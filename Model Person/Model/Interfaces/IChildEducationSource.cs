namespace Model.Interfaces
{
    public interface IChildEducationSource
    {
        IReadOnlyList<string> KinderGardens { get; }
        IReadOnlyList<string> Schools { get; }
    }
}
