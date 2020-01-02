namespace EstimateProcessing
{
    partial class frmStPrinterSelect
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
            this.fraBusuu = new System.Windows.Forms.GroupBox();
            this.numBusuu = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmdOK = new System.Windows.Forms.Button();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.fraBusuu.SuspendLayout();
            this.SuspendLayout();
            // 
            // fraBusuu
            // 
            this.fraBusuu.Controls.Add(this.numBusuu);
            this.fraBusuu.Controls.Add(this.label1);
            this.fraBusuu.Location = new System.Drawing.Point(12, 12);
            this.fraBusuu.Name = "fraBusuu";
            this.fraBusuu.Size = new System.Drawing.Size(548, 83);
            this.fraBusuu.TabIndex = 0;
            this.fraBusuu.TabStop = false;
            this.fraBusuu.Text = "印刷部数";
            // 
            // numBusuu
            // 
            this.numBusuu.Location = new System.Drawing.Point(111, 33);
            this.numBusuu.Name = "numBusuu";
            this.numBusuu.ReadOnly = true;
            this.numBusuu.Size = new System.Drawing.Size(109, 20);
            this.numBusuu.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label1.Location = new System.Drawing.Point(28, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "印刷部数 ：";
            // 
            // cmdOK
            // 
            this.cmdOK.Location = new System.Drawing.Point(371, 101);
            this.cmdOK.Name = "cmdOK";
            this.cmdOK.Size = new System.Drawing.Size(86, 31);
            this.cmdOK.TabIndex = 1;
            this.cmdOK.Text = "OK";
            this.cmdOK.UseVisualStyleBackColor = true;
            // 
            // cmdCancel
            // 
            this.cmdCancel.Location = new System.Drawing.Point(474, 101);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(86, 31);
            this.cmdCancel.TabIndex = 2;
            this.cmdCancel.Text = "ｷｬﾝｾﾙ";
            this.cmdCancel.UseVisualStyleBackColor = true;
            // 
            // frmStPrinterSelect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(579, 155);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.cmdOK);
            this.Controls.Add(this.fraBusuu);
            this.Name = "frmStPrinterSelect";
            this.Text = "ﾌﾟﾘﾝﾀの設定";
            this.fraBusuu.ResumeLayout(false);
            this.fraBusuu.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        public System.Windows.Forms.TextBox numBusuu;
        public System.Windows.Forms.GroupBox fraBusuu;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.Button cmdOK;
        public System.Windows.Forms.Button cmdCancel;
    }
}