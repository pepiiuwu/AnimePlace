using System.Linq;
using System;
class Program
{

    static void Main(string[] args) {
        int waves = int.Parse(Console.ReadLine());

        List<int> defenses = Console.ReadLine()
            .Split(" ")
            .Select(int.Parse)
            .ToList();

        int wavesCount = 1;

        while (waves > 0)
        {
            List<int> attacks = Console.ReadLine()
             .Split(" ").Select(int.Parse).ToList();
        
    




            int currentAttack = attacks[attacks.Count - 1];
            int currentDefense = defenses[0];

            while (true)
            {


                if (waves == 0 && defenses.Count > 0)
                {
                    Console.WriteLine("The people successfully repulsed the orc's attack.");
                    Console.WriteLine($"Plates left: {string.Join(" ", defenses)}");
                    return;
                }
                else if (defenses.Count == 0 && waves != 0)
                {
                    Console.WriteLine("The orcs successfully destroyed the Gondor's defense.");
                    attacks.Reverse();
                    Console.WriteLine($"Orcs left: {string.Join(", ", attacks)}");
                    return;
                }





                if (currentDefense == 0 && defenses.Count > 0)
                {
                    defenses.RemoveAt(0);
                    if (defenses.Count == 0)
                    {
                        continue;
                    }
                    currentDefense = defenses[0];
                }
                if (attacks.Count == 0)
                {
                    waves--;
                    wavesCount++;
                    if (waves == 0)
                    {
                        continue;
                    }
                    attacks = Console.ReadLine()
                            .Split(" ")
                            .Select(int.Parse)
                            .ToList();

                    currentAttack = attacks[attacks.Count - 1];



                    if (wavesCount != 0 && wavesCount % 3 == 0)
                    {
                        int additionalDefense = int.Parse(Console.ReadLine());
                        defenses.Add(additionalDefense);
                    }
                }

                if (!(currentAttack > currentDefense))
                {
                    currentDefense -= currentAttack;
                    attacks.RemoveAt(attacks.Count - 1);
                    if (attacks.Count >= 1) {
                        currentAttack = attacks[attacks.Count - 1];
                    }

                }
                else if (currentAttack > currentDefense)
                {
                    currentAttack -= currentDefense;
                    currentDefense = 0;
                    attacks[attacks.Count - 1] = currentAttack;
                }


            }

        }

    }

}