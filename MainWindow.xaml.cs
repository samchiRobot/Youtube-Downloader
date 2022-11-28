using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using VideoLibrary;

namespace Youtube_Downloader
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string StrURL;
        public MainWindow()
        {
            InitializeComponent();
            StrURL = "";
        }

        private bool CheckUrl(string url)
        {
            Uri uriResult;
            bool tryCreateResult = Uri.TryCreate(url, UriKind.Absolute, out uriResult);
            if (tryCreateResult == true && uriResult != null)
                return true;
            else
                return false;
        }

        private bool CheckFilePath(string path)
        {
            return true;
        }
        private async void BtnDownload_Click(object sender, RoutedEventArgs e)
        {
            if (!CheckUrl(tBoxURL.Text))
                return;
            if (!CheckFilePath(tBoxFilePath.Text))
                return;
            var videoLink = tBoxURL.Text;
            var getTitle = WebRequest.Create(videoLink);
            var youtube = YouTube.Default;
            var video = await youtube.GetVideoAsync(videoLink);
            var filePath = tBoxFilePath.Text;

            File.WriteAllBytes(filePath + @"\" + video.FullName, await video.GetBytesAsync());

        }
    }
}
