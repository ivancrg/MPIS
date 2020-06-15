using System;
using System.Text;

public abstract class Mjerenja : IStanje
{
	protected string ime;
	protected string id;
	private float vrijednost = 0.0f;

	//potrebna implementacija
	public void osvjeziVrijednosti()
    { 
        //izracun vrijednosti
        //vrijednost = ...
    }
	public float getVrijednost() {
		return vrijednost;
	}

	public string PrikaziSignale()
	{
		throw new NotImplementedException();
	}

	public string prikaziSignaleTrenutni()
	{
		throw new NotImplementedException();
	}

	public string prikaziSignaleGrupni()
	{
		return "";
	}
}

public class Watmetar : Mjerenja {
	private bool tip; //false radna, true jalova

	public Watmetar(string ime, string id, bool tip) {
		this.ime = ime;
		this.id = id;
		this.tip = tip;
    }

	public float getSnaga()
	{
		return getVrijednost();
	}

	new public string PrikaziSignale()
	{
		StringBuilder sb = new StringBuilder();
		if (tip)
			sb.AppendLine(ime + " radna snaga (MW) mjerena vel.");
		else
			sb.AppendLine(ime + " jalova snaga (MVAr) mjerena vel.");
		sb.AppendLine("");

		return sb.ToString();
	}

	new public string prikaziSignaleTrenutni()
	{
		StringBuilder sb = new StringBuilder();
		if (tip)
			sb.AppendLine(ime + " radna snaga (MW) mjerena vel.");
		else
			sb.AppendLine(ime + " jalova snaga (MVAr) mjerena vel.");
		sb.AppendLine("");

		return sb.ToString();
	}
}

public class Voltmetar : Mjerenja {
    public Voltmetar(string ime, string id)
	{
		this.ime = ime;
		this.id = id;
	}
	public float getNapon()
    {
        return getVrijednost();
    }

	new public string PrikaziSignale()
	{
		StringBuilder sb = new StringBuilder();
		sb.AppendLine(ime + " Napon (kV) mjerena vel.");
		sb.AppendLine("");

		return sb.ToString();
	}

	new public string prikaziSignaleTrenutni()
	{
		StringBuilder sb = new StringBuilder();
		sb.AppendLine(ime + " Napon (kV) mjerena vel.");
		sb.AppendLine("");

		return sb.ToString();
	}
}

public class Ampermetar : Mjerenja {
	public Ampermetar(string ime, string id)
	{
		this.ime = ime;
		this.id = id;
	}
	public float getJakostStruje()
    {
        return getVrijednost();
    }

	new public string PrikaziSignale()
	{
		StringBuilder sb = new StringBuilder();
		sb.AppendLine(ime + " Struja (A) mjerena vel.");
		sb.AppendLine("");

		return sb.ToString();
	}

	new public string prikaziSignaleTrenutni()
	{
		StringBuilder sb = new StringBuilder();
		sb.AppendLine(ime + " Struja (A) mjerena vel.");
		sb.AppendLine("");

		return sb.ToString();
	}
}

public class Brojilo : Mjerenja {
	private bool alarm;
	private bool tip; //false radna, true jalova

	public Brojilo(string ime, string id, bool tip) {
		this.ime = ime;
		this.id = id;
		this.tip = tip;
    }

    public bool Alarm { get => alarm; set => alarm = value; }
    public bool Tip { get => tip; set => tip = value; }

	new public string PrikaziSignale()
	{
		StringBuilder sb = new StringBuilder();
		if (tip)
			sb.AppendLine(ime + " radna energija (kWh) ");
		else
			sb.AppendLine(ime + " jalova energija (kVArh) ");
		sb.AppendLine(ime + " alarm prorada");
		sb.AppendLine(ime + " alarm prestanak");
		sb.AppendLine("");

		return sb.ToString();
	}

	new public string prikaziSignaleTrenutni()
	{
		StringBuilder sb = new StringBuilder();
		if (tip)
			sb.AppendLine(ime + " radna energija (kWh) ");
		else
			sb.AppendLine(ime + " jalova energija (kVArh) ");
		sb.AppendLine(ime + " alarm " + ((alarm)?("prorada"):("prestanak")));
		sb.AppendLine("");

		return sb.ToString();
	}

	new public string prikaziSignaleGrupni()
	{
		StringBuilder sb = new StringBuilder();
		sb.AppendLine(ime + " alarm prorada");
		sb.AppendLine(ime + " alarm prestanak");
		sb.AppendLine("");

		return sb.ToString();
	}
}