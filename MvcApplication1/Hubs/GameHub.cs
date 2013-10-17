using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using chat.Common;



//word Receive and Send
//-------------------------------------------------
//JS who's request and Receive the signals so 
//JS receive signals
//JS send signals
//the function in JS are like ReceiveNewUser 
namespace SignalHubs
{
    public class GameHub : Hub
    {
        static List<UserDetail> ConnectedUsers = new List<UserDetail>();
        static List<MessageDetail> CurrentMessages = new List<MessageDetail>();
        // this part is going to receive client calls
        public void connect(String logging_UserName)
        {

            UserDetail User;

            if (ConnectedUsers.Count(x => x.userName == logging_UserName) == 0)
            {
                User = new UserDetail(logging_UserName.ToString(), Context.ConnectionId.ToString());
                ConnectedUsers.Add(User);
            }
            else { 
                User = ConnectedUsers.Find(x => x.userName == logging_UserName);
            }


            //send to other
            //new user arrived 
            Clients.Others.ReceiveNewUser(User);
            
            //send to caller
            //list others users
            Clients.Caller.ReceiveAllUser(ConnectedUsers);


            //send to caller 
            //old messages
            Clients.Caller.ReceiveOldMessages(CurrentMessages);

        }




      
    }
}