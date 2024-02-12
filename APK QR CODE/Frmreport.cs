using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using CrystalDecisions.CrystalReports.Engine;

namespace APK_QR_CODE
{
    public partial class Frmreport : Form
    {
        MySqlConnection con = new MySqlConnection(@"server=localhost;database=db_skripsi;userid=root;password=;");
        MySqlCommand cmd;
        MySqlDataAdapter da;
        string date1;
        string date2;

        public Frmreport()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            date1 = dateTimePicker1.Value.Day + "-" + dateTimePicker1.Value.Month + "-" + dateTimePicker1.Value.Year;
            date2 = dateTimePicker2.Value.Day + "-" + dateTimePicker2.Value.Month + "-" + dateTimePicker2.Value.Year;

            con.Open();
            DataTable dt = new DataTable();
            cmd = new MySqlCommand("SELECT *FROM db_skripsi.absen_tb where Tanggal between '" + date1 + "' and '" + date2 + "'", con);
            da = new MySqlDataAdapter(cmd);
            da.Fill(dt);

            report_absen rpt = new report_absen();
            rpt.SetDataSource(dt);
            crystalReportViewer1.ReportSource = rpt;
            crystalReportViewer1.RefreshReport();
            con.Close();
        }
    }
}
