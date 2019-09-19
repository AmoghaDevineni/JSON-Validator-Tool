namespace WindowsFormsApp1
{
    partial class FormModel
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btn_Savetothepath = new System.Windows.Forms.Button();
            this.btn_Browse = new System.Windows.Forms.Button();
            this.listbox_SelectFolder = new System.Windows.Forms.ListBox();
            this.btn_Validate = new System.Windows.Forms.Button();
            this.btn_SelectOSInterfaces = new System.Windows.Forms.Button();
            this.listBox_SelectOSInterfaces = new System.Windows.Forms.ListBox();
            this.dataGridViewModel = new System.Windows.Forms.DataGridView();
            this.ColumnerrorDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Columnid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewModel)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_Savetothepath
            // 
            this.btn_Savetothepath.Location = new System.Drawing.Point(514, 224);
            this.btn_Savetothepath.Name = "btn_Savetothepath";
            this.btn_Savetothepath.Size = new System.Drawing.Size(237, 30);
            this.btn_Savetothepath.TabIndex = 26;
            this.btn_Savetothepath.Text = "Save the log file to your desired path";
            this.btn_Savetothepath.UseVisualStyleBackColor = true;
            this.btn_Savetothepath.Click += new System.EventHandler(this.btn_Savetothepath_Click);
            // 
            // btn_Browse
            // 
            this.btn_Browse.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Browse.Location = new System.Drawing.Point(276, 72);
            this.btn_Browse.Name = "btn_Browse";
            this.btn_Browse.Size = new System.Drawing.Size(150, 23);
            this.btn_Browse.TabIndex = 24;
            this.btn_Browse.Text = "Browse ModelFolder";
            this.btn_Browse.UseVisualStyleBackColor = true;
            this.btn_Browse.Click += new System.EventHandler(this.btn_Browse_Click);
            // 
            // listbox_SelectFolder
            // 
            this.listbox_SelectFolder.FormattingEnabled = true;
            this.listbox_SelectFolder.Location = new System.Drawing.Point(460, 53);
            this.listbox_SelectFolder.Name = "listbox_SelectFolder";
            this.listbox_SelectFolder.Size = new System.Drawing.Size(455, 56);
            this.listbox_SelectFolder.TabIndex = 20;
            // 
            // btn_Validate
            // 
            this.btn_Validate.Location = new System.Drawing.Point(946, 112);
            this.btn_Validate.Name = "btn_Validate";
            this.btn_Validate.Size = new System.Drawing.Size(125, 23);
            this.btn_Validate.TabIndex = 19;
            this.btn_Validate.Text = "Validate JSON";
            this.btn_Validate.UseVisualStyleBackColor = true;
            this.btn_Validate.Click += new System.EventHandler(this.btn_Validate_Click);
            // 
            // btn_SelectOSInterfaces
            // 
            this.btn_SelectOSInterfaces.Location = new System.Drawing.Point(276, 153);
            this.btn_SelectOSInterfaces.Name = "btn_SelectOSInterfaces";
            this.btn_SelectOSInterfaces.Size = new System.Drawing.Size(150, 23);
            this.btn_SelectOSInterfaces.TabIndex = 27;
            this.btn_SelectOSInterfaces.Text = "Browse OSFolder";
            this.btn_SelectOSInterfaces.UseVisualStyleBackColor = true;
            this.btn_SelectOSInterfaces.Click += new System.EventHandler(this.btn_SelectOSInterfaces_Click);
            // 
            // listBox_SelectOSInterfaces
            // 
            this.listBox_SelectOSInterfaces.FormattingEnabled = true;
            this.listBox_SelectOSInterfaces.Location = new System.Drawing.Point(460, 141);
            this.listBox_SelectOSInterfaces.Name = "listBox_SelectOSInterfaces";
            this.listBox_SelectOSInterfaces.Size = new System.Drawing.Size(455, 56);
            this.listBox_SelectOSInterfaces.TabIndex = 28;
            // 
            // dataGridViewModel
            // 
            this.dataGridViewModel.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewModel.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnerrorDescription,
            this.Columnid});
            this.dataGridViewModel.Location = new System.Drawing.Point(233, 290);
            this.dataGridViewModel.Name = "dataGridViewModel";
            this.dataGridViewModel.Size = new System.Drawing.Size(838, 318);
            this.dataGridViewModel.TabIndex = 29;
            // 
            // ColumnerrorDescription
            // 
            this.ColumnerrorDescription.HeaderText = "ErrorDescription";
            this.ColumnerrorDescription.Name = "ColumnerrorDescription";
            this.ColumnerrorDescription.Width = 600;
            // 
            // Columnid
            // 
            this.Columnid.HeaderText = "ID";
            this.Columnid.Name = "Columnid";
            this.Columnid.Width = 200;
            // 
            // FormModel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1341, 632);
            this.Controls.Add(this.dataGridViewModel);
            this.Controls.Add(this.listBox_SelectOSInterfaces);
            this.Controls.Add(this.btn_SelectOSInterfaces);
            this.Controls.Add(this.btn_Savetothepath);
            this.Controls.Add(this.btn_Browse);
            this.Controls.Add(this.listbox_SelectFolder);
            this.Controls.Add(this.btn_Validate);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FormModel";
            this.Text = "JSON Validator";
            this.Load += new System.EventHandler(this.FormModel_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewModel)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_Savetothepath;
        private System.Windows.Forms.Button btn_Browse;
        private System.Windows.Forms.ListBox listbox_SelectFolder;
        private System.Windows.Forms.Button btn_Validate;
        private System.Windows.Forms.Button btn_SelectOSInterfaces;
        private System.Windows.Forms.ListBox listBox_SelectOSInterfaces;
        private System.Windows.Forms.DataGridView dataGridViewModel;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnerrorDescription;
        private System.Windows.Forms.DataGridViewTextBoxColumn Columnid;
    }
}