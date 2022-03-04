using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BV_Housing
{
    public static class Prompt
    {
        public static string ProposalWindow(string caption , Service bv , Task taskToExchange , studentView form)
        {
            Form prompt = new Form()
            {
                Width = 500,
                Height = 150,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                Text = caption,
                StartPosition = FormStartPosition.CenterScreen
            };

            Label textLabel = new Label() { AutoSize = true , Left = 80, Top = 20, Text = $" Proposal : {taskToExchange.GetInfo()}"
        };
            Label instructions = new Label() { AutoSize = true, Left = 30, Top = 40, Text = "Select the person to request exchange :"};
            ComboBox comboBox = new ComboBox() { Left = 50, Top = 60, Width = 100 }; comboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            Button confirmation = new Button() { Text = "Send", Left = 350, Width = 100, Top = 70, DialogResult = DialogResult.OK };
            Button cancel = new Button() { Text = "Cancel", Left = 250, Width = 100, Top = 70, DialogResult = DialogResult.Cancel };
            prompt.Controls.Add(comboBox);
            prompt.Controls.Add(confirmation);
            prompt.Controls.Add(cancel);     cancel.Click += (sender, e) => { prompt.Close(); };
            prompt.Controls.Add(textLabel);
            prompt.Controls.Add(instructions);
            prompt.AcceptButton = confirmation;
            confirmation.Click += (sender, e) => 
            {
                if (comboBox.Text != "") //check if a name is selected
                {
                   
                        //if the proposal is successfull , msgbox and show updated list
                        if (bv.proposeExchange(taskToExchange, bv.getUserByName(comboBox.Text)))
                        {
                            MessageBox.Show($"Proposal for exchanging task with ID {taskToExchange.TaskID} sent to {taskToExchange.UserToExchangeWith.Name}.");
                            prompt.Close();
                            form.showMyList();
                        }
                        //if the proposal is unsuccessfull , tell the user
                        else
                        {
                            MessageBox.Show($"{comboBox.Text} already has a pending proposal from {taskToExchange.User.Name}");
                            string promptValue = Prompt.ProposalWindow("Task Exchange", bv, taskToExchange, form);
                        } 
            
                }
                else { MessageBox.Show("Please select a user to propose exchange"); }
            
            };

            //add the possible Users for proposal to the combobox
            foreach (User u in bv.ListUsers) { if (Service.currentUser.Name != u.Name) { comboBox.Items.Add(u.Name); } }
            
            return prompt.ShowDialog() == DialogResult.OK ? comboBox.Text : "";
        }

    }
}
