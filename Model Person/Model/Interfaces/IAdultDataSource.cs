namespace Model.Interfaces
{
    public interface IAdultDataSource
    {
        IReadOnlyList<string> PassportsIssuedBy 
        { 
            get; 
        }
        IReadOnlyList<string> WorkplaceNames 
        { 
            get; 
        }
    }
}
