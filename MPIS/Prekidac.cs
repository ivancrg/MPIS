using System;
using System.Windows.Forms;

public abstract class Prekidac : IStanje
{
	protected string ime;
	protected string id;
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

		MessageBox.Show("Prekidač uključen.");

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

		MessageBox.Show("Prekidač uključen.");

		trenutnoStanje = stanje.uključen;

		return true;
    }

	public bool iskljuci(APU apu)
	{
		if(apu.getStanje() == APU.stanje.uključen)
		{
			MessageBox.Show("APU je uključena, prekidač se ne može isključiti.");
			return false;
		}

		MessageBox.Show("Prekidač isključen.");

		trenutnoStanje = stanje.isključen;

		return true;
	}

	public void osvjeziVrijednosti()
	{
		throw new NotImplementedException();
	}

	public void PrikaziSignale()
	{
		throw new NotImplementedException();
	}

	public void prikaziSignaleTrenutni()
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
}
