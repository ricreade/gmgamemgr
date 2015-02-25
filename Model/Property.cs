using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Property
    {
        private int _id;
        private string _name;
        private PropertySchema _schema;
        private Dictionary<string, Attribute> _attrs;

        /// <summary>
        /// Instantiates a new property based on the specified schema.  The property
        /// cannot be saved until all required attributes defined by the schema have
        /// been populated.
        /// </summary>
        /// <param name="Schema">The schema upon which to base this property.</param>
        public Property(PropertySchema Schema)
        {
            Initialize();
            _schema = Schema;
        }

        /// <summary>
        /// Instantiates a new property based on the specified schema and naem.  The
        /// property cannot be saved until all required attributes defined by the schema
        /// have been populated.
        /// </summary>
        /// <param name="Schema">The schema upon which to base this property.</param>
        /// <param name="Name">The name of the new property.</param>
        public Property(PropertySchema Schema, string Name)
        {
            Initialize();
            _schema = Schema;
            this.Name = Name;
        }

        /// <summary>
        /// Initializes a property object using the specified id.  The records values
        /// for this object and its associated attributes are populated from the
        /// database automatically.
        /// </summary>
        /// <param name="Id">The id of the property object to load.</param>
        public Property(int Id)
        {
            Initialize();
            _id = Id;
            Load();
        }

        /// <summary>
        /// The attributes dictionary.
        /// </summary>
        public Dictionary<string, Attribute> Attributes
        {
            get { return _attrs; }
        }

        /// <summary>
        /// The property object id.
        /// </summary>
        public int Id
        {
            get { return _id; }
        }

        /// <summary>
        /// The property name;
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
        /// The property schema.
        /// </summary>
        public PropertySchema Schema
        {
            get { return _schema; }
        }

        /// <summary>
        /// Initializes all object fields.
        /// </summary>
        public void Initialize()
        {
            _id = 0;
            _name = "";
            _schema = null;
            _attrs = new Dictionary<string, Attribute>();
        }

        /// <summary>
        /// Loads the property values and all associated attributes from the
        /// database.
        /// </summary>
        public void Load()
        {

        }
    }
}
