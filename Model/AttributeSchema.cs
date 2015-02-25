using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
