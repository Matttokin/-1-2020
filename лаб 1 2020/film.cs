using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace лаб_1_2020
{
    public partial class film : Form
    {
        ArrayList edl = new ArrayList();

        public film(int id_polz)
        {
            InitializeComponent();

            string prav = serverRequest.get_rules_and_othr(id_polz, 0);

            if (prav[0] != 'e')
            {
                read();
            }

            if (prav[1] != 'e')
            {
                button1.Enabled = true;
                button2.Enabled = true;
                button3.Enabled = true;
                button4.Enabled = true;
            }
        }

        private void read()
        {
            List<films> filmsList = serverRequest.Get_films();
            if (filmsList.Count > 0)
            {
                foreach(films filmElem in filmsList)
                    dataGridView1.Rows.Add(filmElem.id_film, filmElem.avtor, filmElem.nazvanie, filmElem.annotacia, filmElem.strana, filmElem.god, filmElem.zhanr);
            }
            else
            {
                MessageBox.Show(
                "Нет данных для вывода на экран",
                "Сообщение",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information,
                MessageBoxDefaultButton.Button1,
                MessageBoxOptions.DefaultDesktopOnly);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            serverRequest.Insert_film(textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text, Convert.ToInt32(textBox5.Text), textBox6.Text);
            dataGridView1.Rows.Add(Convert.ToInt32(dataGridView1[0, dataGridView1.Rows.Count-1].Value) + 1, textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text, textBox5.Text, textBox6.Text);
        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (!edl.Contains(e.RowIndex))
            {
                edl.Add(e.RowIndex);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < edl.Count; i++)
            {
                serverRequest.Update_film(dataGridView1[0, Convert.ToInt32(edl[i])].Value.ToString(), dataGridView1[1, Convert.ToInt32(edl[i])].Value.ToString(), dataGridView1[2, Convert.ToInt32(edl[i])].Value.ToString(), dataGridView1[3, Convert.ToInt32(edl[i])].Value.ToString(), dataGridView1[4, Convert.ToInt32(edl[i])].Value.ToString(), dataGridView1[5, Convert.ToInt32(edl[i])].Value.ToString(), dataGridView1[6, Convert.ToInt32(edl[i])].Value.ToString());
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                serverRequest.Delete_film(dataGridView1[0, dataGridView1.CurrentRow.Index].Value.ToString());
                dataGridView1.Rows.Remove(dataGridView1.CurrentRow);
            }
            catch
            {
                MessageBox.Show(
                "Нельзя удалить запись",
                "Сообщение",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information,
                MessageBoxDefaultButton.Button1,
                MessageBoxOptions.DefaultDesktopOnly);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
