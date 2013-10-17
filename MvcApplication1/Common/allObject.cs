using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace chat.Common
{
    public class allObjects
    {

        //properties
        public String id { get; set; }
        public String cssClass { get; set; }
        public String myPossition { get; set; }
       // public String userId { get; set; }



        //inizzializer
        public allObjects() {
            id = Guid.NewGuid().ToString();
            cssClass = "shape draggable";
        }
    }

    
}