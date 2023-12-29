using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace windowsAppEx2
{
    // Étape 1 : Création de la classe Employee
    public class Employee
    {
        private Employee originalEmployee;
        public Employee() { }
        public Employee(Employee originalEmployee)
        {
            this.originalEmployee = originalEmployee;
        }

        public string Name { get; set; }
        public int EmployeeId { get; set; }
        public Address EmployeeAddress { get; set; }

        // Méthode de copie superficielle (Shallow Copy)
        public Employee ShallowCopy()
        {
            return (Employee)this.MemberwiseClone();
        }

        // Méthode de copie profonde (Deep Copy)
        public Employee DeepCopy()
        {
            // Créer une nouvelle instance d'Employee
            Employee newEmployee = (Employee)this.MemberwiseClone();

            // Créer une nouvelle instance d'Address pour éviter le partage de références
            newEmployee.EmployeeAddress = new Address(this.EmployeeAddress.Street, this.EmployeeAddress.City);

            return newEmployee;
        }
    }

    // Classe pour l'adresse de l'employé
    public class Address
    {
        public string Street { get; set; }
        public string City { get; set; }

        public Address(string street, string city)
        {
            Street = street;
            City = city;
        }

        // Étape 2 : Remplacement de la méthode ToString()
        public override string ToString()
        {
            return $"{Street}, {City}";
        }
    }
}

