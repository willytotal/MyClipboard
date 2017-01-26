using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using MyNewClipboard.Properties;

namespace MyNewClipboard
{
    public partial class formSystemTray : Form
    {
        private bool _bShow;
        private bool _Paste;
        private Win32Clipboard _clipboard;
        private KeyboardHook hook = new KeyboardHook();
        private List<SaveItem> _saveItems = new List<SaveItem>();
	    private bool _isError;

        public formSystemTray()
        {
			InitializeComponent();

            this.ControlBox = false;
            this.Visible = false;

            try
            {
                ResetClipboardChain();

                hook.KeyPressed += new EventHandler<KeyPressedEventArgs>(hook_KeyPressed);
                hook.RegisterHotKey(MyNewClipboard.ModifierKeys.Control | MyNewClipboard.ModifierKeys.Shift, Keys.C);
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
                throw e;
            }
        }

        private void formSystemTray_Load(object sender, EventArgs e)
        {
	        try
	        {
				SetSize();
		        LoadData();
		        DrawClipboard();
			}
	        catch (ConfigurationErrorsException)
	        {
				var dir = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
				var appName = Path.GetFileNameWithoutExtension(AppDomain.CurrentDomain.FriendlyName);

		        dir = Path.Combine(dir, appName);

#if !DEBUG
				var result = MessageBox.Show($"There appears to be a issue with the configuration file ({dir}).{Environment.NewLine}Press YES to delete the file.", "Config Error", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
		        if (result != DialogResult.Yes)
			        return;

				Directory.Delete(dir, true);
# else
				MessageBox.Show($"There appears to be a issue with the configuration file ({dir}).{Environment.NewLine}Please Delete it.", "Config Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
#endif

		        _isError = true;
				Application.Exit();
	        }
        }

	    private void formtest_FormClosing(object sender, FormClosingEventArgs e)
	    {
		    if (!_isError)
			    SaveData();
	    }

	    private void DisplayWindow(bool bShow)
        {
            if( bShow )
            {
                if( listBoxClipboard.Items.Count > 0 )
                    listBoxClipboard.SelectedIndex = 0;
            }

            _bShow = bShow;
            timerDisplay.Enabled = true;
        }

        private void timerDisplay_Tick(object sender, EventArgs e)
        {
            if( _Paste )
                this.Opacity = 0;

            if( !_bShow )
            {
                this.Opacity -= .12;
            }
            else
            {
                this.Visible = true;
                this.Activate();                
                this.Opacity += .12;
            }

            if( this.Opacity <= 0 || this.Opacity >= 1 )
            {
                timerDisplay.Enabled = false;                
            }

            if( this.Opacity <= 0 )
            {
                this.Visible = false;

                if( _Paste )
                {
                    System.Threading.Thread.Sleep(100);
                    SendKeys.Send("^v");
                    _Paste = false;
                }
            }
        }

        private void formSystemTray_Click(object sender, EventArgs e)
        {
            DisplayWindow(false);
        }

        private void formSystemTray_Deactivate(object sender, EventArgs e)
        {
            DisplayWindow(false);
        }

        private void formSystemTray_Shown(object sender, EventArgs e)
        {
            this.Visible = false;
        }

        private void hook_KeyPressed(object sender, KeyPressedEventArgs e)
        {
            DisplayWindow(true);
        }

        private void notifyIcon1_MouseClick(object sender, MouseEventArgs e)
        {
            if( e.Button == MouseButtons.Left )
            {
                DisplayWindow(!this.Visible);
            }
        }

        private void DrawClipboard()
        {
            try
            {
                string strText = GetStringFromClipboard();
                if( strText == string.Empty )
                    return;

                SaveItem saveItem;
                IEnumerable<SaveItem> saveEnum = _saveItems.Where(a => string.Compare(a.Text, strText) == 0);
                if( saveEnum.Any() )
                {
                    saveItem = saveEnum.First();
                    _saveItems.Remove(saveItem);
                }
                else
                {
                    saveItem = new SaveItem(strText);
                }

                _saveItems.Insert(0, saveItem);

                AddClipboadToListbox();
            }
            catch( Exception e )
            {
                MessageBox.Show(e.ToString());
            }
        }

        private string GetStringFromClipboard()
        {
            IDataObject iData = new DataObject();
            iData = Clipboard.GetDataObject();

            if( !iData.GetDataPresent(DataFormats.Text) )
                return "";

            return (string)iData.GetData(DataFormats.Text);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void resetClipboardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ResetClipboardChain();
        }

        private void ResetClipboardChain()
        {
            if( _clipboard != null )
                _clipboard.Dispose();

            _clipboard = new Win32Clipboard();
            _clipboard.DrawClipboard += new Win32Clipboard.DrawClipboardEvent(DrawClipboard);
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            const int WM_KEYDOWN = 0x100;

            if( msg.Msg == WM_KEYDOWN )
            {
                switch( keyData )
                {
                    case Keys.Escape:
                        DisplayWindow(false);
                        return true;

                    case Keys.Return:
                        OnItemSelected();
                        return true;

                    case Keys.Delete:
                        OnDeleteSelected();
                        return true;

                    case Keys.D0:
                    case Keys.D1:
                    case Keys.D2:
                    case Keys.D3:
                    case Keys.D4:
                    case Keys.D5:
                    case Keys.D6:
                    case Keys.D7:
                    case Keys.D8:
                    case Keys.D9:
                        OnItemSelectedNumber(keyData - Keys.D0);
                        return true;

                    case Keys.NumPad0:
                    case Keys.NumPad1:
                    case Keys.NumPad2:
                    case Keys.NumPad3:
                    case Keys.NumPad4:
                    case Keys.NumPad5:
                    case Keys.NumPad6:
                    case Keys.NumPad7:
                    case Keys.NumPad8:
                    case Keys.NumPad9:
                        OnItemSelectedNumber(keyData - Keys.NumPad0);
                        return true;
                }
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void listBox1_DrawItem(object sender, DrawItemEventArgs e)
        {
            if( e.Index == -1 )
                return;

            try
            {
                SolidBrush brushDft = new SolidBrush(Color.LemonChiffon);
                e.Graphics.FillRectangle(brushDft, e.Bounds);
                //            e.DrawBackground();

                if( (e.State & DrawItemState.Focus) == DrawItemState.Focus )
                {
                    SolidBrush brush = new SolidBrush(Color.FromArgb(196, 196, 255));
                    Rectangle rect = e.Bounds;
                    rect.Y = rect.Top + 1;
                    rect.Height -= 3;
                    rect.Width -= 4;
                    e.Graphics.FillRectangle(brush, rect);
                }
                
                // Draw the current item text based on the current Font and the custom brush settings.
                StringFormat format = new StringFormat(StringFormat.GenericDefault);
                format.Trimming = StringTrimming.EllipsisCharacter;
                string strText = GetDisplayText(e.Index, listBoxClipboard.Items[e.Index].ToString());

                e.Graphics.DrawString(strText, e.Font, Brushes.Black, Rectangle.Inflate(e.Bounds, -1, -2), format);

                Pen pen = new Pen(Color.Black);
                e.Graphics.DrawLine(pen, e.Bounds.Left, e.Bounds.Bottom - 1, e.Bounds.Right - 4, e.Bounds.Bottom - 1);
            }
            catch
            {
            }
        }

        private void OnItemSelectedNumber(int nIdx)
        {
            if( listBoxClipboard.Items.Count <= nIdx )
                return;

            listBoxClipboard.SelectedIndex = nIdx;
            OnItemSelected();
        }

        private void OnItemSelected()
        {
            SaveItem item = _saveItems[listBoxClipboard.SelectedIndex];
            if( item == null )
                return;

            // puts the text on the clipboard
            Clipboard.SetText(item.Text);
            _Paste = true;

            // hide the window
            DisplayWindow(false);
        }

        private void OnDeleteSelected()
        {
            int nIdx = listBoxClipboard.SelectedIndex;

            // don't allow the item on the clipboard to be deleted
            if( nIdx == 0 )
                return;

            _saveItems.RemoveAt(nIdx);

            AddClipboadToListbox();

            listBoxClipboard.SelectedIndex = Math.Min(nIdx, listBoxClipboard.Items.Count - 1);
        }

        private void listBoxClipboard_Click(object sender, EventArgs e)
        {
            OnItemSelected();
        }

        private void LoadData()
        {
            if( Settings.Default.SaveData == null )
                return;

            foreach( string str in Settings.Default.SaveData )
            {
                _saveItems.Add(new SaveItem(str.Replace("\n", "\r\n")));
            }
        }

        private void SaveData()
        {
            System.Collections.Specialized.StringCollection coll = Settings.Default.SaveData;
            if( coll == null )
                coll = new System.Collections.Specialized.StringCollection();
            
            coll.Clear();
            if( Settings.Default.SaveArray )
            {
                foreach( SaveItem item in _saveItems )
                {
                    coll.Add(item.Text);
                }
            }

            Settings.Default.SaveData = coll;
            Settings.Default.Save();
        }

        private void configToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using( formConfig form = new formConfig() )
            {
                if( form.ShowDialog() != DialogResult.OK )
                    return;

                AddClipboadToListbox();
                SetSize();
            }
        }

        private void AddClipboadToListbox()
        {
            int nCount = Math.Max(1, Convert.ToInt32(Settings.Default.SaveCount));
            if( _saveItems.Count > nCount )
                _saveItems.RemoveRange(nCount, _saveItems.Count - nCount);

            listBoxClipboard.DataSource = _saveItems.ToList();
        }

        private void SetSize()
        {
	        try
	        {
				int nHeight = (Convert.ToInt32(Settings.Default.DisplayCount) * listBoxClipboard.ItemHeight) + 4;
				this.Size = new Size(this.Size.Width, nHeight);
				Size screen = new Size(Screen.PrimaryScreen.WorkingArea.Width - 10, Screen.PrimaryScreen.WorkingArea.Height - 5);
				this.Location = new Point(Size.Subtract(screen, this.Size));

			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
		        throw;
	        }

        }

        private void listBoxClipboard_MouseMove(object sender, MouseEventArgs e)
        {
            int nIdx = listBoxClipboard.IndexFromPoint(new Point(e.X, e.Y));
            listBoxClipboard.SelectedIndex = nIdx;
        }

        private string GetDisplayText(int nIdx, string strText)
        {
            strText = strText.Substring(0, Math.Min(100, strText.Length));
            if( !Settings.Default.ShowLineNumbers )
                return strText;

            return string.Format("[{0}] {1}", nIdx, strText);
        }

        private void timerCheckChain_Tick(object sender, EventArgs e)
        {
            if( string.Compare(GetStringFromClipboard(), _saveItems[0].Text) != 0 )
                ResetClipboardChain();
        }

    }
}
