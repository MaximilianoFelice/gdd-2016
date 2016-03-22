using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using System.Windows.Forms;
using HotelModel.User_Permissions.UFR;

namespace HotelModel.User_Permissions.tests
{
    [TestFixture]
    public class Hooks_tests
    {
        Form BaseForm;

        Control aGenericControl;

        [TestFixtureSetUp]
        public void Init()
        {
            BaseForm = new HotelModel.User_Permissions.tests.ResourceForms.Attribute_tests_form();
            PermissionManager.StartPoint(BaseForm);

            ActiveUser.LoadUser("Test_User", new String[] {"admin"});

            ActiveUser.ActivateRole("admin");
        }

        [SetUp]
        public void Before()
        {
            aGenericControl = new Control();
        }

        [Test]
        public void HasFeaturesUP()
        {
            Assert.IsTrue(Feature.getFeaturesNames.Contains("Admin"));
        }
        [Test]
        public void controlGetsHooked()
        {
            aGenericControl.HandleAccess();
            aGenericControl.HandleVisibility();

            aGenericControl.Visible = true;

            Assert.IsFalse(aGenericControl.Visible);

        }

        [Test]
        public void controlCanHandleVisibility()
        {
            aGenericControl.HandleVisibility();

            aGenericControl.VisibleBy("Admin");

            aGenericControl.Visible = true;

            Assert.IsTrue(aGenericControl.Visible);

        }

        [TearDown]
        public void DisposingControl()
        {
            aGenericControl.UnmanagePermissions();
        }
    }
}
