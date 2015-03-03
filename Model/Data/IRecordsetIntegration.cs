using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Model;

namespace Model.Data
{
    /// <summary>
    /// Interface for a recordset integration implementation.  This
    /// supports hydration of game objects, properties, and attributes
    /// while supporting agnosticism of the data source.
    /// </summary>
    interface IRecordsetIntegration
    {

        /// <summary>
        /// Constructs an attribute dictionary based on the record data stored
        /// in the integration data source.
        /// </summary>
        /// <returns>A dictionary of attribute objects.</returns>
        Dictionary<int, Attribute> BuildAttributeDictionary();

        /// <summary>
        /// Constructs an attribute schema dictionary based on the record data
        /// stored in the integration data source.
        /// </summary>
        /// <returns>A dictionary of attribute schema objects.</returns>
        Dictionary<int, AttributeSchema> BuildAttributeSchemaDictionary();

        /// <summary>
        /// Constructs a game object dictionary based on the record data stored
        /// in the integration data source.
        /// </summary>
        /// <returns>A dictionary of game object objects.</returns>
        Dictionary<int, GameObject> BuildGameObjectDictionary();

        /// <summary>
        /// Constructs a game object schema dictionary based on the record
        /// data stored in the integration data source.
        /// </summary>
        /// <returns>A dictionary of game object schema objects.</returns>
        Dictionary<int, GameObjectSchema> BuildGameObjectSchemaDictionary();

        /// <summary>
        /// Constructs a property dictionary based on the record data stored
        /// in the integration data source.
        /// </summary>
        /// <returns>A dictionary of property objects.</returns>
        Dictionary<int, Property> BuildPropertyDictionary();

        /// <summary>
        /// Constructs a property schema dictionary based on the record data
        /// stored in the integration data source.
        /// </summary>
        /// <returns>A dictionary of property schema objects.</returns>
        Dictionary<int, PropertySchema> BuildPropertySchemaDictionary();

        /// <summary>
        /// Initializes (or reinitializes) the integration to default values.  This
        /// method should be called automatically by all implementation constructors.
        /// </summary>
        void Initialize();
    }
}
