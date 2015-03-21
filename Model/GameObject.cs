using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    /// Represents a customizable game object used to represent entities or objects
    /// in the game.  This object depends upon a game object schema to give it
    /// definition, which is composed of property definitions that this object must
    /// then populate.  The aggregate of all defined and populated properties gives
    /// this object its full definition and game context.
    /// </summary>
    public class GameObject : DataIntegrationObject
    {
        private GameObjectSchema _schema;
        private Dictionary<int, GameObjectProperty> _props;

        /// <summary>
        /// Instantiates a new game object using the specified game object
        /// schema.  The game object cannot be saved until all required 
        /// properties specified in the schema have been populated.
        /// </summary>
        /// <param name="Schema">The schema object providing the framework for
        /// this game object.</param>
        public GameObject(GameObjectSchema Schema)
        {
            Initialize();
            _schema = Schema;
        }

        /// <summary>
        /// Instantiates a name game object using the specified game object
        /// schema and a name.  The game object cannot be saved until all 
        /// required properties specified in the schema have been populated.
        /// </summary>
        /// <param name="Schema">The schema object providing the framework for
        /// this game object.</param>
        /// <param name="Name">The name of the new game object.</param>
        public GameObject(GameObjectSchema Schema, string Name)
        {
            Initialize();
            _schema = Schema;
            this.Name = Name;
        }

        /// <summary>
        /// Instantiates a new game object using the specified id.  All
        /// object fields and properties are automatically loaded from
        /// the database.
        /// </summary>
        /// <param name="Id">The game object id.</param>
        public GameObject(int Id)
        {
            Initialize();
            _id = Id;
            Load();
        }

        public Dictionary<int, GameObjectProperty> Properties
        {
            get { return _props; }
        }

        /// <summary>
        /// Initializes the object to default values.
        /// </summary>
        public void Initialize()
        {
            _id = 0;
            _schema = null;
            _name = "";
            _props = new Dictionary<int, GameObjectProperty>();
        }

        /// <summary>
        /// Loads the game object values and all associated properties from
        /// the database.  The id field must be populated before calling this
        /// method.
        /// </summary>
        public void Load()
        {

        }

        public void LoadProperties(Dictionary<int, GameObjectProperty> PropertyDictionary){
            IEnumerable<GameObjectProperty> props = 
                PropertyDictionary.Values.Where(prop => prop.GameObject.Id == this.Id);

            foreach (GameObjectProperty prop in props)
            {
                _props.Add(prop.Property.Id, prop);
            }
        }
    }
}
