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
    public class SqlRecordsetIntegration : RecordsetIntegration
    {

        /// <summary>
        /// Initializes the integration with the specified data recordset
        /// that will be used to hydrate all data objects.
        /// </summary>
        /// <param name="Recordset">The collection of records that will be
        /// used to hydrate all data objects.</param>
        public SqlRecordsetIntegration(SqlDataRecordset Recordset) : base(Recordset)
        {
            Initialize();
        }

        /// <summary>
        /// All database reference strings for attributes.
        /// </summary>
        private struct AttributeFields
        {
            public const string Table = "Attributes";
            public const string Id = "AttributeId";
            public const string AttributeSchemaId = "AttributeSchemaId";
            public const string PropertyId = "PropertyId";
            public const string Value = "Value";
        }

        /// <summary>
        /// All database reference strings for attribute schemas.
        /// </summary>
        private struct AttributeSchemaNames
        {
            public const string Table = "AttributeSchemas";
            public const string Id = "AttributeSchemaId";
            public const string PropertySchemaId = "PropertySchemaId";
            public const string Name = "Name";
            public const string IsRequired = "IsRequired";
            public const string Multiplicity = "Multiplicity";
        }

        private struct GameObjectNames
        {
            public const string Table = "GameObjects";
            public const string Id = "GameObjectId";
            public const string Name = "Name";
            public const string GameObjectSchemaId = "GameObjectSchemaId";
        }

        private struct GameObjectSchemaNames
        {
            public const string Table = "GameObjectSchemas";
            public const string Id = "GameObjectSchemaId";
            public const string Name = "Name";
        }

        private struct GameObjectPropertyNames
        {
            public const string Table = "GameObjectProperties";
            public const string GameObjectId = "GameObjectId";
            public const string PropertyId = "PropertyId";
        }

        public struct GameObjectPropertySchemaNames
        {
            public const string Table = "GameObjectPropertySchemas";
            public const string GameObjectSchemaId = "GameObjectSchemaId";
            public const string PropertySchemaId = "PropertySchemaId";
        }

        private struct PropertyNames
        {
            public const string Table = "Properties";
            public const string Id = "PropertyId";
            public const string PropertySchemaId = "PropertySchemaId";
            public const string GameObjectId = "GameObjectId";
            public const string Name = "Name";
        }

        private struct PropertySchemaNames
        {
            public const string Table = "PropertySchemas";
            public const string Id = "PropertySchemaId";
            public const string GameObjectSchemaId = "GameObjectSchemaId";
            public const string Name = "Name";
            public const string IsSummaryProp = "IsSummaryProperty";
        }

        /// <summary>
        /// Fills an attribute object with the values stored in the stored
        /// SQL recordset.
        /// </summary>
        /// <param name="Attr">The attribute to hydrate.</param>
        /// <returns>The hydrated attribute.</returns>
        private AttributeItem FillAttribute(DataRow Fields)
        {
            int schemaId = (int)Fields[AttributeFields.AttributeSchemaId];

            AttributeItem attr = new AttributeItem(_attrschlist[schemaId]);
            attr.Id = (int)Fields[AttributeFields.Id];
            attr.Value = Fields[AttributeFields.Value].ToString();
            attr.PropertyId = (int)Fields[AttributeFields.PropertyId];

            return attr;
        }

        /// <summary>
        /// Fills an attribute schema object with values stored in the stored
        /// SQL recordset.
        /// </summary>
        /// <param name="AttrSchema">The attribute schema to hydrate.</param>
        /// <returns>The hydrated attribute schema.</returns>
        private AttributeSchema FillAttributeSchema(DataRow Fields)
        {
            AttributeSchema attrsch = new AttributeSchema();

            attrsch.Id = (int)Fields[AttributeSchemaNames.Id];
            attrsch.Name = Fields[AttributeSchemaNames.Name].ToString();
            attrsch.IsRequired = (bool)Fields[AttributeSchemaNames.IsRequired];
            attrsch.Multiplicity = (int)Fields[AttributeSchemaNames.Multiplicity];
            attrsch.PropertySchemaId = (int)Fields[AttributeSchemaNames.PropertySchemaId];

            return attrsch;
        }

        public GameObject FillGameObject(DataRow Fields)
        {
            int schemaId = (int)Fields[GameObjectNames.GameObjectSchemaId];

            GameObject g = new GameObject(_gameobjschlist[schemaId]);
            g.Id = (int)Fields[GameObjectNames.Id];
            g.Name = Fields[GameObjectNames.Name].ToString();

            IEnumerable<Property> props = _proplist.Values.Where(prop => prop.GameObjectId == g.Id);
            foreach (Property p in props)
            {
                g.Properties.Add(p.Id, p);
            }

            return g;
        }

        public GameObjectSchema FillGameObjectSchema(DataRow Fields)
        {
            GameObjectSchema gos = new GameObjectSchema();
            gos.Id = (int)Fields[GameObjectSchemaNames.Id];
            gos.Name = Fields[GameObjectSchemaNames.Name].ToString();

            IEnumerable<PropertySchema> propschs = _propschlist.Values.Where(prop => prop.GameObjectSchemaId == gos.Id);
            foreach (PropertySchema p in propschs)
            {
                gos.PropertySchemas.Add(p.Id, p);
            }

            return gos;
        }

        private Property FillProperty(DataRow Fields)
        {
            int schemaId = (int)Fields[PropertyNames.PropertySchemaId];

            Property prop = new Property(_propschlist[schemaId]);
            prop.Id = (int)Fields[PropertyNames.Id];
            prop.Name = Fields[PropertyNames.Name].ToString();
            prop.GameObjectId = (int)Fields[PropertyNames.GameObjectId];

            IEnumerable<AttributeItem> attrs = _attrlist.Values.Where(attr => attr.PropertyId == prop.Id);
            foreach (AttributeItem a in attrs)
            {
                prop.Attributes.Add(a.Id, a);
            }

            return prop;
        }

        private PropertySchema FillPropertySchema(DataRow Fields)
        {
            PropertySchema propsch = new PropertySchema();

            propsch.Id = (int)Fields[PropertySchemaNames.Id];
            propsch.Name = Fields[PropertySchemaNames.Name].ToString();
            propsch.GameObjectSchemaId = (int)Fields[PropertySchemaNames.GameObjectSchemaId];
            propsch.IsSummaryProperty = (bool)Fields[PropertySchemaNames.IsSummaryProp];

            IEnumerable<AttributeSchema> attrschs = _attrschlist.Values.Where(attr => attr.PropertySchemaId == propsch.Id);
            foreach (AttributeSchema a in attrschs)
            {
                propsch.AttributeSchemas.Add(a.Id, a);
            }

            return propsch;
        }

        public override Dictionary<int, AttributeItem> BuildAttributeDictionary()
        {
            if (_attrlist.Values.Count > 0) { return _attrlist; }
            if (_attrschlist.Values.Count == 0)
            {
                BuildAttributeSchemaDictionary();
            }

            AttributeItem a;
            DataTable table = ((SqlDataRecordset)_rst).Dataset.Tables[AttributeFields.Table];

            for (int i = 0; i < table.Rows.Count; i++)
            {
                a = FillAttribute(table.Rows[i]);
                _attrlist.Add(a.Id, a);
            }

            return _attrlist;
        }

        public override Dictionary<int, AttributeSchema> BuildAttributeSchemaDictionary()
        {
            if (_attrschlist.Values.Count > 0) { return _attrschlist; }

            AttributeSchema a;
            DataTable table = ((SqlDataRecordset)_rst).Dataset.Tables[AttributeSchemaNames.Table];

            for (int i = 0; i < table.Rows.Count; i++)
            {
                a = FillAttributeSchema(table.Rows[i]);
                _attrschlist.Add(a.Id, a);
            }

            return _attrschlist;
        }

        public override Dictionary<int, GameObject> BuildGameObjectDictionary()
        {
            if (_gameobjlist.Values.Count > 0) { return _gameobjlist; }
            if (_gameobjschlist.Values.Count == 0)
            {
                BuildGameObjectSchemaDictionary();
            }
            if (_proplist.Values.Count == 0)
            {
                BuildPropertyDictionary();
            }

            GameObject g;
            DataTable table = ((SqlDataRecordset)_rst).Dataset.Tables[GameObjectNames.Table];

            for (int i = 0; i < table.Rows.Count; i++)
            {
                g = FillGameObject(table.Rows[i]);
                _gameobjlist.Add(g.Id, g);
            }

            return _gameobjlist;
        }

        public override Dictionary<int, GameObjectSchema> BuildGameObjectSchemaDictionary()
        {
            if (_gameobjschlist.Values.Count > 0) { return _gameobjschlist; }
            if (_propschlist.Values.Count == 0)
            {
                BuildPropertySchemaDictionary();
            }

            GameObjectSchema g;
            DataTable table = ((SqlDataRecordset)_rst).Dataset.Tables[GameObjectSchemaNames.Table];

            for (int i = 0; i < table.Rows.Count; i++)
            {
                g = FillGameObjectSchema(table.Rows[i]);
                _gameobjschlist.Add(g.Id, g);
            }

            return _gameobjschlist;
        }

        public override Dictionary<int, GameObjectProperties> BuildGameObjectPropertiesDictionary()
        {
            throw new NotImplementedException();
        }

        public override Dictionary<int, GameObjectPropertySchemas> BuildGameObjectPropertySchemasDictionary()
        {
            throw new NotImplementedException();
        }

        public override Dictionary<int, Property> BuildPropertyDictionary()
        {
            if (_proplist.Values.Count > 0) { return _proplist; }
            if (_propschlist.Values.Count == 0)
            {
                BuildPropertySchemaDictionary();
            } 
            if (_attrlist.Values.Count == 0)
            {
                BuildAttributeDictionary();
            }

            Property p;
            DataTable table = ((SqlDataRecordset)_rst).Dataset.Tables[PropertyNames.Table];

            for (int i = 0; i < table.Rows.Count; i++)
            {
                p = FillProperty(table.Rows[i]);
                _proplist.Add(p.Id, p);
            }

            return _proplist;
        }

        public override Dictionary<int, PropertySchema> BuildPropertySchemaDictionary()
        {
            if (_propschlist.Values.Count > 0) { return _propschlist; }
            if (_attrschlist.Values.Count == 0)
            {
                BuildAttributeSchemaDictionary();
            }

            PropertySchema p;
            DataTable table = ((SqlDataRecordset)_rst).Dataset.Tables[PropertySchemaNames.Table];

            for (int i = 0; i < table.Rows.Count; i++)
            {
                p = FillPropertySchema(table.Rows[i]);
                _propschlist.Add(p.Id, p);
            }

            return _propschlist;
        }

        public override void Initialize()
        {
            _attrlist = new Dictionary<int, AttributeItem>();
            _attrschlist = new Dictionary<int, AttributeSchema>();
            _proplist = new Dictionary<int, Property>();
            _propschlist = new Dictionary<int, PropertySchema>();
        }

    }
}
