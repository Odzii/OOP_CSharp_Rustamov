namespace LabFirst
{
    //TODO: разделить интерфейсы по файлам.
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
