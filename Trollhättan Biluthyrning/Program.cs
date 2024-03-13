using System;
using System.Collections.Generic;

namespace Trollhättan_Biluthyrning
{
    class Program
    {
        static void Main(string[] args)
        {

           
            //Meny metoden ska vara utgånspunkten, main ska vara tomt, eftersom användaren skulle kunna få mer chans, alternativ.

            Meny();


        }

        static void Meny()
        {
            Console.WriteLine("Hej och välkommen till Trollhättan biluthyrning!\n" + "Välj en av följande alternativ genom att skriva en siffra, läs gärna våran villkor innan du väljer hyra en bil!" + "\n");
            Console.WriteLine("1-Hyr en bil\n" + "2-Läs på våran villkor\n" + "3-Avsluta\n ");
            Console.WriteLine(string.Empty);

            string val = Console.ReadLine();

            bool inmatning = false;

           
            //Här programmet ska se till att användaren mata in rätt val,
            //annars kommer användare inte kunna gå vidare.
            while (inmatning == false)
            {

                if (val == "1" || val == "2" || val == "3")
                {
                    inmatning = true;

                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Ogiltigt val, försök igen!");
                    Console.ResetColor();
                    val = Console.ReadLine().ToUpper();
                }

            }


            if (val == "1")
            {
                
                // Visar bilar,deras egenskaper och priser från en metod som har dessa information.
                BilarOchSinaEgenskaper();
            }
            else if (val == "2")
            {
                //Nasro
                //visar villkor för företaget
                Villkor();
            }
            else if (val == "3")
            {
                Console.WriteLine("Tack för besöket och du är välkommen åter!");
                System.Environment.Exit(0);
            }

        }


        static void BilarOchSinaEgenskaper()
        {


            // Den metoden, ska innehålla listor på bilinformation,priser mm.Sen ska metoden skriva ut bilarna som är tillgängliga 
            // samt andra information,därefter ska metoden ta emot användaren val 
            //och returnera det här.

            string val = BilarOchValAlternativ();

            
            //Den metoden kommer att fråga användaren om sina uppgifter och val.
            ValAvBil(val);



        }
        static string BilarOchValAlternativ()
        {
           
            // initiera en lista som innehåller allmänna info.
            string[] egenskaper = { "Bilmärke", "Växellåda", "Modellår", "Sittplatser", "Dygn/100km", "Dygn/fria mil" };
            
            //Initiera en lista som ska innehålla första bilens info och sina egenskaper. 
            List<string> volvo = new System.Collections.Generic.List<string>() { "1- Volvo", "Automat", "2020", "5 sittplatser", "750kr", "829kr" };
            
            //initiera en lista som ska innehålla andra bilens info och sina egenskaper.
            List<string> toyota = new List<string>() { "2- Toyota", "Manuell", "2019", "5 sittplatser", "630kr", "709kr" };
            
            //Initiera en lista med tredje bilens info och sina egenskaper.
            List<string> nissan = new List<string>() { "3- Nissan", "Automat", "2020", "7 sittplatser", "920kr", "999kr" };

            
            Console.WriteLine("Välj en bil genom att skriva en siffra\n" + "Ex: om du skriver 1, då har du valt volvo");
            Console.WriteLine(string.Empty);
            
            //Här ska skrivas ut alla bilar, priser osv, som en tabell. 
            foreach (string egenskap in egenskaper)
            {
                Console.Write(egenskap + "\t");

            }
            Console.WriteLine("\n");

            foreach (string ord in volvo)
            {
                Console.Write(ord + "    \t");
            }
            Console.WriteLine(string.Empty);
            foreach (string ord in toyota)
            {
                Console.Write(ord + "    \t");
            }
            Console.WriteLine(string.Empty);
            foreach (string ord in nissan)
            {
                Console.Write(ord + "    \t");
            }
            Console.WriteLine(string.Empty);
            string bilValInmatning = Console.ReadLine();
            bool inmatning = false;
            
            //Här uppmuntrar programmet användaren till att välja rätt val.

            while (inmatning == false)
            {

                if (bilValInmatning == "1" || bilValInmatning == "2" || bilValInmatning == "3")
                {
                    inmatning = true;

                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Ogiltigt val, försök igen!");
                    Console.ResetColor();
                    bilValInmatning = Console.ReadLine().ToUpper();
                }

            }
            return bilValInmatning;
        }

        
        //Den metoden, ska fråga användaren olika frågor,sedan ska alla info lagras.
        static void ValAvBil(string val)
        {
            string val2 = val;

            Console.WriteLine("Skriv ditt förnamn");
            string fornamn = Console.ReadLine();
            Console.WriteLine("Skriv ditt efternamn");
            string efternamn = Console.ReadLine();
            Console.WriteLine("Hur gammal är du?");
           
            // Här sker felhantering i en annan metod,metoden ska se till att användaren mata in ett heltal.
          
            int alder = FelhanteringAlder();

           
            //Programmet avslutas om användaren är yngre än 20år.
            if (alder < 20)
            {
                Console.WriteLine("Du är för ung för att hyra en bil från oss, välkommen åter när du har fyllt 20år");
                System.Environment.Exit(0);
            }






            Console.WriteLine("Hur många dagar vill du hyra bilen?");

            // Här sker felhantering i en annan metod, metoden kommer att reurnera antal dagar när användaren har mattat in ett heltal
            int antalDagar = FelhanteringAntalDagar();

            Console.ResetColor();

            //Den här metoden kommer att se till att användaren matar in rätt datum och rätt form
            //därefter ska metoden returnera ett datum.
            DateTime datum = BilInlamning();

            Console.WriteLine("Vill du ha försäkring? Det kostar 79kr/dygn. ja/nej");
            bool inmatning = false;

            string forsakring = Console.ReadLine().ToUpper();

            //Användaren ska skriva Ja eller nej för att kunna gå vidare.
            while (inmatning == false)
            {

                if (forsakring == "JA" || forsakring == "NEJ")
                {
                    inmatning = true;

                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Du måste skriva antingen ja eller nej, försök igen!");
                    Console.ResetColor();
                    forsakring = Console.ReadLine().ToUpper();
                }

            }


            Console.WriteLine("Hur många km tänker du köra?");
          
            //Den metod ska se till att användaren matar in ett heltal som är större än 0
            //därefter ska metoden returnera körsträckan.
            int korstracka = FelhanteringKorstracka();
            Console.WriteLine();

            //Beroende på användarens val om bil, det vill säga om argumentet i ValAvBil
            //så kommer att ske matematiska beräkningar, beroende på vilken bil har användaren valt.
            if (val2 == "1")
            {
                Volvo(fornamn, efternamn, alder, antalDagar, forsakring, korstracka, datum);
            }
            else if (val2 == "2")
            {
                Toyota(fornamn, efternamn, alder, antalDagar, forsakring, korstracka, datum);
            }
            else if (val2 == "3")
            {
                Nissan(fornamn, efternamn, alder, antalDagar, forsakring, korstracka, datum);
            }

        }



