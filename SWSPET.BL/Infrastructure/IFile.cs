using System;
using System.Windows.Media.Imaging;

namespace SWSPET.BL.Infrastructure
{
    interface IFile
    {
        BitmapImage LoadImage(String guidstr);
        Guid SaveImage(string fileAddress, BitmapImage data);
    }
}
