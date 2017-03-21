using System;
using System.IO;
using System.Reflection;
using System.Windows.Media.Imaging;

namespace SWSPET.BL.Infrastructure
{
    public class ImageFile:IFile, IDisposable
    {
        public BitmapImage LoadImage(string guidstr)
        {
            try
            {
                var uri = new Uri(ImageDirectory + "\\" + guidstr + ".jpg");
                return new BitmapImage(uri);
            }
            catch (Exception)
            {
                var uri = new Uri(ImageDirectory + "\\background.jpg");
                return new BitmapImage(uri);
                
            }

        }
        public bool Remove(Guid guid)
        {
            System.IO.File.Delete(ImageDirectory+"\\"+guid.ToString()+".jpg");
            return true;
        }

        public string ImageDirectory {
            get
            {
                var exe = Assembly.GetExecutingAssembly().Location;
                var exedir = System.IO.Path.GetDirectoryName(exe);

                var imgdir = System.IO.Path.Combine(exedir, "images");
                return imgdir;
            }
        }


      
        public Guid SaveImage(string fileAddress, BitmapImage data)
        {
            fileAddress = ImageDirectory;
            return WriteTransformedBitmapToFile<PngBitmapEncoder>(data, fileAddress);
        }

        //public void SavePhoto(string istrImagePath)
        //{
        //    //SavePhoto("http://www.google.ca/intl/en_com/images/srpr/logo1w.png");
        //    BitmapImage objImage = new BitmapImage(new Uri(istrImagePath, UriKind.RelativeOrAbsolute));

        //    objImage.DownloadCompleted += objImage_DownloadCompleted;
        //}

        //private Guid objImage_DownloadCompleted(object sender, EventArgs e)
        //{
        //    JpegBitmapEncoder encoder = new JpegBitmapEncoder();
        //    Guid photoID = System.Guid.NewGuid();
        //    String photolocation = photoID.ToString() + ".jpg";  //file name 

        //    encoder.Frames.Add(BitmapFrame.Create((BitmapImage)sender));

        //    using (var filestream = new FileStream(photolocation, FileMode.Create))
        //        encoder.Save(filestream);
        //    return photoID;
        //}





        public Guid WriteTransformedBitmapToFile<T>(BitmapSource bitmapSource, string fileName) where T : BitmapEncoder, new()
        {
            //if (string.IsNullOrEmpty(fileName) || bitmapSource == null)
            //    return false;
            Guid photoID = System.Guid.NewGuid();
            //creating frame and putting it to Frames collection of selected encoder
            var frame = BitmapFrame.Create(bitmapSource);
            var encoder = new T();
            encoder.Frames.Add(frame);
            try
            {
                fileName = fileName + "\\" + photoID.ToString() + ".jpg";
                using (var fs = new FileStream(fileName, FileMode.Create))
                {
                    encoder.Save(fs);
                }
            }
            catch (Exception e)
            {
                return photoID;
            }
            return photoID;
        }

        private BitmapImage GetBitmapImage<T>(BitmapSource bitmapSource) where T : BitmapEncoder, new()
        {
            var frame = BitmapFrame.Create(bitmapSource);
            var encoder = new T();
            encoder.Frames.Add(frame);
            var bitmapImage = new BitmapImage();
            bool isCreated;
            try
            {
                using (var ms = new MemoryStream())
                {
                    encoder.Save(ms);

                    bitmapImage.BeginInit();
                    bitmapImage.StreamSource = ms;
                    bitmapImage.EndInit();
                    isCreated = true;
                }
            }
            catch
            {
                isCreated = false;
            }
            return isCreated ? bitmapImage : null;
        }

        public void Dispose()
        {
         //   throw new NotImplementedException();
        }
    }
}
