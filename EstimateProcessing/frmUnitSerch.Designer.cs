namespace EstimateProcessing
{
    partial class frmUnitSerch
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
            this.label1 = new System.Windows.Forms.Label();
            this.cmdFunc_10 = new System.Windows.Forms.Button();
            this.cmdFunc_11 = new System.Windows.Forms.Button();
            this.cmdFunc_12 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtSerch0 = new System.Windows.Forms.TextBox();
            this.lblGuide = new System.Windows.Forms.Label();
            this.spdList = new System.Windows.Forms.DataGridView();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spdList)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label1.Font = new System.Drawing.Font("MS PMincho", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(139, 33);
            this.label1.TabIndex = 0;
            this.label1.Text = "UNIT検索";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cmdFunc_10
            // 
            this.cmdFunc_10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.cmdFunc_10.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.cmdFunc_10.Location = new System.Drawing.Point(201, 0);
            this.cmdFunc_10.Name = "cmdFunc_10";
            this.cmdFunc_10.Size = new System.Drawing.Size(75, 35);
            this.cmdFunc_10.TabIndex = 1;
            this.cmdFunc_10.Text = "F10:ｸﾘｱ";
            this.cmdFunc_10.UseVisualStyleBackColor = false;
            // 
            // cmdFunc_11
            // 
            this.cmdFunc_11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.cmdFunc_11.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.cmdFunc_11.Location = new System.Drawing.Point(274, 0);
            this.cmdFunc_11.Name = "cmdFunc_11";
            this.cmdFunc_11.Size = new System.Drawing.Size(75, 35);
            this.cmdFunc_11.TabIndex = 2;
            this.cmdFunc_11.Text = "F11:取消";
            this.cmdFunc_11.UseVisualStyleBackColor = false;
            // 
            // cmdFunc_12
            // 
            this.cmdFunc_12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.cmdFunc_12.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.cmdFunc_12.Location = new System.Drawing.Point(347, 0);
            this.cmdFunc_12.Name = "cmdFunc_12";
            this.cmdFunc_12.Size = new System.Drawing.Size(75, 35);
            this.cmdFunc_12.TabIndex = 3;
            this.cmdFunc_12.Text = "F12:確定";
            this.cmdFunc_12.UseVisualStyleBackColor = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtSerch0);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.groupBox1.Location = new System.Drawing.Point(12, 41);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(409, 65);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "UNIT曖昧検索";
            // 
            // txtSerch0
            // 
            this.txtSerch0.Location = new System.Drawing.Point(10, 26);
            this.txtSerch0.Name = "txtSerch0";
            this.txtSerch0.Size = new System.Drawing.Size(386, 23);
            this.txtSerch0.TabIndex = 7;
            // 
            // lblGuide
            // 
            this.lblGuide.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblGuide.ForeColor = System.Drawing.Color.White;
            this.lblGuide.Location = new System.Drawing.Point(14, 558);
            this.lblGuide.Name = "lblGuide";
            this.lblGuide.Size = new System.Drawing.Size(407, 24);
            this.lblGuide.TabIndex = 6;
            this.lblGuide.Text = "ｺｰﾄﾞを入力して下さい。";
            this.lblGuide.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // spdList
            // 
            this.spdList.BackgroundColor = System.Drawing.Color.White;
            this.spdList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.spdList.Location = new System.Drawing.Point(12, 112);
            this.spdList.Name = "spdList";
            this.spdList.Size = new System.Drawing.Size(410, 443);
            this.spdList.TabIndex = 7;
            // 
            // frmUnitSerch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(433, 600);
            this.Controls.Add(this.spdList);
            this.Controls.Add(this.lblGuide);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.cmdFunc_12);
            this.Controls.Add(this.cmdFunc_11);
            this.Controls.Add(this.cmdFunc_10);
            this.Controls.Add(this.label1);
            this.Name = "frmUnitSerch";
            this.Text = "frmUnitSerch";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spdList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        public System.Windows.Forms.TextBox txtSerch0;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.Button cmdFunc_10;
        public System.Windows.Forms.Button cmdFunc_11;
        public System.Windows.Forms.Button cmdFunc_12;
        public System.Windows.Forms.GroupBox groupBox1;
        public System.Windows.Forms.Label lblGuide;
        public System.Windows.Forms.DataGridView spdList;
    }
}