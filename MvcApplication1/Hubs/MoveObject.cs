using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using chat.Common;
namespace SignalHubs
{
    public class MoveObjectHub : Hub
    {

        static List<allObjects> AllObjects = new List<allObjects>();
        static List<UserDetail> ConnectedUsers = new List<UserDetail>();

        public void connect(string username)
        {
            var id = Context.ConnectionId;

            if (ConnectedUsers.Count(x => x.connectionId == id) == 0)
            {
                ConnectedUsers.Add(new UserDetail { connectionId = id, userName = username });
             //   Clients.Caller.onConnected(AllObjects);
                if (username != string.Empty)
                {
                    Clients.All.newObject(username);
                }
            }


        }
        
        
        public void MoveObject(string id, int x, int y)
        {
            Clients.Others.objectMoved(id, x, y);
        }

                
        
        public void InsertobjectintoDiv(string idObject, string idDiv)
        {
            Clients.Others.objectInsertedDiv(idObject, idDiv);
        }

        
        
        
        
        public void especificPossition(string objid, string objcssClass, string objpossitionId)
        {
            AllObjects.Add(new allObjects { id = objid, cssClass = objcssClass, mypossition = objpossitionId });
        }

        public override System.Threading.Tasks.Task OnDisconnected()
        {

            var item = ConnectedUsers.FirstOrDefault(x => x.connectionId == Context.ConnectionId);
            if (item != null)
            {
                ConnectedUsers.Remove(item);
                Clients.All.removeObject(item.userName);
            }
            return base.OnDisconnected();
        }
    }

}