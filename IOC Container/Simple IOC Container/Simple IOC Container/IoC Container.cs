using System;
using System.Collections.Generic;
using System.Linq;

namespace Simple_IOC_Container
{
    public class IoC_Container
    {
        private Dictionary<Type, List<ServiceObject>> _register = new Dictionary<Type, List<ServiceObject>>();

        private Dictionary<Type, dynamic> singletons = new Dictionary<Type, dynamic>();

        public void RegisterTransient<TConcrete>()
        {
            var conc = typeof(TConcrete);

            RegisterService(conc, conc, InstanceType.Transient);
        }

        public void RegisterTransient<TAbstract, TConcrete>() where TConcrete : TAbstract
        {
            var abst = typeof(TAbstract);

            var conc = typeof(TConcrete);

            RegisterService(abst, conc, InstanceType.Transient);
        }

        public void RegisterSingleton<TConcrete>()
        {
            var conc = typeof(TConcrete);

            RegisterService(conc, conc, InstanceType.Singleton);
        }

        public void RegisterSingleton<TAbstract, TConcrete>() where TConcrete : TAbstract
        {
            var abst = typeof(TAbstract);

            var conc = typeof(TConcrete);

            RegisterService(abst, conc, InstanceType.Singleton);
        }

        private void RegisterService(Type abst, Type conc, InstanceType instanceType)
        {
            var serviceObject = new ServiceObject(instanceType, conc);

            if (!_register.ContainsKey(abst))
            {
                var serviceList = new List<ServiceObject>()
                {
                    serviceObject
                };

                _register.Add(abst, serviceList);
            }
            else
            {
                _register[abst].Add(serviceObject);
            }
        }

        public T Resolve<T>()
        {
            return (T)Resolve(typeof(T));
        }

        private object Resolve(Type t)
        {
      
            if (!_register.ContainsKey(t))
                throw new ArgumentException($"Unable to resolve type {t.FullName} as it isn't registered.");

            var serviceObj = _register[t][0];

            var type = serviceObj.Type;

            // Get first constructor for type.
            var constructor = type.GetConstructors().FirstOrDefault();

            // Recursively resolve each dependency in constructor.
            var parameters = constructor?.GetParameters().Select(param => Resolve(param.ParameterType)).ToArray() ?? new object[0];

            // This will create a new object if transient or non instantiated singleton, or will return an already existing singleton.
            return HandleInstancing(type, parameters, serviceObj);
        }

        private object HandleInstancing(Type type, object[] parameters, ServiceObject serviceObj)
        {
            if (serviceObj.InstanceType == InstanceType.Transient)
            {
                return Activator.CreateInstance(type, parameters);
            }
            else
            {
                if (!singletons.ContainsKey(type))
                {
                    var instance = Activator.CreateInstance(type, parameters);

                    singletons.Add(type, instance);
                }

                return singletons[type];
            }
        }
    }
}
