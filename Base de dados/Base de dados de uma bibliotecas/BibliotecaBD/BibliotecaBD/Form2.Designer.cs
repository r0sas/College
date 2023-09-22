
namespace BibliotecaBD
{
    partial class Form2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.piso_txt = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.procurar_btn = new System.Windows.Forms.Button();
            this.requisitar_btn = new System.Windows.Forms.Button();
            this.quantidade_txt = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tema_txt = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.autora_txt = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.editora_txt = new System.Windows.Forms.TextBox();
            this.titulo_label = new System.Windows.Forms.Label();
            this.titulo_txt = new System.Windows.Forms.TextBox();
            this.livros_disponiveis_chec = new System.Windows.Forms.CheckBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.add_livro = new System.Windows.Forms.Button();
            this.edit_livro = new System.Windows.Forms.Button();
            this.delete_btn = new System.Windows.Forms.Button();
            this.cod_label = new System.Windows.Forms.Label();
            this.codigo_text = new System.Windows.Forms.TextBox();
            this.cancel_btn = new System.Windows.Forms.Button();
            this.submit_btn = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // piso_txt
            // 
            this.piso_txt.Location = new System.Drawing.Point(507, 309);
            this.piso_txt.Name = "piso_txt";
            this.piso_txt.Size = new System.Drawing.Size(45, 23);
            this.piso_txt.TabIndex = 35;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(507, 291);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 15);
            this.label5.TabIndex = 34;
            this.label5.Text = "Piso";
            // 
            // procurar_btn
            // 
            this.procurar_btn.Location = new System.Drawing.Point(628, 65);
            this.procurar_btn.Name = "procurar_btn";
            this.procurar_btn.Size = new System.Drawing.Size(75, 23);
            this.procurar_btn.TabIndex = 33;
            this.procurar_btn.Text = "Procurar";
            this.procurar_btn.UseVisualStyleBackColor = true;
            this.procurar_btn.Click += new System.EventHandler(this.procurar_btn_Click);
            // 
            // requisitar_btn
            // 
            this.requisitar_btn.Location = new System.Drawing.Point(668, 308);
            this.requisitar_btn.Name = "requisitar_btn";
            this.requisitar_btn.Size = new System.Drawing.Size(105, 23);
            this.requisitar_btn.TabIndex = 32;
            this.requisitar_btn.Text = "Requisitar Livro";
            this.requisitar_btn.UseVisualStyleBackColor = true;
            this.requisitar_btn.Click += new System.EventHandler(this.requisitar_btn_Click);
            // 
            // quantidade_txt
            // 
            this.quantidade_txt.Location = new System.Drawing.Point(422, 309);
            this.quantidade_txt.Name = "quantidade_txt";
            this.quantidade_txt.Size = new System.Drawing.Size(44, 23);
            this.quantidade_txt.TabIndex = 31;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(422, 291);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 15);
            this.label4.TabIndex = 30;
            this.label4.Text = "Quantidade";
            // 
            // tema_txt
            // 
            this.tema_txt.Location = new System.Drawing.Point(423, 265);
            this.tema_txt.Name = "tema_txt";
            this.tema_txt.Size = new System.Drawing.Size(208, 23);
            this.tema_txt.TabIndex = 29;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(423, 247);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 15);
            this.label3.TabIndex = 28;
            this.label3.Text = "Tema";
            // 
            // autora_txt
            // 
            this.autora_txt.Location = new System.Drawing.Point(423, 221);
            this.autora_txt.Name = "autora_txt";
            this.autora_txt.Size = new System.Drawing.Size(208, 23);
            this.autora_txt.TabIndex = 27;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(423, 203);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 15);
            this.label2.TabIndex = 26;
            this.label2.Text = "Autor";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(423, 159);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 15);
            this.label1.TabIndex = 25;
            this.label1.Text = "Editora";
            // 
            // editora_txt
            // 
            this.editora_txt.Location = new System.Drawing.Point(423, 177);
            this.editora_txt.Name = "editora_txt";
            this.editora_txt.Size = new System.Drawing.Size(208, 23);
            this.editora_txt.TabIndex = 24;
            // 
            // titulo_label
            // 
            this.titulo_label.AutoSize = true;
            this.titulo_label.Location = new System.Drawing.Point(423, 115);
            this.titulo_label.Name = "titulo_label";
            this.titulo_label.Size = new System.Drawing.Size(37, 15);
            this.titulo_label.TabIndex = 23;
            this.titulo_label.Text = "Titulo";
            // 
            // titulo_txt
            // 
            this.titulo_txt.Location = new System.Drawing.Point(423, 133);
            this.titulo_txt.Name = "titulo_txt";
            this.titulo_txt.Size = new System.Drawing.Size(208, 23);
            this.titulo_txt.TabIndex = 22;
            // 
            // livros_disponiveis_chec
            // 
            this.livros_disponiveis_chec.AutoSize = true;
            this.livros_disponiveis_chec.Location = new System.Drawing.Point(422, 65);
            this.livros_disponiveis_chec.Name = "livros_disponiveis_chec";
            this.livros_disponiveis_chec.Size = new System.Drawing.Size(86, 19);
            this.livros_disponiveis_chec.TabIndex = 21;
            this.livros_disponiveis_chec.Text = "Disponiveis";
            this.livros_disponiveis_chec.UseVisualStyleBackColor = true;
            this.livros_disponiveis_chec.CheckedChanged += new System.EventHandler(this.livros_disponiveis_chec_CheckedChanged);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Titulo",
            "Editora",
            "Autor",
            "Tema"});
            this.comboBox1.Location = new System.Drawing.Point(647, 25);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 23);
            this.comboBox1.TabIndex = 20;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(422, 25);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(208, 23);
            this.textBox1.TabIndex = 19;
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 15;
            this.listBox1.Location = new System.Drawing.Point(21, 55);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(331, 379);
            this.listBox1.TabIndex = 18;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // add_livro
            // 
            this.add_livro.Location = new System.Drawing.Point(423, 365);
            this.add_livro.Name = "add_livro";
            this.add_livro.Size = new System.Drawing.Size(100, 23);
            this.add_livro.TabIndex = 36;
            this.add_livro.Text = "Adicionar Livro";
            this.add_livro.UseVisualStyleBackColor = true;
            this.add_livro.Visible = false;
            this.add_livro.Click += new System.EventHandler(this.button1_Click);
            // 
            // edit_livro
            // 
            this.edit_livro.Location = new System.Drawing.Point(546, 365);
            this.edit_livro.Name = "edit_livro";
            this.edit_livro.Size = new System.Drawing.Size(100, 23);
            this.edit_livro.TabIndex = 37;
            this.edit_livro.Text = "Editar Livro";
            this.edit_livro.UseVisualStyleBackColor = true;
            this.edit_livro.Visible = false;
            this.edit_livro.Click += new System.EventHandler(this.button2_Click);
            // 
            // delete_btn
            // 
            this.delete_btn.Location = new System.Drawing.Point(668, 365);
            this.delete_btn.Name = "delete_btn";
            this.delete_btn.Size = new System.Drawing.Size(100, 23);
            this.delete_btn.TabIndex = 38;
            this.delete_btn.Text = "Remover Livro";
            this.delete_btn.UseVisualStyleBackColor = true;
            this.delete_btn.Visible = false;
            this.delete_btn.Click += new System.EventHandler(this.button3_Click);
            // 
            // cod_label
            // 
            this.cod_label.AutoSize = true;
            this.cod_label.Location = new System.Drawing.Point(579, 291);
            this.cod_label.Name = "cod_label";
            this.cod_label.Size = new System.Drawing.Size(46, 15);
            this.cod_label.TabIndex = 39;
            this.cod_label.Text = "Código";
            this.cod_label.Visible = false;
            // 
            // codigo_text
            // 
            this.codigo_text.Location = new System.Drawing.Point(579, 308);
            this.codigo_text.Name = "codigo_text";
            this.codigo_text.Size = new System.Drawing.Size(67, 23);
            this.codigo_text.TabIndex = 40;
            // 
            // cancel_btn
            // 
            this.cancel_btn.Location = new System.Drawing.Point(487, 365);
            this.cancel_btn.Name = "cancel_btn";
            this.cancel_btn.Size = new System.Drawing.Size(75, 23);
            this.cancel_btn.TabIndex = 41;
            this.cancel_btn.Text = "Cancelar";
            this.cancel_btn.UseVisualStyleBackColor = true;
            this.cancel_btn.Visible = false;
            this.cancel_btn.Click += new System.EventHandler(this.cancel_btn_Click);
            // 
            // submit_btn
            // 
            this.submit_btn.Location = new System.Drawing.Point(597, 365);
            this.submit_btn.Name = "submit_btn";
            this.submit_btn.Size = new System.Drawing.Size(75, 23);
            this.submit_btn.TabIndex = 42;
            this.submit_btn.Text = "Submeter";
            this.submit_btn.UseVisualStyleBackColor = true;
            this.submit_btn.Visible = false;
            this.submit_btn.Click += new System.EventHandler(this.submit_btn_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(21, 25);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(38, 15);
            this.label6.TabIndex = 43;
            this.label6.Text = "Livros";
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.submit_btn);
            this.Controls.Add(this.cancel_btn);
            this.Controls.Add(this.codigo_text);
            this.Controls.Add(this.cod_label);
            this.Controls.Add(this.delete_btn);
            this.Controls.Add(this.edit_livro);
            this.Controls.Add(this.add_livro);
            this.Controls.Add(this.piso_txt);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.procurar_btn);
            this.Controls.Add(this.requisitar_btn);
            this.Controls.Add(this.quantidade_txt);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tema_txt);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.autora_txt);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.editora_txt);
            this.Controls.Add(this.titulo_label);
            this.Controls.Add(this.titulo_txt);
            this.Controls.Add(this.livros_disponiveis_chec);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.listBox1);
            this.Name = "Form2";
            this.Text = "Livros";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox piso_txt;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button procurar_btn;
        private System.Windows.Forms.Button requisitar_btn;
        private System.Windows.Forms.TextBox quantidade_txt;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tema_txt;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox autora_txt;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox editora_txt;
        private System.Windows.Forms.Label titulo_label;
        private System.Windows.Forms.TextBox titulo_txt;
        private System.Windows.Forms.CheckBox livros_disponiveis_chec;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button add_livro;
        private System.Windows.Forms.Button edit_livro;
        private System.Windows.Forms.Button delete_btn;
        private System.Windows.Forms.Label cod_label;
        private System.Windows.Forms.TextBox codigo_text;
        private System.Windows.Forms.Button cancel_btn;
        private System.Windows.Forms.Button submit_btn;
        private System.Windows.Forms.Label label6;
    }
}