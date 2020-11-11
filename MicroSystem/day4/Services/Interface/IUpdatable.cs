using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MicroShopping.Services
{
   public interface IUpdatable<T>
    {
        int Update(int id, T model);
    }
}
