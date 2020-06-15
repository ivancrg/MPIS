using System;

public abstract class Mjerenja : IStanje
{
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

	public void PrikaziSignale()
	{
		throw new NotImplementedException();
	}

	public void prikaziSignaleTrenutni()
	{
		throw new NotImplementedException();
	}
}

public class Watmetar : Mjerenja {
	private bool tip;
	
	public Watmetar(string id, bool tip) {
		this.id = id;
		this.tip = tip;
    }

	public float getSnaga()
	{
		return getVrijednost();
	}
}

public class Voltmetar : Mjerenja {
    public Voltmetar(string id) => this.id = id;
	public float getNapon()
    {
        return getVrijednost();
    }
}

public class Ampermetar : Mjerenja {
	public Ampermetar(string id) => this.id = id;
	public float getJakostStruje()
    {
        return getVrijednost();
    }
}

public class Brojilo : Mjerenja {
	private bool alarm;
	private bool tip;

	public Brojilo(string id, bool tip) {
		this.id = id;
		this.tip = tip;
    }

    public bool Alarm { get => alarm; set => alarm = value; }
    public bool Tip { get => tip; set => tip = value; }
}