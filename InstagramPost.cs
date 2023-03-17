using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace LectureExample_03_2023_Images_Enumerable
{
    public class InstagramPost
    {
        public enum PhotoFilter { Regular, Greyscale };

        PhotoFilter _filter;
        string _header;
        string _body;
        BitmapSource _picture;


        public InstagramPost(PhotoFilter filter, string header, string body, string filePath)
        {
            _filter = filter;
            _header = header;
            _body = body;

            if (filter == PhotoFilter.Greyscale)
            {
                _picture = GenerateGreyscale(GenerateImage(filePath));
            }
            else
            {
                _picture = GenerateImage(filePath);
            }
        }

        public PhotoFilter Filter { get => _filter; set => _filter = value; }
        public string Header { get => _header; set => _header = value; }
        public string Body { get => _body; set => _body = value; }
        public BitmapSource Picture { get => _picture; set => _picture = value; }



        private BitmapImage GenerateImage(string filePath)
        {
            return new BitmapImage(new Uri(filePath));
        }
        private FormatConvertedBitmap GenerateGreyscale(BitmapImage Picture)
        {
            FormatConvertedBitmap newFormatedBitmapSource = new FormatConvertedBitmap();
            newFormatedBitmapSource.BeginInit();
            newFormatedBitmapSource.Source = Picture;
            newFormatedBitmapSource.DestinationFormat = PixelFormats.Gray32Float;
            newFormatedBitmapSource.EndInit();

            return newFormatedBitmapSource;
        }
        public override string ToString()
        {
            return $"{Header}\n{Body}\n\n";
        }
    }
}
