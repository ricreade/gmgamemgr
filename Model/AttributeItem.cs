using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Model.Data;

namespace Model
{
    /// <summary>
    /// An attribute that helps define a game object property.  This class must
    /// be able to support both numeric and string value types.
    /// </summary>
    public class AttributeItem
    {
        private int _id;
        private AttributeSchema _schema;
        private string _value;
        private int _propid;

        public AttributeItem(AttributeSchema Schema)
        {
            _schema = Schema;
        }

        public AttributeItem(AttributeSchema Schema, IDataIntegration Integration)
        {
            _schema = Schema;
            
        }

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public int PropertyId
        {
            get { return _propid; }
            set { _propid = value; }
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
