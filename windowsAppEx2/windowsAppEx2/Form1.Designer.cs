using System;
using System.Text;
using System.Windows.Forms;

namespace windowsAppEx2
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private TextBox nameTextBox;
        private TextBox idTextBox;
        private TextBox streetTextBox;
        private TextBox cityTextBox;
        private Button addButton;
        private TextBox displayTextBox;

        private Label nameLabel;
        private Label idLabel;
        private Label streetLabel;
        private Label cityLabel;
        private Button deepCopyButton;
        private Button shallowCopyButton;
        private Button clearButton;
        private Button refreshButton;
        private Employee originalEmployee;

        private void InitializeComponent()
        {
            // Initialisation des composants du formulaire
            this.deepCopyButton = new Button { Location = new System.Drawing.Point(50, 270), Size = new System.Drawing.Size(100, 30), Text = "Deep Copy" };
            this.shallowCopyButton = new Button { Location = new System.Drawing.Point(160, 270), Size = new System.Drawing.Size(100, 30), Text = "Shallow Copy" };
            this.clearButton = new Button { Location = new System.Drawing.Point(270, 270), Size = new System.Drawing.Size(100, 30), Text = "Clear" };
            this.refreshButton = new Button { Location = new System.Drawing.Point(380, 270), Size = new System.Drawing.Size(100, 30), Text = "Refresh" };

            // Gestion des événements pour les boutons
            this.deepCopyButton.Click += new System.EventHandler(this.deepCopyButton_Click);
            this.shallowCopyButton.Click += new System.EventHandler(this.shallowCopyButton_Click);
            this.clearButton.Click += new System.EventHandler(this.clearButton_Click);
            this.refreshButton.Click += new System.EventHandler(this.refreshButton_Click);

            // Initialisation du formulaire
            this.ClientSize = new System.Drawing.Size(575, 436);
            this.Controls.Add(this.deepCopyButton);
            this.Controls.Add(this.shallowCopyButton);
            this.Controls.Add(this.clearButton);
            this.Controls.Add(this.refreshButton);

            // Initialisation des labels et textboxes pour le nom, l'ID, la rue et la ville
            nameLabel = new Label { Text = "Name:", Location = new System.Drawing.Point(50, 30) };
            this.Controls.Add(nameLabel);
            nameTextBox = new TextBox { Location = new System.Drawing.Point(50, 50), Size = new System.Drawing.Size(200, 20) };
            this.Controls.Add(nameTextBox);

            idLabel = new Label { Text = "Employee ID:", Location = new System.Drawing.Point(50, 80) };
            this.Controls.Add(idLabel);
            idTextBox = new TextBox { Location = new System.Drawing.Point(50, 100), Size = new System.Drawing.Size(200, 20) };
            this.Controls.Add(idTextBox);

            streetLabel = new Label { Text = "Street:", Location = new System.Drawing.Point(50, 130) };
            this.Controls.Add(streetLabel);
            streetTextBox = new TextBox { Location = new System.Drawing.Point(50, 150), Size = new System.Drawing.Size(200, 20) };
            this.Controls.Add(streetTextBox);

            cityLabel = new Label { Text = "City:", Location = new System.Drawing.Point(50, 180) };
            this.Controls.Add(cityLabel);
            cityTextBox = new TextBox { Location = new System.Drawing.Point(50, 200), Size = new System.Drawing.Size(200, 20) };
            this.Controls.Add(cityTextBox);

            // Bouton pour ajouter un employé
            addButton = new Button { Location = new System.Drawing.Point(50, 230), Size = new System.Drawing.Size(100, 30), Text = "Add Employee" };
            addButton.Click += new System.EventHandler(this.addButton_Click);
            this.Controls.Add(addButton);

            // TextBox pour afficher les détails de l'employé
            displayTextBox = new TextBox { Multiline = true, ReadOnly = true, Location = new System.Drawing.Point(300, 50), Size = new System.Drawing.Size(400, 200) };
            this.Controls.Add(displayTextBox);
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            Employee newEmployee = new Employee
            {
                Name = nameTextBox.Text,
                EmployeeId = int.TryParse(idTextBox.Text, out int id) ? id : 0,
                EmployeeAddress = new Address(streetTextBox.Text, cityTextBox.Text)
            };

            // Mise à jour de la référence à l'employé d'origine
            originalEmployee = newEmployee;

            DisplayEmployeeDetails(newEmployee);
        }

        private void deepCopyButton_Click(object sender, EventArgs e)
        {
            if (originalEmployee != null)
            {
                // Copie profonde de l'employé
                Employee deepCopyEmployee = originalEmployee.DeepCopy();

                // Affichage des détails de la copie profonde
                displayTextBox.AppendText("\r\n\r\nDeep Copy:\r\n");
                DisplayEmployeeDetails(deepCopyEmployee);
            }
        }

        private void shallowCopyButton_Click(object sender, EventArgs e)
        {
            if (originalEmployee != null)
            {
                // Copie superficielle de l'employé
                Employee shallowCopyEmployee = originalEmployee.ShallowCopy();

                // Affichage des détails de la copie superficielle
                displayTextBox.AppendText("\r\n\r\nShallow Copy:\r\n");
                DisplayEmployeeDetails(shallowCopyEmployee);
            }
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            // Effacement des champs du formulaire
            nameTextBox.Text = "";
            idTextBox.Text = "";
            streetTextBox.Text = "";
            cityTextBox.Text = "";
            displayTextBox.Text = "";
        }

        private void refreshButton_Click(object sender, EventArgs e)
        {
            // Rafraîchissement du formulaire avec les détails de l'employé d'origine
            DisplayEmployeeDetails(originalEmployee);
        }

        private void DisplayEmployeeDetails(Employee employee)
        {
            // Utilisation de StringBuilder pour l'affichage
            StringBuilder details = new StringBuilder();
            details.AppendLine("Employee Details:");
            details.AppendLine($"Name: {employee.Name}");
            details.AppendLine($"ID: {employee.EmployeeId}");
            details.AppendLine($"Address: {employee.EmployeeAddress?.ToString() ?? "N/A"}");

            // Affichage des détails dans la TextBox
            displayTextBox.Text = details.ToString();
        }
    }
}
