namespace Model.Interfaces
{
    //TODO: XML
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
