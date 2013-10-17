using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using chat.Common;
namespace SignalHubs
{
    public class ChatHub : Hub
    {

       static List<UserDetail> ConnectedUsers = new List<UserDetail>();
       static List<MessageDetail> CurrentMessages = new List<MessageDetail>();

       public void connect(string userName)
       {

           
           var id = Context.ConnectionId;

           if (ConnectedUsers.Count(x => x.userName == userName) == 0)
           {
               
               var user_character = new allObjects();
               var lista_objct  = new List<allObjects>();
               lista_objct.Add(user_character);



               ConnectedUsers.Add(new UserDetail { connectionId = id, userName = userName , objects = lista_objct });
               Clients.Others.onNewUserConnected(id, userName , user_character);
               Clients.Caller.onConnected(ConnectedUsers, CurrentMessages , user_character);


           }
           else {

                var user = ConnectedUsers.Find(x => x.userName == userName);
                ConnectedUsers.Remove(user);
                user.connectionId = id;
                ConnectedUsers.Add(user);
           }
       }

       public void SendMessageToAll(string name, string message)
        {
            //call the AddNewMessageToPage method to update clients.
            CurrentMessages.Add(new MessageDetail { message = message, userName = name });
           Clients.All.addNewMessageToPage(name, message);
     
        }



        public void SendToPrivate(string who, string message) { 

        }

        public override System.Threading.Tasks.Task OnDisconnected()
        {

            var item = ConnectedUsers.FirstOrDefault(x => x.connectionId == Context.ConnectionId);
            if (item != null)
            {
                ConnectedUsers.Remove(item);
                var id = Context.ConnectionId;
                Clients.All.addNewMessageToPage(item.userName + " is offline" , "");
                Clients.All.onUserDisconnected(id);
            }
            return base.OnDisconnected();
        }
    }
}