using System;
using System.Text;
using System.Windows.Forms;

public abstract class Prekidac : IStanje
{
	protected string ime;
	protected string id;
	protected bool komanda;

	public enum stanje {
		uključen,
		isključen,
		međupoložaj,
		kvar_signalizacije
    }

	private stanje trenutnoStanje = stanje.isključen;

	public stanje getStanje() {
		return trenutnoStanje;
    }

	public void setStanje(stanje tmp) {
		trenutnoStanje = tmp;
    }

	public bool ukljuci(RastavljacSabirnicki rs1, RastavljacIzlazni ri, RastavljacUzemljenja ru)
	{
		if (rs1.getStanje() != Rastavljac.stanje.uključen || ri.getStanje() != Rastavljac.stanje.uključen || ru.getStanje() != Rastavljac.stanje.isključen)
		{
			MessageBox.Show("Prekidač se ne može uključiti. Provjeri jesu li sabirnički i izlazni rastavljači uključeni. Provjeri je li rastavljač uzemljenja isključen.");
			return false;
		}

		//MessageBox.Show("Prekidač uključen.");

		trenutnoStanje = stanje.uključen;

		return true;
	}

	public bool ukljuci(RastavljacSabirnicki rs1, RastavljacSabirnicki rs2, RastavljacIzlazni ri, RastavljacUzemljenja ru)
	{
		if((rs1.getStanje() != Rastavljac.stanje.uključen && rs2.getStanje() != Rastavljac.stanje.uključen) || 
		   ri.getStanje() != Rastavljac.stanje.uključen || ru.getStanje() != Rastavljac.stanje.isključen)
		{
			MessageBox.Show("Prekidač se ne može uključiti. Provjeri jesu li sabirnički i izlazni rastavljači uključeni. Provjeri je li rastavljač uzemljenja isključen.");
			return false;
		}

		//MessageBox.Show("Prekidač uključen.");

		komanda = true;
		trenutnoStanje = stanje.uključen;

		return true;
    }

	public bool iskljuci(APU apu)
	{
		if(apu.Ukljucenje == true)
		{
			MessageBox.Show("APU je uključena, prekidač se ne može isključiti.");
			return false;
		}

		//MessageBox.Show("Prekidač isključen.");

		komanda = false;
		trenutnoStanje = stanje.isključen;

		return true;
	}

	public void osvjeziVrijednosti()
	{
		throw new NotImplementedException();
	}

	public string PrikaziSignale()
	{
		throw new NotImplementedException();
	}

	public string prikaziSignaleTrenutni()
	{
		throw new NotImplementedException();
	}

	public string prikaziSignaleGrupni()
	{
		throw new NotImplementedException();
	}
}

public class PrekidacSF6ABB : Prekidac {
	private bool gubitakSF6;
	private bool blokadaRada;
	private bool blokadaIsklopa;
	private bool oprugaKvar;


	public PrekidacSF6ABB(string ime, string id)
	{
		this.ime = ime;
		this.id = id;
	}

	public bool GubitakSF6 { get => gubitakSF6; set => gubitakSF6 = value; }
	public bool BlokadaRada { get => blokadaRada; set => blokadaRada = value; }
	public bool BlokadaIsklopa { get => blokadaIsklopa; set => blokadaIsklopa = value; }
	public bool OprugaKvar { get => oprugaKvar; set => oprugaKvar = value; }

	new public string PrikaziSignale()
	{
		StringBuilder sb = new StringBuilder();
		sb.AppendLine(ime + " komanda isklop");
		sb.AppendLine(ime + " komanda uklop");
		sb.AppendLine(ime + " stanje međupoložaj");
		sb.AppendLine(ime + " stanje isključen");
		sb.AppendLine(ime + " stanje uključen");
		sb.AppendLine(ime + " stanje kvar signalizacije");
		sb.AppendLine(ime + " gubitak SF6 - upozorenje prorada");
		sb.AppendLine(ime + " gubitak SF6 - upozorenje prestanak");
		sb.AppendLine(ime + " blokada rada prorada");
		sb.AppendLine(ime + " blokada rada prestanak");
		sb.AppendLine(ime + " blokada isklopa prorada");
		sb.AppendLine(ime + " blokada isklopa prestanak");
		sb.AppendLine(ime + " opruga navijena - kvar prorada");
		sb.AppendLine(ime + " opruga navijena - kvar prestanak");
		sb.AppendLine("");

		return sb.ToString();
	}

	new public string prikaziSignaleTrenutni()
	{
		StringBuilder sb = new StringBuilder();
		sb.AppendLine(ime + " komanda " + ((komanda)?("uklop"):("isklop")));
		sb.AppendLine(ime + " stanje " + getStanje());
		sb.AppendLine(ime + " gubitak SF6 - upozorenje " + ((gubitakSF6)?("prorada"):("prestanak")));
		sb.AppendLine(ime + " blokada rada " + ((blokadaRada) ? ("prorada") : ("prestanak")));
		sb.AppendLine(ime + " blokada isklopa " + ((blokadaIsklopa) ? ("prorada") : ("prestanak")));
		sb.AppendLine(ime + " opruga navijena - kvar " + ((oprugaKvar) ? ("prorada") : ("prestanak")));
		sb.AppendLine("");

		return sb.ToString();
	}