        static void Volvo(string fornamn, string efternamn, int alder, int antalDagar, string forsakring, int korstracka, DateTime datum)
        {
            
            int kostandDygn = 750;
            int totalKostnad = 0;

            
            //Här sker matematiska beräkningar
            if ((forsakring == "JA") && (korstracka > 100))
            {
                totalKostnad = (kostandDygn * antalDagar) + (antalDagar * 79) + (antalDagar * 59);

            }
            else if ((forsakring == "JA") && (korstracka < 100))
            {
                totalKostnad = (kostandDygn * antalDagar) + (59 * antalDagar);
            }
            else if ((forsakring == "NEJ") && (korstracka > 100))
            {
                totalKostnad = (kostandDygn * antalDagar) + (79 * antalDagar);
            }
            else
            {
                totalKostnad = kostandDygn * antalDagar;
            }
            Console.WriteLine(string.Empty);
          
            //Allt ska raderas och användaren information skrivs ut.
            Console.Clear();
            Console.WriteLine("Här är dina personuppgifter och dina val:\n" + "Förnamn: {0}\n" + "Efternamn: {1}\n" + "Ålder: {2}\n" + "Antal dagar du vill hyra bilen: {3} dagar\n" + "Försäkring: {4}\n" + "Körsträcka: {5}km\n", fornamn, efternamn, alder, antalDagar, forsakring, korstracka);
            Console.Write("Bilinformation\n" + "Bilmärke: Volvo\t   " + "Växellåda: Automat\t   " + "Modellår: 2020\t   " + "   Sittplatser: 5 sittplatser\t");
            Console.WriteLine(string.Empty);
            Console.WriteLine("Bilen ska hämtas : " + datum.ToLongDateString() + "\n" + "Bilen ska lämnas : " + datum.AddDays(antalDagar).ToLongDateString());
            Console.WriteLine(string.Empty);

           
           
            //Här presenteras totalt kostnad. Kunden får olika total kostnader beroende på val. Exempel, väljer användaren försäkring samt fria mil
            //då får hen total kostnad inklusive försäkring och fria mil som tillägger extra avgift.
            if (forsakring == "JA" && korstracka > 100)
            {
                Console.WriteLine("Totalt kostnaden för hyran inklusive fria mil och försäkrning är {0}kr", totalKostnad);
            }
            else if (forsakring == "JA" && korstracka < 100)
            {
                Console.WriteLine("Totalt kostnaden för hyran inklusive försäkrning och utan fria mil är {0}kr", totalKostnad);
            }
            else if (forsakring == "NEJ" && korstracka > 100)
            {
                Console.WriteLine("Totalt kostnaden för hyran inklusive fria mil, exklusive försäkrning är {0}kr", totalKostnad);
            }
            else
            {
                Console.WriteLine("Totalt kostnaden för hyran exklusive fria mil och försäkrning är {0}kr", totalKostnad);
            }
            Console.WriteLine(string.Empty);
           
            //Sista steg, programmet ska fråga användaren om hen vill bekräfta bokningen via
            //den metod som kommer att kontrollera användaren svar, beroende på användaren svar, kommer olika saker att ske.
            SistaKontrollOchAdjo(fornamn, efternamn);

        }
        static void Toyota(string fornamn, string efternamn, int alder, int antalDagar, string forsakring, int korstracka, DateTime datum)
        {
          


            int kostandDygn = 630;
            int totalKostnad = 0;
            if ((forsakring == "JA") && (korstracka > 100))
            {
                totalKostnad = (kostandDygn * antalDagar) + (antalDagar * 79) + (antalDagar * 59);

            }
            else if ((forsakring == "JA") && (korstracka < 100))
            {
                totalKostnad = (kostandDygn * antalDagar) + (59 * antalDagar);
            }
            else if ((forsakring == "NEJ") && (korstracka > 100))
            {
                totalKostnad = (kostandDygn * antalDagar) + (79 * antalDagar);
            }
            else
            {
                totalKostnad = kostandDygn * antalDagar;
            }
            Console.WriteLine(string.Empty);

            //Allt kommer att raderas och användarens information skrivs ut.
            Console.Clear();
            Console.WriteLine("Här är dina personuppgifter och dina val:\n" + "Förnamn: {0}\n" + "Efternamn: {1}\n" + "Ålder: {2}\n" + "Antal dagar du vill hyra bilen: {3} dagar\n" + "Försäkring: {4}\n" + "Körsträcka: {5}km", fornamn, efternamn, alder, antalDagar, forsakring, korstracka);
            Console.Write("Bilinformation\n" + "Bilmärke: Toyota\t" + "Växellåda: Manuell\t" + "Modellår: 2019\t" + "   Sittplatser: 5 sittplatser");
            Console.WriteLine(string.Empty);
            Console.WriteLine("Bilen ska hämtas : " + datum.ToLongDateString() + "\n" + "Bilen ska lämnas : " + datum.AddDays(antalDagar).ToLongDateString());

            Console.WriteLine(string.Empty);
        
            //Här presenteras totalt kostnad. Kunden får olika total kostnader beroende på val. Exempel, väljer användaren försäkring samt fria mil
            //då får hen total kostnad inklusive försäkring och fria mil som tillägger extra avgift.
            if (forsakring == "JA" && korstracka > 100)
            {
                Console.WriteLine("Totalt kostnaden för hyran inklusive fria mil och försäkrning är {0}kr", totalKostnad);
            }
            else if (forsakring == "JA" && korstracka < 100)
            {
                Console.WriteLine("Totalt kostnaden för hyran inklusive försäkrning och utan fria mil är {0}kr", totalKostnad);
            }
            else if (forsakring == "NEJ" && korstracka > 100)
            {
                Console.WriteLine("Totalt kostnaden för hyran inklusive fria mil, exklusive försäkrning är {0}kr", totalKostnad);
            }
            else
            {
                Console.WriteLine("Totalt kostnaden för hyran exklusive fria mil och försäkrning är {0}kr", totalKostnad);
            }
            Console.WriteLine(string.Empty);
           
            //Sista steg, programmet ska fråga användaren om hen vill bekräftta bokningen via
            //den metod som kommer att kontrollera användaren svar, beroende på användaren svar, kommer olika saker att ske.
            SistaKontrollOchAdjo(fornamn, efternamn);


        }

        
        static void Nissan(string fornamn, string efternamn, int alder, int antalDagar, string forsakring, int korstracka, DateTime datum)
        {


            int kostandDygn = 920;
            int totalKostnad = 0;

            //Här sker matematiska beräkningar
            if ((forsakring == "JA") && (korstracka > 100))
            {
                totalKostnad = (kostandDygn * antalDagar) + (antalDagar * 79) + (antalDagar * 59);

            }
            else if ((forsakring == "JA") && (korstracka < 100))
            {
                totalKostnad = (kostandDygn * antalDagar) + (59 * antalDagar);
            }
            else if ((forsakring == "NEJ") && (korstracka > 100))
            {
                totalKostnad = (kostandDygn * antalDagar) + (79 * antalDagar);
            }
            else
            {
                totalKostnad = kostandDygn * antalDagar;
            }
            Console.WriteLine(string.Empty);
        
            //Allt ska raderas och användaren information skrivs ut.
            Console.Clear();
            Console.WriteLine("Här är dina personuppgifter och dina val:\n" + "Förnamn: {0}\n" + "Efternamn: {1}\n" + "Ålder: {2}\n" + "Antal dagar du vill hyra bilen: {3} dagar\n" + "Försäkring: {4}\n" + "Körsträcka: {5}km", fornamn, efternamn, alder, antalDagar, forsakring, korstracka);
            Console.Write("Bilinformation\n" + "Bilmärke: Nissan\t" + "     Växellåda: Automat\t" + "      Modellår: 2020\t" + "      Sittplatser: 7 sittplatser");
            Console.WriteLine(string.Empty);
            Console.WriteLine("Bilen ska hämtas : " + datum.ToLongDateString() + "\n" + "Bilen ska lämnas : " + datum.AddDays(antalDagar).ToLongDateString());
            Console.WriteLine(string.Empty);

            //Här presenteras totalt kostnad. Kunden får olika total kostnader beroende på val. Exempel, väljer användaren försäkring samt fria mil
            //då får hen total kostnad inklusive försäkring och fria mil som tillägger extra avgift.
            if (forsakring == "JA" && korstracka > 100)
            {
                Console.WriteLine("Totalt kostnaden för hyran inklusive fria mil och försäkrning är {0}kr", totalKostnad);
            }
            else if (forsakring == "JA" && korstracka < 100)
            {
                Console.WriteLine("Totalt kostnaden för hyran inklusive försäkrning och utan fria mil är {0}kr", totalKostnad);
            }
            else if (forsakring == "NEJ" && korstracka > 100)
            {
                Console.WriteLine("Totalt kostnaden för hyran inklusive fria mil, exklusive försäkrning är {0}kr", totalKostnad);
            }
            else
            {
                Console.WriteLine("Totalt kostnaden för hyran exklusive fria mil och försäkrning är {0}kr", totalKostnad);
            }
            Console.WriteLine(string.Empty);

           
            //Sista steg, programmet ska fråga användaren om hen vill bekräftta bokningen via
            //den metod som kommer att kontrollera användaren svar, beroende på användaren svar, kommer olika saker att ske.
            SistaKontrollOchAdjo(fornamn, efternamn);


        }

