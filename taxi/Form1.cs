using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace taxi
{
    public partial class Form1 : Form
    {
        public class TaxiAdatok 
        {
            public int taxi_id;
            public string indulas;
            public double idotartam;
            public double tavolsag;
            public double viteldij;
            public double borravalo;
            public string fizetes_modja;
        }

        public Form1()
        {
            InitializeComponent();
        }


        public TaxiAdatok taxiFeltoltese = new TaxiAdatok();
        public List<TaxiAdatok> taxik = new List<TaxiAdatok>();

        private void Form1_Load(object sender, EventArgs e)
        {
            label1.Text = "";

            FileStream folyam = new FileStream("fuvarmod.txt", FileMode.Open);
            StreamReader olvas = new StreamReader(folyam);


            string elso = olvas.ReadLine();

            string[] resz;

            while (!olvas.EndOfStream)
            {
                elso = olvas.ReadLine();

                resz = elso.Split(';');

                TaxiAdatok taxiFeltoltese = new TaxiAdatok();

                taxiFeltoltese.taxi_id = Convert.ToInt32(resz[0]);
                taxiFeltoltese.indulas = resz[1];
                taxiFeltoltese.idotartam = Convert.ToDouble(resz[2]);
                taxiFeltoltese.tavolsag = Convert.ToDouble(resz[3]);
                taxiFeltoltese.viteldij = Convert.ToDouble(resz[4]);
                taxiFeltoltese.borravalo = Convert.ToDouble(resz[5]);
                taxiFeltoltese.fizetes_modja = resz[6];

                taxik.Add(taxiFeltoltese);
            }

            // Feladat 1;
            //label1.Text = $"{taxik.Count}\n";


            //6185 mennyi volt a bevetele és hány fuvarbol

            var lek1 =
                from x in taxik
                where x.taxi_id == 6185
                select new { x.taxi_id, x.viteldij, x.borravalo};

            int fuvar = 0;
            double bevetel = 0;

            foreach (var item in lek1)
            {
                fuvar++;
                bevetel += (item.borravalo + item.viteldij);
            }

            label1.Text += $"Fuvarok száma: {fuvar} Teljes bevétel: {bevetel}";
        }
    }
}
