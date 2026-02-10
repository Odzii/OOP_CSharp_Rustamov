using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabFirst
{
    public interface IPersonNameSource
    {
        IReadOnlyList<string> MaleNames { get; }
        IReadOnlyList<string> FemaleNames { get; }
        IReadOnlyList<string> Surnames { get; }
    }

    public interface IAdultDataSource
    {
        IReadOnlyList<string> PassportsIssuedBy { get; }
        IReadOnlyList<string> WorkplaceNames { get; }
    }

    public interface IChildEducationSource
    {
        IReadOnlyList<string> KinderGardens { get; }
        IReadOnlyList<string> Schools{ get; }

    }

}
