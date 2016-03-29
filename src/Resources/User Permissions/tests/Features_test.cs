using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Resources.User_Permissions.UFR;

namespace Resources.User_Permissions.tests
{
    [TestFixture]
    public class Features_test
    {
        [Test]
        public void LoadFeatures()
        {
            Feature.LoadFeatures();

            List<String> features = Feature.getFeaturesNames;

            Console.WriteLine(string.Join(";", features.ToArray()));
            Console.WriteLine(features.Count());

            Assert.True(features.Contains("Admin"));
            Assert.True(features.Contains("Other"));
            Assert.IsTrue(features.Contains("Another"));
            Assert.IsTrue(features.Contains("Then"));
            Assert.IsFalse(features.Contains("OtraCosirijilla"));

        }

    }
}
