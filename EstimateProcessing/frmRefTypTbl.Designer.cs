namespace EstimateProcessing
{
    partial class frmRefTypTbl
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.mnuEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuEditMode = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.cmdFunc_10 = new System.Windows.Forms.Button();
            this.cmdFunc_11 = new System.Windows.Forms.Button();
            this.cmdFunc_12 = new System.Windows.Forms.Button();
            this.Frame__Jyouken = new System.Windows.Forms.GroupBox();
            this.txtSerch = new System.Windows.Forms.TextBox();
            this.lblGuide = new System.Windows.Forms.Label();
            this.spdTblInfo = new System.Windows.Forms.DataGridView();
            this.menuStrip1.SuspendLayout();
            this.Frame__Jyouken.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spdTblInfo)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuEdit});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(531, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // mnuEdit
            // 
            this.mnuEdit.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuEditMode});
            this.mnuEdit.Name = "mnuEdit";
            this.mnuEdit.Size = new System.Drawing.Size(43, 20);
            this.mnuEdit.Text = "EDIT";
            // 
            // mnuEditMode
            // 
            this.mnuEditMode.Name = "mnuEditMode";
            this.mnuEditMode.Size = new System.Drawing.Size(98, 22);
            this.mnuEditMode.Text = "削除";
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.MediumBlue;
            this.label1.Font = new System.Drawing.Font("MS Mincho", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(12, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(186, 36);
            this.label1.TabIndex = 1;
            this.label1.Text = "TYPE 参照";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cmdFunc_10
            // 
            this.cmdFunc_10.AutoSize = true;
            this.cmdFunc_10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.cmdFunc_10.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.cmdFunc_10.Location = new System.Drawing.Point(266, 38);
            this.cmdFunc_10.Name = "cmdFunc_10";
            this.cmdFunc_10.Size = new System.Drawing.Size(83, 42);
            this.cmdFunc_10.TabIndex = 2;
            this.cmdFunc_10.Text = "登録(F10)";
            this.cmdFunc_10.UseVisualStyleBackColor = false;
            // 
            // cmdFunc_11
            // 
            this.cmdFunc_11.AutoSize = true;
            this.cmdFunc_11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.cmdFunc_11.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.cmdFunc_11.Location = new System.Drawing.Point(347, 38);
            this.cmdFunc_11.Name = "cmdFunc_11";
            this.cmdFunc_11.Size = new System.Drawing.Size(79, 42);
            this.cmdFunc_11.TabIndex = 3;
            this.cmdFunc_11.Text = "戻る(F11)";
            this.cmdFunc_11.UseVisualStyleBackColor = false;
            // 
            // cmdFunc_12
            // 
            this.cmdFunc_12.AutoSize = true;
            this.cmdFunc_12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.cmdFunc_12.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.cmdFunc_12.Location = new System.Drawing.Point(428, 38);
            this.cmdFunc_12.Name = "cmdFunc_12";
            this.cmdFunc_12.Size = new System.Drawing.Size(83, 42);
            this.cmdFunc_12.TabIndex = 4;
            this.cmdFunc_12.Text = "確定(F12)";
            this.cmdFunc_12.UseVisualStyleBackColor = false;
            // 
            // Frame__Jyouken
            // 
            this.Frame__Jyouken.Controls.Add(this.txtSerch);
            this.Frame__Jyouken.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Frame__Jyouken.Location = new System.Drawing.Point(10, 86);
            this.Frame__Jyouken.Name = "Frame__Jyouken";
            this.Frame__Jyouken.Size = new System.Drawing.Size(501, 63);
            this.Frame__Jyouken.TabIndex = 5;
            this.Frame__Jyouken.TabStop = false;
            this.Frame__Jyouken.Text = "曖昧検索";
            // 
            // txtSerch
            // 
            this.txtSerch.Location = new System.Drawing.Point(16, 24);
            this.txtSerch.Name = "txtSerch";
            this.txtSerch.Size = new System.Drawing.Size(469, 23);
            this.txtSerch.TabIndex = 8;
            // 
            // lblGuide
            // 
            this.lblGuide.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblGuide.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblGuide.ForeColor = System.Drawing.Color.White;
            this.lblGuide.Location = new System.Drawing.Point(12, 616);
            this.lblGuide.Name = "lblGuide";
            this.lblGuide.Size = new System.Drawing.Size(498, 22);
            this.lblGuide.TabIndex = 7;
            this.lblGuide.Text = "ｺｰﾄﾞを入力して下さい。";
            this.lblGuide.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // spdTblInfo
            // 
            this.spdTblInfo.BackgroundColor = System.Drawing.Color.White;
            this.spdTblInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.spdTblInfo.Location = new System.Drawing.Point(10, 155);
            this.spdTblInfo.Name = "spdTblInfo";
            this.spdTblInfo.Size = new System.Drawing.Size(501, 447);
            this.spdTblInfo.TabIndex = 8;
            // 
            // frmRefTypTbl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(531, 727);
            this.Controls.Add(this.spdTblInfo);
            this.Controls.Add(this.lblGuide);
            this.Controls.Add(this.Frame__Jyouken);
            this.Controls.Add(this.cmdFunc_12);
            this.Controls.Add(this.cmdFunc_11);
            this.Controls.Add(this.cmdFunc_10);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmRefTypTbl";
            this.Text = "TYPE　参照 (frmRefTypTbl)";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.Frame__Jyouken.ResumeLayout(false);
            this.Frame__Jyouken.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spdTblInfo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public System.Windows.Forms.TextBox txtSerch;
        public System.Windows.Forms.MenuStrip menuStrip1;
        public System.Windows.Forms.ToolStripMenuItem mnuEdit;
        public System.Windows.Forms.ToolStripMenuItem mnuEditMode;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.Button cmdFunc_10;
        public System.Windows.Forms.Button cmdFunc_11;
        public System.Windows.Forms.Button cmdFunc_12;
        public System.Windows.Forms.GroupBox Frame__Jyouken;
        public System.Windows.Forms.Label lblGuide;
        public System.Windows.Forms.DataGridView spdTblInfo;
    }
}