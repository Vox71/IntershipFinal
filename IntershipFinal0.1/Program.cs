using System;
using System.Collections.Generic;
using System.Linq;

namespace IntershipFinal0._1
{
    public class Colony
    {
        public int NumColony { get; set; }
        public List<Queen> Queen { get; set; }
        public List<Larva> Larva { get; set; }
        public List<Worker> Workers { get; set; }
        public List<Warrior> Warriors { get; set; }
        public List<Unique> uniques { get; set; }
        public int twig { get; set; }
        public int stone { get; set; }
        public int leaf { get; set; }
        public int dew { get; set; }

        public Colony(string color, int NumColony, int Queen, int Larva, int Workers,
            int Warriors, int Uniques, int Twig, int Stone, int Leaf, int Dew)
        {
            this.Queen = new List<Queen>();
            this.Larva = new List<Larva>();
            this.Workers = new List<Worker>();
            this.Warriors = new List<Warrior>();
            uniques = new List<Unique>();

            Random rand = new Random();

            //Создание работяг
            for (int i = 0; i < Workers; i++)
            {
                switch (rand.Next(2))
                {
                    case 0:
                        switch (color)
                        {
                            case "green": this.Workers.Add(new Worker("green", NumColony, 1, 0, 0, 0, 0, 0, 1, 0, 1, 0, 1)); break;
                            case "black": this.Workers.Add(new Worker("black", NumColony, 6, 0, 2, 0, 0, 0, 1, 1, 2, 0, 1)); break;
                            case "red": this.Workers.Add(new Worker("red", NumColony, 6, 0, 2, 0, 0, 1, 0, 1, 2, 0, 1)); break;
                        }
                        break;
                    case 1:
                        switch (color)
                        {
                            case "green": this.Workers.Add(new Worker("green", NumColony, 1, 0, 4, 0, 0, 0, 0, 1, 0, 0, 2)); break;
                            case "black": this.Workers.Add(new Worker("black", NumColony, 1, 1, 4, 0, 0, 0, 1, 0, 1, 0, 2)); break;
                            case "red": this.Workers.Add(new Worker("red", NumColony, 1, 1, 3, 0, 1, 1, 1, 0, 3, 0, 2)); break;
                        }
                        break;
                }
            }

            //Создание варов
            for (int i = 0; i < Warriors; i++)
            {
                switch (rand.Next(2))
                {
                    case 0:
                        switch (color)
                        {
                            case "green": this.Warriors.Add(new Warrior("green", NumColony, 1, 0, 6, 1, 1, 1, 1)); break;
                            case "black": this.Warriors.Add(new Warrior("black", NumColony, 6, 0, 2, 3, 2, 1, 1)); break;
                            case "red": this.Warriors.Add(new Warrior("red", NumColony, 2, 0, 1, 2, 1, 1, 1)); break;
                        }
                        break;
                    case 1:
                        switch (color)
                        {
                            case "green": this.Warriors.Add(new Warrior("green", NumColony, 2, 0, 1, 4, 1, 1, 2)); break;
                            case "black": this.Warriors.Add(new Warrior("black", NumColony, 6, 0, 2, 3, 2, 1, 2)); break;
                            case "red": this.Warriors.Add(new Warrior("red", NumColony, 10, 0, 6, 4, 3, 1, 2)); break;
                        }
                        break;
                }
            }

            for (int i = 0; i < Queen; i++)
            {
                switch (color)
                {
                    case "green": this.Queen.Add(new Queen("green", NumColony, 24, 0, 6, 19, 1, 4, 2, 3, 0)); break;
                    case "black": this.Queen.Add(new Queen("black", NumColony, 25, 0, 5, 27, 2, 3, 1, 4, 0)); break;
                    case "red": this.Queen.Add(new Queen("red", NumColony, 29, 0, 9, 19, 2, 4, 2, 5, 0)); break;
                }
            }

            for (var i = 0; i < Uniques; i++)
            {
                switch (color)
                {
                    case "green": uniques.Add(new Unique("green", NumColony, 19, 2, 5, 100, 1, 1, 1, 1, 1, 0, 1)); break;
                    case "black": uniques.Add(new Unique("black", NumColony, 26, 0, 5, 0, 1, 0, 0, 0, 0, 0, 0)); break;
                    case "red": uniques.Add(new Unique("red", NumColony, 26, 0, 5, 0, 0, 0, 0, 0, 0, 0, 0)); break;
                }
            }

            for (int i = 0; i < Larva; i++)
            {
                switch (color)
                {
                    case "green": this.Larva.Add(new Larva("green", NumColony, 0, 0)); break;
                    case "black": this.Larva.Add(new Larva("black", NumColony, 0, 0)); break;
                    case "red": this.Larva.Add(new Larva("red", NumColony, 0, 0)); break;
                }
            }
            this.NumColony = NumColony;
            twig = Twig;
            stone = Stone;
            leaf = Leaf;
            dew = Dew;
        }

        internal void ShowColonyInfo()
        {
            string queenName = " ";
            switch (Queen.Last().color)
            {
                case "green": queenName = "Изабелла"; break;
                case "black": queenName = "Елизавета"; break;
                case "red": queenName = "Мария"; break;
            }
            Console.WriteLine($"-------------------------------------------" +
            $"\n Колония {Queen.Last().color}, номер колонии {Queen.Last().numOfColony}" +
            $"\n -- Королева {queenName}, кол-во личинок {Larva.Count}" +
            $"\n -- Ресурсы: в={twig}, к={stone}, л={leaf}, р={dew}" +
            $"\n -- Популяция {Workers.Count + Warriors.Count + uniques.Count}: р={Workers.Count}, в={Warriors.Count}, у={uniques.Count}, k={Queen.Count}"
            );
        }

