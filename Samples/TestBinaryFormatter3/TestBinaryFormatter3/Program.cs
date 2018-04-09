using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace TestBinaryFormatter3
{
    class Program
    {
        static void Main(string[] args)
        {
            Foo foo = new Foo() { Name = "aa" };

            foo.ActionDic.Add(Guid.Empty, () => { DoSomething(); });

            WriteFoo(foo);

            Foo bar = ReadFoo();
            //Console.WriteLine(bar.Del());
            Console.WriteLine(bar.Name);

            Console.ReadKey();
        }

        public static void DoSomething()
        {
        }

        public static void WriteFoo(Foo foo)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using (var stream = new FileStream(@"C:/test.bin4", FileMode.Create, FileAccess.Write, FileShare.None))
            {
                formatter.Serialize(stream, foo);
            }
        }

        public static Foo ReadFoo()
        {
            Foo foo = null;
            //BinaryFormatter formatter = new BinaryFormatter();
            //formatter.AssemblyFormat = FormatterAssemblyStyle.Simple;
            //formatter.FilterLevel = TypeFilterLevel.Low;

            var surrogateSelector = new MySurrogateSelector();
            BinaryFormatter formatter = new BinaryFormatter(surrogateSelector, new StreamingContext(StreamingContextStates.All));
            using (var stream = new FileStream(@"C:/test.bin3", FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                foo = formatter.Deserialize(stream) as Foo;
            }

            return foo;
        }
    }

    public class MySurrogateSelector : SurrogateSelector
    {
        PersistSurrogate a;
        public override ISerializationSurrogate GetSurrogate(Type type, StreamingContext context, out ISurrogateSelector selector)
        {
            if (type.Name == "MemberInfoSerializationHolder")
            {
                if (a == null)
                {
                    a = new PersistSurrogate(type);
                }
                selector = this;
                return a;
            }
            return base.GetSurrogate(type, context, out selector);
        }
    }

    public class PersistSurrogate : ISerializationSurrogate
    {
        Type type;
        public PersistSurrogate(Type type)
        {
            this.type = type;
        }
        public void GetObjectData(object obj, SerializationInfo info,
            StreamingContext context)
        {
        }

        static Type[] s_SICtorParamTypes;

        public object SetObjectData(object obj, SerializationInfo info,
            StreamingContext context, ISurrogateSelector selector)
        {
            if (s_SICtorParamTypes == null)
                s_SICtorParamTypes = new Type[] { typeof(SerializationInfo), typeof(StreamingContext) };

            var c = type.GetConstructor(
                BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic,
                                null,
                                CallingConventions.Any,
                                s_SICtorParamTypes,
                                null) as ConstructorInfo;
            object[] param = new object[2];
            param[0] = info;


            //var signatureValue = info.GetMemberValue("m_data") as object[];
            //if (signatureValue != null && ((string)signatureValue[3]).Equals("Void <Main>b__1()", StringComparison.Ordinal))
            //{
            //    signatureValue[0] = "<Main>b__0_0";
            //    signatureValue[2] = "TestBinaryFormatter2.Program+<>c";
            //    signatureValue[3] = "Void <Main>b__0_0()";
            //    signatureValue[4] = "System.Void <Main>b__0_0()";
            //}

            param[1] = context;
            obj = c.Invoke(param);

            //typeof(MemberInfoSerializationHolder).GetField("m_signature", BindingFlags.NonPublic | BindingFlags.Instance).SetValue(obj, "Void <Main>b_0_0");


            return obj;
        }

        internal bool CanHandle(Type type)
        {
            // 如果已经为类型注册了IPersistor接口实现，则自定义机制可以处理。
            return true;
        }
    }

    /// <summary>
    /// Extensions methos for using reflection to get / set member values
    /// </summary>
    public static class ReflectionExtensions
    {
        /// <summary>
        /// Gets the public or private member using reflection.
        /// </summary>
        /// <param name="obj">The source target.</param>
        /// <param name="memberName">Name of the field or property.</param>
        /// <returns>the value of member</returns>
        public static object GetMemberValue(this object obj, string memberName)
        {
            var memInf = GetMemberInfo(obj, memberName);

            if (memInf == null)
                throw new System.Exception("memberName");

            if (memInf is System.Reflection.PropertyInfo)
                return memInf.As<System.Reflection.PropertyInfo>().GetValue(obj, null);

            if (memInf is System.Reflection.FieldInfo)
                return memInf.As<System.Reflection.FieldInfo>().GetValue(obj);

            throw new System.Exception();
        }

        /// <summary>
        /// Gets the public or private member using reflection.
        /// </summary>
        /// <param name="obj">The target object.</param>
        /// <param name="memberName">Name of the field or property.</param>
        /// <returns>Old Value</returns>
        public static object SetMemberValue(this object obj, string memberName, object newValue)
        {
            var memInf = GetMemberInfo(obj, memberName);


            if (memInf == null)
                throw new System.Exception("memberName");

            var oldValue = obj.GetMemberValue(memberName);

            if (memInf is System.Reflection.PropertyInfo)
                memInf.As<System.Reflection.PropertyInfo>().SetValue(obj, newValue, null);
            else if (memInf is System.Reflection.FieldInfo)
                memInf.As<System.Reflection.FieldInfo>().SetValue(obj, newValue);
            else
                throw new System.Exception();

            return oldValue;
        }

        /// <summary>
        /// Gets the member info
        /// </summary>
        /// <param name="obj">source object</param>
        /// <param name="memberName">name of member</param>
        /// <returns>instanse of MemberInfo corresponsing to member</returns>
        private static System.Reflection.MemberInfo GetMemberInfo(object obj, string memberName)
        {
            var prps = new System.Collections.Generic.List<System.Reflection.PropertyInfo>();

            prps.Add(obj.GetType().GetProperty(memberName,
                                               System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance |
                                               System.Reflection.BindingFlags.FlattenHierarchy));
            prps = System.Linq.Enumerable.ToList(System.Linq.Enumerable.Where(prps, i => !ReferenceEquals(i, null)));
            if (prps.Count != 0)
                return prps[0];

            var flds = new System.Collections.Generic.List<System.Reflection.FieldInfo>();

            flds.Add(obj.GetType().GetField(memberName,
                                            System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance |
                                            System.Reflection.BindingFlags.FlattenHierarchy));

            //to add more types of properties

            flds = System.Linq.Enumerable.ToList(System.Linq.Enumerable.Where(flds, i => !ReferenceEquals(i, null)));

            if (flds.Count != 0)
                return flds[0];

            return null;
        }

        [System.Diagnostics.DebuggerHidden]
        private static T As<T>(this object obj)
        {
            return (T)obj;
        }
    }

}
