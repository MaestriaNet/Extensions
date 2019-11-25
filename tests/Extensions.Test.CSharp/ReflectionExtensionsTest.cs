using Maestria.Extensions.Test.CSharp.Interfaces;
using Maestria.Extensions.Test.CSharp.Models;
using NUnit.Framework;

namespace Maestria.Extensions.Test.CSharp
{
    public class ReflectionUtilsTest
    {
        [Test]
        public void IsInheritedOrImplements_InterfaceFromInterface()
        {
            Assert.IsTrue(typeof(IBaseInterface).IsInheritedOrImplements(typeof(IBaseInterface)));
            Assert.IsFalse(typeof(IBaseInterface).IsInheritedOrImplements(typeof(IMyInterface)));
            Assert.IsFalse(typeof(IBaseInterface).IsInheritedOrImplements(typeof(IMyInterface<>)));
            Assert.IsFalse(typeof(IBaseInterface).IsInheritedOrImplements(typeof(IMyInterface<,>)));

            Assert.IsTrue(typeof(IMyInterface).IsInheritedOrImplements(typeof(IBaseInterface)));
            Assert.IsTrue(typeof(IMyInterface).IsInheritedOrImplements(typeof(IMyInterface)));
            Assert.IsFalse(typeof(IMyInterface).IsInheritedOrImplements(typeof(IMyInterface<>)));
            Assert.IsFalse(typeof(IMyInterface).IsInheritedOrImplements(typeof(IMyInterface<,>)));

            Assert.IsTrue(typeof(IMyInterface<>).IsInheritedOrImplements(typeof(IBaseInterface)));
            Assert.IsTrue(typeof(IMyInterface<>).IsInheritedOrImplements(typeof(IMyInterface)));
            Assert.IsTrue(typeof(IMyInterface<>).IsInheritedOrImplements(typeof(IMyInterface<>)));
            Assert.IsFalse(typeof(IMyInterface<>).IsInheritedOrImplements(typeof(IMyInterface<,>)));

            Assert.IsTrue(typeof(IMyInterface<,>).IsInheritedOrImplements(typeof(IBaseInterface)));
            Assert.IsTrue(typeof(IMyInterface<,>).IsInheritedOrImplements(typeof(IMyInterface)));
            Assert.IsTrue(typeof(IMyInterface<,>).IsInheritedOrImplements(typeof(IMyInterface<>)));
            Assert.IsTrue(typeof(IMyInterface<,>).IsInheritedOrImplements(typeof(IMyInterface<,>)));

            Assert.IsFalse(typeof(IMyInterface).IsInheritedOrImplements(typeof(IMyAnotherInterface)));
            Assert.IsFalse(typeof(IMyAnotherInterface).IsInheritedOrImplements(typeof(IMyInterface)));
            Assert.IsFalse(typeof(IMyInterface<>).IsInheritedOrImplements(typeof(IMyAnotherInterface)));
            Assert.IsFalse(typeof(IMyInterface<,>).IsInheritedOrImplements(typeof(IMyAnotherInterface)));
            Assert.IsFalse(typeof(IMyInterface<int>).IsInheritedOrImplements(typeof(IMyAnotherInterface)));
            Assert.IsFalse(typeof(IMyInterface<object>).IsInheritedOrImplements(typeof(IMyAnotherInterface)));
            Assert.IsFalse(typeof(IMyInterface<object, object>).IsInheritedOrImplements(typeof(IMyAnotherInterface)));
            Assert.IsFalse(typeof(IMyInterface<int, int>).IsInheritedOrImplements(typeof(IMyAnotherInterface)));
        }

