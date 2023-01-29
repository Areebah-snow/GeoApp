using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.IO;

namespace Geolocator
{
    class Program
    {
        public static RootObject getAddress(double lat, double lon)

        {
            ///initialize the object
            WebClient webClient = new WebClient();

            webClient.Headers.Add("user-agent", "Mozilla/4.0(compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)");

            webClient.Headers.Add("Referer", "http://www.microsoft.com");

            var jsonData = webClient.DownloadData("http://nominatim.openstreetmap.org/reverse?format=json&lat=" + lat + "&lon=" + lon);

            DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(RootObject));

            RootObject rootObject = (RootObject)ser.ReadObject(new MemoryStream(jsonData));

            return rootObject;

        }

        static void Main(string[] args)
        {
            RootObject rootObject = getAddress(17.461982, 78.428764);

            Console.WriteLine(rootObject.display_name);

            Console.ReadLine();
        }
    }
}
/////Json namespace contains classes for javaScript object notation. Its an open standard that is commonly used
/////for sharing data across the web. It serializes an object into string , byte , array or stream.