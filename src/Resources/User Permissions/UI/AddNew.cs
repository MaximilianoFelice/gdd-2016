using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HotelModel.User_Permissions.UI
{
    public partial class frmAddNew : Form
    {
        private Action<String> _callback;

        public frmAddNew(String title, Action<String> callback)
        {
            InitializeComponent();

            _callback = callback;

            this.Text = title;
        }

        private void frmAddNew_Load(object sender, EventArgs e)
        {
            txtName.Text = "";
        }

        private void cmdAccept_Click(object sender, EventArgs e)
        {
            _callback.Invoke(txtName.Text);

            this.Close();
        }
    }
}