        internal void ShowAntInfo()
        {
            switch (Queen.Last().color)
            {
                case "green":
                    Console.WriteLine($"-------------------------------------------" +
                        $"\n Колония {Queen.Last().color}, номер колонии {Queen.Last().numOfColony}" +
                        $"\n -- Королева <Агриппина> - hp=24 - def=6 - dm=19" +
                        $"\n -- <обычный> РАБОЧИЙ - hp=1 - def=0 - dodge=0 - Может взять 1 leaf" +
                        $"\n -- <обычный забывчивый> РАБОЧИЙ - hp=1 - def=0 - dpdge=0 - Может взять 1 dew - может забыть взять ресурс из кучи" +
                        $"\n -- <обычный> ВОИН - hp=1 - def=0 - dm=1 - numTargets=1 - numBits=1" +
                        $"\n -- <старший сосредоточенный> ВОИН - hp=2 - def=1 - dm=2 - numTargets=1 - numBits=1 - урон от укуса увеличен в двое" +
                        $"\n -- Особенное насекомое <трудолюбивый обычный агрессивный мифический сонный - Термит> - hp=19 - def=5 - dodge=13 - может брать ресурсы (1 ресурс: любой)"
                        );
                    break;

                case "black":
                    Console.WriteLine($"-------------------------------------------" +
                        $"\n Колония {Queen.Last().color}, номер колонии {Queen.Last().numOfColony}" +
                        $"\n -- Королева <Ольга> - hp=25 - def=5 - dm=27" +
                        $"\n -- <продвинутый> РАБОЧИЙ - hp=6 - def=2 - dodge=0 - Может взять 1 twig или leaf" +
                        $"\n -- <обычный сильный> РАБОЧИЙ - hp=1 - def=0 - dodge=0 - Может взять 1 leaf - может брать вдвое больше ресурсов" +
                        $"\n -- <продвинутый> ВОИН - hp=6 - def=2 - dm=3 - dodge=0 - numTargets=2 - numBits=1" +
                        $"\n -- <продвинутый точный> ВОИН - hp=6 - def=2 - dm=3 - dodge=2 - numTargets=2 - numBits=1" +
                        $"\n -- Особенное насекомое <трудолюбивый обычный мирный любимчик королевы - Толстоножка> - hp=26 - def=5 - dm=0 - dodge=0 - numTargets=1 - numBits=1 - может брать 1 twig"
                        );
                    break;

                case "red":
                    Console.WriteLine($"-------------------------------------------" +
                        $"\n Колония {Queen.Last().color}, номер колонии {Queen.Last().numOfColony}" +
                        $"\n -- Королева <Изабелла> - hp=29 - def=9 - dm=19" +
                        $"\n -- <продвинутый> РАБОЧИЙ - hp=6 - def=2- dodge=0 - Может взять 2 stone or dew" +
                        $"\n -- <обычный глупый> РАБОЧИЙ - hp=1 - def=0 - dpdge=1 - Может взять 1 leaf" +
                        $"\n -- <старший> ВОИН - hp=2 - def=1 - dm=2 - dodge=0 - numTargets=1 - numBits=1" +
                        $"\n -- <легендарный точный> ВОИН - hp=10 - def=6 - dm=4 - dodge=0 - numTargets=3 - numBits=1 - " +
                        $"\n -- Особенное насекомое <ленивый обычный мирный подготовленный - Пчела> - hp=26 - def=5 - dodge=0"
                        );
                    break;
            }
        }
    }
    public class StartAnt
    {
        public string color { get; protected set; }
        public int numOfColony { get; protected set; }
        public int hp { get; set; }
        public int dodge { get; set; }
        public int def { get; set; }
        public int dm { get; set; }
        public StartAnt(string Color, int NumOfColony, int Hp, int Dodge, int Def, int Dm)
        {
            color = Color;
            numOfColony = NumOfColony;
            hp = Hp;
            dodge = Dodge;
            def = Def;
            dm = Dm;
        }
    }
    public class Unique : StartAnt
    {
        public int takeTwig { get; set; }
        public int takeStone { get; set; }
        public int takeLeaf { get; set; }
        public int takeDew { get; set; }
        public int maxTaken { get; set; }
        public int takenRes { get; set; }
        public int timeToSleep { get; set; }
        public Unique(string Color, int NumOfColony, int Hp, int Dodge, int Def,
            int Dm, int TakeTwig, int TakeStone, int TakeLeaf, int TakeDew,
            int MaxTaken, int TakenRes, int TimeToSleep) : base(Color, NumOfColony, Hp, Dodge, Def, Dm)
        {
            takeTwig = TakeTwig;
            takeStone = TakeStone;
            takeLeaf = TakeLeaf;
            takeDew = TakeDew;
            maxTaken = MaxTaken;
            takenRes = TakenRes;
            timeToSleep = TimeToSleep;
        }
    }

