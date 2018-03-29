using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading;
using System.Windows;
using System.Windows.Media;
using System.Windows.Threading;

namespace HEIC.Utils
{
    public class HEICFile : INotifyPropertyChanged
    {
        public string Path { get; private set; }

        public string Name { get; private set; }

        public ImageSource Icon { get; private set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public static bool IsHEICFile(string path)
        {
            try
            {
                new File(new Path(path));
                return true;
            }
            catch
            {
            }

            return false;
        }

        public void Convert(string outPath, string outFileName, Converter.OutputFormat format, uint quality, bool keepEXIF, 
            Action<double, string> progressCallback, Action<string> errorCallback,Action<bool> endCallback)
        {

                Exception e;
                new System.Threading.Tasks.Task(delegate
                {
                    bool success = false;

                    HEICFile hEICFile = this;
                    Converter converter = new Converter();

                    try
                    {
                        string finalOutFilePath = System.IO.Path.Combine(outPath, outFileName);
                        converter.Convert(new Path(Path), new Path(finalOutFilePath), format, quality, keepEXIF);
                        success = true;
                    }
                    catch (Exception ex)
                    {
                        Exception ex2 = e = ex;
                        if (errorCallback != null)
                        {
                            Application.Current.Dispatcher.BeginInvoke((Action) delegate { errorCallback(e.Message); });
                        }
                    }

                    if (endCallback != null)
                    {
                        Application.Current.Dispatcher.BeginInvoke((Action) delegate { endCallback(success); });
                    }
                }).Start();
        }

        private static string UniqueFilename(string name, string ext, string dir)
        {
            string text = System.IO.Path.Combine(dir, name + "." + ext);
            uint num = 1u;
            while (System.IO.File.Exists(text))
            {
                text = System.IO.Path.Combine(dir, name + "-" + num++ + "." + ext);
            }

            return text;
        }

        public HEICFile(string path)
        {
            new File(new Path(path));
            Path = path;
            Name = System.IO.Path.GetFileName(path);
        }

        private void OnPropertyChanged(string name)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public void ExtractThumbnail()
        {
            Dispatcher currentDispatcher = Dispatcher.CurrentDispatcher;
            ThreadPool.QueueUserWorkItem(delegate
            {
                HEICFile hEICFile = this;
                string tempFileName = System.IO.Path.GetTempFileName();
                Converter converter = new Converter();
                try
                {
                    converter.ExtractThumbnail(new Path(Path), new Path(tempFileName), Converter.OutputFormat.JPEG, 100u);
                    System.Windows.Media.Imaging.BitmapImage image = new System.Windows.Media.Imaging.BitmapImage(new Uri(tempFileName));
                    image.Freeze();
                    if (image != null)
                    {
                        Application.Current.Dispatcher.BeginInvoke((Action) delegate
                        {
                            hEICFile.Icon = image;
                            hEICFile.OnPropertyChanged("Icon");
                        });
                    }
                }
                catch
                {
                }
            });
        }
    }
}