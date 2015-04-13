namespace WindowsFormsMFinder
{
    partial class EditUser
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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxFirstName = new System.Windows.Forms.TextBox();
            this.textBoxLastName = new System.Windows.Forms.TextBox();
            this.textBoxRamal = new System.Windows.Forms.TextBox();
            this.comboBoxDptos = new System.Windows.Forms.ComboBox();
            this.comboBoxRoles = new System.Windows.Forms.ComboBox();
            this.buttonSave = new System.Windows.Forms.Button();
            this.bindingSourceRoles = new System.Windows.Forms.BindingSource(this.components);
            this.bindingSourceDptos = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceRoles)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceDptos)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(66, 83);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "First Name:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(66, 125);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Last Name:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(66, 201);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Departament:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(66, 163);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Ramal:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(66, 243);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(32, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Role:";
            // 
            // textBoxFirstName
            // 
            this.textBoxFirstName.Location = new System.Drawing.Point(213, 75);
            this.textBoxFirstName.Name = "textBoxFirstName";
            this.textBoxFirstName.Size = new System.Drawing.Size(121, 20);
            this.textBoxFirstName.TabIndex = 5;
            // 
            // textBoxLastName
            // 
            this.textBoxLastName.Location = new System.Drawing.Point(213, 118);
            this.textBoxLastName.Name = "textBoxLastName";
            this.textBoxLastName.Size = new System.Drawing.Size(121, 20);
            this.textBoxLastName.TabIndex = 6;
            // 
            // textBoxRamal
            // 
            this.textBoxRamal.Location = new System.Drawing.Point(213, 160);
            this.textBoxRamal.Name = "textBoxRamal";
            this.textBoxRamal.Size = new System.Drawing.Size(121, 20);
            this.textBoxRamal.TabIndex = 7;
            // 
            // comboBoxDptos
            // 
            this.comboBoxDptos.FormattingEnabled = true;
            this.comboBoxDptos.Location = new System.Drawing.Point(213, 201);
            this.comboBoxDptos.Name = "comboBoxDptos";
            this.comboBoxDptos.Size = new System.Drawing.Size(121, 21);
            this.comboBoxDptos.TabIndex = 8;
            // 
            // comboBoxRoles
            // 
            this.comboBoxRoles.FormattingEnabled = true;
            this.comboBoxRoles.Location = new System.Drawing.Point(213, 243);
            this.comboBoxRoles.Name = "comboBoxRoles";
            this.comboBoxRoles.Size = new System.Drawing.Size(121, 21);
            this.comboBoxRoles.TabIndex = 9;
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(258, 305);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(75, 23);
            this.buttonSave.TabIndex = 10;
            this.buttonSave.Text = "Save";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // EditUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(386, 474);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.comboBoxRoles);
            this.Controls.Add(this.comboBoxDptos);
            this.Controls.Add(this.textBoxRamal);
            this.Controls.Add(this.textBoxLastName);
            this.Controls.Add(this.textBoxFirstName);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "EditUser";
            this.Text = "EditUser";
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceRoles)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceDptos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxFirstName;
        private System.Windows.Forms.TextBox textBoxLastName;
        private System.Windows.Forms.TextBox textBoxRamal;
        private System.Windows.Forms.ComboBox comboBoxDptos;
        private System.Windows.Forms.ComboBox comboBoxRoles;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.BindingSource bindingSourceRoles;
        private System.Windows.Forms.BindingSource bindingSourceDptos;
    }
}