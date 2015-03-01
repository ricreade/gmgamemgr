using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Model.Data;

namespace Model
{
    /// <summary>
    /// Provides the framework to define an attribute, which is a component of a
    /// PropertySchema.
    /// </summary>
    public class AttributeSchema
    {
        private int _id;
        private string _name;
        private bool _isrequired;
        private bool _iscalcvalue;
        private int _multiplicity;
        private bool _isstatmod;

        /// <summary>
        /// Instantiates a new attribute schema with the specified name.
        /// </summary>
        /// <param name="Name">The name of the new attribute schema.</param>
        public AttributeSchema(string Name)
        {
            Initialize();
            this.Name = Name;
        }

        /// <summary>
        /// Instantiates an existing attribute schema with the specified
        /// object id.  The stored database values are automatically loaded
        /// to the new object.
        /// </summary>
        /// <param name="Id"></param>
        public AttributeSchema(int Id)
        {
            Initialize();
            _id = Id;
            Load();
        }

        /// <summary>
        /// Instantiates an attribute schema from the specified record
        /// collection.
        /// </summary>
        /// <param name="Records"></param>
        public AttributeSchema(IDataRecordset Records)
        {

        }

        public void Initialize()
        {
            _id = 0;
            _name = "";
            _isrequired = false;
            _iscalcvalue = false;
            _multiplicity = 1;
            _isstatmod = false;
        }

        /// <summary>
        /// Populates this object with values from the database.
        /// </summary>
        public void Load()
        {

        }

        /// <summary>
        /// The attribute schema id.
        /// </summary>
        public int Id
        {
            get { return _id; }
            set {
                Initialize();
                _id = value;
                Load();
            }
        }

        /// <summary>
        /// The attribute schema name.
        /// </summary>
        public string Name
        {
            get { return _name; }
            set
            {
                if (value != null && value.Length > 0)
                {
                    _name = value;
                }
            }
        }

        /// <summary>
        /// Whether this attribute must be populated in the derived attribute.
        /// </summary>
        public bool IsRequired
        {
            get { return _isrequired; }
            set { _isrequired = value; }
        }

        /// <summary>
        /// Whether this attribute can be used as part of a value calculation.
        /// </summary>
        public bool IsCalcValue
        {
            get { return _iscalcvalue; }
            set { _iscalcvalue = value; }
        }

        /// <summary>
        /// The number of times this attribute can exist in the property.  A value
        /// less than 1 is considered unlimited multiplicity.
        /// </summary>
        public int Multiplicity
        {
            get { return _multiplicity; }
            set { _multiplicity = value; }
        }

        /// <summary>
        /// Whether this attribute should be considered when calculating overall
        /// GameObject statistics.
        /// </summary>
        public bool IsStatModifier
        {
            get { return _isstatmod; }
            set { _isstatmod = value; }
        }
    }
}
