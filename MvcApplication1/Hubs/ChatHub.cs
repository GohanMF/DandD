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

           if (ConnectedUsers.Count(x => x.ConnectionId == id) == 0)
           {

               ConnectedUsers.Add(new UserDetail { ConnectionId = id, UserName = userName });
               
               Clients.Caller.onConnected(id, userName, ConnectedUsers, CurrentMessages);
               Clients.AllExcept(id).onNewUserConnected(id, userName);
           }
       }

        public void SendToAll(string name, string message)
        {
            //call the AddNewMessageToPage method to update clients.
            Clients.All.addNewMessageToPage(name, message);
     
        }



        public void SendToPrivate(string who, string message) { 

        }

        public override System.Threading.Tasks.Task OnDisconnected()
        {
           



            return base.OnDisconnected();
        }
    }
}