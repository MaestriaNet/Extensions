using System;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Maestria.Extensions
{
    public static class ReflectionExtensions
    {
        public static Assembly GetAssemblyByName(string name)
        {
            return AppDomain.CurrentDomain.GetAssemblies()
                .SingleOrDefault(assembly => assembly.GetName().Name == name);
        }

        /// <summary>
        /// Create instance of object using constructor of data type arguments
        /// </summary>
        /// <typeparam name="T">Instance result class</typeparam>
        /// <param name="parameters">Parameters to instantiate oject</param>
        /// <returns>New instance</returns>
        public static T Create<T>(params object[] parameters)
        {
            var argsDataTypes = new Type[parameters.Length];
            for (var i = 0; i < parameters.Length; i++)
                argsDataTypes[i] = parameters[i].GetType();

            var constructorInfo = typeof(T).GetConstructor(argsDataTypes);

            if (constructorInfo != null)
                return (T) Activator.CreateInstance(typeof(T), parameters);

            var strDataTypes = "";
            for (var i = 0; i < argsDataTypes.Length; i++)
                strDataTypes += $"{i + 1} - {argsDataTypes[i].FullName}\n";
            strDataTypes = strDataTypes.Trim();

            throw new NotImplementedException(
                $"Not implemented construtor at class '{typeof(T).FullName}' with the parameters: {strDataTypes}");
        }

        public static bool HasConstructor<T>(params Type[] parametersTypes) =>
            typeof(T).GetConstructor(parametersTypes) != null;

        public static bool HasConstructor<T>(params object[] parameters)
        {
            var types = new Type[parameters.Length];
            for (var i = 0; i < parameters.Length; i++)
                types[i] = parameters[i].GetType();

            return HasConstructor<T>(types);
        }

        #region IsInheritedOrImplements

        /// <summary>
        /// Check if child inherited or implements parent. This method support types with generic data types declaration and check inheritance of generic types too.
        /// </summary>
        /// <param name="child"></param>
        /// <param name="parent"></param>
        /// <returns></returns>
        public static bool IsInheritedOrImplements(this Type child, Type parent)
        {
            // ATENÇÃO: SE FOR ALTERAR ALGO AQUI, EXECUET O PROJETO DE TESTE UNITÁRIO DO FRAMEWORK!!!
            if (child == parent)
                return true;

            if (child.IsGenericType && parent.IsGenericType && child.IsGenericTypeArgumentsInheritedsFrom(parent))
                return true;

            parent = ResolveGenericTypeDefinition(parent);

            var currentChild = child.IsGenericType
                ? child.GetGenericTypeDefinition()
                : child;

            while (currentChild != typeof(object))
            {
                if (parent == currentChild || HasAnyInterfaces(parent, currentChild))
                    return true;

                currentChild = currentChild.BaseType != null
                               && currentChild.BaseType.IsGenericType
                    ? currentChild.BaseType.GetGenericTypeDefinition()
                    : currentChild.BaseType;

                if (currentChild == null)
                    return false;
            }
            return false;
        }

        /// <summary>
        /// Check if child generics data types is inherited or implements generics from parent respecting order of args
        /// </summary>
        /// <param name="child"></param>
        /// <param name="parent"></param>
        /// <returns></returns>
        public static bool IsGenericTypeArgumentsInheritedsFrom(this Type child, Type parent)
        {
            // ATENÇÃO: SE FOR ALTERAR ALGO AQUI, EXECUET O PROJETO DE TESTE UNITÁRIO DO FRAMEWORK!!!
            if (parent.GenericTypeArguments.Length > 0 &&
                parent.GenericTypeArguments.Length == child.GenericTypeArguments.Length)
            {
                for (var i = 0; i < parent.GenericTypeArguments.Length; i++)
                {
                    if (!parent.GenericTypeArguments[i].IsAssignableFrom(child.GenericTypeArguments[i]))
                        return false;
                }

                return true;
            }
            return false;
        }

        /// <summary>
        /// Check if types implements an interface
        /// </summary>
        /// <param name="parent"></param>
        /// <param name="child"></param>
        /// <returns></returns>
        private static bool HasAnyInterfaces(Type parent, Type child)
        {
            // ATENÇÃO: SE FOR ALTERAR ALGO AQUI, EXECUET O PROJETO DE TESTE UNITÁRIO DO FRAMEWORK!!!
            return child.GetInterfaces()
                .Any(childInterface =>
                {
                    if (parent.IsAssignableFrom(childInterface))
                        return true;

                    if (childInterface.IsGenericTypeArgumentsInheritedsFrom(parent))
                        return true;

                    var currentInterface = childInterface.IsGenericType
                    ? childInterface.GetGenericTypeDefinition()
                    : childInterface;

                    return currentInterface == parent;
                });
        }

        /// <summary>
        /// typeof(List<int>)                            = System.Collections.Generic.List`1[System.Int32]
        /// typeof(List<int>).GetGenericTypeDefinition() = System.Collections.Generic.List`1[T]
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        private static Type ResolveGenericTypeDefinition(Type type)
        {
            // ATENÇÃO: SE FOR ALTERAR ALGO AQUI, EXECUET O PROJETO DE TESTE UNITÁRIO DO FRAMEWORK!!!

            // ReSharper disable once ReplaceWithSingleAssignment.True
            var shouldUseGenericType = true;
            if (type.IsGenericType && type.GetGenericTypeDefinition() != type)
                shouldUseGenericType = false;

            if (type.IsGenericType && shouldUseGenericType)
                type = type.GetGenericTypeDefinition();
            return type;
        }

        #endregion

        public static bool PropertyExist(object instance, string name)
        {
            if (instance == null)
                throw new ArgumentNullException(nameof(instance));

            var propInfo = instance.GetType().GetProperty(name, BindingFlags.Instance | BindingFlags.Public);
            return propInfo != null;
        }

        public static void SetPropertyValue(object instance, string name, object value)
        {
            if (instance == null)
                throw new ArgumentNullException(nameof(instance));

            var propInfo = instance.GetType().GetProperty(name, BindingFlags.Instance | BindingFlags.Public);
            if (propInfo == null)
                throw new ArgumentException(
                    "Propriedade {0} não existe no tipo {1}.".Format(name, instance.GetType().FullName),
                    nameof(name));

            propInfo.SetValue(instance, value);
        }

        public static object GetPropertyValue(object instance, string name)
        {
            if (instance == null)
                throw new ArgumentNullException(nameof(instance));

            var propInfo = instance.GetType().GetProperty(name, BindingFlags.Instance | BindingFlags.Public);
            if (propInfo == null)
                throw new ArgumentException(
                    "Propriedade {0} não existe no tipo {1}.".Format(name, instance.GetType().FullName),
                    nameof(name));

            return propInfo.GetValue(instance);
        }

        public static T GetPropertyValue<T>(object instance, string name) =>
            (T) GetPropertyValue(instance, name);

        public static object GetTaskResult(Task task)
        {
            if (task.GetType().IsInheritedOrImplements(typeof(Task<>)))
            {
                var propInfo = task
                    .GetType()
                    .GetProperty(nameof(Task<object>.Result));
                return propInfo?.GetValue(task);
            }
            return null;
        }

        public static object GetTaskResult(object task)
        {
            if (task.GetType().IsInheritedOrImplements(typeof(Task<>)))
            {
                var propInfo = task
                    .GetType()
                    .GetProperty(nameof(Task<object>.Result));
                return propInfo?.GetValue(task);
            }
            return null;
        }

        public static object InvokeMethod(object instance, string name, params object[] parameters)
        {
            if (instance == null)
                throw new ArgumentNullException(nameof(instance));

            var methodInfo = instance.GetType().GetMethod(name, BindingFlags.Instance | BindingFlags.Public);
            if (methodInfo == null)
                throw new ArgumentException(
                    "Método {0} não existe no tipo {1}.".Format(name, instance.GetType().FullName),
                    nameof(name));

            return methodInfo.Invoke(instance, parameters);
        }
    }
}
