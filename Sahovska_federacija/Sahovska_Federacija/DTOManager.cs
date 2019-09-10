using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate.Linq;
using Sahovska_Federacija.Entiteti;

namespace Sahovska_Federacija
{
    public class DTOManager
    {
        #region Federacija -> CRUD

        //GET
        public static List<FederacijaPregled> getInfosFederacija()
        {
            List<FederacijaPregled> odInfos = new List<FederacijaPregled>();
            try
            {
                ISession s = DataLayer.GetSession();
                IEnumerable<Federacija> federacija = from t in s.Query<Federacija>()
                                                     select t;
                foreach (Federacija t in federacija)
                {
                    odInfos.Add(new FederacijaPregled(t.lokacija));
                }
                s.Close();
            }
            catch (Exception ex)
            {
                //exception
            }
            return odInfos;
        }

        //GET BY ID
        public static FederacijaPregled GetFederacijaBasic(int odId)
        {
            FederacijaPregled bp = new FederacijaPregled();
            try
            {
                ISession s = DataLayer.GetSession();
                Federacija b = s.Load<Federacija>(odId);
                bp = new FederacijaPregled(b.lokacija);
                s.Close();
            }
            catch (Exception ex)
            {

            }
            return bp;
        }

        //CREATE
        public int DodajFederaciju(string lokacija)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Federacija bp = new Federacija();
                bp.lokacija = lokacija;

