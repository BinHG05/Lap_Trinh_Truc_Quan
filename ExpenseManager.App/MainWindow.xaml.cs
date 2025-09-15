using System;
using System.Windows;

namespace ExpenseManager.App
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            InitWebView();
        }

        private async void InitWebView()
        {
            await webView.EnsureCoreWebView2Async();

            string htmlPath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "WebAssets", "index.html");

            if (System.IO.File.Exists(htmlPath))
            {
                // Chuyển path Windows thành URI hợp lệ
                string uri = new Uri(htmlPath).AbsoluteUri;
                webView.CoreWebView2.Navigate(uri);
            }
            else
            {
                MessageBox.Show("❌ Không tìm thấy file index.html");
            }
        }



    }
}
