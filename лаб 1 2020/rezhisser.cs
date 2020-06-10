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
    public partial class rezhisser : Form
    {
        ArrayList edl = new ArrayList();

        public rezhisser(int id_polz)
        {
            InitializeComponent();

            string prav = SendRequests.get_rules_and_othr(id_polz, 1);

            if (prav[0] != '0')
            {
                read();
            }

            if (prav[1] != '0')
            {
                button1.Enabled = true;
                button2.Enabled = true;
                button3.Enabled = true;
                button4.Enabled = true;
            }
        }

        private void read()
        {
            OracleDataReader d = SendRequests.send("SELECT * FROM rezhisser");

            if (d.HasRows)
            {
                while (d.Read())
                    dataGridView1.Rows.Add(d.GetInt32(0), d.GetString(1), d.GetInt32(2));
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
            OracleDataReader d = SendRequests.send("INSERT INTO rezhisser VALUES ( (SELECT nvl(MAX(ID_REZH) + 1, 1) FROM rezhisser), '" + textBox1.Text + "', " + textBox2.Text + " )");
            dataGridView1.Rows.Add(Convert.ToInt32(dataGridView1[0, dataGridView1.Rows.Count - 1].Value) + 1, textBox1.Text, textBox2.Text);
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
                OracleDataReader d = SendRequests.send("UPDATE rezhisser SET fio = '" + dataGridView1[1, Convert.ToInt32(edl[i])].Value.ToString() + "', god_rozhdenia = '" + dataGridView1[2, Convert.ToInt32(edl[i])].Value.ToString() + "' WHERE id_rezh = " + dataGridView1[0, Convert.ToInt32(edl[i])].Value.ToString());
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                OracleDataReader d = SendRequests.send("DELETE FROM rezhisser WHERE id_rezh = " + dataGridView1[0, dataGridView1.CurrentRow.Index].Value.ToString());
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
