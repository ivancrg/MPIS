using System;

public class APU : IStanje
{
	public APU(string ime, string id)
	{
		this.ime = ime;
		this.id = id;
	}

	private readonly string id;
	private string ime;
	private bool ukljucenje;
	private bool p1; //zamijenjeno s 1p pošto nesmije počinjat brojem
	private bool p3;
	private bool blokada;

    public bool Ukljucenje { get => ukljucenje; set => ukljucenje = value; }
    public bool P1 { get => p1; set => p1 = value; }
    public bool P3 { get => p3; set => p3 = value; }
    public bool Blokada { get => blokada; set => blokada = value; }

	public bool ukljuciPrekidac(Prekidac prekidac) {
		return prekidac.ukljuci();
    }

	public void osvjeziVrijednosti() {
		//potrebno dodati implementaciju
    }
}
