using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    /// An attribute that helps define a game object property.  This class must
    /// be able to support both numeric and string value types.
    /// </summary>
    public class Attribute
    {
        private int _id;
        private AttributeSchema _schema;
        private string _value;

        public Attribute(AttributeSchema Schema, IDataIntegration<object, IDataRecordset> Integration)
        {
            _schema = Schema;
            
        }

        public int Id
        {
            get { return _id; }
        }

        public string Value
        {
            get { return _value; }
            set { _value = value; }
        }

        public AttributeSchema Schema
        {
            get { return _schema; }
        }
    }
}
