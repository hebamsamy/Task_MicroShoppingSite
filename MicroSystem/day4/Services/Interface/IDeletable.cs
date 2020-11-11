using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MicroShopping.Services
{
   public interface IDeletable
    {
        int Delete(int id);
    }
}
