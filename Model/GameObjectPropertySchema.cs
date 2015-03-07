using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    /// Represents a relationship between game object schemas
    /// and property schemas.  This class is intended to support
    /// shared property schemas between different game object
    /// schemas.  This also supports querying of shared relationships
    /// between the two schemas.
    /// </summary>
    public class GameObjectPropertySchema
    {
        private int _id;
        private GameObjectSchema _gameobjsch;
        private PropertySchema _propsch;

        /// <summary>
        /// The object business id.
        /// </summary>
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        /// <summary>
        /// The GameObjectSchema side of this relationship.
        /// </summary>
        public GameObjectSchema GameObjectSchema
        {
            get { return _gameobjsch; }
            set { _gameobjsch = value; }
        }

        /// <summary>
        /// The PropertySchema side of this relationship.
        /// </summary>
        public PropertySchema PropertySchema
        {
            get { return _propsch; }
            set { _propsch = value; }
        }
    }
}
