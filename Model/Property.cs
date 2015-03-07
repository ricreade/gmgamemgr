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
        private Dictionary<int, AttributeItem> _attrs;
        private int _gameobjid;

        /// <summary>
        /// Instantiates a new property with no schema.  The property cannot be saved
        /// until its schema is declared and all property attributes required by the
        /// schema have been populated.
        /// </summary>
        public Property()
        {
            Initialize();
        }

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
        public Dictionary<int, AttributeItem> Attributes
        {
            get {
                if (_attrs == null)
                    _attrs = new Dictionary<int, AttributeItem>();
                return _attrs; 
            }
        }

        public int GameObjectId
        {
            get { return _gameobjid; }
            set { _gameobjid = value; }
        }

        /// <summary>
        /// The property object id.
        /// </summary>
        public int Id
        {
            get { return _id; }
            set { _id = value; }
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
            set { _schema = value; }
        }

        /// <summary>
        /// Initializes all object fields.
        /// </summary>
        public void Initialize()
        {
            _id = 0;
            _name = "";
            _schema = null;
            _attrs = null;
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
