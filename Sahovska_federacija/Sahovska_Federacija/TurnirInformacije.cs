using NHibernate;
using Sahovska_Federacija.Entiteti;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using NHibernate.Linq;

namespace Sahovska_Federacija
{
    public partial class TurnirInformacije : Form
    {
        public int federacijaBroj { get; set; }
        public TurnirInformacije()
        {
            InitializeComponent();
        }

        public TurnirInformacije(int fedb)
        {
            this.federacijaBroj = fedb;
            InitializeComponent();
        }

        private void TurniriInformacije_Load(object sender, EventArgs e)
        {
            //this.PopulateInfos();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            if(listView2.SelectedItems.Count==0)
            {
                MessageBox.Show("Odaberite turnir");
                return;
            }

            int odId = Int32.Parse(listView2.SelectedItems[0].SubItems[0].Text);
            TurnirBasic tb = DTOManager.GetTurnirBasic(odId);

            TurnirEditBasic tbForm = new TurnirEditBasic(tb);
            if(tbForm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                //DTOManager.UpdateTurnirBasic(tbForm.tBasic);
                //PopulateInfos();
            }
        }

        //private void PopulateInfos()
        //{
        //    listView2.Items.Clear();
        //    List<TurnirPregled> odInfos = DTOManager.getInfos(this.federacijaBroj);
        //    foreach(TurnirPregled tp in odInfos)
        //    {
        //        ListViewItem item = new ListViewItem(new string[] { tp.turnirId.ToString(), tp.naziv, tp.lokacija_federacija, tp.brojPartija.ToString() });
        //        listView2.Items.Add(item);
        //    }
        //    listView2.Refresh();
        //}

        private void ListView2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Label2_Click(object sender, EventArgs e)
        {

        }
    }
}
