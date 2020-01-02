namespace EstimateProcessing
{
    partial class saFrm_Sansyo906
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
            this.label0 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.chkData_0 = new System.Windows.Forms.CheckBox();
            this.chkData_1 = new System.Windows.Forms.CheckBox();
            this.cmdFunc_11 = new System.Windows.Forms.Button();
            this.cmdFunc_12 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.datKDate = new System.Windows.Forms.DateTimePicker();
            this.datMDate = new System.Windows.Forms.DateTimePicker();
            this.txtVessel = new System.Windows.Forms.TextBox();
            this.txtTName = new System.Windows.Forms.TextBox();
            this.txtMitNo = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.optCountry_1 = new System.Windows.Forms.RadioButton();
            this.optCountry_0 = new System.Windows.Forms.RadioButton();
            this.label8 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label0
            // 
            this.label0.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label0.Font = new System.Drawing.Font("MS Gothic", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label0.ForeColor = System.Drawing.Color.White;
            this.label0.Location = new System.Drawing.Point(12, 4);
            this.label0.Name = "label0";
            this.label0.Size = new System.Drawing.Size(253, 29);
            this.label0.TabIndex = 0;
            this.label0.Text = "見積/受注 情報参照";
            this.label0.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Red;
            this.label1.Font = new System.Drawing.Font("MS Gothic", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(280, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(124, 29);
            this.label1.TabIndex = 1;
            this.label1.Text = "見積/受注";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // chkData_0
            // 
            this.chkData_0.AutoSize = true;
            this.chkData_0.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.chkData_0.Location = new System.Drawing.Point(432, 6);
            this.chkData_0.Name = "chkData_0";
            this.chkData_0.Size = new System.Drawing.Size(69, 28);
            this.chkData_0.TabIndex = 2;
            this.chkData_0.Text = "見積";
            this.chkData_0.UseVisualStyleBackColor = true;
            // 
            // chkData_1
            // 
            this.chkData_1.AutoSize = true;
            this.chkData_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.chkData_1.Location = new System.Drawing.Point(510, 6);
            this.chkData_1.Name = "chkData_1";
            this.chkData_1.Size = new System.Drawing.Size(69, 28);
            this.chkData_1.TabIndex = 3;
            this.chkData_1.Text = "受注";
            this.chkData_1.UseVisualStyleBackColor = true;
            // 
            // cmdFunc_11
            // 
            this.cmdFunc_11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.cmdFunc_11.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.cmdFunc_11.Location = new System.Drawing.Point(660, 12);
            this.cmdFunc_11.Name = "cmdFunc_11";
            this.cmdFunc_11.Size = new System.Drawing.Size(75, 34);
            this.cmdFunc_11.TabIndex = 4;
            this.cmdFunc_11.Text = "戻る(F11)";
            this.cmdFunc_11.UseVisualStyleBackColor = false;
            this.cmdFunc_11.Click += new System.EventHandler(this.cmdFunc_11_Click);
            // 
            // cmdFunc_12
            // 
            this.cmdFunc_12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.cmdFunc_12.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.cmdFunc_12.Location = new System.Drawing.Point(735, 12);
            this.cmdFunc_12.Name = "cmdFunc_12";
            this.cmdFunc_12.Size = new System.Drawing.Size(81, 34);
            this.cmdFunc_12.TabIndex = 5;
            this.cmdFunc_12.Text = "確定(F12)";
            this.cmdFunc_12.UseVisualStyleBackColor = false;
            this.cmdFunc_12.Click += new System.EventHandler(this.cmdFunc_12_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.datKDate);
            this.groupBox1.Controls.Add(this.datMDate);
            this.groupBox1.Controls.Add(this.txtVessel);
            this.groupBox1.Controls.Add(this.txtTName);
            this.groupBox1.Controls.Add(this.txtMitNo);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.optCountry_1);
            this.groupBox1.Controls.Add(this.optCountry_0);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.groupBox1.Location = new System.Drawing.Point(16, 56);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(951, 88);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "曖昧検索";
            // 
            // datKDate
            // 
            this.datKDate.Location = new System.Drawing.Point(809, 51);
            this.datKDate.Name = "datKDate";
            this.datKDate.Size = new System.Drawing.Size(125, 23);
            this.datKDate.TabIndex = 12;
            // 
            // datMDate
            // 
            this.datMDate.Location = new System.Drawing.Point(653, 51);
            this.datMDate.Name = "datMDate";
            this.datMDate.Size = new System.Drawing.Size(154, 23);
            this.datMDate.TabIndex = 11;
            // 
            // txtVessel
            // 
            this.txtVessel.Location = new System.Drawing.Point(439, 51);
            this.txtVessel.Name = "txtVessel";
            this.txtVessel.Size = new System.Drawing.Size(213, 23);
            this.txtVessel.TabIndex = 9;
            this.txtVessel.TextChanged += new System.EventHandler(this.txtMitNo_TextChanged);
            // 
            // txtTName
            // 
            this.txtTName.Location = new System.Drawing.Point(234, 51);
            this.txtTName.Name = "txtTName";
            this.txtTName.Size = new System.Drawing.Size(204, 23);
            this.txtTName.TabIndex = 8;
            this.txtTName.TextChanged += new System.EventHandler(this.txtMitNo_TextChanged);
            // 
            // txtMitNo
            // 
            this.txtMitNo.Location = new System.Drawing.Point(105, 51);
            this.txtMitNo.Name = "txtMitNo";
            this.txtMitNo.Size = new System.Drawing.Size(128, 23);
            this.txtMitNo.TabIndex = 7;
            this.txtMitNo.TextChanged += new System.EventHandler(this.txtMitNo_TextChanged);
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.label7.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label7.Location = new System.Drawing.Point(809, 23);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(126, 25);
            this.label7.TabIndex = 6;
            this.label7.Text = "契約日付 >=";
            this.label7.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.label7.Click += new System.EventHandler(this.label7_Click);
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.label6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label6.Location = new System.Drawing.Point(654, 23);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(154, 25);
            this.label6.TabIndex = 5;
            this.label6.Text = "QUOTED DATE >=";
            this.label6.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label5.Location = new System.Drawing.Point(440, 23);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(213, 25);
            this.label5.TabIndex = 4;
            this.label5.Text = "Vessel\'s Name";
            this.label5.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label4.Location = new System.Drawing.Point(235, 23);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(204, 25);
            this.label4.TabIndex = 3;
            this.label4.Text = "Messrs";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label3.Location = new System.Drawing.Point(106, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(128, 25);
            this.label3.TabIndex = 2;
            this.label3.Text = "Estimate No.";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // optCountry_1
            // 
            this.optCountry_1.AutoSize = true;
            this.optCountry_1.Location = new System.Drawing.Point(19, 49);
            this.optCountry_1.Name = "optCountry_1";
            this.optCountry_1.Size = new System.Drawing.Size(54, 21);
            this.optCountry_1.TabIndex = 1;
            this.optCountry_1.Text = "国内";
            this.optCountry_1.UseVisualStyleBackColor = true;
            // 
            // optCountry_0
            // 
            this.optCountry_0.AutoSize = true;
            this.optCountry_0.Checked = true;
            this.optCountry_0.Location = new System.Drawing.Point(19, 22);
            this.optCountry_0.Name = "optCountry_0";
            this.optCountry_0.Size = new System.Drawing.Size(54, 21);
            this.optCountry_0.TabIndex = 0;
            this.optCountry_0.TabStop = true;
            this.optCountry_0.Text = "海外";
            this.optCountry_0.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.Color.Blue;
            this.label8.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(18, 586);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(949, 22);
            this.label8.TabIndex = 7;
            this.label8.Text = "ｺｰﾄﾞを入力して下さい。";
            this.label8.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.label8.Click += new System.EventHandler(this.label8_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(18, 153);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(948, 430);
            this.dataGridView1.TabIndex = 8;
            this.dataGridView1.DoubleClick += new System.EventHandler(this.dataGridView1_DoubleClick);
            // 
            // saFrm_Sansyo906
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(1007, 637);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.cmdFunc_12);
            this.Controls.Add(this.cmdFunc_11);
            this.Controls.Add(this.chkData_1);
            this.Controls.Add(this.chkData_0);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label0);
            this.Name = "saFrm_Sansyo906";
            this.Text = "見積・受注　情報  (saFrm_Sansyo906)";
            this.Load += new System.EventHandler(this.saFrm_Sansyo906_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label0;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chkData_0;
        private System.Windows.Forms.CheckBox chkData_1;
        private System.Windows.Forms.Button cmdFunc_11;
        private System.Windows.Forms.Button cmdFunc_12;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RadioButton optCountry_1;
        private System.Windows.Forms.RadioButton optCountry_0;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DateTimePicker datKDate;
        private System.Windows.Forms.DateTimePicker datMDate;
        private System.Windows.Forms.TextBox txtVessel;
        private System.Windows.Forms.TextBox txtTName;
        private System.Windows.Forms.TextBox txtMitNo;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}