        [Test]
        public void IsInheritedOrImplements_ClassFromInterface()
        {
            Assert.IsTrue(typeof(BaseClass).IsInheritedOrImplements(typeof(IBaseInterface)));
            Assert.IsFalse(typeof(BaseClass).IsInheritedOrImplements(typeof(IMyInterface)));
            Assert.IsFalse(typeof(BaseClass).IsInheritedOrImplements(typeof(IMyInterface<>)));
            Assert.IsFalse(typeof(BaseClass).IsInheritedOrImplements(typeof(IMyInterface<,>)));

            Assert.IsTrue(typeof(MyClass).IsInheritedOrImplements(typeof(IBaseInterface)));
            Assert.IsTrue(typeof(MyClass).IsInheritedOrImplements(typeof(IMyInterface)));
            Assert.IsFalse(typeof(MyClass).IsInheritedOrImplements(typeof(IMyInterface<>)));
            Assert.IsFalse(typeof(MyClass).IsInheritedOrImplements(typeof(IMyInterface<,>)));

            Assert.IsTrue(typeof(MyClass<>).IsInheritedOrImplements(typeof(IBaseInterface)));
            Assert.IsTrue(typeof(MyClass<>).IsInheritedOrImplements(typeof(IMyInterface)));
            Assert.IsTrue(typeof(MyClass<>).IsInheritedOrImplements(typeof(IMyInterface<>)));
            Assert.IsFalse(typeof(MyClass<>).IsInheritedOrImplements(typeof(IMyInterface<,>)));

            Assert.IsTrue(typeof(MyClass<,>).IsInheritedOrImplements(typeof(IBaseInterface)));
            Assert.IsTrue(typeof(MyClass<,>).IsInheritedOrImplements(typeof(IMyInterface)));
            Assert.IsTrue(typeof(MyClass<,>).IsInheritedOrImplements(typeof(IMyInterface<>)));
            Assert.IsTrue(typeof(MyClass<,>).IsInheritedOrImplements(typeof(IMyInterface<,>)));

            Assert.IsTrue(typeof(MyClassImplementer_1_Int).IsInheritedOrImplements(typeof(IBaseInterface)));
            Assert.IsTrue(typeof(MyClassImplementer_1_Int).IsInheritedOrImplements(typeof(IMyInterface)));
            Assert.IsTrue(typeof(MyClassImplementer_1_Int).IsInheritedOrImplements(typeof(IMyInterface<int>)));
            Assert.IsTrue(typeof(MyClassImplementer_1_Int).IsInheritedOrImplements(typeof(IMyInterface<object>)));
            Assert.IsFalse(typeof(MyClassImplementer_1_Int).IsInheritedOrImplements(typeof(IMyInterface<string>)));

            Assert.IsTrue(typeof(MyClassImplementer_1_String).IsInheritedOrImplements(typeof(IBaseInterface)));
            Assert.IsTrue(typeof(MyClassImplementer_1_String).IsInheritedOrImplements(typeof(IMyInterface)));
            Assert.IsFalse(typeof(MyClassImplementer_1_String).IsInheritedOrImplements(typeof(IMyInterface<int>)));
            Assert.IsTrue(typeof(MyClassImplementer_1_String).IsInheritedOrImplements(typeof(IMyInterface<object>)));
            Assert.IsTrue(typeof(MyClassImplementer_1_String).IsInheritedOrImplements(typeof(IMyInterface<string>)));

            Assert.IsTrue(typeof(MyClassImplementer_2_Int_Int).IsInheritedOrImplements(typeof(IBaseInterface)));
            Assert.IsTrue(typeof(MyClassImplementer_2_Int_Int).IsInheritedOrImplements(typeof(IMyInterface)));
            Assert.IsTrue(typeof(MyClassImplementer_2_Int_Int).IsInheritedOrImplements(typeof(IMyInterface<int>)));
            Assert.IsTrue(typeof(MyClassImplementer_2_Int_Int).IsInheritedOrImplements(typeof(IMyInterface<int, int>)));
            Assert.IsTrue(typeof(MyClassImplementer_2_Int_Int).IsInheritedOrImplements(typeof(IMyInterface<object>)));
            Assert.IsTrue(typeof(MyClassImplementer_2_Int_Int).IsInheritedOrImplements(typeof(IMyInterface<int, object>)));
            Assert.IsTrue(typeof(MyClassImplementer_2_Int_Int).IsInheritedOrImplements(typeof(IMyInterface<object, int>)));
            Assert.IsTrue(typeof(MyClassImplementer_2_Int_Int).IsInheritedOrImplements(typeof(IMyInterface<object, object>)));
            Assert.IsFalse(typeof(MyClassImplementer_2_Int_Int).IsInheritedOrImplements(typeof(IMyInterface<string>)));
            Assert.IsFalse(typeof(MyClassImplementer_2_Int_Int).IsInheritedOrImplements(typeof(IMyInterface<object, string>)));
            Assert.IsFalse(typeof(MyClassImplementer_2_Int_Int).IsInheritedOrImplements(typeof(IMyInterface<string, object>)));
            Assert.IsFalse(typeof(MyClassImplementer_2_Int_Int).IsInheritedOrImplements(typeof(IMyInterface<string, string>)));

            Assert.IsTrue(typeof(MyClassImplementer_2_Int_String).IsInheritedOrImplements(typeof(IBaseInterface)));
            Assert.IsTrue(typeof(MyClassImplementer_2_Int_String).IsInheritedOrImplements(typeof(IMyInterface)));
            Assert.IsTrue(typeof(MyClassImplementer_2_Int_String).IsInheritedOrImplements(typeof(IMyInterface<int>)));
            Assert.IsTrue(typeof(MyClassImplementer_2_Int_String).IsInheritedOrImplements(typeof(IMyInterface<int, string>)));
            Assert.IsTrue(typeof(MyClassImplementer_2_Int_String).IsInheritedOrImplements(typeof(IMyInterface<object>)));
            Assert.IsTrue(typeof(MyClassImplementer_2_Int_String).IsInheritedOrImplements(typeof(IMyInterface<int, object>)));
            Assert.IsTrue(typeof(MyClassImplementer_2_Int_String).IsInheritedOrImplements(typeof(IMyInterface<object, string>)));
            Assert.IsTrue(typeof(MyClassImplementer_2_Int_String).IsInheritedOrImplements(typeof(IMyInterface<object, object>)));
            Assert.IsFalse(typeof(MyClassImplementer_2_Int_String).IsInheritedOrImplements(typeof(IMyInterface<string>)));
            Assert.IsFalse(typeof(MyClassImplementer_2_Int_String).IsInheritedOrImplements(typeof(IMyInterface<object, int>)));
            Assert.IsFalse(typeof(MyClassImplementer_2_Int_String).IsInheritedOrImplements(typeof(IMyInterface<string, object>)));
            Assert.IsFalse(typeof(MyClassImplementer_2_Int_String).IsInheritedOrImplements(typeof(IMyInterface<string, string>)));
        }