    public class Worker : StartAnt
    {
        public int takeTwig { get; set; }
        public int takeStone { get; set; }
        public int takeLeaf { get; set; }
        public int takeDew { get; set; }
        public int maxTaken { get; set; }
        public int takenRes { get; set; }
        public int version { get; set; }
        public Worker(string Color, int NumOfColony, int Hp, int Dodge, int Def,
            int Dm, int TakeTwig, int TakeStone, int TakeLeaf, int TakeDew,
            int MaxTaken, int TakenRes, int Version) : base(Color, NumOfColony, Hp, Dodge, Def, Dm)
        {
            takeTwig = TakeTwig;
            takeStone = TakeStone;
            takeLeaf = TakeLeaf;
            takeDew = TakeDew;
            maxTaken = MaxTaken;
            takenRes = TakenRes;
            version = Version;
        }
    }
    public class Larva
    {
        public string color { get; protected set; }
        public int numOfColony { get; protected set; }
        public int allTime { get; set; }
        public int presentTime { get; set; }
        public Larva(string Color, int NumOfColony, int AllTime, int PresentTime)
        {
            color = Color;
            numOfColony = NumOfColony;
            allTime = AllTime;
            presentTime = PresentTime;
        }
    }
    public class Warrior : StartAnt
    {
        public int numTargets { get; set; }
        public int numBites { get; set; }
        public int version { get; set; }
        public Warrior(string Color, int NumOfColony, int Hp,
            int Dodge, int Def, int Dm, int NumTargets, int NumBites,
            int Version) : base(Color, NumOfColony, Hp, Dodge, Def, Dm)
        {
            numTargets = NumTargets;
            numBites = NumBites;
            version = Version;
        }
    }
    public class Queen : StartAnt
    {
        public int minDays { get; set; }
        public int maxDays { get; set; }
        public int minNewQweens { get; set; }
        public int maxNewQweens { get; set; }
        public int nowNewQweens { get; set; }
        public Queen(string Color, int NumOfColony, int Hp, int Dodge, int Def,
            int Dm, int MinDays, int MaxDays, int MinNewQweens, int MaxNewQweens,
            int NowNewQweens) : base(Color, NumOfColony, Hp, Dodge, Def, Dm)
        {
            minDays = MinDays;
            maxDays = MaxDays;
            minNewQweens = MinNewQweens;
            maxNewQweens = MaxNewQweens;
            nowNewQweens = NowNewQweens;
        }
    }
    public class Stack
    {
        public int twig { get; set; }
        public int stone { get; set; }
        public int leaf { get; set; }
        public int dew { get; set; }
        public List<Worker> workers { get; set; }
        public List<Warrior> warriors { get; set; }
        public List<Unique> uniques { get; set; }
        public Stack(int Twig, int Stone, int Leaf, int Dew)
        {
            workers = new List<Worker>();
            warriors = new List<Warrior>();
            uniques = new List<Unique>();
            twig = Twig;
            stone = Stone;
            leaf = Leaf;
            dew = Dew;
        }
    }
    public class Spider
    {
        public int timeToSpider { get; set; }
        public List<Worker> workers { get; set; }
        public List<Warrior> warriors { get; set; }
        public List<Unique> uniques { get; set; }
        public Spider(int TimeToSpider)
        {
            timeToSpider = TimeToSpider;
            workers = new List<Worker>();
            warriors = new List<Warrior>();
            uniques = new List<Unique>();
        }
    }
    public class main
    {
        static void Main(string[] args)
        {
            Random rand = new Random();

            //Начальные статы колонии
            Colony GreenColony = new Colony("green", 0, 1, 0, 15, 9, 1, 0, 0, 0, 0);
            Colony BlackColony = new Colony("black", 1, 1, 0, 18, 9, 1, 0, 0, 0, 0);
            Colony RedColony = new Colony("red", 2, 1, 0, 14, 5, 1, 0, 0, 0, 0);

            //Начальные кучки
            Stack FirstStack = new Stack(14, 19, 0, 0);
            Stack SecondStack = new Stack(49, 0, 23, 0);
            Stack ThirdStack = new Stack(36, 0, 26, 15);
            Stack FourthStack = new Stack(23, 0, 10, 33);
            Stack FifthStack = new Stack(46, 0, 0, 40);

            //Пихаю все в один лист
            List<Colony> AllColonies = new List<Colony>();
            AllColonies.Add(GreenColony);
            AllColonies.Add(BlackColony);
            AllColonies.Add(RedColony);

            //Сую кучи в мега-кучу
            List<Stack> AllStacks = new List<Stack>();
            AllStacks.Add(FirstStack);
            AllStacks.Add(SecondStack);
            AllStacks.Add(ThirdStack);
            AllStacks.Add(FourthStack);
            AllStacks.Add(FifthStack);

            List<Unique> sleepUniques = new List<Unique>();
            int Day = 0;

            StartInfo(AllColonies, AllStacks, Day);

            string read = Console.ReadLine();
            if (read == "2") { ShowInfo(AllColonies, AllStacks, Day); }
            while (Day < 11)
            {
                Expedition(AllColonies, AllStacks, sleepUniques);
                NewAnts(AllColonies);
                Console.WriteLine(
                $"\nНачать день {Day + 1} (1)" +
                $"\nПосмотреть информацию о колониях (2)" +
                $"\nПоказать информацию о муровьях конкретной колонии (3)" +
                $"\n");
                string readInDay = Console.ReadLine();
                if (readInDay == "2")
                {
                    ShowInfo(AllColonies, AllStacks, Day);
                    Console.WriteLine($"\nНачать день {Day + 1} (1)" +
                    $"\nПоказать информацию о муровьях конкретной колонии" +
                    $"\n");
                    readInDay = Console.ReadLine();
                    if (readInDay == "2")
                    {
                        Console.WriteLine($"Укажите номер конкретной колонии" +
                            $"\n");
                        int colonyNum = Convert.ToInt32(Console.ReadLine());
                        AllColonies[colonyNum].ShowAntInfo();
                        Console.WriteLine($"\nНачать день {Day + 1} (1)" +
                        $"\n");
                        Console.ReadLine();
                    }
                }
                if (readInDay == "3")
                {
                    Console.WriteLine($"Укажите номер конкретной колонии" +
                        $"\n");
                    int colonyNum = Convert.ToInt32(Console.ReadLine());
                    AllColonies[colonyNum].ShowAntInfo();
                    Console.WriteLine($"\nНачать день {Day + 1} (1)" +
                    $"\n");
                    Console.ReadLine();
                }
                Day++;
            }
            FinalInfo(AllColonies, AllStacks);
        }

