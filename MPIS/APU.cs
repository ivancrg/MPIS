using System;
using System.Text;

public class APU : IStanje
{
	public APU(string ime, string id)
	{
		this.ime = ime;
		this.id = id;
	}

	private readonly string id;
	private readonly string ime;
	private bool ukljucenje;
	private bool p1; //zamijenjeno s 1p pošto ne smije počinjati brojem
	private bool p3;
	private bool blokada;

    public bool Ukljucenje { get => ukljucenje; set => ukljucenje = value; }
    public bool P1 { get => p1; set => p1 = value; }
    public bool P3 { get => p3; set => p3 = value; }
    public bool Blokada { get => blokada; set => blokada = value; }

	public void ukljuci()
	{
		ukljucenje = true;
	}

	public void iskljuci()
	{
		ukljucenje = false;
	}

	public bool ukljuciPrekidac(Prekidac prekidac, RastavljacSabirnicki s1, RastavljacIzlazni ir, RastavljacUzemljenja ru)
	{
		return prekidac.ukljuci(s1, ir, ru);
	}

	public bool ukljuciPrekidac(Prekidac prekidac, RastavljacSabirnicki s1, RastavljacSabirnicki s2, RastavljacIzlazni ir, RastavljacUzemljenja ru)
	{
		return prekidac.ukljuci(s1, s2, ir, ru);
	}


	public void osvjeziVrijednosti() {
		//potrebno dodati implementaciju
		throw new NotImplementedException();
	}

	public string PrikaziSignale()
	{
		StringBuilder sb = new StringBuilder();
		sb.AppendLine(ime + " APU uključenje prorada");
		sb.AppendLine(ime + " APU uključenje prestanak");
		sb.AppendLine(ime + " APU 1p prorada");
		sb.AppendLine(ime + " APU 1p prestanak");
		sb.AppendLine(ime + " APU 3p prorada");
		sb.AppendLine(ime + " APU 3p prestanak");
		sb.AppendLine(ime + " APU blokada prorada");
		sb.AppendLine(ime + " APU blokada prestanak");
		sb.AppendLine("");

		return sb.ToString();
	}

	public string prikaziSignaleTrenutni()
	{
		StringBuilder sb = new StringBuilder();
		sb.AppendLine(ime + " APU uključenje " + ((ukljucenje) ? ("prorada") : ("prestanak")));
		sb.AppendLine(ime + " APU 1p " + ((p1) ? ("prorada") : ("prestanak")));
		sb.AppendLine(ime + " APU 3p " + ((p3) ? ("prorada") : ("prestanak")));
		sb.AppendLine(ime + " APU blokada " + ((blokada) ? ("prorada") : ("prestanak")));
		sb.AppendLine("");

		return sb.ToString();
	}

	public string prikaziSignaleGrupni()
	{
		StringBuilder sb = new StringBuilder();
		sb.AppendLine(ime + " APU blokada prorada");
		sb.AppendLine(ime + " APU blokada prestanak");
		sb.AppendLine("");

		return sb.ToString();
	}
}
