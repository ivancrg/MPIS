using System;

//klasa rastavljac koju će nasljediti daljnji tipovi rastavljaca
public abstract class Rastavljac : IStanje {

	private readonly string id;
	private string ime;

	//nisam gldao koja su moguća stanja pa treba zamijeniti
	private enum stanje {
		nekoStanje,
		drugoStanje
	}
	stanje trenutnoStanje;

	public stanje getStanje(){
		return trenutnoStanje;
	}

	public void setStanje(stanje tmp) {
		trenutnoStanje = tmp;
    }

	public void ukljuci();
	public void iskljuci();
	public void osvjeziStanje(stanje novo);

}

public class RastavljacIzlazni : Rastavljac {
	public RastavljacIzlazni(string ime, string id) {
		this.ime = ime;
		this.id = id;
	}
}

public class RastavljacSabirnicki : Rastavljac {

	private readonly int redniBroj;

	public RastavljacSabirnicki(string ime, string id, int broj) {
		this.ime = ime;
		this.id = id;
		redniBroj = broj;
    }

	public int getRedniBroj() {
		return redniBroj;
    }
}

public class RastavljacUzemljenja : Rastavljac {
	public RastavljacUzemljenja(string ime, string id) {
		this.ime = ime;
		this.id = id;
    }
}
