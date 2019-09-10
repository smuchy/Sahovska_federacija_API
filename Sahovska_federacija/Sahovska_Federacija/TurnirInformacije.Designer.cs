namespace Sahovska_Federacija
{
    partial class TurnirInformacije
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
            this.listView2 = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label2 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listView2
            // 
            this.listView2.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.listView2.Location = new System.Drawing.Point(12, 69);
            this.listView2.Name = "listView2";
            this.listView2.Size = new System.Drawing.Size(473, 386);
            this.listView2.TabIndex = 0;
            this.listView2.UseCompatibleStateImageBehavior = false;
            this.listView2.View = System.Windows.Forms.View.Details;
            this.listView2.SelectedIndexChanged += new System.EventHandler(this.ListView2_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "ID";
            this.columnHeader1.Width = 120;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Naziv";
            this.columnHeader2.Width = 120;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Lokacija Federacije";
            this.columnHeader3.Width = 120;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Broj partija";
            this.columnHeader4.Width = 120;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(197, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Odaberite ID turnira za izmenu podataka";
            this.label2.Click += new System.EventHandler(this.Label2_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(513, 164);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(127, 34);
            this.button2.TabIndex = 2;
            this.button2.Text = "Izmenite podatke";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.Button2_Click);
            // 
            // TurnirInformacije
            // 
            this.ClientSize = new System.Drawing.Size(666, 467);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.listView2);
            this.Name = "TurnirInformacije";
            this.Text = "Informacije o turnirima";
            this.Load += new System.EventHandler(this.TurniriInformacije_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ColumnHeader ID;
        private System.Windows.Forms.ColumnHeader naziv;
        private System.Windows.Forms.ColumnHeader lokacija;
        private System.Windows.Forms.ColumnHeader broj_partija;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ListView listView2;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button2;
    }
}