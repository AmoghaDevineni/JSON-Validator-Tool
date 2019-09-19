namespace WindowsFormsApp1
{
    partial class Form1
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
            this.btn_Validate = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.ColumnErrorDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Columnid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.listbox_SelectFolder = new System.Windows.Forms.ListBox();
            this.btn_Browse = new System.Windows.Forms.Button();
            this.btn_Savetothepath = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_Validate
            // 
            this.btn_Validate.Location = new System.Drawing.Point(982, 90);
            this.btn_Validate.Name = "btn_Validate";
            this.btn_Validate.Size = new System.Drawing.Size(125, 23);
            this.btn_Validate.TabIndex = 2;
            this.btn_Validate.Text = "Validate JSON";
            this.btn_Validate.UseVisualStyleBackColor = true;
            this.btn_Validate.Click += new System.EventHandler(this.btn_Validate_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnErrorDescription,
            this.Columnid});
            this.dataGridView1.Location = new System.Drawing.Point(280, 245);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGridView1.Size = new System.Drawing.Size(827, 380);
            this.dataGridView1.TabIndex = 6;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // ColumnErrorDescription
            // 
            this.ColumnErrorDescription.HeaderText = "Error Description";
            this.ColumnErrorDescription.Name = "ColumnErrorDescription";
            this.ColumnErrorDescription.Width = 600;
            // 
            // Columnid
            // 
            this.Columnid.HeaderText = "ID";
            this.Columnid.Name = "Columnid";
            this.Columnid.Width = 200;
            // 
            // listbox_SelectFolder
            // 
            this.listbox_SelectFolder.FormattingEnabled = true;
            this.listbox_SelectFolder.Location = new System.Drawing.Point(439, 68);
            this.listbox_SelectFolder.Name = "listbox_SelectFolder";
            this.listbox_SelectFolder.Size = new System.Drawing.Size(506, 69);
            this.listbox_SelectFolder.TabIndex = 12;
            this.listbox_SelectFolder.SelectedIndexChanged += new System.EventHandler(this.listbox_SelectFolder_SelectedIndexChanged);
            // 
            // btn_Browse
            // 
            this.btn_Browse.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Browse.Location = new System.Drawing.Point(280, 90);
            this.btn_Browse.Name = "btn_Browse";
            this.btn_Browse.Size = new System.Drawing.Size(115, 23);
            this.btn_Browse.TabIndex = 16;
            this.btn_Browse.Text = "Browse OSFolder";
            this.btn_Browse.UseVisualStyleBackColor = true;
            this.btn_Browse.Click += new System.EventHandler(this.btn_Browse_Click);
            // 
            // btn_Savetothepath
            // 
            this.btn_Savetothepath.Location = new System.Drawing.Point(541, 180);
            this.btn_Savetothepath.Name = "btn_Savetothepath";
            this.btn_Savetothepath.Size = new System.Drawing.Size(237, 30);
            this.btn_Savetothepath.TabIndex = 18;
            this.btn_Savetothepath.Text = "Save the log file to your desired path";
            this.btn_Savetothepath.UseVisualStyleBackColor = true;
            this.btn_Savetothepath.Click += new System.EventHandler(this.btn_Savetothepath_Click_1);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1341, 620);
            this.Controls.Add(this.btn_Savetothepath);
            this.Controls.Add(this.btn_Browse);
            this.Controls.Add(this.listbox_SelectFolder);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btn_Validate);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form1";
            this.Text = "JSON Validator";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btn_Validate;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ListBox listbox_SelectFolder;
        private System.Windows.Forms.Button btn_Browse;
        private System.Windows.Forms.Button btn_Savetothepath;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnErrorDescription;
        private System.Windows.Forms.DataGridViewTextBoxColumn Columnid;
    }
}

