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
    public partial class Form2 : Form
    {
        private SqlConnection cn;
        private int currentLivro;
        public bool bibliotecario = false;
        public bool logged_in = false;
        public string user_cc;
        private bool adding = false;
        private bool editing = false;
        public Form2()
        {
            InitializeComponent();
        }

        private void procurar_btn_Click(object sender, EventArgs e)
        {
            loadLivros();
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

        private void loadLivros()
        {
            if (!verifySGBDConnection())
                return;

            SqlCommand cmd = new SqlCommand("SELECT * FROM Biblioteca.Livro", cn);
            SqlDataReader reader = cmd.ExecuteReader();
            listBox1.Items.Clear();
            string box_selected = this.comboBox1.GetItemText(this.comboBox1.SelectedItem).ToLower();
            while (reader.Read())
            {
                Livro L = new Livro();
                L.LivroTitulo = reader["titulo"].ToString();
                L.LivroAutor = reader["autor"].ToString();
                L.LivroEditora = reader["editora"].ToString();
                L.LivroNome = reader["nome"].ToString();
                L.LivroQuantidade = Int16.Parse(reader["quantidade"].ToString());
                L.LivroCodigo = reader["codigo"].ToString();
                L.LivroPiso = reader["piso"].ToString();
                L.LivroCodigo = reader["codigo"].ToString();
                if (livros_disponiveis_chec.Checked == true)
                {
                    if (Int16.Parse(reader["quantidade"].ToString()) == 0)
                    {
                        continue;
                    }
                }
                if (String.IsNullOrEmpty(textBox1.Text) == false)
                {
                    if (box_selected.Equals("tema"))
                    {
                        box_selected = "nome";
                    }
                    string s = reader[box_selected].ToString();
                    if (s.Contains(textBox1.Text) == false)
                    {
                        continue;
                    }

                }
                listBox1.Items.Add(L);

            }
            cn.Close();
            currentLivro = 0;
            ShowLivro();

        }

        private void lockTextBoxes()
        {
            titulo_txt.Enabled = false;
            editora_txt.Enabled = false;
            autora_txt.Enabled = false;
            tema_txt.Enabled = false;
            quantidade_txt.Enabled = false;
            piso_txt.Enabled = false;
            codigo_text.Enabled = false;
        }

        private void unlockTextBoxes()
        {
            titulo_txt.Enabled = true;
            editora_txt.Enabled = true;
            autora_txt.Enabled = true;
            tema_txt.Enabled = true;
            quantidade_txt.Enabled = true;
            piso_txt.Enabled = true;
            codigo_text.Enabled = true;
        }

        private void ShowLivro()
        {
            if (listBox1.Items.Count == 0 | currentLivro < 0)
                return;
            Livro L = new Livro();
            L = (Livro)listBox1.Items[currentLivro];
            titulo_txt.Text = L.LivroTitulo;
            editora_txt.Text = L.LivroEditora;
            autora_txt.Text = L.LivroAutor;
            tema_txt.Text = L.LivroNome;
            quantidade_txt.Text = L.LivroQuantidade.ToString();
            piso_txt.Text = L.LivroPiso;
            codigo_text.Text = L.LivroCodigo;

        }

        private void clearTextBoxes()
        {
            titulo_txt.Text = String.Empty;
            autora_txt.Text = String.Empty;
            editora_txt.Text = String.Empty;
            tema_txt.Text = String.Empty;
            piso_txt.Text = String.Empty;
            codigo_text.Text = String.Empty;
            quantidade_txt.Text = String.Empty;
        }

        private void insertLivro()
        {
            if (!verifySGBDConnection())
                return;

            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "Insert Biblioteca.Livro (titulo,autor,editora,piso,nome,codigo,quantidade)" + "VALUES (@titulo, @autor,@editora,@piso,@nome,@codigo,@quantidade)";
            cmd.Parameters.Clear();

            cmd.Parameters.AddWithValue("@titulo", titulo_txt.Text);
            cmd.Parameters.AddWithValue("@autor", autora_txt.Text);
            cmd.Parameters.AddWithValue("@editora", editora_txt.Text);
            cmd.Parameters.AddWithValue("@piso", piso_txt.Text);
            cmd.Parameters.AddWithValue("@nome", tema_txt.Text);
            cmd.Parameters.AddWithValue("@codigo", codigo_text.Text);
            cmd.Parameters.AddWithValue("@quantidade", quantidade_txt.Text);
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

        private void updateLivro()
        {
            if (!verifySGBDConnection())
                return;

            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "Update Biblioteca.Livro SET titulo = @titulo, autor = @autor, editora = @editora, piso = @piso, nome = @nome, quantidade = @quantidade WHERE codigo = @codigo";
            cmd.Parameters.Clear();

            cmd.Parameters.AddWithValue("@titulo", titulo_txt.Text);
            cmd.Parameters.AddWithValue("@autor", autora_txt.Text);
            cmd.Parameters.AddWithValue("@editora", editora_txt.Text);
            cmd.Parameters.AddWithValue("@piso", piso_txt.Text);
            cmd.Parameters.AddWithValue("@nome", tema_txt.Text);
            cmd.Parameters.AddWithValue("@codigo", codigo_text.Text);
            cmd.Parameters.AddWithValue("@quantidade", quantidade_txt.Text);
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

        private void removeLivro()
        {
            if (!verifySGBDConnection())
                return;
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "DELETE Biblioteca.Livro WHERE codigo=@codigo ";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@codigo", codigo_text.Text);
            cmd.Connection = cn;

            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to delete contact in database. \n ERROR MESSAGE: \n" + ex.Message);
            }
            finally
            {
                cn.Close();
            }
        }

        private void requisitarLivro()
        {
            if (!verifySGBDConnection())
                return;

            SqlCommand cmd = new SqlCommand("requisitarLivro", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@num_cc", user_cc);
            cmd.Parameters.AddWithValue("@codigo", codigo_text.Text);
            cmd.Parameters.AddWithValue("@quantidade", (Int16.Parse(quantidade_txt.Text)-1).ToString());
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

        private void Biblio_btns()
        {
            if (bibliotecario)
            {
                add_livro.Visible = true;
                edit_livro.Visible = true;
                delete_btn.Visible = true;
                cod_label.Visible = true;
            }
        }


        private void hideControlButtons()
        {
            add_livro.Visible = false;
            edit_livro.Visible = false;
            delete_btn.Visible = false;
            cancel_btn.Visible = true;
            submit_btn.Visible = true;
        }

        private void showControlButtons()
        {
            add_livro.Visible = true;
            edit_livro.Visible = true;
            delete_btn.Visible = true;
            cancel_btn.Visible = false;
            submit_btn.Visible = false;
        }

        private void requisitar_btn_Click(object sender, EventArgs e)
        {
            int stock = Int16.Parse(quantidade_txt.Text);
            if (stock <= 0)
            {
                MessageBox.Show("O livro não está disponível em stock");
            }
            else
            {
                requisitarLivro();
                loadLivros();
            }
        }

        private void livros_disponiveis_chec_CheckedChanged(object sender, EventArgs e)
        {
            loadLivros();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex > 0)
            {
                currentLivro = listBox1.SelectedIndex;
                ShowLivro();
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            Biblio_btns();
            cn = getSGBDConnection();
            loadLivros();
            lockTextBoxes();
            codigo_text.Enabled = false;
            if (logged_in == false)
            {
                requisitar_btn.Visible = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            adding = true;
            unlockTextBoxes();
            hideControlButtons();
            clearTextBoxes();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            unlockTextBoxes();
            editing = true;
            hideControlButtons();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            removeLivro();
            loadLivros();
        }

        private void cancel_btn_Click(object sender, EventArgs e)
        {
            if (adding)
            {
                adding = false;
            }
            if (editing)
            {
                editing = false;
            }
            showControlButtons();
            lockTextBoxes();
        }

        private void submit_btn_Click(object sender, EventArgs e)
        {
            if (adding)
            {
                insertLivro();
                adding = false;
            }
            if (editing)
            {
                updateLivro();
                editing = false;
            }
            showControlButtons();
            loadLivros();
            lockTextBoxes();
        }
    }
}
