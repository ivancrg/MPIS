using System;

public abstract class Zastita : IStanje
{
	protected string ime;
	protected string id;

	public void osvjeziVrijednosti(Prekidac prekidac, APU apu) {
		//potrebna implementacija
    }

	public bool iskljuciPrekidac(Prekidac prekidac, APU apu) {
		apu.iskljuci();
		return prekidac.iskljuci(apu);
    }

	public bool getProrada()
	{
		throw new NotImplementedException();
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

public class ZastitaDistantna : Zastita {
	private bool iskljucenje = false;
	private bool fazaL1Poticaj = false;
	private bool fazaL2Poticaj = false;
	private bool fazaL3Poticaj = false;
	private bool zemljospojPoticaj = false;
	private bool napajanjeNestanak = false;
	private bool uredajKvar = false;

	public bool Iskljucenje { get => iskljucenje; set => iskljucenje = value; }
	public bool FazaL1Poticaj { get => fazaL1Poticaj; set => fazaL1Poticaj = value; }
	public bool FazaL2Poticaj { get => fazaL2Poticaj; set => fazaL2Poticaj = value; }
	public bool FazaL3Poticaj { get => fazaL3Poticaj; set => fazaL3Poticaj = value; }
	public bool ZemljospojPoticaj { get => zemljospojPoticaj; set => zemljospojPoticaj = value; }
	public bool NapajanjeNestanak { get => napajanjeNestanak; set => napajanjeNestanak = value; }
	public bool UredajKvar { get => uredajKvar; set => uredajKvar = value; }

	public ZastitaDistantna(string ime, string id) {
		this.ime = ime;
		this.id = id;
    }

	new public void osvjeziVrijednosti(Prekidac prekidac, APU apu)
	{
		if (Iskljucenje || FazaL1Poticaj || FazaL2Poticaj || FazaL3Poticaj || ZemljospojPoticaj || NapajanjeNestanak || UredajKvar)
			iskljuciPrekidac(prekidac, apu);
	}

	new public bool getProrada()
	{
		if (Iskljucenje || FazaL1Poticaj || FazaL2Poticaj || FazaL3Poticaj || ZemljospojPoticaj || NapajanjeNestanak || UredajKvar)
			return true;
		return false;
	}

}

public class ZastitaNadstrujna : Zastita {
	private bool npcIskljucenje = false;
	private bool vpcIskljucenje = false;
	private bool zsIskljucenje = false;
	private bool preopterecenjeUpozorenje = false;
	private bool preopterecenjeIskljucenje = false;
	private bool relejKvar = false;

	public bool NpcIskljucenje { get => npcIskljucenje; set => npcIskljucenje = value; }
	public bool VpcIskljucenje { get => vpcIskljucenje; set => vpcIskljucenje = value; }
	public bool ZsIskljucenje { get => zsIskljucenje; set => zsIskljucenje = value; }
	public bool PreopterecenjeUpozorenje { get => preopterecenjeUpozorenje; set => preopterecenjeUpozorenje = value; }
	public bool PreopterecenjeIskljucenje { get => preopterecenjeIskljucenje; set => preopterecenjeIskljucenje = value; }
	public bool RelejKvar { get => relejKvar; set => relejKvar = value; }

	public ZastitaNadstrujna(string ime, string id)
	{
		this.ime = ime;
		this.id = id;
	}

	new public void osvjeziVrijednosti(Prekidac prekidac, APU apu)
	{
		if (NpcIskljucenje || VpcIskljucenje || ZsIskljucenje || PreopterecenjeUpozorenje || PreopterecenjeIskljucenje || RelejKvar)
			iskljuciPrekidac(prekidac, apu);
	}

	new public bool getProrada()
	{
		if (NpcIskljucenje || VpcIskljucenje || ZsIskljucenje || PreopterecenjeUpozorenje || PreopterecenjeIskljucenje || RelejKvar)
			return true;
		return false;
	}

}

public class ZastitaZemljospojna : Zastita {
	private bool s1Iskljucenje = false;
	private bool s2Iskljucenje = false;
	private bool rastavljacKvar = false;
	private bool pomocnoNapajanjeNestanak = false;
	private bool uTestu = false;

	public bool S1Iskljucenje { get => s1Iskljucenje; set => s1Iskljucenje = value; }
	public bool S2Iskljucenje { get => s2Iskljucenje; set => s2Iskljucenje = value; }
	public bool RastavljacKvar { get => rastavljacKvar; set => rastavljacKvar = value; }
	public bool PomocnoNapajanjeNestanak { get => pomocnoNapajanjeNestanak; set => pomocnoNapajanjeNestanak = value; }
	public bool UTestu { get => uTestu; set => uTestu = value; }

	public ZastitaZemljospojna(string ime, string id)
	{
		this.ime = ime;
		this.id = id;
    }

	new public void osvjeziVrijednosti(Prekidac prekidac, APU apu)
	{
		if (S1Iskljucenje || S2Iskljucenje || RastavljacKvar || PomocnoNapajanjeNestanak || UTestu)
			iskljuciPrekidac(prekidac, apu);
	}

	new public bool getProrada()
	{
		if (S1Iskljucenje || S2Iskljucenje || RastavljacKvar || PomocnoNapajanjeNestanak || UTestu)
			return true;
		return false;
	}

}
