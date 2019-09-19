using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadLogClassLibrary
{
    public static class OSUtility
    {
        public static void LogErrorMessages(List<string> errors)
        {
            TextWriter textWriter = File.CreateText("tempLog.log");
            textWriter.Write("\r\nLog Entry ");
            textWriter.WriteLine($"{DateTime.Now.ToLongTimeString()}");
            textWriter.WriteLine("---------------------------------------");
            foreach (var item in errors)
            {
                textWriter.WriteLine(item);
            }
            textWriter.Close();
        }

        public static JObject JsonReader(string path)
        {
            StreamReader file = File.OpenText(path);
            JsonTextReader reader = new JsonTextReader(file);
            return (JObject)JToken.ReadFrom(reader);
        }
    }
}
