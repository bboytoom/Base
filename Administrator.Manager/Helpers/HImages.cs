using System;
using System.IO;
using System.Text.RegularExpressions;

namespace Administrator.Manager.Helpers
{
    public static class HImages
    {
        public static void ImagesSys(string imgBit, string nameImage, string pathDirectoryCustom)
        {
            string Directorywork = AppDomain.CurrentDomain.BaseDirectory;
            string PathDirectory = Directory.GetParent(Directorywork).Parent.FullName + pathDirectoryCustom;
            string PathImage = Path.Combine(PathDirectory, nameImage);

            var Base64Image = Regex.Match(imgBit, @"data:image/(?<type>.+?),(?<data>.+)").Groups["data"].Value;
            var BinData = Convert.FromBase64String(Base64Image);

            using (var ImageFile = new FileStream(PathImage, FileMode.Create))
            {
                ImageFile.Write(BinData, 0, BinData.Length);
                ImageFile.Flush();
            }
        }
    }
}
