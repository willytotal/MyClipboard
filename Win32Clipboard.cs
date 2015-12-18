using System;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace MyNewClipboard
{
    internal sealed class Win32Clipboard : IDisposable
    {
        public event DrawClipboardEvent DrawClipboard;
        public delegate void DrawClipboardEvent();

        #region externs
        [DllImport("User32.dll")]
        private static extern int SetClipboardViewer(int hWndNewViewer);

        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        private static extern bool ChangeClipboardChain(IntPtr hWndRemove, IntPtr hWndNewNext);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern int SendMessage(IntPtr hwnd, int wMsg, IntPtr wParam, IntPtr lParam);
        #endregion // externs

        private Window _window = new Window();
        private IntPtr _nextClipboardViewer;

        public Win32Clipboard()
        {
            _window.DrawClipboard += new Window.DrawClipboardHandler(window_DrawClipboard);
            _window.ChangeCBChain += new Window.ChangeCBChainHandler(window_ChangeCBChain);

            _nextClipboardViewer = (IntPtr)SetClipboardViewer((int)_window.Handle);
        }

        private class Window : NativeWindow, IDisposable
        {
            public event DrawClipboardHandler DrawClipboard;
            public delegate void DrawClipboardHandler(ref Message m);
            public event ChangeCBChainHandler ChangeCBChain;
            public delegate void ChangeCBChainHandler(ref Message m);

            public Window()
            {
                // create the handle for the window.
                this.CreateHandle(new CreateParams());
            }

            protected override void WndProc(ref Message m)
            {
                const int WM_DRAWCLIPBOARD = 0x308;
                const int WM_CHANGECBCHAIN = 0x030D;

                switch( m.Msg )
                {
                    case WM_DRAWCLIPBOARD:
                        if( DrawClipboard != null )
                        {
                            DrawClipboard(ref m);
                            return;
                        }
                        break;

                    case WM_CHANGECBCHAIN:
                        if( ChangeCBChain != null )
                        {
                            ChangeCBChain(ref m);
                            return;
                        }
                        break;

                    default:
                        break;
                }

                base.WndProc(ref m);
            }  

            #region IDisposable Members

            public void Dispose()
            {
                this.DestroyHandle();
            }

            #endregion
        }

        public void Dispose()
        {
            ChangeClipboardChain(_window.Handle, _nextClipboardViewer);

            _window.Dispose();
        }

        private void window_DrawClipboard(ref Message m)
        {
            if( DrawClipboard != null )
                DrawClipboard();

            SendMessage(_nextClipboardViewer, m.Msg, m.WParam, m.LParam);
        }

        private void window_ChangeCBChain(ref Message m)
        {
            if( m.WParam == _nextClipboardViewer )
                _nextClipboardViewer = m.LParam;
            else
                SendMessage(_nextClipboardViewer, m.Msg, m.WParam, m.LParam);
        }


    }
}
