using System;
using System.Windows.Forms;

namespace windowsAppEx2
{
    partial class Form2
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.TextBox idTextBox;
        private System.Windows.Forms.TextBox streetTextBox;
        private System.Windows.Forms.TextBox cityTextBox;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.TextBox displayTextBox;

        private Label nameLabel;
        private Label idLabel;
        private Label streetLabel;
        private Label cityLabel;

        private Button deepCopyButton;
        private Button shallowCopyButton;
        private Button clearButton;
        private Button refreshButton;

        private Employee originalEmployee; // Ajout d'une variable pour stocker l'employé d'origine

        private void InitializeComponent()
        {
            this.deepCopyButton = new System.Windows.Forms.Button();
            this.shallowCopyButton = new System.Windows.Forms.Button();
            this.clearButton = new System.Windows.Forms.Button();
            this.refreshButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // deepCopyButton
            // 
            this.deepCopyButton.Location = new System.Drawing.Point(50, 270);
            this.deepCopyButton.Name = "deepCopyButton";
            this.deepCopyButton.Size = new System.Drawing.Size(100, 30);
            this.deepCopyButton.TabIndex = 0;
            this.deepCopyButton.Text = "Deep Copy";
            this.deepCopyButton.Click += new System.EventHandler(this.deepCopyButton_Click);
            // 
            // shallowCopyButton
            // 
            this.shallowCopyButton.Location = new System.Drawing.Point(160, 270);
            this.shallowCopyButton.Name = "shallowCopyButton";
            this.shallowCopyButton.Size = new System.Drawing.Size(100, 30);
            this.shallowCopyButton.TabIndex = 1;
            this.shallowCopyButton.Text = "Shallow Copy";
            this.shallowCopyButton.Click += new System.EventHandler(this.shallowCopyButton_Click);
            // 
            // clearButton
            // 
            this.clearButton.Location = new System.Drawing.Point(270, 270);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(100, 30);
            this.clearButton.TabIndex = 2;
            this.clearButton.Text = "Clear";
            this.clearButton.Click += new System.EventHandler(this.clearButton_Click);
            // 
            // refreshButton
            // 
            this.refreshButton.Location = new System.Drawing.Point(380, 270);
            this.refreshButton.Name = "refreshButton";
            this.refreshButton.Size = new System.Drawing.Size(100, 30);
            this.refreshButton.TabIndex = 3;
            this.refreshButton.Text = "Refresh";
            this.refreshButton.Click += new System.EventHandler(this.refreshButton_Click);
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(575, 436);
            this.Controls.Add(this.deepCopyButton);
            this.Controls.Add(this.shallowCopyButton);
            this.Controls.Add(this.clearButton);
            this.Controls.Add(this.refreshButton);
            this.Name = "Form1";
            this.ResumeLayout(false);

        }

        private void deepCopyButton_Click(object sender, EventArgs e)
        {
            // Effectuez ici la copie profonde en fonction de la structure de vos classes
            Employee deepCopyEmployee = new Employee(originalEmployee);
            DisplayEmployeeDetails(deepCopyEmployee);
        }

        private void shallowCopyButton_Click(object sender, EventArgs e)
        {
            // Effectuez ici la copie superficielle en fonction de la structure de vos classes
            Employee shallowCopyEmployee = originalEmployee.ShallowCopy();
            DisplayEmployeeDetails(shallowCopyEmployee);
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            // Effacez les champs du formulaire
            nameTextBox.Text = "";
            idTextBox.Text = "";
            streetTextBox.Text = "";
            cityTextBox.Text = "";
            displayTextBox.Text = "";
        }

        private void refreshButton_Click(object sender, EventArgs e)
        {
            // Rafraîchissez le formulaire avec les détails de l'employé d'origine
            DisplayEmployeeDetails(originalEmployee);
        }



        private void DisplayEmployeeDetails(Employee employee)
        {
            displayTextBox.Text = $"Employee Details:\r\nName: {employee.Name}\r\nID: {employee.EmployeeId}\r\nAddress: {employee.EmployeeAddress}";
        }
    }
}

