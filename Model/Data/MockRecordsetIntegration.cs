using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Data
{
    public class MockRecordsetIntegration : RecordsetIntegration
    {

        public MockRecordsetIntegration(MockDataRecordset Recordset) : base(Recordset)
        {
            Initialize();
        }

        private struct AttributeNames
        {
            public const string Id = "AttributeId";
            public const string AttributeSchema = "AttributeSchemaId";
            public const string Value = "Value";
        }

        private struct AttributeSchemaNames
        {
            public const string Table = "AttributeSchemas";
            public const string Id = "AttributeSchemaId";
            public const string Name = "Name";
            public const string IsRequired = "IsRequired";
            public const string Multiplicity = "Multiplicity";
        }

        private AttributeItem FillAttribute(Dictionary<string, string> Fields)
        {
            AttributeItem attr;

            attr = new AttributeItem(_attrschlist[Int32.Parse(Fields[AttributeNames.AttributeSchema])]);
            attr.Id = Int32.Parse(Fields[AttributeNames.Id]);
            attr.Value = Fields[AttributeNames.Value];

            return attr;
        }

        private AttributeSchema FillAttributeSchema(Dictionary<string, string> Fields)
        {
            AttributeSchema attrsch;

            attrsch = new AttributeSchema();
            attrsch.Id = Int32.Parse(Fields[AttributeSchemaNames.Id]);
            attrsch.Name = Fields[AttributeSchemaNames.Name];
            attrsch.IsRequired = Boolean.Parse(Fields[AttributeSchemaNames.IsRequired]);
            attrsch.Multiplicity = Int32.Parse(Fields[AttributeSchemaNames.Multiplicity]);

            return attrsch;
        }


        public override Dictionary<int, AttributeItem> BuildAttributeDictionary()
        {
            MockDataRecordset rst = (MockDataRecordset)_rst;
            Dictionary<string, string> attr;

            if (_attrschlist.Values.Count == 0)
                BuildAttributeSchemaDictionary();

            for (int i = 0; i < rst.AttributeRecords.Values.Count; i++)
            {
                attr = rst.AttributeRecords.Values.ElementAt<Dictionary<string, string>>(i);
                AttributeItem a = FillAttribute(attr);
                _attrlist.Add(a.Id, a);
            }

            return _attrlist;
        }

        public override Dictionary<int, AttributeSchema> BuildAttributeSchemaDictionary()
        {
            MockDataRecordset rst = (MockDataRecordset)_rst;
            Dictionary<string, string> attrsch;

            for (int i = 0; i < rst.AttributeSchemaRecords.Values.Count; i++)
            {
                attrsch = rst.AttributeSchemaRecords.Values.ElementAt<Dictionary<string, string>>(i);
                AttributeSchema a = FillAttributeSchema(attrsch);
                _attrschlist.Add(a.Id, a);
            }

            return _attrschlist;
        }

        public override Dictionary<int, GameObject> BuildGameObjectDictionary()
        {
            throw new NotImplementedException();
        }

        public override Dictionary<int, GameObjectSchema> BuildGameObjectSchemaDictionary()
        {
            throw new NotImplementedException();
        }

        public override Dictionary<int, Property> BuildPropertyDictionary()
        {
            throw new NotImplementedException();
        }

        public override Dictionary<int, PropertySchema> BuildPropertySchemaDictionary()
        {
            throw new NotImplementedException();
        }

        public override void Initialize()
        {
            _attrschlist = new Dictionary<int, AttributeSchema>();
            _attrlist = new Dictionary<int, AttributeItem>();
        }

        public override Dictionary<int, GameObjectProperty> BuildGameObjectPropertiesDictionary()
        {
            throw new NotImplementedException();
        }

        public override Dictionary<int, GameObjectPropertySchema> BuildGameObjectPropertySchemasDictionary()
        {
            throw new NotImplementedException();
        }
    }
}
