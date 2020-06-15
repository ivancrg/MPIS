using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MPIS
{
    public partial class Form1 : Form
    {
        //ova klasa predstavlja dalekovodno polje
        //u njoj se trebaju deklarirati dva objekta klasa koji ce predstavljati TS-D i TS-E
        //u Form1_Load ce se inicijalizirati svi objekti i koristiti u eventima buttona, comboboxova itd.
        RastavljacSabirnicki srTSD = new RastavljacSabirnicki("TS-D 110 DV rastavljač S1", "1_1", 1);
        PrekidacSF6ABB prTSD = new PrekidacSF6ABB("TS-D 110 DV prekidač", "1");
        RastavljacIzlazni irTSD = new RastavljacIzlazni("TS-D 110 DV rastavljač izlazni", "1");
        RastavljacUzemljenja ruTSD = new RastavljacUzemljenja("TS-D 110 DV rastavljač uzemljenja", "1");
        ZastitaDistantna zdTSD = new ZastitaDistantna("TS-D 110 DV zaštita distantna", "1");
        ZastitaNadstrujna znTSD = new ZastitaNadstrujna("TS-D 110 DV zaštita nadstrujna", "1");
        ZastitaZemljospojna zzTSD = new ZastitaZemljospojna("TS-D 110 DV zaštita zemljospojna", "1");
        APU apuTSD = new APU("TS-D 110 DV zaštita distantna APU", "1");
        Napajanje napTSD = new Napajanje("1");
        Watmetar wattTSD = new Watmetar("TS-D 110 DV mjerni pretvornik", "1", true);
        Voltmetar voltTSD = new Voltmetar("TS-D 110 DV mjerni pretvornik", "1");
        Ampermetar ampTSD = new Ampermetar("TS-D 110 DV mjerni pretvornik", "1");
        Brojilo brTSD = new Brojilo("TS-D 110 DV brojilo", "1", false);

        RastavljacSabirnicki sr1TSE = new RastavljacSabirnicki("TS-E 110 DV rastavljač S1", "2_1", 1);
        RastavljacSabirnicki sr2TSE = new RastavljacSabirnicki("TS-E 110 DV rastavljač S2", "2_1", 2);
        PrekidacSF6ABB prTSE = new PrekidacSF6ABB("TS-E 110 DV prekidač", "2");
        RastavljacIzlazni irTSE = new RastavljacIzlazni("TS-E 110 DV rastavljač izlazni", "2");
        RastavljacUzemljenja ruTSE = new RastavljacUzemljenja("TS-E 110 DV rastavljač uzemljenja", "2");
        ZastitaDistantna zdTSE = new ZastitaDistantna("TS-E 110 DV zaštita distantna", "2");
        ZastitaNadstrujna znTSE = new ZastitaNadstrujna("TS-E 110 DV zaštita nadstrujna", "2");
        ZastitaZemljospojna zzTSE = new ZastitaZemljospojna("TS-E 110 DV zaštita zemljospojna", "2");
        APU apuTSE = new APU("TS-E 110 DV zaštita distantna APU", "2");
        Napajanje napTSE = new Napajanje("2");
        Watmetar wattTSE = new Watmetar("TS-E 110 DV mjerni pretvornik", "2", false);
        Voltmetar voltTSE = new Voltmetar("TS-E 110 DV mjerni pretvornik", "2");
        Ampermetar ampTSE = new Ampermetar("TS-E 110 DV mjerni pretvornik", "2");
        Brojilo brTSE = new Brojilo("TS-E 110 DV brojilo", "2", true);

        private bool stanjeDaljinskoUpravljanje = true;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            srprTSD.BackColor = Color.Red;
            prirTSD.BackColor = Color.Red;
            irruTSD.BackColor = Color.Red;
            dvRuTSD.BackColor = Color.Red;
            dvTsTSD.BackColor = Color.Red;

            dv.BackColor = Color.Red;

            sr1srTSE.BackColor = Color.Red;
            sr2srTSE.BackColor = Color.Red;
            srprTSE.BackColor = Color.Red;
            prirTSE.BackColor = Color.Red;
            irruTSE.BackColor = Color.Red;
            dvRuTSE.BackColor = Color.Red;
            dvTsTSE.BackColor = Color.Red;

            dvButton_Click(sender, e);
        }

        private void srTSDButton_Click(object sender, EventArgs e)
        {
            if(srTSDButton.Text == "Uključi SR")
            {
                if (srTSD.ukljuci(prTSD))
                {
                    srprTSD.BackColor = Color.Green;
                    srTSDButton.Text = "Isključi SR";
                }
            }
            else
            {
                if (srTSD.iskljuci(prTSD))
                {
                    srprTSD.BackColor = Color.Red;
                    srTSDButton.Text = "Uključi SR";
                }
            }

            osvjeziStanjeIspravnost();
        }

        private void prTSDButton_Click(object sender, EventArgs e)
        {
            if(prTSDButton.Text == "Uključi PR")
            {
                if(prTSD.ukljuci(srTSD, irTSD, ruTSD))
                {
                    prirTSD.BackColor = Color.Green;
                    prTSDButton.Text = "Isključi PR";
                }
            }
            else
            {
                if (prTSD.iskljuci(apuTSD))
                {
                    prirTSD.BackColor = Color.Red;
                    prTSDButton.Text = "Uključi PR";
                }
            }

            osvjeziStanjeIspravnost();
        }

        private void irTSDButton_Click(object sender, EventArgs e)
        {
            if (irTSDButton.Text == "Uključi IR")
            {
                if (irTSD.ukljuci(prTSD, ruTSD))
                {
                    irruTSD.BackColor = Color.Green;
                    irTSDButton.Text = "Isključi IR";
                }
            }
            else
            {
                if (irTSD.iskljuci(prTSD))
                {
                    irruTSD.BackColor = Color.Red;
                    irTSDButton.Text = "Uključi IR";
                }
            }

            osvjeziStanjeIspravnost();
        }

        private void ruTSDButton_Click(object sender, EventArgs e)
        {
            if(ruTSDButton.Text == "Uključi RU")
            {
                if (ruTSD.ukljuci(prTSD))
                {
                    dvRuTSD.BackColor = Color.Green;
                    ruTSDButton.Text = "Isključi RU";
                }
            }
            else
            {
                if (ruTSD.iskljuci())
                {
                    dvRuTSD.BackColor = Color.Red;
                    ruTSDButton.Text = "Uključi RU";
                }
            }

            osvjeziStanjeIspravnost();
        }

        private void sr1TSEButton_Click(object sender, EventArgs e)
        {
            if (sr1TSEButton.Text == "Uključi SR1")
            {
                if (sr1TSE.ukljuci(prTSE, sr2TSE))
                {
                    sr1srTSE.BackColor = Color.Green;
                    srprTSE.BackColor = Color.Green;
                    sr1TSEButton.Text = "Isključi SR1";
                }
            }
            else
            {
                if (sr1TSE.iskljuci(prTSE))
                {
                    sr1srTSE.BackColor = Color.Red;
                    srprTSE.BackColor = Color.Red;
                    sr1TSEButton.Text = "Uključi SR1";
                }
            }

            osvjeziStanjeIspravnost();
        }

        private void sr2TSEButton_Click(object sender, EventArgs e)
        {
            if (sr2TSEButton.Text == "Uključi SR2")
            {
                if (sr2TSE.ukljuci(prTSE, sr1TSE))
                {
                    sr2srTSE.BackColor = Color.Green;
                    srprTSE.BackColor = Color.Green;
                    sr2TSEButton.Text = "Isključi SR2";
                }
            }
            else
            {
                if (sr2TSE.iskljuci(prTSE))
                {
                    sr2srTSE.BackColor = Color.Red;
                    srprTSE.BackColor = Color.Red;
                    sr2TSEButton.Text = "Uključi SR2";
                }
            }

            osvjeziStanjeIspravnost();
        }

        private void prTSEButton_Click(object sender, EventArgs e)
        {
            if (prTSEButton.Text == "Uključi PR")
            {
                if (prTSE.ukljuci(sr1TSE, sr2TSE, irTSE, ruTSE))
                {
                    prirTSE.BackColor = Color.Green;
                    prTSEButton.Text = "Isključi PR";
                }
            }
            else
            {
                if (prTSE.iskljuci(apuTSE))
                {
                    prirTSE.BackColor = Color.Red;
                    prTSEButton.Text = "Uključi PR";
                }
            }

            osvjeziStanjeIspravnost();
        }

        private void irTSEButton_Click(object sender, EventArgs e)
        {
            if (irTSEButton.Text == "Uključi IR")
            {
                if (irTSE.ukljuci(prTSE, ruTSE))
                {
                    irruTSE.BackColor = Color.Green;
                    irTSEButton.Text = "Isključi IR";
                }
            }
            else
            {
                if (irTSE.iskljuci(prTSE))
                {
                    irruTSE.BackColor = Color.Red;
                    irTSEButton.Text = "Uključi IR";
                }
            }

            osvjeziStanjeIspravnost();
        }

        private void ruTSEButton_Click(object sender, EventArgs e)
        {
            if (ruTSEButton.Text == "Uključi RU")
            {
                if (ruTSE.ukljuci(prTSE))
                {
                    dvRuTSE.BackColor = Color.Green;
                    ruTSEButton.Text = "Isključi RU";
                }
            }
            else
            {
                if (ruTSE.iskljuci())
                {
                    dvRuTSE.BackColor = Color.Red;
                    ruTSEButton.Text = "Uključi RU";
                }
            }

            osvjeziStanjeIspravnost();
        }

        private void dvButton_Click(object sender, EventArgs e)
        {
            if(dvButton.Text == "Uključi DV")
            {
                if (dvUkljuci(sender, e))
                {
                    dvTsTSD.BackColor = Color.Green;
                    dv.BackColor = Color.Green;
                    dvTsTSE.BackColor = Color.Green;

                    MessageBox.Show("Dalekovodno polje uključeno.");

                    dvButton.Text = "Isključi DV";
                }
                else
                {
                    MessageBox.Show("Došlo je do greške");
                }
            }
            else
            {
                if (dvIskljuci(sender, e))
                {
                    dvTsTSD.BackColor = Color.Red;
                    dv.BackColor = Color.Red;
                    dvTsTSE.BackColor = Color.Red;

                    MessageBox.Show("Dalekovodno polje isključeno.");

                    dvButton.Text = "Uključi DV";
                }
                else
                {
                    MessageBox.Show("Došlo je do greške");
                }
            }
        }

        private bool dvUkljuci(object sender, EventArgs e)
        {
            if (zdTSD.getProrada()) return false;
            if (zdTSE.getProrada()) return false;

            if (znTSD.getProrada()) return false;
            if (znTSE.getProrada()) return false;

            if (zzTSD.getProrada()) return false;
            if (zzTSE.getProrada()) return false;

            if (napTSD.uredajiBezNapajanja() != null) return false;
            if (napTSE.uredajiBezNapajanja() != null) return false;

            if (prTSD.GubitakSF6) return false;
            if (prTSE.GubitakSF6) return false;

            if (!stanjeDaljinskoUpravljanje) return false;

            //nepoznat polozaj
            if ((int)prTSD.getStanje() == 2 || (int)prTSE.getStanje() == 2) return false;
            if ((int)srTSD.getStanje() == 2 || (int)sr1TSE.getStanje() == 2 || (int)sr2TSE.getStanje() == 2) return false;
            if ((int)irTSD.getStanje() == 2 || (int)irTSE.getStanje() == 2) return false;
            if ((int)ruTSD.getStanje() == 2 || (int)ruTSE.getStanje() == 2) return false;

            //kvar
            if ((int)prTSD.getStanje() == 3 || (int)prTSE.getStanje() == 3) return false;
            if ((int)srTSD.getStanje() == 3 || (int)sr1TSE.getStanje() == 3 || (int)sr2TSE.getStanje() == 3) return false;
            if ((int)irTSD.getStanje() == 3 || (int)irTSE.getStanje() == 3) return false;
            if ((int)ruTSD.getStanje() == 3 || (int)ruTSE.getStanje() == 3) return false;

            if (ruTSDButton.Text == "Isključi RU") ruTSDButton_Click(sender, e);
            if (ruTSDButton.Text == "Isključi RU") return false;
            if (ruTSEButton.Text == "Isključi RU") ruTSEButton_Click(sender, e);
            if (ruTSEButton.Text == "Isključi RU") return false;

            if (irTSDButton.Text == "Uključi IR") irTSDButton_Click(sender, e);
            if (irTSDButton.Text == "Uključi IR") return false;
            if (irTSEButton.Text == "Uključi IR") irTSEButton_Click(sender, e);
            if (irTSEButton.Text == "Uključi IR") return false;

            if (srTSDButton.Text == "Uključi SR") srTSDButton_Click(sender, e);
            if (srTSDButton.Text == "Uključi SR") return false;
            if (sr1TSEButton.Text == "Uključi SR1") sr1TSEButton_Click(sender, e);
            if (sr1TSEButton.Text == "Uključi SR1") return false;
            if (sr2TSEButton.Text == "Isključi SR2") sr2TSEButton_Click(sender, e);
            if (sr2TSEButton.Text == "Isključi SR2") return false;

            if (prTSDButton.Text == "Uključi PR") prTSDButton_Click(sender, e);
            if (prTSDButton.Text == "Uključi PR") return false;
            if (prTSEButton.Text == "Uključi PR") prTSEButton_Click(sender, e);
            if (prTSEButton.Text == "Uključi PR") return false;

            return true;
        }

        private bool dvIskljuci(object sender, EventArgs e)
        {
            if (zdTSD.getProrada()) return false;
            if (zdTSE.getProrada()) return false;

            if (znTSD.getProrada()) return false;
            if (znTSE.getProrada()) return false;

            if (zzTSD.getProrada()) return false;
            if (zzTSE.getProrada()) return false;

            if (napTSD.uredajiBezNapajanja() != null) return false;
            if (napTSE.uredajiBezNapajanja() != null) return false;

            if (prTSD.GubitakSF6) return false;
            if (prTSE.GubitakSF6) return false;

            if (!stanjeDaljinskoUpravljanje) return false;
            
            //nepoznat polozaj
            if ((int)prTSD.getStanje() == 2 || (int)prTSE.getStanje() == 2) return false;
            if ((int)srTSD.getStanje() == 2 || (int)sr1TSE.getStanje() == 2 || (int)sr2TSE.getStanje() == 2) return false;
            if ((int)irTSD.getStanje() == 2 || (int)irTSE.getStanje() == 2) return false;
            if ((int)ruTSD.getStanje() == 2 || (int)ruTSE.getStanje() == 2) return false;

            //kvar
            if ((int)prTSD.getStanje() == 3 || (int)prTSE.getStanje() == 3) return false;
            if ((int)srTSD.getStanje() == 3 || (int)sr1TSE.getStanje() == 3 || (int)sr2TSE.getStanje() == 3) return false;
            if ((int)irTSD.getStanje() == 3 || (int)irTSE.getStanje() == 3) return false;
            if ((int)ruTSD.getStanje() == 3 || (int)ruTSE.getStanje() == 3) return false;

            if (prTSDButton.Text == "Isključi PR") prTSDButton_Click(sender, e);
            if (prTSDButton.Text == "Isključi PR") return false;
            if (prTSEButton.Text == "Isključi PR") prTSEButton_Click(sender, e);
            if (prTSEButton.Text == "Isključi PR") return false;

            if (srTSDButton.Text == "Isključi SR") srTSDButton_Click(sender, e);
            if (srTSDButton.Text == "Isključi SR") return false;
            if (sr1TSEButton.Text == "Isključi SR1") sr1TSEButton_Click(sender, e);
            if (sr1TSEButton.Text == "Isključi SR1") return false;
            if (sr2TSEButton.Text == "Isključi SR2") sr2TSEButton_Click(sender, e);
            if (sr2TSEButton.Text == "Isključi SR2") return false;

            if (irTSDButton.Text == "Isključi IR") irTSDButton_Click(sender, e);
            if (irTSDButton.Text == "Isključi IR") return false;
            if (irTSEButton.Text == "Isključi IR") irTSEButton_Click(sender, e);
            if (irTSEButton.Text == "Isključi IR") return false;

            if (ruTSDButton.Text == "Uključi RU") ruTSDButton_Click(sender, e);
            if (ruTSDButton.Text == "Uključi RU") return false;
            if (ruTSEButton.Text == "Uključi RU") ruTSEButton_Click(sender, e);
            if (ruTSEButton.Text == "Uključi RU") return false;

            return true;
        }

        private void osvjeziStanjeIspravnost()
        {
            Rastavljac.stanje ra;
            Prekidac.stanje pr;

            ra = srTSD.getStanje();
            stanjeSrTSD.Text = "Stanje: " + ra.ToString();
            if((int) ra == 3)
            {
                stanjeSrTSD.ForeColor = Color.Red;
                ispravnostSrTSD.ForeColor = Color.Red;
                ispravnostSrTSD.Text = "Ispravno: NE";
            }
            else
            {
                stanjeSrTSD.ForeColor = Color.Green;
                ispravnostSrTSD.ForeColor = Color.Green;
                ispravnostSrTSD.Text = "Ispravno: DA";
            }

            pr = prTSD.getStanje();
            stanjePrTSD.Text = "Stanje: " + pr.ToString();
            if ((int)pr == 3)
            {
                stanjePrTSD.ForeColor = Color.Red;
                ispravnostPrTSD.ForeColor = Color.Red;
                ispravnostPrTSD.Text = "Ispravno: NE";
            }
            else
            {
                stanjePrTSD.ForeColor = Color.Green;
                ispravnostPrTSD.ForeColor = Color.Green;
                ispravnostPrTSD.Text = "Ispravno: DA";
            }


            ra = irTSD.getStanje();
            stanjeIrTSD.Text = "Stanje: " + ra.ToString();
            if ((int)ra == 3)
            {
                stanjeIrTSD.ForeColor = Color.Red;
                ispravnostIrTSD.ForeColor = Color.Red;
                ispravnostIrTSD.Text = "Ispravno: NE";
            }
            else
            {
                stanjeIrTSD.ForeColor = Color.Green;
                ispravnostIrTSD.ForeColor = Color.Green;
                ispravnostIrTSD.Text = "Ispravno: DA";
            }

            ra = ruTSD.getStanje();
            stanjeRuTSD.Text = "Stanje: " + ra.ToString();
            if ((int)ra == 3)
            {
                stanjeRuTSD.ForeColor = Color.Red;
                ispravnostRuTSD.ForeColor = Color.Red;
                ispravnostRuTSD.Text = "Ispravno: NE";
            }
            else
            {
                stanjeRuTSD.ForeColor = Color.Green;
                ispravnostRuTSD.ForeColor = Color.Green;
                ispravnostRuTSD.Text = "Ispravno: DA";
            }



            ra = sr1TSE.getStanje();
            stanjeSr1TSE.Text = "Stanje: " + ra.ToString();
            if ((int)ra == 3)
            {
                stanjeSr1TSE.ForeColor = Color.Red;
                ispravnostSr1TSE.ForeColor = Color.Red;
                ispravnostSr1TSE.Text = "Ispravno: NE";
            }
            else
            {
                stanjeSr1TSE.ForeColor = Color.Green;
                ispravnostSr1TSE.ForeColor = Color.Green;
                ispravnostSr1TSE.Text = "Ispravno: DA";
            }

            ra = sr2TSE.getStanje();
            stanjeSr2TSE.Text = "Stanje: " + ra.ToString();
            if ((int)ra == 3)
            {
                stanjeSr2TSE.ForeColor = Color.Red;
                ispravnostSr2TSE.ForeColor = Color.Red;
                ispravnostSr2TSE.Text = "Ispravno: NE";
            }
            else
            {
                stanjeSr2TSE.ForeColor = Color.Green;
                ispravnostSr2TSE.ForeColor = Color.Green;
                ispravnostSr2TSE.Text = "Ispravno: DA";
            }

            pr = prTSE.getStanje();
            stanjePrTSE.Text = "Stanje: " + pr.ToString();
            if ((int)pr == 3)
            {
                stanjePrTSE.ForeColor = Color.Red;
                ispravnostPrTSE.ForeColor = Color.Red;
                ispravnostPrTSE.Text = "Ispravno: NE";
            }
            else
            {
                stanjePrTSE.ForeColor = Color.Green;
                ispravnostPrTSE.ForeColor = Color.Green;
                ispravnostPrTSE.Text = "Ispravno: DA";
            }


            ra = irTSE.getStanje();
            stanjeIrTSE.Text = "Stanje: " + ra.ToString();
            if ((int)ra == 3)
            {
                stanjeIrTSE.ForeColor = Color.Red;
                ispravnostIrTSE.ForeColor = Color.Red;
                ispravnostIrTSE.Text = "Ispravno: NE";
            }
            else
            {
                stanjeIrTSE.ForeColor = Color.Green;
                ispravnostIrTSE.ForeColor = Color.Green;
                ispravnostIrTSE.Text = "Ispravno: DA";
            }

            ra = ruTSE.getStanje();
            stanjeRuTSE.Text = "Stanje: " + ra.ToString();
            if ((int)ra == 3)
            {
                stanjeRuTSE.ForeColor = Color.Red;
                ispravnostRuTSE.ForeColor = Color.Red;
                ispravnostRuTSE.Text = "Ispravno: NE";
            }
            else
            {
                stanjeRuTSE.ForeColor = Color.Green;
                ispravnostRuTSE.ForeColor = Color.Green;
                ispravnostRuTSE.Text = "Ispravno: DA";
            }
        }

        private void prikazSvihSignalaButton_Click(object sender, EventArgs e)
        {
            izbornik.Show(prikazSvihSignalaButton, 0, prikazSvihSignalaButton.Height);
        }

        private void prikazTrenutnihSignalaButton_Click(object sender, EventArgs e)
        {
            izbornik.Show(prikazTrenutnihSignalaButton, 0, prikazTrenutnihSignalaButton.Height);
        }

        private void prikazGrupnihSignalaButton_Click(object sender, EventArgs e)
        {
            izbornik.Show(prikazGrupnihSignalaButton, 0, prikazGrupnihSignalaButton.Height);
        }

        private void tSDToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Button buttonInitiated = (Button)izbornik.SourceControl; //koji smo button stisnuli

            if (buttonInitiated == prikazSvihSignalaButton)
            {
                string text;
                richTextBox1.Clear();
                text = srTSD.PrikaziSignale();
                text += prTSD.PrikaziSignale();
                text += irTSD.PrikaziSignale();
                text += ruTSD.PrikaziSignale();
                text += apuTSD.PrikaziSignale();
                text += zdTSD.PrikaziSignale();
                text += znTSD.PrikaziSignale();
                text += zzTSD.PrikaziSignale();
                text += wattTSD.PrikaziSignale();
                text += voltTSD.PrikaziSignale();
                text += ampTSD.PrikaziSignale();
                text += brTSD.PrikaziSignale();
                richTextBox1.Text = text;
            }
            else if (buttonInitiated == prikazTrenutnihSignalaButton)
            {
                string text;
                richTextBox1.Clear();
                text = srTSD.prikaziSignaleTrenutni();
                text += prTSD.prikaziSignaleTrenutni();
                text += irTSD.prikaziSignaleTrenutni();
                text += ruTSD.prikaziSignaleTrenutni();
                text += apuTSD.prikaziSignaleTrenutni();
                text += zdTSD.prikaziSignaleTrenutni();
                text += znTSD.prikaziSignaleTrenutni();
                text += zzTSD.prikaziSignaleTrenutni();
                text += wattTSD.prikaziSignaleTrenutni();
                text += voltTSD.prikaziSignaleTrenutni();
                text += ampTSD.prikaziSignaleTrenutni();
                text += brTSD.prikaziSignaleTrenutni();
                richTextBox1.Text = text;
            }   
            else if (buttonInitiated == prikazGrupnihSignalaButton)
            {
                string text;
                richTextBox1.Clear();
                text = srTSD.prikaziSignaleGrupni();
                text += prTSD.prikaziSignaleGrupni();
                text += irTSD.prikaziSignaleGrupni();
                text += ruTSD.prikaziSignaleGrupni();
                text += apuTSD.prikaziSignaleGrupni();
                text += zdTSD.prikaziSignaleGrupni();
                text += znTSD.prikaziSignaleGrupni();
                text += zzTSD.prikaziSignaleGrupni();
                text += wattTSD.prikaziSignaleGrupni();
                text += voltTSD.prikaziSignaleGrupni();
                text += ampTSD.prikaziSignaleGrupni();
                text += brTSD.prikaziSignaleGrupni();
                richTextBox1.Text = text;
            }
        }

        private void tSEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Button buttonInitiated = (Button)izbornik.SourceControl; //koji smo button stisnuli

            if (buttonInitiated == prikazSvihSignalaButton)
            {
                string text;
                richTextBox1.Clear();
                text = sr1TSE.PrikaziSignale();
                text += sr2TSE.PrikaziSignale();
                text += prTSE.PrikaziSignale();
                text += irTSE.PrikaziSignale();
                text += ruTSE.PrikaziSignale();
                text += apuTSE.PrikaziSignale();
                text += zdTSE.PrikaziSignale();
                text += znTSE.PrikaziSignale();
                text += zzTSE.PrikaziSignale();
                text += wattTSE.PrikaziSignale();
                text += voltTSE.PrikaziSignale();
                text += ampTSE.PrikaziSignale();
                text += brTSE.PrikaziSignale();
                richTextBox1.Text = text;
            }
            else if (buttonInitiated == prikazTrenutnihSignalaButton)
            {
                string text;
                richTextBox1.Clear();
                text = sr1TSE.prikaziSignaleTrenutni();
                text += sr2TSE.prikaziSignaleTrenutni();
                text += prTSE.prikaziSignaleTrenutni();
                text += irTSE.prikaziSignaleTrenutni();
                text += ruTSE.prikaziSignaleTrenutni();
                text += apuTSE.prikaziSignaleTrenutni();
                text += zdTSE.prikaziSignaleTrenutni();
                text += znTSE.prikaziSignaleTrenutni();
                text += zzTSE.prikaziSignaleTrenutni();
                text += wattTSE.prikaziSignaleTrenutni();
                text += voltTSE.prikaziSignaleTrenutni();
                text += ampTSE.prikaziSignaleTrenutni();
                text += brTSE.prikaziSignaleTrenutni();
                richTextBox1.Text = text;
            }
            else if (buttonInitiated == prikazGrupnihSignalaButton)
            {
                string text;
                richTextBox1.Clear();
                text = sr1TSE.prikaziSignaleGrupni();
                text += sr2TSE.prikaziSignaleGrupni();
                text += prTSE.prikaziSignaleGrupni();
                text += irTSE.prikaziSignaleGrupni();
                text += ruTSE.prikaziSignaleGrupni();
                text += apuTSE.prikaziSignaleGrupni();
                text += zdTSE.prikaziSignaleGrupni();
                text += znTSE.prikaziSignaleGrupni();
                text += zzTSE.prikaziSignaleGrupni();
                text += wattTSE.prikaziSignaleGrupni();
                text += voltTSE.prikaziSignaleGrupni();
                text += ampTSE.prikaziSignaleGrupni();
                text += brTSE.prikaziSignaleGrupni();
                richTextBox1.Text = text;
            }
        }

        private void srTSDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Button buttonInitiated = (Button)izbornik.SourceControl; //koji smo button stisnuli

            if (buttonInitiated == prikazSvihSignalaButton)
            {
                string text;
                richTextBox1.Clear();
                text = srTSD.PrikaziSignale();
                richTextBox1.Text = text;
            }
            else if (buttonInitiated == prikazTrenutnihSignalaButton)
            {
                string text;
                richTextBox1.Clear();
                text = srTSD.prikaziSignaleTrenutni();
                richTextBox1.Text = text;
            }
            else if (buttonInitiated == prikazGrupnihSignalaButton)
            {
                string text;
                richTextBox1.Clear();
                text = srTSD.prikaziSignaleGrupni();
                richTextBox1.Text = text;
            }
        }

        private void prTSDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Button buttonInitiated = (Button)izbornik.SourceControl; //koji smo button stisnuli

            if (buttonInitiated == prikazSvihSignalaButton)
            {
                string text = prTSD.PrikaziSignale();
                richTextBox1.Clear();
                richTextBox1.Text = text;
            }
            else if (buttonInitiated == prikazTrenutnihSignalaButton)
            {
                string text = prTSD.prikaziSignaleTrenutni();
                richTextBox1.Clear();
                richTextBox1.Text = text;
            }
            else if (buttonInitiated == prikazGrupnihSignalaButton)
            {
                string text = prTSD.prikaziSignaleGrupni();
                richTextBox1.Clear();
                richTextBox1.Text = text;
            }
        }

        private void irTSDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Button buttonInitiated = (Button)izbornik.SourceControl; //koji smo button stisnuli

            if (buttonInitiated == prikazSvihSignalaButton)
            {
                string text = irTSD.PrikaziSignale();
                richTextBox1.Clear();
                richTextBox1.Text = text;
            }
            else if (buttonInitiated == prikazTrenutnihSignalaButton)
            {
                string text = irTSD.prikaziSignaleTrenutni();
                richTextBox1.Clear();
                richTextBox1.Text = text;
            }
            else if (buttonInitiated == prikazGrupnihSignalaButton)
            {
                string text = irTSD.prikaziSignaleGrupni();
                richTextBox1.Clear();
                richTextBox1.Text = text;
            }
        }

        private void ruTSDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Button buttonInitiated = (Button)izbornik.SourceControl; //koji smo button stisnuli

            if (buttonInitiated == prikazSvihSignalaButton)
            {
                string text = ruTSD.PrikaziSignale();
                richTextBox1.Clear();
                richTextBox1.Text = text;
            }
            else if (buttonInitiated == prikazTrenutnihSignalaButton)
            {
                string text = ruTSD.prikaziSignaleTrenutni();
                richTextBox1.Clear();
                richTextBox1.Text = text;
            }
            else if (buttonInitiated == prikazGrupnihSignalaButton)
            {
                string text = ruTSD.prikaziSignaleGrupni();
                richTextBox1.Clear();
                richTextBox1.Text = text;
            }
        }

        private void apuTSDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Button buttonInitiated = (Button)izbornik.SourceControl; //koji smo button stisnuli

            if(buttonInitiated == prikazSvihSignalaButton)
            {
                string text = apuTSD.PrikaziSignale();
                richTextBox1.Clear();
                richTextBox1.Text = text;
            }
            else if (buttonInitiated == prikazTrenutnihSignalaButton)
            {
                string text = apuTSD.prikaziSignaleTrenutni();
                richTextBox1.Clear();
                richTextBox1.Text = text;
            }
            else if (buttonInitiated == prikazGrupnihSignalaButton)
            {
                string text = apuTSD.prikaziSignaleGrupni();
                richTextBox1.Clear();
                richTextBox1.Text = text;
            }
        }

        private void dzTSDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Button buttonInitiated = (Button)izbornik.SourceControl; //koji smo button stisnuli

            if (buttonInitiated == prikazSvihSignalaButton)
            {
                string text = zdTSD.PrikaziSignale();
                richTextBox1.Clear();
                richTextBox1.Text = text;
            }
            else if (buttonInitiated == prikazTrenutnihSignalaButton)
            {
                string text = zdTSD.prikaziSignaleTrenutni();
                richTextBox1.Clear();
                richTextBox1.Text = text;
            }
            else if (buttonInitiated == prikazGrupnihSignalaButton)
            {
                string text = zdTSD.prikaziSignaleGrupni();
                richTextBox1.Clear();
                richTextBox1.Text = text;
            }
        }

        private void znTSDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Button buttonInitiated = (Button)izbornik.SourceControl; //koji smo button stisnuli

            if (buttonInitiated == prikazSvihSignalaButton)
            {
                string text = znTSD.PrikaziSignale();
                richTextBox1.Clear();
                richTextBox1.Text = text;
            }
            else if (buttonInitiated == prikazTrenutnihSignalaButton)
            {
                string text = znTSD.prikaziSignaleTrenutni();
                richTextBox1.Clear();
                richTextBox1.Text = text;
            }
            else if (buttonInitiated == prikazGrupnihSignalaButton)
            {
                string text = znTSD.prikaziSignaleGrupni();
                richTextBox1.Clear();
                richTextBox1.Text = text;
            }
        }
        private void wattTSDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Button buttonInitiated = (Button)izbornik.SourceControl; //koji smo button stisnuli

            if (buttonInitiated == prikazSvihSignalaButton)
            {
                string text = wattTSD.PrikaziSignale();
                richTextBox1.Clear();
                richTextBox1.Text = text;
            }
            else if (buttonInitiated == prikazTrenutnihSignalaButton)
            {
                string text = wattTSD.prikaziSignaleTrenutni();
                richTextBox1.Clear();
                richTextBox1.Text = text;
            }
            else if (buttonInitiated == prikazGrupnihSignalaButton)
            {
                string text = wattTSD.prikaziSignaleGrupni();
                richTextBox1.Clear();
                richTextBox1.Text = text;
            }
        }

        private void ampTSDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Button buttonInitiated = (Button)izbornik.SourceControl; //koji smo button stisnuli

            if (buttonInitiated == prikazSvihSignalaButton)
            {
                string text = ampTSD.PrikaziSignale();
                richTextBox1.Clear();
                richTextBox1.Text = text;
            }
            else if (buttonInitiated == prikazTrenutnihSignalaButton)
            {
                string text = ampTSD.prikaziSignaleTrenutni();
                richTextBox1.Clear();
                richTextBox1.Text = text;
            }
            else if (buttonInitiated == prikazGrupnihSignalaButton)
            {
                string text = ampTSD.prikaziSignaleGrupni();
                richTextBox1.Clear();
                richTextBox1.Text = text;
            }
        }

        private void voltTSDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Button buttonInitiated = (Button)izbornik.SourceControl; //koji smo button stisnuli

            if (buttonInitiated == prikazSvihSignalaButton)
            {
                string text = voltTSD.PrikaziSignale();
                richTextBox1.Clear();
                richTextBox1.Text = text;
            }
            else if (buttonInitiated == prikazTrenutnihSignalaButton)
            {
                string text = voltTSD.prikaziSignaleTrenutni();
                richTextBox1.Clear();
                richTextBox1.Text = text;
            }
            else if (buttonInitiated == prikazGrupnihSignalaButton)
            {
                string text = voltTSD.prikaziSignaleGrupni();
                richTextBox1.Clear();
                richTextBox1.Text = text;
            }
        }

        private void brTSDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Button buttonInitiated = (Button)izbornik.SourceControl; //koji smo button stisnuli

            if (buttonInitiated == prikazSvihSignalaButton)
            {
                string text = brTSD.PrikaziSignale();
                richTextBox1.Clear();
                richTextBox1.Text = text;
            }
            else if (buttonInitiated == prikazTrenutnihSignalaButton)
            {
                string text = brTSD.prikaziSignaleTrenutni();
                richTextBox1.Clear();
                richTextBox1.Text = text;
            }
            else if (buttonInitiated == prikazGrupnihSignalaButton)
            {
                string text = brTSD.prikaziSignaleGrupni();
                richTextBox1.Clear();
                richTextBox1.Text = text;
            }
        }

        private void sr1TSEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Button buttonInitiated = (Button)izbornik.SourceControl; //koji smo button stisnuli

            if (buttonInitiated == prikazSvihSignalaButton)
            {
                string text = sr1TSE.PrikaziSignale();
                richTextBox1.Clear();
                richTextBox1.Text = text;
            }
            else if (buttonInitiated == prikazTrenutnihSignalaButton)
            {
                string text = sr1TSE.prikaziSignaleTrenutni();
                richTextBox1.Clear();
                richTextBox1.Text = text;
            }
            else if (buttonInitiated == prikazGrupnihSignalaButton)
            {
                string text = sr1TSE.prikaziSignaleGrupni();
                richTextBox1.Clear();
                richTextBox1.Text = text;
            }
        }

        private void sr2TSEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Button buttonInitiated = (Button)izbornik.SourceControl; //koji smo button stisnuli

            if (buttonInitiated == prikazSvihSignalaButton)
            {
                string text = sr2TSE.PrikaziSignale();
                richTextBox1.Clear();
                richTextBox1.Text = text;
            }
            else if (buttonInitiated == prikazTrenutnihSignalaButton)
            {
                string text = sr2TSE.prikaziSignaleTrenutni();
                richTextBox1.Clear();
                richTextBox1.Text = text;
            }
            else if (buttonInitiated == prikazGrupnihSignalaButton)
            {
                string text = sr2TSE.prikaziSignaleGrupni();
                richTextBox1.Clear();
                richTextBox1.Text = text;
            }
        }

        private void prTSEToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Button buttonInitiated = (Button)izbornik.SourceControl; //koji smo button stisnuli

            if (buttonInitiated == prikazSvihSignalaButton)
            {
                string text = prTSE.PrikaziSignale();
                richTextBox1.Clear();
                richTextBox1.Text = text;
            }
            else if (buttonInitiated == prikazTrenutnihSignalaButton)
            {
                string text = prTSE.prikaziSignaleTrenutni();
                richTextBox1.Clear();
                richTextBox1.Text = text;
            }
            else if (buttonInitiated == prikazGrupnihSignalaButton)
            {
                string text = prTSE.prikaziSignaleGrupni();
                richTextBox1.Clear();
                richTextBox1.Text = text;
            }
        }

        private void irTSEToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            Button buttonInitiated = (Button)izbornik.SourceControl; //koji smo button stisnuli

            if (buttonInitiated == prikazSvihSignalaButton)
            {
                string text = irTSE.PrikaziSignale();
                richTextBox1.Clear();
                richTextBox1.Text = text;
            }
            else if (buttonInitiated == prikazTrenutnihSignalaButton)
            {
                string text = irTSE.prikaziSignaleTrenutni();
                richTextBox1.Clear();
                richTextBox1.Text = text;
            }
            else if (buttonInitiated == prikazGrupnihSignalaButton)
            {
                string text = irTSE.prikaziSignaleGrupni();
                richTextBox1.Clear();
                richTextBox1.Text = text;
            }
        }

        private void ruTSEToolStripMenuItem4_Click(object sender, EventArgs e)
        {
            Button buttonInitiated = (Button)izbornik.SourceControl; //koji smo button stisnuli

            if (buttonInitiated == prikazSvihSignalaButton)
            {
                string text = ruTSE.PrikaziSignale();
                richTextBox1.Clear();
                richTextBox1.Text = text;
            }
            else if (buttonInitiated == prikazTrenutnihSignalaButton)
            {
                string text = ruTSE.prikaziSignaleTrenutni();
                richTextBox1.Clear();
                richTextBox1.Text = text;
            }
            else if (buttonInitiated == prikazGrupnihSignalaButton)
            {
                string text = ruTSE.prikaziSignaleGrupni();
                richTextBox1.Clear();
                richTextBox1.Text = text;
            }
        }

        private void apuTSEToolStripMenuItem5_Click(object sender, EventArgs e)
        {
            Button buttonInitiated = (Button)izbornik.SourceControl; //koji smo button stisnuli

            if (buttonInitiated == prikazSvihSignalaButton)
            {
                string text = apuTSE.PrikaziSignale();
                richTextBox1.Clear();
                richTextBox1.Text = text;
            }
            else if (buttonInitiated == prikazTrenutnihSignalaButton)
            {
                string text = apuTSE.prikaziSignaleTrenutni();
                richTextBox1.Clear();
                richTextBox1.Text = text;
            }
            else if (buttonInitiated == prikazGrupnihSignalaButton)
            {
                string text = apuTSE.prikaziSignaleGrupni();
                richTextBox1.Clear();
                richTextBox1.Text = text;
            }
        }

        private void dzTSEToolStripMenuItem6_Click(object sender, EventArgs e)
        {
            Button buttonInitiated = (Button)izbornik.SourceControl; //koji smo button stisnuli

            if (buttonInitiated == prikazSvihSignalaButton)
            {
                string text = zdTSE.PrikaziSignale();
                richTextBox1.Clear();
                richTextBox1.Text = text;
            }
            else if (buttonInitiated == prikazTrenutnihSignalaButton)
            {
                string text = zdTSE.prikaziSignaleTrenutni();
                richTextBox1.Clear();
                richTextBox1.Text = text;
            }
            else if (buttonInitiated == prikazGrupnihSignalaButton)
            {
                string text = zdTSE.prikaziSignaleGrupni();
                richTextBox1.Clear();
                richTextBox1.Text = text;
            }
        }

        private void znTSEToolStripMenuItem7_Click(object sender, EventArgs e)
        {
            Button buttonInitiated = (Button)izbornik.SourceControl; //koji smo button stisnuli

            if (buttonInitiated == prikazSvihSignalaButton)
            {
                string text = znTSE.PrikaziSignale();
                richTextBox1.Clear();
                richTextBox1.Text = text;
            }
            else if (buttonInitiated == prikazTrenutnihSignalaButton)
            {
                string text = znTSE.prikaziSignaleTrenutni();
                richTextBox1.Clear();
                richTextBox1.Text = text;
            }
            else if (buttonInitiated == prikazGrupnihSignalaButton)
            {
                string text = znTSE.prikaziSignaleGrupni();
                richTextBox1.Clear();
                richTextBox1.Text = text;
            }
        }

        private void wattTSEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Button buttonInitiated = (Button)izbornik.SourceControl; //koji smo button stisnuli

            if (buttonInitiated == prikazSvihSignalaButton)
            {
                string text = wattTSE.PrikaziSignale();
                richTextBox1.Clear();
                richTextBox1.Text = text;
            }
            else if (buttonInitiated == prikazTrenutnihSignalaButton)
            {
                string text = wattTSE.prikaziSignaleTrenutni();
                richTextBox1.Clear();
                richTextBox1.Text = text;
            }
            else if (buttonInitiated == prikazGrupnihSignalaButton)
            {
                string text = wattTSE.prikaziSignaleGrupni();
                richTextBox1.Clear();
                richTextBox1.Text = text;
            }
        }

        private void ampTSEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Button buttonInitiated = (Button)izbornik.SourceControl; //koji smo button stisnuli

            if (buttonInitiated == prikazSvihSignalaButton)
            {
                string text = ampTSE.PrikaziSignale();
                richTextBox1.Clear();
                richTextBox1.Text = text;
            }
            else if (buttonInitiated == prikazTrenutnihSignalaButton)
            {
                string text = ampTSE.prikaziSignaleTrenutni();
                richTextBox1.Clear();
                richTextBox1.Text = text;
            }
            else if (buttonInitiated == prikazGrupnihSignalaButton)
            {
                string text = ampTSE.prikaziSignaleGrupni();
                richTextBox1.Clear();
                richTextBox1.Text = text;
            }
        }

        private void voltTSEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Button buttonInitiated = (Button)izbornik.SourceControl; //koji smo button stisnuli

            if (buttonInitiated == prikazSvihSignalaButton)
            {
                string text = voltTSE.PrikaziSignale();
                richTextBox1.Clear();
                richTextBox1.Text = text;
            }
            else if (buttonInitiated == prikazTrenutnihSignalaButton)
            {
                string text = voltTSE.prikaziSignaleTrenutni();
                richTextBox1.Clear();
                richTextBox1.Text = text;
            }
            else if (buttonInitiated == prikazGrupnihSignalaButton)
            {
                string text = voltTSE.prikaziSignaleGrupni();
                richTextBox1.Clear();
                richTextBox1.Text = text;
            }
        }

        private void brTSEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Button buttonInitiated = (Button)izbornik.SourceControl; //koji smo button stisnuli

            if (buttonInitiated == prikazSvihSignalaButton)
            {
                string text = brTSE.PrikaziSignale();
                richTextBox1.Clear();
                richTextBox1.Text = text;
            }
            else if (buttonInitiated == prikazTrenutnihSignalaButton)
            {
                string text = brTSE.prikaziSignaleTrenutni();
                richTextBox1.Clear();
                richTextBox1.Text = text;
            }
            else if (buttonInitiated == prikazGrupnihSignalaButton)
            {
                string text = brTSE.prikaziSignaleGrupni();
                richTextBox1.Clear();
                richTextBox1.Text = text;
            }
        }
    }
}