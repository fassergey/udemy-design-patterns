using System;

namespace Singleton
{
    public class SingletonTester
    {
        public static bool IsSingleton(Func<object> func)
        {
            object instance1 = func.Invoke();
            object instance2 = func.Invoke();

            return object.ReferenceEquals(instance1, instance2);
        }
    }
}
