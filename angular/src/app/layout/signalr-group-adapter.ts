import { ChatAdapter, IChatGroupAdapter, User, Group, Message, ChatParticipantStatus, ParticipantResponse, ParticipantMetadata, ChatParticipantType, IChatParticipant } from 'ng-chat';
import { Observable, of } from 'rxjs';
import { map, catchError } from 'rxjs/operators';
import { HttpClient } from '@angular/common/http';

import * as signalR from "@aspnet/signalr";
import { environment } from '@env/environment';

export class SignalRGroupAdapter extends ChatAdapter implements IChatGroupAdapter {
    public userId: string;



    private hubConnection: signalR.HubConnection
    public static serverBaseUrl: string = environment.apis.default.signalR; // Set this to 'https://localhost:5001/' if running locally

    constructor(private username: string, private avatar: string, private http: HttpClient) {
        super();

        this.initializeConnection();
    }

    private initializeConnection(): void {
        this.hubConnection = new signalR.HubConnectionBuilder()
            .withUrl(`${SignalRGroupAdapter.serverBaseUrl}/groupchat`,
                {   // 这里使用WebSockets，不这样写连不上的
                    skipNegotiation: true,
                    transport: signalR.HttpTransportType.WebSockets
                })
            .build();

        this.hubConnection
            .start()
            .then(() => {
                this.joinRoom();
                this.initializeListeners();
            })
            .catch(err => console.log(`Error while starting SignalR connection: ${err}`));
    }

    private initializeListeners(): void {
        this.hubConnection.on("generatedUserId", (userId) => {
            // With the userId set the chat will be rendered
            console.log("client on generatedUserId ", userId, this.userId)
            this.userId = userId;
        });

        this.hubConnection.on("messageReceived", (participant, message) => {
            // Handle the received message to ng-chat
            console.log("client on messageReceived", participant, message)
            this.onMessageReceived(participant, message);
        });

        this.hubConnection.on("friendsListChanged", (participantsResponse: Array<ParticipantResponse>) => {
            console.log("client on friendsListChanged ", participantsResponse, this.userId)
            // Use polling for the friends list for this simple group example
            // If you want to use push notifications you will have to send filtered messages through your hub instead of using the "All" broadcast channel
            this.onFriendsListChanged(participantsResponse.filter(x => x.participant.id != this.userId));
        });
    }

    joinRoom(): void {
        if (this.hubConnection
            //  && this.hubConnection..state == signalR.HubConnectionState.Connected
        ) {
            this.hubConnection.send("join", this.username, this.avatar);
        }
    }

    listFriends(): Observable<ParticipantResponse[]> {
        // List connected users to show in the friends list
        // Sending the userId from the request body as this is just a demo 
        return this.http
            .post(`${environment.apis.default.url}/home/listFriends`, { currentUserId: this.userId })
            .pipe(
                map((res: any) => res),
                catchError((error: any) => Observable.throw(error.error || 'Server error'))
            );
    }

    getMessageHistory(destinataryId: any): Observable<Message[]> {
        // This could be an API call to your web application that would go to the database
        // and retrieve a N amount of history messages between the users.

        // return this.http
        //     .get(`${environment.apis.default.url}/home/historyMessage`, {
        //         params: {
        //             from: destinataryId,
        //             to: destinataryId
        //         }
        //     })
        //     .pipe(
        //         map((res: any) => res),
        //         catchError((error: any) => Observable.throw(error.error || 'Server error'))
        //     );
        return of([]);
    }

    sendMessage(message: Message): void {
        if (this.hubConnection
            //  && this.hubConnection.state == 1
        ) {
            console.log("client on sendMessage", message)
            this.hubConnection.send("sendMsg", JSON.stringify(message));
        }
    }

    groupCreated(group: Group): void {
        this.hubConnection.send("groupCreated", group);
    }
}
