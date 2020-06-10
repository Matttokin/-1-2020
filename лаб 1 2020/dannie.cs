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
    public partial class dannie : Form
    {
        ArrayList edl = new ArrayList();

        public dannie(int id_polz)
        {
            InitializeComponent();

            string prav = SendRequests.get_rules_and_othr(id_polz, 3);

            if (prav[0] != '0')
            {
                read();
            }

            if (prav[1] != '0')
            {
                button1.Enabled = true;
                button2.Enabled = true;
            }
        }

        private void read()
        {
            OracleDataReader d = SendRequests.send("SELECT * FROM data_lists");

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
                OracleDataReader d = SendRequests.send("UPDATE data_lists SET name = '" + dataGridView1[1, Convert.ToInt32(edl[i])].Value.ToString() + "', uroven_kritichnosi = '" + dataGridView1[2, Convert.ToInt32(edl[i])].Value.ToString() + "' WHERE id_table = " + dataGridView1[0, Convert.ToInt32(edl[i])].Value.ToString());
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
