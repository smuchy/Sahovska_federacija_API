using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sahovska_Federacija
{
    public partial class TurnirEditBasic : Form
    {
        public TurnirBasic tBasic;
        public TurnirEditBasic()
        {
            InitializeComponent();
        }

        public TurnirEditBasic(TurnirBasic tb)
        {
            this.tBasic = tb;
            InitializeComponent();
            PopulateData();
        }

        private void PopulateData()
        {
            textBox1.Text = tBasic.naziv;
            textBox2.Text = tBasic.zemlja;
            textBox3.Text = tBasic.grad;
            textBox4.Text = tBasic.god_odrzavanja.ToString();
        }


        private void TextBox1_TextChanged(object sender, EventArgs e)
        {
            tBasic.naziv = textBox1.Text;
        }

        private void TextBox2_TextChanged(object sender, EventArgs e)
        {
            tBasic.zemlja = textBox2.Text;
        }

        private void TextBox3_TextChanged(object sender, EventArgs e)
        {
            tBasic.grad = textBox3.Text;
        }

        private void TextBox4_TextChanged(object sender, EventArgs e)
        {
            try
            {
                tBasic.god_odrzavanja = Int32.Parse(textBox4.Text);
            }
            catch
            {
                MessageBox.Show("Godina je ceo broj!");
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {

        }

        
    }
}