                s.Save(bp);
                return 1;
            }
            catch (Exception ex)
            {
                return -1;
            }
        }

        //UPDATE
        public static FederacijaPregled UpdateFederaciju(FederacijaPregled tb, int odId)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Federacija t = s.Load<Federacija>(odId);
                t.lokacija = tb.lokacija;


                s.Update(t);
                s.Flush();
                s.Close();
            }
            catch (Exception ex)
            {
                //Exception
            }
            return tb;
        }

        #endregion



        #region  Sahovski turnir 


        //GET
        public static List<TurnirPregled> getInfos(int federacijaBroj)
        {
            List<TurnirPregled> odInfos = new List<TurnirPregled>();
            try
            {
                ISession s = DataLayer.GetSession();
                IEnumerable<Sahovski_turnir> turniri = from t in s.Query<Sahovski_turnir>()
                                                       where t.Je_pokrovitelj.registracioni_broj == federacijaBroj
                                                       select t;
                foreach (Sahovski_turnir t in turniri)
                {
                    odInfos.Add(new TurnirPregled(t.naziv, t.zemlja, t.grad, t.god_odrzavanja, t.tip));
                }
                s.Close();
            }
            catch (Exception ex)
            {
                //exception
            }
            return odInfos;
        }


        //GET BY ID
        public static TurnirBasic GetTurnirBasic(int odId)
        {
            TurnirBasic tb = new TurnirBasic();
            try
            {
                ISession s = DataLayer.GetSession();

                Sahovski_turnir t = s.Load<Sahovski_turnir>(odId);
                tb = new TurnirBasic(t.id_turnira, t.naziv, t.zemlja, t.grad, t.god_odrzavanja, t.tip);
                s.Close();
            }
            catch (Exception ex)
            {
                //exception
            }

            return tb;
        }

        //CREATE
        public int DodajTurnir(string Naziv, string Zemlja, string Grad, int God_odrzavanja, string Tip)
        {
            try
            {

                ISession s = DataLayer.GetSession();
                Federacija f = s.Load<Federacija>(1);

                Sahovski_turnir turnir = new Sahovski_turnir();
                turnir.naziv = Naziv;
                turnir.zemlja = Zemlja;
                turnir.grad = Grad;
                turnir.god_odrzavanja = God_odrzavanja;
                turnir.tip = Tip;
                turnir.odigran = "N";


                turnir.Je_pokrovitelj = f;
                s.Save(turnir);
                f.Sahovski_turniri.Add(turnir);
                s.Save(f);
                return 1;
            }
            catch (Exception ex)
            {
                return -1;
            }

        }


        //UPDATE
        public static TurnirBasic UpdateTurnirBasic(TurnirBasic tb, int id)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Sahovski_turnir t = s.Load<Sahovski_turnir>(id);
                t.naziv = tb.naziv;
                t.grad = tb.grad;
                t.zemlja = tb.zemlja;
                t.god_odrzavanja = tb.god_odrzavanja;
                t.tip = tb.tip;

                s.Update(t);
                s.Flush();
                s.Close();
            }
            catch (Exception ex)
            {
                //Exception
            }
            return tb;
        }

        //DELETE
        public int DeleteTurnir(int id)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Sahovski_turnir st = s.Load<Sahovski_turnir>(id);

                s.Delete(st);
                s.Flush();
                s.Close();

                return 1;
            }
            catch (Exception ex)
            {
                return -1;
            }
        }

        #endregion

        #region Egzibicioni turnir -> CRUD

        //GET
        public static List<EgzibicioniPregled> getInfosEgzibicioni(int federacijaBroj)
        {
            List<EgzibicioniPregled> odInfos = new List<EgzibicioniPregled>();
            try
            {
                ISession s = DataLayer.GetSession();
                IEnumerable<Egzibicioni> egzibicioni = from t in s.Query<Egzibicioni>()
                                                       where t.Je_pokrovitelj.registracioni_broj == federacijaBroj
                                                       where t.tip == "egzibicioni"
                                                       select t;
                foreach (Egzibicioni t in egzibicioni)
                {
                    odInfos.Add(new EgzibicioniPregled(t.naziv, t.zemlja, t.grad, t.god_odrzavanja));
                }
                s.Close();
            }
            catch (Exception ex)
            {

            }
            return odInfos;
        }

        //GET BY ID
        public static EgzibicioniPregled GetEgzibicioniBasic(int odId)
        {
            EgzibicioniPregled bp = new EgzibicioniPregled();
            try
            {
                ISession s = DataLayer.GetSession();
                Egzibicioni b = s.Load<Egzibicioni>(odId);
                bp = new EgzibicioniPregled(b.naziv, b.zemlja, b.grad, b.god_odrzavanja);
                s.Close();
            }
            catch (Exception ex)
            {

            }
            return bp;
        }

        //CREATE
        public int DodajEgzibicioni(string Naziv, string Zemlja, string Grad, int God_odrzavanja)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                Federacija f = s.Load<Federacija>(1);

                Egzibicioni bp = new Egzibicioni();
                bp.naziv = Naziv;
                bp.zemlja = Zemlja;
                bp.grad = Grad;
                bp.god_odrzavanja = God_odrzavanja;
                bp.tip = "egzibicioni";
                bp.odigran = "N";

                bp.Je_pokrovitelj = f;
                s.Save(bp);
                f.Sahovski_turniri.Add(bp);
                s.Save(f);
                return 1;
            }
            catch (Exception ex)
            {
                return -1;
            }
        }

        //UPDATE
        public static EgzibicioniPregled UpdateEgzibicioni(EgzibicioniPregled tb, int odId)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Egzibicioni t = s.Load<Egzibicioni>(odId);
                t.naziv = tb.naziv;
                t.zemlja = tb.zemlja;
                t.grad = tb.grad;
                t.god_odrzavanja = tb.god_odrzavanja;
                tb.tip = "egzibicioni";


                s.Update(t);
                s.Flush();
                s.Close();
            }
            catch (Exception ex)
            {
                //Exception
            }
            return tb;
        }


        //DELETE
        public int DeleteEgzibicioni(int id)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Egzibicioni st = s.Load<Egzibicioni>(id);

                s.Delete(st);
                s.Flush();
                s.Close();

                return 1;
            }
            catch (Exception ex)
            {
                return -1;
            }
        }

        #endregion

        #region Brzopotezni turnir -> CRUD

        //GET
        public static List<BrzopotezniPregled> getInfosBrzopotezni(int federacijaBroj)
        {
            List<BrzopotezniPregled> odInfos = new List<BrzopotezniPregled>();
            try
            {
                ISession s = DataLayer.GetSession();
                IEnumerable<Brzopotezni> brzopotezni = from t in s.Query<Brzopotezni>()
                                                       where t.Je_pokrovitelj.registracioni_broj == federacijaBroj
                                                       where t.tip == "brzopotezni"
                                                       select t;
                foreach (Brzopotezni t in brzopotezni)
                {
                    odInfos.Add(new BrzopotezniPregled(t.naziv, t.zemlja, t.grad, t.god_odrzavanja,t.max_vreme_trajanja_partija));
                }
                s.Close();
            }
            catch (Exception ex)
            {

            }
            return odInfos;
        }


        //GET BY ID
        public static BrzopotezniPregled GetBrzopotezniBasic(int odId)
        {
            BrzopotezniPregled bp = new BrzopotezniPregled();
            try
            {
                ISession s = DataLayer.GetSession();
                Brzopotezni b = s.Load<Brzopotezni>(odId);
                bp = new BrzopotezniPregled(b.naziv, b.zemlja, b.grad, b.god_odrzavanja, b.max_vreme_trajanja_partija);
                s.Close();
            }
            catch (Exception ex)
            {

            }
            return bp;
        }


        //CREATE
        public int DodajBrzopotezni(string Naziv, string Zemlja, string Grad, int God_odrzavanja, int Max_vreme)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                Federacija f = s.Load<Federacija>(1);

                Brzopotezni bp = new Brzopotezni();
                bp.naziv = Naziv;
                bp.zemlja = Zemlja;
                bp.grad = Grad;
                bp.god_odrzavanja = God_odrzavanja;
                bp.tip = "brzopotezni";
                bp.max_vreme_trajanja_partija = Max_vreme;
                bp.odigran = "N";

                bp.Je_pokrovitelj = f;
                s.Save(bp);
                f.Sahovski_turniri.Add(bp);
                s.Save(f);
                return 1;
            }
            catch (Exception ex)
            {
                return -1;
            }
        }


        //UPDATE
        public static BrzopotezniPregled UpdateBrzopotezni(BrzopotezniPregled tb, int odId)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Brzopotezni t = s.Load<Brzopotezni>(odId);
                t.naziv = tb.naziv;
                t.zemlja = tb.zemlja;
                t.grad = tb.grad;
                t.god_odrzavanja = tb.god_odrzavanja;
                tb.tip = "brzopotezni";
                t.max_vreme_trajanja_partija = tb.max_vreme_trajanja_partija;


                s.Update(t);
                s.Flush();
                s.Close();
            }
            catch (Exception ex)
            {
                //Exception
            }
            return tb;
        }


        //DELETE
        public int DeleteBrzopotezni(int id)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Brzopotezni st = s.Load<Brzopotezni>(id);

                s.Delete(st);
                s.Flush();
                s.Close();

                return 1;
            }
            catch (Exception ex)
            {
                return -1;
            }
        }
        #endregion

        #region Humanitarni -> CRUD

        //GET
        public static List<HumanitarniPregled> getInfosHumanitarni(int federacijaBroj)
        {
            List<HumanitarniPregled> odInfos = new List<HumanitarniPregled>();
            try
            {
                ISession s = DataLayer.GetSession();
                IEnumerable<Humanitarni> humanitarni = from t in s.Query<Humanitarni>()
                                                       where t.Je_pokrovitelj.registracioni_broj == federacijaBroj
                                                       select t;
                foreach (Humanitarni t in humanitarni)
                {
                    odInfos.Add(new HumanitarniPregled(t.naziv, t.zemlja, t.grad, t.god_odrzavanja, t.kome_je_namenjen,t.prikupljeni_iznos));
                }
                s.Close();
            }
            catch (Exception ex)
            {

            }
            return odInfos;
        }


        //GET BY ID
        public static HumanitarniPregled GetHumanitarniBasic(int odId)
        {
            HumanitarniPregled bp = new HumanitarniPregled();
            try
            {
                ISession s = DataLayer.GetSession();
                Humanitarni b = s.Load<Humanitarni>(odId);
                bp = new HumanitarniPregled(b.naziv, b.zemlja, b.grad, b.god_odrzavanja, b.kome_je_namenjen, b.prikupljeni_iznos);
                s.Close();
            }
            catch (Exception ex)
            {

            }
            return bp;
        }


        //CREATE
        public int DodajHumanitarni(string Naziv, string Zemlja, string Grad, int God_odrzavanja, string kome_je_namenjen, int prikupljeni_iznos)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                Federacija f = s.Load<Federacija>(1);

                Humanitarni bp = new Humanitarni();
                bp.naziv = Naziv;
                bp.zemlja = Zemlja;
                bp.grad = Grad;
                bp.god_odrzavanja = God_odrzavanja;
                bp.tip = "humanitarni";
                bp.kome_je_namenjen = kome_je_namenjen;
                bp.prikupljeni_iznos = prikupljeni_iznos;
                bp.odigran = "N";

                bp.Je_pokrovitelj = f;
                s.Save(bp);
                f.Sahovski_turniri.Add(bp);
                s.Save(f);
                return 1;
            }
            catch (Exception ex)
            {
                return -1;
            }
        }


        //UPDATE
        public static HumanitarniPregled UpdateHumanitarni(HumanitarniPregled tb, int odId)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Humanitarni t = s.Load<Humanitarni>(odId);
                t.naziv = tb.naziv;
                t.zemlja = tb.zemlja;
                t.grad = tb.grad;
                t.god_odrzavanja = tb.god_odrzavanja;
                tb.tip = "humanitarni";
                t.kome_je_namenjen = tb.kome_je_namenjen;
                t.prikupljeni_iznos = tb.prikupljeni_iznos;



                s.Update(t);
                s.Flush();
                s.Close();
            }
            catch (Exception ex)
            {
                //Exception
            }
            return tb;
        }

        //DELETE
        public int DeleteHumanitarni(int id)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Humanitarni st = s.Load<Humanitarni>(id);

                s.Delete(st);
                s.Flush();
                s.Close();

                return 1;
            }
            catch (Exception ex)
            {
                return -1;
            }
        }

        #endregion

        #region Normalni -> CRUD

        //GET
        public static List<NormalniPregled> getInfosNormalni(int federacijaBroj)
        {
            List<NormalniPregled> odInfos = new List<NormalniPregled>();
            try
            {
                ISession s = DataLayer.GetSession();
                IEnumerable<Normalni> normalni = from t in s.Query<Normalni>()
                                                       where t.Je_pokrovitelj.registracioni_broj == federacijaBroj
                                                       select t;
                foreach (Normalni t in normalni)
                {
                    odInfos.Add(new NormalniPregled(t.naziv, t.zemlja, t.grad, t.god_odrzavanja));
                }
                s.Close();
            }
            catch (Exception ex)
            {

            }
            return odInfos;
        }

        //GET BY ID
        public static NormalniPregled GetNormalniBasic(int odId)
        {
            NormalniPregled bp = new NormalniPregled();
            try
            {
                ISession s = DataLayer.GetSession();
                Normalni b = s.Load<Normalni>(odId);
                bp = new NormalniPregled(b.naziv, b.zemlja, b.grad, b.god_odrzavanja);
                s.Close();
            }
            catch (Exception ex)
            {

            }
            return bp;
        }


        //CREATE
        public int DodajNormalni(string Naziv, string Zemlja, string Grad, int God_odrzavanja)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                Federacija f = s.Load<Federacija>(1);

                Normalni bp = new Normalni();
                bp.naziv = Naziv;
                bp.zemlja = Zemlja;
                bp.grad = Grad;
                bp.god_odrzavanja = God_odrzavanja;
                bp.tip = "normalni";
                bp.odigran = "N";

                bp.Je_pokrovitelj = f;
                s.Save(bp);
                f.Sahovski_turniri.Add(bp);
                s.Save(f);
                return 1;
            }
            catch (Exception ex)
            {
                return -1;
            }
        }


        //UPDATE
        public static NormalniPregled UpdateNormalni(NormalniPregled tb, int odId)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Normalni t = s.Load<Normalni>(odId);
                t.naziv = tb.naziv;
                t.zemlja = tb.zemlja;
                t.grad = tb.grad;
                t.god_odrzavanja = tb.god_odrzavanja;
                tb.tip = "normalni";



                s.Update(t);
                s.Flush();
                s.Close();
            }
            catch (Exception ex)
            {
                //Exception
            }
            return tb;
        }

        //DELETE
        public int DeleteNormalni(int id)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Normalni st = s.Load<Normalni>(id);

                s.Delete(st);
                s.Flush();
                s.Close();

                return 1;
            }
            catch (Exception ex)
            {
                return -1;
            }
        }

        #endregion

        #region Promotivni -> CRUD

        //GET
        public static List<PromotivniPregled> getInfosPromotivni(int federacijaBroj)
        {
            List<PromotivniPregled> odInfos = new List<PromotivniPregled>();
            try
            {
                ISession s = DataLayer.GetSession();
                IEnumerable<Promotivni> promotivni = from t in s.Query<Promotivni>()
                                                 where t.Je_pokrovitelj.registracioni_broj == federacijaBroj
                                                     select t;
                foreach (Promotivni t in promotivni)
                {
                    odInfos.Add(new PromotivniPregled(t.naziv, t.zemlja, t.grad, t.god_odrzavanja));
                }
                s.Close();
            }
            catch (Exception ex)
            {

            }
            return odInfos;
        }

        //GET BY ID
        public static PromotivniPregled GetPromotivniBasic(int odId)
        {
            PromotivniPregled bp = new PromotivniPregled();
            try
            {
                ISession s = DataLayer.GetSession();
                Promotivni b = s.Load<Promotivni>(odId);
                bp = new PromotivniPregled(b.naziv, b.zemlja, b.grad, b.god_odrzavanja);
                s.Close();
            }
            catch (Exception ex)
            {

            }
            return bp;
        }


        //CREATE
        public int DodajPromotivni(string Naziv, string Zemlja, string Grad, int God_odrzavanja)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                Federacija f = s.Load<Federacija>(1);

                Promotivni bp = new Promotivni();
                bp.naziv = Naziv;
                bp.zemlja = Zemlja;
                bp.grad = Grad;
                bp.god_odrzavanja = God_odrzavanja;
                bp.tip = "promotivni";
                bp.odigran = "N";

                bp.Je_pokrovitelj = f;
                s.Save(bp);
                f.Sahovski_turniri.Add(bp);
                s.Save(f);
                return 1;
            }
            catch (Exception ex)
            {
                return -1;
            }
        }


        //UPDATE
        public static PromotivniPregled UpdatePromotivni(PromotivniPregled tb, int odId)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Promotivni t = s.Load<Promotivni>(odId);
                t.naziv = tb.naziv;
                t.zemlja = tb.zemlja;
                t.grad = tb.grad;
                t.god_odrzavanja = tb.god_odrzavanja;
                tb.tip = "promotivni";



                s.Update(t);
                s.Flush();
                s.Close();
            }
            catch (Exception ex)
            {
                //Exception
            }
            return tb;
        }

        //DELETE
        public int DeletePromotivni(int id)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Promotivni st = s.Load<Promotivni>(id);

                s.Delete(st);
                s.Flush();
                s.Close();

                return 1;
            }
            catch (Exception ex)
            {
                return -1;
            }
        }
        #endregion

        #region Takmicarski -> CRUD

        //GET
        public static List<TakmicarskiPregled> getInfosTakmicarski(int federacijaBroj)
        {
            List<TakmicarskiPregled> odInfos = new List<TakmicarskiPregled>();
            try
            {
                ISession s = DataLayer.GetSession();
                IEnumerable<Takmicarski> takmicarski = from t in s.Query<Takmicarski>()
                                                     where t.Je_pokrovitelj.registracioni_broj == federacijaBroj
                                                     select t;
                foreach (Takmicarski t in takmicarski)
                {
                    odInfos.Add(new TakmicarskiPregled(t.naziv, t.zemlja, t.grad, t.god_odrzavanja, t.internacionalni, t.regionalni, t.nacionalni));
                }
                s.Close();
            }
            catch (Exception ex)
            {

            }
            return odInfos;
        }

        //GET BY ID
        public static TakmicarskiPregled GetTakmicarskiBasic(int odId)
        {
            TakmicarskiPregled bp = new TakmicarskiPregled();
            try
            {
                ISession s = DataLayer.GetSession();
                Takmicarski b = s.Load<Takmicarski>(odId);
                bp = new TakmicarskiPregled(b.naziv, b.zemlja, b.grad, b.god_odrzavanja,b.internacionalni,b.regionalni,b.internacionalni);
                s.Close();
            }
            catch (Exception ex)
            {

            }
            return bp;
        }


        //CREATE
        public int DodajTakmicarski(string Naziv, string Zemlja, string Grad, int God_odrzavanja, string internacionalni, string regionalni, string nacionalni)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                Federacija f = s.Load<Federacija>(1);

                Takmicarski bp = new Takmicarski();
                bp.naziv = Naziv;
                bp.zemlja = Zemlja;
                bp.grad = Grad;
                bp.god_odrzavanja = God_odrzavanja;
                bp.tip = "takmicarski";
                bp.odigran = "N";
                bp.internacionalni = internacionalni;
                bp.regionalni = regionalni;
                bp.nacionalni = nacionalni;

                bp.Je_pokrovitelj = f;
                s.Save(bp);
                f.Sahovski_turniri.Add(bp);
                s.Save(f);
                return 1;
            }
            catch (Exception ex)
            {
                return -1;
            }
        }


        //UPDATE
        public static TakmicarskiPregled UpdateTakmicarski(TakmicarskiPregled tb, int odId)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Takmicarski t = s.Load<Takmicarski>(odId);
                t.naziv = tb.naziv;
                t.zemlja = tb.zemlja;
                t.grad = tb.grad;
                t.god_odrzavanja = tb.god_odrzavanja;
                tb.tip = "takmicarski";
                t.internacionalni = tb.internacionalni;
                t.regionalni = tb.regionalni;
                t.nacionalni = tb.nacionalni;



                s.Update(t);
                s.Flush();
                s.Close();
            }
            catch (Exception ex)
            {
                //Exception
            }
            return tb;
        }

        //DELETE
        public int DeleteTakmicarski(int id)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Takmicarski st = s.Load<Takmicarski>(id);

                s.Delete(st);
                s.Flush();
                s.Close();

                return 1;
            }
            catch (Exception ex)
            {
                return -1;
            }
        }
        #endregion



        #region  Sahista 

        //GET
        public static List<SahistaPregled> getInfosSahista(int federacijaBroj)
        {
            List<SahistaPregled> odInfos = new List<SahistaPregled>();
            try
            {
                ISession s = DataLayer.GetSession();
                IEnumerable<Sahista> sahisti = from t in s.Query<Sahista>()
                                               where t.ClanFederacije.registracioni_broj == federacijaBroj
                                               select t;
                foreach (Sahista t in sahisti)
                {
                    odInfos.Add(new SahistaPregled(t.br_pasosa, t.ime, t.prezime, t.ulica, t.broj, t.datum_rodjenja, t.zemlja_porekla,t.tip));
                }
                s.Close();
            }
            catch (Exception ex)
            {
                //exception
            }
            return odInfos;
        }

        //GET BY ID
        public static SahistaPregled GetSahistaBasic(int odId)
        {
            SahistaPregled tb = new SahistaPregled();
            try
            {
                ISession s = DataLayer.GetSession();

                Sahista t = s.Load<Sahista>(odId);
                tb = new SahistaPregled(t.br_pasosa, t.ime, t.prezime, t.ulica, t.broj, t.datum_rodjenja, t.zemlja_porekla,t.tip);
                s.Close();
            }
            catch (Exception ex)
            {
                //exception
            }

            return tb;
        }


        //DELETE
        public int DeleteSahistu(int id)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Sahista st = s.Load<Sahista>(id);

                s.Delete(st);
                s.Flush();
                s.Close();

                return 1;
            }
            catch (Exception ex)
            {
                return -1;
            }
        }

        #endregion

        #region ObicanClan -> CRUD

        //GET
        public static List<ObicanClanPregled> getInfosObicanClan()
        {
            List<ObicanClanPregled> odInfos = new List<ObicanClanPregled>();
            try
            {
                ISession s = DataLayer.GetSession();
                IEnumerable<Obican_clan> obican = from t in s.Query<Obican_clan>()
                                               select t;
                foreach (Obican_clan t in obican)
                {
                    odInfos.Add(new ObicanClanPregled(t.br_pasosa, t.ime, t.prezime, t.ulica, t.broj, t.datum_rodjenja, t.zemlja_porekla));
                }
                s.Close();
            }
            catch (Exception ex)
            {
                //exception
            }
            return odInfos;
        }


        //GET BY ID
        public static ObicanClanPregled GetObicanClanBasic(int odId)
        {
            ObicanClanPregled tb = new ObicanClanPregled();
            try
            {
                ISession s = DataLayer.GetSession();

                Obican_clan t = s.Load<Obican_clan>(odId);
                tb = new ObicanClanPregled(t.br_pasosa, t.ime, t.prezime, t.ulica, t.broj, t.datum_rodjenja, t.zemlja_porekla);
                s.Close();
            }
            catch (Exception ex)
            {
                //exception
            }

            return tb;
        }


        //CREATE
        public int DodajObicanClan(int br_pasosa, string ime, string prezime, string ulica, int broj, string datum_rodjenja, string zemlja_porekla)
        {
            try
            {

                ISession s = DataLayer.GetSession();
                Federacija f = s.Load<Federacija>(1);

                Obican_clan sahista = new Obican_clan();

                sahista.br_pasosa = br_pasosa;
                sahista.ime = ime;
                sahista.prezime = prezime;
                sahista.ulica = ulica;
                sahista.broj = broj;
                sahista.datum_rodjenja = datum_rodjenja;
                sahista.zemlja_porekla = zemlja_porekla;
                sahista.tip = "obican_clan";


                sahista.ClanFederacije = f;
                s.Save(sahista);
                f.Sahisti.Add(sahista);
                s.Save(f);
                return 1;
            }
            catch (Exception ex)
            {
                return -1;
            }
        }


        //UPDATE
        public static ObicanClanPregled UpdateObicanClanPregled(ObicanClanPregled tb, int id)
        {

            try
            {
                ISession s = DataLayer.GetSession();

                Obican_clan t = s.Load<Obican_clan>(id);
                t.br_pasosa = tb.br_pasosa;
                t.ime = tb.ime;
                t.prezime = tb.prezime;
                t.ulica = tb.ulica;
                t.broj = tb.broj;
                t.datum_rodjenja = tb.datum_rodjenja;
                t.zemlja_porekla = tb.zemlja_porekla;

                s.Update(t);
                s.Flush();
                s.Close();
            }
            catch (Exception ex)
            {
                //Exception
            }
            return tb;
        }


        //DELETE
        public int DeleteObicanClan(int id)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Obican_clan st = s.Load<Obican_clan>(id);

                s.Delete(st);
                s.Flush();
                s.Close();

                return 1;
            }
            catch (Exception ex)
            {
                return -1;
            }
        }

        #endregion

        #region MajstorskiKandidat -> CRUD
        //GET
        public static List<MajstorskiKandidatPregled> getInfosMajstorskiKandidat()
        {
            List<MajstorskiKandidatPregled> odInfos = new List<MajstorskiKandidatPregled>();
            try
            {
                ISession s = DataLayer.GetSession();
                IEnumerable<Majstorski_kandidat> majstorski_kandidat = from t in s.Query<Majstorski_kandidat>()
                                                  select t;
                foreach (Majstorski_kandidat t in majstorski_kandidat)
                {
                    odInfos.Add(new MajstorskiKandidatPregled(t.br_pasosa, t.ime, t.prezime, t.ulica, t.broj, t.datum_rodjenja, t.zemlja_porekla, t.br_odigranih_partija, t.br_partija_do_zvanja));
                }
                s.Close();
            }
            catch (Exception ex)
            {
                //exception
            }
            return odInfos;
        }


        //GET BY ID
        public static MajstorskiKandidatPregled GetMajstorskiKandidatBasic(int odId)
        {
            MajstorskiKandidatPregled tb = new MajstorskiKandidatPregled();
            try
            {
                ISession s = DataLayer.GetSession();

                Majstorski_kandidat t = s.Load<Majstorski_kandidat>(odId);
                tb = new MajstorskiKandidatPregled(t.br_pasosa, t.ime, t.prezime, t.ulica, t.broj, t.datum_rodjenja, t.zemlja_porekla, t.br_odigranih_partija, t.br_partija_do_zvanja);
                s.Close();
            }
            catch (Exception ex)
            {
                //exception
            }

            return tb;
        }


        //CREATE
        public int DodajMajstorskiKandidat(int br_pasosa, string ime, string prezime, string ulica, int broj, string datum_rodjenja, string zemlja_porekla,int br_odigranih_partija, int br_partija_do_zvanja)
        {
            try
            {

                ISession s = DataLayer.GetSession();
                Federacija f = s.Load<Federacija>(1);

                Majstorski_kandidat sahista = new Majstorski_kandidat();

                sahista.br_pasosa = br_pasosa;
                sahista.ime = ime;
                sahista.prezime = prezime;
                sahista.ulica = ulica;
                sahista.broj = broj;
                sahista.datum_rodjenja = datum_rodjenja;
                sahista.zemlja_porekla = zemlja_porekla;
                sahista.tip = "majstorski_kandidat";
                sahista.br_odigranih_partija = br_odigranih_partija;
                sahista.br_partija_do_zvanja = br_partija_do_zvanja;


                sahista.ClanFederacije = f;
                s.Save(sahista);
                f.Sahisti.Add(sahista);
                s.Save(f);
                return 1;
            }
            catch (Exception ex)
            {
                return -1;
            }
        }


        //UPDATE
        public static MajstorskiKandidatPregled UpdateMajstorskiKandidatPregled(MajstorskiKandidatPregled tb, int id)
        {

            try
            {
                ISession s = DataLayer.GetSession();

                Majstorski_kandidat t = s.Load<Majstorski_kandidat>(id);
                t.br_pasosa = tb.br_pasosa;
                t.ime = tb.ime;
                t.prezime = tb.prezime;
                t.ulica = tb.ulica;
                t.broj = tb.broj;
                t.datum_rodjenja = tb.datum_rodjenja;
                t.zemlja_porekla = tb.zemlja_porekla;
                t.br_odigranih_partija = tb.br_odigranih_partija;
                t.br_partija_do_zvanja = tb.br_partija_do_zvanja;
                tb.tip = "majstorski_kandidat";

                s.Update(t);
                s.Flush();
                s.Close();
            }
            catch (Exception ex)
            {
                //Exception
            }
            return tb;
        }


        //DELETE
        public int DeleteMajstorskiKandidat(int id)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Majstorski_kandidat st = s.Load<Majstorski_kandidat>(id);

                s.Delete(st);
                s.Flush();
                s.Close();

                return 1;
            }
            catch (Exception ex)
            {
                return -1;
            }
        }
        #endregion

        #region Majstor -> CRUD
        //GET
        public static List<MajstorPregled> getInfosMajstor()
        {
            List<MajstorPregled> odInfos = new List<MajstorPregled>();
            try
            {
                ISession s = DataLayer.GetSession();
                IEnumerable<Majstor> majstor = from t in s.Query<Majstor>()
                                                                       select t;
                foreach (Majstor t in majstor)
                {
                    odInfos.Add(new MajstorPregled(t.br_pasosa, t.ime, t.prezime, t.ulica, t.broj, t.datum_rodjenja, t.zemlja_porekla, t.datum_sticanja_zvanja));
                }
                s.Close();
            }
            catch (Exception ex)
            {
                //exception
            }
            return odInfos;
        }

        //GET BY ID
        public static MajstorPregled GetMajstorBasic(int odId)
        {
            MajstorPregled tb = new MajstorPregled();
            try
            {
                ISession s = DataLayer.GetSession();

                Majstor t = s.Load<Majstor>(odId);
                tb = new MajstorPregled(t.br_pasosa, t.ime, t.prezime, t.ulica, t.broj, t.datum_rodjenja, t.zemlja_porekla, t.datum_sticanja_zvanja);
                s.Close();
            }
            catch (Exception ex)
            {
                //exception
            }

            return tb;
        }

        public int DodajMajstor(int br_pasosa, string ime, string prezime, string ulica, int broj, string datum_rodjenja, string zemlja_porekla, string datum_sticanja_zvanja)
        {
            try
            {

                ISession s = DataLayer.GetSession();
                Federacija f = s.Load<Federacija>(1);

                Majstor sahista = new Majstor();

                sahista.br_pasosa = br_pasosa;
                sahista.ime = ime;
                sahista.prezime = prezime;
                sahista.ulica = ulica;
                sahista.broj = broj;
                sahista.datum_rodjenja = datum_rodjenja;
                sahista.zemlja_porekla = zemlja_porekla;
                sahista.tip = "majstor";
                sahista.datum_sticanja_zvanja = datum_sticanja_zvanja;


                sahista.ClanFederacije = f;
                s.Save(sahista);
                f.Sahisti.Add(sahista);
                s.Save(f);
                return 1;
            }
            catch (Exception ex)
            {
                return -1;
            }
        }

        //UPDATE
        public static MajstorPregled UpdateMajstorPregled(MajstorPregled tb, int id)
        {

            try
            {
                ISession s = DataLayer.GetSession();

                Majstor t = s.Load<Majstor>(id);
                t.br_pasosa = tb.br_pasosa;
                t.ime = tb.ime;
                t.prezime = tb.prezime;
                t.ulica = tb.ulica;
                t.broj = tb.broj;
                t.datum_rodjenja = tb.datum_rodjenja;
                t.zemlja_porekla = tb.zemlja_porekla;
                t.datum_sticanja_zvanja = tb.datum_sticanja_zvanja;
                tb.tip = "majstor";

                s.Update(t);
                s.Flush();
                s.Close();
            }
            catch (Exception ex)
            {
                //Exception
            }
            return tb;
        }

        //DELETE
        public int DeleteMajstor(int id)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Majstor st = s.Load<Majstor>(id);

                s.Delete(st);
                s.Flush();
                s.Close();

                return 1;
            }
            catch (Exception ex)
            {
                return -1;
            }
        }
        #endregion


        #region Sponzor -> CRUD

        //GET
        public static List<SponzorPregled> getInfosSponzor()
        {
            List<SponzorPregled> odInfos = new List<SponzorPregled>();
            try
            {
                ISession s = DataLayer.GetSession();
                IEnumerable<Sponzor> sponzori = from t in s.Query<Sponzor>()
                                               select t;
                foreach (Sponzor t in sponzori)
                {
                    odInfos.Add(new SponzorPregled(t.ime, t.opis,t.logo));
                }
                s.Close();
            }
            catch (Exception ex)
            {
                //exception
            }
            return odInfos;
        }

        //GET BY ID
        public static SponzorPregled GetSponzorBasic(int odId)
        {
            SponzorPregled tb = new SponzorPregled();
            try
            {
                ISession s = DataLayer.GetSession();

                Sponzor t = s.Load<Sponzor>(odId);
                tb = new SponzorPregled(t.ime, t.opis, t.logo);
                s.Close();
            }
            catch (Exception ex)
            {
                //exception
            }

            return tb;
        }

        //CREATE
        public int DodajSponzora(string ime, string opis, string logo)
        {
            try
            {

                ISession s = DataLayer.GetSession();

                Sponzor sponzor = new Sponzor();

                sponzor.ime = ime;
                sponzor.opis = opis;
                sponzor.logo = logo;

                s.Save(sponzor);
                return 1;
            }
            catch (Exception ex)
            {
                return -1;
            }
        }

        //UPDATE
        public static SponzorPregled UpdateSponzorPregled(SponzorPregled tb, int id)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Sponzor t = s.Load<Sponzor>(id);
                t.ime = tb.ime;
                t.opis=tb.opis;
                t.logo = tb.logo;

                s.Update(t);
                s.Flush();
                s.Close();
            }
            catch (Exception ex)
            {
                //Exception
            }
            return tb;
        }

        //DELETE
        public int DeleteSponzora(int id)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Sponzor st = s.Load<Sponzor>(id);

                s.Delete(st);
                s.Flush();
                s.Close();

                return 1;
            }
            catch (Exception ex)
            {
                return -1;
            }
        }
        #endregion


        #region Organizator -> CRUD

        //GET 
        public static List<OrganizatorPregled> getInfosOrganizator()
        {
            List<OrganizatorPregled> odInfos = new List<OrganizatorPregled>();
            try
            {
                ISession s = DataLayer.GetSession();
                IEnumerable<Organizator> organizatori = from t in s.Query<Organizator>()
                                                select t;
                foreach (Organizator t in organizatori)
                {
                    odInfos.Add(new OrganizatorPregled(t.ime, t.prezime, t.adresa));
                }
                s.Close();
            }
            catch (Exception ex)
            {
                //exception
            }
            return odInfos;
        }


        //GET BY ID
        public static OrganizatorPregled GetOrganizatorBasic(int odId)
        {

            OrganizatorPregled tb = new OrganizatorPregled();
            try
            {
                ISession s = DataLayer.GetSession();

                Organizator t = s.Load<Organizator>(odId);
                tb = new OrganizatorPregled(t.ime, t.prezime, t.adresa);
                s.Close();
            }
            catch (Exception ex)
            {
                //exception
            }

            return tb;
        }


        //CREATE
        public int DodajOrganizatora(string ime, string prezime, string adresa,int idTurnir)
        {
            try
            {

                ISession s = DataLayer.GetSession();
                Sahovski_turnir t = s.Load<Sahovski_turnir>(idTurnir);

                Organizator organizator = new Organizator();
                organizator.ime = ime;
                organizator.prezime = prezime;
                organizator.adresa = adresa;


                organizator.OrganizujeTurnir = t;
                s.Save(organizator);

                t.Organizatori.Add(organizator);
                s.Save(t);
                return 1;
            }
            catch (Exception ex)
            {
                return -1;
            }
        }


        //UPDATE
        public static OrganizatorPregled UpdateOrganizatorPregled(OrganizatorPregled tb, int id)
        {

            try
            {
                ISession s = DataLayer.GetSession();

                Organizator t = s.Load<Organizator>(id);
                t.ime = tb.ime;
                t.prezime = tb.prezime;
                t.adresa = tb.adresa;

                s.Update(t);
                s.Flush();
                s.Close();
            }
            catch (Exception ex)
            {
                //Exception
            }
            return tb;
        }


        //DELETE
        public int DeleteOrganizatora(int id)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Organizator st = s.Load<Organizator>(id);

                s.Delete(st);
                s.Flush();
                s.Close();

                return 1;
            }
            catch (Exception ex)
            {
                return -1;
            }
        }


        #endregion

        #region Partija -> CRUD
        //GET 
        public static List<PartijaPregled> getInfosPartija()
        {
            List<PartijaPregled> odInfos = new List<PartijaPregled>();
            try
            {
                ISession s = DataLayer.GetSession();
                IEnumerable<Partija> partije = from t in s.Query<Partija>()
                                               select t;
                foreach (Partija t in partije)
                {
                    odInfos.Add(new PartijaPregled(t.bele, t.crne, t.kad_se_igra, t.trajanje, t.pat, t.mat, t.rem));
                }
                s.Close();
            }
            catch (Exception ex)
            {
                //exception
            }
            return odInfos;
        }

        //GET BY ID
        public static PartijaPregled GetPartijaBasic(int odId)
        {

            PartijaPregled tb = new PartijaPregled();
            try
            {
                ISession s = DataLayer.GetSession();

                Partija t = s.Load<Partija>(odId);
                tb = new PartijaPregled(t.bele, t.crne, t.kad_se_igra, t.trajanje, t.pat, t.mat, t.rem);
                s.Close();
            }
            catch (Exception ex)
            {
                //exception
            }

            return tb;
        }

        //CREATE
        public int DodajPartija(string bele, string crne, string kad_se_igra, int trajanje, string pat, string mat, string rem, int idTurnir)
        {
            try
            {

                ISession s = DataLayer.GetSession();
                Sahovski_turnir t = s.Load<Sahovski_turnir>(idTurnir);

                Partija partija = new Partija();
                partija.bele = bele;
                partija.crne = crne;
                partija.kad_se_igra = kad_se_igra;
                partija.trajanje = trajanje;
                partija.pat = pat;
                partija.mat = mat;
                partija.rem = rem;


                partija.IgraSe = t;
                s.Save(partija);

                t.Partije.Add(partija);
                s.Save(t);
                s.Close();
                return 1;
            }
            catch (Exception ex)
            {
                return -1;
            }
        }

        //UPDATE
        public static PartijaPregled UpdatePartijaPregled(PartijaPregled tb, int id)
        {

            try
            {
                ISession s = DataLayer.GetSession();

                Partija t = s.Load<Partija>(id);
                t.bele = tb.bele;
                t.crne = tb.crne;
                t.kad_se_igra = tb.kad_se_igra;
                t.trajanje = tb.trajanje;
                t.pat = tb.pat;
                t.mat = tb.mat;
                t.rem = tb.rem;

                s.Update(t);
                s.Flush();
                s.Close();
            }
            catch (Exception ex)
            {
                //Exception
            }
            return tb;
        }

        //DELETE
        public int DeletePartija(int id)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Partija st = s.Load<Partija>(id);

                s.Delete(st);
                s.Flush();
                s.Close();

                return 1;
            }
            catch (Exception ex)
            {
                return -1;
            }
        }
        #endregion

        #region Potez -> CRUD

        //GET 
        public static List<PotezPregled> getInfosPotez()
        {
            List<PotezPregled> odInfos = new List<PotezPregled>();
            try
            {
                ISession s = DataLayer.GetSession();
                IEnumerable<Potez> potezi = from t in s.Query<Potez>()
                                               select t;
                foreach (Potez t in potezi)
                {
                    odInfos.Add(new PotezPregled(t.opis, t.kad_odigran));
                }
                s.Close();
            }
            catch (Exception ex)
            {
                //exception
            }
            return odInfos;
        }

        //GET BY ID
        public static PotezPregled GetPotezBasic(int odId)
        {

            PotezPregled tb = new PotezPregled();
            try
            {
                ISession s = DataLayer.GetSession();

                Potez t = s.Load<Potez>(odId);
                tb = new PotezPregled(t.opis, t.kad_odigran);
                s.Close();
            }
            catch (Exception ex)
            {
                //exception
            }

            return tb;
        }

        //CREATE
        public int DodajPotez(string Opis, string Kad_odigran, int idPartija)
        {
            try
            {

                ISession s = DataLayer.GetSession();
                Partija t = s.Load<Partija>(idPartija);

                Potez potez = new Potez();
                potez.opis = Opis;
                potez.kad_odigran = Kad_odigran;
                


                potez.je_odigran = t;
                s.Save(potez);

                t.Potezi.Add(potez);
                s.Save(t);
                s.Close();
                return 1;
            }
            catch (Exception ex)
            {
                return -1;
            }
        }

        //UPDATE
        public static PotezPregled UpdatePotezPregled(PotezPregled tb, int id)
        {

            try
            {
                ISession s = DataLayer.GetSession();

                Potez t = s.Load<Potez>(id);
                t.opis = tb.opis;
                t.kad_odigran = tb.kad_odigran;

                s.Update(t);
                s.Flush();
                s.Close();
            }
            catch (Exception ex)
            {
                //Exception
            }
            return tb;
        }

        //DELETE
        public int DeletePotez(int id)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Potez st = s.Load<Potez>(id);

                s.Delete(st);
                s.Flush();
                s.Close();

                return 1;
            }
            catch (Exception ex)
            {
                return -1;
            }
        }

        #endregion

        public int PoveziSponzorTurnir(Je_sponzorDTO je)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                Sahovski_turnir t = s.Load<Sahovski_turnir>(je.idTurnir);
                Sponzor sp = s.Load<Sponzor>(je.idSponzor);

                Je_sponzor je_sponzor = new Je_sponzor();

                je_sponzor.SponzorJe = sp;
                je_sponzor.SponzoriseTurnir = t;
                s.Save(je_sponzor);
                s.Close();
                return 1;
            }
            catch (Exception ex)
            {
                return -1;
            }
        }
    }
}
