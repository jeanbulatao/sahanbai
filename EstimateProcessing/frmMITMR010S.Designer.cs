namespace EstimateProcessing
{
    partial class frmMITMR010S
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
            this.Label0 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cmdFunc_1 = new System.Windows.Forms.Button();
            this.cmdFunc_0 = new System.Windows.Forms.Button();
            this.cmdFunc_10 = new System.Windows.Forms.Button();
            this.cmdFunc_12 = new System.Windows.Forms.Button();
            this.txtIraiNo = new System.Windows.Forms.TextBox();
            this.txtTName = new System.Windows.Forms.TextBox();
            this.txtMNo = new System.Windows.Forms.TextBox();
            this.txtVessel = new System.Windows.Forms.TextBox();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.datMDate = new System.Windows.Forms.DateTimePicker();
            this.spdData = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.spdData)).BeginInit();
            this.SuspendLayout();
            // 
            // Label0
            // 
            this.Label0.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.Label0.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Label0.Location = new System.Drawing.Point(134, 65);
            this.Label0.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label0.Name = "Label0";
            this.Label0.Size = new System.Drawing.Size(166, 48);
            this.Label0.TabIndex = 1;
            this.Label0.Text = "Your Ref No.";
            this.Label0.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.Label0.Click += new System.EventHandler(this.Label0_Click);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label1.Location = new System.Drawing.Point(308, 64);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 48);
            this.label1.TabIndex = 2;
            this.label1.Text = "Our Estimate No.";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label2.Location = new System.Drawing.Point(842, 64);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(175, 47);
            this.label2.TabIndex = 3;
            this.label2.Text = "Vessell\'s Name";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label3.Location = new System.Drawing.Point(577, 65);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(257, 47);
            this.label3.TabIndex = 4;
            this.label3.Text = "Messrs";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label4.Location = new System.Drawing.Point(432, 65);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(137, 48);
            this.label4.TabIndex = 5;
            this.label4.Text = "QUOTED DATE >=";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // cmdFunc_1
            // 
            this.cmdFunc_1.Location = new System.Drawing.Point(715, 614);
            this.cmdFunc_1.Name = "cmdFunc_1";
            this.cmdFunc_1.Size = new System.Drawing.Size(74, 51);
            this.cmdFunc_1.TabIndex = 12;
            this.cmdFunc_1.Text = "  表示  (F1)";
            this.cmdFunc_1.UseVisualStyleBackColor = true;
            this.cmdFunc_1.Click += new System.EventHandler(this.cmdFunc_1_Click);
            // 
            // cmdFunc_0
            // 
            this.cmdFunc_0.Location = new System.Drawing.Point(795, 614);
            this.cmdFunc_0.Name = "cmdFunc_0";
            this.cmdFunc_0.Size = new System.Drawing.Size(87, 51);
            this.cmdFunc_0.TabIndex = 13;
            this.cmdFunc_0.Text = "ｶｰｿﾙ移動(F5)";
            this.cmdFunc_0.UseVisualStyleBackColor = true;
            this.cmdFunc_0.Click += new System.EventHandler(this.cmdFunc_0_Click);
            // 
            // cmdFunc_10
            // 
            this.cmdFunc_10.Location = new System.Drawing.Point(888, 614);
            this.cmdFunc_10.Name = "cmdFunc_10";
            this.cmdFunc_10.Size = new System.Drawing.Size(67, 51);
            this.cmdFunc_10.TabIndex = 14;
            this.cmdFunc_10.Text = " 選択 (F10)";
            this.cmdFunc_10.UseVisualStyleBackColor = true;
            this.cmdFunc_10.Click += new System.EventHandler(this.cmdFunc_10_Click);
            // 
            // cmdFunc_12
            // 
            this.cmdFunc_12.Location = new System.Drawing.Point(961, 614);
            this.cmdFunc_12.Name = "cmdFunc_12";
            this.cmdFunc_12.Size = new System.Drawing.Size(79, 51);
            this.cmdFunc_12.TabIndex = 15;
            this.cmdFunc_12.Text = "戻る (F12)";
            this.cmdFunc_12.UseVisualStyleBackColor = true;
            this.cmdFunc_12.Click += new System.EventHandler(this.cmdFunc_12_Click);
            // 
            // txtIraiNo
            // 
            this.txtIraiNo.Location = new System.Drawing.Point(134, 116);
            this.txtIraiNo.Name = "txtIraiNo";
            this.txtIraiNo.Size = new System.Drawing.Size(166, 24);
            this.txtIraiNo.TabIndex = 16;
            // 
            // txtTName
            // 
            this.txtTName.Location = new System.Drawing.Point(576, 115);
            this.txtTName.Name = "txtTName";
            this.txtTName.Size = new System.Drawing.Size(258, 24);
            this.txtTName.TabIndex = 18;
            // 
            // txtMNo
            // 
            this.txtMNo.Location = new System.Drawing.Point(308, 116);
            this.txtMNo.Name = "txtMNo";
            this.txtMNo.Size = new System.Drawing.Size(116, 24);
            this.txtMNo.TabIndex = 19;
            // 
            // txtVessel
            // 
            this.txtVessel.Location = new System.Drawing.Point(842, 115);
            this.txtVessel.Name = "txtVessel";
            this.txtVessel.Size = new System.Drawing.Size(175, 24);
            this.txtVessel.TabIndex = 20;
            // 
            // txtTitle
            // 
            this.txtTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.txtTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.txtTitle.Location = new System.Drawing.Point(12, 12);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(139, 32);
            this.txtTitle.TabIndex = 21;
            // 
            // datMDate
            // 
            this.datMDate.Location = new System.Drawing.Point(432, 116);
            this.datMDate.Name = "datMDate";
            this.datMDate.Size = new System.Drawing.Size(132, 24);
            this.datMDate.TabIndex = 22;
            // 
            // spdData
            // 
            this.spdData.BackgroundColor = System.Drawing.Color.White;
            this.spdData.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.spdData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.spdData.Location = new System.Drawing.Point(12, 158);
            this.spdData.Name = "spdData";
            this.spdData.Size = new System.Drawing.Size(1028, 440);
            this.spdData.TabIndex = 23;
            // 
            // frmMITMR010S
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1058, 676);
            this.Controls.Add(this.spdData);
            this.Controls.Add(this.datMDate);
            this.Controls.Add(this.txtTitle);
            this.Controls.Add(this.txtVessel);
            this.Controls.Add(this.txtMNo);
            this.Controls.Add(this.txtTName);
            this.Controls.Add(this.txtIraiNo);
            this.Controls.Add(this.cmdFunc_12);
            this.Controls.Add(this.cmdFunc_10);
            this.Controls.Add(this.cmdFunc_0);
            this.Controls.Add(this.cmdFunc_1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Label0);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmMITMR010S";
            this.Text = "契約№選択";
            this.Load += new System.EventHandler(this.frmMITMR010S_Load);
            ((System.ComponentModel.ISupportInitialize)(this.spdData)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public System.Windows.Forms.TextBox txtIraiNo;
        public System.Windows.Forms.TextBox txtTName;
        public System.Windows.Forms.TextBox txtMNo;
        public System.Windows.Forms.TextBox txtVessel;
        public System.Windows.Forms.DateTimePicker datMDate;
        public System.Windows.Forms.Label Label0;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.Label label2;
        public System.Windows.Forms.Label label3;
        public System.Windows.Forms.Label label4;
        public System.Windows.Forms.Button cmdFunc_1;
        public System.Windows.Forms.Button cmdFunc_0;
        public System.Windows.Forms.Button cmdFunc_10;
        public System.Windows.Forms.Button cmdFunc_12;
        public System.Windows.Forms.TextBox txtTitle;
        public System.Windows.Forms.DataGridView spdData;
    }
}