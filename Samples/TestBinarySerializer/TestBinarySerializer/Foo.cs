using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace TestBinarySerializer
{
    [Serializable]
    public class Foo //: INotifyPropertyChanged//: IDeserializationCallback //: ISerializable
    {
        //[OptionalField]
        //[NonSerialized]
        //public Func<string> Del;

        //public delegate void IOHandler(object obj, EventArgs args);
        //public event IOHandler OnIOEvent;

        public string Name { get; set; }

        //public int Age { get; set; }
        //public event PropertyChangedEventHandler PropertyChanged;

        //public event EventHandler ConfigurationRestore;

        public delegate void PerformAction();
        private Dictionary<Guid, PerformAction> actionDic = new Dictionary<Guid, PerformAction>();
        public Dictionary<Guid, PerformAction> ActionDic { get { return actionDic; } }

        //[OnDeserialized]
        //[OnDeserializing]
        //private void SetDelDefault(StreamingContext context)
        //{
        //    Del = null;
        //}

        //[SecurityPermissionAttribute(SecurityAction.Demand,SerializationFormatter = true)]
        //public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
        //{
        //    info.AddValue(null, Del);
        //}

        //void IDeserializationCallback.OnDeserialization(Object sender)
        //{
        //    Del = null;
        //}
    }
}
