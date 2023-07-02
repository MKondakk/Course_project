using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CoorseProdject01.Classes;


namespace CoorseProdject01
{
    public partial class SignUpForm : Form
    {
        private UserCollection userCollection;

        public SignUpForm()
        {
            InitializeComponent();

            userCollection = new UserCollection();
            /*
            userCollection.Users.Add(new User() { Username = "Admin", Password = "admin", IsAdmin = true });
            userCollection.Users.Add(new User() { Username = "Maria", Password = "maria", IsAdmin = false });
            userCollection.Users.Add(new User() { Username = "Mike", Password = "mike", IsAdmin = false });
            userCollection.SerializeXML();
            */
            userCollection.DeserializeXML();

            UserList.DataSource = userCollection.Users;
            UserList.DisplayMember = "Username";
            UserList.ValueMember = "Username";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Globals.CurrentUser.CheckPassword(PasswordBox.Text))
            {
                Hide();
                MenuForm newForm = new MenuForm();
                newForm.ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show("Неверный пароль");
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void PasswordBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void SignUpForm_Load(object sender, EventArgs e)
        {

        }

        private void UserList_SelectedIndexChanged(object sender, EventArgs e)
        {

            Globals.CurrentUser = (User)UserList.SelectedItem;
        }
    }
}