        static void SistaKontrollOchAdjo(string fornamn, string efternamn)
        {
          
            //Detta steg ska porgrammet fråga användaren ifall hens uppgifter stämmer eller ifall hen vill göra ändringar. 
            //Då får hen möjlighet att ändra de genom att trycka nej, annars väljer hen ja om allt stämmer.
            Console.WriteLine("Stämmer alla dina uppgifter? Ja/nej ");
            string sistaFraga = Console.ReadLine().ToUpper();
            
            bool inmatning = false;
            while (inmatning == false)
            {
                if (sistaFraga == "NEJ")
                {
                    inmatning = true;
                    Console.Clear();
                    Console.WriteLine("Nu kan du börja igen och fylla på uppgifter!\n");

                    BilarOchSinaEgenskaper();
                }

                else if (sistaFraga == "JA")
                {

                    inmatning = true;

                }



                else
                {
                    inmatning = false;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Var vänlig och skriv ja eller nej!");
                    Console.ResetColor();
                    sistaFraga = Console.ReadLine().ToUpper();
                }
            }
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Bokningen har utfört!\n" + "Tack {0} {1} för att du valde att hyra en bil från Trollhättan Biluthyrning!\n" + "Vi ses på vår station!", fornamn, efternamn);
            Console.ResetColor();
        }

