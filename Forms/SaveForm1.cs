using System;
using System.IO;
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
    public partial class SaveForm1 : Form
    {
        private PrisonerCollection savedCollection;
        public SaveForm1()
        {
            InitializeComponent();
            savedCollection = new PrisonerCollection();
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            savedCollection.SerializeXML();
            Hide();
            MenuForm newForm = new MenuForm();
            newForm.ShowDialog();
            this.Close();
        }

        private void SaveForm1_Load(object sender, EventArgs e)
        {

            dataGridView1.AutoGenerateColumns = false;

            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;
            dataGridView1.ColumnCount = 11;
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
            savedCollection.DeserializeXML();

            BindingList<Prisoner> prisoners = new BindingList<Prisoner>(savedCollection.Prisoners);
            BindingList<Prisoner> filtered = new BindingList<Prisoner>(prisoners.Where(
                                             p => p.Saved.Equals(true)).ToList());
            dataGridView1.DataSource = filtered;

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;
        }

      
        private void SavedForm_FormClosing(Object sender, FormClosingEventArgs e)
        {
            savedCollection.SerializeXML();
        }

        private void ExportButton_Click(object sender, EventArgs e)
        { 
                //var lstData = new DataDbHandler().GetDetails();
                var sb = new StringBuilder();
                foreach (DataGridViewRow data in dataGridView1.Rows)
                {
                    sb.Append("\"");
                    foreach (DataGridViewCell cell in data.Cells)
                    {
                        sb.Append(Convert.ToString(cell.Value) + "\",\"");
                    }
                    sb.AppendLine("\"");

                }
            File.WriteAllText(Const.ExportFileName, sb.ToString());
            MessageBox.Show("Експортовано");
        }
    }
}
