using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabFirst
{
    public interface IPersonFactory<out T> where T: Person
    {
        T Create();
    }
}