        static int FelhanteringAlder()

        {
           

            int alder = 0;
            bool inmatning = false;
            while (inmatning == false)
            {

                try

                {
                    alder = int.Parse(Console.ReadLine());
                    inmatning = true;

                }




                catch (FormatException ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Du måste skriva ett heltal\n" + ex.Message);
                    Console.ResetColor();
                }
                if (alder > 85)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("SKriv ett rimligt ålder!");
                    Console.ResetColor();
                    inmatning = false;

                }

            }
            return alder;


        }

        static int FelhanteringAntalDagar()

        {
            
            int antalDagar = 0;
            bool inmatning = false;
            while (inmatning == false)
            {

                try

                {
                    antalDagar = int.Parse(Console.ReadLine());
                    inmatning = true;
                    if (antalDagar > 7)
                    {
                        
                        
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Det går inte att hyra en bil mer än en vecka! Försök igen!");
                        Console.ResetColor();
                        inmatning = false;


                        
                    }
                    else if (antalDagar <= 0)
                    {
                      
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Fel tal! Skriv ett tal som är större än 0!");
                        Console.ResetColor();
                        inmatning = false;
                        
                    }
                    Console.ResetColor();
                }


                catch (Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Du måste skriva ett heltal\n" + ex.Message);
                    Console.ResetColor();
                }


            }

            return antalDagar;
        }



