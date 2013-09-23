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


        public void connect()
        {
             Clients.Caller.onConnected(AllObjects);

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
    }

}