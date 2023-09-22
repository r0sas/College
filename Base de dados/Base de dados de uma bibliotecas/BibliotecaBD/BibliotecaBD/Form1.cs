using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace BibliotecaBD
{
    public partial class Form1 : Form
    {
        private SqlConnection cn;
        public bool bibliotecario = false;
        public bool aluno = false;
        public string aluno_cc;
        public bool logged_in = false;
        public Form1()
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

        private void CheckUser()
        {
            if (!verifySGBDConnection())
                return;

            SqlCommand cmd = new SqlCommand("SELECT * FROM Biblioteca.AppLogIn ", cn);
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                String user_email = reader["email"].ToString();
                String user_pass = reader["pass"].ToString();
                if (email_txt.Text.Equals(user_email) && password_txt.Text.Equals(user_pass))
                {
                    checkPermissions();
                    checkAluno();
                    getAlunoCC();
                    getUserName();
                    loggedInControls();
                }
            }

            cn.Close();

        }

        private void RegisterUser()
        {
            if (!verifySGBDConnection())
                return;

            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "Insert Biblioteca.AppLogIn (email,pass)" + "VALUES (@email, @pass)";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@email", email_txt.Text);
            cmd.Parameters.AddWithValue("@pass", password_txt.Text);
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

        private void checkPermissions()
        {
            cn = new SqlConnection("data source=DESKTOP-26KGO20;integrated security=true;initial catalog=ProjetoBD");
            cn.Open();
            SqlCommand cmd = new SqlCommand("Permissions", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@email", email_txt.Text);
            cmd.Parameters.Add("@return", System.Data.SqlDbType.Int).Direction = System.Data.ParameterDirection.ReturnValue;
            cmd.ExecuteNonQuery();
            int returnValue = (int)cmd.Parameters["@return"].Value;
            if (returnValue == 1)
            {
                bibliotecario = true;
            }
            cn.Close();
        }

        private void checkAluno()
        {
            if (!verifySGBDConnection())
                return;
            SqlCommand cmd = new SqlCommand("checkAluno", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@email", email_txt.Text);
            cmd.Parameters.Add("@return", System.Data.SqlDbType.Int).Direction = System.Data.ParameterDirection.ReturnValue;
            cmd.ExecuteNonQuery();
            int returnValue = (int)cmd.Parameters["@return"].Value;
            if (returnValue == 1)
            {
                aluno = true;
            }
            cn.Close();
        }

        private void getUserName()
        {
            cn = new SqlConnection("data source=DESKTOP-26KGO20;integrated security=true;initial catalog=ProjetoBD");
            cn.Open();
            SqlCommand cmd = new SqlCommand("GetUserName", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@email", email_txt.Text);
            cmd.Parameters.Add("@nome", SqlDbType.VarChar, 40);
            cmd.Parameters["@nome"].Direction = ParameterDirection.Output;
            cmd.ExecuteNonQuery();
            string username = Convert.ToString(cmd.Parameters["@nome"].Value);
            if (bibliotecario)
            {
                label3.Text = "Bibliotecário: " + username;
            }
            else
            {
                label3.Text = "Utilizador: " + username;
            }
            cn.Close();
        }

        private void getAlunoCC()
        {
            if (!verifySGBDConnection())
                return;
            SqlCommand cmd = new SqlCommand("getAlunoCC", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@email", email_txt.Text);
            cmd.Parameters.Add("@num_cc", SqlDbType.VarChar, 40);
            cmd.Parameters["@num_cc"].Direction = ParameterDirection.Output;
            cmd.ExecuteNonQuery();
            aluno_cc = Convert.ToString(cmd.Parameters["@num_cc"].Value);
            cn.Close();
        }

        private void loggedInControls()
        {
            label3.Visible = true;
            log_out_btn.Visible = true;
            sign_up_btn.Visible = false;
            log_in_btn.Visible = false;
            email_txt.Visible = false;
            password_txt.Visible = false;
            label1.Visible = false;
            label2.Visible = false;
            
            if (bibliotecario || aluno)
            {
                button4.Visible = true;
            }
        }

        private void loggedOutControls()
        {
            label3.Visible = false;
            log_out_btn.Visible = false;
            sign_up_btn.Visible = true;
            log_in_btn.Visible = true;
            email_txt.Visible = true;
            password_txt.Visible = true;
            label1.Visible = true;
            label2.Visible = true;
            button4.Visible = false;
        }

        private void log_in_btn_Click(object sender, EventArgs e)
        {
            CheckUser();
            logged_in = true;
            getAlunoCC();
        }

        private void sign_up_btn_Click(object sender, EventArgs e)
        {
            RegisterUser();
        }

        private void livros_btn_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.bibliotecario = bibliotecario;
            f2.logged_in = logged_in;
            f2.user_cc = aluno_cc;
            f2.ShowDialog();
        }

        private void salas_btn_Click(object sender, EventArgs e)
        {
            Form3 f3 = new Form3();
            f3.logged_in = logged_in;
            f3.aluno = aluno;
            f3.user_cc = aluno_cc;
            f3.ShowDialog();
        }

        private void log_out_btn_Click(object sender, EventArgs e)
        {
            bibliotecario = false;
            loggedOutControls();
            logged_in = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form4 f4 = new Form4();
            if (aluno)
            {
                f4.aluno = aluno;
            }
            if (bibliotecario)
            {
                f4.bibliotecario = bibliotecario;
            }
            f4.aluno_cc = aluno_cc;
            f4.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form5 f5 = new Form5();
            if (aluno)
            {
                f5.aluno = aluno;
            }
            if (bibliotecario)
            {
                f5.bibliotecario = bibliotecario;
            }
            f5.aluno_cc = aluno_cc;
            f5.ShowDialog();
        }

        private void horario_btn_Click(object sender, EventArgs e)
        {
            Form f6 = new Form6();
            f6.ShowDialog();
        }
    }
}
