using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Gamemania.Models
{
    public class AdresModel
    {
        public int AdresID { get; set; }
        public string Land { get; set; }
        public string Postcode { get; set; }
        public string Plaatsnaam { get; set; }
        public string Straatnaam { get; set; }
        public int Huisnummer { get; set; }
        public string Toevoeging { get; set; }

        public AdresModel(int ID, string land , string postcode , string plaatsnaam, string straatnaam , int huisnummer ,string toevoeging)
        {
            ID = AdresID;
            Land = land;
            Postcode = postcode;
            Plaatsnaam = plaatsnaam;
            Straatnaam = straatnaam;
            Huisnummer = huisnummer;
            Toevoeging = toevoeging;
        }
        public AdresModel()
        {

        }

        public AdresModel ToevoegenAdres(int id , string land, string postcode, string plaatsnaam, string straatnaam, int huisnummer, string toevoeging)
        {
            AdresModel adres = new AdresModel(id , land, postcode, plaatsnaam, straatnaam, huisnummer, toevoeging);
            return adres;
        }
    }
}