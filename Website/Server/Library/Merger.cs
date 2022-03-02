using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Reflection.Emit;

namespace Client.Library
{
    public class TypeMergerPolicy
    {
        public TypeMergerPolicy()
        {
            IgnoredProperties = new List<Tuple<string, string>>();
            UseProperties = new List<Tuple<string, string>>();
        }

        internal IList<Tuple<string, string>> IgnoredProperties { get; }

        internal IList<Tuple<string, string>> UseProperties { get; }

        /// <summary>
        ///     Specify a property to be ignored from a object being merged.
        /// </summary>
        /// <param name="ignoreProperty">The property of the object to be ignored as a Func.</param>
        /// <returns>TypeMerger policy used in method chaining.</returns>
        public TypeMergerPolicy Ignore(Expression<Func<object>> ignoreProperty)
        {
            IgnoredProperties.Add(GetObjectTypeAndProperty(ignoreProperty));
            return this;
        }

        /// <summary>
        ///     Specify a property to use when there is a property name collision between objects being merged.
        /// </summary>
        /// <param name="useProperty"></param>
        /// <returns>TypeMerger policy used in method chaining.</returns>
        public TypeMergerPolicy Use(Expression<Func<object>> useProperty)
        {
            UseProperties.Add(GetObjectTypeAndProperty(useProperty));
            return this;
        }

        /// <summary>
        ///     /// Merge two different object instances into a single object which is a super-set of the properties of both
        ///     objects.
        ///     If property name collision occurs and no policy has been created to specify which to use using the .Use() method
        ///     the property value from 'values1' will be used.
        /// </summary>
        /// <param name="values1">An object to be merged.</param>
        /// <param name="values2">An object to be merged.</param>
        /// <returns>New object containing properties from both objects</returns>
        public object Merge(object values1, object values2)
        {
            return Merger.Merge(values1, values2, this);
        }

        /// <summary>
        ///     Inspects the property specified to get the underlying Type and property name to be used during merging.
        /// </summary>
        /// <param name="property">The property to inspect as a Func Expression.</param>
        /// <returns></returns>
        private Tuple<string, string> GetObjectTypeAndProperty(Expression<Func<object>> property)
        {
            var objType = string.Empty;
            var propName = string.Empty;

            try
            {
                if (property.Body is MemberExpression)
                {
                    objType = ((MemberExpression) property.Body).Member.ReflectedType.UnderlyingSystemType.Name;
                    propName = ((MemberExpression) property.Body).Member.Name;
                }
                else if (property.Body is UnaryExpression)
                {
                    objType = ((MemberExpression) ((UnaryExpression) property.Body).Operand).Member.ReflectedType
                        .UnderlyingSystemType.Name;
                    propName = ((MemberExpression) ((UnaryExpression) property.Body).Operand).Member.Name;
                }
                else
                {
                    throw new Exception("Expression type unknown.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error in TypeMergePolicy.GetObjectTypeAndProperty.", ex);
            }

            return new Tuple<string, string>(objType, propName);
        }
    }

    public class Merger
    {
        private static readonly ModuleBuilder modBuilder = null;
        private static TypeMergerPolicy typeMergerPolicy;

        private static readonly IDictionary<string, Type> anonymousTypes = new Dictionary<string, Type>();

        private static readonly object _syncLock = new();

        public static object Merge(object values1, object values2)
        {
            lock (_syncLock)
            {
                var name = string.Format("{0}_{1}", values1.GetType(),
                    values2.GetType());

                if (typeMergerPolicy != null)
                    name += "_" + string.Join(",",
                        typeMergerPolicy.IgnoredProperties.Select(x => string.Format("{0}_{1}", x.Item1, x.Item2)));

                var result = CreateInstance(name, values1, values2);
                if (result != null)
                {
                    typeMergerPolicy = null;
                    return result;
                }

                var pdc = GetProperties(values1, values2);

                //InitializeAssembly();

                var newType = CreateType(name, pdc);

                anonymousTypes.Add(name, newType);

                result = CreateInstance(name, values1, values2);
                typeMergerPolicy = null;
                return result;
            }
        }

        internal static object Merge(object values1, object values2, TypeMergerPolicy policy)
        {
            typeMergerPolicy = policy;
            return Merge(values1, values2);
        }

        public static TypeMergerPolicy Ignore(Expression<Func<object>> ignoreProperty)
        {
            return new TypeMergerPolicy().Ignore(ignoreProperty);
        }

        public static TypeMergerPolicy Use(Expression<Func<object>> useProperty)
        {
            return new TypeMergerPolicy().Use(useProperty);
        }

        private static object CreateInstance(string name, object values1, object values2)
        {
            object newValues = null;

            if (anonymousTypes.ContainsKey(name))
            {
                var allValues = MergeValues(values1, values2);

                var type = anonymousTypes[name];

                if (type != null)
                    newValues = Activator.CreateInstance(type, allValues);
                else
                    lock (_syncLock)
                    {
                        anonymousTypes.Remove(name);
                    }
            }

            return newValues;
        }