        private static void ShowInfo(List<Colony> AllColonies, List<Stack> AllStackes, int Day)
        {
            Console.WriteLine(
            $"\nХАРАКТЕРИСТИКИ: КОЛОНИЙ:" +
            $"\n День = {Day}, до засухи осталось {11 - Day} дней.");
            foreach (Colony colony in AllColonies)
            {
                colony.ShowColonyInfo();
            }
        }

        private static void FinalInfo(List<Colony> AllColonies, List<Stack> AllStacks)
        {
            int max = 0; int winner = 0;
            foreach (Colony colony in AllColonies)
            {
                int sum = 0;
                sum += colony.twig + colony.dew + colony.stone + colony.leaf;
                if (sum > max) { max = sum; winner = colony.NumColony; }
            }
            Console.WriteLine($"\nПобедила колония номер {winner}, набрав {max} ресурсов");
        }

        private static void StartInfo(List<Colony> AllColonies, List<Stack> AllStacks, int Day)
        {
            Console.WriteLine("НАЧАЛЬНЫЕ ХАРАКТЕРИСТИКИ:" +
                $"\n" +
                $"\n Колония green, номер колонии 0, королева Агриппина" +
                $"\n Кол-во существ: рабочих {AllColonies[0].Workers.Count}, воинов {AllColonies[0].Warriors.Count}, уникальных юнитов {AllColonies[0].uniques.Count}" +
                $"\n -------------------------------------------" +
                $"\n Колония black, номер колонии 1, королева Ольга" +
                $"\n Кол-во существ: рабочих {AllColonies[1].Workers.Count}, воинов {AllColonies[1].Warriors.Count}, уникальных юнитов {AllColonies[1].uniques.Count}" +
                $"\n -------------------------------------------" +
                $"\n Колония red, номер колонии 2, королева Изабелла" +
                $"\n Кол-во существ: рабочих {AllColonies[2].Workers.Count}, воинов {AllColonies[2].Warriors.Count}, уникальных юнитов {AllColonies[2].uniques.Count}" +
                $"\n" +
                $"\n" +
                $"\n НАЧАЛЬНАЯ ИНФОРМАЦИЯ О КУЧАХ:" +
                $"\n Название:         -- Куча 1 -- Куча 2 -- Куча 3 -- Куча 4 -- Куча 5 --" +
                $"\n Кол-во веточек:   --   {AllStacks[0].twig}   --   {AllStacks[1].twig}   --   {AllStacks[2].twig}   --   {AllStacks[3].twig}   --   {AllStacks[4].twig}   --" +
                $"\n Кол-во камня:     --   {AllStacks[0].stone}   --    {AllStacks[1].stone}   --    {AllStacks[2].stone}   --    {AllStacks[3].stone}   --    {AllStacks[4].stone}   --" +
                $"\n Кол-во листиков:  --    {AllStacks[0].leaf}   --   {AllStacks[1].leaf}   --   {AllStacks[2].leaf}   --   {AllStacks[3].leaf}   --    {AllStacks[4].leaf}   --" +
                $"\n Кол-во росы:      --   {AllStacks[0].dew}   --   {AllStacks[1].dew}   --    {AllStacks[2].dew}   --   {AllStacks[3].dew}   --    {AllStacks[4].dew}   --" +
                $"\n" +
                $"\nНачать день {Day} (1)" +
                $"\nПосмотреть информацию о колониях (2)" +
                $"\n");
        }

        //Ролю кол-во работяг на кучах
        public static void ShortWorkersRoll(Colony colony, Stack stack)
        {
            Random rand = new Random();
            int rollingAnt = rand.Next(0, (colony.Workers.Count) / 2);
            for (int i = 0; rollingAnt > i; i++)
            {
                stack.workers.Add(colony.Workers[0]);
                colony.Workers.Remove(colony.Workers[0]);
            }
        }

        //Ролю кол-во варов на кучах 
        public static void ShortWarriorsRoll(Colony colony, Stack stack)
        {
            Random rand = new Random();
            int rollingAnt = rand.Next(0, (colony.Warriors.Count) / 2);
            for (int i = 0; rollingAnt > i; i++)
            {
                stack.warriors.Add(colony.Warriors[0]);
                colony.Warriors.Remove(colony.Warriors[0]);
            }
        }

        public static void ShortUniquesRoll(Colony colony, Stack stack)
        {
            Random rand = new Random();
            int rollingAnt = rand.Next(0, colony.uniques.Count);
            for (int i = 0; rollingAnt > i; i++)
            {
                stack.uniques.Add(colony.uniques[0]);
                colony.uniques.Remove(colony.uniques[0]);
            }
        }

        public static void TestForSleeping(Stack stack, List<Unique> sleepUniques)
        {
            for (int i = 0; i < stack.uniques.Count; i++)
            {
                switch (stack.uniques[i].timeToSleep)
                {
                    case 0: break;
                    case 1: stack.uniques[i].timeToSleep += 1; break;
                    case 2: sleepUniques.Add(stack.uniques[i]); stack.uniques.Remove(stack.uniques[i]); i--; break;
                }
            }
        }

