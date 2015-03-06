using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    /// Represents a relationship between a game object and
    /// a property.  This allows shared properties between
    /// different game objects and supports querying of game
    /// object property relationships by the application.
    /// </summary>
    public class GameObjectProperties
    {
        private GameObject _gameobj;
        private Property _prop;

        /// <summary>
        /// The GameObject side of this relationship.
        /// </summary>
        public GameObject GameObject
        {
            get { return _gameobj; }
            set { _gameobj = value; }
        }

        /// <summary>
        /// The Property side of this relationship.
        /// </summary>
        public Property Property
        {
            get { return _prop; }
            set { _prop = value; }
        }
    }
}
