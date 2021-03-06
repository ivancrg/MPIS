﻿using System;
using System.Text;
using System.Windows.Forms;

//klasa rastavljac koju će nasljediti daljnji tipovi rastavljaca
public abstract class Rastavljac : IStanje {

	protected string id;
	protected string ime;
	protected bool komanda;

	public enum stanje
	{
		uključen,
		isključen,
		međupoložaj,
		kvar_signalizacije
	}

	private stanje trenutnoStanje = stanje.isključen;

	public stanje getStanje(){
		return trenutnoStanje;
	}

	public void setStanje(stanje tmp) {
		trenutnoStanje = tmp;
    }

	public bool ukljuci(Prekidac p, RastavljacUzemljenja ru)
	{
		throw new NotImplementedException();
	}

	public bool ukljuci(Prekidac p, RastavljacSabirnicki rs)
	{
		throw new NotImplementedException();
	}

	public bool ukljuci(Prekidac p)
	{
		throw new NotImplementedException();
	}

	public bool iskljuci(Prekidac p)
	{
		throw new NotImplementedException();
	}

	public bool iskljuci()
	{
		throw new NotImplementedException();
	}

	public void osvjeziStanje()
	{
		throw new NotImplementedException();
	}

	public string PrikaziSignale()
	{
		StringBuilder sb = new StringBuilder();
		sb.AppendLine(ime + " komanda isklop");
		sb.AppendLine(ime + " komanda uklop");
		sb.AppendLine(ime + " stanje međupoložaj");
		sb.AppendLine(ime + " stanje isključen");
		sb.AppendLine(ime + " stanje uključen");
		sb.AppendLine(ime + " stanje kvar signalizacije");
		sb.AppendLine("");

		return sb.ToString();
	}

	public string prikaziSignaleTrenutni()
	{
		StringBuilder sb = new StringBuilder();
		sb.AppendLine(ime + " komanda " + ((komanda) ? ("uklop") : ("isklop")));
		sb.AppendLine(ime + " stanje " + getStanje());
		sb.AppendLine("");

		return sb.ToString();
	}

	public string prikaziSignaleGrupni()
	{
		StringBuilder sb = new StringBuilder();
		sb.AppendLine("");

		return sb.ToString();
	}
}

public class RastavljacIzlazni : Rastavljac {
	public RastavljacIzlazni(string ime, string id) {
		this.ime = ime;
		this.id = id;
	}

	new public bool ukljuci(Prekidac p, RastavljacUzemljenja ru)
	{
		if (p.getStanje() != Prekidac.stanje.isključen)
		{
			MessageBox.Show("Nije moguće uključiti izlazni rastavljač dok je prekidač uključen.");
			return false;
		}
		else if (ru.getStanje() != stanje.isključen)
		{
			MessageBox.Show("Nije moguće uključiti izlazni rastavljač dok je uzemljenje uključeno.");
			return false;
		}

		komanda = true;
		setStanje(stanje.uključen);

		//MessageBox.Show("Izlazni rastavljač uključen.");

		return true;
	}

	new public bool iskljuci(Prekidac p)
	{
		if (p.getStanje() != Prekidac.stanje.isključen)
		{
			MessageBox.Show("Nije moguće isključiti izlazni rastavljač dok je prekidač uključen.");
			return false;
		}

		komanda = false;
		setStanje(stanje.isključen);

		//MessageBox.Show("Izlazni rastavljač isključen.");

		return true;
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

	new public bool ukljuci(Prekidac p, RastavljacSabirnicki rs)
	{
		if (p.getStanje() != Prekidac.stanje.isključen || rs.getStanje() != stanje.isključen)
		{
			MessageBox.Show("Nije moguće uključiti sabirnički rastavljač dok je prekidač ili drugi sabirnički rastavljač uključen.");
			return false;
		}

		komanda = true;
		setStanje(stanje.uključen);

		//MessageBox.Show("Sabirnički rastavljač uključen.");

		return true;
	}

	new public bool ukljuci(Prekidac p)
	{
		if (p.getStanje() != Prekidac.stanje.isključen)
		{
			MessageBox.Show("Nije moguće uključiti sabirnički rastavljač dok je prekidač uključen.");
			return false;
		}

		komanda = true;
		setStanje(stanje.uključen);

		//MessageBox.Show("Sabirnički rastavljač uključen.");

		return true;
	}

	new public bool iskljuci(Prekidac p)
	{
		if (p.getStanje() != Prekidac.stanje.isključen)
		{
			MessageBox.Show("Nije moguće isključiti sabirnički rastavljač dok je prekidač uključen.");
			return false;
		}

		komanda = false;
		setStanje(stanje.isključen);

		//MessageBox.Show("Sabirnički rastavljač isključen.");

		return true;
	}
}

public class RastavljacUzemljenja : Rastavljac {
	public RastavljacUzemljenja(string ime, string id) {
		this.ime = ime;
		this.id = id;
    }

	new public bool ukljuci(Prekidac p)
	{
		if (p.getStanje() != Prekidac.stanje.isključen)
		{
			MessageBox.Show("Nije moguće uključiti rastavljač uzemljenja dok je prekidač uključen.");
			return false;
		}

		setStanje(stanje.uključen);

		//MessageBox.Show("Rastavljač uzemljenja uključen.");

		return true;
	}

	new public bool iskljuci()
	{
		if (getStanje() == stanje.isključen)
		{
			MessageBox.Show("Rastavljač uzemljenja je već isključen.");
			return true;
		}

		setStanje(stanje.isključen);

		//MessageBox.Show("Sabirnički rastavljač isključen.");

		return true;
	}

	new public string PrikaziSignale()
	{
		StringBuilder sb = new StringBuilder();
		sb.AppendLine(ime + " stanje međupoložaj");
		sb.AppendLine(ime + " stanje isključen");
		sb.AppendLine(ime + " stanje uključen");
		sb.AppendLine(ime + " stanje kvar signalizacije");
		sb.AppendLine("");

		return sb.ToString();
	}

	new public string prikaziSignaleTrenutni()
	{
		StringBuilder sb = new StringBuilder();
		sb.AppendLine(ime + " stanje " + getStanje());
		sb.AppendLine("");

		return sb.ToString();
	}
}
