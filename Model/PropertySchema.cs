using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    /// Provides the framwork for defining a game object property.  Properties
    /// instantiated with this class must support all required attributes that
    /// make up this property.  Both this property schema and its composite
    /// attribute schemas are defined and populated from the database.
    /// </summary>
    public class PropertySchema
    {
        private int _id;
        private string _name;
        private bool _isrequired;
        private Dictionary<string, AttributeSchema> _attrschemas;

        /// <summary>
        /// Constructor.  Initializes a property schema with the specified object id,
        /// which is used to obtain the relevant database definition.
        /// </summary>
        /// <param name="Id">The property schema object id for the data to retrieve.</param>
        public PropertySchema(int Id)
        {
            Initialize();
            _id = Id;
            Load();
        }

        /// <summary>
        /// Constructor.  Initializess a new empty property schema with the specified name.
        /// The schema must define at least one attribute before it can be saved to the
        /// database.
        /// </summary>
        /// <param name="Name">Name for the new property schema.</param>
        public PropertySchema(string Name)
        {
            Initialize();
            _name = Name;
        }

        /// <summary>
        /// The property schema id.
        /// </summary>
        public int Id
        {
            get { return _id; }
        }

        /// <summary>
        /// Initializes all object fields.
        /// </summary>
        public void Initialize()
        {
            _id = 0;
            _name = "";
            _isrequired = false;
            _attrschemas = new Dictionary<string, AttributeSchema>();
        }

        /// <summary>
        /// Loads all data for this object from the database.  The Id field must be populated 
        /// before calling this method.
        /// </summary>
        public void Load()
        {

        }

        /// <summary>
        /// The property schema name.
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
