namespace WindowsFormsApp1
{
    partial class FormMain
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
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox_MainSelect = new System.Windows.Forms.ComboBox();
            this.label_main = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(697, 346);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(168, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "Select the Interface : ";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // comboBox_MainSelect
            // 
            this.comboBox_MainSelect.FormattingEnabled = true;
            this.comboBox_MainSelect.Items.AddRange(new object[] {
            "Models",
            "OSInterfaces"});
            this.comboBox_MainSelect.Location = new System.Drawing.Point(908, 347);
            this.comboBox_MainSelect.Name = "comboBox_MainSelect";
            this.comboBox_MainSelect.Size = new System.Drawing.Size(121, 21);
            this.comboBox_MainSelect.TabIndex = 1;
            this.comboBox_MainSelect.Text = "--Select--";
            this.comboBox_MainSelect.SelectedIndexChanged += new System.EventHandler(this.comboBox_MainSelect_SelectedIndexChanged);
            // 
            // label_main
            // 
            this.label_main.AutoSize = true;
            this.label_main.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_main.Location = new System.Drawing.Point(761, 235);
            this.label_main.Name = "label_main";
            this.label_main.Size = new System.Drawing.Size(215, 31);
            this.label_main.TabIndex = 2;
            this.label_main.Text = "JSON Validator";
            this.label_main.Click += new System.EventHandler(this.label_main_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::WindowsFormsApp1.Properties.Resources.image1moda1;
            this.pictureBox1.Location = new System.Drawing.Point(418, 175);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(225, 301);
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1341, 620);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label_main);
            this.Controls.Add(this.comboBox_MainSelect);
            this.Controls.Add(this.label1);
            this.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FormMain";
            this.Text = "JSON Validator";
            this.Load += new System.EventHandler(this.FormMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox_MainSelect;
        private System.Windows.Forms.Label label_main;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}