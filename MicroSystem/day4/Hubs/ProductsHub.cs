using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MicroShopping.Hubs
{
   
        [HubName("ProductsHub")]
        public class ProductsHub : Hub
        {
        }
    
}
