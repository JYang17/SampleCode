using System;
using System.Collections.Generic;
using System.Linq;
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

using System.IO;
using System.Net;
using System.ComponentModel;

namespace CCWTemplateDownloader
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //private WebClient downloader = new WebClient();
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void DownloadButton_Click(object sender, RoutedEventArgs e)
        {
            await DownloadFileToLocalAsync();
        }

        private async Task DownloadFileToLocalAsync()
        {
            //var urlAddress = @"http://files.cnblogs.com/x4646/tree.zip";
            var urlAddress = @"http://project.ra.rockwell.com/PWA/S3525_U3526_D3527_NPD_CCWv11/Lists/Team%20Discussion/Attachments/23/LargeMemoryModelModifications.docx";
            //var urlAddress = @"thunder://QUFmdHA6Ly9keTpkeUBkeWdvZGo4LmNvbToxMzEyL1vnlLXlvbHlpKnloIJ3d3cuZHkyMDE4LmNvbV3plb/ln45IROmrmOa4hemfqeeJiOS4reWtly5ta3ZaWg==";
            var address = new Uri(urlAddress);
            var receivePath = @"C:\1\";
            var filePath = receivePath + System.IO.Path.GetFileName(urlAddress);

            using (WebClient downloader = new WebClient())
            {
                downloader.DownloadFileCompleted += new AsyncCompletedEventHandler(downloader_DownloadFileCompleted);
                downloader.DownloadProgressChanged += new DownloadProgressChangedEventHandler(downloader_DownloadProgressChanged);

                downloader.UseDefaultCredentials = true;//use current user's credential 
                //downloader.Credentials.GetCredential(Uri uri, string authType);
                downloader.DownloadFileAsync(address, filePath);
            }
        }

        void downloader_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            //label1.Text = e.BytesReceived + " " + e.ProgressPercentage;
        }
        void downloader_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            if (e.Error != null)
                MessageBox.Show(e.Error.Message);
            else
                MessageBox.Show("Completed!!!");
        }

        //private void DownloadButton_Click(object sender, RoutedEventArgs e)
        //{
        //    string URLAddress = @"http://files.cnblogs.com/x4646/tree.zip";

        //    string receivePath = @"C:\1\";

        //    WebClient client = new WebClient();


        //    Stream str = client.OpenRead(URLAddress);
        //    StreamReader reader = new StreamReader(str);

        //    //byte[] mbyte = new byte[1000000];
        //    //int allmybyte = (int)mbyte.Length;
        //    //int startmbyte = 0;

        //    //while (allmybyte > 0)
        //    //{

        //    //    int m = str.Read(mbyte, startmbyte, allmybyte);
        //    //    if (m == 0)
        //    //        break;

        //    //    startmbyte += m;
        //    //    allmybyte -= m;
        //    //}


        //    var wholeFileSize = 0;
        //    var maxReadByteSize = 1000000000;
        //    var wholeFileMemory = new byte[maxReadByteSize];

        //    while (true)
        //    {
        //        var readByteNumber = str.Read(wholeFileMemory, wholeFileSize, maxReadByteSize - wholeFileSize);
        //        if (readByteNumber == 0)
        //            break;

        //        wholeFileSize += readByteNumber;
        //        //if (wholeFileSize % maxReadByteSize == 0)
        //        //{
        //        //    var templist = wholeFileMemory;
        //        //    var largerMemoryList = new List<byte>(templist.Count + maxReadByteSize);
        //        //}
        //    }

        //    reader.Dispose();
        //    str.Dispose();

        //    string path = receivePath + System.IO.Path.GetFileName(URLAddress);
        //    FileStream fstr = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Write);
        //    fstr.Write(wholeFileMemory, 0, wholeFileSize);
        //    fstr.Flush();
        //    fstr.Close();
        //}
    }
}
