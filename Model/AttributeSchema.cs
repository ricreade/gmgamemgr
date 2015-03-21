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
    public class AttributeSchema : DataIntegrationObject
    {
        private bool _isrequired;
        private int _multiplicity;
        private PropertySchema _propsch;

        /// <summary>
        /// Instantiates a new empty attribute schema.
        /// </summary>
        public AttributeSchema()
        {
            Initialize();
        }

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
        /// Initializes the attribute schema internal fields to their default
        /// value.
        /// </summary>
        public void Initialize()
        {
            _id = 0;
            _name = "";
            _isrequired = false;
            _multiplicity = 1;
            _propsch = new PropertySchema();
        }

        /// <summary>
        /// Populates this object with values from the database.
        /// </summary>
        public void Load()
        {

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
        /// The number of times this attribute can exist in the property.  A value
        /// less than 1 is considered unlimited multiplicity.
        /// </summary>
        public int Multiplicity
        {
            get { return _multiplicity; }
            set { _multiplicity = value; }
        }

        /// <summary>
        /// The id of the parent property schema.  This value supports reconstruction
        /// of the property tree after data has been pull en mass from the database.
        /// </summary>
        public PropertySchema PropertySchema
        {
            get { return _propsch; }
            set { _propsch = value; }
        }
    }
}
