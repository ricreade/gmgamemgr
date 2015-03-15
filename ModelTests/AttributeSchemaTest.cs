using System;
using System.Collections.Generic;
using System.Data;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using GMGameManager;
using Model;
using Model.Data;

namespace ModelTests
{
    [TestClass]
    public class AttributeSchemaTest
    {
        [TestMethod]
        public void TestAttributeSchemaConstructorMock()
        {
            MockRecordsetIntegration integration = new MockRecordsetIntegration(new MockDataRecordset());

            Dictionary<int, AttributeSchema> attrschdict = integration.BuildAttributeSchemaDictionary();

            AttributeSchema ability = attrschdict[1];
            AttributeSchema bonus = attrschdict[2];
            AttributeSchema description = attrschdict[3];

            Assert.AreEqual<int>(1, ability.Id);
            Assert.AreEqual<string>("ability", ability.Name);
            Assert.AreEqual<bool>(true, ability.IsRequired);
            Assert.AreEqual<int>(1, ability.Multiplicity);
            
            Assert.AreEqual<int>(2, bonus.Id);
            Assert.AreEqual<string>("bonus", bonus.Name);
            Assert.AreEqual<bool>(true, bonus.IsRequired);
            Assert.AreEqual<int>(1, bonus.Multiplicity);

            Assert.AreEqual<int>(3, description.Id);
            Assert.AreEqual<string>("description", description.Name);
            Assert.AreEqual<bool>(false, description.IsRequired);
            Assert.AreEqual<int>(1, description.Multiplicity);
        }

        [TestMethod]
        public void TestAttributeSchemaConstructorSql()
        {
            String conn = GMGameManager.Properties.Settings.Default.ConnString;
            SqlDataIntegration dataIntegration = null;
            SqlDataRecordset records = null;
            SqlRecordsetIntegration recordIntegration = null;
            Dictionary<int, AttributeSchema> schemas = null;

            try
            {
                dataIntegration = new SqlDataIntegration(conn);
            }
            catch (Exception ex)
            {
                Assert.Fail("Fail at connection: " + ex.Message);
            }

            try
            {
                records = (SqlDataRecordset)dataIntegration.SendDataRequest("GetAllRecords", null);
                if (records.Dataset.Tables.Count == 0)
                {
                    Assert.Fail("No tables retrieved");
                }
                for (int i = 0; i < records.Dataset.Tables.Count; i++)
                {
                    DataTable table = records.Dataset.Tables[i];
                    if (records.Dataset.Tables[i].Rows.Count == 0)
                    {
                        Assert.Fail(String.Format("Table {0} return no results.",
                            records.Dataset.Tables[i].TableName));
                    }
                }
            }
            catch (Exception ex)
            {
                Assert.Fail("Fail at request: " + ex.Message);
            }

            recordIntegration = new SqlRecordsetIntegration(records);
            Assert.IsNotNull(recordIntegration, "Fail - record integration is null.");

            try
            {
                schemas = recordIntegration.BuildAttributeSchemaDictionary();
                Assert.IsNotNull(schemas, "Fail - schemas result is null.");
                if (schemas.Count == 0)
                {
                    Assert.Fail("No records retrieved");
                }
            }
            catch (Exception ex)
            {
                Assert.Fail("Fail at object build: " + ex.Message);
            }

            AttributeSchema ability = schemas[1];
            AttributeSchema bonus = schemas[2];
            AttributeSchema desc = schemas[3];

            Assert.AreEqual<string>("ability", ability.Name);
            Assert.AreEqual<string>("bonus", bonus.Name);
            Assert.AreEqual<string>("description", desc.Name);
        }

        [TestMethod]
        public void TestAttributeSchemaConstructorSqlTvp()
        {
            String conn = GMGameManager.Properties.Settings.Default.ConnString;
            SqlDataIntegration dataIntegration = null;
            SqlDataRecordset records = null;
            SqlRecordsetIntegration recordIntegration = null;
            Dictionary<int, AttributeSchema> schemas = null;

            try
            {
                dataIntegration = new SqlDataIntegration(conn);
            }
            catch (Exception ex)
            {
                Assert.Fail("Fail at connection: " + ex.Message);
            }

            try
            {
                records = (SqlDataRecordset)dataIntegration.SendDataRequest("AttributeSchema_Read", GetTestIdList(), 0);
                if (records.Dataset.Tables.Count == 0)
                {
                    Assert.Fail("No tables retrieved");
                }
                for (int i = 0; i < records.Dataset.Tables.Count; i++)
                {
                    DataTable table = records.Dataset.Tables[i];
                    if (records.Dataset.Tables[i].Rows.Count == 0)
                    {
                        Assert.Fail(String.Format("Table {0} return no results.",
                            records.Dataset.Tables[i].TableName));
                    }
                }
            }
            catch (Exception ex)
            {
                Assert.Fail("Fail at request: " + ex.Message);
            }

            recordIntegration = new SqlRecordsetIntegration(records);
            Assert.IsNotNull(recordIntegration, "Fail - record integration is null.");

            try
            {
                schemas = recordIntegration.BuildAttributeSchemaDictionary();
                Assert.IsNotNull(schemas, "Fail - schemas result is null.");
                if (schemas.Count == 0)
                {
                    Assert.Fail("No records retrieved");
                }
            }
            catch (Exception ex)
            {
                Assert.Fail("Fail at object build: " + ex.Message);
            }

            AttributeSchema ability = schemas[1];
            AttributeSchema bonus = schemas[2];
            AttributeSchema desc = schemas[3];

            Assert.AreEqual<string>("ability", ability.Name);
            Assert.AreEqual<string>("bonus", bonus.Name);
            Assert.AreEqual<string>("description", desc.Name);
        }

        [TestMethod]
        public void TestAttributeSchemaUpsert()
        {
            String conn = GMGameManager.Properties.Settings.Default.ConnString;
            SqlDataIntegration dataIntegration = null;
            SqlDataRecordset records = null;
            SqlRecordsetIntegration recordIntegration = null;
            AttributeSchema Schema;
            bool result;

            try
            {
                dataIntegration = new SqlDataIntegration(conn);
            }
            catch (Exception ex)
            {
                Assert.Fail("Fail at connection: " + ex.Message);
            }

            Schema = new AttributeSchema();
            Schema.Name = "weight";
            Schema.IsRequired = true;
            Schema.Multiplicity = 1;
            Schema.PropertySchema.Id = 1;

            result = dataIntegration.SendActionRequest("AttributeSchema_Upsert", 
                SqlRecordsetIntegration.ParameterizeAttributeSchema(Schema));

            Assert.IsTrue(result);
        }

        private Model.Data.IDataParameter[] GetTestIdList()
        {
            IList<int> list = new List<int>();
            for (int i = 1; i <= 3; i++)
            {
                list.Add(i);
            }
            SqlDataParameter p = new SqlDataParameter("list", list);
            Model.Data.IDataParameter[] paramlist = new SqlDataParameter[]{p};
            
            return paramlist;
        }
    }
}
