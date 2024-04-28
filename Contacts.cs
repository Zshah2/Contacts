
// Mohammad Shah and Jessie H. Contacts Project assigment.







using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IContacts
{
    interface MyInterface
    {

    }
    abstract class BaseContact : MyInterface
    {
        public string Name { get; set; }
        public string PhoneNumber { get; set; }

        // Constructor to initialize Name and PhoneNumber
        public BaseContact(string name, string phoneNumber)
        {
            Name = name;
            PhoneNumber = phoneNumber;
        }

        public abstract string GetContactType();
    }
}





using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace IContacts
{
    internal class BusinessContact : BaseContact
    {

        public BusinessContact(string name, string phoneNumber) : base(name, phoneNumber)
        {
            // Additional initialization for Business contact if needed
        }

        public override string GetContactType()
        {
            return "Business";
        }

        // Override ToString() to customize string representation
        public override string ToString()
        {
            return $"{GetContactType()}: {Name} - {PhoneNumber}";
        }

    }
}



using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IContacts
{
    internal class IContacts 
    {
        public string Name { get; set; }
        public string Phone { get;set; }

        public IContacts(string name, string phone) 
        {
        
            Name = name;
            Phone = phone;


        
        }

        public string GetInfo() 
        {
            return $"Name: {Name}\nPhone: {Phone}";


        }
    }

private void btnEditing_Click(object sender, EventArgs e)
        {
            if (lstContactResult.SelectedItem is BaseContact selectedContact)
            {
                using (var dialog = new InputDialogForm("Edit Name or Phone Number:"))
                {
                    if (dialog.ShowDialog() == DialogResult.OK)
                    {

                        if (dialog.InputType == InputDialogForm.ContactEditedType.Name)
                        {
                            selectedContact.Name = dialog.InputValue;
                        }
                        else if (dialog.InputType == InputDialogForm.ContactEditedType.PhoneNumber)
                        {
                            selectedContact.PhoneNumber = dialog.InputValue;
                        }

                        /*selectedContact.Name = dialog.InputValue;
                        selectedContact.PhoneNumber = dialog.InputValue;*/

                        //PopulateContactBox();

                        lstContactResult.DataSource = null;
                        lstContactResult.DataSource = allContacts;
                        lstContactResult.DisplayMember = "Name";
                        lstContactResult.ValueMember = "Phone Number";
                    }
                }

            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (lstContactResult.SelectedItem is BaseContact selectedContact)
            {
                allContacts.Remove(selectedContact);

              /*  lstContactResult.ClearSelected();
                lstContactResult.SelectedIndexChanged -= lstContactResult_SelectedIndexChanged;

                //contacts.Remove(selectedContact);

                lstContactResult.SelectedIndexChanged += lstContactResult_SelectedIndexChanged;

                //contacts.ResetBindings();//PopulateContactBox();

                if (lstContactResult.Items.Count == 0)
                {
                    lstContactResult_SelectedIndexChanged(lstContactResult, EventArgs.Empty);
                }*/



            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            allContacts.Clear();
            txtName.Text = null;
            txtPhone.Text = null;
            cmGroup.Text = null;
        }

        /*private void lstContactResult_SelectedIndexChanged(object sender, EventArgs e)
        {

        }*/
    }



}






using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IContacts
{
    internal class FamilyContact : BaseContact
    {
        public FamilyContact(string name, string phoneNumber) : base(name, phoneNumber)
        {
            // Additional initialization for Family contact if needed
        }

        public override string GetContactType()
        {
            return "Family";
        }

        // Override ToString() to customize string representation
        public override string ToString()
        {
            return $"{GetContactType()}: {Name} - {PhoneNumber}";
        }
    }
}








using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace IContacts
{
    internal class FriendContact : BaseContact
    {

        public FriendContact(string name, string phoneNumber) : base(name, phoneNumber)
        {
            // Additional initialization for Friend contact if needed
        }

        public override string GetContactType()
        {
            return "Friend";
        }

        // Override ToString() to customize string representation
        public override string ToString()
        {
            return $"{GetContactType()}: {Name} - {PhoneNumber}";
        }
    }
}





namespace IContacts
{
    public partial class Form1 : Form
    {


        private List<Contact> contacts = new List<Contact>();
        public Form1()
        {
            InitializeComponent();
            cmGroup.Items.Add("Friend");
            cmGroup.Items.Add("Family");
            cmGroup.Items.Add("Business");

            cmGroup.SelectedIndex = 0;


        }

        public class Contact
        {
            public string Name { get; set; }
            public string Phone { get; set; }


            public Contact(string name, string phone)
            {
                Name = name;
                Phone = phone;
            }

            public override string ToString()
            {
                return $"{Name}-{Phone}";
            }
        }








        private void Form1_Load(object sender, EventArgs e)
        {

        }



        private void PopulateContactBox()

        {
            LsContactResult.Items.Clear();

            foreach (var contact in contacts)
            {

                LsContactResult.Items.Add(contact);

            }


        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            // lets add a code where we get user input


            string name = txtNameBox.Text;
            string phone = txtPhoneBox.Text;

            // select from the group in combobox

        string group = cmGroup.SelectedItem?.ToString();

            // we need an if statment

            if (!string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(phone)
                && !string.IsNullOrEmpty(group)) 
            {
                // time to create contact


                BaseContact contact = null;

                switch (group) 
                {

                    case "Friend":
                        contact = new FriendContact(name, phone);
                        break;


                    case "Family":
                        contact = new FamilyContact(name, phone);
                        break;

                    case "Business":
                        contact = new BusinessContact(name, phone);
                        break;
                
                
                
                }

                if (contact != null)
                {
                    LsContactResult.Items.Add (contact);
                }
                else
                {
                    MessageBox.Show("Please enter name, phone, and select a group.");
                }


            }



        }
    }
}





























