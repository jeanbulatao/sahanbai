namespace EstimateProcessing
{
    partial class txtSerch_0
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
            this.label2 = new System.Windows.Forms.Label();
            this.cmdFunc_10 = new System.Windows.Forms.Button();
            this.cmdFunc_11 = new System.Windows.Forms.Button();
            this.cmdFunc_12 = new System.Windows.Forms.Button();
            this.frame1 = new System.Windows.Forms.GroupBox();
            this.txtSerch0 = new System.Windows.Forms.TextBox();
            this.spdList = new System.Windows.Forms.DataGridView();
            this.frame1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spdList)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label1.Font = new System.Drawing.Font("MS Mincho", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(-2, -1);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(143, 46);
            this.label1.TabIndex = 0;
            this.label1.Text = "TYPE検索";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(4, 553);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(415, 24);
            this.label2.TabIndex = 1;
            this.label2.Text = "ｺｰﾄﾞを入力して下さい。";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cmdFunc_10
            // 
            this.cmdFunc_10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.cmdFunc_10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.cmdFunc_10.Location = new System.Drawing.Point(215, 6);
            this.cmdFunc_10.Name = "cmdFunc_10";
            this.cmdFunc_10.Size = new System.Drawing.Size(65, 36);
            this.cmdFunc_10.TabIndex = 2;
            this.cmdFunc_10.Text = "F10:ｸﾘｱ";
            this.cmdFunc_10.UseVisualStyleBackColor = false;
            // 
            // cmdFunc_11
            // 
            this.cmdFunc_11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.cmdFunc_11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.cmdFunc_11.Location = new System.Drawing.Point(276, 6);
            this.cmdFunc_11.Name = "cmdFunc_11";
            this.cmdFunc_11.Size = new System.Drawing.Size(73, 36);
            this.cmdFunc_11.TabIndex = 3;
            this.cmdFunc_11.Text = "F11:取消";
            this.cmdFunc_11.UseVisualStyleBackColor = false;
            // 
            // cmdFunc_12
            // 
            this.cmdFunc_12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.cmdFunc_12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.cmdFunc_12.Location = new System.Drawing.Point(347, 6);
            this.cmdFunc_12.Name = "cmdFunc_12";
            this.cmdFunc_12.Size = new System.Drawing.Size(72, 36);
            this.cmdFunc_12.TabIndex = 4;
            this.cmdFunc_12.Text = "F12:確定";
            this.cmdFunc_12.UseVisualStyleBackColor = false;
            // 
            // frame1
            // 
            this.frame1.Controls.Add(this.txtSerch0);
            this.frame1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.frame1.Location = new System.Drawing.Point(7, 61);
            this.frame1.Name = "frame1";
            this.frame1.Size = new System.Drawing.Size(412, 58);
            this.frame1.TabIndex = 5;
            this.frame1.TabStop = false;
            this.frame1.Text = "MAKER曖昧検索";
            // 
            // txtSerch0
            // 
            this.txtSerch0.Location = new System.Drawing.Point(12, 24);
            this.txtSerch0.Name = "txtSerch0";
            this.txtSerch0.Size = new System.Drawing.Size(385, 23);
            this.txtSerch0.TabIndex = 7;
            // 
            // spdList
            // 
            this.spdList.BackgroundColor = System.Drawing.Color.White;
            this.spdList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.spdList.Location = new System.Drawing.Point(7, 125);
            this.spdList.Name = "spdList";
            this.spdList.Size = new System.Drawing.Size(414, 425);
            this.spdList.TabIndex = 7;
            // 
            // txtSerch_0
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(433, 610);
            this.Controls.Add(this.spdList);
            this.Controls.Add(this.frame1);
            this.Controls.Add(this.cmdFunc_12);
            this.Controls.Add(this.cmdFunc_11);
            this.Controls.Add(this.cmdFunc_10);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "txtSerch_0";
            this.Text = "frmTypeSerch";
            this.frame1.ResumeLayout(false);
            this.frame1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spdList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        public System.Windows.Forms.TextBox txtSerch0;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.Label label2;
        public System.Windows.Forms.Button cmdFunc_10;
        public System.Windows.Forms.Button cmdFunc_11;
        public System.Windows.Forms.Button cmdFunc_12;
        public System.Windows.Forms.GroupBox frame1;
        public System.Windows.Forms.DataGridView spdList;
    }
}