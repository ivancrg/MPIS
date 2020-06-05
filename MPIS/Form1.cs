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

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void srTSD_Click(object sender, EventArgs e)
        {
            
        }

        private void prikazSvihSignala_Click(object sender, EventArgs e)
        {
            izbornik.Show(prikazSvihSignala, 0, prikazSvihSignala.Height);
        }

        private void prikazTrenutnihSignala_Click(object sender, EventArgs e)
        {
            izbornik.Show(prikazTrenutnihSignala, 0, prikazTrenutnihSignala.Height);
        }

        private void sR1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Button buttonInitiated = (Button)izbornik.SourceControl; //koji smo button stisnuli
            
            if (buttonInitiated == prikazSvihSignala)
            {
                MessageBox.Show("svi");
                //prikaz svih signala za SR1 TSE
            }
            else if (buttonInitiated == prikazTrenutnihSignala)
            {
                MessageBox.Show("trenutni");
                //prikaz trenutnih signala za SR1 TSE
            }
        }

        private void sR2ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}