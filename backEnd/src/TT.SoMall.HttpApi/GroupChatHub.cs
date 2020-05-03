using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using Newtonsoft.Json;

namespace TT.SoMall
{
    public class GroupChatParticipantViewModel : ChatParticipantViewModel
    {
        public IList<ChatParticipantViewModel> ChattingTo { get; set; }
    }

    public class GroupChatHub : Hub
    {
        private static List<ParticipantResponseViewModel> AllConnectedParticipants { get; set; } = new List<ParticipantResponseViewModel>();
        private static List<ParticipantResponseViewModel> DisconnectedParticipants { get; set; } = new List<ParticipantResponseViewModel>();
        private static List<GroupChatParticipantViewModel> AllGroupParticipants { get; set; } = new List<GroupChatParticipantViewModel>();

        private object ParticipantsConnectionLock = new object();

        private static IEnumerable<ParticipantResponseViewModel> FilteredGroupParticipants(string currentUserId)
        {
            return AllConnectedParticipants
                .Where(p => p.Participant.ParticipantType == ChatParticipantTypeEnum.User
                            || AllGroupParticipants.Any(g => g.Id == p.Participant.Id && g.ChattingTo.Any(u => u.Id == currentUserId))
                );
        }

        public static IEnumerable<ParticipantResponseViewModel> ConnectedParticipants(string currentUserId)
        {
            return FilteredGroupParticipants(currentUserId).Where(x => x.Participant.Id != currentUserId);
        }

        public void Join(string userName)
        {
            lock (ParticipantsConnectionLock)
            {
                AllConnectedParticipants.Add(new ParticipantResponseViewModel()
                {
                    Metadata = new ParticipantMetadataViewModel()
                    {
                        TotalUnreadMessages = 0
                    },
                    Participant = new ChatParticipantViewModel()
                    {
                        DisplayName = userName,
                        Id = Context.ConnectionId
                    }
                });

                // This will be used as the user's unique ID to be used on ng-chat as the connected user.
                // You should most likely use another ID on your application
                Clients.Caller.SendAsync("generatedUserId", Context.ConnectionId);

                Clients.All.SendAsync("friendsListChanged", AllConnectedParticipants);
            }
        }

        public void GroupCreated(GroupChatParticipantViewModel group)
        {
            AllGroupParticipants.Add(group);

            // Pushing the current user to the "chatting to" list to keep track of who's created the group as well.
            // In your application you'll probably want a more sofisticated group persistency and management
            group.ChattingTo.Add(new ChatParticipantViewModel()
            {
                Id = Context.ConnectionId
            });

            AllConnectedParticipants.Add(new ParticipantResponseViewModel()
            {
                Metadata = new ParticipantMetadataViewModel()
                {
                    TotalUnreadMessages = 0
                },
                Participant = group
            });

            Clients.All.SendAsync("friendsListChanged", AllConnectedParticipants);
        }

        public void SendMsg(string msg)
        {
            //{"type":1,"fromId":123,"toId":"8ss_ttkQHMql3M-SFviTFQ","message":"123","dateSent":"2020-05-03T14:22:47.965Z"}

            var message = JsonConvert.DeserializeObject<MessageViewModel>(msg);

            var sender = AllConnectedParticipants.Find(x => x.Participant.Id == message.FromId);

            if (sender != null)
            {
                var groupDestinatary = AllGroupParticipants.Where(x => x.Id == message.ToId).FirstOrDefault();

                if (groupDestinatary != null)
                {
                    // Notify all users in the group except the sender
                    var usersInGroupToNotify = AllConnectedParticipants
                        .Where(p => p.Participant.Id != sender.Participant.Id
                                    && groupDestinatary.ChattingTo.Any(g => g.Id == p.Participant.Id)
                        )
                        .Select(g => g.Participant.Id);

                    Clients.Clients(usersInGroupToNotify.ToList()).SendAsync("messageReceived", groupDestinatary, message);
                }
                else
                {
                    Clients.Client(message.ToId).SendAsync("messageReceived", sender.Participant, message);
                }
            }
        }


        public void NewMsg(MessageViewModel message)
        {
            var sender = AllConnectedParticipants.Find(x => x.Participant.Id == message.FromId);

            if (sender != null)
            {
                var groupDestinatary = AllGroupParticipants.Where(x => x.Id == message.ToId).FirstOrDefault();

                if (groupDestinatary != null)
                {
                    // Notify all users in the group except the sender
                    var usersInGroupToNotify = AllConnectedParticipants
                        .Where(p => p.Participant.Id != sender.Participant.Id
                                    && groupDestinatary.ChattingTo.Any(g => g.Id == p.Participant.Id)
                        )
                        .Select(g => g.Participant.Id);

                    Clients.Clients(usersInGroupToNotify.ToList()).SendAsync("messageReceived", groupDestinatary, message);
                }
                else
                {
                    Clients.Client(message.ToId).SendAsync("messageReceived", sender.Participant, message);
                }
            }
        }

        public override Task OnDisconnectedAsync(Exception exception)
        {
            lock (ParticipantsConnectionLock)
            {
                var connectionIndex = AllConnectedParticipants.FindIndex(x => x.Participant.Id == Context.ConnectionId);

                if (connectionIndex >= 0)
                {
                    var participant = AllConnectedParticipants.ElementAt(connectionIndex);

                    var groupsParticipantIsIn = AllGroupParticipants.Where(x => x.ChattingTo.Any(u => u.Id == participant.Participant.Id));

                    AllConnectedParticipants.RemoveAll(x => groupsParticipantIsIn.Any(g => g.Id == x.Participant.Id));
                    AllGroupParticipants.RemoveAll(x => groupsParticipantIsIn.Any(g => g.Id == x.Id));

                    AllConnectedParticipants.Remove(participant);
                    DisconnectedParticipants.Add(participant);

                    Clients.All.SendAsync("friendsListChanged", AllConnectedParticipants);
                }

                return base.OnDisconnectedAsync(exception);
            }
        }

        public override Task OnConnectedAsync()
        {
            lock (ParticipantsConnectionLock)
            {
                var connectionIndex = DisconnectedParticipants.FindIndex(x => x.Participant.Id == Context.ConnectionId);

                if (connectionIndex >= 0)
                {
                    var participant = DisconnectedParticipants.ElementAt(connectionIndex);

                    DisconnectedParticipants.Remove(participant);
                    AllConnectedParticipants.Add(participant);

                    Clients.All.SendAsync("friendsListChanged", AllConnectedParticipants);
                }

                return base.OnConnectedAsync();
            }
        }
    }
}