using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;

namespace лаб_1_2020
{
    public partial class Form1 : Form
    {

        private string login_local;
        private string id_local;
        private string dif;
        public string old_pas;
        private string new_password;

        OracleConnection conn;

        public Form1()
        {
            db.connect();

            conn = db.conn;

            InitializeComponent();

            button3.Enabled = false;
        }

        private void Войти_Click(object sender, EventArgs e)
        {

            login_local = LoginBox.Text;

            id_local = serverRequest.Poisk_id_po_loginu(login_local);
            if (id_local != (-1).ToString())
            {

                if (!id_local.Equals("-9"))
                {


                    old_pas = serverRequest.Poisk_password_po_id(id_local);

                    if (PasswordBox.Text.Equals(old_pas))
                    {

                        string data_izm = serverRequest.Get_data_izmenenia(login_local);
                        MessageBox.Show("Success");
                        MessageBox.Show(data_izm);



                        dif = serverRequest.Get_dif1(login_local);
                        float flt1 = float.Parse(dif);
                        if (flt1 > 1)
                        {
                            MessageBox.Show("Change Password");
                            textBox1.Visible = true;
                            button1.Visible = true;


                        }
                        else
                        {
                            MessageBox.Show("Vse norm");
                        }
                    }
                    else
                    {
                        MessageBox.Show("smth wrong");
                    };

                    button3.Enabled = true;

                }
                else {
                    MessageBox.Show("smth wrong");
                }
                
            }
        }
    
        private void button1_Click(object sender, EventArgs e)
        {
            new_password = textBox1.Text;
            serverRequest.Update_password(id_local, new_password);
            MessageBox.Show("Success");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form syschnoste = new syshnoste(Convert.ToInt32(id_local));

            syschnoste.Show();

        }
    }
}


    