        private static PropertyDescriptor[] GetProperties(object values1, object values2)
        {
            var properties = new List<PropertyDescriptor>();

            var pdc1 = TypeDescriptor.GetProperties(values1);
            var pdc2 = TypeDescriptor.GetProperties(values2);

            for (var i = 0; i < pdc1.Count; i++)
                if (typeMergerPolicy == null
                    || !typeMergerPolicy.IgnoredProperties.Contains(
                        new Tuple<string, string>(values1.GetType().Name, pdc1[i].Name))
                    & !typeMergerPolicy.UseProperties.Contains(new Tuple<string, string>(values2.GetType().Name,
                        pdc1[i].Name)))
                    properties.Add(pdc1[i]);
            for (var i = 0; i < pdc2.Count; i++)
                if (typeMergerPolicy == null
                    || !typeMergerPolicy.IgnoredProperties.Contains(
                        new Tuple<string, string>(values2.GetType().Name, pdc2[i].Name))
                    & !typeMergerPolicy.UseProperties.Contains(new Tuple<string, string>(values1.GetType().Name,
                        pdc2[i].Name)))
                    properties.Add(pdc2[i]);
            return properties.ToArray();
        }

        private static Type[] GetTypes(PropertyDescriptor[] pdc)
        {
            var types = new List<Type>();

            for (var i = 0; i < pdc.Length; i++)
                types.Add(pdc[i].PropertyType);

            return types.ToArray();
        }

        private static object[] MergeValues(object values1, object values2)
        {
            var pdc1 = TypeDescriptor.GetProperties(values1);
            var pdc2 = TypeDescriptor.GetProperties(values2);

            var values = new List<object>();
            for (var i = 0; i < pdc1.Count; i++)
                if (typeMergerPolicy == null
                    || !typeMergerPolicy.IgnoredProperties.Contains(
                        new Tuple<string, string>(values1.GetType().Name, pdc1[i].Name))
                    & !typeMergerPolicy.UseProperties.Contains(new Tuple<string, string>(values2.GetType().Name,
                        pdc1[i].Name)))
                    values.Add(pdc1[i].GetValue(values1));

            for (var i = 0; i < pdc2.Count; i++)
                if (typeMergerPolicy == null
                    || !typeMergerPolicy.IgnoredProperties.Contains(
                        new Tuple<string, string>(values2.GetType().Name, pdc2[i].Name))
                    & !typeMergerPolicy.UseProperties.Contains(new Tuple<string, string>(values1.GetType().Name,
                        pdc2[i].Name)))
                    values.Add(pdc2[i].GetValue(values2));
            return values.ToArray();
        }

        //        private static void InitializeAssembly()
        //        {
        //            if (asmBuilder == null)
        //            {
        //                AssemblyName assembly = new AssemblyName();
        //                assembly.Name = "AnonymousTypeExentions";
        //
        //                AppDomain domain = Thread.GetDomain();
        //
        //                asmBuilder = domain.DefineDynamicAssembly(assembly, AssemblyBuilderAccess.Run);
        //                modBuilder = asmBuilder.DefineDynamicModule(asmBuilder.GetName().Name, false);
        //            }
        //        }

        private static Type CreateType(string name, PropertyDescriptor[] pdc)
        {
            var typeBuilder = CreateTypeBuilder(name);

            var types = GetTypes(pdc);

            var fields = BuildFields(typeBuilder, pdc);

            BuildCtor(typeBuilder, fields, types);

            BuildProperties(typeBuilder, fields);

            return typeBuilder.CreateType();
        }

        private static TypeBuilder CreateTypeBuilder(string typeName)
        {
            var typeBuilder = modBuilder.DefineType(typeName,
                TypeAttributes.Public,
                typeof(object));
            return typeBuilder;
        }

        private static void BuildCtor(TypeBuilder typeBuilder, FieldBuilder[] fields, Type[] types)
        {
            var ctor = typeBuilder.DefineConstructor(
                MethodAttributes.Public,
                CallingConventions.Standard,
                types
            );

            var ctorGen = ctor.GetILGenerator();

            for (var i = 0; i < fields.Length; i++)
            {
                ctorGen.Emit(OpCodes.Ldarg_0);
                ctorGen.Emit(OpCodes.Ldarg, i + 1);

                ctorGen.Emit(OpCodes.Stfld, fields[i]);
            }

            ctorGen.Emit(OpCodes.Ret);
        }

        private static FieldBuilder[] BuildFields(TypeBuilder typeBuilder, PropertyDescriptor[] pdc)
        {
            var fields = new List<FieldBuilder>();

            for (var i = 0; i < pdc.Length; i++)
            {
                var pd = pdc[i];

                var field = typeBuilder.DefineField(
                    string.Format("_{0}", pd.Name),
                    pd.PropertyType,
                    FieldAttributes.Private
                );

                if (fields.Contains(field) == false)
                    fields.Add(field);
            }

            return fields.ToArray();
        }

        private static void BuildProperties(TypeBuilder typeBuilder, FieldBuilder[] fields)
        {
            for (var i = 0; i < fields.Length; i++)
            {
                var propertyName = fields[i].Name.Substring(1);

                var property = typeBuilder.DefineProperty(propertyName,
                    PropertyAttributes.None, fields[i].FieldType, null);

                var getMethod = typeBuilder.DefineMethod(
                    string.Format("Get_{0}", propertyName),
                    MethodAttributes.Public,
                    fields[i].FieldType,
                    Type.EmptyTypes
                );

                var methGen = getMethod.GetILGenerator();

                methGen.Emit(OpCodes.Ldarg_0);
                methGen.Emit(OpCodes.Ldfld, fields[i]);
                methGen.Emit(OpCodes.Ret);

                property.SetGetMethod(getMethod);
            }
        }
    }
}