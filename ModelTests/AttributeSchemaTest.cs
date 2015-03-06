using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Model;
using Model.Data;

namespace ModelTests
{
    [TestClass]
    public class AttributeSchemaTest
    {
        [TestMethod]
        public void TestAttributeSchemaConstructor()
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
    }
}
