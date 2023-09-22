
namespace BibliotecaBD
{
    partial class Form4
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
            this.listView1 = new System.Windows.Forms.ListView();
            this.searchBar = new System.Windows.Forms.TextBox();
            this.box_selected = new System.Windows.Forms.ComboBox();
            this.button2 = new System.Windows.Forms.Button();
            this.renovar_btn = new System.Windows.Forms.Button();
            this.entregar_btn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listView1
            // 
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(25, 76);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(868, 293);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            // 
            // searchBar
            // 
            this.searchBar.Location = new System.Drawing.Point(25, 33);
            this.searchBar.Name = "searchBar";
            this.searchBar.Size = new System.Drawing.Size(392, 23);
            this.searchBar.TabIndex = 1;
            // 
            // box_selected
            // 
            this.box_selected.FormattingEnabled = true;
            this.box_selected.Items.AddRange(new object[] {
            "ID",
            "Título",
            "Requisitante"});
            this.box_selected.Location = new System.Drawing.Point(544, 33);
            this.box_selected.Name = "box_selected";
            this.box_selected.Size = new System.Drawing.Size(121, 23);
            this.box_selected.TabIndex = 2;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(785, 32);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(108, 23);
            this.button2.TabIndex = 4;
            this.button2.Text = "Procurar";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // renovar_btn
            // 
            this.renovar_btn.Location = new System.Drawing.Point(673, 392);
            this.renovar_btn.Name = "renovar_btn";
            this.renovar_btn.Size = new System.Drawing.Size(95, 23);
            this.renovar_btn.TabIndex = 5;
            this.renovar_btn.Text = "Renovar";
            this.renovar_btn.UseVisualStyleBackColor = true;
            this.renovar_btn.Click += new System.EventHandler(this.renovar_btn_Click);
            // 
            // entregar_btn
            // 
            this.entregar_btn.Location = new System.Drawing.Point(798, 392);
            this.entregar_btn.Name = "entregar_btn";
            this.entregar_btn.Size = new System.Drawing.Size(95, 23);
            this.entregar_btn.TabIndex = 6;
            this.entregar_btn.Text = "Entregar";
            this.entregar_btn.UseVisualStyleBackColor = true;
            this.entregar_btn.Click += new System.EventHandler(this.entregar_btn_Click);
            // 
            // Form4
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(917, 427);
            this.Controls.Add(this.entregar_btn);
            this.Controls.Add(this.renovar_btn);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.box_selected);
            this.Controls.Add(this.searchBar);
            this.Controls.Add(this.listView1);
            this.Name = "Form4";
            this.Text = "Livros Requisitados";
            this.Load += new System.EventHandler(this.Form4_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.TextBox searchBar;
        private System.Windows.Forms.ComboBox box_selected;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button renovar_btn;
        private System.Windows.Forms.Button entregar_btn;
    }
}