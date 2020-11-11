using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MicroShopping.Services
{
   public interface ICreatable<T>
    {
        int Add(T Model);
    }
}
