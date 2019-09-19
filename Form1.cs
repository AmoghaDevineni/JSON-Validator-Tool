using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using Newtonsoft.Json.Linq;
using System.Text.RegularExpressions;
using ClassLibrary;
using ReadLogClassLibrary;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public string OSJsonFolder { get; set; }
        public string AbsoluteFilePath { get; set; }
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void listbox_SelectFolder_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
        private void btn_Validate_Click(object sender, EventArgs e)
        {
            // Get file name from list box selected by user
            string userSelectedFileName = listbox_SelectFolder.GetItemText(listbox_SelectFolder.SelectedItem);
            AbsoluteFilePath = OSJsonFolder +'\\'+userSelectedFileName;


            FunctionOfOSInterface();

            // Validating for error messages based on OSInterface file rules
            List<string> ErrorLogList = new List<string>(); // Hold all the error messages to be logged
            using (StreamReader streamReader = new StreamReader("tempLog.log"))
            {
                string currentLine = string.Empty;
                while ((currentLine = streamReader.ReadLine()) != null)
                {
                    ErrorLogList.Add(currentLine);
                }
            }
            
            // Clear the grid before displaying error log list
            this.dataGridView1.Rows.Clear();

            // Displaying error log list in grid
            string[] idProperties = null; // To display in grid column id
            int idOfValidatedProperty = 0; // helper variable to display id in grid as numeric data 
            for (int i = 3; (i < ErrorLogList.Count); i++)
            {
                idProperties = Regex.Split((string)ErrorLogList[i], @"\D+");
                
                foreach (string values in idProperties)
                {
                    if(!string.IsNullOrEmpty(values))
                    {
                        idOfValidatedProperty = int.Parse(values);
                    }
                }
                this.dataGridView1.Rows.Add(ErrorLogList[i], $"{idOfValidatedProperty}");
            }
            MessageBox.Show("Validated");
           
        }
        
        
        private void FunctionOfOSInterface()
        {
            // The current file json is represented as JObject for traversal of properties and values based on the files  json structure
            JObject MainObject = OSUtility.JsonReader(AbsoluteFilePath);
            List<string> errorMessages = new List<string>();
            List<int> memberIds = new List<int>();
            const string members = "members";
            const string id = "id";
            JArray membersObjArr = (JArray)MainObject[members];
            for (int j = 0; j < membersObjArr.Count(); j++)
            {
                var membersId = MainObject[members][j][id];
                memberIds.Add((int)membersId);
            }
            List<I_OSInterfaceValidator> MainRequirementList = new List<I_OSInterfaceValidator>
            {
                new OSInterfaceMainValidator(),
                new OSInterfaceFirstMemberIdValidator()
            };

            List<I_OSInterfaceValidator> MembersIdRequirementList = new List<I_OSInterfaceValidator>
            {
                new OSInterfaceMemberSequenceIdValidator(),
                new OSInterfaceMemberUniqueIdValidator()
            };
            List<I_OSInterfaceValidator> MembersRequirementsList = new List<I_OSInterfaceValidator>
            {
                new OSInterfaceMembersAllValidator(),
                new OSInterfaceMemberPropsValidator(),
                new OSInterfaceMembersIdEdcIdValidator(),
                new OSInterfaceMembersNameValidator()
            };
            foreach (var item in MainRequirementList)
            {
                item.ValidateOSInterface(MainObject, ref errorMessages, null);
            }
            foreach (var item in MembersIdRequirementList)
            {
                item.ValidateOSInterface(MainObject, ref errorMessages, memberIds);
            }
            for (int i = 0; i < membersObjArr.Count(); i++) //loop to iterate through all the elements of members array
            {
                JObject membersDictionary = (JObject)membersObjArr[i];
                foreach (var item in MembersRequirementsList)
                {
                    item.ValidateOSInterface(membersDictionary, ref errorMessages, null);
                }
            }
            OSUtility.LogErrorMessages(errorMessages);

        }

        

        private void listbox_viewlogfile_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btn_Browse_Click(object sender, EventArgs e)
        {
            int count = 0;
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                listbox_SelectFolder.Items.Clear();
                string[] file = Directory.GetFiles(folderBrowserDialog.SelectedPath);
                // string[] dirs = Directory.GetDirectories(folderBrowserDialog.SelectedPath);
                OSJsonFolder = folderBrowserDialog.SelectedPath;
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
            if (count == 0)
                {
                    MessageBox.Show("Select an appropriate folder");
                }

            }

            private void combobox_browse_SelectedIndexChanged(object sender, EventArgs e)
            {

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
                        using (StreamReader streamReader = new StreamReader("log.log"))
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
        
            private void combobox_browse_SelectedIndexChanged_1(object sender, EventArgs e)
            {
                //getvalue = combobox_browse.SelectedItem.ToString();
            }

        private void btn_Savetothepath_Click_1(object sender, EventArgs e)
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

        private void lbl_Select_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}

