using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Data
{
    /// <summary>
    /// Abstract class to provide the structure and common logic to support
    /// specific implmentations of the integration to hydrate data objects
    /// from a record source.
    /// </summary>
    public abstract class RecordsetIntegration
    {
        protected IDataRecordset _rst;

        protected Dictionary<int, Model.AttributeItem> _attrlist;
        protected Dictionary<int, AttributeSchema> _attrschlist;
        protected Dictionary<int, Property> _proplist;
        protected Dictionary<int, PropertySchema> _propschlist;
        protected Dictionary<int, GameObject> _gameobjlist;
        protected Dictionary<int, GameObjectSchema> _gameobjschlist;

        public RecordsetIntegration(IDataRecordset Recordset)
        {
            _rst = Recordset;
        }

        /// <summary>
        /// Constructs an attribute dictionary based on the record data stored
        /// in the integration data source.
        /// </summary>
        /// <returns>A dictionary of attribute objects.</returns>
        public abstract Dictionary<int, AttributeItem> BuildAttributeDictionary();

        /// <summary>
        /// Constructs an attribute schema dictionary based on the record data
        /// stored in the integration data source.
        /// </summary>
        /// <returns>A dictionary of attribute schema objects.</returns>
        public abstract Dictionary<int, AttributeSchema> BuildAttributeSchemaDictionary();

        /// <summary>
        /// Constructs a game object dictionary based on the record data stored
        /// in the integration data source.
        /// </summary>
        /// <returns>A dictionary of game object objects.</returns>
        public abstract Dictionary<int, GameObject> BuildGameObjectDictionary();

        /// <summary>
        /// Constructs a game object schema dictionary based on the record
        /// data stored in the integration data source.
        /// </summary>
        /// <returns>A dictionary of game object schema objects.</returns>
        public abstract Dictionary<int, GameObjectSchema> BuildGameObjectSchemaDictionary();

        /// <summary>
        /// Constructs a property dictionary based on the record data stored
        /// in the integration data source.
        /// </summary>
        /// <returns>A dictionary of property objects.</returns>
        public abstract Dictionary<int, Property> BuildPropertyDictionary();

        /// <summary>
        /// Constructs a property schema dictionary based on the record data
        /// stored in the integration data source.
        /// </summary>
        /// <returns>A dictionary of property schema objects.</returns>
        public abstract Dictionary<int, PropertySchema> BuildPropertySchemaDictionary();

        /// <summary>
        /// Initializes (or reinitializes) the integration to default values.  This
        /// method should be called automatically by all implementation constructors.
        /// </summary>
        public abstract void Initialize();
    }
}
