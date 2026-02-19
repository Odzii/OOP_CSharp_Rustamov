namespace Model.Interfaces
{
    public interface IPersonNameSource
    {
        IReadOnlyList<string> MaleNames 
        {
            get; 
        }
        IReadOnlyList<string> FemaleNames 
        { 
            get; 
        }
        IReadOnlyList<string> Surnames 
        {
            get; 
        }
    }
}
