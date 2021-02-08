using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;

namespace MarketMVC.Services
{
    public static class SaveImageToDatabase
    {
        public static byte[] UseMe(HttpPostedFileBase imageIn)
        {
            using (Stream inputStream = imageIn.InputStream)
            {
                MemoryStream memoryStream = inputStream as MemoryStream;
                if (memoryStream == null)
                {
                    memoryStream = new MemoryStream();
                    inputStream.CopyTo(memoryStream);
                }
                byte[] data = memoryStream.ToArray();
                return data;
            }
        }
    }
}