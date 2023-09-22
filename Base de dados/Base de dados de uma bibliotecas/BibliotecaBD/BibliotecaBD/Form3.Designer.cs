
namespace BibliotecaBD
{
    partial class Form3
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
            this.chave_txt = new System.Windows.Forms.TextBox();
            this.requisitar_btn = new System.Windows.Forms.Button();
            this.disponiveis_check = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.num_sala_txt = new System.Windows.Forms.TextBox();
            this.piso_txt = new System.Windows.Forms.TextBox();
            this.edificio_text = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // chave_txt
            // 
            this.chave_txt.Location = new System.Drawing.Point(292, 110);
            this.chave_txt.Name = "chave_txt";
            this.chave_txt.Size = new System.Drawing.Size(94, 23);
            this.chave_txt.TabIndex = 21;
            // 
            // requisitar_btn
            // 
            this.requisitar_btn.Location = new System.Drawing.Point(292, 176);
            this.requisitar_btn.Name = "requisitar_btn";
            this.requisitar_btn.Size = new System.Drawing.Size(94, 23);
            this.requisitar_btn.TabIndex = 20;
            this.requisitar_btn.Text = "Requisitar Sala";
            this.requisitar_btn.UseVisualStyleBackColor = true;
            this.requisitar_btn.Click += new System.EventHandler(this.requisitar_btn_Click);
            // 
            // disponiveis_check
            // 
            this.disponiveis_check.AutoSize = true;
            this.disponiveis_check.Location = new System.Drawing.Point(292, 151);
            this.disponiveis_check.Name = "disponiveis_check";
            this.disponiveis_check.Size = new System.Drawing.Size(86, 19);
            this.disponiveis_check.TabIndex = 19;
            this.disponiveis_check.Text = "Disponiveis";
            this.disponiveis_check.UseVisualStyleBackColor = true;
            this.disponiveis_check.CheckedChanged += new System.EventHandler(this.disponiveis_check_CheckedChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(392, 60);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 15);
            this.label4.TabIndex = 18;
            this.label4.Text = "Número Sala";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(342, 60);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 15);
            this.label3.TabIndex = 17;
            this.label3.Text = "Piso";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(292, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 15);
            this.label2.TabIndex = 16;
            this.label2.Text = "Edificio";
            // 
            // num_sala_txt
            // 
            this.num_sala_txt.Location = new System.Drawing.Point(392, 81);
            this.num_sala_txt.Name = "num_sala_txt";
            this.num_sala_txt.Size = new System.Drawing.Size(44, 23);
            this.num_sala_txt.TabIndex = 15;
            // 
            // piso_txt
            // 
            this.piso_txt.Location = new System.Drawing.Point(342, 81);
            this.piso_txt.Name = "piso_txt";
            this.piso_txt.Size = new System.Drawing.Size(44, 23);
            this.piso_txt.TabIndex = 14;
            // 
            // edificio_text
            // 
            this.edificio_text.Location = new System.Drawing.Point(292, 81);
            this.edificio_text.Name = "edificio_text";
            this.edificio_text.Size = new System.Drawing.Size(44, 23);
            this.edificio_text.TabIndex = 13;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(292, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(28, 15);
            this.label1.TabIndex = 12;
            this.label1.Text = "Sala";
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 15;
            this.listBox1.Location = new System.Drawing.Point(27, 35);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(203, 394);
            this.listBox1.TabIndex = 11;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(27, 13);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(33, 15);
            this.label5.TabIndex = 22;
            this.label5.Text = "Salas";
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(598, 453);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.chave_txt);
            this.Controls.Add(this.requisitar_btn);
            this.Controls.Add(this.disponiveis_check);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.num_sala_txt);
            this.Controls.Add(this.piso_txt);
            this.Controls.Add(this.edificio_text);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listBox1);
            this.Name = "Form3";
            this.Text = "Salas";
            this.Load += new System.EventHandler(this.Form3_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox chave_txt;
        private System.Windows.Forms.Button requisitar_btn;
        private System.Windows.Forms.CheckBox disponiveis_check;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox num_sala_txt;
        private System.Windows.Forms.TextBox piso_txt;
        private System.Windows.Forms.TextBox edificio_text;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Label label5;
    }
}