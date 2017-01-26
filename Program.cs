using System;
using System.Threading;
using System.Windows.Forms;

namespace MyNewClipboard
{
    static class Program
    {
		private static Mutex _singleInstanceMutex;

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
        static void Main()
        {
			if (Mutex.TryOpenExisting("MyClipboard", out _singleInstanceMutex))
			{
				MessageBox.Show("Only one instance can run");
				Application.Exit();
				return;
			}

			Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

			_singleInstanceMutex = new Mutex(true, "MyClipboard");

			try
            {
                formSystemTray form = new formSystemTray();
                Application.Run(form);
            }
            catch
            {
            	
            }                       
        }
    }
}
