using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinQTeknolojisi
{
    public class DataSource
    {
        List<Musteri> liste = new List<Musteri>();
        public List<Musteri> musterilistesi()
        {
            for (int i = 0; i < 101; i++)
            {
                Musteri m = new Musteri();
                m.id = i;
                m.ad = FakeData.NameData.GetFirstName();
                m.soyad = FakeData.NameData.GetMaleFirstName();
                m.ulke = FakeData.PlaceData.GetCountry();
                m.email = $"{m.ad}.{m.soyad}@{FakeData.NetworkData.GetDomain()}";
                m.tel = FakeData.PhoneNumberData.GetPhoneNumber();
                m.dogumtarihi = FakeData.DateTimeData.GetDatetime();

                liste.Add(m);

            }
            return liste;
        }
    }

}