        //Новая мультиатака
        public static void RollForNumTargets(Stack stack, Warrior warrior, ref int i)
        {
            Random rand = new Random();
            int localNumTargets = 1;
            while (warrior.numTargets > localNumTargets)
            {
                int rollTarget = rand.Next(0, 3);
                switch (rollTarget)
                {
                    case 0:
                        if (stack.workers.Count > 0)
                        {
                            int rollWorkersOnFirst2 = rand.Next(0, stack.workers.Count - 1);
                            int rollStop = 0;
                            while (stack.workers[rollWorkersOnFirst2].color == warrior.color)
                            {
                                rollWorkersOnFirst2 = rand.Next(0, stack.workers.Count - 1); rollStop++;
                                if (rollStop > 25) { return; }
                            }
                            switch (stack.workers[rollWorkersOnFirst2].dodge)
                            {
                                case 0: stack.workers.RemoveAt(rollWorkersOnFirst2); break;
                                case 1: stack.workers[rollWorkersOnFirst2].dodge -= 1; break;
                                case 2: break;
                            }
                        }
                        localNumTargets++;
                        break;
                    case 1:
                        if (stack.warriors.Count > 0)
                        {
                            int rollWarriorOnFirst = rand.Next(0, stack.warriors.Count - 1);
                            int rollStop = 0;
                            while (stack.warriors[rollWarriorOnFirst].color == warrior.color && i == rollWarriorOnFirst)
                            {
                                rollWarriorOnFirst = rand.Next(0, stack.warriors.Count - 1); rollStop++;
                                if (rollStop > 25) { return; }
                            }
                            switch (stack.warriors[rollWarriorOnFirst].dodge)
                            {
                                case 0:
                                    if (stack.warriors[rollWarriorOnFirst].def <= 0)
                                    {
                                        stack.warriors[rollWarriorOnFirst].hp -= (warrior.dm) * warrior.numBites;
                                        if (stack.warriors[rollWarriorOnFirst].hp <= 0)
                                        {
                                            stack.warriors.RemoveAt(rollWarriorOnFirst);
                                        }
                                    }
                                    else
                                    {
                                        stack.warriors[rollWarriorOnFirst].def -= (warrior.dm - 1) * warrior.numBites;
                                        stack.warriors[rollWarriorOnFirst].hp -= 1 * warrior.numBites;
                                        if (stack.warriors[rollWarriorOnFirst].hp <= 0)
                                        {
                                            stack.warriors.RemoveAt(rollWarriorOnFirst);
                                        }
                                    }
                                    break;
                                case 1:
                                    stack.warriors[rollWarriorOnFirst].dodge -= 1;
                                    break;
                                case 2: break;
                            }
                        }
                        localNumTargets++;
                        break;
                    case 2:
                        if (stack.uniques.Count > 0)
                        {
                            int rollUniqueOnFirst = rand.Next(0, stack.uniques.Count - 1);
                            int rollStop = 0;
                            while (stack.uniques[rollUniqueOnFirst].color == warrior.color)
                            {
                                rollUniqueOnFirst = rand.Next(0, stack.uniques.Count - 1); rollStop++;
                                if (rollStop > 25) { return; }
                            }
                            switch (stack.uniques[rollUniqueOnFirst].dodge)
                            {
                                case 0:
                                    if (stack.uniques[rollUniqueOnFirst].def <= 0)
                                    {
                                        stack.uniques[rollUniqueOnFirst].hp -= (warrior.dm) * warrior.numBites;
                                        if (stack.uniques[rollUniqueOnFirst].hp <= 0) { stack.uniques.RemoveAt(rollUniqueOnFirst); }
                                    }
                                    else
                                    {
                                        stack.uniques[rollUniqueOnFirst].def -= (warrior.dm - 1) * warrior.numBites;
                                        stack.uniques[rollUniqueOnFirst].hp -= 1;
                                        if (stack.uniques[rollUniqueOnFirst].hp <= 0) { stack.uniques.RemoveAt(rollUniqueOnFirst); }
                                    }
                                    break;
                                case 2: break;
                            }
                        }
                        localNumTargets++;
                        break;
                }
            }
        }

        //Ролл атаки на рабочих
        public static void RollWorkersOnFight(Stack stack, Warrior warrior, ref int i)
        {
            Random rand = new Random();
            if (stack.workers.Count > 0)
            {
                int rollWorkersOnFirst = rand.Next(0, stack.workers.Count - 1);
                int rollStop = 0;
                while (stack.workers[rollWorkersOnFirst].color == warrior.color)
                {
                    rollWorkersOnFirst = rand.Next(0, stack.workers.Count - 1); rollStop++;
                    if (rollStop > 25) { return; }
                }
                switch (stack.workers[rollWorkersOnFirst].dodge)
                {
                    case 0:
                        stack.workers.RemoveAt(rollWorkersOnFirst);
                        break;
                    case 1:
                        stack.workers[rollWorkersOnFirst].dodge -= 1;
                        break;
                }
            }
            RollForNumTargets(stack, warrior, ref i);
        }

        //Ролл атаки на войнов
        public static void RollWarriorsOnFight(Stack stack, Warrior warrior, ref int i)
        {
            Random rand = new Random();
            if (stack.warriors.Count > 0)
            {
                int rollWarriorsOnFirst = rand.Next(0, stack.warriors.Count - 1);
                int rollStop = 0;
                while (stack.warriors[rollWarriorsOnFirst].color == warrior.color && i == rollWarriorsOnFirst)
                {
                    rollWarriorsOnFirst = rand.Next(0, stack.warriors.Count - 1); rollStop++;
                    if (rollStop > 25) { return; }
                }
                switch (stack.warriors[rollWarriorsOnFirst].dodge)
                {
                    case 0:
                        if (stack.warriors[rollWarriorsOnFirst].def <= 0)
                        {
                            stack.warriors[rollWarriorsOnFirst].hp -= warrior.dm * warrior.numBites;
                            if (stack.warriors[rollWarriorsOnFirst].hp <= 0)
                            {
                                stack.warriors.RemoveAt(rollWarriorsOnFirst);
                            }
                        }
                        else
                        {
                            stack.warriors[rollWarriorsOnFirst].def -= (warrior.dm - 1) * warrior.numBites;
                            stack.warriors[rollWarriorsOnFirst].hp -= 1 * warrior.numBites;
                        }
                        break;
                    case 1:
                        stack.warriors[rollWarriorsOnFirst].dodge -= 1;
                        break;
                    case 2: break;
                }
            }
            RollForNumTargets(stack, warrior, ref i);
        }

