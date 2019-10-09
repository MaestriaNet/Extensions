using Maestria.Extensions.Test.CSharp.Interfaces;

namespace Maestria.Extensions.Test.CSharp.Models
{
    public class BaseClass : IBaseInterface
    {
    }

    public class MyClass : BaseClass, IMyInterface
    {
    }

    public class MyClass<T> : MyClass, IMyInterface<T>
    {
    }

    public class MyClass<T1, T2> : MyClass<T1>, IMyInterface<T1, T2>
    {
    }

    public class MyClassImplementer_1_Int : MyClass<int>
    {
    }

    public class MyAnotherClassImplementer_1_Int : MyClass<int>
    {
    }

    public class MyClassImplementer_1_String : MyClass<string>
    {
    }

    public class MyClassImplementer_2_Int_Int : MyClass<int, int>
    {
    }

    public class MyClassImplementer_2_Int_String : MyClass<int, string>
    {
    }
}