        [Test]
        public void IsInheritedOrImplements_ClassFromClass()
        {
            Assert.IsTrue(typeof(BaseClass).IsInheritedOrImplements(typeof(BaseClass)));
            Assert.IsFalse(typeof(BaseClass).IsInheritedOrImplements(typeof(MyClass)));
            Assert.IsFalse(typeof(BaseClass).IsInheritedOrImplements(typeof(MyClass<>)));
            Assert.IsFalse(typeof(BaseClass).IsInheritedOrImplements(typeof(MyClass<,>)));

            Assert.IsTrue(typeof(MyClass).IsInheritedOrImplements(typeof(BaseClass)));
            Assert.IsTrue(typeof(MyClass).IsInheritedOrImplements(typeof(MyClass)));
            Assert.IsFalse(typeof(MyClass).IsInheritedOrImplements(typeof(MyClass<>)));
            Assert.IsFalse(typeof(MyClass).IsInheritedOrImplements(typeof(MyClass<,>)));

            Assert.IsTrue(typeof(MyClass<>).IsInheritedOrImplements(typeof(BaseClass)));
            Assert.IsTrue(typeof(MyClass<>).IsInheritedOrImplements(typeof(MyClass)));
            Assert.IsTrue(typeof(MyClass<>).IsInheritedOrImplements(typeof(MyClass<>)));
            Assert.IsFalse(typeof(MyClass<>).IsInheritedOrImplements(typeof(MyClass<,>)));

            Assert.IsTrue(typeof(MyClass<,>).IsInheritedOrImplements(typeof(BaseClass)));
            Assert.IsTrue(typeof(MyClass<,>).IsInheritedOrImplements(typeof(MyClass)));
            Assert.IsTrue(typeof(MyClass<,>).IsInheritedOrImplements(typeof(MyClass<>)));
            Assert.IsTrue(typeof(MyClass<,>).IsInheritedOrImplements(typeof(MyClass<,>)));

            Assert.IsTrue(typeof(MyClassImplementer_1_Int).IsInheritedOrImplements(typeof(BaseClass)));
            Assert.IsTrue(typeof(MyClassImplementer_1_Int).IsInheritedOrImplements(typeof(MyClass)));
            Assert.IsTrue(typeof(MyClassImplementer_1_Int).IsInheritedOrImplements(typeof(MyClass<int>)));
            Assert.IsTrue(typeof(MyClassImplementer_1_Int).IsInheritedOrImplements(typeof(MyClass<object>)));
            Assert.IsFalse(typeof(MyClassImplementer_1_Int).IsInheritedOrImplements(typeof(MyClass<string>)));

            Assert.IsTrue(typeof(MyClassImplementer_1_String).IsInheritedOrImplements(typeof(BaseClass)));
            Assert.IsTrue(typeof(MyClassImplementer_1_String).IsInheritedOrImplements(typeof(MyClass)));
            Assert.IsFalse(typeof(MyClassImplementer_1_String).IsInheritedOrImplements(typeof(MyClass<int>)));
            Assert.IsTrue(typeof(MyClassImplementer_1_String).IsInheritedOrImplements(typeof(MyClass<object>)));
            Assert.IsTrue(typeof(MyClassImplementer_1_String).IsInheritedOrImplements(typeof(MyClass<string>)));

            Assert.IsTrue(typeof(MyClassImplementer_2_Int_Int).IsInheritedOrImplements(typeof(BaseClass)));
            Assert.IsTrue(typeof(MyClassImplementer_2_Int_Int).IsInheritedOrImplements(typeof(MyClass)));
            Assert.IsTrue(typeof(MyClassImplementer_2_Int_Int).IsInheritedOrImplements(typeof(MyClass<int>)));
            Assert.IsTrue(typeof(MyClassImplementer_2_Int_Int).IsInheritedOrImplements(typeof(MyClass<int, int>)));
            Assert.IsTrue(typeof(MyClassImplementer_2_Int_Int).IsInheritedOrImplements(typeof(MyClass<object>)));
            Assert.IsTrue(typeof(MyClassImplementer_2_Int_Int).IsInheritedOrImplements(typeof(MyClass<int, object>)));
            Assert.IsTrue(typeof(MyClassImplementer_2_Int_Int).IsInheritedOrImplements(typeof(MyClass<object, int>)));
            Assert.IsTrue(typeof(MyClassImplementer_2_Int_Int).IsInheritedOrImplements(typeof(MyClass<object, object>)));
            Assert.IsFalse(typeof(MyClassImplementer_2_Int_Int).IsInheritedOrImplements(typeof(MyClass<string>)));
            Assert.IsFalse(typeof(MyClassImplementer_2_Int_Int).IsInheritedOrImplements(typeof(MyClass<object, string>)));
            Assert.IsFalse(typeof(MyClassImplementer_2_Int_Int).IsInheritedOrImplements(typeof(MyClass<string, object>)));
            Assert.IsFalse(typeof(MyClassImplementer_2_Int_Int).IsInheritedOrImplements(typeof(MyClass<string, string>)));

            Assert.IsTrue(typeof(MyClassImplementer_2_Int_String).IsInheritedOrImplements(typeof(BaseClass)));
            Assert.IsTrue(typeof(MyClassImplementer_2_Int_String).IsInheritedOrImplements(typeof(MyClass)));
            Assert.IsTrue(typeof(MyClassImplementer_2_Int_String).IsInheritedOrImplements(typeof(MyClass<int>)));
            Assert.IsTrue(typeof(MyClassImplementer_2_Int_String).IsInheritedOrImplements(typeof(MyClass<int, string>)));
            Assert.IsTrue(typeof(MyClassImplementer_2_Int_String).IsInheritedOrImplements(typeof(MyClass<object>)));
            Assert.IsTrue(typeof(MyClassImplementer_2_Int_String).IsInheritedOrImplements(typeof(MyClass<int, object>)));
            Assert.IsTrue(typeof(MyClassImplementer_2_Int_String).IsInheritedOrImplements(typeof(MyClass<object, string>)));
            Assert.IsTrue(typeof(MyClassImplementer_2_Int_String).IsInheritedOrImplements(typeof(MyClass<object, object>)));
            Assert.IsFalse(typeof(MyClassImplementer_2_Int_String).IsInheritedOrImplements(typeof(MyClass<string>)));
            Assert.IsFalse(typeof(MyClassImplementer_2_Int_String).IsInheritedOrImplements(typeof(MyClass<object, int>)));
            Assert.IsFalse(typeof(MyClassImplementer_2_Int_String).IsInheritedOrImplements(typeof(MyClass<string, object>)));
            Assert.IsFalse(typeof(MyClassImplementer_2_Int_String).IsInheritedOrImplements(typeof(MyClass<string, string>)));

            Assert.IsFalse(typeof(MyClassImplementer_1_Int).IsInheritedOrImplements(typeof(MyAnotherClassImplementer_1_Int)));
        }

