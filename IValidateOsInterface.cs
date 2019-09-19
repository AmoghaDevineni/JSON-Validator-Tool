using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace ClassLibrary
{
    public interface I_OSInterfaceValidator
    {
        void ValidateOSInterface(JObject jobject, ref List<string> errorMessages, List<int> memberIds);
    }
}
