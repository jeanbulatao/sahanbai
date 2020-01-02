namespace EstimateProcessing
{
    partial class frmMITMR010P
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
            this.pibView1 = new System.Windows.Forms.DataGridView();
            this.cmdFunc_7 = new System.Windows.Forms.Button();
            this.cmdFunc_8 = new System.Windows.Forms.Button();
            this.cmdFunc_10 = new System.Windows.Forms.Button();
            this.cmdFunc_11 = new System.Windows.Forms.Button();
            this.cmdFunc_12 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pibView1)).BeginInit();
            this.SuspendLayout();
            // 
            // pibView1
            // 
            this.pibView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.pibView1.Location = new System.Drawing.Point(24, 18);
            this.pibView1.Name = "pibView1";
            this.pibView1.Size = new System.Drawing.Size(743, 471);
            this.pibView1.TabIndex = 0;
            // 
            // cmdFunc_7
            // 
            this.cmdFunc_7.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.cmdFunc_7.Location = new System.Drawing.Point(24, 508);
            this.cmdFunc_7.Name = "cmdFunc_7";
            this.cmdFunc_7.Size = new System.Drawing.Size(108, 27);
            this.cmdFunc_7.TabIndex = 1;
            this.cmdFunc_7.Text = "前頁(F7)";
            this.cmdFunc_7.UseVisualStyleBackColor = true;
            // 
            // cmdFunc_8
            // 
            this.cmdFunc_8.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.cmdFunc_8.Location = new System.Drawing.Point(138, 508);
            this.cmdFunc_8.Name = "cmdFunc_8";
            this.cmdFunc_8.Size = new System.Drawing.Size(108, 27);
            this.cmdFunc_8.TabIndex = 2;
            this.cmdFunc_8.Text = "次頁(F8)";
            this.cmdFunc_8.UseVisualStyleBackColor = true;
            // 
            // cmdFunc_10
            // 
            this.cmdFunc_10.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.cmdFunc_10.Location = new System.Drawing.Point(425, 508);
            this.cmdFunc_10.Name = "cmdFunc_10";
            this.cmdFunc_10.Size = new System.Drawing.Size(108, 27);
            this.cmdFunc_10.TabIndex = 3;
            this.cmdFunc_10.Text = "全頁印刷(F10)";
            this.cmdFunc_10.UseVisualStyleBackColor = true;
            // 
            // cmdFunc_11
            // 
            this.cmdFunc_11.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.cmdFunc_11.Location = new System.Drawing.Point(539, 508);
            this.cmdFunc_11.Name = "cmdFunc_11";
            this.cmdFunc_11.Size = new System.Drawing.Size(108, 27);
            this.cmdFunc_11.TabIndex = 4;
            this.cmdFunc_11.Text = "１頁印刷(F11)";
            this.cmdFunc_11.UseVisualStyleBackColor = true;
            // 
            // cmdFunc_12
            // 
            this.cmdFunc_12.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.cmdFunc_12.Location = new System.Drawing.Point(653, 508);
            this.cmdFunc_12.Name = "cmdFunc_12";
            this.cmdFunc_12.Size = new System.Drawing.Size(108, 27);
            this.cmdFunc_12.TabIndex = 5;
            this.cmdFunc_12.Text = "終了(F12)";
            this.cmdFunc_12.UseVisualStyleBackColor = true;
            // 
            // frmMITMR010P
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(782, 563);
            this.Controls.Add(this.cmdFunc_12);
            this.Controls.Add(this.cmdFunc_11);
            this.Controls.Add(this.cmdFunc_10);
            this.Controls.Add(this.cmdFunc_8);
            this.Controls.Add(this.cmdFunc_7);
            this.Controls.Add(this.pibView1);
            this.Name = "frmMITMR010P";
            this.Text = "印刷プレビュー";
            this.Load += new System.EventHandler(this.frmMITMR010P_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pibView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.DataGridView pibView1;
        public System.Windows.Forms.Button cmdFunc_7;
        public System.Windows.Forms.Button cmdFunc_8;
        public System.Windows.Forms.Button cmdFunc_10;
        public System.Windows.Forms.Button cmdFunc_11;
        public System.Windows.Forms.Button cmdFunc_12;
    }
}