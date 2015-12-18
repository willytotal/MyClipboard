namespace MyNewClipboard
{
    partial class formConfig
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
            if( disposing && (components != null) )
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
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cbShowLineNum = new System.Windows.Forms.CheckBox();
            this.txListCnt = new System.Windows.Forms.TextBox();
            this.txDisplayCnt = new System.Windows.Forms.TextBox();
            this.cbSaveClipboard = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // btnOk
            // 
            this.btnOk.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.Location = new System.Drawing.Point(35, 129);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 4;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(116, 129);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(54, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(135, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Number of Rows to Display";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(54, 87);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(126, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Number of Rows to Keep";
            // 
            // cbShowLineNum
            // 
            this.cbShowLineNum.AutoSize = true;
            this.cbShowLineNum.Checked = global::MyNewClipboard.Properties.Settings.Default.ShowLineNumbers;
            this.cbShowLineNum.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::MyNewClipboard.Properties.Settings.Default, "ShowLineNumbers", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cbShowLineNum.Location = new System.Drawing.Point(12, 35);
            this.cbShowLineNum.Name = "cbShowLineNum";
            this.cbShowLineNum.Size = new System.Drawing.Size(121, 17);
            this.cbShowLineNum.TabIndex = 1;
            this.cbShowLineNum.Text = "Show Line Numbers";
            this.cbShowLineNum.UseVisualStyleBackColor = true;
            // 
            // txListCnt
            // 
            this.txListCnt.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::MyNewClipboard.Properties.Settings.Default, "SaveCount", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.txListCnt.Location = new System.Drawing.Point(12, 84);
            this.txListCnt.MaxLength = 2;
            this.txListCnt.Name = "txListCnt";
            this.txListCnt.Size = new System.Drawing.Size(36, 20);
            this.txListCnt.TabIndex = 3;
            this.txListCnt.Text = global::MyNewClipboard.Properties.Settings.Default.SaveCount;
            this.txListCnt.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tx_KeyPress);
            // 
            // txDisplayCnt
            // 
            this.txDisplayCnt.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::MyNewClipboard.Properties.Settings.Default, "DisplayCount", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.txDisplayCnt.Location = new System.Drawing.Point(12, 58);
            this.txDisplayCnt.MaxLength = 2;
            this.txDisplayCnt.Name = "txDisplayCnt";
            this.txDisplayCnt.Size = new System.Drawing.Size(36, 20);
            this.txDisplayCnt.TabIndex = 2;
            this.txDisplayCnt.Text = global::MyNewClipboard.Properties.Settings.Default.DisplayCount;
            this.txDisplayCnt.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tx_KeyPress);
            // 
            // cbSaveClipboard
            // 
            this.cbSaveClipboard.AutoSize = true;
            this.cbSaveClipboard.Checked = global::MyNewClipboard.Properties.Settings.Default.SaveArray;
            this.cbSaveClipboard.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbSaveClipboard.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::MyNewClipboard.Properties.Settings.Default, "SaveArray", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cbSaveClipboard.Location = new System.Drawing.Point(12, 12);
            this.cbSaveClipboard.Name = "cbSaveClipboard";
            this.cbSaveClipboard.Size = new System.Drawing.Size(160, 17);
            this.cbSaveClipboard.TabIndex = 0;
            this.cbSaveClipboard.Text = "Save Clipboard when exiting";
            this.cbSaveClipboard.UseVisualStyleBackColor = true;
            // 
            // formConfig
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(226, 164);
            this.Controls.Add(this.cbShowLineNum);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txListCnt);
            this.Controls.Add(this.txDisplayCnt);
            this.Controls.Add(this.cbSaveClipboard);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "formConfig";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Config";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.CheckBox cbSaveClipboard;
        private System.Windows.Forms.TextBox txDisplayCnt;
        private System.Windows.Forms.TextBox txListCnt;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox cbShowLineNum;
    }
}