        public static void RollUniqueOnFight(Stack stack, Warrior warrior, ref int i)
        {
            Random rand = new Random();
            if (stack.uniques.Count > 0)
            {
                int rollUniquesOnFirst = rand.Next(0, stack.uniques.Count - 1);
                int rollStop = 0;
                while (stack.uniques[rollUniquesOnFirst].color == warrior.color)
                {
                    rollUniquesOnFirst = rand.Next(0, stack.uniques.Count - 1); rollStop++;
                    if (rollStop > 25) { return; }
                }
                switch (stack.uniques[rollUniquesOnFirst].dodge)
                {
                    case 0:
                        if (stack.uniques[rollUniquesOnFirst].def <= 0)
                        {
                            stack.uniques[rollUniquesOnFirst].hp -= warrior.dm * warrior.numBites;
                            if (stack.uniques[rollUniquesOnFirst].hp <= 0) { stack.uniques.RemoveAt(rollUniquesOnFirst); }
                        }
                        else { stack.uniques[rollUniquesOnFirst].def -= (warrior.dm - 1) * warrior.numBites; stack.uniques[rollUniquesOnFirst].hp -= 1 * warrior.numBites; }
                        break;
                    case 2: break;
                }
            }
            RollForNumTargets(stack, warrior, ref i);
        }

        //Смертельная битва
        public static void Fight(Stack stack)
        {
            Random rand = new Random();
            for (int i = 0; i < stack.warriors.Count; i++)
            {
                int rollAttack = rand.Next(1, 4);

                switch (rollAttack)
                {
                    case 1: RollWorkersOnFight(stack, stack.warriors[i], ref i); break;
                    case 2: RollWarriorsOnFight(stack, stack.warriors[i], ref i); break;
                    case 3: RollUniqueOnFight(stack, stack.warriors[i], ref i); break;
                }
            }

            for (int i = 0; i < stack.uniques.Count; i++)
            {
                if (stack.uniques[i].dm > 0)
                {
                    int rollAttack = rand.Next(1, 3);
                    int rollStop = 0;

                    switch (rollAttack)
                    {
                        case 1:
                            if (stack.workers.Count > 0)
                            {
                                int rollWorkersOnSecond = rand.Next(0, stack.workers.Count - 1);
                                while (stack.workers[rollWorkersOnSecond].color != stack.uniques[i].color)
                                {
                                    rollWorkersOnSecond = rand.Next(0, stack.workers.Count - 1); rollStop++;
                                    if (rollStop > 25) { return; }
                                }
                                switch (stack.workers[rollWorkersOnSecond].dodge)
                                {
                                    case 0: stack.workers.RemoveAt(rollWorkersOnSecond); break;
                                    case 1: stack.workers[rollWorkersOnSecond].dodge -= 1; break;
                                }
                            }
                            break;
                        case 2:
                            if (stack.warriors.Count > 0)
                            {
                                int rollWarriorsOnSecond = rand.Next(0, stack.warriors.Count - 1);
                                while (stack.warriors[rollWarriorsOnSecond].color != stack.uniques[i].color)
                                {
                                    rollWarriorsOnSecond = rand.Next(0, stack.warriors.Count - 1); rollStop++;
                                    if (rollStop > 25) { return; }
                                }
                                switch (stack.warriors[rollWarriorsOnSecond].dodge)
                                {
                                    case 0:
                                        if (stack.warriors[rollWarriorsOnSecond].def <= 0)
                                        {
                                            stack.warriors[rollWarriorsOnSecond].hp -= stack.uniques[i].dm;
                                            if (stack.warriors[rollWarriorsOnSecond].hp <= 0) { stack.warriors.RemoveAt(rollWarriorsOnSecond); }
                                        }
                                        else
                                        {
                                            stack.warriors[rollWarriorsOnSecond].def -= stack.uniques[i].dm - 1;
                                            stack.warriors[rollWarriorsOnSecond].hp -= 1;
                                            if (stack.warriors[rollWarriorsOnSecond].hp <= 0) { stack.warriors.RemoveAt(rollWarriorsOnSecond); }
                                        }
                                        if (stack.uniques[i].hp <= 0) { stack.uniques.Remove(stack.uniques[i]); }
                                        break;
                                    case 1: stack.warriors[rollWarriorsOnSecond].dodge -= 1; break;
                                    case 2: break;
                                }
                            }
                            break;
                    }
                }
            }
        }

        //Сбор ресурсов
        public static void Farm(Stack stack, List<Colony> AllColonies)
        {

            foreach (Worker worker in stack.workers)
            {
                if (worker.takeTwig > 0 && stack.twig > 0)
                {
                    while (worker.takenRes < worker.takeTwig && worker.takenRes < worker.maxTaken && stack.twig > 0)
                    {
                        worker.takenRes++;
                        AllColonies[worker.numOfColony].twig++;
                        stack.twig--;
                    }
                }
                else if (worker.maxTaken > worker.takenRes && (worker.takeStone > 0 && stack.stone > 0))
                {
                    while (worker.takenRes < worker.takeStone && worker.takenRes < worker.maxTaken && stack.stone > 0)
                    {
                        worker.takenRes++;
                        AllColonies[worker.numOfColony].stone++;
                        stack.stone--;
                    }
                }
                else if (worker.maxTaken > worker.takenRes && (worker.takeLeaf > 0 && stack.leaf > 0))
                {
                    while (worker.takenRes < worker.takeLeaf && worker.takenRes < worker.maxTaken && stack.leaf > 0)
                    {
                        worker.takenRes++;
                        AllColonies[worker.numOfColony].leaf++;
                        stack.leaf--;
                    }
                }
                else if (worker.maxTaken > worker.takenRes && (worker.takeDew > 0 && stack.dew > 0))
                {
                    while (worker.takenRes < worker.takeDew && worker.takenRes < worker.maxTaken && stack.dew > 0)
                    {
                        worker.takenRes++;
                        AllColonies[worker.numOfColony].dew++;
                        stack.dew--;
                    }
                }
                worker.takenRes = 0;
            }
        }

