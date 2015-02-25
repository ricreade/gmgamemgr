using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    /// Defines a game object by declaring required fields and the list of
    /// optional and required properties that compose this object.  All game
    /// objects must be based upon a game object schema as the schema gives
    /// all game objects their definition and context.
    /// </summary>
    public class GameObjectSchema
    {
        private int _id;
        private string _name;
        private Dictionary<string, PropertySchema> _propschemas;

        /// <summary>
        /// Instantiates a new game object schema with no properties and the
        /// specified schema name.
        /// </summary>
        /// <param name="Name">The name of the new object schema.</param>
        public GameObjectSchema(string Name)
        {
            Initialize();
            _name = Name;
        }

        /// <summary>
        /// Instantiates a game object schema using the specified id.  It's local
        /// fields and property schema list are automatically loaded.
        /// </summary>
        /// <param name="Id">The game object schema object id.</param>
        public GameObjectSchema(int Id)
        {
            Initialize();
            _id = Id;
            Load();
        }

        /// <summary>
        /// Initializes all fields of this object.
        /// </summary>
        public void Initialize()
        {
            _id = 0;
            _name = "";
            _propschemas = new Dictionary<string, PropertySchema>();
        }

        /// <summary>
        /// The object id.
        /// </summary>
        public int Id
        {
            get { return _id; }
        }

        /// <summary>
        /// Loads (or refreshes) the object properties from the database.
        /// </summary>
        public void Load()
        {
            /* Retrieve data tables from the database containing this object's
             * values and all associated property schemas.  The object schema
             * properties are then populated.
             */
        }

        /// <summary>
        /// The game object schema name.
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
        /// A collection of all property schemas that define this object.
        /// </summary>
        public Dictionary<string, PropertySchema> PropertySchemas
        {
            get { return _propschemas; }
        }
    }
}
