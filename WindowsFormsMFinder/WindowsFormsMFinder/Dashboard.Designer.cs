namespace WindowsFormsMFinder
{
    partial class Dashboard
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
            this.viewLoanButton = new System.Windows.Forms.Button();
            this.viewHistoryButton = new System.Windows.Forms.Button();
            this.manageUsersButton = new System.Windows.Forms.Button();
            this.manageMachinesButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // viewLoanButton
            // 
            this.viewLoanButton.Location = new System.Drawing.Point(37, 27);
            this.viewLoanButton.Name = "viewLoanButton";
            this.viewLoanButton.Size = new System.Drawing.Size(214, 23);
            this.viewLoanButton.TabIndex = 0;
            this.viewLoanButton.Text = "View Loans";
            this.viewLoanButton.UseVisualStyleBackColor = true;
            // 
            // viewHistoryButton
            // 
            this.viewHistoryButton.Location = new System.Drawing.Point(37, 84);
            this.viewHistoryButton.Name = "viewHistoryButton";
            this.viewHistoryButton.Size = new System.Drawing.Size(214, 23);
            this.viewHistoryButton.TabIndex = 1;
            this.viewHistoryButton.Text = "View History";
            this.viewHistoryButton.UseVisualStyleBackColor = true;
            // 
            // manageUsersButton
            // 
            this.manageUsersButton.Location = new System.Drawing.Point(37, 136);
            this.manageUsersButton.Name = "manageUsersButton";
            this.manageUsersButton.Size = new System.Drawing.Size(214, 23);
            this.manageUsersButton.TabIndex = 2;
            this.manageUsersButton.Text = "Manage Users";
            this.manageUsersButton.UseVisualStyleBackColor = true;
            this.manageUsersButton.Click += new System.EventHandler(this.manageUsersButton_Click);
            // 
            // manageMachinesButton
            // 
            this.manageMachinesButton.Location = new System.Drawing.Point(37, 189);
            this.manageMachinesButton.Name = "manageMachinesButton";
            this.manageMachinesButton.Size = new System.Drawing.Size(214, 23);
            this.manageMachinesButton.TabIndex = 3;
            this.manageMachinesButton.Text = "Manage Machines";
            this.manageMachinesButton.UseVisualStyleBackColor = true;
            this.manageMachinesButton.Click += new System.EventHandler(this.manageMachinesButton_Click);
            // 
            // Dashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.manageMachinesButton);
            this.Controls.Add(this.manageUsersButton);
            this.Controls.Add(this.viewHistoryButton);
            this.Controls.Add(this.viewLoanButton);
            this.Name = "Dashboard";
            this.Text = "Dashboard";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button viewLoanButton;
        private System.Windows.Forms.Button viewHistoryButton;
        private System.Windows.Forms.Button manageUsersButton;
        private System.Windows.Forms.Button manageMachinesButton;
    }
}