        public static void GetBack(Stack stack, List<Colony> AllColonies)
        {
            Random rand = new Random();

            for (int i = 0; i < stack.workers.Count; i++)
            {
                AllColonies[stack.workers[i].numOfColony].Workers.Add(stack.workers[i]);
                stack.workers.Remove(stack.workers[i]);
            }

            for (int i = 0; i < stack.warriors.Count; i++)
            {
                AllColonies[stack.warriors[i].numOfColony].Warriors.Add(stack.warriors[i]);
                stack.warriors.Remove(stack.warriors[i]);
            }

            for (int i = 0; i < stack.uniques.Count; i++)
            {
                AllColonies[stack.uniques[i].numOfColony].uniques.Add(stack.uniques[i]);
                stack.uniques.Remove(stack.uniques[i]);
            }
        }

        public static void Expedition(List<Colony> AllColonies, List<Stack> Stack, List<Unique> sleepUniques)
        {
            Random rand = new Random();

            for (int i = 0; i < sleepUniques.Count; i++)
            {
                switch (sleepUniques[i].timeToSleep)
                {
                    case 1: AllColonies[0].uniques.Add(sleepUniques[i]); sleepUniques.Remove(sleepUniques[i]); break;
                    case 2: sleepUniques[i].timeToSleep -= 1; break;
                }
            }

            foreach (Colony colony in AllColonies)
            {
                int switchWorker = 0;
                while (switchWorker < 5)
                {
                    switch (switchWorker)
                    {
                        case 0:
                            ShortWorkersRoll(colony, Stack[0]);
                            ShortWarriorsRoll(colony, Stack[0]);
                            ShortUniquesRoll(colony, Stack[0]);
                            TestForSleeping(Stack[0], sleepUniques);
                            switchWorker += 1;
                            break;

                        case 1:
                            ShortWorkersRoll(colony, Stack[1]);
                            ShortWarriorsRoll(colony, Stack[1]);
                            ShortUniquesRoll(colony, Stack[1]);
                            TestForSleeping(Stack[1], sleepUniques);
                            switchWorker += 1;
                            break;

                        case 2:
                            ShortWorkersRoll(colony, Stack[2]);
                            ShortWarriorsRoll(colony, Stack[2]);
                            ShortUniquesRoll(colony, Stack[2]);
                            TestForSleeping(Stack[2], sleepUniques);
                            switchWorker += 1;
                            break;

                        case 3:
                            ShortWorkersRoll(colony, Stack[3]);
                            ShortWarriorsRoll(colony, Stack[3]);
                            ShortUniquesRoll(colony, Stack[3]);
                            TestForSleeping(Stack[3], sleepUniques);
                            switchWorker += 1;
                            break;

                        case 4:
                            while (colony.Workers.Count > 0)
                            {
                                Stack[4].workers.Add(colony.Workers[0]);
                                colony.Workers.Remove(colony.Workers[0]);
                            }
                            while (colony.Warriors.Count > 0)
                            {
                                Stack[4].warriors.Add(colony.Warriors[0]);
                                colony.Warriors.Remove(colony.Warriors[0]);
                            }
                            while (colony.uniques.Count > 0)
                            {
                                Stack[4].uniques.Add(colony.uniques[0]);
                                colony.uniques.Remove(colony.uniques[0]);
                            }
                            TestForSleeping(Stack[4], sleepUniques);
                            switchWorker += 1;
                            break;
                    }
                }
            }
            
            int fightOnExp = 1;
            while (fightOnExp < 6)
            {
                switch (fightOnExp)
                {
                    case 1: Fight(Stack[0]); fightOnExp += 1; break;
                    case 2: Fight(Stack[1]); fightOnExp += 1; break;
                    case 3: Fight(Stack[2]); fightOnExp += 1; break;
                    case 4: Fight(Stack[3]); fightOnExp += 1; break;
                    case 5: Fight(Stack[4]); fightOnExp += 1; break;
                }
            }

            int farmOnExp = 1;
            while (farmOnExp < 6)
            {
                switch (farmOnExp)
                {
                    case 1: Farm(Stack[0], AllColonies); farmOnExp += 1; break;
                    case 2: Farm(Stack[1], AllColonies); farmOnExp += 1; break;
                    case 3: Farm(Stack[2], AllColonies); farmOnExp += 1; break;
                    case 4: Farm(Stack[3], AllColonies); farmOnExp += 1; break;
                    case 5: Farm(Stack[4], AllColonies); farmOnExp += 1; break;
                }
            }

            int getBack = 1;
            while (getBack < 6)
            {
                switch (getBack)
                {
                    case 1: GetBack(Stack[0], AllColonies); getBack++; break;
                    case 2: GetBack(Stack[1], AllColonies); getBack++; break;
                    case 3: GetBack(Stack[2], AllColonies); getBack++; break;
                    case 4: GetBack(Stack[3], AllColonies); getBack++; break;
                    case 5: GetBack(Stack[4], AllColonies); getBack++; break;
                }
            }
        }
        
