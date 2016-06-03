using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Gamemania.Models
{
    public class GebruikerModel : ApplicationUser
    {
        public int GebruikerID { get; set; }
        public string Gebruikersnaam { get; set; }
        public string Wachtwoord { get; set; }
        public string Voornaam { get; set; }
        public string Tussenvoegsel { get; set; }
        public string Achternaam { get; set; }
        public DateTime Geboortedatum { get; set; }
        public override string Email { get; set; }
        public int Telefoonnummer { get; set; }

        public AdresModel Adres = new AdresModel();

        public List<LijstModel> Wishlijst = new List<LijstModel>();

        public List<LijstModel> Collectionlijst = new List<LijstModel>();

        public List<BestellingModel> Bestellinglijst = new List<BestellingModel>();

        public GebruikerModel(string gebruikersnaam, string wachtwoord , string voornaam , string tussenvoegsel , string achternaam , 
            DateTime geboortedatum , string geslacht , string email , int telefoonnummer , 
            AdresModel adres , List<LijstModel> wishlijst , List<LijstModel> collectionlijst , List<BestellingModel> bestellinglijst)
        {

        }

        public GebruikerModel(int gebruikerID , string gebruikersnaam, string wachtwoord, string voornaam, string tussenvoegsel, string achternaam,
            DateTime geboortedatum, string email, int telefoonnummer , AdresModel adres)
        {
            GebruikerID = gebruikerID;
            Gebruikersnaam = gebruikersnaam;
            Wachtwoord = wachtwoord;
            Voornaam = voornaam;
            Tussenvoegsel = tussenvoegsel;
            Achternaam = achternaam;
            Geboortedatum = geboortedatum;
            Email = email;
            Telefoonnummer = telefoonnummer;
            Adres = adres;
        }

        public GebruikerModel()
        {

        }


    }
}