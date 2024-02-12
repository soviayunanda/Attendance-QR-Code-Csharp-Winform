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
    public partial class Frmadmin : Form
    {
        private MySqlConnection con = new MySqlConnection();
        MySqlCommand cmd = new MySqlCommand();
        public static string id, nama;

        public Frmadmin()
        {
            InitializeComponent();
            con.ConnectionString = @"server=localhost;database=db_skripsi;userid=root;password=;";
            slide_panel.Height = button1.Height;
            admin_panel.BringToFront();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            slide_panel.Height = button1.Height;
            slide_panel.Top = button1.Top;
            admin_panel.BringToFront();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            slide_panel.Height = button2.Height;
            slide_panel.Top = button2.Top;
            guru_panel.BringToFront();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            slide_panel.Height = button3.Height;
            slide_panel.Top = button3.Top;
            this.Hide();
            Frmcetak frmctk = new Frmcetak();
            frmctk.ShowDialog();
            frmctk = null;
            this.Show();
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

        private void Frmadmin_Load(object sender, EventArgs e)
        {
            label1.Text = Frmlogin.username;
            string query_total = "SELECT COUNT(*) FROM guru_tb";
            con.Open();
            cmd = new MySqlCommand(query_total, con);
            Int32 fuc = Convert.ToInt32(cmd.ExecuteScalar());
            cmd.Dispose();
            con.Close();
            label8.Text = "Total Guru = " + fuc.ToString();

            string query_lk = "SELECT COUNT(*) FROM guru_tb WHERE JenisKelamin='" + label13.Text + "' ";
            con.Open();
            cmd = new MySqlCommand(query_lk, con);
            Int32 fuc1 = Convert.ToInt32(cmd.ExecuteScalar());
            cmd.Dispose();
            con.Close();
            label13.Text = "Laki-Laki = " + fuc1.ToString();

            string query_pr = "SELECT COUNT(*) FROM guru_tb WHERE JenisKelamin='" + label2.Text + "' ";
            con.Open();
            cmd = new MySqlCommand(query_pr, con);
            Int32 fuc2 = Convert.ToInt32(cmd.ExecuteScalar());
            cmd.Dispose();
            con.Close();
            label2.Text = "Perempuan = " + fuc2.ToString();

            try
            {
                con.Open();
                cmd.Connection = con;
                string query = "SELECT * FROM guru_tb";
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
            timer1.Start();
        }

        private void Btnkembali_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Close();
            Frmawal formawal = new Frmawal();
            formawal.ShowDialog();
        }

        private void Add_btn_Click(object sender, EventArgs e)
        {
            QRCoder.QRCodeGenerator QG = new QRCoder.QRCodeGenerator();
            var MyData = QG.CreateQrCode(idtext.Text, QRCoder.QRCodeGenerator.ECCLevel.H);
            var code = new QRCoder.QRCode(MyData);
            pictureBox7.Image = code.GetGraphic(50);
            try
            {
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "INSERT INTO guru_tb(ID,Nama,JenisKelamin,TanggalLahir,Agama,Alamat,MataPelajaran) Values ('" + idtext.Text + "','" + namatext.Text + "','" + jenkeltext.Text + "','" + dateTimePicker1.Text + "','" + agamatext.Text + "','" + alamattext.Text + "','" + mapeltext.Text + "')";
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Data Disimpan");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            string initialDIR = @"C:\Users\pahah\Documents\Visual Studio 2010\Projects\APK QR CODE\APK QR CODE\bin\Debug\QR Code";
            var dialog = new SaveFileDialog();
            dialog.InitialDirectory = initialDIR;
            dialog.Filter = "PNG|*.png|JPEG|*jpeg|BMP|*.bmp|GIF|*.gif";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                pictureBox7.Image.Save(dialog.FileName);
            }
            idtext.Text = "";
            namatext.Text = "";
            jenkeltext.Text = "";
            dateTimePicker1.Text = "";
            agamatext.Text = "";
            alamattext.Text = "";
            mapeltext.Text = "";
            dateTimePicker1.Text = "";
            pictureBox7.Image = null;
        }

        private void Edit_btn_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "UPDATE guru_tb SET ID ='" + idtext.Text + "',Nama='" + namatext.Text + "',JenisKelamin='" + jenkeltext.Text + "',TanggalLahir='" + dateTimePicker1.Text + "',Agama='" + agamatext.Text + "',Alamat='" + alamattext.Text + "',MataPelajaran='" + mapeltext.Text + "'  WHERE ID = '" + idtext.Text + "' ";
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Data Berhasil di Update");
                idtext.Text = "";
                namatext.Text = "";
                jenkeltext.Text = "";
                dateTimePicker1.Text = "";
                agamatext.Text = "";
                alamattext.Text = "";
                mapeltext.Text = "";
                dateTimePicker1.Text = "";
                pictureBox7.Image = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex);
            }
        }

        private void Hapus_btn_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "DELETE FROM guru_tb  WHERE ID = '" + idtext.Text + "'  ";
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Data Berhasil di Hapus");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex);
            }
            idtext.Text = "";
            namatext.Text = "";
            jenkeltext.Text = "";
            dateTimePicker1.Text = "";
            agamatext.Text = "";
            alamattext.Text = "";
            mapeltext.Text = "";
            dateTimePicker1.Text = "";
            pictureBox7.Image = null;
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            label23.Text = DateTime.Now.ToLongTimeString();
            label24.Text = DateTime.Now.ToLongDateString();
            refresh();
            timer1.Start();
        }

        private void refresh()
        {
            con.Open();
            cmd.Connection = con;
            string query = "SELECT * FROM guru_tb";
            cmd.CommandText = query;
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        } 

        private void panel6_Paint(object sender, PaintEventArgs e)
        {
            timer1.Start();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                cmd.Connection = con;
                string query = "SELECT * FROM guru_tb where ID like '%" + textBox3.Text + "' or Nama like '" + textBox3.Text + "'";
                cmd.CommandText = query;
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex);
            }
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                idtext.Text = row.Cells[0].Value.ToString();
                namatext.Text = row.Cells[1].Value.ToString();
                jenkeltext.Text = row.Cells[2].Value.ToString();
                dateTimePicker1.Text = row.Cells[3].Value.ToString();
                agamatext.Text = row.Cells[4].Value.ToString();
                alamattext.Text = row.Cells[5].Value.ToString();
                mapeltext.Text = row.Cells[6].Value.ToString();
            }
        }

        private void btn_cardid_Click(object sender, EventArgs e)
        {
            if (idtext.Text  == "" || namatext.Text == "")
            {
                MessageBox.Show("Please first student.", "warming", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                id = idtext.Text;
                nama = namatext.Text;
                new CetakID().ShowDialog();
            }
        }
    }
}
