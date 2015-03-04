using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Data
{
    public class MockDataRecordset : IDataRecordset
    {
        private Dictionary<int, Dictionary<string, string>> _attrlst;
        private Dictionary<int, Dictionary<string, string>> _attrschemalst;
        private Dictionary<int, Dictionary<string, string>> _proplst;
        private Dictionary<int, Dictionary<string, string>> _propschemalst;
        private Dictionary<int, Dictionary<string, string>> _gameobjlst;
        private Dictionary<int, Dictionary<string, string>> _gameobjschemalst;
        
        private string[] _attrschemafieldnames;
        private string[] _attrfieldnames;

        public MockDataRecordset()
        {
            Initialize();
            PopulateAttributeSchemas();
            PopulateAttributes();
        }

        public Dictionary<int, Dictionary<string, string>> AttributeRecords
        {
            get { return _attrlst; }
        }

        public Dictionary<int, Dictionary<string, string>> AttributeSchemaRecords
        {
            get { return _attrschemalst; }
        }

        private void Initialize()
        {
            _attrlst = new Dictionary<int, Dictionary<string, string>>();
            _attrschemalst = new Dictionary<int, Dictionary<string, string>>();
            _proplst = new Dictionary<int, Dictionary<string, string>>();
            _propschemalst = new Dictionary<int, Dictionary<string, string>>();
            _gameobjlst = new Dictionary<int, Dictionary<string, string>>();
            _gameobjschemalst = new Dictionary<int, Dictionary<string, string>>();
            _attrschemafieldnames = new string[] { "AttributeSchemaId", "Name", "IsRequired", "IsCalcValue", "IsStatMod", "Multiplicity" };
            _attrfieldnames = new string[] { "AttributeId", "AttributeSchemaId", "Value" };
        }

        private void PopulateAttributeSchemas()
        {
            Dictionary<string, string> _attrschema;
            string[][] _attrschemas = new string[3][];
            _attrschemas[0] = new string[] { "1", "ability", "true", "false", "false", "1" };
            _attrschemas[1] = new string[] { "2", "bonus", "true", "false", "false", "1" };
            _attrschemas[2] = new string[] { "3", "description", "false", "false", "false", "1" };

            for (int i = 0; i < _attrschemas.Length; i++)
            {
                _attrschema = new Dictionary<string, string>();
                for (int j = 0; j < _attrschemas[i].Length; j++)
                {
                    _attrschema.Add(_attrschemafieldnames[j], _attrschemas[i][j]);
                }
                _attrschemalst.Add(Int32.Parse(_attrschema["AttributeSchemaId"]),_attrschema);
            }
        }

        private void PopulateAttributes()
        {
            Dictionary<string, string> _attr;
            string[][] _attrs = new string[3][];
            _attrs[0] = new string[] { "1", "1", "strength" };
            _attrs[1] = new string[] { "2", "2", "4" };
            _attrs[2] = new string[] { "3", "3", "+4 Strength bonus" };

            for (int i = 0; i < _attrs.Length; i++)
            {
                _attr = new Dictionary<string, string>();
                for (int j = 0; j < _attrs[i].Length; j++)
                {
                    _attr.Add(_attrfieldnames[j], _attrs[i][j]);
                }
                _attrlst.Add(Int32.Parse(_attr["AttributeId"]), _attr);
            }
        }
    }
}
