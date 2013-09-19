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

           if (ConnectedUsers.Count(x => x.connectionId == id) == 0)
           {

               ConnectedUsers.Add(new UserDetail { connectionId = id, userName = userName });
               Clients.AllExcept(id).onNewUserConnected(id, userName);
               Clients.Caller.onConnected(ConnectedUsers, CurrentMessages);
             
           }
       }

       public void SendMessageToAll(string name, string message)
        {
            //call the AddNewMessageToPage method to update clients.
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