using System;
using System.Linq;

#if DNXCORE50
using System.Reflection;
using System.Collections.Generic;
#endif

namespace Entitas {

    public static class TypeExtension {

        /// Determines whether the type implements the specified interface and is not an interface itself.
        public static bool ImplementsInterface<T>(this Type type) {
            return !type.IsInterface() && type.GetInterfaces().Contains(typeof(T));
        }

        public static bool IsInterface(this Type type){
#if DNXCORE50
            return type.GetTypeInfo().IsInterface;
#else
            return type.IsInterface;
#endif
        }

        public static bool IsAbstract(this Type type){
#if DNXCORE50
            return type.GetTypeInfo().IsAbstract;
#else
            return type.IsAbstract;
#endif
        }

        public static bool IsGenericType(this Type type){
#if DNXCORE50
            return type.GetTypeInfo().IsGenericType;
#else
            return type.IsGenericType;
#endif
        }

#if DNXCORE50
        public static Type[] GetGenericArguments(this Type type){
            return type.GetTypeInfo().GetGenericArguments();
        }
#endif


#if DNXCORE50
        public static IEnumerable<CustomAttributeData> GetCustomAttributes(this Type type){
            return type.GetTypeInfo().CustomAttributes;
        }
#else
        public static Attribute[] GetCustomAttributes(this Type type){
            return Attribute.GetCustomAttributes(type);
        }
#endif

        public static Type BaseType(this Type type){
#if DNXCORE50
            return type.GetTypeInfo().BaseType;
#else
            return type.BaseType;
#endif
        }
    }
}