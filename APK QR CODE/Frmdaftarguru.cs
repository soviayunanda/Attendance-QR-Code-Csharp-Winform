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
    public partial class Frmdaftarguru : Form
    {
        public Frmdaftarguru()
        {
            InitializeComponent();
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            this.Close();
            Frmawal formawal = new Frmawal();
            formawal.ShowDialog();
        }
    }
}
