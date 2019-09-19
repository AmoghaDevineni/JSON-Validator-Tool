using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;

namespace ModelNewClassLibrary
{
    class ModelMainValidator : IModelValidator
    {
        public void ValidateModelProperties(JObject jObject, ref List<string> Error, string[] elements, string element = null, JArray jArray = null)
        {
            if (!jObject.ContainsKey(element))
                Error.Add("'" + element + "' is not present in the file");
        }
    }
    class ModelFacetTypeNameValidator : IModelValidator
    {
        public void ValidateModelProperties(JObject jObject, ref List<string> Error, string[] elements, string element = null, JArray jArray = null)
        {
            if (!((dynamic)jObject[elements[0]] == elements[1]))
                Error.Add("The 'FaceplateFacetTypeName' value is not same as the Json filename");
        }
    }
    class ModelFacetTypeInstanceValidator : IModelValidator
    {
        public void ValidateModelProperties(JObject jObject, ref List<string> Error, string[] elements, string element = null, JArray jArray = null)
        {
            if (!((dynamic)jObject[elements[0]] == elements[1]))
                Error.Add("'FaceplateFacetTypeInstance' -> props -> ContainedType value is not as same as FaceplateFacetTypeName");
        }
    }
    class ModelFacetTypeMainValidator : IModelValidator
    {
        public void ValidateModelProperties(JObject jObject, ref List<string> Error, string[] elements, string element = null, JArray jArray = null)
        {
            for (int i = 0; i < elements.Length; i++)
            {
                if (!jObject.ContainsKey(elements[i]))
                    Error.Add("'" + elements[i] + "' is not present in FaceplateFacetType");
            }
        }
    }
    class ModelFacetTypeChildElementsValidator : IModelValidator
    {
        public void ValidateModelProperties(JObject jObject, ref List<string> Error, string[] elements, string element = null, JArray jArray = null)
        {
            if (!(jObject.ContainsKey(elements[0]) && jObject.ContainsKey(elements[1])))// To check if all child objects of "elements" have "id" and "type" variables.                    
                Error.Add("The id or type is not present for '" + element + "'");
        }
    }
    class ModelFacetTypeElementNameValidator : IModelValidator
    {
        public void ValidateModelProperties(JObject jObject, ref List<string> Error, string[] elements, string element = null, JArray jArray = null)
        {
            const string id = "id";
            var count = 0;
            foreach (var child in elements)
            {
                if (element == (dynamic)child)
                    count++;
            }
            if (!((dynamic)jObject[id] == element))// To check if the "id" variable and name of the child objects of "elements" are same.                    
                Error.Add("The id value and the name of the element is not same for '" + element + "'");
            if (count > 1)
                Error.Add("The '" + element + "' is not unique");
        }
    }
    class ModelFacetTypeElementStatusBarPosValidator : IModelValidator
    {
        public void ValidateModelProperties(JObject jObject, ref List<string> Error, string[] elements, string element = null, JArray jArray = null)
        {
            if (!jObject.ContainsKey(elements[2])) //To check if "statusBarPos" is present in child objects of "elements".
            {
                if (!jObject.ContainsKey(elements[3]))//To check if "layout" is present if "statusBarPos" is not present in the child objects.                         
                    Error.Add("Both statusBarPos and Layout elements are not present for '" + element + "'");
            }
        }
    }
    class ModelFacetTypeElementDisplayLogicValidator : IModelValidator
    {
        public void ValidateModelProperties(JObject jObject, ref List<string> Error, string[] elements, string element = null, JArray jArray = null)
        {
            const string displayLogic_tag = "tag";
            JArray propInfoBinding = (JArray)jObject[elements[5]];
            if (jObject.ContainsKey(elements[4]))//To check if the "tag"s of "displayLogic" are present in "propInfoBinding" uniquely.
            {
                if (jObject[elements[4]].GetType() == typeof(JArray))
                {
                    JArray displayLogic = (JArray)jObject[elements[4]];
                    foreach (var displayelement in displayLogic)
                    {
                        if (displayelement.GetType() == typeof(JObject))
                        {
                            JObject displayelements = (JObject)displayelement;
                            if (displayelements.ContainsKey(displayLogic_tag))
                            {
                                if (displayelements[displayLogic_tag].GetType() == typeof(JArray))
                                {
                                    JArray tagelements = (JArray)displayelements[displayLogic_tag];
                                    foreach (var tagelement in tagelements)
                                    {
                                        var count = 0;
                                        foreach (var prop in propInfoBinding)
                                        {
                                            if (prop == (dynamic)tagelement)
                                                count++;
                                        }
                                        if (count > 1)
                                            Error.Add("The displayLogic tag " + tagelement + " is present in propInfoBinding but are not unique for '" + element + "'");
                                        if (count == 0)
                                            Error.Add("The displayLogic tag " + tagelement + " is not present in propInfoBinding for '" + element + "'");
                                    }
                                }
                                if (displayelements[displayLogic_tag].GetType() == typeof(JValue))
                                {
                                    var count = 0;
                                    foreach (var prop in propInfoBinding)
                                    {
                                        if (prop == (dynamic)displayelements[displayLogic_tag])
                                            count++;
                                    }
                                    if (count > 1)
                                        Error.Add("The displayLogic tag " + displayelements[displayLogic_tag] + " is present in propInfoBinding but are not unique for '" + element + "'");
                                    if (count == 0)
                                        Error.Add("The displayLogic tag " + displayelements[displayLogic_tag] + " is not present in propInfoBinding for '" + element + "'");
                                }
                            }
                        }
                    }
                }
            }
        }
    }
    class ModelFacetTypeElementPropInfoBindingValidator : IValidateModelPropertyInterface
    {
        public void ValidateProperty(JObject jObject, ref List<string> Error, JArray jArray, string element = null, string check = null)
        {
            const string PropInfoBinding = "propInfoBinding";
            JArray propInfoBinding = (JArray)jObject[PropInfoBinding];
            IEnumerable<JToken> UniquePropInfo = new List<JToken>(propInfoBinding.Distinct());
            IEnumerable<JToken> UniquePropInterface = new List<JToken>(jArray.Distinct());
            if (check == "true")
            {
                foreach (var uniqueProperty in UniquePropInterface)
                {
                    //System.Console.WriteLine(uniqueProperty);
                    int PropertyCount = 0;
                    foreach (var property in jArray)
                    {
                        if (uniqueProperty == (dynamic)property)
                            PropertyCount++;
                    }
                    if (PropertyCount > 1)
                        Error.Add("Property Interface elements are not unique for '" + uniqueProperty + "'");
                }
            }

            foreach (var uniquePropInfo in UniquePropInfo)
            {

                if (propInfoBinding.Count != 0)
                {
                    int count = 0;
                    foreach (dynamic prop in propInfoBinding)
                    {
                        int flag = 0;
                        if (prop == uniquePropInfo)
                            count++;
                        if (count > 1)
                            Error.Add("propInfoBinding elements are not unique for '" + element + "'");

                        foreach (var property in UniquePropInterface)
                        {
                            if (prop == property)
                            {
                                flag = 1;
                                break;
                            }
                        }
                        if (flag == 0)
                            Error.Add("propInfoBinding element " + prop + " for the Elements object '" + element + "' is not present in PropertyInterface");
                    }
                }
            }
        }
    }
    class ModelFacetTypeElementInstanceSpecificValidator : IModelValidator
    {
        public void ValidateModelProperties(JObject jObject, ref List<string> Error, string[] elements, string element = null, JArray jArray = null)
        {
            const string instanceSpecific = "instanceSpecific";
            JArray propInfoBinding = (JArray)jObject[elements[5]];
            bool check_InstanceSpecific = false, check_InstanceSpecificValues = false;
            var subelement_element = "null";
            foreach (var subelement in jObject)//To check if instanceSpecific is present and if present check if propInfoBinding contains InstanceSpecificValues
            {
                if (subelement.Value.GetType() == typeof(JObject))
                {
                    JObject subelements = (JObject)subelement.Value;
                    subelement_element = subelement.Key;
                    if (subelements.ContainsKey(instanceSpecific))
                        check_InstanceSpecific = true;
                }
                if (subelement.Value.GetType() == typeof(JArray))
                {
                    JArray subArray = (JArray)subelement.Value;
                    foreach (var arr in subArray)
                    {
                        if (arr.GetType() == typeof(JObject))
                        {
                            JObject temp = (JObject)arr;
                            subelement_element = subelement.Key;
                            if (temp.ContainsKey(instanceSpecific))
                                check_InstanceSpecific = true;
                        }
                    }
                }
                if (propInfoBinding.Count != 0)
                {
                    foreach (dynamic prop in propInfoBinding)
                    {
                        if (check_InstanceSpecific)
                        {
                            if (prop == "InstanceSpecificValues")
                                check_InstanceSpecificValues = true;
                        }
                    }
                }
            }
            if ((check_InstanceSpecificValues ^ check_InstanceSpecific) && (check_InstanceSpecific == true && check_InstanceSpecificValues == false))
                Error.Add("InstanceSpecific is present in '" + element + "' -> " + subelement_element + " but not present in propInfoBinding");
        }
    }
    class ModelFacetTypeElementImagesTooltipTextValidator : IModelValidator
    {
        public void ValidateModelProperties(JObject jObject, ref List<string> Error, string[] elements, string element = null, JArray jArray = null)
        {
            if (jObject.ContainsKey(elements[6]))// To check if "images" and "tooltipText/text" array is present, if present and size greater than 1 then both sizes should be same.
            {
                if (jObject[elements[6]].GetType() == typeof(JArray))
                {
                    JArray images = (JArray)jObject[elements[6]];
                    if (jObject.ContainsKey(elements[7]))
                    {
                        if (jObject[elements[7]].GetType() == typeof(JArray))
                        {
                            JArray tooltipText = (JArray)jObject[elements[7]];
                            if ((images.Count > 1 && tooltipText.Count > 1))
                            {
                                if (!(images.Count == tooltipText.Count))
                                    Error.Add("The size of images and tooltipText is not same for '" + element + "'");
                            }
                        }
                    }
                    if (jObject.ContainsKey(elements[8]))
                    {
                        if (jObject[elements[8]].GetType() == typeof(JArray))
                        {
                            JArray text = (JArray)jObject[elements[8]];
                            if ((images.Count > 1 && text.Count > 1))
                            {
                                if (!(images.Count == text.Count))
                                    Error.Add("The size of images and text arrays is not same for '" + element + "'");
                            }
                        }
                    }
                }
            }
        }
    }
    class ModelFacetTypeElementtooltipTextValidator : IModelValidator
    {
        public void ValidateModelProperties(JObject jObject, ref List<string> Error, string[] elements, string element = null, JArray jArray = null)
        {
            const string default_tag = "default";
            if (!(element.EndsWith("Unit")))//To check if "tooltipText/text" contains "id" and "default" except Unit elements.
            {
                if (jObject.ContainsKey(elements[7]))
                {
                    if (jObject[elements[7]].GetType() == typeof(JArray))
                    {
                        JArray tooltipText = (JArray)jObject[elements[7]];
                        foreach (var arr in tooltipText)
                        {
                            if (arr.GetType() == typeof(JObject))
                            {
                                JObject tool = (JObject)arr;
                                if (!(tool.ContainsKey(elements[0]) && tool.ContainsKey(default_tag)))
                                    Error.Add("The tooltipText element does not contain id or default for '" + element + "'");
                            }
                        }
                    }
                    if (jObject[elements[7]].GetType() == typeof(JObject))
                    {
                        JObject tool = (JObject)jObject[elements[7]];
                        if (!(tool.ContainsKey(elements[0]) && tool.ContainsKey(default_tag)))
                            Error.Add("The tooltipText element does not contain id or default for '" + element + "'");
                    }
                }
                if (jObject.ContainsKey(elements[8]))
                {
                    if (jObject[elements[8]].GetType() == typeof(JArray))
                    {
                        JArray texts = (JArray)jObject[elements[8]];
                        foreach (var arr in texts)
                        {
                            if (arr.GetType() == typeof(JObject))
                            {
                                JObject text = (JObject)arr;
                                if (!(text.ContainsKey(elements[0]) && text.ContainsKey(default_tag)))
                                    Error.Add("The text element does not contain id or default for '" + element + "'");
                            }
                        }
                    }
                    if (jObject[elements[8]].GetType() == typeof(JObject))
                    {
                        JObject text = (JObject)jObject[elements[8]];
                        if (!(text.ContainsKey(elements[0]) && text.ContainsKey(default_tag)))
                            Error.Add("The text element does not contain id or default for '" + element + "'");
                    }
                }
            }
        }
    }
    class ModelFacetTypePropertyInterfaceValidator : IValidateModelPropertyInterface
    {
        public void ValidateProperty(JObject jObject, ref List<string> Error, JArray jArray, string element = null, string check = null)
        {
            const string members = "members";
            const string name = "name";
            JArray Members = (JArray)jObject[members];
            IEnumerable<JToken> UniquePropInterface = new List<JToken>(jArray.Distinct());
            foreach (var prop in UniquePropInterface)
            {
                int flag = 0;
                foreach (var member in Members)
                {
                    JObject variables = (JObject)member;
                    if (variables[name] == (dynamic)prop)
                    {
                        flag = 1;
                        break;
                    }
                }
                if (flag == 0)
                    Error.Add("'" + prop + "' is not present in the OS file");
            }
        }
    }
}
           
        