        static int FelhanteringKorstracka()
        {
        

            int korstracka = 0;
            bool inmatning = false;
            while (inmatning == false)
            {

                try

                {
                    korstracka = int.Parse(Console.ReadLine());
                    inmatning = true;
                }


                catch (Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Du måste skriva ett heltal\n" + ex.Message);
                    Console.ResetColor();
                }
                if (korstracka<= 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Du måste skriva ett tal som är större än 0 ");
                    inmatning = false;
                    Console.ResetColor();
                }

            }
            return korstracka;

        }

        static DateTime BilInlamning()

        {
            

            bool inmatning = false;
            DateTime datum = DateTime.Today;

            Console.WriteLine("Nuvarande datum är " + datum.ToShortDateString());
            Console.WriteLine("När vill du hämta bilen? skriv så här (åååå-mm-dd)");
            while (inmatning == false)
            {
                try
                {

                    datum = DateTime.Parse(Console.ReadLine());
                    if (datum == DateTime.Today || datum > DateTime.Today)
                    {
                        inmatning = true;
                    }

                    else if (datum < DateTime.Today)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Fel datum, skriv igen!");
                        Console.ResetColor();
                        inmatning = false;
                    }

                    else
                    {
                        inmatning = true;
                    }

                }
                catch (FormatException)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Du måste skriva på rätt form, försök igen!");
                    Console.ResetColor();
                }
                catch (Exception)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Du måste skriva på rätt form, försök igen!");
                    Console.ResetColor();
                }
            }
            return datum;
        }


        static void Villkor()
        {
          
            // De villkorna för företaget.
            Console.WriteLine("* Bokning är personlig och kan inte överlåtas.\n" +
            "* Du måste vara 20 år för att få hyra bil hos oss.\n" +
            "* Du måste visa giltigt körkort(originalhandling)när du ska hämta bilen.\n" +
            "* Bilarna måste hämtas och lämnas på samma station.\n" +
            "* Drivmedel ingår inte i priset\n" +
             "* Djur får ej medföras i bilarna.\n" + "* Max antal extraförare är 1\n" + "* Försäkring kostar 59kr per dygn.\n" + "* Fria mil kostar 79kr extra per dygn\n" + "* Man kan inte hyra en bil mer än 7 dagar, detta eftersom vi har få bilar och andra kunder ska få chans att hyra en bil.");
           
            // Här ska användaren trycka på enter så att hen går tillbaka till meny.
            Console.WriteLine("\nTryck på enter så att du kan gå tillbaka till meny");
            Console.ReadLine();

            //Efter man har tryckt på enter, så kommer villkor text att försvinna.
            Console.Clear();
            //meny ska visas igen
            Meny();
        }
    }

}



