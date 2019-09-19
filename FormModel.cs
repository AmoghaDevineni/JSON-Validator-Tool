using ModelNewClassLibrary;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ReadLogClassLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class FormModel : Form
    {
        public string ModelPath { get; set; }
        public string ModelFilePath { get; set; }
        public string OSPath { get; set; }
        public string OSFilePath { get; set; }
         public string ModelFileName { get; set; }
        public string OSFileName{ get; set; }

    public FormModel()
        {
            InitializeComponent();
        }

        private void btn_Browse_Click(object sender, EventArgs e)
        {
            int count = 0;
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                listbox_SelectFolder.Items.Clear();
                string[] file = Directory.GetFiles(folderBrowserDialog.SelectedPath);
                //string[] dirs = Directory.GetDirectories(folderBrowserDialog.SelectedPath);
               ModelPath = folderBrowserDialog.SelectedPath;
                //MessageBox.Show(getpath);
                foreach (var item in file)
                {

                    if (Path.GetExtension(item) == ".json")
                    {
                        listbox_SelectFolder.Items.Add(Path.GetFileName(item));
                        count++;
                    }
                }
            }
            if(count==0)
            {
                MessageBox.Show("Select an appropriate folder");
            }
        }

        private void btn_Validate_Click(object sender, EventArgs e)
        {
            List<string> listarraymodel = new List<string>();
             ModelFileName = listbox_SelectFolder.GetItemText(listbox_SelectFolder.SelectedItem);
             OSFileName = listBox_SelectOSInterfaces.GetItemText(listBox_SelectOSInterfaces.SelectedItem);
            ModelFilePath = ModelPath + @"\" + ModelFileName;
            OSFilePath = OSPath + @"\" + OSFileName;
            FunctionOfModelInterface();
            //listbox_viewlogfile.Items.Clear();
            using (StreamReader streamReader = new StreamReader("tempLog.log"))
            {
                string line;
                while ((line = streamReader.ReadLine()) != null)
                {
                    listarraymodel.Add(line);
                    //listbox_viewlogfile.Items.Add(line);
                }
            }
            this.dataGridViewModel.Rows.Clear();
            for (int i = 3; i < listarraymodel.Count; i++)
            {
                var numreg = new Regex("'.*?'");
                var matches = numreg.Matches((string)listarraymodel[i]);
               foreach (var values in matches)
                {
                    this.dataGridViewModel.Rows.Add(listarraymodel[i], values.ToString());
                }
                
            }
            MessageBox.Show("Validated");
           
        }
        

        //Model
        private void FunctionOfModelInterface()
        { 
            string filename = ModelFilePath;
            string OSfile = OSFilePath;
            List<string> ErrorMessages = new List<string>();
            JObject MainObject = OSUtility.JsonReader(filename);
            ModelValidator modelFile = new ModelValidator();
            // Checking for main json of DcsPlus.APL.FP.Control.PIDConL.Home.json file
            modelFile.FullFile_Check(ref ErrorMessages, MainObject);

            // Checking for FaceplateFacetTypeName
            modelFile.FaceplateFacetTypeName_Check(ref ErrorMessages, filename, MainObject);

            // Checking for FaceplateFacetTypeInstance
            JObject FaceplateFacetTypeInstance = (JObject)MainObject["FaceplateFacetTypeInstance"];
            modelFile.FaceplateFacetTypeInstance_Check(ref ErrorMessages, MainObject, FaceplateFacetTypeInstance);

            // Checking for FaceplateFacetType
            JObject FaceplateFacetType = (JObject)MainObject["FaceplateFacetType"];
            JObject FaceplateFacetTypePropertyInterface = (JObject)MainObject["FaceplateFacetTypePropertyInterface"];
            JArray PropertyInterface = (JArray)FaceplateFacetTypePropertyInterface["PropertyInterface"];
            modelFile.FaceplateFacetType_Check(ref ErrorMessages, FaceplateFacetType, PropertyInterface);

            // Checking for FaceplateFacetTypePropertyInterface
            modelFile.CompareFaceplateFacetTypeProperty(ref ErrorMessages, OSUtility.JsonReader(OSfile), PropertyInterface); //Check if all Property Interface elements are present in the particular OS interface.  

            OSUtility.LogErrorMessages(ErrorMessages);

        }
        

        private void btn_Savetothepath_Click(object sender, EventArgs e)
        {
            // FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                using (Stream stream = File.Open(saveFileDialog.FileName, FileMode.CreateNew))
                using (StreamWriter streamwriter = new StreamWriter(stream))
                {
                    using (StreamReader streamReader = new StreamReader("tempLog.log"))
                    {
                        string line;
                        while ((line = streamReader.ReadLine()) != null)
                        {
                            streamwriter.WriteLine(line);
                        }
                    }
                }
            }
        }

        private void listbox_viewlogfile_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btn_SelectOSInterfaces_Click(object sender, EventArgs e)
        {
           int count=0;
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                listBox_SelectOSInterfaces.Items.Clear();
                string[] file = Directory.GetFiles(folderBrowserDialog.SelectedPath);
                //string[] dirs = Directory.GetDirectories(folderBrowserDialog.SelectedPath);
                OSPath = folderBrowserDialog.SelectedPath;
                //MessageBox.Show(getpath);
                foreach (var item in file)
                {

                    if (Path.GetExtension(item) == ".json")
                    {
                        listBox_SelectOSInterfaces.Items.Add(Path.GetFileName(item));
                        count++;
                    }
                }
            }
            if (count == 0)
            {
                MessageBox.Show("Select an appropriate folder");
            }
        }

        private void btn_viewlogfileboth_Click(object sender, EventArgs e)
        {
            using (StreamReader streamReader = new StreamReader("tempLog.log"))
            {
                string line;
                while ((line = streamReader.ReadLine()) != null)
                {
                    //listbox_viewlogfile.Items.Add(line);
                }
            }
        }

        private void listbox_SelectFolder_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dataGridViewModel_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void FormModel_Load(object sender, EventArgs e)
        {

        }

        private void listBox_SelectOSInterfaces_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
