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

namespace CoorseProdject01.Classes
{
    public partial class Form1 : Form
    {
        private PrisonerCollection prisonerCollection;
        public Form1()
        {
            InitializeComponent();
            prisonerCollection = new PrisonerCollection();

           /* 
            DateTime bd = new DateTime(2003, 05, 21);
            DateTime sd = new DateTime(2020, 09, 26);
            Guid g = Guid.NewGuid();

            prisonerCollection.Prisoners.Add(new Prisoner() { Firstname = "Роман ",
                Lastname = "Кацаран ", Birthday = bd, Sex = "ч", Article = "151", 
                Term = "1 р. 5 м. 0 д.", Startdate = sd, Hierarchy = "головний", 
                Room = 1, Relatives = "мати Ольга Iванова,  батько Микола Миколов", 
                Character = "буйний", Saved = false, Id = Convert.ToString(g) });

            Guid g2 = Guid.NewGuid();
            DateTime bd2 = new DateTime(2005, 03, 12);
            DateTime sd2 = new DateTime(2021, 04, 03);
            prisonerCollection.Prisoners.Add(new Prisoner() { Firstname = "Катерина",
                Lastname = "Петрова", Birthday = bd2, Sex = "ж", Article = "27", 
                Term = "0 р. 0 м. 15 д.", Startdate = sd2, Hierarchy = "звичайна", 
                Room = 2, Relatives = "брат Олег Олегов", 
                Character = "спокiйна", Saved = false, Id = Convert.ToString(g2)
            });

            prisonerCollection.SerializeXML();
           */


            prisonerCollection.DeserializeXML();

        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {


        }
        private void Form1_Load(object sender, EventArgs e)
        {
            
            dataGridView1.AutoGenerateColumns = false;
         
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;
            dataGridView1.ColumnCount = 12;
            dataGridView1.Columns[0].Name = "Iм'я";
            dataGridView1.Columns[0].DataPropertyName = "Firstname";
            dataGridView1.Columns[1].Name = "Прiзвище";
            dataGridView1.Columns[1].DataPropertyName = "Lastname";
            dataGridView1.Columns[2].Name = "Дата народження";
            dataGridView1.Columns[2].DataPropertyName = "Birthday";
            dataGridView1.Columns[3].Name = "Стать";
            dataGridView1.Columns[3].DataPropertyName = "Sex";
            dataGridView1.Columns[4].Name = "Стаття";
            dataGridView1.Columns[4].DataPropertyName = "Article";
            dataGridView1.Columns[5].Name = "Термiн";
            dataGridView1.Columns[5].DataPropertyName = "Term";
            dataGridView1.Columns[6].Name = "Початок строку";
            dataGridView1.Columns[6].DataPropertyName = "Startdate";
            dataGridView1.Columns[7].Name = "Мiсце в iєрархiї";
            dataGridView1.Columns[7].DataPropertyName = "Hierarchy";
            dataGridView1.Columns[8].Name = "Камера";
            dataGridView1.Columns[8].DataPropertyName = "Room";
            dataGridView1.Columns[9].Name = "Родичi";
            dataGridView1.Columns[9].DataPropertyName = "Relatives";
            dataGridView1.Columns[10].Name = "Характер";
            dataGridView1.Columns[10].DataPropertyName = "Character";
            dataGridView1.Columns[11].Name = "Збережено";
            dataGridView1.Columns[11].DataPropertyName = "Saved";

            prisonerCollection.DeserializeXML();

            dataGridView1.DataSource = prisonerCollection.Prisoners;

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;

            if (Globals.CurrentUser.IsAdmin == false)
            {
                AddButton.Hide();
                ChangeButton.Hide();
                DeleteButton.Hide();
            }

            this.FormClosing += new FormClosingEventHandler(Form1_FormClosing);

            numericUpDown1.Text = "";
            numericUpDown2.Text = "";
            numericUpDown3.Text = "";
            numericUpDown4.Text = "";

        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

  

        private void BackButton_Click(object sender, EventArgs e)
        {
            prisonerCollection.SerializeXML();
            Hide();
            MenuForm newForm = new MenuForm();
            newForm.ShowDialog();
            this.Close();
            
        }

        private void ChangeButton_Click(object sender, EventArgs e)
        {
            AddForm newForm1 = new AddForm();
            Prisoner curpr = new Prisoner();

            curpr = prisonerCollection.Prisoners[dataGridView1.CurrentCell.RowIndex];
           
           newForm1.ShowDialog(ref curpr);
            dataGridView1.Refresh();       
        }
       
        private void Form1_FormClosing(Object sender, FormClosingEventArgs e)
        {
            prisonerCollection.SerializeXML();
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            AddForm newForm1 = new AddForm();
            Prisoner newpr = new Prisoner();
            newpr.Birthday = new DateTime(2000, 01, 01); 
            newpr.Startdate = new DateTime(2000, 01, 01);
            newpr.Term = "0 р. 0 м. 0 д.";
            newpr.Room = 0;
            if (newForm1.ShowDialog(ref newpr) == DialogResult.OK)
            {
            prisonerCollection.Prisoners.Add(new Prisoner {Firstname = newpr.Firstname, 
                Lastname = newpr.Lastname, Birthday = newpr.Birthday,
                Sex = newpr.Sex, Article = newpr.Article, Term = newpr.Term, Startdate = newpr.Startdate, 
                Hierarchy = newpr.Hierarchy, Room = newpr.Room, Relatives = newpr.Relatives, 
                Character = newpr.Character, Saved = false, Id = newpr.Id});
            dataGridView1.DataSource = prisonerCollection.Prisoners.ToList();
            dataGridView1.Refresh();
            }
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Видалити", "Ви впевненi?", MessageBoxButtons.YesNo);
            switch (dr)
            {
                case DialogResult.Yes:
                    {
                        if (dataGridView1.CurrentRow != null)
                        {
                            prisonerCollection.Prisoners.RemoveAt(dataGridView1.CurrentCell.RowIndex);
                            dataGridView1.DataSource = prisonerCollection.Prisoners.ToList();
                        }
                    }
                    break;
                case DialogResult.No:
                    break;
            }
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            prisonerCollection.Prisoners[dataGridView1.CurrentCell.RowIndex].Saved = !prisonerCollection.Prisoners[dataGridView1.CurrentCell.RowIndex].Saved;
            dataGridView1.Refresh();
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {

            string[] arrayOfTerm; 
            dataGridView1.CurrentCell = null;
            dataGridView1.ClearSelection();
            

            foreach (DataGridViewRow r in dataGridView1.Rows)
            {
                dataGridView1.Rows[r.Index].Selected = false;
                arrayOfTerm = Convert.ToString(r.Cells[5].Value).Split(' ');
                if (
                    (textBox1.Text == "" 
                        || Convert.ToString(r.Cells[0].Value).ToUpper().Contains(textBox1.Text.ToUpper()))
                    &&
                    (textBox2.Text == ""
                        || Convert.ToString(r.Cells[1].Value).ToUpper().Contains(textBox2.Text.ToUpper()))
                    &&
                    (numericUpDown1.Text == "" 
                        || Convert.ToInt32(r.Cells[8].Value) == numericUpDown1.Value)
                    &&
                    (DateTime.Compare(dateTimePicker1.Value, Convert.ToDateTime(r.Cells[2].Value)) <= 0)
                    &&
                    (DateTime.Compare(dateTimePicker2.Value, Convert.ToDateTime(r.Cells[2].Value)) >= 0)
                    &&
                    (textBox3.Text == ""
                        || Convert.ToString(r.Cells[3].Value).ToUpper().Contains(textBox3.Text.ToUpper()))
                    &&
                    (textBox4.Text == ""
                        || Convert.ToString(r.Cells[4].Value).ToUpper().Contains(textBox4.Text.ToUpper()))
                    &&
                    (DateTime.Compare(dateTimePicker4.Value, Convert.ToDateTime(r.Cells[6].Value)) <= 0)
                    &&
                    (DateTime.Compare(dateTimePicker3.Value, Convert.ToDateTime(r.Cells[6].Value)) >= 0)
                    &&
                    (numericUpDown2.Text == ""
                         || Convert.ToInt32(arrayOfTerm[0]) == numericUpDown2.Value)
                    &&
                    (numericUpDown3.Text == ""
                         || Convert.ToInt32(arrayOfTerm[2]) == numericUpDown3.Value)
                    &&
                    (numericUpDown4.Text == ""
                         || Convert.ToInt32(arrayOfTerm[4]) == numericUpDown4.Value)
                         &&
                    (textBox5.Text == ""
                        || Convert.ToString(r.Cells[7].Value).ToUpper().Contains(textBox5.Text.ToUpper()))
                    &&
                    (textBox6.Text == ""
                        || Convert.ToString(r.Cells[9].Value).ToUpper().Contains(textBox6.Text.ToUpper()))
                        &&
                    (textBox7.Text == ""
                        || Convert.ToString(r.Cells[10].Value).ToUpper().Contains(textBox7.Text.ToUpper()))

                    ) 
                {
                    dataGridView1.Rows[r.Index].Visible = true;
                    dataGridView1.Rows[r.Index].Selected = true;
                }

                else
                {
                    
                    dataGridView1.Rows[r.Index].Visible = false;
                }
            }

            dataGridView1.Refresh();
            //this.dataGridView1.CurrentCell = this.dataGridView1[0, 0];
        }

        private void CleanButton_Click(object sender, EventArgs e)
        {
            numericUpDown1.Text = "";
            numericUpDown2.Text = "";
            numericUpDown3.Text = "";
            numericUpDown4.Text = "";
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            dateTimePicker1.Value = new DateTime(1900, 01, 01);
            DateTime dt = DateTime.Today;
            dateTimePicker2.Value = dt;
            dateTimePicker4.Value = new DateTime(1900, 01, 01);
            DateTime dt1 = DateTime.Today;
            dateTimePicker3.Value = dt1;
            SearchButton_Click(sender, e);

        }

        private void numericUpDown3_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }
    }
}
