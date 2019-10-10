using System.Text;

namespace LT.Core.Seedwork.Data
{
    public interface IHasId
    {
        object Id { get; }

    }

    public interface IHasId<T> : IHasId
    {
#pragma warning disable CS0108 // Member hides inherited member; missing new keyword
        T Id { get; }
#pragma warning restore CS0108 // Member hides inherited member; missing new keyword
    }
}