        [Test]
        public void IsInheritedOrImplements_InterfaceFromClass()
        {
            Assert.IsFalse(typeof(IBaseInterface).IsInheritedOrImplements(typeof(BaseClass)));
            Assert.IsFalse(typeof(IMyInterface).IsInheritedOrImplements(typeof(BaseClass)));
            Assert.IsFalse(typeof(IMyInterface<>).IsInheritedOrImplements(typeof(BaseClass)));
            Assert.IsFalse(typeof(IMyInterface<,>).IsInheritedOrImplements(typeof(BaseClass)));

            Assert.IsFalse(typeof(IBaseInterface).IsInheritedOrImplements(typeof(MyClass)));
            Assert.IsFalse(typeof(IMyInterface).IsInheritedOrImplements(typeof(MyClass)));
            Assert.IsFalse(typeof(IMyInterface<>).IsInheritedOrImplements(typeof(MyClass)));
            Assert.IsFalse(typeof(IMyInterface<,>).IsInheritedOrImplements(typeof(MyClass)));

            Assert.IsFalse(typeof(IBaseInterface).IsInheritedOrImplements(typeof(MyClass<>)));
            Assert.IsFalse(typeof(IMyInterface).IsInheritedOrImplements(typeof(MyClass<>)));
            Assert.IsFalse(typeof(IMyInterface<>).IsInheritedOrImplements(typeof(MyClass<>)));
            Assert.IsFalse(typeof(IMyInterface<,>).IsInheritedOrImplements(typeof(MyClass<>)));

            Assert.IsFalse(typeof(IBaseInterface).IsInheritedOrImplements(typeof(MyClass<,>)));
            Assert.IsFalse(typeof(IMyInterface).IsInheritedOrImplements(typeof(MyClass<,>)));
            Assert.IsFalse(typeof(IMyInterface<>).IsInheritedOrImplements(typeof(MyClass<,>)));
            Assert.IsFalse(typeof(IMyInterface<,>).IsInheritedOrImplements(typeof(MyClass<,>)));

            Assert.IsFalse(typeof(IBaseInterface).IsInheritedOrImplements(typeof(MyClassImplementer_1_Int)));
            Assert.IsFalse(typeof(IMyInterface).IsInheritedOrImplements(typeof(MyClassImplementer_1_Int)));
            Assert.IsFalse(typeof(IMyInterface<int>).IsInheritedOrImplements(typeof(MyClassImplementer_1_Int)));
            Assert.IsFalse(typeof(IMyInterface<object>).IsInheritedOrImplements(typeof(MyClassImplementer_1_Int)));
            Assert.IsFalse(typeof(IMyInterface<string>).IsInheritedOrImplements(typeof(MyClassImplementer_1_Int)));

            Assert.IsFalse(typeof(IBaseInterface).IsInheritedOrImplements(typeof(MyClassImplementer_1_String)));
            Assert.IsFalse(typeof(IMyInterface).IsInheritedOrImplements(typeof(MyClassImplementer_1_String)));
            Assert.IsFalse(typeof(IMyInterface<int>).IsInheritedOrImplements(typeof(MyClassImplementer_1_String)));
            Assert.IsFalse(typeof(IMyInterface<object>).IsInheritedOrImplements(typeof(MyClassImplementer_1_String)));
            Assert.IsFalse(typeof(IMyInterface<string>).IsInheritedOrImplements(typeof(MyClassImplementer_1_String)));

            Assert.IsFalse(typeof(IBaseInterface).IsInheritedOrImplements(typeof(MyClassImplementer_2_Int_Int)));
            Assert.IsFalse(typeof(IMyInterface).IsInheritedOrImplements(typeof(MyClassImplementer_2_Int_Int)));
            Assert.IsFalse(typeof(IMyInterface<int>).IsInheritedOrImplements(typeof(MyClassImplementer_2_Int_Int)));
            Assert.IsFalse(typeof(IMyInterface<int, int>).IsInheritedOrImplements(typeof(MyClassImplementer_2_Int_Int)));
            Assert.IsFalse(typeof(IMyInterface<object>).IsInheritedOrImplements(typeof(MyClassImplementer_2_Int_Int)));
            Assert.IsFalse(typeof(IMyInterface<int, object>).IsInheritedOrImplements(typeof(MyClassImplementer_2_Int_Int)));
            Assert.IsFalse(typeof(IMyInterface<object, int>).IsInheritedOrImplements(typeof(MyClassImplementer_2_Int_Int)));
            Assert.IsFalse(typeof(IMyInterface<object, object>).IsInheritedOrImplements(typeof(MyClassImplementer_2_Int_Int)));
            Assert.IsFalse(typeof(IMyInterface<string>).IsInheritedOrImplements(typeof(MyClassImplementer_2_Int_Int)));
            Assert.IsFalse(typeof(IMyInterface<object, string>).IsInheritedOrImplements(typeof(MyClassImplementer_2_Int_Int)));
            Assert.IsFalse(typeof(IMyInterface<string, object>).IsInheritedOrImplements(typeof(MyClassImplementer_2_Int_Int)));
            Assert.IsFalse(typeof(IMyInterface<string, string>).IsInheritedOrImplements(typeof(MyClassImplementer_2_Int_Int)));

            Assert.IsFalse(typeof(IBaseInterface).IsInheritedOrImplements(typeof(MyClassImplementer_2_Int_String)));
            Assert.IsFalse(typeof(IMyInterface).IsInheritedOrImplements(typeof(MyClassImplementer_2_Int_String)));
            Assert.IsFalse(typeof(IMyInterface<int>).IsInheritedOrImplements(typeof(MyClassImplementer_2_Int_String)));
            Assert.IsFalse(typeof(IMyInterface<int, string>).IsInheritedOrImplements(typeof(MyClassImplementer_2_Int_String)));
            Assert.IsFalse(typeof(IMyInterface<object>).IsInheritedOrImplements(typeof(MyClassImplementer_2_Int_String)));
            Assert.IsFalse(typeof(IMyInterface<int, object>).IsInheritedOrImplements(typeof(MyClassImplementer_2_Int_String)));
            Assert.IsFalse(typeof(IMyInterface<object, string>).IsInheritedOrImplements(typeof(MyClassImplementer_2_Int_String)));
            Assert.IsFalse(typeof(IMyInterface<object, object>).IsInheritedOrImplements(typeof(MyClassImplementer_2_Int_String)));
            Assert.IsFalse(typeof(IMyInterface<string>).IsInheritedOrImplements(typeof(MyClassImplementer_2_Int_String)));
            Assert.IsFalse(typeof(IMyInterface<object, int>).IsInheritedOrImplements(typeof(MyClassImplementer_2_Int_String)));
            Assert.IsFalse(typeof(IMyInterface<string, object>).IsInheritedOrImplements(typeof(MyClassImplementer_2_Int_String)));
            Assert.IsFalse(typeof(IMyInterface<string, string>).IsInheritedOrImplements(typeof(MyClassImplementer_2_Int_String)));
        }

        [Test]
        public void IsInheritedOrImplements_CommandHandler()
        {
            Assert.IsTrue(typeof(PaisCommandHandler).IsInheritedOrImplements(typeof(IHandler<PaisSaveCommand, PaisDomain>)));
            Assert.IsTrue(typeof(PaisCommandHandler).IsInheritedOrImplements(typeof(IHandler<PaisSaveCommand, object>)));

            Assert.IsTrue(typeof(IHandler<PaisSaveCommand, PaisDomain>).IsInheritedOrImplements(typeof(IHandler<PaisSaveCommand, PaisDomain>)));
            Assert.IsTrue(typeof(IHandler<PaisSaveCommand, PaisDomain>).IsInheritedOrImplements(typeof(IHandler<PaisSaveCommand, object>)));
            Assert.IsTrue(typeof(IHandler<PaisSaveCommand, PaisDomain>).IsInheritedOrImplements(typeof(IHandler<object, PaisDomain>)));
            Assert.IsTrue(typeof(IHandler<PaisSaveCommand, PaisDomain>).IsInheritedOrImplements(typeof(IHandler<object, object>)));
        }
    }
}