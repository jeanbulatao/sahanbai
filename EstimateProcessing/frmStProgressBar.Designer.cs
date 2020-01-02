namespace EstimateProcessing
{
    partial class frmStProgressBar
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
            this.frame1 = new System.Windows.Forms.GroupBox();
            this.prgCount = new System.Windows.Forms.TextBox();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.frame1.SuspendLayout();
            this.SuspendLayout();
            // 
            // frame1
            // 
            this.frame1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.frame1.Controls.Add(this.prgCount);
            this.frame1.Location = new System.Drawing.Point(12, 12);
            this.frame1.Name = "frame1";
            this.frame1.Size = new System.Drawing.Size(406, 108);
            this.frame1.TabIndex = 0;
            this.frame1.TabStop = false;
            // 
            // prgCount
            // 
            this.prgCount.BackColor = System.Drawing.SystemColors.ControlLight;
            this.prgCount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.prgCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.prgCount.Location = new System.Drawing.Point(31, 40);
            this.prgCount.Name = "prgCount";
            this.prgCount.ReadOnly = true;
            this.prgCount.Size = new System.Drawing.Size(338, 24);
            this.prgCount.TabIndex = 1;
            // 
            // cmdCancel
            // 
            this.cmdCancel.Location = new System.Drawing.Point(148, 126);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(110, 32);
            this.cmdCancel.TabIndex = 1;
            this.cmdCancel.Text = "中止";
            this.cmdCancel.UseVisualStyleBackColor = true;
            // 
            // frmStProgressBar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(439, 212);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.frame1);
            this.Name = "frmStProgressBar";
            this.Text = "処理中";
            this.frame1.ResumeLayout(false);
            this.frame1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        public System.Windows.Forms.TextBox prgCount;
        public System.Windows.Forms.GroupBox frame1;
        public System.Windows.Forms.Button cmdCancel;
    }
}