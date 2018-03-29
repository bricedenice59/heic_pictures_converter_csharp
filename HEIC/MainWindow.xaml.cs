using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
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
using HEIC.Properties;
using HEIC.Utils;
using Microsoft.SqlServer.Server;

namespace HEIC
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Convert();
        }

        private void Convert()
        {
            try
            {
                List<HEICFile> files = new List<HEICFile>();
                files.Add(new HEICFile(@"C:\Users\Brice\Documents\Visual Studio 2015\Projects\HEIC\HEIC\IMG_4453.HEIC"));

                foreach (var file in files)
                {
                    file.ExtractThumbnail();
                }

                HEICFile.ConvertFiles(files.ToList(), @"C:\Users\Brice\Documents\Visual Studio 2015\Projects\HEIC\HEIC", Converter.OutputFormat.JPEG, 95, false, delegate (double progress, string message)
                {

                }, delegate (string error)
                {

                    //new Alert("Conversion Failed", error, "OK", null).Show(this, null);
                }, delegate (bool success)
                {
                    if (success)
                    {

                    }
                });
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
