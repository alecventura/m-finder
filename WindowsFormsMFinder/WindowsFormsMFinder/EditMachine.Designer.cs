namespace WindowsFormsMFinder
{
    partial class EditMachine
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
            this.buttonSave = new System.Windows.Forms.Button();
            this.textBoxSerialNumber = new System.Windows.Forms.TextBox();
            this.textBoxModel = new System.Windows.Forms.TextBox();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dateTimePickerAquisition = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerWarrantExpiration = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(261, 308);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(75, 23);
            this.buttonSave.TabIndex = 19;
            this.buttonSave.Text = "Save";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // textBoxSerialNumber
            // 
            this.textBoxSerialNumber.Location = new System.Drawing.Point(216, 163);
            this.textBoxSerialNumber.Name = "textBoxSerialNumber";
            this.textBoxSerialNumber.Size = new System.Drawing.Size(121, 20);
            this.textBoxSerialNumber.TabIndex = 18;
            // 
            // textBoxModel
            // 
            this.textBoxModel.Location = new System.Drawing.Point(216, 121);
            this.textBoxModel.Name = "textBoxModel";
            this.textBoxModel.Size = new System.Drawing.Size(121, 20);
            this.textBoxModel.TabIndex = 17;
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(216, 78);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(121, 20);
            this.textBoxName.TabIndex = 16;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(69, 246);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(128, 13);
            this.label5.TabIndex = 15;
            this.label5.Text = "Warranty Expiration Date:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(69, 204);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 13);
            this.label3.TabIndex = 14;
            this.label3.Text = "Aquisition Date:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(69, 166);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "SerialNumber:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(69, 128);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Model:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(69, 86);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Name:";
            // 
            // dateTimePickerAquisition
            // 
            this.dateTimePickerAquisition.CustomFormat = "dd-MM-yyyy";
            this.dateTimePickerAquisition.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerAquisition.Location = new System.Drawing.Point(216, 204);
            this.dateTimePickerAquisition.Name = "dateTimePickerAquisition";
            this.dateTimePickerAquisition.Size = new System.Drawing.Size(121, 20);
            this.dateTimePickerAquisition.TabIndex = 20;
            // 
            // dateTimePickerWarrantExpiration
            // 
            this.dateTimePickerWarrantExpiration.CustomFormat = "dd-MM-yyyy";
            this.dateTimePickerWarrantExpiration.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerWarrantExpiration.Location = new System.Drawing.Point(216, 246);
            this.dateTimePickerWarrantExpiration.Name = "dateTimePickerWarrantExpiration";
            this.dateTimePickerWarrantExpiration.Size = new System.Drawing.Size(121, 20);
            this.dateTimePickerWarrantExpiration.TabIndex = 21;
            // 
            // EditMachine
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(387, 477);
            this.Controls.Add(this.dateTimePickerWarrantExpiration);
            this.Controls.Add(this.dateTimePickerAquisition);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.textBoxSerialNumber);
            this.Controls.Add(this.textBoxModel);
            this.Controls.Add(this.textBoxName);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "EditMachine";
            this.Text = "EditMachine";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.TextBox textBoxSerialNumber;
        private System.Windows.Forms.TextBox textBoxModel;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dateTimePickerAquisition;
        private System.Windows.Forms.DateTimePicker dateTimePickerWarrantExpiration;

    }
}