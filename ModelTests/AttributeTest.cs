using System;
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

            Model.Attribute ability = integration.FillAttribute(null);
            Model.Attribute bonus = integration.FillAttribute(null);
            Model.Attribute description = integration.FillAttribute(null);

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
