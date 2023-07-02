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
    public partial class AddForm : Form
    {
        private Prisoner prisoner;
        public string[] arrayOfTerm; 
        public AddForm()
        {
            InitializeComponent();
          
        }
        public DialogResult ShowDialog(ref Prisoner p)
        {
            prisoner = new Prisoner();
            prisoner = p;
            textBox1.Text = prisoner.Firstname;
            textBox2.Text = prisoner.Lastname;
            dateTimePicker1.MinDate = new DateTime(1900, 1, 1);
            dateTimePicker1.MaxDate = DateTime.Today;
            dateTimePicker1.Value = prisoner.Birthday;   
            textBox4.Text = prisoner.Sex;
            textBox5.Text = prisoner.Article;
            arrayOfTerm = prisoner.Term.Split(' ');
            numericUpDown2.Value = Convert.ToInt32(arrayOfTerm[0]);
            numericUpDown3.Value = Convert.ToInt32(arrayOfTerm[2]);
            numericUpDown4.Value = Convert.ToInt32(arrayOfTerm[4]);
            dateTimePicker2.MinDate = new DateTime(1900, 1, 1);
            dateTimePicker2.MaxDate = DateTime.Today;
            dateTimePicker2.Value = prisoner.Startdate;
            textBox8.Text = prisoner.Hierarchy;
            numericUpDown1.Value = prisoner.Room;
            textBox10.Text = prisoner.Relatives;
            textBox11.Text = prisoner.Character;
            this.DialogResult = DialogResult.Cancel;
            return this.ShowDialog(); 
 
            
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }


        private void label7_Click(object sender, EventArgs e)
        {

        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }
        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            prisoner.Firstname = textBox1.Text;
            prisoner.Lastname = textBox2.Text;
            prisoner.Birthday = dateTimePicker1.Value;
            if (textBox4.Text == "ч" || textBox4.Text == "ж")
            {
               prisoner.Sex = textBox4.Text;  
            }    
            prisoner.Article = textBox5.Text;
            prisoner.Term = String.Format("{0} р. {1} м. {2} д.", numericUpDown2.Value, numericUpDown3.Value, numericUpDown4.Value);
            prisoner.Startdate = dateTimePicker2.Value;
            prisoner.Hierarchy = textBox8.Text;
            prisoner.Room = Convert.ToInt32(numericUpDown1.Value);
            prisoner.Relatives = textBox10.Text;
            prisoner.Character = textBox11.Text;
            prisoner.Id = Convert.ToString(Guid.NewGuid());
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void AddForm_Load(object sender, EventArgs e)
        {
            
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
