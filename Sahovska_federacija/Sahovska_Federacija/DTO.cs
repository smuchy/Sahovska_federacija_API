using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace Sahovska_Federacija
{

    #region Federacija

    [DataContract]
    public class FederacijaPregled
    {
        [DataMember]
        public string lokacija { get; set; }

        public FederacijaPregled() { }
        public FederacijaPregled(string lokacija)
        {
            this.lokacija = lokacija;
        }
    }
    #endregion


    #region Turniri 

    [DataContract]
    public class TurnirPregled
    {
        [DataMember]
        public string naziv { get; set; }
        [DataMember]
        public string zemlja { get; set; }
        [DataMember]
        public string grad { get; set; }
        [DataMember]
        public int god_odrzavanja { get; set; }
        [DataMember]
        public string tip { get; set; }

        public TurnirPregled() { }

        public TurnirPregled(string Naziv, string Zemlja, string Grad, int God_odrzavanja, string Tip)
        {
            this.naziv = Naziv;
            this.zemlja = Zemlja;
            this.grad = Grad;
            this.god_odrzavanja = God_odrzavanja;
            this.tip = Tip;
        }


    }

    [DataContract]
    public class BrzopotezniPregled : TurnirPregled
    {
        [DataMember]
        public int max_vreme_trajanja_partija { get; set; }

        public BrzopotezniPregled() { }

        public BrzopotezniPregled(string Naziv, string Zemlja, string Grad, int God_odrzavanja, int Max_vreme_trajanja)
            : base(Naziv, Zemlja, Grad, God_odrzavanja, "brzopotezni")
        {
            this.max_vreme_trajanja_partija = Max_vreme_trajanja;
        }
    }

    [DataContract]
    public class EgzibicioniPregled : TurnirPregled
    {
        public EgzibicioniPregled() { }

        public EgzibicioniPregled(string Naziv, string Zemlja, string Grad, int God_odrzavanja)
            : base(Naziv, Zemlja, Grad, God_odrzavanja, "egzibicioni")
        {

        }
    }

    [DataContract]
    public class HumanitarniPregled : TurnirPregled
    {
        [DataMember]
        public string kome_je_namenjen { get; set; }
        [DataMember]
        public int prikupljeni_iznos { get; set; }
        public HumanitarniPregled() { }

        public HumanitarniPregled(string Naziv, string Zemlja, string Grad, int God_odrzavanja,string kome_je_namenjen, int prikupljeni_iznos)
            : base(Naziv, Zemlja, Grad, God_odrzavanja, "humanitarni")
        {
            this.kome_je_namenjen = kome_je_namenjen;
            this.prikupljeni_iznos = prikupljeni_iznos;
        }
    }

    [DataContract]
    public class NormalniPregled : TurnirPregled
    {
        public NormalniPregled() { }

        public NormalniPregled(string Naziv, string Zemlja, string Grad, int God_odrzavanja)
            : base(Naziv, Zemlja, Grad, God_odrzavanja, "normalni")
        {

        }
    }

    [DataContract]
    public class PromotivniPregled : TurnirPregled
    {
        public PromotivniPregled() { }

        public PromotivniPregled(string Naziv, string Zemlja, string Grad, int God_odrzavanja)
            : base(Naziv, Zemlja, Grad, God_odrzavanja, "promotivni")
        {

        }
    }

    [DataContract]
    public class TakmicarskiPregled : TurnirPregled
    {
        [DataMember]
        public string internacionalni { get; set; }
        [DataMember]
        public string regionalni { get; set; }
        [DataMember]
        public string nacionalni { get; set; }

        public TakmicarskiPregled() { }

        public TakmicarskiPregled(string Naziv, string Zemlja, string Grad, int God_odrzavanja, string internacionalni, string regionalni,string nacionalni)
            : base(Naziv, Zemlja, Grad, God_odrzavanja, "takmicarski")
        {
            this.internacionalni = internacionalni;
            this.regionalni = regionalni;
            this.nacionalni = nacionalni;
        }
    }


    public class TurnirBasic
    {
        public int turnirId { get; set; }
        public string naziv { get; set; }
        public string zemlja { get; set; }
        public string grad { get; set; }
        public int god_odrzavanja { get; set; }
        public string tip { get; set; }

        public TurnirBasic(int id, string Naziv, string Zemlja, string Grad, int odrzavanje, string Tip)
        {
            this.turnirId = id;
            this.naziv = Naziv;
            this.zemlja = Zemlja;
            this.grad = Grad;
            this.god_odrzavanja = odrzavanje;
            this.tip = Tip;
        }

        public TurnirBasic() { }
    }

    #endregion


    #region Sahiste
    [DataContract]
    public class SahistaPregled
    {
        [DataMember]
        public int br_pasosa { get; set; }
        [DataMember]
        public string ime { get; set; }
        [DataMember]
        public string prezime { get; set; }
        [DataMember]
        public string ulica { get; set; }
        [DataMember]
        public int broj { get; set; }
        [DataMember]
        public string datum_rodjenja { get; set; }
        [DataMember]
        public string zemlja_porekla { get; set; }
        [DataMember]
        public string tip { get; set; }

        public SahistaPregled(){ }

        public SahistaPregled(int br_pasosa, string ime,string prezime, string ulica, int broj, string datum_rodjenja, string zemlja_porekla,string tip)
        {
            this.br_pasosa = br_pasosa;
            this.ime = ime;
            this.prezime = prezime;
            this.ulica = ulica;
            this.broj = broj;
            this.datum_rodjenja = datum_rodjenja;
            this.zemlja_porekla = zemlja_porekla;
            this.tip = tip;
        }



    }


    public class ObicanClanPregled : SahistaPregled
    {

        public ObicanClanPregled() { }

        public ObicanClanPregled(int br_pasosa, string ime, string prezime, string ulica, int broj, string datum_rodjenja, string zemlja_porekla)
            : base( br_pasosa, ime, prezime,ulica, broj,datum_rodjenja,zemlja_porekla,"obican_clan")
        {
            
        }
    }


    [DataContract]
    public class MajstorskiKandidatPregled : SahistaPregled
    {
        [DataMember]
        public int br_odigranih_partija { get; set; }

        [DataMember]
        public int br_partija_do_zvanja { get; set; }
        public MajstorskiKandidatPregled() { }

        public MajstorskiKandidatPregled(int br_pasosa, string ime, string prezime, string ulica, int broj, string datum_rodjenja, string zemlja_porekla,int br_odigranih_partija,int br_partija_do_zvanja)
            : base(br_pasosa, ime, prezime, ulica, broj, datum_rodjenja, zemlja_porekla, "majstorski_kandidat")
        {
            this.br_odigranih_partija = br_odigranih_partija;
            this.br_partija_do_zvanja = br_partija_do_zvanja;
        }
    }

    [DataContract]
    public class MajstorPregled : SahistaPregled
    {
        [DataMember]
        public string datum_sticanja_zvanja { get; set; }

        public MajstorPregled() { }

        public MajstorPregled(int br_pasosa,string ime,string prezime,string ulica,int broj,string datum_rodjenja,string zemlja_porekla,string Datum_sticanja_zvanja)
            : base(br_pasosa,ime,prezime,ulica,broj,datum_rodjenja,zemlja_porekla,"majstor")
        {
            this.datum_sticanja_zvanja = Datum_sticanja_zvanja;
        }
    }
    #endregion


    [DataContract]
    public class SponzorPregled
    {
        [DataMember]
        public string ime { get; set; }

        [DataMember]
        public string opis { get; set;}

        [DataMember]
        public string logo { get; set; }

        public SponzorPregled() { }

        public SponzorPregled(string ime, string opis,string logo)
        {
            this.ime = ime;
            this.opis = opis;
            this.logo = logo;
        }
    }

    [DataContract]
    public class OrganizatorPregled
    {

        [DataMember]
        public string ime { get; set; }

        [DataMember]
        public string prezime { get; set;}

        [DataMember]
        public string adresa { get; set; }


        public OrganizatorPregled() { }

        public  OrganizatorPregled(string ime, string prezime, string adresa)
        {
            this.ime = ime;
            this.prezime = prezime;
            this.adresa = adresa;
        }
    }

    [DataContract]
    public class PartijaPregled
    {
        [DataMember]
        public string bele { get; set; }
        [DataMember]
        public string crne { get; set; }
        [DataMember]
        public string kad_se_igra { get; set; }
        [DataMember]
        public int trajanje { get; set; }
        [DataMember]
        public string pat { get; set; }
        [DataMember]
        public string mat { get; set; }
        [DataMember]
        public string rem { get; set; }

        public PartijaPregled() { }

        public PartijaPregled(string Bele, string Crne, string Kad_se_igra, int Trajanje, string Pat, string Mat, string Rem)
        {
            this.bele = Bele;
            this.crne = Crne;
            this.kad_se_igra = Kad_se_igra;
            this.trajanje = Trajanje;
            this.pat = Pat;
            this.mat = Mat;
            this.rem = Rem;
        }

    }

    [DataContract]
    public class PotezPregled
    {
        [DataMember]
        public string opis { get; set; }
        [DataMember]
        public string kad_odigran { get; set; }

        public PotezPregled() { }

        public PotezPregled (string Opis, string Kad_odigran)
        {
            this.opis = Opis;
            this.kad_odigran = Kad_odigran;
        }
    }

    [DataContract]
    public class Je_sponzorDTO
    {
        [DataMember]
        public int idTurnir { get; set; }
        [DataMember]
        public int idSponzor { get; set; }

        public Je_sponzorDTO() { }

        public Je_sponzorDTO(int idT, int idS)
        {
            this.idSponzor = idS;
            this.idTurnir = idT;
        }
    }
   
}
