using System;

public class DVPolje
{
	public DVPolje(string ime){
		this.ime = ime;
	}

	private string ime;
	private bool stanje;
	private float napon;

	private bool unutarnjaSmetnjaIskljucenje()
	{
		return false;
	}

	private bool ostaleZastiteIskljucene()
	{
		return false;
	}

	private bool zastiteUpozorenje()
	{
		return false;
	}

	private bool primarnaOpremaUpozorenje()
	{
		return false;
	}

	private bool sekundarnaOpremaUpozorenje()
	{
		return false;
	}

	private bool pomocniUredaji()
	{
		return false;
	}

	public string getIme(){
		return ime;
    }

	public bool getStanje() {
		return stanje;
	}

	//uz pomoc dijagrama slijeda zadatka 3 dovršiti metodu ukljuci/iskljuci
	public void ukljuci() {

    }

	public void iskljuci() {

    }

	//uz pritisak gumba pozvati ovu metodu
	//potrebno dovršiti implementaciju 
	public void prikaziSignalePolja() {

    }

	public void prikaziSignalePoljaTrenutni() {

    }
}
