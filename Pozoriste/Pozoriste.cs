using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;

namespace Pozoriste
{
    public partial class Pozoriste : Form
    {
        string connectionString;
        SqlConnection connection;
        public Pozoriste()
        {
            InitializeComponent();
            connectionString = ConfigurationManager.ConnectionStrings["Pozoriste.Properties.Settings.Database1ConnectionString"].ConnectionString;

        }

        private void upit1_Click(object sender, EventArgs e)
        {
            string commandText = "select glu.IME,glu.PREZIME,pos.NAZIV_SEZONE " +
                                 "from GLUMAC glu join POSTAVA pos " +
                                    "on glu.GLUMID = pos.GLUMID " +
                                 "join PREDSTAVA pre " +
                                    "on pre.PREDID = pos.PREDID " +
                                 "where pre.NAZIV = 'Kir Janja' and pos.ULOGA = 'Kir Dime' " +
                                 "order by pos.NAZIV_SEZONE asc, glu.PREZIME desc ";
            using (connection = new SqlConnection(connectionString))
            using (SqlDataAdapter adapter = new SqlDataAdapter(commandText, connection))
            {
                DataTable tableOwn = new DataTable();
                adapter.Fill(tableOwn);
                dataGridView1.DataSource = tableOwn;
                connection.Close();

            }
        }
        private void upit2_Click(object sender, EventArgs e)
        {
            Button clickedButton2 = (Button)sender;
        }
        private void upit3_Click(object sender, EventArgs e)
        {
            Button clickedButton3 = (Button)sender;
        }
    }
}
