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
    public abstract class RecordsetIntegration : IntegrationObject
    {
        protected IDataRecordset _rst;
        protected DataIntegration _integration;

        protected Dictionary<int, Model.AttributeItem> _attrlist;
        protected Dictionary<int, AttributeSchema> _attrschlist;
        protected Dictionary<int, Property> _proplist;
        protected Dictionary<int, PropertySchema> _propschlist;
        protected Dictionary<int, GameObject> _gameobjlist;
        protected Dictionary<int, GameObjectSchema> _gameobjschlist;
        protected Dictionary<int, GameObjectProperty> _gameobjproplist;
        protected Dictionary<int, GameObjectPropertySchema> _gameobjpropschlist;

        public RecordsetIntegration(IDataRecordset Recordset)
        {
            _rst = Recordset;
        }

        public RecordsetIntegration(DataIntegration Integration)
        {
            _integration = Integration;
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
        /// Constructs a game object properties dictionary based on the record
        /// data stored in the integration data source.
        /// </summary>
        /// <returns>A dictionary of game object property objects.</returns>
        public abstract Dictionary<int, GameObjectProperty> BuildGameObjectPropertiesDictionary();

        /// <summary>
        /// Constructs a game object property schema dictionary based on the
        /// record data stored in the integration data source.
        /// </summary>
        /// <returns>A dictionary of game object property schema objects.</returns>
        public abstract Dictionary<int, GameObjectPropertySchema> BuildGameObjectPropertySchemasDictionary();

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

        /// <summary>
        /// Conversion method for converting datastore values to the specified type.
        /// If a conversion is not possible, throws an InvalidCastException.
        /// </summary>
        /// <typeparam name="T">The type to which the value should be converted.</typeparam>
        /// <param name="Value">The value to convert.</param>
        /// <returns>The typed value.</returns>
        /// <exception cref="InvalidCastException">The expected type T does not
        /// match the actual type of Value.</exception>
        protected T GetTypedValue<T>(object Value)
        {
            if (Value.GetType() == typeof(T))
                return (T)Value;
            else
                throw new InvalidCastException(String.Format(
                    "Expected type '{0}', but found type '{1}' for value {2}.", 
                    typeof(T), Value.GetType(), Value.ToString()));
        }

        /// <summary>
        /// Retrieves all records for the specified user.  Records in the database
        /// are organized under the top-level GameObject.  All GameObjects for the
        /// user are retrieved, then all properties and attributes (and their
        /// associated schemas) that support those GameObjects.  This method is
        /// intended to support application initialization by loading relevant
        /// records into memory.
        /// </summary>
        /// <param name="User">The application user for whom all records should
        /// be obtained.</param>
        public abstract void RetrieveUserRecords(User User);
    }
}
