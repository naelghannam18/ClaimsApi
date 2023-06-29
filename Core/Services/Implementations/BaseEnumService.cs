namespace Core.Services.Implementations;

using Core.Services.Contracts;
using Domain.Extensions;
public abstract class BaseEnumService<T> : IBaseEnumService<T> where T : Enum
{
    public BaseEnumService()
    {

    }

    public virtual Dictionary<int, string> GetLookup() => EnumExtensions.ToKeyLookup<T>();
}
