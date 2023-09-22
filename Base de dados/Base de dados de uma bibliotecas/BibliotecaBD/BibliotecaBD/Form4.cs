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
    public partial class Form4 : Form
    {
        public bool aluno = false;
        public string aluno_cc;
        public bool bibliotecario = false;
        private string bibliotecario_id;
        private SqlConnection cn;
        public Form4()
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
        private void loadLivroTransactions()
        {
            listView1.Items.Clear();
            if (!verifySGBDConnection())
                return;
            using (SqlDataAdapter da = new SqlDataAdapter())
            {
                da.SelectCommand = new SqlCommand("getLivrosRequisitados", cn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;

                DataSet ds = new DataSet();
                da.Fill(ds, "LivrosRequisitados");

                DataTable dt = ds.Tables["LivrosRequisitados"];

                foreach (DataRow row in dt.Rows)
                {
                    string[] arr = { row[1].ToString(), row[4].ToString(), row[6].ToString(), row[7].ToString(), row[0].ToString(), row[5].ToString(), row[3].ToString(), row[2].ToString() };
                    ListViewItem item;
                    item = new ListViewItem(arr);
                    listView1.Items.Add(item);

                }
            }
            cn.Close();
        }

        private void getLivrosRequisitadosByTitle()
        {
            listView1.Items.Clear();
            if (!verifySGBDConnection())
                return;
            using (SqlDataAdapter da = new SqlDataAdapter())
            {
                da.SelectCommand = new SqlCommand("getLivrosRequisitadosByTitle", cn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@titulo", searchBar.Text);
                DataSet ds = new DataSet();
                da.Fill(ds, "getLivrosRequisitadosByTitle");

                DataTable dt = ds.Tables["getLivrosRequisitadosByTitle"];

                foreach (DataRow row in dt.Rows)
                {
                    string[] arr = { row[1].ToString(), row[4].ToString(), row[6].ToString(), row[7].ToString(), row[0].ToString(), row[5].ToString(), row[3].ToString(), row[2].ToString() };
                    ListViewItem item;
                    item = new ListViewItem(arr);
                    listView1.Items.Add(item);

                }
            }
        }

        private void getUserLivrosRequisitadosByTitle()
        {
            listView1.Items.Clear();
            if (!verifySGBDConnection())
                return;
            using (SqlDataAdapter da = new SqlDataAdapter())
            {
                da.SelectCommand = new SqlCommand("getUserLivrosRequisitadosByTitle", cn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@titulo", searchBar.Text);
                da.SelectCommand.Parameters.AddWithValue("@num_cc", aluno_cc);
                DataSet ds = new DataSet();
                da.Fill(ds, "getUserLivrosRequisitadosByTitle");

                DataTable dt = ds.Tables["getUserLivrosRequisitadosByTitle"];

                foreach (DataRow row in dt.Rows)
                {
                    string[] arr = { row[1].ToString(), row[4].ToString(), row[6].ToString(), row[7].ToString(), row[0].ToString(), row[5].ToString(), row[3].ToString(), row[2].ToString() };
                    ListViewItem item;
                    item = new ListViewItem(arr);
                    listView1.Items.Add(item);

                }
            }
        }

        private void getLivrosRequisitadosByID()
        {
            listView1.Items.Clear();
            if (!verifySGBDConnection())
                return;
            using (SqlDataAdapter da = new SqlDataAdapter())
            {
                da.SelectCommand = new SqlCommand("getLivrosRequisitadosByID", cn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@num_req", searchBar.Text);
                DataSet ds = new DataSet();
                da.Fill(ds, "getLivrosRequisitadosByID");

                DataTable dt = ds.Tables["getLivrosRequisitadosByID"];

                foreach (DataRow row in dt.Rows)
                {
                    string[] arr = { row[1].ToString(), row[4].ToString(), row[6].ToString(), row[7].ToString(), row[0].ToString(), row[5].ToString(), row[3].ToString(), row[2].ToString() };
                    ListViewItem item;
                    item = new ListViewItem(arr);
                    listView1.Items.Add(item);

                }
            }
        }

        private void getUserLivrosRequisitadosByID()
        {
            listView1.Items.Clear();
            if (!verifySGBDConnection())
                return;
            using (SqlDataAdapter da = new SqlDataAdapter())
            {
                da.SelectCommand = new SqlCommand("getUserLivrosRequisitadosByID", cn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@num_req", searchBar.Text);
                da.SelectCommand.Parameters.AddWithValue("@num_cc", aluno_cc);
                DataSet ds = new DataSet();
                da.Fill(ds, "getUserLivrosRequisitadosByID");

                DataTable dt = ds.Tables["getUserLivrosRequisitadosByID"];

                foreach (DataRow row in dt.Rows)
                {
                    string[] arr = { row[1].ToString(), row[4].ToString(), row[6].ToString(), row[7].ToString(), row[0].ToString(), row[5].ToString(), row[3].ToString(), row[2].ToString() };
                    ListViewItem item;
                    item = new ListViewItem(arr);
                    listView1.Items.Add(item);

                }
            }
        }

        private void getLivrosRequisitadosByUser()
        {
            listView1.Items.Clear();
            if (!verifySGBDConnection())
                return;
            using (SqlDataAdapter da = new SqlDataAdapter())
            {
                da.SelectCommand = new SqlCommand("getLivrosRequisitadosByUser", cn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@num_cc", aluno_cc);
                if (bibliotecario)
                {
                    da.SelectCommand.Parameters.AddWithValue("@num_cc", searchBar.Text);
                }
                DataSet ds = new DataSet();
                da.Fill(ds, "getLivrosRequisitadosByUser");

                DataTable dt = ds.Tables["getLivrosRequisitadosByUser"];

                foreach (DataRow row in dt.Rows)
                {
                    string[] arr = { row[1].ToString(), row[4].ToString(), row[6].ToString(), row[7].ToString(), row[0].ToString(), row[5].ToString(), row[3].ToString(), row[2].ToString() };
                    ListViewItem item;
                    item = new ListViewItem(arr);
                    listView1.Items.Add(item);

                }
            }
        }

        private void entregarLivrosByUser()
        {
            if (!verifySGBDConnection())
                return;
            String codigo = listView1.SelectedItems[0].SubItems[3].Text;
            SqlCommand cmd = new SqlCommand("entregarLivroByUser", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@num_cc", aluno_cc);
            cmd.Parameters.AddWithValue("@codigo", codigo);
            cmd.Connection = cn;

            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to update in database. \n ERROR MESSAGE: \n" + ex.Message);
            }
            finally
            {
                cn.Close();
            }
        }

        private void renovarLivrosByUser()
        {
            if (!verifySGBDConnection())
                return;

            String codigo = listView1.SelectedItems[0].SubItems[3].Text;
            String cc = listView1.SelectedItems[0].SubItems[2].Text;
            SqlCommand cmd = new SqlCommand("renovarLivroByUser", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@num_cc", cc);
            cmd.Parameters.AddWithValue("@codigo", codigo);
            cmd.Connection = cn;

            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to update in database. \n ERROR MESSAGE: \n" + ex.Message);
            }
            finally
            {
                cn.Close();
            }
        }
        private void renovarLivrosByBibliotecario()
        {
            if (!verifySGBDConnection())
                return;

            String codigo = listView1.SelectedItems[0].SubItems[3].Text;
            String cc = listView1.SelectedItems[0].SubItems[2].Text;
            SqlCommand cmd = new SqlCommand("renovarLivroByBibliotecario", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@num_cc", cc);
            cmd.Parameters.AddWithValue("@codigo", codigo);
            cmd.Parameters.AddWithValue("@bibliotecario", bibliotecario_id);
            cmd.Connection = cn;

            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to update in database. \n ERROR MESSAGE: \n" + ex.Message);
            }
            finally
            {
                cn.Close();
            }
        }

        private void getBibliotecarioID()
        {
            if (!verifySGBDConnection())
                return;

            SqlCommand cmd = new SqlCommand("getBibliotecarioID", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@num_cc", aluno_cc);
            cmd.Parameters.Add("@id", SqlDbType.VarChar, 10);
            cmd.Parameters["@id"].Direction = ParameterDirection.Output;
            cmd.Connection = cn;
            cmd.ExecuteNonQuery();
            bibliotecario_id = Convert.ToString(cmd.Parameters["@id"].Value);
        }

        private void entregarLivrosByBibliotecario()
        {
            if (!verifySGBDConnection())
                return;

            String codigo = listView1.SelectedItems[0].SubItems[3].Text;
            String id = listView1.SelectedItems[0].SubItems[1].Text;
            SqlCommand cmd = new SqlCommand("entregarLivroByBibliotecario", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@num_cc", aluno_cc);
            cmd.Parameters.AddWithValue("@codigo", codigo);
            cmd.Parameters.AddWithValue("@bibliotecario", id);
            cmd.Connection = cn;

            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to update in database. \n ERROR MESSAGE: \n" + ex.Message);
            }
            finally
            {
                cn.Close();
            }
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            listView1.View = View.Details;
            listView1.FullRowSelect = true;

            //Add column header
            listView1.Columns.Add("Id", 50);
            listView1.Columns.Add("Bibliotecário", 80);
            listView1.Columns.Add("Requisitante", 80);
            listView1.Columns.Add("Codigo do Livro", 100);
            listView1.Columns.Add("Titulo", 180);
            listView1.Columns.Add("Data", 140);
            listView1.Columns.Add("Periodo (Dias)", 100);
            listView1.Columns.Add("Operação", 80);
            cn = getSGBDConnection();
            if (bibliotecario)
            {
                getBibliotecarioID();
                loadLivroTransactions();
            }
            else
            {
                getLivrosRequisitadosByUser();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            if (String.IsNullOrEmpty(searchBar.Text) == false)
            {
                if (box_selected.Text.Equals("Título"))
                {
                    if (bibliotecario)
                    {
                        getLivrosRequisitadosByTitle();
                    }
                    else
                    {
                        getUserLivrosRequisitadosByTitle();
                    }
                }
                else if (box_selected.Text.Equals("ID"))
                {
                    if (bibliotecario)
                    {
                        getLivrosRequisitadosByID();
                    }
                    else
                    {
                        getUserLivrosRequisitadosByID();
                    }
                }
                else if (box_selected.Text.Equals("Requisitante"))
                {
                    getLivrosRequisitadosByUser();
                }
            }
            else if (bibliotecario)
            {
                loadLivroTransactions();
            }
            else
            {
                getLivrosRequisitadosByUser();
            }
        }

        private void renovar_btn_Click(object sender, EventArgs e)
        {
            if (bibliotecario)
            {
                renovarLivrosByBibliotecario();
                loadLivroTransactions();
            }
            else
            {
                renovarLivrosByUser();
                getLivrosRequisitadosByUser();
            }
        }

        private void entregar_btn_Click(object sender, EventArgs e)
        {
            if (bibliotecario)
            {
                entregarLivrosByBibliotecario();
                loadLivroTransactions();
            }
            else
            {
                entregarLivrosByUser();
                getLivrosRequisitadosByUser();
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
