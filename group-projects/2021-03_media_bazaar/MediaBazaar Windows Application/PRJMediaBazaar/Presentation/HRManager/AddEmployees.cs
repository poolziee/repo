using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using EmployeeControl = PRJMediaBazaar.Logic.EmployeeControl;
using PRJMediaBazaar.Logic;

namespace PRJMediaBazaar
{
    partial class AddEmployees : Form
    {
        private EmployeeControl ec;
        private HRHome hr;
        private List<Employee> employees;
        private List<Button> buttons;
        private List<Timer> timers;
        public AddEmployees(HRHome hr, EmployeeControl ec, List<Employee> employees)
        {
            InitializeComponent();
            timers = new List<Timer>();
            buttons = new List<Button>();
            this.ec = ec;
            this.hr = hr;
            this.employees = employees;
        }
        public void StatusFunction(String text, int x, int y, int width, int height, Color color)
        {
            Button newButton = new Button();
            newButton.Location = new Point(x, y);
            newButton.Width = width;
            newButton.Height = height;
            newButton.Enabled = false;
            newButton.BackColor = color;
            newButton.Text = text;
            this.Controls.Add(newButton);
            newButton.BringToFront();
            buttons.Add(newButton);
            Timer temp = new Timer();
            timers.Add(temp);
            temp.Start();
        }
        private void btnAddEmployee_Click(object sender, EventArgs e)
        {
            try
            {
                String firstName = this.tbSurname.Text;
                if (Regex.IsMatch(firstName, @"\d"))
                {
                    StatusFunction("Enter a valid first name!", -60, -5, 835, 28, Color.Red);
                    throw new InvalidStringException();
                }
                String lastName = this.tbName.Text;
                if (Regex.IsMatch(lastName, @"\d"))
                {
                    StatusFunction("Enter a valid last name!", -60, -5, 835, 28, Color.Red);
                    throw new InvalidStringException();
                }
                DateTime birthDate = this.dtpBirthdate.Value.Date;
                String email = this.tbEmail.Text;
                if (CheckEmail(email) == false)
                {
                    StatusFunction("Enter a valid email!", -60, -5, 835, 28, Color.Red);
                    throw new InvalidEmailException();
                }
                if (this.tbPassword.TextLength == 0)
                {
                    StatusFunction("Enter a password!", -60, -5, 835, 28, Color.Red);
                    throw new Exception();
                }
                String password = this.tbPassword.Text;
                if (this.cbJobPosition.SelectedItem == null )
                {
                    StatusFunction("Select a job position!", -60, -5, 835, 28, Color.Red);
                    throw new EmptyComboBoxException();
                }
                String jobPosition = this.cbJobPosition.Text;
                if (this.tbPhone.Text.Length == 0 || !Regex.IsMatch(this.tbPhone.Text, @"^\d+$"))
                {
                    StatusFunction("Enter a valid phone!", -60, -5, 835, 28, Color.Red);
                    throw new InvalidIntException();
                }    
                int phone = Convert.ToInt32(this.tbPhone.Text);
                if (phone < 0 || this.tbPhone.Text.Length != 10)
                {
                    StatusFunction("Enter a valid phone!", -60, -5, 835, 28, Color.Red);
                    throw new NegativeInputException();
                }
                String address = this.tbAddress.Text;
                if (!Regex.IsMatch(this.tbSalary.Text.ToString(), @"^\d+$"))
                {
                    StatusFunction("Enter a valid salary!", -60, -5, 835, 28, Color.Red);
                    throw new InvalidIntException();
                }
                int salary = Convert.ToInt32(this.tbSalary.Text);
                if (salary < 0)
                {
                    StatusFunction("Enter a valid salary!", -60, -5, 835, 28, Color.Red);
                    throw new NegativeInputException();
                }
                if (this.cbGender.SelectedItem == null)
                {
                    StatusFunction("Select a gender!", -60, -5, 835, 28, Color.Red);
                    throw new EmptyComboBoxException();
                }
                String gender = this.cbGender.Text;
                String education = this.tbEducation.Text;
                if (Regex.IsMatch(education, @"\d"))
                {
                    StatusFunction("Enter a valid education!", -60, -5, 835, 28, Color.Red);
                    throw new InvalidStringException();
                }
                

                if (this.rbFulltime.Checked == true)
                {
                    String contract = this.rbFulltime.Text;
                    ec.AddAnEmployee(firstName, lastName, birthDate, email, password, jobPosition, phone, address,
                                    salary, gender, education, contract, 30, 40, 30);
                    int id = ec.GetIDFromEmail(email);
                    hr.AddEmployee(new Employee(id, firstName, lastName, birthDate, gender, salary, email, password, jobPosition,
                                    phone, address, education, contract, 30, 40, 30));
                    hr.AddNameToCB(firstName + ' ' + lastName);
                    StatusFunction("Success!", -60, -5, 835, 28, Color.Green);
                }
                else if (this.rbParttime.Checked == true)
                {
                    if (!Regex.IsMatch(this.tbDaysOffLeft.Text, @"^\d+$") || Convert.ToInt32(this.tbDaysOffLeft.Text)<1)
                    {
                        StatusFunction("Enter valid days off!", -60, -5, 835, 28, Color.Red);
                        throw new InvalidIntException();
                    }
                    int daysOff = Convert.ToInt32(this.tbDaysOffLeft.Text);
                    String contract = this.rbParttime.Text;
                    if (!Regex.IsMatch(this.tbContractHours.Text, @"^\d+$") || Convert.ToInt32(this.tbContractHours.Text)<1 || Convert.ToInt32(this.tbContractHours.Text)>39)
                    {
                        StatusFunction("Enter valid contract hours!", -60, -5, 835, 28, Color.Red);
                        throw new InvalidIntException();
                    }
                    int contractHours = Convert.ToInt32(this.tbContractHours.Text);
                    
                    ec.AddAnEmployee(firstName, lastName, birthDate, email, password, jobPosition, phone, address,
                                    salary, gender, education, contract, daysOff, contractHours, daysOff);
                    int id = ec.GetIDFromEmail(email);
                    hr.AddEmployee(new Employee(id, firstName, lastName, birthDate, gender, salary, email, password, jobPosition,
                                   phone, address, education, contract, daysOff, contractHours, daysOff));
                    hr.AddNameToCB(firstName + ' ' + lastName);
                    StatusFunction("Success!", -60, -5, 835, 28, Color.Green);
                }
            }
            catch (InvalidIntException ex)
            {
                if (this.rbParttime.Checked == true)
                {
                    StatusFunction("Enter valid numbers for phone,salary,contract hours and days off!", -60, -5, 835, 28, Color.Red);
                }
                else
                {
                    StatusFunction("Enter valid numbers for phone and salary!", -60, -5, 835, 28, Color.Red);
                }
                
            }
            catch (EmptyComboBoxException ex)
            {
                StatusFunction("Select a gender and job position!", -60, -5, 835, 28, Color.Red);
            }
            catch (InvalidEmailException ex)
            {
                StatusFunction("Enter a valid email!", -60, -5, 835, 28, Color.Red);
            }
            catch (InvalidStringException ex)
            {
                StatusFunction("Enter a valid name, address and education", -60, -5, 835, 28, Color.Red);
            }
            catch (NegativeInputException ex)
            {
                StatusFunction("Input cannot be negative!", -60, -5, 835, 28, Color.Red);
            }
        }

        private void rbFulltime_CheckedChanged(object sender, EventArgs e)
        {
            if (this.rbFulltime.Checked == true)
            {
                this.tbContractHours.Visible = false;
                this.label12.Visible = false;
                this.label13.Visible = false;
                this.tbDaysOffLeft.Visible = false;
            }
        }

        private void rbParttime_CheckedChanged(object sender, EventArgs e)
        {
            if (this.rbParttime.Checked == true)
            {
                this.tbContractHours.Visible = true;
                this.label12.Visible = true;
                this.label13.Visible = true;
                this.tbDaysOffLeft.Visible = true;
            }
        }
        private bool CheckEmail(String email)
        {
            return new EmailAddressAttribute().IsValid(email);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
        }

        private void godTimer_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < timers.Count; i++)
            {
                if (timers[i].Enabled == true)
                {
                    timers[i].Enabled = false;
                    buttons[i].Visible = false;
                }
            }
        }
    }
}
