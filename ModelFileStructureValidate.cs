using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ModelNewClassLibrary
{
    public class ModelValidator 
    {
        public void CompareFaceplateFacetTypeProperty(ref List<string> Error, JObject OSfile, JArray PropertyInterface)
        {
            JObject MainOSobject = OSfile;
            IValidateModelPropertyInterface modelPIObj = new ModelFacetTypePropertyInterfaceValidator();
            modelPIObj.ValidateProperty(MainOSobject, ref Error, PropertyInterface);
        }

        public void FaceplateFacetType_Check(ref List<string> Error, JObject FaceplateFacetType, JArray PropertyInterface)
        {
            string[] FaceplateFacetTypeArray = { "elements", "type", "blockType", "viewType", "panelType", "id", "version", "layout" };
            string[] FaceplateFacetType_elementsArray = { "id", "type", "statusBarPos", "layout", "displayLogic", "propInfoBinding", "images", "tooltipText", "text" };
            string checking = "true";
            IModelValidator r4 = new ModelFacetTypeMainValidator();
            r4.ValidateModelProperties(FaceplateFacetType, ref Error, FaceplateFacetTypeArray);

            JObject FaceplateFacetType_elements = (JObject)FaceplateFacetType[FaceplateFacetTypeArray[0]];

            string[] ChildElements = ((IDictionary<string, JToken>)FaceplateFacetType_elements).Keys.ToArray();

            List<IModelValidator> ElementWise_CheckList = new List<IModelValidator>
            {
                new ModelFacetTypeChildElementsValidator(),
                new ModelFacetTypeElementStatusBarPosValidator()
            };

            List<IModelValidator> InnerElement_CheckList = new List<IModelValidator>
            {
                new ModelFacetTypeElementDisplayLogicValidator(),
                new ModelFacetTypeElementInstanceSpecificValidator(),
                new ModelFacetTypeElementImagesTooltipTextValidator(),
                new ModelFacetTypeElementtooltipTextValidator()
            };

            foreach (var element in FaceplateFacetType_elements)
            {
                try
                {
                    JObject elements = (JObject)element.Value;
                    foreach (var check in ElementWise_CheckList)
                    {
                        check.ValidateModelProperties(elements, ref Error, FaceplateFacetType_elementsArray, element.Key);
                    }

                    IModelValidator obj = new ModelFacetTypeElementNameValidator();
                    obj.ValidateModelProperties(elements, ref Error, ChildElements, element.Key);

                    if (elements.ContainsKey(FaceplateFacetType_elementsArray[5]))//To check "propInfoBinding" contents are present in the FaceplateFacetTypePropertyInterface and are unique.
                    {
                        if (elements[FaceplateFacetType_elementsArray[5]].GetType() == typeof(JArray))
                        {
                            foreach (var check in InnerElement_CheckList)
                            {
                                check.ValidateModelProperties(elements, ref Error, FaceplateFacetType_elementsArray, element.Key);
                            }

                            IValidateModelPropertyInterface r9 = new ModelFacetTypeElementPropInfoBindingValidator();
                            r9.ValidateProperty(elements, ref Error, PropertyInterface, element.Key, checking);
                            checking = "false";
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }
        }

        public void FaceplateFacetTypeInstance_Check(ref List<string> Error, JObject MainObject, JObject FaceplateFacetTypeInstance)
        {
            const string FaceplateFacetTypeName = "FaceplateFacetTypeName";
            const string props = "props";
            string[] tagNames = { "ContainedType", (dynamic)MainObject[FaceplateFacetTypeName] };
            JObject FaceplateFacetTypeInstance_props = (JObject)FaceplateFacetTypeInstance[props];
            IModelValidator r3 = new ModelFacetTypeInstanceValidator();
            r3.ValidateModelProperties(FaceplateFacetTypeInstance_props, ref Error, tagNames);
        }

        public void FaceplateFacetTypeName_Check(ref List<string> Error, string filename, JObject MainObject)
        {
            string[] temp = { "FaceplateFacetTypeName", Path.GetFileNameWithoutExtension(filename) };
            IModelValidator r2 = new ModelFacetTypeNameValidator();
            r2.ValidateModelProperties(MainObject, ref Error, temp);
        }

        public void FullFile_Check(ref List<string> Error, JObject MainObject)
        {
            string[] MainPropsOfFile = { "FaceplateFacetTypeName", "FaceplateFacetTypeInstance", "FaceplateFacetType", "FaceplateFacetTypeVariant", "FaceplateFacetTypePropertyInterface" };
            IModelValidator r1 = new ModelMainValidator();
            for (int i = 0; i < MainPropsOfFile.Count(); i++)
            {
                r1.ValidateModelProperties(MainObject, ref Error, null, MainPropsOfFile[i]);
            }
        }
    }
}
