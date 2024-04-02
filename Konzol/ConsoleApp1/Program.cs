using System;
using System.Linq; 

namespace ConsoleApp // Vytváříme prostor s názvem ConsoleApp
{
    class Program // Vytváříme novou třídu s názvem Program
    {
        static void Main(string[] args) // Vytváříme vstupní metodu Main s parametrem args
        {
            while (true) // Dokud platí opakuj..
            {
                Console.WriteLine("Zadej sekvenci čísel:"); // Vypíšeme zprávu abychom zadali sekvenci čísel
                string input = Console.ReadLine(); // Načteme vstup od uživatele
                string[] numbers = input.Split(','); // Rozdělíme vstup podle čárky a uložíme do pole čísel

                int[] parsedNumbers; // Deklarujeme pole pro celá čísla

                try 
                {
                    parsedNumbers = numbers.Select(int.Parse).ToArray();  
                }
                catch (FormatException) // Pokud se vyskytne chyba při parsování
                {
                    Console.WriteLine("Některý z vstupů není celé číslo. Zadejte prosím znovu."); // Vypíšeme zprávu o chybě
                    continue; 
                }

                int min = parsedNumbers.Min(); // Nalezneme nejmenší číslo v poli
                int max = parsedNumbers.Max(); // Nalezneme největší číslo v poli
                int longestAscendingInterval = GetLongestAscendingInterval(parsedNumbers); // Spočítáme délku nejdelšího intervalu

                Console.WriteLine($"Nejmenší číslo je {min}."); // Vypíšeme nejmenší číslo
                Console.WriteLine($"Největší číslo je {max}."); // Vypíšeme největší číslo
                Console.WriteLine($"Délka nejdelšího vzestupného intervalu je {longestAscendingInterval}."); // Vypíšeme délku nejdelšího intervalu

                Console.WriteLine("Chcete pokračovat? (ano/ne)"); // Zeptáme se jestli chce uživatel pokračovat
                string choice = Console.ReadLine(); // Načteme odpověď od uživatele
                if (choice.ToLower() != "ano") // Pokud odpověď není "ano" (ignorujeme velká nebo malá písmena)
                    break; 
            }
        }

        static int GetLongestAscendingInterval(int[] numbers) // Metoda pro získání délky nejdelšího vzestupného intervalu
        {
            int longestInterval = 0; // najdeme proměnnou pro nejdelší interval
            int currentInterval = 1; // najdeme proměnnou pro aktuální interval

            for (int i = 1; i < numbers.Length; i++) // Projdeme všechna čísla v poli
            {
                if (numbers[i] > numbers[i - 1]) // Pokud je aktuální číslo větší než předchozí
                    currentInterval++; // projedeme momentální délku aktuálního intervalu
                else // Jinak
                {
                    if (currentInterval > longestInterval) // Pokud délka aktuálního intervalu je větší než délka nejdelšího nalezeného intervalu
                        longestInterval = currentInterval; // Aktualizujeme délku nejdelšího intervalu
                    currentInterval = 1; // Resetujeme délku aktuálního intervalu
                }
            }

            if (currentInterval > longestInterval) // Pokud délka posledního intervalu je větší než délka nejdelšího nalezeného intervalu
                longestInterval = currentInterval; // Aktualizujeme délku nejdelšího intervalu

            return longestInterval; // Vracíme délku nejdelšího intervalu
        }
    }
}
