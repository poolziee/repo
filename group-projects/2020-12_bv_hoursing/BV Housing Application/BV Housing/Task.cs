using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BV_Housing
{
    public class Task
    {
        private User user;
        private String taskName;
        private String status;
        private String dueTo;
        private int taskID;
        private static int nexFreeTaskID = 101;
        private bool forExchange = false;
        private User userToExchangeWith = null;
        public Task(User user, String taskName, String dueTo)
        {
            this.user = user;
            this.taskName = taskName;
            this.status = "Not Done";
            this.dueTo = dueTo;
            this.taskID = nexFreeTaskID;
            nexFreeTaskID++;
        }

        public bool ForExchange
        { get { return this.forExchange; }
          set { this.forExchange = value; }
        }

        public User UserToExchangeWith
        {   get { return this.userToExchangeWith; }
            set { this.userToExchangeWith = value; }
        }

        public int TaskID
        { get { return this.taskID; } }
      
        public User User
        {
            get { return this.user; }
            set { this.user = value; }
        }
        public String TaskName
        {
            get { return this.taskName; }
            set { this.taskName = value; }
        }
        public String Status
        {
            get { return this.status; }
            set { this.status = value; }
        }
        public String DueTo
        {
            get { return this.dueTo; }
            set { this.dueTo = value; }
        }
        public String GetInfo()
        {
            return $" Task{taskID} : {taskName}  - {dueTo} ";
        }
    }
}
