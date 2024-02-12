using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace APK_QR_CODE
{
    public partial class CetakID : Form
    {
        public CetakID()
        {
            InitializeComponent();
        }

        private void CetakID_Load(object sender, EventArgs e)
        {
            label1.Text = "id: " + Frmadmin.id.ToUpper();
            label2.Text = "nama: " + Frmadmin.nama.ToUpper();
        }
    }
}
