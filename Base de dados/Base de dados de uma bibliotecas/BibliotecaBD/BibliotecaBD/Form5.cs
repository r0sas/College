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
    public partial class Form5 : Form
    {
        private string bibliotecario_id;
        public bool aluno = false;
        public string aluno_cc;
        private SqlConnection cn;
        public bool bibliotecario = false;
        public Form5()
        {
            InitializeComponent();
        }

        private void loadSalasTransactions()
        {
            listView1.Items.Clear();
            if (!verifySGBDConnection())
                return;
            using (SqlDataAdapter da = new SqlDataAdapter())
            {
                da.SelectCommand = new SqlCommand("getSalasRequisitadas", cn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;

                DataSet ds = new DataSet();
                da.Fill(ds, "SalasRequisitadas");

                DataTable dt = ds.Tables["SalasRequisitadas"];

                foreach (DataRow row in dt.Rows)
                {
                    string[] arr = { row[0].ToString(), row[4].ToString(), row[5].ToString(), row[1].ToString(), row[2].ToString(), row[3].ToString(), row[6].ToString(), row[7].ToString() };
                    ListViewItem item;
                    item = new ListViewItem(arr);
                    listView1.Items.Add(item);

                }
            }
        }
        private void searchSalaByName()
        {
            listView1.Items.Clear();
            string[] sala_name = searchBar.Text.Split(".");
            if (!verifySGBDConnection())
                return;
            using (SqlDataAdapter da = new SqlDataAdapter())
            {
                da.SelectCommand = new SqlCommand("searchSalaByName", cn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@num_edificio", sala_name[0]);
                da.SelectCommand.Parameters.AddWithValue("@piso", sala_name[1]);
                da.SelectCommand.Parameters.AddWithValue("@id_no_piso", sala_name[2]);
                DataSet ds = new DataSet();
                da.Fill(ds, "SalasRequisitadasByName");

                DataTable dt = ds.Tables["SalasRequisitadasByName"];

                foreach (DataRow row in dt.Rows)
                {
                    string[] arr = { row[0].ToString(), row[4].ToString(), row[5].ToString(), row[1].ToString(), row[2].ToString(), row[3].ToString(), row[6].ToString(), row[7].ToString() };
                    ListViewItem item;
                    item = new ListViewItem(arr);
                    listView1.Items.Add(item);

                }
            }
        }

        private void searchUserSalaByName()
        {
            listView1.Items.Clear();
            string[] sala_name = searchBar.Text.Split(".");
            if (!verifySGBDConnection())
                return;
            using (SqlDataAdapter da = new SqlDataAdapter())
            {
                da.SelectCommand = new SqlCommand("searchUserSalaByName", cn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@num_edificio", sala_name[0]);
                da.SelectCommand.Parameters.AddWithValue("@piso", sala_name[1]);
                da.SelectCommand.Parameters.AddWithValue("@id_no_piso", sala_name[2]);
                da.SelectCommand.Parameters.AddWithValue("@num_cc", aluno_cc);
                DataSet ds = new DataSet();
                da.Fill(ds, "UserSalasRequisitadasByName");

                DataTable dt = ds.Tables["UserSalasRequisitadasByName"];

                foreach (DataRow row in dt.Rows)
                {
                    string[] arr = { row[0].ToString(), row[4].ToString(), row[5].ToString(), row[1].ToString(), row[2].ToString(), row[3].ToString(), row[6].ToString(), row[7].ToString() };
                    ListViewItem item;
                    item = new ListViewItem(arr);
                    listView1.Items.Add(item);

                }
            }
        }

        private void searchSalaByID()
        {
            listView1.Items.Clear();
            if (!verifySGBDConnection())
                return;
            using (SqlDataAdapter da = new SqlDataAdapter())
            {
                da.SelectCommand = new SqlCommand("searchSalaByID", cn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@cod_req", searchBar.Text);
                da.SelectCommand.Parameters.AddWithValue("@num_cc", aluno_cc);
                DataSet ds = new DataSet();
                da.Fill(ds, "SalasRequisitadasByID");

                DataTable dt = ds.Tables["SalasRequisitadasByID"];

                foreach (DataRow row in dt.Rows)
                {
                    string[] arr = { row[0].ToString(), row[4].ToString(), row[5].ToString(), row[1].ToString(), row[2].ToString(), row[3].ToString(), row[6].ToString(), row[7].ToString() };
                    ListViewItem item;
                    item = new ListViewItem(arr);
                    listView1.Items.Add(item);

                }
            }
        }

        private void searchUserSalaByID()
        {
            listView1.Items.Clear();
            if (!verifySGBDConnection())
                return;
            using (SqlDataAdapter da = new SqlDataAdapter())
            {
                da.SelectCommand = new SqlCommand("searchUserSalaByID", cn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@cod_req", searchBar.Text);
                da.SelectCommand.Parameters.AddWithValue("@num_cc", aluno_cc);
                DataSet ds = new DataSet();
                da.Fill(ds, "UserSalasRequisitadasByID");

                DataTable dt = ds.Tables["UserSalasRequisitadasByID"];

                foreach (DataRow row in dt.Rows)
                {
                    string[] arr = { row[0].ToString(), row[4].ToString(), row[5].ToString(), row[1].ToString(), row[2].ToString(), row[3].ToString(), row[6].ToString(), row[7].ToString() };
                    ListViewItem item;
                    item = new ListViewItem(arr);
                    listView1.Items.Add(item);

                }
            }
        }

        private void searchSalaByUser()
        {
            listView1.Items.Clear();
            if (!verifySGBDConnection())
                return;
            using (SqlDataAdapter da = new SqlDataAdapter())
            {
                da.SelectCommand = new SqlCommand("searchSalaByUser", cn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@n_mec", searchBar.Text);
                DataSet ds = new DataSet();
                da.Fill(ds, "SalasRequisitadasByUser");

                DataTable dt = ds.Tables["SalasRequisitadasByUser"];

                foreach (DataRow row in dt.Rows)
                {
                    string[] arr = { row[0].ToString(), row[4].ToString(), row[5].ToString(), row[1].ToString(), row[2].ToString(), row[3].ToString(), row[6].ToString(), row[7].ToString() };
                    ListViewItem item;
                    item = new ListViewItem(arr);
                    listView1.Items.Add(item);

                }
            }
        }

        private void searchUserSalas()
        {
            listView1.Items.Clear();
            if (!verifySGBDConnection())
                return;
            using (SqlDataAdapter da = new SqlDataAdapter())
            {
                da.SelectCommand = new SqlCommand("searchUserSalas", cn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@num_cc", aluno_cc);
                DataSet ds = new DataSet();
                da.Fill(ds, "SalasRequisitadasByUser");

                DataTable dt = ds.Tables["SalasRequisitadasByUser"];

                foreach (DataRow row in dt.Rows)
                {
                    string[] arr = { row[0].ToString(), row[4].ToString(), row[5].ToString(), row[1].ToString(), row[2].ToString(), row[3].ToString(), row[6].ToString(), row[7].ToString() };
                    ListViewItem item;
                    item = new ListViewItem(arr);
                    listView1.Items.Add(item);

                }
            }
        }

        private void entregarSalaByUser()
        {
            if (!verifySGBDConnection())
                return;

            String edificio = listView1.SelectedItems[0].SubItems[3].Text;
            String piso = listView1.SelectedItems[0].SubItems[4].Text;
            String id_no_piso = listView1.SelectedItems[0].SubItems[5].Text;
            SqlCommand cmd = new SqlCommand("entregarSalaByUser", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@num_cc", aluno_cc);
            cmd.Parameters.AddWithValue("@num_edificio", edificio);
            cmd.Parameters.AddWithValue("@piso", piso);
            cmd.Parameters.AddWithValue("@id_no_piso", id_no_piso);
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

        private void entregarSalaByBibliotecario()
        {
            if (!verifySGBDConnection())
                return;

            String edificio = listView1.SelectedItems[0].SubItems[3].Text;
            String piso = listView1.SelectedItems[0].SubItems[4].Text;
            String id_no_piso = listView1.SelectedItems[0].SubItems[5].Text;
            SqlCommand cmd = new SqlCommand("entregarSalaByBibliotecario", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@num_cc", aluno_cc);
            cmd.Parameters.AddWithValue("@num_edificio", edificio);
            cmd.Parameters.AddWithValue("@piso", piso);
            cmd.Parameters.AddWithValue("@id_no_piso", id_no_piso);
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

        private void Form5_Load(object sender, EventArgs e)
        {
            listView1.View = View.Details;
            listView1.FullRowSelect = true;

            //Add column header
            listView1.Columns.Add("Id", 50);
            listView1.Columns.Add("Bibliotecário", 80);
            listView1.Columns.Add("Requisitante", 80);
            listView1.Columns.Add("Edificio", 80);
            listView1.Columns.Add("Piso", 50);
            listView1.Columns.Add("Número", 80);
            listView1.Columns.Add("Data", 140);
            listView1.Columns.Add("Operação", 140);
            cn = getSGBDConnection();
            if (aluno)
            {
                searchUserSalas();
            }
            else if (bibliotecario)
            {
                getBibliotecarioID();
                loadSalasTransactions();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(searchBar.Text) == false)
            {
                if (box_selected.Text.Equals("Sala"))
                {
                    if (aluno)
                    {
                        searchUserSalaByName();
                    }
                    else
                    {
                        searchSalaByName();
                    }
                }
                else if (box_selected.Text.Equals("ID"))
                {
                    if (aluno)
                    {
                        searchUserSalaByID();
                    }
                    else
                    {
                        searchSalaByID();
                    }
                }
                else if (box_selected.Text.Equals("Requisitante"))
                {
                    if (aluno)
                    {
                        searchUserSalas();
                    }
                    else
                    {
                        searchSalaByUser();
                    }
                }
            }
            else if (bibliotecario)
            {
                loadSalasTransactions();
            }
            else
            {
                searchUserSalas();
            }
        }

        private void entregar_btn_Click(object sender, EventArgs e)
        {
            if (bibliotecario)
            {
                entregarSalaByBibliotecario();
                loadSalasTransactions();
            }
            else
            {
                entregarSalaByUser();
                searchUserSalas();
            }
        }
    }
}
