using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using NUnit.Framework;
using HotelModel.User_Permissions.HandledControls;

namespace HotelModel.User_Permissions.tests
{
    [TestFixture]
    public class Annotated_Forms_Tests
    {
        Form BaseForm;

        [SetUp]
        public void Init()
        {
            BaseForm = new HotelModel.User_Permissions.tests.ResourceForms.Attribute_tests_form();
            PermissionManager.StartPoint(BaseForm);

        }

        [Test]
        public void Check_Instance_Class()
        {
            Assert.IsTrue(BaseForm.Controls["handledButton1"] is HandledButton);
        }

        [Test]
        public void GetHandledControls()
        { 
            HashSet<Control> controls = PermissionManager.ManagedObjects;
            HashSet<Control> visible = PermissionManager.ManagedVisibleObjects;
            HashSet<Control> accessible = PermissionManager.ManagedAccessibleObjects;

            Assert.IsTrue(controls.Contains(BaseForm.Controls["handledButton1"]));
            Assert.IsFalse(controls.Contains(BaseForm.Controls["button1"]));
            Assert.IsTrue(visible.Contains(BaseForm.Controls["handledButton1"]));
            Assert.IsTrue(accessible.Contains(BaseForm.Controls["handledButton1"]));
            Assert.IsTrue(visible.Contains(BaseForm.Controls["onlyVisibleButton"]));
            Assert.IsFalse(accessible.Contains(BaseForm.Controls["onlyVisibleButton"]));
            Assert.IsTrue(accessible.Contains(BaseForm.Controls["onlyAccessButton"]));
            Assert.IsFalse(visible.Contains(BaseForm.Controls["onlyAccessButton"]));
        }
    }

}
