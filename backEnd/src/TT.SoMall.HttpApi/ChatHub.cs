using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using Volo.Abp.Users;

namespace TT.SoMall
{
    public class ErrorViewModel
    {
        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }

    public enum ChatParticipantTypeEnum
    {
        User = 0,
        Group = 1
    }

    public class ChatParticipantViewModel
    {
        public ChatParticipantTypeEnum ParticipantType { get; set; }
        public string Id { get; set; }
        public string ConnectionId { get; set; }
        
        public int Status { get; set; }
        
        public string Avatar { get; set; }
        public string DisplayName { get; set; }
    }

    public class ParticipantMetadataViewModel
    {
        public int TotalUnreadMessages { get; set; }
    }

    public class ParticipantResponseViewModel
    {
        public ChatParticipantViewModel Participant { get; set; }
        public ParticipantMetadataViewModel Metadata { get; set; }
    }

    public class ChatHub : Hub
    {
        private readonly ICurrentUser _currentUser;

        public ChatHub(ICurrentUser currentUser)
        {
            _currentUser = currentUser;
        }

        private static List<ParticipantResponseViewModel> AllConnectedParticipants { get; set; } = new List<ParticipantResponseViewModel>();
        private static List<ParticipantResponseViewModel> DisconnectedParticipants { get; set; } = new List<ParticipantResponseViewModel>();
        private object ParticipantsConnectionLock = new object();

        public static IEnumerable<ParticipantResponseViewModel> ConnectedParticipants(string currentUserId)
        {
            return AllConnectedParticipants
                .Where(x => x.Participant.Id != currentUserId);
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
                        DisplayName = userName ?? "UnSet",
                        Id = Context.ConnectionId
                    }
                });

                // This will be used as the user's unique ID to be used on ng-chat as the connected user.
                // You should most likely use another ID on your application
                Clients.Caller.SendAsync("generatedUserId", Context.ConnectionId);

                Clients.All.SendAsync("friendsListChanged", AllConnectedParticipants);
            }
        }

        public void SendMessage(MessageViewModel message)
        {
            var sender = AllConnectedParticipants.Find(x => x.Participant.Id == message.FromId);

            if (sender != null)
            {
                Clients.Client(message.ToId).SendAsync("messageReceived", sender.Participant, message);
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
                var user = _currentUser;
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