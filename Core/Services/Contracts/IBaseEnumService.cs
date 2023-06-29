namespace Core.Services.Contracts
{
    public interface IBaseEnumService<T> where T : Enum
    {
        Dictionary<int, string> GetLookup();
    }
}