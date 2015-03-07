using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using GMGameManager;
using Model.Data;

namespace ModelTests
{
    [TestClass]
    public class DataConnTest
    {
        [TestMethod]
        public void DataConnectionTest()
        {
            String conn = GMGameManager.Properties.Settings.Default.ConnString;

            try
            {
                SqlDataIntegration integration = new SqlDataIntegration(conn);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }

            try
            {
                SqlDataIntegration integration = new SqlDataIntegration();
                integration.SetConnectionString(conn);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
            
        }
    }
}
