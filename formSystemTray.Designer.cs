namespace MyNewClipboard
{
    partial class formSystemTray
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formSystemTray));
            this.timerDisplay = new System.Windows.Forms.Timer(this.components);
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.resetClipboardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.configToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listBoxClipboard = new System.Windows.Forms.ListBox();
            this.timerCheckChain = new System.Windows.Forms.Timer(this.components);
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // timerDisplay
            // 
            this.timerDisplay.Interval = 50;
            this.timerDisplay.Tick += new System.EventHandler(this.timerDisplay_Tick);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.ContextMenuStrip = this.contextMenuStrip1;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "Click here to Configure MyClipboad";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem,
            this.toolStripSeparator1,
            this.resetClipboardToolStripMenuItem,
            this.configToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(158, 76);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(154, 6);
            // 
            // resetClipboardToolStripMenuItem
            // 
            this.resetClipboardToolStripMenuItem.Name = "resetClipboardToolStripMenuItem";
            this.resetClipboardToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.resetClipboardToolStripMenuItem.Text = "Reset Clipboard";
            this.resetClipboardToolStripMenuItem.Click += new System.EventHandler(this.resetClipboardToolStripMenuItem_Click);
            // 
            // configToolStripMenuItem
            // 
            this.configToolStripMenuItem.Name = "configToolStripMenuItem";
            this.configToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.configToolStripMenuItem.Text = "Configure";
            this.configToolStripMenuItem.Click += new System.EventHandler(this.configToolStripMenuItem_Click);
            // 
            // listBoxClipboard
            // 
            this.listBoxClipboard.BackColor = System.Drawing.Color.LemonChiffon;
            this.listBoxClipboard.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listBoxClipboard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxClipboard.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.listBoxClipboard.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBoxClipboard.FormattingEnabled = true;
            this.listBoxClipboard.ItemHeight = 18;
            this.listBoxClipboard.Location = new System.Drawing.Point(5, 2);
            this.listBoxClipboard.Name = "listBoxClipboard";
            this.listBoxClipboard.Size = new System.Drawing.Size(258, 252);
            this.listBoxClipboard.TabIndex = 1;
            this.listBoxClipboard.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.listBox1_DrawItem);
            this.listBoxClipboard.MouseMove += new System.Windows.Forms.MouseEventHandler(this.listBoxClipboard_MouseMove);
            this.listBoxClipboard.Click += new System.EventHandler(this.listBoxClipboard_Click);
            // 
            // timerCheckChain
            // 
            this.timerCheckChain.Enabled = true;
            this.timerCheckChain.Interval = 900000;
            this.timerCheckChain.Tick += new System.EventHandler(this.timerCheckChain_Tick);
            // 
            // formSystemTray
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LemonChiffon;
            this.ClientSize = new System.Drawing.Size(264, 256);
            this.Controls.Add(this.listBoxClipboard);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "formSystemTray";
            this.Padding = new System.Windows.Forms.Padding(5, 2, 1, 0);
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.TopMost = true;
            this.Deactivate += new System.EventHandler(this.formSystemTray_Deactivate);
            this.Load += new System.EventHandler(this.formSystemTray_Load);
            this.Shown += new System.EventHandler(this.formSystemTray_Shown);
            this.Click += new System.EventHandler(this.formSystemTray_Click);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.formtest_FormClosing);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer timerDisplay;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem resetClipboardToolStripMenuItem;
        private System.Windows.Forms.ListBox listBoxClipboard;
        private System.Windows.Forms.ToolStripMenuItem configToolStripMenuItem;
        private System.Windows.Forms.Timer timerCheckChain;
    }
}