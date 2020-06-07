using System;

public abstract class Mjerenja : IStanje
{
	private readonly string id;
	private float vrijednost;

	//potrebna implementacija
	public void osvjeziVrijednosti() { }
	public float getVrijednosti() { }

}

public class Watmetar : Mjerenja {
	private bool tip;
	
	public Watmetar(string id, bool tip) {
		this.id = id;
		this.tip = tip;
    }

	public float getSnaga() { }
}

public class Voltmetar : Mjerenja {
    public Voltmetar(string id) => this.id = id;
	public float getNapon() { }
}

public class Ampermetar : Mjerenja {
	public Ampermetar(string id) => this.id = id;
	public float getJakostStruje() { }
}

public class Brojilo : Mjerenja {
	private bool alarm;
	private bool tip;

	public Brojilo(string id, bool tip) {
		this.id = id;
		this.Tip = tip;
    }

    public bool Alarm { get => alarm; set => alarm = value; }
    public bool Tip { get => tip; set => tip = value; }
}