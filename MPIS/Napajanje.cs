using System;

public class Napajanje {
	private readonly string id;
	private enum stanje {
		prvo,
		drugo
	}

	private bool napajanjePrekidac;
	private bool napajanjeRastavljac;
	private bool napajanjeAPU;
	private bool napajanjeZastita;
	public Napajanje(string id) {
		this.id = id;
	}

	//potrebno dodati implementaciju
	public stanje provjeraPrekidac(Prekidac prekidac) { }
	public stanje provjeraRastavljac(Rastavljac rastavljac) { }
	public stanje provjeraAPU(APU apu) { }
	public stanje provjeraZastita(Zastita zastita) { }
	public string uredajiNapajanje() { }
	public string uredajiBezNapajanja() { }
	
}
