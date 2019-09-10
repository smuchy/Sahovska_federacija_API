using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using NHibernate;
using NHibernate.Criterion;
using NHibernate.Linq;
using Sahovska_Federacija.Entiteti;


namespace Sahovska_Federacija
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                //Ucitavaju se podaci o prodavnici za zadatim brojem
                Sahovska_Federacija.Entiteti.Federacija f = s.Load<Sahovska_Federacija.Entiteti.Federacija>(1);

                MessageBox.Show(f.lokacija);

                s.Close();
            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Entiteti.Federacija f = new Entiteti.Federacija();

                f.lokacija = "Nemacka";

                s.Save(f);
                s.Flush();
                s.Close();
            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }

        //MANY TO ONE
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                //Ucitavaju se podaci o prodavnici za zadatim brojem
                Sahovski_turnir o = s.Load<Sahovski_turnir>(2);

                MessageBox.Show(o.naziv);
                MessageBox.Show(o.Je_pokrovitelj.lokacija);

                s.Close();
            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }


        //ONE TO MANY
        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                //Ucitavaju se podaci o prodavnici sa zadatim brojem
               Sahovska_Federacija.Entiteti.Federacija f = s.Load<Sahovska_Federacija.Entiteti.Federacija>(1);

                foreach (Sahista o in f.Sahisti)
                {
                    MessageBox.Show(o.ime + " " + o.tip);
                }

                s.Close();
            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                Sahovska_Federacija.Entiteti.Federacija f = s.Load<Sahovska_Federacija.Entiteti.Federacija>(21);

                Majstor m = new Majstor();

                m.br_pasosa = 111111;
                m.tip = "majstor";
                m.ime = "Nikola";
                m.prezime = "Ristic";
                m.ulica = "BK";
                m.broj = 39;
                m.datum_rodjenja = "18.12.1997";
                m.zemlja_porekla = "Kipar";
                m.datum_sticanja_zvanja = "20.5.2019";


                m.ClanFederacije = f;
                s.Save(m);

                f.Sahisti.Add(m);

                s.Save(f);
            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                Sahovska_Federacija.Entiteti.Federacija f = s.Load<Sahovska_Federacija.Entiteti.Federacija>(21);

                Takmicarski t = new Takmicarski();

                t.god_odrzavanja = 2011;
                t.zemlja = "Srbija";
                t.grad = "Beograd";
                t.naziv = "FIDE-Beograd";
                t.tip = "takmicarski";
                t.nacionalni = "Y";
                t.regionalni = "N";
                t.internacionalni = "N";


                t.Je_pokrovitelj = f;
                s.Save(t);

                f.Sahovski_turniri.Add(t);

                s.Save(f);
            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }

        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Sponzor s1 = s.Load<Sponzor>(1);

                foreach (Entiteti.Sahovski_turnir t1 in s1.Sahovski_turniri)
                {
                    MessageBox.Show(t1.naziv);
                }


                Entiteti.Sahovski_turnir t2 = s.Load<Entiteti.Sahovski_turnir>(1);

                foreach (Sponzor s2 in t2.Sponzori)
                {
                    MessageBox.Show(s2.ime + " " + s2.opis);
                }

                s.Close();
            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Sponzor s1 = s.Load<Sponzor>(4);
                Entiteti.Sahovski_turnir t = s.Load<Entiteti.Sahovski_turnir>(6);

                Je_sponzor j = new Je_sponzor();
                j.SponzoriseTurnir = t;
                j.SponzorJe=s1;

                s.Save(j);

                s.Flush();
                s.Close();



            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Sponzor s1 = new Sponzor();
                s1.ime = "Manchester United";
                s1.opis = "Best club in the world!";
                s1.logo = "Red Devils";
              
                s.Save(s1);
                s.Flush();
                s.Close();

            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();


                IList<Sahovski_turnir> turniri = s.QueryOver<Sahovski_turnir>()
                                                .Where(p => p.id_turnira == 4)
                                                .List<Sahovski_turnir>();

                Humanitarni v = (Humanitarni)turniri[0];

                s.Close();



            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Sahovska_Federacija.Entiteti.Federacija f = s.Load<Sahovska_Federacija.Entiteti.Federacija>(21);

                Humanitarni h = new Humanitarni();

                h.naziv = "FIDE-Paris";
                h.zemlja = "Francuska";
                h.grad = "Paris";
                h.god_odrzavanja = 2005;
                h.tip = "humanitarni";

                h.kome_je_namenjen = "mladim talentima";
                h.prikupljeni_iznos = 65800;

                h.Je_pokrovitelj = f;
                s.Save(h);

                f.Sahovski_turniri.Add(h);
                s.Save(f);


                s.Close();

            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {

            try
            {
                ISession s = DataLayer.GetSession();
                Sahovska_Federacija.Entiteti.Federacija f = s.Load<Sahovska_Federacija.Entiteti.Federacija>(21);

                Obican_clan o = new Obican_clan();

                o.br_pasosa = 2222222;
                o.tip = "obican_clan";
                o.ime = "Petar";
                o.prezime = "Peric";
                o.ulica = "Dusanova";
                o.broj = 15;
                o.datum_rodjenja = "8.11.1993";
                o.zemlja_porekla = "BIH";

                o.ClanFederacije = f;
                s.Save(o);

                f.Sahisti.Add(o);

                s.Save(f);
            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Sahista o = s.Get<Sahista>(5);

                if (o != null)
                {
                    MessageBox.Show("Sahista je clan federacije, cija je lokacija: " + o.ClanFederacije.lokacija);
                }
                else
                {
                    MessageBox.Show("Ne postoji sahista sa zadatim identifikatorom");
                }


                s.Close();

            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }

        private void button14_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Sahovski_turnir t = s.Get<Sahovski_turnir>(6);

                //obrada podataka o sahovskom turniru

                s.Refresh(t);

                s.Close();

            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }

        private void button15_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                IQuery q = s.CreateQuery("from Sponzor");

                IList<Sponzor> sponzori = q.List<Sponzor>();

                foreach (Sponzor s1 in sponzori)
                {
                    MessageBox.Show("Logo: "+s1.logo);
                }

                s.Close();

            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }

        private void button16_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                //Takmicarski turniri koji su internacionalnog tipa
                IQuery q = s.CreateQuery("from Takmicarski as o where o.internacionalni = 'Y'");

                IList<Takmicarski> turniri = q.List<Takmicarski>();

                foreach (Takmicarski o in turniri)
                {
                    MessageBox.Show(o.naziv + " " + o.zemlja);
                }

                s.Close();

            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }

        private void button17_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                //Paramterizovani upit
                IQuery q = s.CreateQuery("from Sahovski_turnir as o where o.tip = ? and o.god_odrzavanja >= ?");
                q.SetParameter(0, "takmicarski");
                q.SetInt32(1, 1950);

                IList<Sahovski_turnir> turniri = q.List<Sahovski_turnir>();

                foreach (Sahovski_turnir o in turniri)
                {
                    MessageBox.Show(o.naziv + " " + o.god_odrzavanja + " " + o.tip);
                }

                s.Close();

            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }

        private void button18_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                //Upiti sa imenovanim parametrima
                IQuery q = s.CreateQuery("select o.ClanFederacije from Sahista as o "
                                        + " where o.tip = :tip and o.zemlja_porekla = :zemlja");
                q.SetString("tip", "majstor");
                q.SetString("zemlja", "Srbija");

                IList<Entiteti.Federacija> federacije = q.List<Entiteti.Federacija>();

                foreach (Entiteti.Federacija f in federacije)
                {
                    MessageBox.Show(f.lokacija);
                }

                s.Close();

            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }

        private void button19_Click(object sender, EventArgs e)
        {

            try
            {
                ISession s = DataLayer.GetSession();

                //Upiti sa imenovanim parametrima
                IQuery q = s.CreateQuery("select o.Je_pokrovitelj from Sahovski_turnir as o "
                                        + " where o.grad = :grad and o.god_odrzavanja >= :god "
                                        + " and o.Je_pokrovitelj.lokacija = :lokacija");
                q.SetString("grad", "Lion");
                q.SetInt32("god", 1990);
                q.SetString("lokacija", "Francuska");

                IList<Entiteti.Federacija> federacije = q.List<Entiteti.Federacija>();

                foreach (Entiteti.Federacija f in federacije)
                {
                    MessageBox.Show(f.lokacija);
                }

                s.Close();

            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }

        private void button20_Click(object sender, EventArgs e)
        {

            try
            {
                ISession s = DataLayer.GetSession();

                IQuery q = s.CreateQuery("from Takmicarski");

                IEnumerable<Takmicarski> turniri = q.Enumerable<Takmicarski>();

                foreach (Takmicarski o in turniri)
                {
                    if (o.nacionalni == "N")
                        break;
                }

                s.Close();

            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }

        private void button21_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                IQuery q = s.CreateQuery("select sum(o.prikupljeni_iznos) from Humanitarni o ");

                //za slucaj da upit vraca samo jednu vrednost
                Int64 iznos = q.UniqueResult<Int64>();

                MessageBox.Show("Ukupan prikupljeni iznos sa humanitarinih turnira je: " + iznos.ToString() + " din");

                s.Close();

            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }

        private void button22_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                IQuery q = s.CreateQuery("select o from Sponzor o where o.reg_broj = 5 ");

                //za slucaj da upit vraca samo jednu vrednost
                Sponzor o = q.UniqueResult<Sponzor>();

                MessageBox.Show(o.opis);

                s.Close();

            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }

        private void button23_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                IQuery q = s.CreateQuery("select o.Lokacija, sum(o.BrojKasa), count(o) from Odeljenje o "
                                        + " group by o.Lokacija ");

                //za slucaj da upit vraca visestruku vrednost
                IList<object[]> result = q.List<object[]>();

                foreach (object[] r in result)
                {
                    string tip = (string)r[0];
                    Int64 kase = (Int64)r[1];
                    long broj = (long)r[2];

                    MessageBox.Show(tip + " " + broj.ToString() + " " + kase.ToString());
                }

                s.Close();

            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }

        private void button24_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Sahovska_Federacija.Entiteti.Sahovski_turnir t = s.Load<Sahovska_Federacija.Entiteti.Sahovski_turnir>(25);

                Organizator o = new Organizator();

                o.ime = "Marko";
                o.prezime = "Zivic";
                o.adresa = "Vozdova 5";

                o.OrganizujeTurnir = t;
                s.Save(o);

                t.Organizatori.Add(o);
                s.Save(t);


                s.Close();

            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }

        private void button25_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                //stranicenje

                IQuery q = s.CreateQuery("from Sahista");
                q.SetFirstResult(4);
                q.SetMaxResults(10);

                IList<Sahista> sahiste = q.List<Sahista>();

                foreach (Sahista o in sahiste)
                {
                    MessageBox.Show(o.registracioni_broj.ToString());
                }

                s.Close();

            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }

        private void button26_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                ICriteria c = s.CreateCriteria<Partija>();

                c.Add(Expression.Ge("trajanje", 5));
                c.Add(Expression.Eq("pat", "Y"));

                IList<Partija> partije = c.List<Partija>();

                foreach (Partija o in partije)
                {
                    MessageBox.Show(o.bele +" vs "+ o.crne + " - partija: "+ o.id_partije.ToString());
                }

                s.Close();

            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }

        private void button27_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                IList<Partija> partije = s.QueryOver<Partija>()
                                                .Where(x => x.trajanje >= 15)
                                                .Where(x => x.mat == "N")
                                                .List<Partija>();

                foreach (Partija p in partije)
                {
                    MessageBox.Show(p.bele + " vs " + p.crne + " - partija: " + p.id_partije.ToString());
                }

                s.Close();

            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }

        private void button28_Click(object sender, EventArgs e)
        {

            try
            {
                ISession s = DataLayer.GetSession();

                ISQLQuery q = s.CreateSQLQuery("SELECT O.* FROM ORGANIZATOR O");
                q.AddEntity(typeof(Organizator));


                IList<Organizator> organizatori = q.List<Organizator>();

                foreach (Organizator o in organizatori)
                {
                    MessageBox.Show(o.maticni_broj.ToString() + " - " + o.ime + " " + o.prezime);
                } 

                s.Close();

            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }

        private void button29_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Sponzor o = s.Load<Sponzor>(3);

                //objekat se modifikuje 
                o.opis = "Jako dobra kafa";


                //poziva se Update 
                s.Update(o);

                s.Flush();
                s.Close();

            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }

        private void button30_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Sponzor o = s.Load<Sponzor>(93);

                //brise se objekat iz baze ali ne i instanca objekta u memroiji
                s.Delete(o);
                //s.Delete("from Sponzor");

                s.Flush();
                s.Close();

            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }

        private void button31_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Sahista o = s.Load<Sahista>(7);

                ITransaction t = s.BeginTransaction();

                s.Delete(o);

                //t.Commit();
                t.Rollback();

                s.Close();

            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }

        private void button32_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                IList<Partija> partije = (from p in s.Query<Partija>()
                                              where (p.trajanje >= 10 && p.rem == "Y")
                                              select p).ToList<Partija>();

                foreach (Partija p in partije)
                {
                    MessageBox.Show(p.bele + " vs " + p.crne + " - partija: " + p.id_partije.ToString());
                }


                s.Close();

            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }

        private void button33_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                IEnumerable<Sahovski_turnir> turniri = from p in s.Query<Sahovski_turnir>()
                                                  where (p.tip == "Takmicarski" || p.tip == "Normalni")
                                                  orderby p.tip, p.naziv.Length
                                                  select p;

                foreach (Sahovski_turnir p in turniri)
                {
                    MessageBox.Show(p.naziv);
                }

                s.Close();

            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }

        private void button34_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                IEnumerable<Sahista> sahisti = s.Query<Sahista>()
                                                    .Where(p => (p.tip == "majstor" || p.tip == "majstorski_kandidat"))
                                                    .OrderBy(p => p.tip).ThenBy(p => p.ime.Length)
                                                    .Select(p => p);

                foreach (Sahista p in sahisti)
                {
                    MessageBox.Show(p.ime + " " + p.prezime);
                }


                s.Close();

            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }

        private void button35_Click(object sender, EventArgs e)
        {
            TurnirInformacije odInfoForm = new TurnirInformacije(1);
            odInfoForm.Show();
        }

        private void Button36_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Sahovska_Federacija.Entiteti.Sahovski_turnir t = s.Load<Sahovska_Federacija.Entiteti.Sahovski_turnir>(7);

                Partija p = new Partija();
                p.bele = "Charles Mangus";
                p.crne = "Milos Perunovic";
                p.kad_se_igra = "18.3.2000. 13:30";
                p.trajanje = 15;
                p.pat = "N";
                p.mat = "Y";
                p.rem = "N";

                p.IgraSe = t;
                s.Save(p);

                t.Partije.Add(p);
                s.Save(t);


                Potez m = new Potez();
                m.opis = "beli top na polju D4";
                m.kad_odigran = "13:32";

                m.je_odigran = p;
                s.Save(m);

                p.Potezi.Add(m);
                s.Save(p);

                s.Close();


            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }
    }
}
