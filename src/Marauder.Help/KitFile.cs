using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Marauder.Help
{
    public class KitFile
    {
        public static HttpResponseMessage FileAsAttachment(string path, string filename, string fileType)
        {
            if (File.Exists(path))
            {
                HttpResponseMessage result = new HttpResponseMessage(HttpStatusCode.OK);
                var stream = new FileStream(path, FileMode.Open);
                return SetResponseHeader(stream, filename, fileType);
            }

            return new HttpResponseMessage(HttpStatusCode.NotFound);
        }

        public static HttpResponseMessage FileAsAttachment(object obj, string filename, string fileType)
        {
            MemoryStream stream = new MemoryStream();
            StreamWriter writer = new StreamWriter(stream);
            writer.Write(JsonConvert.SerializeObject(obj));
            writer.Flush();
            stream.Position = 0;

            return SetResponseHeader(stream, filename, fileType);
        }

        private static HttpResponseMessage SetResponseHeader(Stream stream, string filename, string fileType)
        {
            HttpResponseMessage result = new HttpResponseMessage(HttpStatusCode.OK);
            result.Content = new StreamContent(stream);
            result.Content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
            result.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment");
            result.Content.Headers.ContentDisposition.FileName = filename + "." + fileType;
            return result;
        }
    }
}
