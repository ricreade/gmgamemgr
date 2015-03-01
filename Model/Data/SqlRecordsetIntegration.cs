using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Data
{
    /// <summary>
    /// A sql-driven implementation of a recordset integration.  The data source
    /// (the results of a database query) is used to hydrate and return the 
    /// specified object.
    /// </summary>
    public class SqlRecordsetIntegration : IRecordsetIntegration
    {
        SqlDataRecordset _rst;
        private int _attributeRow = 0;
        private int _attributeSchemaRow = 0;
        private int _gameObjectRow = 0;
        private int _gameObjectSchemaRow = 0;
        private int _propertyRow = 0;
        private int _propertySchemaRow = 0;

        /// <summary>
        /// Initializes the integration with the specified data recordset
        /// that will be used to hydrate all data objects.
        /// </summary>
        /// <param name="Recordset">The collection of records that will be
        /// used to hydrate all data objects.</param>
        public SqlRecordsetIntegration(SqlDataRecordset Recordset)
        {
            Initialize();
            _rst = Recordset;
        }

        /// <summary>
        /// All database reference strings for attributes.
        /// </summary>
        private struct AttributeFields
        {
            public const string Id = "AttributeId";

        }

        /// <summary>
        /// All database reference strings for attribute schemas.
        /// </summary>
        private struct AttributeSchemaNames
        {
            public const string Table = "AttributeSchemas";
            public const string Id = "AttributeSchemaId";
            public const string Name = "Name";
            public const string IsRequired = "IsRequired";
            public const string IsCalcValue = "IsCalcValue";
            public const string IsStatMod = "IsStatMod";
            public const string Multiplicity = "Multiplicity";
        }

        /// <summary>
        /// Initializes (or reinitializes) active table row references.
        /// </summary>
        public void Initialize()
        {
            _attributeRow = 0;
            _attributeSchemaRow = 0;
            _gameObjectRow = 0;
            _gameObjectSchemaRow = 0;
            _propertyRow = 0;
            _propertySchemaRow = 0;
        }

        /// <summary>
        /// Fills an attribute object with the values stored in the stored
        /// SQL recordset.
        /// </summary>
        /// <param name="Attr">The attribute to hydrate.</param>
        /// <returns>The hydrated attribute.</returns>
        public Attribute FillAttribute(Attribute Attr)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Fills an attribute schema object with values stored in the stored
        /// SQL recordset.
        /// </summary>
        /// <param name="AttrSchema">The attribute schema to hydrate.</param>
        /// <returns>The hydrated attribute schema.</returns>
        public AttributeSchema FillAttributeSchema(AttributeSchema AttrSchema)
        {
            
            DataTable table = _rst.Dataset.Tables[AttributeSchemaNames.Table];
            AttrSchema.Id = (int)table.Rows[_attributeSchemaRow][AttributeSchemaNames.Id];
            AttrSchema.Name = (string)table.Rows[_attributeSchemaRow][AttributeSchemaNames.Name];
            AttrSchema.IsRequired = (bool)table.Rows[_attributeSchemaRow][AttributeSchemaNames.IsRequired];
            AttrSchema.IsCalcValue = (bool)table.Rows[_attributeSchemaRow][AttributeSchemaNames.IsCalcValue];
            AttrSchema.IsStatModifier = (bool)table.Rows[_attributeSchemaRow][AttributeSchemaNames.IsStatMod];
            AttrSchema.Multiplicity = (int)table.Rows[_attributeSchemaRow][AttributeSchemaNames.Multiplicity];
            _attributeSchemaRow++;

            return AttrSchema;
        }

        /// <summary>
        /// Fills a game object with values stored in the stored SQL recordset.
        /// </summary>
        /// <param name="GameObj">The game object to hydrate.</param>
        /// <returns>The hydrated game object.</returns>
        public GameObject FillGameObject(GameObject GameObj)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Fills a game object schema with values stored in the stored SQL recordset.
        /// </summary>
        /// <param name="GameObjSchema">The game object schema to hydrate.</param>
        /// <returns>The hydrated game object schema.</returns>
        public GameObjectSchema FillGameObjectSchema(GameObjectSchema GameObjSchema)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Fills a property with values stored in the stored SQL recordset.
        /// </summary>
        /// <param name="Prop">The property to hydrate.</param>
        /// <returns>The hydrated property.</returns>
        public Property FillProperty(Property Prop)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Fills a property schema with values stored in the stored SQL recordset.
        /// </summary>
        /// <param name="PropSchema">The property schema to hydrate.</param>
        /// <returns>The hydrated property schema.</returns>
        public PropertySchema FillPropertySchema(PropertySchema PropSchema)
        {
            throw new NotImplementedException();
        }
    }
}
