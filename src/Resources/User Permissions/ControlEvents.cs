using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Resources.User_Permissions
{
    public static class ControlEvents
    {
        public static void VisibilityChanged(object sender, EventArgs e) 
        {
            if (!ActiveUser.HasVisibility((Control)sender)) ((Control) sender).Visible = false;
        }


        public static void AccessibilityChanged(object sender, EventArgs e)
        {
            if (!ActiveUser.HasAccess((Control)sender)) ((Control)sender).Enabled = false;
        }
    }

    public static class ToolStripEvents
    {
        public static void VisibilityChanged(object sender, EventArgs e)
        {
            if (!ActiveUser.HasVisibility((ToolStripItem)sender)) ((ToolStripItem)sender).Visible = false;
        }


        public static void AccessibilityChanged(object sender, EventArgs e)
        {
            if (!ActiveUser.HasAccess((ToolStripItem)sender)) ((ToolStripItem)sender).Enabled = false;
        }
    }
}
