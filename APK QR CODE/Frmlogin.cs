using MySql.Data.MySqlClient;
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
    public partial class Frmlogin : Form
    {
        public static string username;

        public Frmlogin()
        {
            InitializeComponent();
        }

        private void Btnkembali_Click(object sender, EventArgs e)
        {
            this.Close();
            Frmawal formawal = new Frmawal();
            formawal.ShowDialog();
        }
        
         private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
                textBox2.Focus();
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
                Btnmasuk.PerformClick();
        }

        private void Btnmasuk_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("Silahkan masukan username dan password dengan benar.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox1.Focus();
                return;
            }
            string myconnectionString = @"server=localhost;database=db_skripsi;userid=root;password=;";
            MySqlConnection con = null;
            MySqlCommand cmd;
            MySqlDataReader dr;
           
            try
            {
                con = new MySqlConnection(myconnectionString);
                con.Open();
                cmd = new MySqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "SELECT * FROM login_tb  WHERE Username='" + textBox1.Text + "'  AND Password='" + textBox2.Text + "' ";
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    MessageBox.Show("Selamat Datang Admin!");
                    this.Hide();
                    username = textBox1.Text;
                    Frmadmin formadm= new Frmadmin();
                    formadm.ShowDialog();
                }
            }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message,"Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                textBox2.UseSystemPasswordChar = false;
            }
            else
            {
                textBox2.UseSystemPasswordChar = true;
            }
            textBox2.Focus();
        }

        private void Frmlogin_Load(object sender, EventArgs e)
        {
         textBox1.Focus();
         textBox2.UseSystemPasswordChar = true;
        }

        private void rectangleShape4_Click(object sender, EventArgs e)
        {

        }

        private void rectangleShape1_Click(object sender, EventArgs e)
        {

        }
    }
}
          
          