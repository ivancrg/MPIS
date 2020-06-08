using System;

public abstract class Zastita : IStanje
{
	private readonly string id;

	public void osvjeziVrijednosti() {
		//potrebna implementacija
    }

	public bool iskljuciPrekidac(Prekidac prekidac) {
		return prekidac.iskljuci();
    }
}

public class ZastitaDistantna : Zastita {
	private bool iskljucenje;
	private bool fazaL1Poticaj;
	private bool fazaL2Poticaj;
	private bool fazaL3Poticaj;
	private bool zemljospojPoticaj;
	private bool napajanjeNestanak;
	private bool uredajKvar;

	public ZastitaDistantna(string id) {
		this.id = id;
    }

    public bool Iskljucenje { get => iskljucenje; set => iskljucenje = value; }
    public bool FazaL1Poticaj { get => fazaL1Poticaj; set => fazaL1Poticaj = value; }
    public bool FazaL2Poticaj { get => fazaL2Poticaj; set => fazaL2Poticaj = value; }
    public bool FazaL3Poticaj { get => fazaL3Poticaj; set => fazaL3Poticaj = value; }
    public bool ZemljospojPoticaj { get => zemljospojPoticaj; set => zemljospojPoticaj = value; }
    public bool NapajanjeNestanak { get => napajanjeNestanak; set => napajanjeNestanak = value; }
    public bool UredajKvar { get => uredajKvar; set => uredajKvar = value; }
}

public class ZastitaNadstrujna : Zastita {
	private bool NPCIskljucenje;
	private bool VPCIskljucenje;
	private bool ZSIkljucenje;
	private bool preopterecenjeUpozorenje;
	private bool preopterecenjeIskljucenje;
	private bool relejKvar;

	public ZastitaNadstrujna(string id) {
		this.id = id;
    }

    public bool NPCIskljucenje1 { get => NPCIskljucenje; set => NPCIskljucenje = value; }
    public bool VPCIskljucenje1 { get => VPCIskljucenje; set => VPCIskljucenje = value; }
    public bool ZSIkljucenje1 { get => ZSIkljucenje; set => ZSIkljucenje = value; }
    public bool PreopterecenjeUpozorenje { get => preopterecenjeUpozorenje; set => preopterecenjeUpozorenje = value; }
    public bool PreopterecenjeIskljucenje { get => preopterecenjeIskljucenje; set => preopterecenjeIskljucenje = value; }
    public bool RelejKvar { get => relejKvar; set => relejKvar = value; }
}

public class ZastitaZemljopisna : Zastita {
	private bool s1Iskljucenje;
	private bool s2Iskljucenje;
	private bool rastavljacKvar;
	private bool pomocnoNapajanjeNestanak;
	private bool uTestu;

	public ZastitaZemljopisna(string id) {
		this.id = id;
    }

    public bool S1Iskljucenje { get => s1Iskljucenje; set => s1Iskljucenje = value; }
    public bool S2Iskljucenje { get => s2Iskljucenje; set => s2Iskljucenje = value; }
    public bool RastavljacKvar { get => rastavljacKvar; set => rastavljacKvar = value; }
    public bool PomocnoNapajanjeNestanak { get => pomocnoNapajanjeNestanak; set => pomocnoNapajanjeNestanak = value; }
    public bool UTestu { get => uTestu; set => uTestu = value; }
}
