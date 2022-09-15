using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WF_MySql_pizzerria
{
    public partial class Form1 : Form
    {
        //faze de novo essa parte pra aprende
        MySqlConnection con;
        MySqlCommand command;
        MySqlDataReader reader;
        public Form1()
        {
            InitializeComponent();
            con = new MySqlConnection("Server=localhost;Database=pizzeriadb;User=root;Pwd=;SslMode=none");
        }

        class Dados
        {
            public string nome { get; set; }
            public DateTime  data_nascimento { get; set; }
            public string telefone { get; set; }
            public string ddd { get; set; }
            public string complemento { get; set; }
            public string CEP { get; set; }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<Dados> listaNomes = new List<Dados>();
            //Popular a lista atraves do select do banco de dados
            command = new MySqlCommand();
            con.Open();
            command.Connection = con;
            command.CommandText = "Select nome_completo,data_nascimento,telefone,ddd,complemento,CEP from cliente";
            reader = command.ExecuteReader();

            while (reader.Read())
            {
                Dados nome = new Dados();

                nome.nome = reader["nome_completo"].ToString();
                nome.data_nascimento = Convert.ToDateTime(reader["data_nascimento"].ToString());
                nome.telefone = reader["telefone"].ToString();
                nome.ddd = reader["ddd"].ToString();
                nome.complemento = reader["complemento"].ToString();
                nome.CEP = reader["CEP"].ToString();

                ListViewItem Nome = new ListViewItem();


                Nome.Text = nome.nome;
                Nome.SubItems.Add(nome.CEP);
                Nome.SubItems.Add(nome.data_nascimento.ToString("dd/MM/yyyy"));
                Nome.SubItems.Add(nome.ddd);
                Nome.SubItems.Add(nome.telefone);
                Nome.SubItems.Add(nome.complemento);
                

                listView1.Items.Add(Nome);

            }
            con.Close();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
