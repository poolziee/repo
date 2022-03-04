using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BV_Housing
{
    public class Service
    {
        private string name;
        private List<User> users;
        private List<Rule> rules;
        private List<Complain> complainsAboutUsers;
        private List<Complain> complainsAboutAgency;
        private List<Task> tasks;
        private static List<string> TaskNames;
        public static User currentUser;

                                                     //Constructor
        public Service(String name)
        {
            this.name = name;
           users = new List<User>();
            rules = new List<Rule>();
            complainsAboutUsers = new List<Complain>();
            complainsAboutAgency = new List<Complain>();
            tasks = new List<Task>();
            TaskNames = new List<string>();
            TaskNames.Add("Laundry");
            TaskNames.Add("Garbage disposal");
            TaskNames.Add("Grocery");
            TaskNames.Add("Bathroom Cleaning");
            TaskNames.Add("Living room Cleaning");
            TaskNames.Add("Kitchen Cleaning");
            TaskNames.Add("Washing Floor");
            TaskNames.Add("Vacuuming");
            TaskNames.Add("Mopping");
        }

                                                       //Properties
        public List<User> ListUsers
        { get { return this.users; } }

        public List<Rule> ListRules
        { get { return this.rules; } }

        public List<String> ListTaskNames
        {
            get { return TaskNames; }
        }

        public List<Complain> ListComplainsAgency
        {
            get { return this.complainsAboutAgency; }
        }

        public List<Complain> ListComplainsStudent
        { get { return this.complainsAboutUsers; } }

        public List<Task> ListTasks
        { get { return this.tasks; } }



                                                       //Methods

        //Users
        public bool addUser(String name , String username , String password)
        {
            if (getByUsername(username) == null && name != "" && username != "" && password != "")
            {
                User user = new User(name, username, password);
                this.users.Add(user);
                return true;
            }
            return false;
        }

        public User getUserByName(String Name)
        {
            foreach (User u in this.users)
            {
                if (u.Name == Name)
                {
                    return u;
                }
            }
            return null;
        }

        public bool removeUserAtIndex(int index)
        {
            if (index >= 0)
            {
                User u = this.users.ElementAt(index);
                this.users.Remove(u);
                return true;
            }
            return false;
        }

        public User getByUsername(String username)
        {
            foreach (User u in this.users)
            {
                if (u.Username == username)
                {
                    return u;
                }
            }
            return null;
        }

        public bool IsAdmin(String username, String password)
        {
            if (username == "admin" && password == "admin")
            { return true; }
            return false;
        }

        public bool identifyStudent(String username, String password)
        {
            User student = getByUsername(username);
            if (student != null && student.Username != "admin")
            {
                if (student.Username == username && student.Password == password)
                {
                    Service.currentUser = student;
                    return true;
                }
            }
            return false;
        }
        //Complains
        public bool addComplain(String complainToAdd, String about)
        {
            Complain complain = new Complain(complainToAdd);
            if (about == "BV")
            { this.complainsAboutAgency.Add(complain); return true; }

            else if (about == "student")
            { this.complainsAboutUsers.Add(complain); return true; }
            return false;
        }
        //Rules
        public bool addRule(String ruleToAdd)
        {
            if (ruleToAdd != "")
            {
                Rule rule = new Rule(ruleToAdd);
                this.rules.Add(rule);
                return true;
            }
            return false;
        }

        public bool removeRuleAtIndex(int index)
        {
            if (index >= 0)
            {
                Rule r = this.rules.ElementAt(index);
                this.rules.Remove(r);
                return true;
            }
            return false;
        }

        //TaskNames

        public void removeTaskNameAtIndex(int index)
        {
            if(index >= 0)
            {
                TaskNames.RemoveAt(index);
            }
        }

        public String GetTaskName(string text)
        {
            foreach (String s in this.ListTaskNames)
            {
                if (s == text)
                { return s; }
            }
            return null;
        }

        public void AddTaskName(string text)
        {
            TaskNames.Add(text);
        }

        public Task TaskWithName(String s)
        {
            foreach (Task t in this.tasks)
            {
                if (t.TaskName == s)
                { return t; }
            }
            return null;
        }

       //Tasks

       public void addTask(String task , String dueTo)
        {
            Task newTask = new Task(currentUser , task , dueTo);
            //currentUser.UserTasks.Add(newTask);
            this.tasks.Add(newTask);
        }

        public void addTask(String task, String dueTo , User u)
        {
            Task newTask = new Task(u , task, dueTo);
            //u.UserTasks.Add(newTask);
            this.tasks.Add(newTask);
        }

        public void editTask(Task t , String task , String dueTo)
        {
            t.TaskName = task;
            t.DueTo = dueTo;
        }

        public bool proposeExchange(Task t , User user) //propose a task to a user
        {
            if (ProposalFor(user) == null)
            {
                t.UserToExchangeWith = user; // set the UserToExchange with the given user
                t.ForExchange = true;
                t.Status = $"Proposed to {user.Name}";
                return true;
            }
            return false;
        }

        public void exchangeTask(Task t) // exchange the task from the original user to the UserToExchangeWith
        {
            //t.User.UserTasks.Remove(t);  // remove the task from the original user tasks
            //t.UserToExchangeWith.UserTasks.Add(t); // assign the task to the user that agreed
            t.User = t.UserToExchangeWith; // set the new User for the task
            t.ForExchange = false;
            t.Status = "Not Done"; // auto-assign the status to Not Done
            t.UserToExchangeWith = null; // remove the UserToExchange from the task
        }

        public void denyProposal(Task t)
        {
            t.UserToExchangeWith = null;
            t.ForExchange = false;
            t.Status = "Not Done";
        }


        public Task ProposalFor(User u) //check if user is proposed a task and return it
        {
           foreach (Task t in this.tasks)
            {
                if (t.UserToExchangeWith == u)
                {
                    return t;
                }
            }
            return null;
        }

        public List<Task> CurrentUserTasks()
        {
            List<Task> temp = new List<Task>();
            foreach(Task t in this.tasks)
            {
                if (t.User == Service.currentUser)
                {
                    temp.Add(t);
                }
            }
            return temp;
        }

    }
}
