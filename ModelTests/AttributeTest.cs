using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Model;
using Model.Data;

namespace ModelTests
{
    [TestClass]
    public class AttributeTest
    {

        [TestMethod]
        public void TestAttributeConstruction()
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
    }
}
