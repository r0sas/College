
namespace BibliotecaBD
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.log_out_btn = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.log_in_btn = new System.Windows.Forms.Button();
            this.sign_up_btn = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.password_txt = new System.Windows.Forms.TextBox();
            this.email_txt = new System.Windows.Forms.TextBox();
            this.horario_btn = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.salas_btn = new System.Windows.Forms.Button();
            this.livros_btn = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // log_out_btn
            // 
            this.log_out_btn.Location = new System.Drawing.Point(153, 192);
            this.log_out_btn.Name = "log_out_btn";
            this.log_out_btn.Size = new System.Drawing.Size(75, 23);
            this.log_out_btn.TabIndex = 28;
            this.log_out_btn.Text = "Log Out";
            this.log_out_btn.UseVisualStyleBackColor = true;
            this.log_out_btn.Visible = false;
            this.log_out_btn.Click += new System.EventHandler(this.log_out_btn_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(153, 162);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 15);
            this.label3.TabIndex = 27;
            this.label3.Text = "label3";
            this.label3.Visible = false;
            // 
            // log_in_btn
            // 
            this.log_in_btn.Location = new System.Drawing.Point(213, 241);
            this.log_in_btn.Name = "log_in_btn";
            this.log_in_btn.Size = new System.Drawing.Size(73, 23);
            this.log_in_btn.TabIndex = 25;
            this.log_in_btn.Text = "Log In";
            this.log_in_btn.UseVisualStyleBackColor = true;
            this.log_in_btn.Click += new System.EventHandler(this.log_in_btn_Click);
            // 
            // sign_up_btn
            // 
            this.sign_up_btn.Location = new System.Drawing.Point(120, 241);
            this.sign_up_btn.Name = "sign_up_btn";
            this.sign_up_btn.Size = new System.Drawing.Size(71, 23);
            this.sign_up_btn.TabIndex = 24;
            this.sign_up_btn.Text = "Sign Up";
            this.sign_up_btn.UseVisualStyleBackColor = true;
            this.sign_up_btn.Click += new System.EventHandler(this.sign_up_btn_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(213, 162);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 15);
            this.label2.TabIndex = 23;
            this.label2.Text = "Password";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(91, 162);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 15);
            this.label1.TabIndex = 22;
            this.label1.Text = "Email";
            // 
            // password_txt
            // 
            this.password_txt.Location = new System.Drawing.Point(213, 191);
            this.password_txt.Name = "password_txt";
            this.password_txt.Size = new System.Drawing.Size(100, 23);
            this.password_txt.TabIndex = 21;
            // 
            // email_txt
            // 
            this.email_txt.Location = new System.Drawing.Point(91, 191);
            this.email_txt.Name = "email_txt";
            this.email_txt.Size = new System.Drawing.Size(100, 23);
            this.email_txt.TabIndex = 20;
            // 
            // horario_btn
            // 
            this.horario_btn.Location = new System.Drawing.Point(480, 270);
            this.horario_btn.Name = "horario_btn";
            this.horario_btn.Size = new System.Drawing.Size(125, 23);
            this.horario_btn.TabIndex = 19;
            this.horario_btn.Text = "Horário";
            this.horario_btn.UseVisualStyleBackColor = true;
            this.horario_btn.Click += new System.EventHandler(this.horario_btn_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(480, 212);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(125, 23);
            this.button3.TabIndex = 17;
            this.button3.Text = "Livros Requisitados";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // salas_btn
            // 
            this.salas_btn.Location = new System.Drawing.Point(480, 183);
            this.salas_btn.Name = "salas_btn";
            this.salas_btn.Size = new System.Drawing.Size(125, 23);
            this.salas_btn.TabIndex = 16;
            this.salas_btn.Text = "Salas";
            this.salas_btn.UseVisualStyleBackColor = true;
            this.salas_btn.Click += new System.EventHandler(this.salas_btn_Click);
            // 
            // livros_btn
            // 
            this.livros_btn.Location = new System.Drawing.Point(480, 154);
            this.livros_btn.Name = "livros_btn";
            this.livros_btn.Size = new System.Drawing.Size(125, 23);
            this.livros_btn.TabIndex = 15;
            this.livros_btn.Text = "Livros";
            this.livros_btn.UseVisualStyleBackColor = true;
            this.livros_btn.Click += new System.EventHandler(this.livros_btn_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(480, 241);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(125, 23);
            this.button4.TabIndex = 18;
            this.button4.Text = "Salas Requisitadas";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Visible = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.log_out_btn);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.log_in_btn);
            this.Controls.Add(this.sign_up_btn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.password_txt);
            this.Controls.Add(this.email_txt);
            this.Controls.Add(this.horario_btn);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.salas_btn);
            this.Controls.Add(this.livros_btn);
            this.Name = "Form1";
            this.Text = "Menu";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button log_out_btn;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button log_in_btn;
        private System.Windows.Forms.Button sign_up_btn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox password_txt;
        private System.Windows.Forms.TextBox email_txt;
        private System.Windows.Forms.Button horario_btn;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button salas_btn;
        private System.Windows.Forms.Button livros_btn;
        private System.Windows.Forms.Button button4;
    }
}

