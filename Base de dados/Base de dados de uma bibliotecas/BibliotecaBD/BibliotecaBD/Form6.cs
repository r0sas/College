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
    public partial class Form6 : Form
    {
        private SqlConnection cn;
        public Form6()
        {
            InitializeComponent();
        }

        private void Form6_Load(object sender, EventArgs e)
        {
            lockTextBoxes();
            loadHorarioInstituição();
            loadHorarioNInstituição();
        }
        private SqlConnection getSGBDConnection()
        {
            return new SqlConnection("data source=DESKTOP-26KGO20;integrated security=true;initial catalog=ProjetoBD");
        }

        private void loadHorarioInstituição()
        {
            if (!verifySGBDConnection())
                return;
            using (SqlDataAdapter da = new SqlDataAdapter())
            {
                da.SelectCommand = new SqlCommand("getHorarioInstituicao", cn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataSet ds = new DataSet();
                da.Fill(ds, "getHorarioInstituicao");

                DataTable dt = ds.Tables["getHorarioInstituicao"];

                foreach (DataRow row in dt.Rows)
                {
                    s_semana_inicio.Text = row[0].ToString();
                    s_semana_fim.Text = row[1].ToString();
                    s_fds_inicio.Text = row[2].ToString();
                    s_fds_fim.Text = row[3].ToString();

                }
            }
        }

        private void loadHorarioNInstituição()
        {
            if (!verifySGBDConnection())
                return;
            using (SqlDataAdapter da = new SqlDataAdapter())
            {
                da.SelectCommand = new SqlCommand("getHorarioNInstituicao", cn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataSet ds = new DataSet();
                da.Fill(ds, "getHorarioNInstituicao");

                DataTable dt = ds.Tables["getHorarioNInstituicao"];

                foreach (DataRow row in dt.Rows)
                {
                    n_semana_inicio.Text = row[0].ToString();
                    n_semana_fim.Text = row[1].ToString();
                    n_fds_inicio.Text = row[2].ToString();
                    n_fds_fim.Text = row[3].ToString();

                }
            }
        }

        private void lockTextBoxes()
        {
            n_semana_fim.Enabled = false;
            n_semana_inicio.Enabled = false;
            n_fds_inicio.Enabled = false;
            n_fds_fim.Enabled = false;
            s_fds_inicio.Enabled = false;
            s_fds_fim.Enabled = false;
            s_semana_inicio.Enabled = false;
            s_semana_fim.Enabled = false;
        }

        private bool verifySGBDConnection()
        {
            if (cn == null)
                cn = getSGBDConnection();

            if (cn.State != ConnectionState.Open)
                cn.Open();

            return cn.State == ConnectionState.Open;
        }
    }
}
