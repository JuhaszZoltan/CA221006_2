namespace CA221006_2
{
    internal class Program
    {
        static private string[] fishes = { "ponty", "keszeg", "harcsa", "kárász", "busa", "aranyhal", "kráken" };

        static void Main()
        {
            //Fish f = new Fish();
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