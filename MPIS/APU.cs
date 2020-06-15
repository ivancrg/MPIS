using System;

public class APU : IStanje
{
	public APU(string ime, string id)
	{
		this.ime = ime;
		this.id = id;
	}

	public enum stanje
	{
		uključen,
		isključen
	}

	private stanje trenutnoStanje = stanje.isključen;
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
		trenutnoStanje = stanje.uključen;
	}

	public void iskljuci()
	{
		trenutnoStanje = stanje.isključen;
	}

	public bool ukljuciPrekidac(Prekidac prekidac, RastavljacSabirnicki s1, RastavljacIzlazni ir, RastavljacUzemljenja ru)
	{
		return prekidac.ukljuci(s1, ir, ru);
	}

	public bool ukljuciPrekidac(Prekidac prekidac, RastavljacSabirnicki s1, RastavljacSabirnicki s2, RastavljacIzlazni ir, RastavljacUzemljenja ru)
	{
		return prekidac.ukljuci(s1, s2, ir, ru);
	}

	public stanje getStanje() { return trenutnoStanje; }

	public void osvjeziVrijednosti() {
		//potrebno dodati implementaciju
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
