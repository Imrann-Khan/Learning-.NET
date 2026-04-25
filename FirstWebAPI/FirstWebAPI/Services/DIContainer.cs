using System.Reflection;

namespace FirstWebAPI.Services
{
    public class DIContainer
    {
        public readonly Dictionary<Type, Type>? _map = new Dictionary<Type, Type>();
        public void RegisterTransient<TInterface, TImplementation>()
        {
            _map?[typeof(TInterface)] = typeof(TImplementation);
        }

        public object Resolve(Type typeToResolve)
        {
            if (!_map!.TryGetValue(typeToResolve, out Type? concreteType))
            {
                concreteType = typeToResolve;
            }

            ConstructorInfo[] constructors = concreteType.GetConstructors();
            ConstructorInfo? constructor = constructors.First();

            ParameterInfo[] parameters = constructor.GetParameters();

            if(parameters.Length == 0)
            {
                return Activator.CreateInstance(concreteType)!;
            }

            List<object> resolvedParameters = new List<object>();

            foreach(ParameterInfo parameter in parameters)
            {
                object dependency = Resolve(parameter.ParameterType);
                resolvedParameters.Add(dependency);
            }

            return Activator.CreateInstance(concreteType, resolvedParameters.ToArray())!;
        }

        public T Resolve<T>()
        {
            return (T)Resolve(typeof(T));
        }
    }
}
