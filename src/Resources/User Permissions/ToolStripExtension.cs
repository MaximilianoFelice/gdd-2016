using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Resources.User_Permissions.UFR;
using System.Windows.Forms;
using Resources.User_Permissions.Exceptions;

namespace Resources.User_Permissions
{
    public static class ToolStripExtension
    {
        public static void HandleVisibility(this ToolStripItem toolstrip, String[] features)
        {
            toolstrip.HandleVisibility();
            foreach (String feat in features) toolstrip.VisibleBy(feat);
        }
        public static void HandleAccess(this ToolStripItem toolstrip, String[] features)
        {
            toolstrip.HandleAccess();
            foreach (String feat in features) toolstrip.AccesedBy(feat);
        }
        public static void HandleVisibility(this ToolStripItem toolstrip)
        {
            PermissionManager.addVisibleToolStripItem(toolstrip);
        }

        public static void HandleAccess(this ToolStripItem toolstrip)
        {
            PermissionManager.addAccessibleToolStripItem(toolstrip);
        }

        public static void VisibleBy(this ToolStripItem toolstrip, String[] features) { foreach (String feat in features) toolstrip.VisibleBy(feat); }
        public static void AccesedBy(this ToolStripItem toolstrip, String[] features) { foreach (String feat in features) toolstrip.AccesedBy(feat); }

        public static void VisibleBy(this ToolStripItem toolstrip, String feature)
        {
            try
            {
                Feature.getFeaturesDictionary[feature].CanView(toolstrip);
            }
            catch
            {
                throw new FeatureNotFoundException("Feature " + feature + " was not found");
            }
        }

        public static void AccesedBy(this ToolStripItem toolstrip, String feature)
        {
            try
            {
                Feature.getFeaturesDictionary[feature].CanAcess(toolstrip);
            }
            catch
            {
                throw new FeatureNotFoundException("Feature " + feature + " was not found");
            }
        }

        public static void VisibleBy(this ToolStripItem toolstrip, Feature feat)
        {
            feat.CanView(toolstrip);
        }

        public static void AccesedBy(this ToolStripItem toolstrip, Feature feat)
        {
            feat.CanView(toolstrip);
        }

        public static void UnmanagePermissions(this ToolStripItem toolstrip)
        {
            PermissionManager.Unmanage(toolstrip);
        }
    }
}
