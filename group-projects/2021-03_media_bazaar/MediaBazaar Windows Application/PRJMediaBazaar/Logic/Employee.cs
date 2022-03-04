using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRJMediaBazaar.Logic
{
    public class Employee
    {
        
        public Employee(int id, string firstName, string lastName, DateTime birthDate,
           string gender, double salary, string email, string password,
          string jobPosition, int phoneNumber, string address, string education, string contract,
            int daysOff, int contractHours, int daysOffLeft)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            BirthDate = birthDate;
            Gender = gender;
            Salary = salary;
            Email = email;
            Password = password;
            JobPosition = jobPosition;
            PhoneNumber = phoneNumber;
            Address = address;
            Education = education;
            Contract = contract;
            DaysOff = daysOff;
            ContractHours = contractHours;
            DaysOffLeft = daysOffLeft;
        }

        public Employee(int id, string firstName, string lastName, string jobPosition)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            JobPosition = jobPosition;
        }

        public int Id { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public DateTime BirthDate { get; private set; }
        public string Gender { get; private set; }
        public double Salary { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }
        public string JobPosition { get; private set; }
        public int PhoneNumber { get; private set; }
        public string Address { get; private set; }
        public string Education { get; private set; }
        public string FullName { get { return FirstName + " " + LastName; } }
        public String Contract { get; set; }
        public int DaysOff { get; set; }
        public int ContractHours { get; set; }
        public int DaysOffLeft { get; set; }
        public String Note { get; set; }       
    }
}
