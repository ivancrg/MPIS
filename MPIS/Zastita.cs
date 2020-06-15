using System;
using System.Text;

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
		throw new NotImplementedException();
	}
}

public class ZastitaDistantna : Zastita {
	private bool iskljucenje = false;
	private bool fazaL1Poticaj = false;
	private bool fazaL2Poticaj = false;
	private bool fazaL3Poticaj = false;
	private bool zemljospojPoticaj = false;
	private bool stupanj2 = false;
	private bool stupanj3 = false;
	private bool stupanj4 = false;
	private bool suprotniSmjer = false;
	private bool njihanjeEnergije = false;
	private bool TKPrijem = false;
	private bool TKSlanje = false;
	private bool TKIskljucenje = false;
	private bool napajanjeNestanak = false;
	private bool uredajKvar = false;

	
	public bool Stupanj2 { get => stupanj2; set => stupanj2 = value; }
	public bool Stupanj3 { get => stupanj3; set => stupanj3 = value; }
	public bool Stupanj4 { get => stupanj4; set => stupanj4 = value; }
	public bool SuprotniSmjer { get => suprotniSmjer; set => suprotniSmjer = value; }
	public bool NjihanjeEnergije { get => njihanjeEnergije; set => njihanjeEnergije = value; }
	public bool TKPrijem1 { get => TKPrijem; set => TKPrijem = value; }
	public bool TKSlanje1 { get => TKSlanje; set => TKSlanje = value; }
	public bool TKIskljucenje1 { get => TKIskljucenje; set => TKIskljucenje = value; }
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
		if (Iskljucenje || FazaL1Poticaj || FazaL2Poticaj || FazaL3Poticaj || ZemljospojPoticaj || NapajanjeNestanak || UredajKvar
			|| Stupanj2 || Stupanj3 || Stupanj4 || SuprotniSmjer || NjihanjeEnergije || TKPrijem1 || TKSlanje1 || TKIskljucenje1)
			iskljuciPrekidac(prekidac, apu);
	}

	new public bool getProrada()
	{
		if (Iskljucenje || FazaL1Poticaj || FazaL2Poticaj || FazaL3Poticaj || ZemljospojPoticaj || NapajanjeNestanak || UredajKvar
			|| Stupanj2 || Stupanj3 || Stupanj4 || SuprotniSmjer || NjihanjeEnergije || TKPrijem1 || TKSlanje1 || TKIskljucenje1)
			return true;
		return false;
	}

	new public string PrikaziSignale()
	{
		StringBuilder sb = new StringBuilder();
		sb.AppendLine(ime + " isključenje prorada");
		sb.AppendLine(ime + " isključenje prestanak");
		sb.AppendLine(ime + " faza L1 poticaj prorada");
		sb.AppendLine(ime + " faza L1 poticaj prestanak");
		sb.AppendLine(ime + " faza L2 poticaj prorada");
		sb.AppendLine(ime + " faza L2 poticaj prestanak");
		sb.AppendLine(ime + " faza L3 poticaj prorada");
		sb.AppendLine(ime + " faza L3 poticaj prestanak");
		sb.AppendLine(ime + " zemljospoj poticaj prorada");
		sb.AppendLine(ime + " zemljospoj poticaj prestanak");
		sb.AppendLine(ime + " 2.stupanj - isključenje prorada");
		sb.AppendLine(ime + " 2.stupanj - isključenje prestanak");
		sb.AppendLine(ime + " 3.stupanj - isključenje prorada");
		sb.AppendLine(ime + " 3.stupanj - isključenje prestanak");
		sb.AppendLine(ime + " 4.stupanj - isključenje prorada");
		sb.AppendLine(ime + " 4.stupanj - isključenje prestanak");
		sb.AppendLine(ime + " suprotni smijer poticaj prorada");
		sb.AppendLine(ime + " suprotni smijer poticaj prestanak");
		sb.AppendLine(ime + " njihanje energije - blokada prorada");
		sb.AppendLine(ime + " njihanje energije - blokada prestanak");
		sb.AppendLine(ime + " TK signal - prijem prorada");
		sb.AppendLine(ime + " TK signal - prijem prestanak");
		sb.AppendLine(ime + " TK signal - slanje prorada");
		sb.AppendLine(ime + " TK signal - slanje prestanak");
		sb.AppendLine(ime + " TK signal - isključenje prorada");
		sb.AppendLine(ime + " TK signal - isključenje prestanak");
		sb.AppendLine(ime + " napajanje - nestanak prorada");
		sb.AppendLine(ime + " napajanje - nestanak prestanak");
		sb.AppendLine(ime + " uređaj - kvar prorada");
		sb.AppendLine(ime + " uređaj - kvar prestanak");
		sb.AppendLine("");

		return sb.ToString();
	}

	new public string prikaziSignaleTrenutni()
	{
		StringBuilder sb = new StringBuilder();
		sb.AppendLine(ime + " isključenje " + ((iskljucenje)?("prorada"):("prestanak")));
		sb.AppendLine(ime + " faza L1 poticaj " + ((fazaL1Poticaj) ? ("prorada") : ("prestanak")));
		sb.AppendLine(ime + " faza L2 poticaj " + ((fazaL2Poticaj) ? ("prorada") : ("prestanak")));
		sb.AppendLine(ime + " faza L3 poticaj " + ((fazaL3Poticaj) ? ("prorada") : ("prestanak")));
		sb.AppendLine(ime + " zemljospoj poticaj " + ((zemljospojPoticaj) ? ("prorada") : ("prestanak")));
		sb.AppendLine(ime + " 2.stupanj - isključenje " + ((stupanj2) ? ("prorada") : ("prestanak")));
		sb.AppendLine(ime + " 3.stupanj - isključenje " + ((stupanj3) ? ("prorada") : ("prestanak")));
		sb.AppendLine(ime + " 4.stupanj - isključenje " + ((stupanj4) ? ("prorada") : ("prestanak")));
		sb.AppendLine(ime + " suprotni smijer poticaj " + ((suprotniSmjer) ? ("prorada") : ("prestanak")));
		sb.AppendLine(ime + " njihanje energije - blokada " + ((njihanjeEnergije) ? ("prorada") : ("prestanak")));
		sb.AppendLine(ime + " TK signal - prijem " + ((TKPrijem) ? ("prorada") : ("prestanak")));
		sb.AppendLine(ime + " TK signal - slanje " + ((TKSlanje) ? ("prorada") : ("prestanak")));
		sb.AppendLine(ime + " TK signal - isključenje " + ((TKIskljucenje) ? ("prorada") : ("prestanak")));
		sb.AppendLine(ime + " napajanje - nestanak " + ((napajanjeNestanak) ? ("prorada") : ("prestanak")));
		sb.AppendLine(ime + " uređaj - kvar " + ((uredajKvar) ? ("prorada") : ("prestanak")));
		sb.AppendLine("");

		return sb.ToString();
	}

	new public string prikaziSignaleGrupni()
	{
		StringBuilder sb = new StringBuilder();
		sb.AppendLine(ime + " isključenje prorada");
		sb.AppendLine(ime + " isključenje prestanak");
		sb.AppendLine(ime + " 2.stupanj - isključenje prorada");
		sb.AppendLine(ime + " 2.stupanj - isključenje prestanak");
		sb.AppendLine(ime + " 3.stupanj - isključenje prorada");
		sb.AppendLine(ime + " 3.stupanj - isključenje prestanak");
		sb.AppendLine(ime + " 4.stupanj - isključenje prorada");
		sb.AppendLine(ime + " 4.stupanj - isključenje prestanak");
		sb.AppendLine(ime + " njihanje energije - blokada prorada");
		sb.AppendLine(ime + " njihanje energije - blokada prestanak");
		sb.AppendLine(ime + " TK signal - isključenje prorada");
		sb.AppendLine(ime + " TK signal - isključenje prestanak");
		sb.AppendLine(ime + " napajanje - nestanak prorada");
		sb.AppendLine(ime + " napajanje - nestanak prestanak");
		sb.AppendLine(ime + " uređaj - kvar prorada");
		sb.AppendLine(ime + " uređaj - kvar prestanak");
		sb.AppendLine("");

		return sb.ToString();
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
	new public string PrikaziSignale()
	{
		StringBuilder sb = new StringBuilder();
		sb.AppendLine(ime + " NPČ - isključenje prorada");
		sb.AppendLine(ime + " NPČ - isključenje prestanak");
		sb.AppendLine(ime + " VPČ isključenje prorada");
		sb.AppendLine(ime + " VPČ isključenje prestanak");
		sb.AppendLine(ime + " zemljospojna isključenje prorada");
		sb.AppendLine(ime + " zemljospojna isključenje prestanak");
		sb.AppendLine(ime + " od preopterećenja upozorenje prorada");
		sb.AppendLine(ime + " od preopterećenja upozorenje prestanak");
		sb.AppendLine(ime + " od preopterećenja isključenje prorada");
		sb.AppendLine(ime + " od preopterećenja isključenje prestanak");
		sb.AppendLine(ime + " relej - kvar prorada");
		sb.AppendLine(ime + " relej - kvar prestanak");
		sb.AppendLine("");

		return sb.ToString();
	}

	new public string prikaziSignaleTrenutni()
	{
		StringBuilder sb = new StringBuilder();
		sb.AppendLine(ime + " NPČ - isključenje " + ((npcIskljucenje) ? ("prorada") : ("prestanak")));
		sb.AppendLine(ime + " VPČ isključenje " + ((vpcIskljucenje) ? ("prorada") : ("prestanak")));
		sb.AppendLine(ime + " zemljospojna isključenje " + ((zsIskljucenje) ? ("prorada") : ("prestanak")));
		sb.AppendLine(ime + " od preopterećenja upozorenje " + ((preopterecenjeIskljucenje) ? ("prorada") : ("prestanak")));
		sb.AppendLine(ime + " od preopterećenja isključenje " + ((preopterecenjeUpozorenje) ? ("prorada") : ("prestanak")));
		sb.AppendLine(ime + " relej - kvar " + ((relejKvar) ? ("prorada") : ("prestanak")));
		sb.AppendLine("");

		return sb.ToString();
	}

	new public string prikaziSignaleGrupni()
	{
		StringBuilder sb = new StringBuilder();
		sb.AppendLine(ime + " NPČ - isključenje prorada");
		sb.AppendLine(ime + " NPČ - isključenje prestanak");
		sb.AppendLine(ime + " VPČ isključenje prorada");
		sb.AppendLine(ime + " VPČ isključenje prestanak");
		sb.AppendLine(ime + " zemljospojna isključenje prorada");
		sb.AppendLine(ime + " zemljospojna isključenje prestanak");
		sb.AppendLine(ime + " od preopterećenja upozorenje prorada");
		sb.AppendLine(ime + " od preopterećenja upozorenje prestanak");
		sb.AppendLine(ime + " od preopterećenja isključenje prorada");
		sb.AppendLine(ime + " od preopterećenja isključenje prestanak");
		sb.AppendLine(ime + " relej - kvar prorada");
		sb.AppendLine(ime + " relej - kvar prestanak");
		sb.AppendLine("");

		return sb.ToString();
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
	new public string PrikaziSignale()
	{
		StringBuilder sb = new StringBuilder();
		sb.AppendLine(ime + " 1.stupanj - isključenje prorada");
		sb.AppendLine(ime + " 1.stupanj - isključenje prestanak");
		sb.AppendLine(ime + " 2.stupanj - isključenje prorada");
		sb.AppendLine(ime + " 2.stupanj - isključenje prestanak");
		sb.AppendLine(ime + " rastavljač - kvar prorada");
		sb.AppendLine(ime + " rastavljač - kvar prestanak");
		sb.AppendLine(ime + " pomoćno napajanje - nestanak prorada");
		sb.AppendLine(ime + " pomoćno napajanje - nestanak prestanak");
		sb.AppendLine(ime + " u testu prorada");
		sb.AppendLine(ime + " u testu prestanak");
		sb.AppendLine("");

		return sb.ToString();
	}

	new public string prikaziSignaleTrenutni()
	{
		StringBuilder sb = new StringBuilder();
		sb.AppendLine(ime + " 1.stupanj - isključenje " + ((s1Iskljucenje) ? ("prorada") : ("prestanak")));
		sb.AppendLine(ime + " 2.stupanj - isključenje " + ((s2Iskljucenje) ? ("prorada") : ("prestanak")));
		sb.AppendLine(ime + " rastavljač - kvar " + ((rastavljacKvar) ? ("prorada") : ("prestanak")));
		sb.AppendLine(ime + " pomoćno napajanje - nestanak " + ((pomocnoNapajanjeNestanak) ? ("prorada") : ("prestanak")));
		sb.AppendLine(ime + " u testu " + ((uTestu) ? ("prorada") : ("prestanak")));
		sb.AppendLine("");

		return sb.ToString();
	}

	new public string prikaziSignaleGrupni()
	{
		StringBuilder sb = new StringBuilder();
		sb.AppendLine(ime + " 1.stupanj - isključenje prorada");
		sb.AppendLine(ime + " 1.stupanj - isključenje prestanak");
		sb.AppendLine(ime + " 2.stupanj - isključenje prorada");
		sb.AppendLine(ime + " 2.stupanj - isključenje prestanak");
		sb.AppendLine(ime + " rastavljač - kvar prorada");
		sb.AppendLine(ime + " rastavljač - kvar prestanak");
		sb.AppendLine(ime + " pomoćno napajanje - nestanak prorada");
		sb.AppendLine(ime + " pomoćno napajanje - nestanak prestanak");
		sb.AppendLine("");

		return sb.ToString();
	}
}
