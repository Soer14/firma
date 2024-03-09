using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProjectCommon
{
    internal class PlayingWithClassesTest
    {

        
        [Test]
        public void PatternFirst()
        {
           // Prepare
           // bierzesz szklanke

           // Act
           // rzucasz w scianę


           //Test
           // Sprawdzasz czy jest cala czy nie
        }


        [Test]
        public void TestFirst()
        {

            //Prepare
            var czlowiek = new Czlowiek();
            var bydle = new Zwierze();
            var fish = new Fish();
            //Act
            //  zadzailo w konstruktorze

            //Test
            //Assert.AreEqual("dupa", czlowiek.NazwaNaukowa);
            Assert.IsTrue(czlowiek is IstotaZywa);


            //metoda
            czlowiek.Ssij();

            // funcja 
           var odleglosc =  czlowiek.Idz();

           // funkcja uzyta jak metoda
           czlowiek.Idz(); // wersja chamska
          _ = czlowiek.Idz(); // wersja dla kolegow czytajacych kod
          
            Assert.AreEqual(false, fish is Ssak);



            czlowiek.Ssij();
        }

        


    }
    public class Fish : Zwierze
    {
        public Fish()
        {
            NazwaNaukowa = "Fish";
        }
    }

    public class IstotaZywa
    {
        public string NazwaNaukowa { get; set; }
    }

    public class Zwierze : IstotaZywa
    {
        public Zwierze()
        {
            NazwaNaukowa = "Animalia";
        }
    }

    public class Ssak : Zwierze
    {

        // konstruktor
        public Ssak()
        {
            NazwaNaukowa = "Mammalia";
        }

        //property, cechy, własciwości, pole

    public AnimalHabitat Habitat {get; set;}


         // method, metoda

         public decimal Idz() {
            return 100m ;
         }



        public void Ssij() //metoda nie zwracająca wyniku
        {

        }
    }

    public enum AnimalHabitat
    {
        Marine,
        Terrestrial,
        Freshwater,
        Aerial
    }


    public class Czlowiek : Ssak
    {
        public Czlowiek()
        {
            NazwaNaukowa = "Homo sapiens";
        }
    }
}
