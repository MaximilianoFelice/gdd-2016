using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data;


namespace HotelModel.Home
{
   public class FormHandler
    {
        public static void groupBoxCleaner(GroupBox g) { 
             foreach (var c in g.Controls)
            {
                
                if (c is TextBox)
                {
                    ((TextBox)c).Clear();
                }
               
                else if (c is ComboBox)
                {
                    ((ComboBox)c).SelectedItem=null;
                }
                
                else if (c is CheckBox)
                {
                    ((CheckBox)c).Checked = false;
                }
            }
        
        }

        public static void formCleaner(Control c) {
            foreach (var f in c.Controls)
            {
                
                if (f is TextBox)
                {
                    ((TextBox)f).Clear();
                }
              
                else if (f is ComboBox)
                {
                    ((ComboBox)f).SelectedItem = null;
                }
          
                else if (f is CheckBox)
                {
                    ((CheckBox)f).Checked = false;
                }
            }
        }

        public static void clearDatePicker(DateTimePicker datePick) {
            datePick.Value = datePick.MinDate;
        }

        public static void clearItemCheckList(CheckedListBox check)
        {
            for (int item = 0; item < check.Items.Count; item++)
            {
                check.SetItemChecked(item, false);
            }
        }

        public static void clearDataGridViewDT(DataGridView dgv, DataTable tabla)
        {
            tabla.Clear();
            dgv.DataSource = tabla;
        }
        public static void clearDataGridView(DataGridView dgv)
        {
            DataTable tabla = new DataTable();
            dgv.DataSource = tabla;
        }

        public static Boolean checkBoxListEmpty(CheckedListBox cbl)
        {
            for (int i = 0; i < cbl.Items.Count; i++)
            {
                if (cbl.GetItemChecked(i) == true) return false;
            }
            return true;

        }

        public static int selectItemIndex(CheckedListBox clb)
        {
            for (int i = 0; i < clb.Items.Count; i++)
            {
                if (clb.GetItemChecked(i)) return i;

            }
            return 0;
        }

        public static void validateEmptyTextBox(TextBox txtb, ErrorProvider errorP, Button button) {
            if (String.IsNullOrEmpty(txtb.Text)) {
                errorP.SetError(txtb, "Enter value to textbox");
                button.Enabled = false;
            } else {
                errorP.SetError(txtb, "");
                button.Enabled = true;
            }
        
        }

        public static void validateIntTextBox(TextBox txtb, ErrorProvider errorP, Button button) {
            try {
                Int32 unInt = Int32.Parse(txtb.Text);
                errorP.SetError(txtb, "");
                button.Enabled = true;
            }
            catch (FormatException) {
                errorP.SetError(txtb, "Invalid type");
                button.Enabled = false;
            }
        
        }

       public static void validateDecimalTextBox(TextBox txtb, ErrorProvider errorP, Button button) {
            try {
                Decimal unDec = Decimal.Parse(txtb.Text);
                errorP.SetError(txtb, "");
                button.Enabled = true;
            }
            catch (FormatException) {
                errorP.SetError(txtb, "Invalid type");
                button.Enabled = false;
            }
        
        }

       public static void validateEmptyComboBox(ComboBox combo, ErrorProvider errorP, Button button) {
           if (combo.SelectedItem == null)
           {
               errorP.SetError(combo, "Select an option");
               button.Enabled = false;

           }
           else
           {
               errorP.SetError(combo, "");
               button.Enabled = true;
               

           }
       }

       public static void allowOnlyChars(object sender, KeyPressEventArgs e)
       {
           if (char.IsLetter(e.KeyChar))
           {

           }
           else
           {
               e.Handled = e.KeyChar != (char)Keys.Back;
           }
       }

       public static void allowOnlyCharsAndSpace(Object sender, KeyPressEventArgs e) {
           if (char.IsLetter(e.KeyChar) || char.IsWhiteSpace(e.KeyChar))
           {

           }
           else
           {
               e.Handled = e.KeyChar != (char)Keys.Back;
           }
       }

      public static void allowOnlyNumbers(object sender, KeyPressEventArgs e)
       {
           if (char.IsNumber(e.KeyChar))
           {

           }
           else
           {
               e.Handled = e.KeyChar != (char)Keys.Back;
           }
       }

      public static void loadDocTypesToCombo(ComboBox combo, GuestHandler gh) {
            combo.DataSource = gh.getDocTypes().Tables[0];
            combo.DisplayMember = "doc_type";
            combo.ValueMember = "doc_type";
      }

      public static void loadCountriesToCombo(ComboBox combo) {
          combo.DataSource = CountryModel.country.Tables[0];
          combo.DisplayMember = "country";
          combo.ValueMember = "country";
      }


    }
}


