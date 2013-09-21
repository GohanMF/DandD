using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;

namespace MvcApplication1.Hubs
{
    [HubName("moveObject")]
    public class MoveObjectHub : Hub
    {
        public void MoveObject(string id, int x, int y)
        {
            Clients.Others.objectMoved(id,x, y);
        }

         
    }
}