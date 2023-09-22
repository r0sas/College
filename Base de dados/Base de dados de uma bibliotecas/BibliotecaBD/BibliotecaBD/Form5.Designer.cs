
namespace BibliotecaBD
{
    partial class Form5
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
            this.box_selected = new System.Windows.Forms.ComboBox();
            this.searchBar = new System.Windows.Forms.TextBox();
            this.listView1 = new System.Windows.Forms.ListView();
            this.button2 = new System.Windows.Forms.Button();
            this.entregar_btn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // box_selected
            // 
            this.box_selected.FormattingEnabled = true;
            this.box_selected.Items.AddRange(new object[] {
            "ID",
            "Sala",
            "Requisitante"});
            this.box_selected.Location = new System.Drawing.Point(367, 35);
            this.box_selected.Name = "box_selected";
            this.box_selected.Size = new System.Drawing.Size(121, 23);
            this.box_selected.TabIndex = 6;
            // 
            // searchBar
            // 
            this.searchBar.Location = new System.Drawing.Point(28, 35);
            this.searchBar.Name = "searchBar";
            this.searchBar.Size = new System.Drawing.Size(270, 23);
            this.searchBar.TabIndex = 5;
            // 
            // listView1
            // 
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(28, 78);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(745, 279);
            this.listView1.TabIndex = 4;
            this.listView1.UseCompatibleStateImageBehavior = false;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(539, 35);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 8;
            this.button2.Text = "Procurar\r\n";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // entregar_btn
            // 
            this.entregar_btn.Location = new System.Drawing.Point(678, 396);
            this.entregar_btn.Name = "entregar_btn";
            this.entregar_btn.Size = new System.Drawing.Size(95, 23);
            this.entregar_btn.TabIndex = 9;
            this.entregar_btn.Text = "Entregar";
            this.entregar_btn.UseVisualStyleBackColor = true;
            this.entregar_btn.Click += new System.EventHandler(this.entregar_btn_Click);
            // 
            // Form5
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.entregar_btn);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.box_selected);
            this.Controls.Add(this.searchBar);
            this.Controls.Add(this.listView1);
            this.Name = "Form5";
            this.Text = "Salas Requisitadas";
            this.Load += new System.EventHandler(this.Form5_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox box_selected;
        private System.Windows.Forms.TextBox searchBar;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button entregar_btn;
    }
}