        public static void AddNewLarva(Colony colony)
        {
            Random rand = new Random();
            foreach (Queen queen in colony.Queen)
            {
                int rollNumLarva = rand.Next(1, 12);
                int i = 0;
                while (i < rollNumLarva)
                {
                    int rollNumDaysLarva = rand.Next(queen.minDays, queen.maxDays);
                    colony.Larva.Add(new Larva(queen.color, queen.numOfColony, rollNumDaysLarva, 0));
                    i++;
                }
            }
        }

        public static void NewAnts(List<Colony> AllColonies)
        {
            Random rand = new Random();

            for (int i = 0; i < AllColonies.Count; i++)
            {
                AddNewLarva(AllColonies[i]);
                GrownCheckLarva(AllColonies[i], AllColonies);
            }

        }

        private static void GrownCheckLarva(Colony colony, List<Colony> AllColonies)
        {
            for (int i = 0; i < colony.Larva.Count; i++)
            {
                if (colony.Larva[i].presentTime >= colony.Larva[i].allTime)
                {
                    // ролл на чела
                    CreateNewAnt(colony, colony.Larva[i], AllColonies);
                    colony.Larva.Remove(colony.Larva[i]); i--;
                }
                else { colony.Larva[i].presentTime++; }
            }
        }

        //Ролл на создание
        private static void CreateNewAnt(Colony colony, Larva larva, List<Colony> AllColonies)
        {
            Random rand = new Random();
            switch (rand.Next(1, 9))
            {
                case 1:
                    switch (larva.color)
                    {
                        case "green": colony.Workers.Add(new Worker("green", larva.numOfColony, 1, 0, 0, 0, 0, 0, 1, 0, 1, 0, 1)); break;
                        case "black": colony.Workers.Add(new Worker("black", larva.numOfColony, 6, 0, 2, 0, 0, 0, 1, 1, 2, 0, 1)); break;
                        case "red": colony.Workers.Add(new Worker("red", larva.numOfColony, 6, 0, 2, 0, 0, 1, 0, 1, 2, 0, 1)); break;
                    }
                    break;
                case 2:
                    switch (larva.color)
                    {
                        case "green": colony.Workers.Add(new Worker("green", larva.numOfColony, 1, 0, 4, 0, 0, 0, 0, 1, 0, 0, 2)); break;
                        case "black": colony.Workers.Add(new Worker("black", larva.numOfColony, 1, 1, 4, 0, 0, 0, 1, 0, 1, 0, 2)); break;
                        case "red": colony.Workers.Add(new Worker("red", larva.numOfColony, 1, 1, 3, 0, 1, 1, 1, 0, 3, 0, 2)); break;
                    }
                    break;
                case 3:
                    switch (larva.color)
                    {
                        case "green": colony.Warriors.Add(new Warrior("green", larva.numOfColony, 1, 0, 6, 1, 1, 1, 1)); break;
                        case "black": colony.Warriors.Add(new Warrior("black", larva.numOfColony, 6, 0, 2, 3, 2, 1, 1)); break;
                        case "red": colony.Warriors.Add(new Warrior("red", larva.numOfColony, 2, 0, 1, 2, 1, 1, 1)); break;
                    }
                    break;
                case 4:
                    switch (larva.color)
                    {
                        case "green": colony.Warriors.Add(new Warrior("green", larva.numOfColony, 2, 0, 1, 4, 1, 1, 2)); break;
                        case "black": colony.Warriors.Add(new Warrior("black", larva.numOfColony, 6, 0, 2, 3, 2, 1, 2)); break;
                        case "red": colony.Warriors.Add(new Warrior("red", larva.numOfColony, 10, 0, 6, 4, 3, 1, 2)); break;
                    }
                    break;
                case 5:
                    switch (larva.color)
                    {
                        case "green": colony.uniques.Add(new Unique("green", larva.numOfColony, 19, 2, 5, 100, 1, 1, 1, 1, 1, 0, 1)); break;
                        case "black": colony.uniques.Add(new Unique("black", larva.numOfColony, 26, 0, 5, 0, 1, 0, 0, 0, 0, 0, 0)); break;
                        case "red": colony.uniques.Add(new Unique("red", larva.numOfColony, 26, 0, 5, 0, 0, 0, 0, 0, 0, 0, 0)); break;
                    }
                    break;
                case 6:
                    if (colony.Queen[0].maxNewQweens > colony.Queen[0].nowNewQweens)
                    {
                        AllColonies.Add(new Colony(larva.color, AllColonies.Count, 1, 0, 12, 8, 4, 0, 0, 0, 0));
                        colony.Queen[0].nowNewQweens++;
                    }
                    break;
                case 7:
                    switch (larva.color)
                    {
                        case "green": colony.Workers.Add(new Worker("green", larva.numOfColony, 1, 0, 0, 0, 0, 0, 1, 0, 1, 0, 1)); break;
                        case "black": colony.Workers.Add(new Worker("black", larva.numOfColony, 6, 0, 2, 0, 0, 0, 1, 1, 2, 0, 1)); break;
                        case "red": colony.Workers.Add(new Worker("red", larva.numOfColony, 6, 0, 2, 0, 0, 1, 0, 1, 2, 0, 1)); break;
                    }
                    break;
                case 8:
                    switch (larva.color)
                    {
                        case "green": colony.Workers.Add(new Worker("green", larva.numOfColony, 1, 0, 4, 0, 0, 0, 0, 1, 0, 0, 2)); break;
                        case "black": colony.Workers.Add(new Worker("black", larva.numOfColony, 1, 1, 4, 0, 0, 0, 1, 0, 1, 0, 2)); break;
                        case "red": colony.Workers.Add(new Worker("red", larva.numOfColony, 1, 1, 3, 0, 1, 1, 1, 0, 3, 0, 2)); break;
                    }
                    break;
            }
        }
    }
}