	new public string prikaziSignaleGrupni()
	{
		StringBuilder sb = new StringBuilder();
		sb.AppendLine(ime + " gubitak SF6 - upozorenje prorada");
		sb.AppendLine(ime + " gubitak SF6 - upozorenje prestanak");
		sb.AppendLine(ime + " blokada rada prorada");
		sb.AppendLine(ime + " blokada rada prestanak");
		sb.AppendLine(ime + " blokada isklopa prorada");
		sb.AppendLine(ime + " blokada isklopa prestanak");
		sb.AppendLine(ime + " opruga navijena - kvar prorada");
		sb.AppendLine(ime + " opruga navijena - kvar prestanak");
		sb.AppendLine("");

		return sb.ToString();
	}
}

public class Prekidac3PKoncar : Prekidac {
	private bool padTlaka16;
	private bool padTlaka14;
	private bool padTlaka11;
	private bool APUBlokada;
	private bool neskladPolova;
	private bool upravljanje;

    public bool PadTlaka16 { get => padTlaka16; set => padTlaka16 = value; }
    public bool PadTlaka14 { get => padTlaka14; set => padTlaka14 = value; }
    public bool PadTlaka11 { get => padTlaka11; set => padTlaka11 = value; }
    public bool APUBlokada1 { get => APUBlokada; set => APUBlokada = value; }
    public bool NeskladPolova { get => neskladPolova; set => neskladPolova = value; }
    public bool Upravljanje { get => upravljanje; set => upravljanje = value; }

	public Prekidac3PKoncar(string ime, string id)
	{
		this.ime = ime;
		this.id = id;
	}

	new public string PrikaziSignale()
	{
		StringBuilder sb = new StringBuilder();
		sb.AppendLine(ime + " komanda isklop");
		sb.AppendLine(ime + " komanda uklop");
		sb.AppendLine(ime + " stanje međupoložaj");
		sb.AppendLine(ime + " stanje isključen");
		sb.AppendLine(ime + " stanje uključen");
		sb.AppendLine(ime + " stanje kvar signalizacije");
		sb.AppendLine(ime + " pad tlaka <16 b prorada");
		sb.AppendLine(ime + " pad tlaka <16 b prestanak");
		sb.AppendLine(ime + " pad tlaka <14 b prorada");
		sb.AppendLine(ime + " pad tlaka <14 b prestanak");
		sb.AppendLine(ime + " pad tlaka <11 b prorada");
		sb.AppendLine(ime + " pad tlaka <11 b prestanak");
		sb.AppendLine(ime + " APU blokada prorada");
		sb.AppendLine(ime + " APU blokada prestanak");
		sb.AppendLine(ime + " nesklad polova - 3P isklop prorada");
		sb.AppendLine(ime + " nesklad polova - 3P isklop prestanak");
		sb.AppendLine(ime + " upravljanje daljinsko");
		sb.AppendLine(ime + " upravljanje lokalno");
		sb.AppendLine("");

		return sb.ToString();
	}

	new public string prikaziSignaleTrenutni()
	{
		StringBuilder sb = new StringBuilder();
		sb.AppendLine(ime + " komanda " + ((komanda) ? ("uklop") : ("isklop")));
		sb.AppendLine(ime + " stanje " + getStanje());
		sb.AppendLine(ime + " pad tlaka <16 b " + ((padTlaka16) ? ("prorada") : ("prestanak")));
		sb.AppendLine(ime + " pad tlaka <14 b " + ((padTlaka14) ? ("prorada") : ("prestanak")));
		sb.AppendLine(ime + " pad tlaka <11 b " + ((padTlaka11) ? ("prorada") : ("prestanak")));
		sb.AppendLine(ime + " APU blokada " + ((APUBlokada) ? ("prorada") : ("prestanak")));
		sb.AppendLine(ime + " nesklad polova - 3P isklop " + ((neskladPolova) ? ("prorada") : ("prestanak")));
		sb.AppendLine(ime + " upravljanje " + ((upravljanje) ? ("daljinsko") : ("lokalno")));
		sb.AppendLine("");

		return sb.ToString();
	}

	new public string prikaziSignaleGrupni()
	{
		StringBuilder sb = new StringBuilder();
		sb.AppendLine(ime + " pad tlaka <16 b prorada");
		sb.AppendLine(ime + " pad tlaka <16 b prestanak");
		sb.AppendLine(ime + " pad tlaka <14 b prorada");
		sb.AppendLine(ime + " pad tlaka <14 b prestanak");
		sb.AppendLine(ime + " pad tlaka <11 b prorada");
		sb.AppendLine(ime + " pad tlaka <11 b prestanak");
		sb.AppendLine(ime + " APU blokada prorada");
		sb.AppendLine(ime + " APU blokada prestanak");
		sb.AppendLine(ime + " nesklad polova - 3P isklop prorada");
		sb.AppendLine(ime + " nesklad polova - 3P isklop prestanak");
		sb.AppendLine("");

		return sb.ToString();
	}
}
