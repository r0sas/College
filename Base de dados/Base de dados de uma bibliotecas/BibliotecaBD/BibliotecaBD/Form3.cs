using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace BibliotecaBD
{
    public partial class Form3 : Form
    {
        private SqlConnection cn;
        private int currentSala;
        public bool aluno = false;
        public bool logged_in = false;
        public string user_cc;
        public Form3()
        {
            InitializeComponent();
        }

        private SqlConnection getSGBDConnection()
        {
            return new SqlConnection("data source=DESKTOP-26KGO20;integrated security=true;initial catalog=ProjetoBD");
        }

        private bool verifySGBDConnection()
        {
            if (cn == null)
                cn = getSGBDConnection();

            if (cn.State != ConnectionState.Open)
                cn.Open();

            return cn.State == ConnectionState.Open;
        }


        private void loadSalas()
        {
            if (!verifySGBDConnection())
                return;

            SqlCommand cmd = new SqlCommand("SELECT * FROM Biblioteca.Sala", cn);
            SqlDataReader reader = cmd.ExecuteReader();
            listBox1.Items.Clear();
            while (reader.Read())
            {
                if (disponiveis_check.Checked == true)
                {
                    if (reader["chave"].ToString().Equals("Não"))
                    {
                        continue;
                    }
                }
                Sala S = new Sala();
                S.SalaEdificio = reader["num_edificio"].ToString();
                S.SalaPiso = reader["piso"].ToString();
                S.SalaId = reader["id_no_piso"].ToString();
                S.SalaChave = reader["chave"].ToString();
                listBox1.Items.Add(S);

            }
            cn.Close();

            currentSala = 0;
            ShowSala();
        }
        private void ShowSala()
        {
            if (listBox1.Items.Count == 0 | currentSala < 0)
                return;
            Sala S = new Sala();
            S = (Sala)listBox1.Items[currentSala];
            edificio_text.Text = S.SalaEdificio;
            piso_txt.Text = S.SalaPiso;
            num_sala_txt.Text = S.SalaId;
            if (S.SalaChave.Equals("Sim"))
            {
                chave_txt.Text = "Disponivel";
            }
            else
            {
                chave_txt.Text = "Ocupada";
            }
        }



        private void disponiveis_check_CheckedChanged(object sender, EventArgs e)
        {
            loadSalas();
        }

        private void requisitarSala()
        {
            if (!verifySGBDConnection())
                return;

            SqlCommand cmd = new SqlCommand("requisitarSala", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@num_cc", user_cc);
            cmd.Parameters.AddWithValue("@num_edificio", edificio_text.Text);
            cmd.Parameters.AddWithValue("piso", piso_txt.Text);
            cmd.Parameters.AddWithValue("@id_no_piso", num_sala_txt.Text);
            cmd.ExecuteNonQuery();
            cmd.Connection = cn;

            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to update contact in database. \n ERROR MESSAGE: \n" + ex.Message);
            }
            finally
            {
                cn.Close();
            }
        }

        private void requisitar_btn_Click(object sender, EventArgs e)
        {
            requisitarSala();
            loadSalas();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            cn = getSGBDConnection();
            edificio_text.Enabled = false;
            piso_txt.Enabled = false;
            num_sala_txt.Enabled = false;
            chave_txt.Enabled = false;
            loadSalas();
            if (logged_in == false || aluno == false)
            {
                requisitar_btn.Visible = false;
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex > 0)
            {
                currentSala = listBox1.SelectedIndex;
                ShowSala();
            }
        }
    }
}
