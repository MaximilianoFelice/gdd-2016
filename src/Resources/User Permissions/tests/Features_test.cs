using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using HotelModel.User_Permissions.UFR;

namespace HotelModel.User_Permissions.tests
{
    [TestFixture]
    public class Features_test
    {
        [Test]
        public void LoadFeatures()
        {
            Feature.LoadFeatures();

            List<String> features = Feature.getFeaturesNames;

            Assert.IsTrue(features.Contains("Admin"));
            Assert.IsTrue(features.Contains("Other"));
            Assert.IsTrue(features.Contains("Another"));
            Assert.IsTrue(features.Contains("Then"));
            Assert.IsFalse(features.Contains("OtraCosirijilla"));

        }

    }
}
