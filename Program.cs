using System;
using System.Threading;

namespace Hangman
{
    class Game
    {
        private static int live = 3;
        public void StartGame()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("WELCOME TO HANGMAN\n");
        }
        public static void SetLive(int l)
        {
            live = l;
        }
        public static int GetLive()
        {
            return live;
        }
        public static void WinArt()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(" ÛÛÛÛÛ ÛÛÛÛÛ                        ÛÛÛÛÛ   ÛÛÛ   ÛÛÛÛÛ                     ÛÛÛ ÛÛÛ     ");
            Console.WriteLine("°°ÛÛÛ °°ÛÛÛ                        °°ÛÛÛ   °ÛÛÛ  °°ÛÛÛ                     °ÛÛÛ°ÛÛÛ     ");
            Console.WriteLine(" °°ÛÛÛ ÛÛÛ    ÛÛÛÛÛÛ  ÛÛÛÛÛ ÛÛÛÛ    °ÛÛÛ   °ÛÛÛ   °ÛÛÛ   ÛÛÛÛÛÛ  ÛÛÛÛÛÛÛÛ  °ÛÛÛ°ÛÛÛ     ");
            Console.WriteLine("  °°ÛÛÛÛÛ    ÛÛÛ°°ÛÛÛ°°ÛÛÛ °ÛÛÛ     °ÛÛÛ   °ÛÛÛ   °ÛÛÛ  ÛÛÛ°°ÛÛÛ°°ÛÛÛ°°ÛÛÛ °ÛÛÛ°ÛÛÛ     ");
            Console.WriteLine("   °°ÛÛÛ    °ÛÛÛ °ÛÛÛ °ÛÛÛ °ÛÛÛ     °°ÛÛÛ  ÛÛÛÛÛ  ÛÛÛ  °ÛÛÛ °ÛÛÛ °ÛÛÛ °ÛÛÛ °ÛÛÛ°ÛÛÛ     ");
            Console.WriteLine("    °ÛÛÛ    °ÛÛÛ °ÛÛÛ °ÛÛÛ °ÛÛÛ      °°°ÛÛÛÛÛ°ÛÛÛÛÛ°   °ÛÛÛ °ÛÛÛ °ÛÛÛ °ÛÛÛ °°° °°°      ");
            Console.WriteLine("    ÛÛÛÛÛ   °°ÛÛÛÛÛÛ  °°ÛÛÛÛÛÛÛÛ       °°ÛÛÛ °°ÛÛÛ     °°ÛÛÛÛÛÛ  ÛÛÛÛ ÛÛÛÛÛ ÛÛÛ ÛÛÛ     ");
            Console.WriteLine("    °°°°°     °°°°°°    °°°°°°°°         °°°   °°°       °°°°°°  °°°° °°°°° °°° °°°     ");
            Console.ResetColor();
        }
    }
    class Country
    {
        private readonly string[] country = { "Russia", "Antarctica", "Canada", "Australia", "India" };
        //get random string from array
        public string GetCountry()
        {
            Random random = new Random();
            int index = random.Next(0, country.Length);
            string str = country[index];
            return str;
        }
    }
    class City
    {
        private readonly string[] city = { "Tokyo", "Delhi", "Shanghai", "Mexico", "Cairo" };
        //get random string from array
        public string GetCity()
        {
            Random random = new Random();
            int index = random.Next(0, city.Length);
            string str = city[index];
            return str;
        }
    }
    class Flower
    {
        private readonly string[] flower = { "Lily", "Holly", "Jasmine", "Daisy", "Poppy" };
        //get random string from array
        public string GetFlower()
        {
            Random random = new Random();
            int index = random.Next(0, flower.Length);
            string str = flower[index];
            return str;
        }
    }
    class Fruit
    {
        private readonly string[] fruit = { "Apple", "Blueberry", "Cherry", "Coconut", "Date" };
        //get random string from array
        public string GetFruit()
        {
            Random random = new Random();
            int index = random.Next(0, fruit.Length);
            string str = fruit[index];
            return str;
        }
    }
    class MainClass
    {
        public static void Main(string[] args)
        {
            bool flag = true, f = false;
            int count, i, j, k, m, n;
            string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            Random random = new Random();
            Game g = new Game();
            g.StartGame();
            Console.WriteLine("Press 'Enter' to start");
            Console.ReadLine();
            Console.Clear();
            while (flag)
            {
                Game.SetLive(3);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Clear();
                Console.WriteLine("Choose your subject:\n1. Country\n2. City\n3. Flower\n4. Fruit\n5. Exit");
                int choice = Convert.ToInt32(Console.ReadLine());
                Console.Clear();
                switch (choice)
                {
                    case 1:
                        count = 0;
                        Country c = new Country();
                        string str = c.GetCountry().ToUpper(); //uppercase the string
                        int len = str.Length + str.Length; //Length of hints letters array
                        char[] temp = new char[str.Length]; //guessing string
                        char[] temp2 = new char[len]; //hints letter string
                        for (i = 0; i < str.Length; i++)
                        {
                            temp[i] = '_';
                        }
                        for (i = 0; i < len; i++)
                        {
                            if (i < str.Length)
                            {
                                temp2[i] = str[i];
                            }
                            else
                            {
                                temp2[i] = chars[random.Next(chars.Length)];
                            }
                        }
                        //randomize the hints array
                        n = temp2.Length;
                        while (n > 1)
                        {
                            n--;
                            k = random.Next(n + 1);
                            var value = temp2[k];
                            temp2[k] = temp2[n];
                            temp2[n] = value;
                        }
                        while (Game.GetLive() > 0)
                        {
                            f = false;
                            Console.WriteLine("Guess the Word:\n{0}", string.Join(" ", temp));
                            if (count == str.Length)
                            {
                                break;
                            }
                            Console.WriteLine("Letters:\n{0}", string.Join(" ", temp2));
                            string s = Console.ReadLine();
                            s = s.ToUpper();
                            char ch = Convert.ToChar(s);
                            //check whether the character is contains in the hints array
                            if (Array.Exists(temp2, element => element == ch) == true)
                            {
                                //check whether the character is contains in the guessing string
                                for (j = 0; j < str.Length; j++)
                                {
                                    if ((ch == str[j]) && (temp[j] == '_'))
                                    {
                                        temp[j] = ch;
                                        count++;
                                        f = true;
                                        break;
                                    }
                                }
                                //eleminate the character from the hints letter array
                                for (m = 0; m < temp2.Length; m++)
                                {
                                    if (temp2[m] == ch)
                                    {
                                        temp2[m] = '_';
                                        break;
                                    }
                                }
                                if (f == false)
                                {
                                    Game.SetLive(Game.GetLive() - 1);
                                    Console.WriteLine("Lost 1 live\nCurrent Live = {0}", Game.GetLive());
                                }
                            }
                            else
                            {
                                Console.WriteLine("Wrong Input");
                            }
                        }
                        if ((count >= str.Length) && (Game.GetLive() != 0))
                        {
                            Console.WriteLine("Perfect Guess\n");
                            Game.WinArt();
                        }
                        else
                        {
                            Console.WriteLine("Gussing Word was {0}", str);
                            Console.WriteLine("Game Over");
                            Thread.Sleep(500);
                        }
                        Thread.Sleep(1500);
                        break;
                    case 2: count = 0;
                        City cty = new City();
                        str = cty.GetCity().ToUpper(); //uppercase the string
                        len = str.Length + str.Length; //Length of hints letters array
                        temp = new char[str.Length]; //guessing string
                        temp2 = new char[len]; //hints string
                        for (i = 0; i < str.Length; i++)
                        {
                            temp[i] = '_';
                        }
                        for (i = 0; i < len; i++)
                        {
                            if (i < str.Length)
                            {
                                temp2[i] = str[i];
                            }
                            else
                            {
                                temp2[i] = chars[random.Next(chars.Length)];
                            }
                        }
                        //randomize the hints array
                        n = temp2.Length;
                        while (n > 1)
                        {
                            n--;
                            k = random.Next(n + 1);
                            var value = temp2[k];
                            temp2[k] = temp2[n];
                            temp2[n] = value;
                        }
                        while (Game.GetLive() > 0)
                        {
                            f = false;
                            Console.WriteLine("Guess the Word:\n{0}", string.Join(" ", temp));
                            if (count == str.Length)
                            {
                                break;
                            }
                            Console.WriteLine("Letters:\n{0}", string.Join(" ", temp2));
                            string s = Console.ReadLine();
                            s = s.ToUpper();
                            char ch = Convert.ToChar(s);
                            if (Array.Exists(temp2, element => element == ch) == true)
                            {
                                //check whether the character is contains in the guessing string
                                for (j = 0; j < str.Length; j++)
                                {
                                    if ((ch == str[j]) && (temp[j] == '_'))
                                    {
                                        temp[j] = ch;
                                        count++;
                                        f = true;
                                        break;
                                    }
                                }
                                //eleminate the character from the hints letters array
                                for (m = 0; m < temp2.Length; m++)
                                {
                                    if (temp2[m] == ch)
                                    {
                                        temp2[m] = '_';
                                        break;
                                    }
                                }
                                if (f == false)
                                {
                                    Game.SetLive(Game.GetLive() - 1);
                                    Console.WriteLine("Lost 1 live\nCurrent Live = {0}", Game.GetLive());
                                }
                            }
                            else
                            {
                                Console.WriteLine("Wrong Input");
                            }
                        }
                        if ((count >= str.Length) && (Game.GetLive() != 0))
                        {
                            Console.WriteLine("Perfect Guess\n");
                            Game.WinArt();
                        }
                        else
                        {
                            Console.WriteLine("Gussing Word was {0}", str);
                            Console.WriteLine("Game Over");
                            Thread.Sleep(500);
                        }
                        Thread.Sleep(1500);
                        break;
                    case 3: count = 0;
                        Flower fl = new Flower();
                        str = fl.GetFlower().ToUpper(); //uppercase 
                        len = str.Length + str.Length; //Length of hints letters array
                        temp = new char[str.Length]; //guessing string
                        temp2 = new char[len]; //hints letter string
                        for (i = 0; i < str.Length; i++)
                        {
                            temp[i] = '_';
                        }
                        for (i = 0; i < len; i++)
                        {
                            if (i < str.Length)
                            {
                                temp2[i] = str[i];
                            }
                            else
                            {
                                temp2[i] = chars[random.Next(chars.Length)];
                            }
                        }
                        //randomize the hints array
                        n = temp2.Length;
                        while (n > 1)
                        {
                            n--;
                            k = random.Next(n + 1);
                            var value = temp2[k];
                            temp2[k] = temp2[n];
                            temp2[n] = value;
                        }
                        while (Game.GetLive() > 0)
                        {
                            f = false;
                            Console.WriteLine("Guess the Word:\n{0}", string.Join(" ", temp));
                            if (count == str.Length)
                            {
                                break;
                            }
                            Console.WriteLine("Letters:\n{0}", string.Join(" ", temp2));
                            string s = Console.ReadLine();
                            s = s.ToUpper();
                            char ch = Convert.ToChar(s);
                            if (Array.Exists(temp2, element => element == ch) == true)
                            {
                                //check whether the character is contains in the guessing string
                                for (j = 0; j < str.Length; j++)
                                {
                                    if ((ch == str[j]) && (temp[j] == '_'))
                                    {
                                        temp[j] = ch;
                                        count++;
                                        f = true;
                                        break;
                                    }
                                }
                                //eleminate the character from the hints letters array
                                for (m = 0; m < temp2.Length; m++)
                                {
                                    if (temp2[m] == ch)
                                    {
                                        temp2[m] = '_';
                                        break;
                                    }
                                }
                                if (f == false)
                                {
                                    Game.SetLive(Game.GetLive() - 1);
                                    Console.WriteLine("Lost 1 live\nCurrent Live = {0}", Game.GetLive());
                                }
                            }
                            else
                            {
                                Console.WriteLine("Wrong Input");
                            }
                        }
                        if ((count >= str.Length) && (Game.GetLive() != 0))
                        {
                            Console.WriteLine("Perfect Guess\n");
                            Game.WinArt();
                        }
                        else
                        {
                            Console.WriteLine("Gussing Word was {0}", str);
                            Console.WriteLine("Game Over");
                            Thread.Sleep(500);
                        }
                        Thread.Sleep(1500);
                        break;
                    case 4: count = 0;
                        Fruit fr = new Fruit();
                        str = fr.GetFruit().ToUpper(); //uppercase array
                        len = str.Length + str.Length; //Length of hints letters array
                        temp = new char[str.Length]; //guessing string
                        temp2 = new char[len]; //hints letter string
                        for (i = 0; i < str.Length; i++)
                        {
                            temp[i] = '_';
                        }
                        for (i = 0; i < len; i++)
                        {
                            if (i < str.Length)
                            {
                                temp2[i] = str[i];
                            }
                            else
                            {
                                temp2[i] = chars[random.Next(chars.Length)];
                            }
                        }
                        //randomize the hints array
                        n = temp2.Length;
                        while (n > 1)
                        {
                            n--;
                            k = random.Next(n + 1);
                            var value = temp2[k];
                            temp2[k] = temp2[n];
                            temp2[n] = value;
                        }
                        while (Game.GetLive() > 0)
                        {
                            f = false;
                            Console.WriteLine("Guess the Word:\n{0}", string.Join(" ", temp));
                            if (count == str.Length)
                            {
                                break;
                            }
                            Console.WriteLine("Letters:\n{0}", string.Join(" ", temp2));
                            string s = Console.ReadLine();
                            s = s.ToUpper();
                            char ch = Convert.ToChar(s);
                            if (Array.Exists(temp2, element => element == ch) == true)
                            {
                                //check whether the character is contains in the guessing string
                                for (j = 0; j < str.Length; j++)
                                {
                                    if ((ch == str[j]) && (temp[j] == '_'))
                                    {
                                        temp[j] = ch;
                                        count++;
                                        f = true;
                                        break;
                                    }
                                }
                                //eleminate the character from the hints letters array
                                for (m = 0; m < temp2.Length; m++)
                                {
                                    if (temp2[m] == ch)
                                    {
                                        temp2[m] = '_';
                                        break;
                                    }
                                }
                                if (f == false)
                                {
                                    Game.SetLive(Game.GetLive() - 1);
                                    Console.WriteLine("Lost 1 live\nCurrent Live = {0}", Game.GetLive());
                                }
                            }
                            else
                            {
                                Console.WriteLine("Wrong Input");
                            }
                        }
                        if ((count >= str.Length) && (Game.GetLive() != 0))
                        {
                            Console.WriteLine("Perfect Guess\n");
                            Game.WinArt();
                        }
                        else
                        {
                            Console.WriteLine("Gussing Word was {0}", str);
                            Console.WriteLine("Game Over");
                            Thread.Sleep(500);
                        }
                        Thread.Sleep(1500);
                        break;
                    case 5:
                        flag = false;
                        break;
                    default: Console.WriteLine("Wrong Input");
                        Thread.Sleep(1500);
                        break;
                }
            }
        }
    }
}