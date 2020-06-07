using System;

public abstract class Prekidac : IStanje
{
	private readonly string id;
	private enum stanje {
		prvo,
		drugo
    }

	stanje trenutnoStanje;

	public stanje GetStanje() {
		return trenutnoStanje;
    }

	public void setStanje(stanje tmp) {
		trenutnoStanje = tmp;
    }

	public bool ukljuci() {
		//zamijenjeno je s void tipom radi lakše daljnje obrade
		//potrebno dodati implementaciju
    }

	public bool iskljuci() { }

	public void osvjeziVrijednosti() {
		//potrebna implementacija
    }

}

public class PrekidacSF6ABB : Prekidac {

	private bool gubitakSF6;
	private bool blokadaRada;
	private bool blokadaIsklopa;
	private bool oprugaKvar;

	public bool GubitakSF6 { get => gubitakSF6; set => gubitakSF6 = value; }
	public bool BlokadaRada { get => blokadaRada; set => blokadaRada = value; }
	public bool BlokadaIsklopa { get => blokadaIsklopa; set => blokadaIsklopa = value; }
	public bool OprugaKvar { get => oprugaKvar; set => oprugaKvar = value; }
    public Prekidac3PKoncar(string id) => this.id = id;

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
    public Prekidac3PKoncar(string id) => this.id = id;
}
