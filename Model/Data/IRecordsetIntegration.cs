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
        /// Fills an Attribute object using values stored in the integration
        /// data source.
        /// </summary>
        /// <param name="Object">The attribute object to hydrate.</param>
        Attribute FillAttribute(Attribute Attr);

        /// <summary>
        /// Fills an AttributeSchema object using values stored in the integration
        /// data source.
        /// </summary>
        /// <param name="Object">The attribute schema object to hydrate.</param>
        AttributeSchema FillAttributeSchema(AttributeSchema AttrSchema);

        /// <summary>
        /// Fills a GameObject object using values stored in the integration
        /// data source.
        /// </summary>
        /// <param name="Object">The game object to hydrate.</param>
        GameObject FillGameObject(GameObject GameObj);

        /// <summary>
        /// Fills a GameObjectSchema object using the values stored in the
        /// integration data source.
        /// </summary>
        /// <param name="Object">The game object schema to hydrate.</param>
        GameObjectSchema FillGameObjectSchema(GameObjectSchema GameObjSchema);

        /// <summary>
        /// Fills a Property object using the values stored in the integration
        /// data source.
        /// </summary>
        /// <param name="Object">The property to hydrate.</param>
        Property FillProperty(Property Prop);

        /// <summary>
        /// Fills a PropertySchema object using the values stored in the integration
        /// data source.
        /// </summary>
        /// <param name="Object">The property schema to hydrate.</param>
        PropertySchema FillPropertySchema(PropertySchema PropSchema);

        /// <summary>
        /// Initializes (or reinitializes) the integration to default values.  This
        /// method should be called automatically by all implementation constructors.
        /// </summary>
        void Initialize();
    }
}
