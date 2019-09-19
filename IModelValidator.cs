using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace ModelNewClassLibrary
{
    public interface IModelValidator
    {
        void ValidateModelProperties(JObject jObject, ref List<string> Error, string[] elements, string element = null, JArray jArray = null);
    }
    public interface IValidateModelPropertyInterface
    {
        void ValidateProperty(JObject jObject, ref List<string> Error, JArray jArray, string element = null, string check = null);
    }
}
