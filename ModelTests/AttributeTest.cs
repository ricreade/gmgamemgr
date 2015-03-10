using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Model;
using Model.Data;

namespace ModelTests
{
    [TestClass]
    public class AttributeTest
    {

        [TestMethod]
        public void TestAttributeConstructionMock()
        {
            MockRecordsetIntegration integration = new MockRecordsetIntegration(new MockDataRecordset());

            Dictionary<int, AttributeItem> attrdict = integration.BuildAttributeDictionary();

            AttributeItem ability = attrdict[1];
            AttributeItem bonus = attrdict[2];
            AttributeItem description = attrdict[3];

            Assert.AreEqual<int>(1, ability.Id);
            Assert.AreEqual<int>(1, ability.Schema.Id);
            Assert.AreEqual<string>("strength", ability.Value);

            Assert.AreEqual<int>(2, bonus.Id);
            Assert.AreEqual<int>(2, bonus.Schema.Id);
            Assert.AreEqual<string>("4", bonus.Value);

            Assert.AreEqual<int>(3, description.Id);
            Assert.AreEqual<int>(3, description.Schema.Id);
            Assert.AreEqual<string>("+4 Strength bonus", description.Value);
        }

        [TestMethod]
        public void TestAttributeConstructionSql()
        {
            String conn = GMGameManager.Properties.Settings.Default.ConnString;
            SqlDataIntegration dataIntegration = null;
            SqlDataRecordset records = null;
            SqlRecordsetIntegration recordIntegration = null;
            Dictionary<int, AttributeItem> attrs = null;

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
                attrs = recordIntegration.BuildAttributeDictionary();
                Assert.IsNotNull(attrs, "Fail - schemas result is null.");
                if (attrs.Count == 0)
                {
                    Assert.Fail("No records retrieved");
                }
            }
            catch (Exception ex)
            {
                Assert.Fail("Fail at object build: " + ex.Message);
            }

            AttributeItem ability = attrs[1];
            AttributeItem bonus = attrs[2];
            AttributeItem desc = attrs[3];

            Assert.AreEqual<string>("strength", ability.Value);
            Assert.AreEqual<string>("4", bonus.Value);
            Assert.AreEqual<string>("+4 strength bonus", desc.Value);
        }
    }
}
