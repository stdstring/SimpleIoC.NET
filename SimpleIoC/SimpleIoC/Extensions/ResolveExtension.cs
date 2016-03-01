using System;
using System.Collections.Generic;
using SimpleIoC.Key;

namespace SimpleIoC.Extensions
{
    public static class ResolveExtension
    {
        public static IList<T> ResolveNameTypeServices<T>(this IServiceContainer container)
        {
            Func<Object, Boolean> predicate =
                key =>
                    {
                        NameTypeKey nameTypeKey = key as NameTypeKey;
                        return nameTypeKey != null && typeof (T).IsAssignableFrom(nameTypeKey.Type);
                    };
            return container.Resolve<T>(predicate);
        }
    }
}
