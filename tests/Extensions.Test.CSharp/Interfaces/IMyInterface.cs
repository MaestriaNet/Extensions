namespace Maestria.Extensions.Test.CSharp.Interfaces
{
    public interface IBaseInterface
    {
    }

    public interface IMyInterface : IBaseInterface
    {
    }

    public interface IMyAnotherInterface : IBaseInterface
    {
    }


    public interface IMyInterface<T1> : IMyInterface
    {
    }

    public interface IMyInterface<T1, T2> : IMyInterface<T1>
    {
    }
}
