using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace TweetDeckViewer
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
            this.Icon = new Icon(@"icon.ico");
        }

        private void Main_Load(object sender, EventArgs e)
        {
            // ウィンドウの位置・サイズを復元
            Bounds = Properties.Settings.Default.Bounds;
            WindowState = Properties.Settings.Default.WindowState;
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            // ウィンドウの位置・サイズを保存
            if (WindowState == FormWindowState.Normal)
                Properties.Settings.Default.Bounds = Bounds;
            else
                Properties.Settings.Default.Bounds = RestoreBounds;

            Properties.Settings.Default.WindowState = WindowState;

            Properties.Settings.Default.Save();
        }

        private void webBrowser1_NewWindow(object sender, CancelEventArgs e)
        {
            WebBrowser wb = (WebBrowser)sender;
            string txt = wb.StatusText;
            if (txt != "")
            {
                System.Diagnostics.Process.Start(txt);
            }
            //ここで標準ブラウザで開くのをキャンセルしている
            e.Cancel = true;
        }
    }
}
