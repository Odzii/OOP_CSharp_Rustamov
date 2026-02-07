using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabFirst
{
    public interface INameSource
    {
        IReadOnlyList<string> MaleNames { get; }
        IReadOnlyList<string> FemaleNames { get; }
        IReadOnlyList<string> Surnames { get; }
    }
}
