using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MicroShopping.Services
{
    public interface IReadable<T>
    {
        List<T> GetAll();
        T GetDetails(int id);
    }
}
