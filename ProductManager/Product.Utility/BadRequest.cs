using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Utility
{
        
    public class BadRequest : Exception
    {
    public  BadRequest (string msg): base(msg){}
         
    
    }
}