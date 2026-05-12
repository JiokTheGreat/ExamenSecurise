using System;
using System.Windows.Forms;
using Microsoft.Web.WebView2.WinForms;

namespace ExamenSecurise
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
        }
    }

    public partial class Form1 : Form
    {
        private WebView2 webView21;

        public Form1()
        {
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
            this.TopMost = true;

            webView21 = new WebView2();
            webView21.Dock = DockStyle.Fill;
            this.Controls.Add(webView21);

            InitializeWebView();
        }

        private async void InitializeWebView()
        {
            await webView21.EnsureCoreWebView2Async(null);
            webView21.CoreWebView2.Settings.AreDefaultContextMenusEnabled = false;
            webView21.CoreWebView2.Settings.AreDevToolsEnabled = false;
            webView21.CoreWebView2.NewWindowRequested += (s, e) => { e.Handled = true; };

            // MODIFIEZ L'URL ICI AVEC VOTRE ÉPREUVE INTERACTIVE :
            webView21.Source = new Uri("https://votre-site-d-epreuve.com");
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Alt | Keys.Tab) || 
                keyData == (Keys.Alt | Keys.F4) || 
                keyData == (Keys.Control | Keys.N))
            {
                return true; 
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}
