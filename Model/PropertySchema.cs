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
    public class PropertySchema : DataIntegrationObject
    {
        private Dictionary<int, AttributeSchema> _attrschemas;
        private GameObjectSchema _gameobjsch;
        private bool _issummaryprop;

        public PropertySchema()
        {
            Initialize();
        }

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

        public Dictionary<int, AttributeSchema> AttributeSchemas
        {
            get {
                if (_attrschemas == null)
                    _attrschemas = new Dictionary<int, AttributeSchema>();
                return _attrschemas; 
            }
        }

        /// <summary>
        /// The game object that owns this property.
        /// </summary>
        public GameObjectSchema GameObjectSchema
        {
            get { return _gameobjsch; }
            set { _gameobjsch = value; }
        }

        /// <summary>
        /// Initializes all object fields.
        /// </summary>
        public void Initialize()
        {
            _id = 0;
            _name = "";
            _attrschemas = null;
        }

        /// <summary>
        /// Whether this property should be loaded when the application
        /// starts up because it contains information that needs to be
        /// available to represent the game object in a summary table.
        /// </summary>
        public bool IsSummaryProperty
        {
            get { return _issummaryprop; }
            set { _issummaryprop = value; }
        }

        /// <summary>
        /// Loads all data for this object from the database.  The Id field must be populated 
        /// before calling this method.
        /// </summary>
        public void Load()
        {

        }
    }
}
