using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace chat.Common
{
    public class UserDetail
    {
       public String connectionId {get;set;}
       public String userName {get;set;}
       public List<allObjects> MyObjects {get;set;}


       public UserDetail(string name, string id)
       {
           connectionId = id;
           userName = name;
           allObjects firstObject = new allObjects();
           MyObjects.Add(firstObject);

       }

    }

   
}