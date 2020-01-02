namespace EstimateProcessing
{
    partial class frmRefUniTbl
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
            this.mnuEdit = new System.Windows.Forms.MenuStrip();
            this.mnuEditMode = new System.Windows.Forms.ToolStripMenuItem();
            this.削除ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.lblGuide = new System.Windows.Forms.Label();
            this.cmdFunc_10 = new System.Windows.Forms.Button();
            this.cmdFunc_11 = new System.Windows.Forms.Button();
            this.cmdFunc_12 = new System.Windows.Forms.Button();
            this.Frame__Jyouken = new System.Windows.Forms.GroupBox();
            this.txtSerch = new System.Windows.Forms.TextBox();
            this.spdTblInfo = new System.Windows.Forms.DataGridView();
            this.mnuEdit.SuspendLayout();
            this.Frame__Jyouken.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spdTblInfo)).BeginInit();
            this.SuspendLayout();
            // 
            // mnuEdit
            // 
            this.mnuEdit.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuEditMode});
            this.mnuEdit.Location = new System.Drawing.Point(0, 0);
            this.mnuEdit.Name = "mnuEdit";
            this.mnuEdit.Size = new System.Drawing.Size(509, 24);
            this.mnuEdit.TabIndex = 0;
            this.mnuEdit.Text = "EDIT";
            // 
            // mnuEditMode
            // 
            this.mnuEditMode.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.削除ToolStripMenuItem});
            this.mnuEditMode.Name = "mnuEditMode";
            this.mnuEditMode.Size = new System.Drawing.Size(43, 20);
            this.mnuEditMode.Text = "EDIT";
            // 
            // 削除ToolStripMenuItem
            // 
            this.削除ToolStripMenuItem.Name = "削除ToolStripMenuItem";
            this.削除ToolStripMenuItem.Size = new System.Drawing.Size(98, 22);
            this.削除ToolStripMenuItem.Text = "削除";
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label1.Font = new System.Drawing.Font("MS Mincho", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(12, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(192, 34);
            this.label1.TabIndex = 1;
            this.label1.Text = "UNIT 参照";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblGuide
            // 
            this.lblGuide.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblGuide.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblGuide.ForeColor = System.Drawing.Color.White;
            this.lblGuide.Location = new System.Drawing.Point(13, 609);
            this.lblGuide.Name = "lblGuide";
            this.lblGuide.Size = new System.Drawing.Size(484, 23);
            this.lblGuide.TabIndex = 2;
            this.lblGuide.Text = "ｺｰﾄﾞを入力して下さい。";
            this.lblGuide.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cmdFunc_10
            // 
            this.cmdFunc_10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.cmdFunc_10.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.cmdFunc_10.Location = new System.Drawing.Point(242, 36);
            this.cmdFunc_10.Name = "cmdFunc_10";
            this.cmdFunc_10.Size = new System.Drawing.Size(86, 44);
            this.cmdFunc_10.TabIndex = 3;
            this.cmdFunc_10.Text = "登録(F10)";
            this.cmdFunc_10.UseVisualStyleBackColor = false;
            this.cmdFunc_10.Click += new System.EventHandler(this.cmdFunc_10_Click);
            // 
            // cmdFunc_11
            // 
            this.cmdFunc_11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.cmdFunc_11.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.cmdFunc_11.Location = new System.Drawing.Point(330, 36);
            this.cmdFunc_11.Name = "cmdFunc_11";
            this.cmdFunc_11.Size = new System.Drawing.Size(85, 44);
            this.cmdFunc_11.TabIndex = 4;
            this.cmdFunc_11.Text = "戻る(F11)";
            this.cmdFunc_11.UseVisualStyleBackColor = false;
            this.cmdFunc_11.Click += new System.EventHandler(this.cmdFunc_11_Click);
            // 
            // cmdFunc_12
            // 
            this.cmdFunc_12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.cmdFunc_12.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.cmdFunc_12.Location = new System.Drawing.Point(417, 36);
            this.cmdFunc_12.Name = "cmdFunc_12";
            this.cmdFunc_12.Size = new System.Drawing.Size(81, 44);
            this.cmdFunc_12.TabIndex = 5;
            this.cmdFunc_12.Text = "確定(F12)";
            this.cmdFunc_12.UseVisualStyleBackColor = false;
            this.cmdFunc_12.Click += new System.EventHandler(this.cmdFunc_12_Click);
            // 
            // Frame__Jyouken
            // 
            this.Frame__Jyouken.Controls.Add(this.txtSerch);
            this.Frame__Jyouken.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Frame__Jyouken.Location = new System.Drawing.Point(12, 86);
            this.Frame__Jyouken.Name = "Frame__Jyouken";
            this.Frame__Jyouken.Size = new System.Drawing.Size(486, 57);
            this.Frame__Jyouken.TabIndex = 6;
            this.Frame__Jyouken.TabStop = false;
            this.Frame__Jyouken.Text = "曖昧検索";
            // 
            // txtSerch
            // 
            this.txtSerch.Location = new System.Drawing.Point(15, 23);
            this.txtSerch.Name = "txtSerch";
            this.txtSerch.Size = new System.Drawing.Size(454, 23);
            this.txtSerch.TabIndex = 0;
            // 
            // spdTblInfo
            // 
            this.spdTblInfo.BackgroundColor = System.Drawing.Color.White;
            this.spdTblInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.spdTblInfo.Location = new System.Drawing.Point(12, 156);
            this.spdTblInfo.Name = "spdTblInfo";
            this.spdTblInfo.Size = new System.Drawing.Size(486, 437);
            this.spdTblInfo.TabIndex = 8;
            // 
            // frmRefUniTbl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(509, 647);
            this.Controls.Add(this.spdTblInfo);
            this.Controls.Add(this.Frame__Jyouken);
            this.Controls.Add(this.cmdFunc_12);
            this.Controls.Add(this.cmdFunc_11);
            this.Controls.Add(this.cmdFunc_10);
            this.Controls.Add(this.lblGuide);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.mnuEdit);
            this.MainMenuStrip = this.mnuEdit;
            this.Name = "frmRefUniTbl";
            this.Text = "UNIT　参照 (frmRefUniTbl)";
            this.mnuEdit.ResumeLayout(false);
            this.mnuEdit.PerformLayout();
            this.Frame__Jyouken.ResumeLayout(false);
            this.Frame__Jyouken.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spdTblInfo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public System.Windows.Forms.TextBox txtSerch;
        public System.Windows.Forms.MenuStrip mnuEdit;
        public System.Windows.Forms.ToolStripMenuItem mnuEditMode;
        public System.Windows.Forms.ToolStripMenuItem 削除ToolStripMenuItem;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.Label lblGuide;
        public System.Windows.Forms.Button cmdFunc_10;
        public System.Windows.Forms.Button cmdFunc_11;
        public System.Windows.Forms.Button cmdFunc_12;
        public System.Windows.Forms.GroupBox Frame__Jyouken;
        public System.Windows.Forms.DataGridView spdTblInfo;
    }
}