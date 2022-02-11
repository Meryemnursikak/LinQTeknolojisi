using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LinQTeknolojisi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DataSource dc = new DataSource();
            List<Musteri> liste = dc.musterilistesi();

            //ismi a ile başlayan müşteri sayısı için sayac,döngü ve şartımızı yazdık

            int sayac = 0;
            for (int i = 0; i < 100; i++)
            {
               
                
                if (liste[i].ad[0] == 'A')
                {
                    sayac++;
                }
            }

            

            //LinQ to ile bunu nasıl yaparız? 1.YOL metot
            //bulunanı sıfırdan başlattık listede nerede dedik, i öyleki adının başlangıcı a ise ve sayaca koyduk count ile
            //bulunanı 0 a eşitledik sayac gibi
            //int bulunanadet = 0;
            //bulunanadet = liste.Where(i => i.ad.StartsWith("A")).Count();

            //2.YOL query
            //var bulunanmusteriler = from I in liste where I.ad.StartsWith("A") select I;
            //bulunanadet = bulunanmusteriler.Count();

            //Ülkesi a ile başlayanlar
            //IEnumerable<Musteri> musteriliste = liste.Where(x => x.ulke.StartsWith("A"));
            //int bulunanulke = 0;
            //var ulkebul = from U in liste where U.ulke.StartsWith("A") select U;
            //bulunanadet =musteriliste.Count();

            //foreach (var item in musteriliste)
            //{
            //    listBox1.Items.Add(item);
            //}

            //ismi içende b harfi ülkesi içinde a harfi geçen lite
            //var musteriliste2 = liste.Where(x => x.ad.Contains("b") && x.ulke.Contains("a"));

            //foreach (var item in musteriliste2)
            //{
            //    listBox1.Items.Add(item);
            //}

            //doğum yılı 2010 dan büyük olan ve adı içinde a harfi geçenler

            //var musteriliste3 = from D in liste where D.dogumtarihi.Year > 2010 
            //                    && D.ad.ToLower().Contains("a") select D;

            //foreach (var item in musteriliste3)
            //{
            //    listBox1.Items.Add(item);
            //}


            //adı b ile başlayan soyadı içinde e geçen ve doğum tarihi >2000 olan kayıtlar

            var mustreiliste4 = from M in liste where M.ad.ToUpper().StartsWith("B") 
                                || M.soyad.ToUpper().Contains("e")
                                && M.dogumtarihi.Year > 2000 select M;

            //foreach ile listenin her bir elemanını alıp listboxa ekledik.
            liste.ForEach(x => listBox1.Items.Add((x.ad + " " + x.soyad).ToString()));

            MessageBox.Show(sayac.ToString());

        }

        public bool fundelegetemetot(Musteri m)
        {
            if (m.ad[0] == 'A')
                return true;
            else
                return false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataSource dc = new DataSource();
            List<Musteri> liste = dc.musterilistesi();

            //1.yöntem son hal
            var AileBaslayan1=liste.Where(I => I.ad.StartsWith("A"));

            Func<Musteri, bool> funcdelegete = new Func<Musteri, bool>(fundelegetemetot);

            //2.yöntem bir önceki hal
            var AileBaslayan2 = liste.Where(funcdelegete);

            //1yöntem-hal ilk hali linq to dan önce yani
            var AileBaslayan3 = liste.Where(delegate (Musteri m) { return m.ad[0] == 'A' ? true : false; });

            var dogumtarihinegore = liste.FindAll(m => m.dogumtarihi.Year > 2000);

            Action<Musteri> action = new Action<Musteri>(accoinmetot);
            //bu yukarıdakinden gelir.
            liste.ForEach(m => m.ad.ToString());
        }

        private void accoinmetot(Musteri obj)
        {
            
        }
    }
}
