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
    public partial class user_lists : Form
    {
        ArrayList edl = new ArrayList();

        ArrayList role = new ArrayList();
        ArrayList roleid = new ArrayList();

        public user_lists(int id_polz)
        {
            InitializeComponent();

            string prav = serverRequest.get_rules_and_othr(id_polz, 4);

            addRolelist();

            comboBox1.DataSource = role;

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
            List<users> usersList = serverRequest.Get_users();
            var column = dataGridView1.Columns[4] as DataGridViewComboBoxColumn;

            column.DataSource = role;

            if (usersList.Count > 0)
            {
                foreach (users userElem in usersList)
                    dataGridView1.Rows.Add(userElem.id_user, userElem.login, userElem.password, userElem.data, role[get_id(userElem.role)]);
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
            serverRequest.Insert_user(textBox1.Text, textBox2.Text, roleid[get_idstr(comboBox1.Text)].ToString());
             dataGridView1.Rows.Add(Convert.ToInt32(dataGridView1[0, dataGridView1.Rows.Count - 1].Value) + 1, textBox1.Text, textBox2.Text, DateTime.Today.ToShortDateString(), role[get_idstr(comboBox1.Text)]);
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
                serverRequest.Update_user(dataGridView1[0, Convert.ToInt32(edl[i])].Value.ToString(), dataGridView1[1, Convert.ToInt32(edl[i])].Value.ToString(), dataGridView1[2, Convert.ToInt32(edl[i])].Value.ToString(), roleid[get_idstr(dataGridView1[4, Convert.ToInt32(edl[i])].Value.ToString())].ToString());
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                serverRequest.Delete_user(dataGridView1[0, dataGridView1.CurrentRow.Index].Value.ToString());
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

        private void addRolelist()
        {
            List<roles> listRoles = serverRequest.Get_role();

            if (listRoles.Count > 0)
            {
                foreach(roles roleElem in listRoles)
                {
                    roleid.Add(roleElem.id_role);
                    role.Add(roleElem.name);
                }
            }
            else
            {
                MessageBox.Show(
                "Нет данных о ролях пользователей",
                "Сообщение",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information,
                MessageBoxDefaultButton.Button1,
                MessageBoxOptions.DefaultDesktopOnly);
            }
        }

        private int get_id(int n)
        {
            int a = roleid.IndexOf(n);
            return a;
        }

        private int get_idstr (string n)
        {
            int a = role.IndexOf(n);
            return a;
        }
    }
}
