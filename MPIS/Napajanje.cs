using System;

public class Napajanje {
	private readonly string id;
	public enum stanje {
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
	public stanje provjeraPrekidac(Prekidac prekidac)
	{
		return stanje.prvo;
	}
	public stanje provjeraRastavljac(Rastavljac rastavljac)
	{
		return stanje.prvo;
	}
	public stanje provjeraAPU(APU apu)
	{
		return stanje.prvo;
	}
	public stanje provjeraZastita(Zastita zastita)
	{
		return stanje.prvo;
	}
	public string uredajiNapajanje() 
	{
		return null;
	}
	public string uredajiBezNapajanja() 
	{
		return null;
	}
}
