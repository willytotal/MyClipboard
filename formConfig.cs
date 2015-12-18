using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MyNewClipboard.Properties;

namespace MyNewClipboard
{
    public partial class formConfig : Form
    {
        public formConfig()
        {
            InitializeComponent();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            Settings.Default.Save();
        }

        private void tx_KeyPress(object sender, KeyPressEventArgs e)
        {
            if( e.KeyChar != '\b' )
            {
                int nNumber = 0;
                e.Handled = !int.TryParse(e.KeyChar.ToString(), out nNumber);
            }

        }
    }
}
