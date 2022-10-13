namespace CA221006_2
{
    internal class Program
    {
        private static string[] fishes = { "ponty", "keszeg", "harcsa", "kárász", "busa", "aranyhal", "kráken" };
        private static Random rnd = new();
        public static List<Fish> fishList = new();

        static void Main()
        {
            InitRandomFishList(100);
            //GetAllFishInfo();
            ExercisesBefore();
            Simulation(100);

            Console.ReadKey(false);
        }

        private static void Simulation(int rounds)
        {
            using StreamWriter log = new(@"..\..\..\src\simulation.log");

            for (int i = 0; i < rounds; i++)
            {
                int x, y;
                do
                {
                    x = rnd.Next(fishList.Count);
                    y = rnd.Next(fishList.Count);
                } while (x == y);

                if (fishList[x].Predator != fishList[y].Predator)
                {
                    log.WriteLine($"{i + 1,3}. kör [{DateTime.Now.Ticks}]:");
                    Fish p, h;
                    if (fishList[x].Predator)
                    {
                        p = fishList[x];
                        h = fishList[y];
                    }
                    else
                    {
                        p = fishList[y];
                        h = fishList[x];
                    }

                    log.WriteLine($"\tragadozó:  {p.GetFishInfo()}");
                    log.WriteLine($"\tnövényevő: {h.GetFishInfo()}");

                    if (h.SwimBotm >= p.SwimTop && p.SwimBotm >= h.SwimTop)
                    {
                        if (rnd.Next(100) < 30)
                        {
                            if (p.Weight * 1.1f > 40f)
                                p.Weight = 40f;
                            else p.Weight *= 1.1f;
                            fishList.Remove(h);
                            log.WriteLine("\ta ragadozó megette a növényevőt");
                        }
                        else log.WriteLine("\tnincs kedve megenni");
                    }
                    else log.WriteLine("\tnem tudnak beúszni egymás sávjába");


                }
                //else log.WriteLine($"\tmindkét hal azonos étrenden van");


            }
        }

        private static void ExercisesBefore()
        {
            int nop = fishList.Count(f => f.Predator);
            Console.WriteLine($"Ragadozók száma: {nop} db");
            Console.WriteLine($"Növényevők száma: {fishList.Count - nop} db");
            float bfw = fishList.Max(f => f.Weight);
            Console.WriteLine($"Legnagyobb súlyú hal súlya: {bfw} Kg");
            int m11s = fishList.Count(f => f.SwimTop <= 110 && f.SwimBotm >= 110);
            Console.WriteLine($"1.1m-re merülni képes halak száma: {m11s} db");
        }

        private static void GetAllFishInfo()
        {
            foreach (var f in fishList)
            {
                Console.ForegroundColor = f.Predator
                    ? ConsoleColor.Red
                    : ConsoleColor.Green;
                Console.WriteLine(f.GetFishInfo());
            }
            Console.ResetColor();
        }

        private static void InitRandomFishList(int pieces)
        {
            for (int i = 0; i < pieces; i++)
            {
                fishList.Add(new Fish(
                    weight: rnd.Next(1, 81) / 2f,
                    predator: rnd.Next(100) < 10,
                    swimTop: rnd.Next(401),
                    swimDepth: rnd.Next(10, 401),
                    species: fishes[rnd.Next(fishes.Length)]));
            }
        }

        private static void ElvisOperator()
        {
            // <condition> ? <code if TRUE> : <code if FALSE>
            //<type> <variable> = <condition> ? <value if TRUE> : <value if FALSE>

            string szin = "zöld";
            Console.WriteLine(szin == "lila" ? "a kabát színe lila" : "a kabát színe NEM lila");

            //if (szin == "lila")
            //{
            //    Console.WriteLine("a kabát színe lila");
            //}
            //else
            //{
            //    Console.WriteLine("a kabát színe NEM lila");
            //}


            Console.Write("szeretsz élni? ");
            bool valasz = Console.ReadLine() == "nem" ? false : true;

            //bool valasz;
            //string valaszString = Console.ReadLine();
            //if (valaszString == "nem")
            //{
            //    valasz = false;
            //}
            //else
            //{
            //    valasz = true;
            //}
            //Console.WriteLine($"valasz értéke: {valasz}");

        }
        private static void Test()
        {
            #region tesztek

            #region üres konstruktoros kezdőérték adás
            //Fish f = new()
            //{
            //    Weight = 10f,
            //};
            #endregion

            Fish f = new(
                weight: 25f,
                predator: true,
                swimTop: 10,
                swimDepth: 10,
                species: "Keszeg");

            f.Weight -= .1f;
            //f.Predator = false;

            Console.WriteLine($"A {(f.Predator ? "ragadozó" : "növényevő")} hal súlya {f.Weight:00.00} Kg");
            #endregion
        }

        
    }
}