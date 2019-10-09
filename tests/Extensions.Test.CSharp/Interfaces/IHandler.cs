using System.Threading.Tasks;

namespace Maestria.Extensions.Test.CSharp.Interfaces
{
    public interface IHandler<in TCommand>
    {
        Task HandlerAsync(TCommand message);
    }

    public interface IHandler<in TCommand, TResult>
    {
        Task<TResult> HandlerAsync(TCommand message);
    }
}