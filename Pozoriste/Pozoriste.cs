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
using System.Reflection;

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
            string commandText = "select TOP 1 rep.PREDID, pre.NAZIV " +
                                 "from REPERTOAR rep join PREDSTAVA pre " +
                                 "on rep.PREDID = pre.PREDID " +
                                 "where year(rep.DATUMIVREME) = year(getdate()) " +
                                 "group by rep.PREDID, pre.NAZIV " +
                                 "order by count(*) desc";
            using (connection = new SqlConnection(connectionString))
            using (SqlDataAdapter adapter = new SqlDataAdapter(commandText,connection))
            {
                DataTable tableOwn = new DataTable();
                adapter.Fill(tableOwn);
                dataGridView1.DataSource = tableOwn;
                connection.Close();
            }
        }
        private void upit3_Click(object sender, EventArgs e)
        {
            string commandText1 = "create view PREGLED_GLUMACA(GLUMACID,PREZIME,IME,BROJ_PREDSTAVA_08_09,BROJ_PREDSTAVA_09_10) as " +
                                        "with razlicite as( " +
                                        "	select pos.GLUMID uspeh " +
                                        "	from GLUMAC glu join POSTAVA pos " +
                                        "			on glu.GLUMID = pos.GLUMID " +
                                        "		 join PREDSTAVA pre " +
                                        "			on pre.PREDID = pos.PREDID " +
                                        "    group by pos.GLUMID " +
                                        "	having count(distinct pos.PREDID) >= 20), " +
                                        "pom1 as ( " +
                                        "	select pos.GLUMID idGlumca , " +
                                        "		 count(*) brPred " +
                                        "	from razlicite r join POSTAVA pos " +
                                        "		on r.uspeh = pos.GLUMID " +
                                        "	join PREDSTAVA pre " +
                                        "		on pre.PREDID = pos.PREDID " +
                                        "	where pos.NAZIV_SEZONE = '2008/2009' " +
                                        "		and pre.TIP = 'KOMEDIJA' " +
                                        "	group by pos.GLUMID), " +
                                        "pom2 as ( " +
                                        "	select pos.GLUMID idGlumca , " +
                                        "		count(*) brPred " +
                                        "	from razlicite r join POSTAVA pos " +
                                        "		on r.uspeh = pos.GLUMID " +
                                        "	join PREDSTAVA pre " +
                                        "		on pre.PREDID = pos.PREDID " +
                                        "	where pos.NAZIV_SEZONE = '2009/2010' " +
                                        "		and pre.TIP = 'KOMEDIJA' " +
                                        "	group by pos.GLUMID), " +
                                        "pom3 as ( " +
                                        "	select p1.idGlumca idGlumca " +
                                        " 	from pom1 p1 join pom2 p2 " +
                                        "		on p1.idGlumca = p2.idGlumca " +
                                        "	where p2.brPred > p1.brPred), " +
                                        "pom4 as ( " +
                                        "	select pos.GLUMID idGlumaca , " +
                                        "		count( " +
                                        "		case when pos.NAZIV_SEZONE = '2008/2009' then 1 " +
                                        "		else  null " +
                                        "		end) ukGodina1, " +
                                        "		count( " +
                                        "		case when pos.NAZIV_SEZONE = '2009/2010' then 1 " +
                                        "		else  null " +
                                        "		end) ukGodina2 " +
                                        "	from pom3 p3 join POSTAVA pos " +
                                        "		on p3.idGlumca = pos.GLUMID " +
                                        "	join PREDSTAVA pre " +
                                        "		on pre.PREDID = pos.PREDID " +
                                        "	group by pos.GLUMID) " +
                                        "select glu.GLUMID, glu.PREZIME, glu.IME, p4.ukGodina1, p4.ukGodina2 " +
                                        "from pom4 p4 join GLUMAC glu " +
                                        "	on p4.idGlumaca = glu.GLUMID ";
            string commandText2 = "select * from PREGLED_GLUMACA";
            string commandText3 = "DROP VIEW IF EXISTS PREGLED_GLUMACA";

            using (connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(commandText3, connection))
            {
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
            using (connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(commandText1, connection))
            {
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
            using (connection = new SqlConnection(connectionString))
            using (SqlDataAdapter adapter = new SqlDataAdapter(commandText2, connection))
            {
                DataTable tableOwn = new DataTable();
                adapter.Fill(tableOwn);
                dataGridView1.DataSource = tableOwn;
                connection.Close();
            }
           
        }

        private void Pozoriste_Load(object sender, EventArgs e)
        {
            string copyright, version;
            Assembly asm = Assembly.GetExecutingAssembly();
            copyright = ((AssemblyCopyrightAttribute)asm.GetCustomAttribute(typeof(AssemblyCopyrightAttribute))).Copyright;
            version = ((AssemblyFileVersionAttribute)asm.GetCustomAttribute(typeof(AssemblyFileVersionAttribute))).Version;
            info.Text = copyright + " v" + version;

            using (connection = new SqlConnection(connectionString))
            {
                connection.Close();
            }

        }
    }
}
