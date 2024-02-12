using AForge.Video.DirectShow;
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
using AForge.Video;
using ZXing;
using ZXing.Aztec;


namespace APK_QR_CODE
{
    public partial class Frmqr : Form
    {

        private MySqlConnection con = new MySqlConnection();  
        private FilterInfoCollection CaptureDevice;
        private VideoCaptureDevice FinalFrame;

        public Frmqr()
        {
            InitializeComponent();
            con.ConnectionString = @"server=localhost;database=db_skripsi;userid=root;password=;";

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CaptureDevice = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            foreach (FilterInfo Device in CaptureDevice)
                comboBox1.Items.Add(Device.Name);
            comboBox1.SelectedIndex = 0;
            FinalFrame = new VideoCaptureDevice();

            //Date and Time
            label1.Text = DateTime.Now.ToLongDateString();
            label2.Text = DateTime.Now.ToLongTimeString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FinalFrame = new VideoCaptureDevice(CaptureDevice[comboBox1.SelectedIndex].MonikerString);
            FinalFrame.NewFrame += new NewFrameEventHandler(FinalFrame_NewFrame);
            FinalFrame.Start();
        }
        private void FinalFrame_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            pictureBox1.Image = (Bitmap)eventArgs.Frame.Clone(); 
        }

        private void button2_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (FinalFrame.IsRunning == true)
                FinalFrame.Stop();
        }   

        private void timer1_Tick(object sender, EventArgs e)
        {
            BarcodeReader reader = new BarcodeReader();
            Result result = reader.Decode((Bitmap)pictureBox1.Image);
            try
            {
                string decode = result.ToString().Trim();
                idtext.Text = decode;
                if (decode != null)
                {
                    con.Open();
                    MySqlCommand coman = new MySqlCommand();
                    coman.Connection = con;
                    coman.CommandText = "SELECT * FROM guru_tb WHERE ID LIKE '%"+idtext.Text+"%' ";
                    MySqlDataReader dr = coman.ExecuteReader();
                    dr.Read();
                    if (dr.HasRows)
                    {
                        namatext.Text = dr["Nama"].ToString();
                        
                    }
                    con.Close();
                    timer2.Start();
                }
            }
            catch (Exception )
            {

            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                MySqlCommand coman = new MySqlCommand();
                coman.Connection = con;
                coman.CommandText = "select * from absen_tb where ID Like'%" + idtext.Text + "%' and Status=1";
                int record = Convert.ToInt32(coman.ExecuteScalar());
                if (record <= 0)
                {
                    coman.CommandText = "INSERT INTO absen_tb (ID,Nama,Tanggal,Masuk,Keluar,Status) Values ('" + idtext.Text + "','" + namatext.Text + "','" + label1.Text + "','" + label2.Text + "',null,'1')";
                    coman.ExecuteNonQuery();
                    MessageBox.Show("Absen In-Time Successfull !");
                    this.Hide();
                    this.Close();
                    Frmawal formawal = new Frmawal();
                    formawal.ShowDialog();
                }
                else
                {
                    coman.CommandText = "UPDATE absen_tb SET Keluar='" + label2.Text + "',Status=0 WHERE ID like'%"+idtext.Text+"%' and Status=1";
                    coman.ExecuteNonQuery();
                    MessageBox.Show("Absen Out-Time Successfull !");
                }
            }
            catch (Exception)
            {

            }
        }

        private void Btnkembali_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Close();
            Frmawal formawal = new Frmawal();
            formawal.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Close();
        }
    }
}
