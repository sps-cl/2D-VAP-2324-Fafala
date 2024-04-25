using System; // Importuje knihovnu System pro práci s konzolí
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Slovnik slovnik = new Slovnik(); // Vytvoření instance třídy Slovnik

        while (true) // Neustálá smyčka která běží dokud není program ukončen
        {
            string prikaz = Console.ReadLine(); // Čtení vstupního řádku z konzole

            if (prikaz.StartsWith("Pridat:")) // Pokud vstupní řádek začíná "Pridat:"
            {
                string slovo = prikaz.Substring(7); // Získání slova bez "Pridat:"
                slovnik.PridatSlovo(slovo); // Zavolání metody PridatSlovo s novým slovem
            }
            else if (prikaz == "Zpet") // Pokud vstupní řádek je "Zpet"
            {
                slovnik.Zpet(); // Zavolání metody Zpet pro přesun na minulé slovo
            }
            else if (prikaz == "Vpred") // Pokud vstupní řádek je "Vpred"
            {
                slovnik.Vpred(); // Zavolání metody Vpred pro přesun na další slovo
            }
            else // Pokud vstupní příkaz není rozpoznán
            {
                slovnik.NeznamyPrikaz();
            }
        }
    }
}

class Slovnik
{
    private List<string> slova; // Seznam pro ukládání slov
    private int aktualniIndex; // Index aktuálního slova

    public Slovnik() // Konstruktor třídy Slovnik
    {
        slova = new List<string>(); // Prohlídnutí seznamu slov
        aktualniIndex = -1; // Inicializace indexu na -1
    }

    public void PridatSlovo(string slovo) // Metoda pro přidání nového slova
    {
        slova.Add(slovo); // Přidání slova do seznamu slov
        aktualniIndex = slova.Count - 1; // Nastavení indexu na poslední přidané slovo
        Console.WriteLine(slovo); // Výpis přidaného slova na konzoli
    }

    public void Zpet() // Metoda pro přesun na předchozí slovo
    {
        if (aktualniIndex > 0) // Pokud není aktuální slovo první v seznamu
        {
            aktualniIndex--; // Snížení indexu o 1 pro získání předchozího slova
            Console.WriteLine(slova[aktualniIndex]); // Výpis předchozího slova na konzoli
        }
        else // Pokud je aktuální slovo první v seznamu
        {
            Console.WriteLine(slova[0]); // Výpis prvního slova na konzoli
        }
    }

    public void Vpred() // Metoda pro přesun na následující slovo
    {
        if (aktualniIndex < slova.Count - 1) // Pokud není aktuální slovo poslední v seznamu
        {
            aktualniIndex++; // Zvýšení indexu o 1 pro získání následujícího slova
            Console.WriteLine(slova[aktualniIndex]); // Výpis následujícího slova na konzoli
        }
        else // Pokud je aktuální slovo poslední v seznamu
        {
            Console.WriteLine(slova[slova.Count - 1]); // Výpis posledního slova na konzoli
        }
    }

    public void NeznamyPrikaz() // Metoda pro zobrazení chybové zprávy pro neznámý příkaz
    {
        Console.WriteLine("Neznamy prikaz"); // Výpis chybové zprávy na konzoli
    }
}