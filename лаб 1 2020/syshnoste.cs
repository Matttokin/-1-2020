using Oracle.ManagedDataAccess.Client;
using System;
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
    public partial class syshnoste : Form
    {
        int id_polzov;

        public syshnoste(int id_pol)
        {
            InitializeComponent();

            id_polzov = id_pol;

            List<int> buttonList = serverRequest.syshnoste(id_pol.ToString());

            
                foreach(int elemList in buttonList)
                {
                    switch (elemList)
                    {
                        case 0:
                            button1.Enabled = true;
                            break;
                        case 1:
                            button2.Enabled = true;
                            break;
                        case 2:
                            button3.Enabled = true;
                            break;
                        case 3:
                            button4.Enabled = true;
                            break;
                        case 4:
                            button5.Enabled = true;
                            break;
                        case 5:
                            button6.Enabled = true;
                            break;
                    }
                }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form filmssss = new film(id_polzov);
            filmssss.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form rezhisseriii = new rezhisser(id_polzov);
            rezhisseriii.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form stranaaa = new strana(id_polzov);
            stranaaa.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form dannieeee = new dannie(id_polzov);
            dannieeee.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form useryyy = new user_lists(id_polzov);
            useryyy.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form roooleee = new role(id_polzov);
            roooleee.Show();
        }
    }
}
