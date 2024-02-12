namespace APK_QR_CODE
{
    partial class Frmcetak
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frmcetak));
            this.Button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.Btnkembali = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // Button2
            // 
            this.Button2.BackColor = System.Drawing.Color.DarkCyan;
            this.Button2.FlatAppearance.BorderSize = 0;
            this.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Button2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Button2.ForeColor = System.Drawing.Color.White;
            this.Button2.Location = new System.Drawing.Point(400, 463);
            this.Button2.Name = "Button2";
            this.Button2.Size = new System.Drawing.Size(103, 24);
            this.Button2.TabIndex = 145;
            this.Button2.Text = "Cetak";
            this.Button2.UseVisualStyleBackColor = false;
            this.Button2.Click += new System.EventHandler(this.Button2_Click);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.Transparent;
            this.button3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button3.BackgroundImage")));
            this.button3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button3.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.button3.FlatAppearance.BorderSize = 0;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.ForeColor = System.Drawing.Color.White;
            this.button3.Location = new System.Drawing.Point(837, 10);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(43, 19);
            this.button3.TabIndex = 157;
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // Btnkembali
            // 
            this.Btnkembali.BackColor = System.Drawing.Color.Transparent;
            this.Btnkembali.BackgroundImage = global::APK_QR_CODE.Properties.Resources.icon_kembali;
            this.Btnkembali.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Btnkembali.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.Btnkembali.FlatAppearance.BorderSize = 0;
            this.Btnkembali.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btnkembali.ForeColor = System.Drawing.Color.White;
            this.Btnkembali.Location = new System.Drawing.Point(1, 504);
            this.Btnkembali.Name = "Btnkembali";
            this.Btnkembali.Size = new System.Drawing.Size(37, 20);
            this.Btnkembali.TabIndex = 158;
            this.Btnkembali.UseVisualStyleBackColor = false;
            this.Btnkembali.Click += new System.EventHandler(this.Btnkembali_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(152, 222);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(599, 235);
            this.dataGridView1.TabIndex = 144;
            // 
            // Frmcetak
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(902, 536);
            this.Controls.Add(this.Btnkembali);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.Button2);
            this.Controls.Add(this.dataGridView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Frmcetak";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Frmcetak";
            this.Load += new System.EventHandler(this.Frmcetak_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.Button Button2;
        internal System.Windows.Forms.Button button3;
        internal System.Windows.Forms.Button Btnkembali;
        private System.Windows.Forms.DataGridView dataGridView1;

    }
}