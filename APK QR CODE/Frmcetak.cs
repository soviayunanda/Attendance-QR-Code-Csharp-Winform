using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace APK_QR_CODE
{
    public partial class Frmcetak : Form
    {
        public MySqlConnection con = new MySqlConnection();
        MySqlCommand cmd = new MySqlCommand();
        MySqlDataAdapter da = new MySqlDataAdapter();

        public Frmcetak()
        {
            InitializeComponent();
            con.ConnectionString = @"server=localhost;database=db_skripsi;userid=root;password=;";
        }

        private void Frmcetak_Load(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                cmd.Connection = con;
                string query = "SELECT * FROM absen_tb";
                cmd.CommandText = query;
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex);
            }
       
        }

        private void Btnkembali_Click(object sender, EventArgs e)
        {
            this.Hide();
            Frmadmin formadmin = new Frmadmin();
            formadmin.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Close();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            Frmreport repot = new Frmreport();
            repot.Show();
        }

    }
}
