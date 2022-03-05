using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoryGame
{
    internal class Program
    {
        public static int[] RandomNum = new int[8];
        public static string[] WordsA8 = new string[8];
        public static string[] WordsB8 = new string[8];
        public static string[] WordsA4 = new string[4];
        public static string[] WordsB4 = new string[4];
       
     
        public static string coordinates;
        public static string coordinates2;
        public static int tim = 0;
        public static int chance = 0;
        public static int term1;
        public static int term2;
        public static char char1;
        public static char char2;
        public static char logic1;
        public static char logic2;

        public static string level;
        public static string numbers;

        public static string word1A = "X" ;
        public static string word2A = "X";
        public static string word3A = "X";
        public static string word4A = "X";
        public static string word5A = "X";
        public static string word6A = "X";
        public static string word7A = "X";
        public static string word8A = "X";

        public static string word1B = "X";
        public static string word2B = "X";
        public static string word3B = "X";
        public static string word4B = "X";
        public static string word5B = "X";
        public static string word6B = "X";
        public static string word7B = "X";
        public static string word8B = "X";

        










        public static void Main()
        {


            for (int i = 0; i < 8; i++)                   //generuje cztery losowe liczby zapisane w fourRandomNumbers
            {
                Random random = new();
                int randomGenerateNumber = random.Next(1, 100);
                RandomNum[i] = randomGenerateNumber;
            }

            for (int i = 0; i < 8; i++)
            {
                WordsA8[i] = GetWord(RandomNum[i]);                             // robi array A
            }
            for (int i = 0; i < 4; i++)
            {
                WordsA4[i] = GetWord(RandomNum[i]);                             // robi array A
            }

            int[] arr = { 0, 1, 2, 3, 4, 5, 6, 7, 8 };                           //miesza nam rząd B         
            Random random2 = new();
            WordsB8 = WordsA8;
            WordsB4 = WordsA4;
            WordsB8 = WordsB8.OrderBy(x => random2.Next()).ToArray();
            WordsB4 = WordsB4.OrderBy(x => random2.Next()).ToArray();

            Console.WriteLine("Numers in order : " + String.Join(" ", RandomNum) + "\n");
            Console.WriteLine("Numers in order one: " + String.Join(" ", WordsA8));
            Console.WriteLine("Numers in order two: " + String.Join(" ", WordsB8)); Console.WriteLine(); //funkcja wypisująca wyrazy w arrayu order2
            Console.WriteLine("Numers in order A4: " + String.Join(" ", WordsA4));
            Console.WriteLine("Numers in order B4: " + String.Join(" ", WordsB4) + "\n"); //funkcja wypisująca wyrazy w arrayu order2


            Console.Write("Choose level (easy or hard): ");
            // Thread.Sleep(100);

            string level = "easy"; // Console.ReadLine();

            if (level != "easy" && level != "hard")
            {
                // Console.Clear();
                Console.WriteLine("Wrong command! :(");
            }


            


            if(level == "easy")
            {
                chance = 10;
                LoadMatrix4();




                while (true)
                {
                    coordinates = Console.ReadLine();
                    tim++;

                    switch (coordinates)
                    {
                        case "A1": word1A = WordsA4[0]; LoadMatrix4(); term1 = 0; char1 = 'A'; break;
                        case "A2": word2A = WordsA4[1]; LoadMatrix4(); term1 = 1; char1 = 'A'; break;
                        case "A3": word3A = WordsA4[2]; LoadMatrix4(); term1 = 2; char1 = 'A'; break;
                        case "A4": word4A = WordsA4[3]; LoadMatrix4(); term1 = 3; char1 = 'A'; break;
                        

                        case "B1": word1B = WordsB4[0]; LoadMatrix4(); term1 = 0; char1 = 'B'; break;
                        case "B2": word2B = WordsB4[1]; LoadMatrix4(); term1 = 1; char1 = 'B'; break;
                        case "B3": word3B = WordsB4[2]; LoadMatrix4(); term1 = 2; char1 = 'B'; break;
                        case "B4": word4B = WordsB4[3]; LoadMatrix4(); term1 = 3; char1 = 'B'; break;
                       


                    }

                         Console.WriteLine();
                         Console.WriteLine("Liczba tim: " + tim);
                         Console.WriteLine("Liczba term1: " + term1);
                         Console.WriteLine("Liczba term2: " + term2);
                         Console.WriteLine("Liczba char1: " + char1);
                       Console.WriteLine("Liczba char2: " + char2);
                    Console.ReadLine();
                    
                    while (tim == 2)
                    {
                        if ((WordsA4[term1] == WordsB4[term2])^(WordsA4[term2] == WordsB4[term1]))
                        {

                            Console.WriteLine("YOU GUESSED!");
                            Thread.Sleep(2000);
                            LoadMatrix4();

                            tim = tim - 2;
                            char1 = char2 = 'O';

                        }
                        else
                        {
                            switch (coordinates)
                            {
                                case "A1": word1A = "X"; break;
                                case "A2": word2A = "X"; break;
                                case "A3": word3A = "X"; break;
                                case "A4": word4A = "X"; break;
                              

                                case "B1": word1B = "X"; break;
                                case "B2": word2B = "X"; break;
                                case "B3": word3B = "X"; break;
                                case "B4": word4B = "X"; break;
                           

                            }
                            switch (coordinates2)
                            {
                                case "A1": word1A = "X"; break;
                                case "A2": word2A = "X"; break;
                                case "A3": word3A = "X"; break;
                                case "A4": word4A = "X"; break;
                              

                                case "B1": word1B = "X"; break;
                                case "B2": word2B = "X"; break;
                                case "B3": word3B = "X"; break;
                                case "B4": word4B = "X"; break;
                          

                            }

                            Console.WriteLine("YOU LOSE ONE CHANCE!");
                            chance--;
                            Thread.Sleep(2000);
                            LoadMatrix4();


                            //   Console.ReadLine();
                            tim = tim - 2;
                        }


                    }
                    coordinates2 = coordinates;
                    term2 = term1;
                    char2 = char1;

                    if (chance == 0)
                    {
                        Console.Clear();
                        Console.Write("YOU LOSE! \n Do you want to play again? \n Enter yes or no: ");
                        Console.ReadLine();
                    }

                    if ((word1A != "X")&& (word2A != "X") && (word3A != "X") && (word4A != "X") && (word1B != "X") && (word2B != "X") && (word3B != "X") && (word4B != "X") )
                    {
                        Console.Clear();
                        Console.Write("YOU WIN! \n Do you want to play again? \n Enter yes or no: ");
                        Console.ReadLine();
                    }


                }





            }


            if (level == "hard")
            {
                chance = 15;
                LoadMatrix8();
              
                


                while (true)
                {           coordinates = Console.ReadLine();
                            tim++;
                    if ((coordinates[0] != 'A') && (coordinates[0] != 'B'))
                    {
                        Console.WriteLine("Wrong coordinates!");
                        Thread.Sleep(1000);
                        LoadMatrix8();
                    }

                    switch (coordinates)
                            {
                                case "A1": word1A = WordsA8[0]; LoadMatrix8(); term1 = 0; char1 = 'A'; break;
                                case "A2": word2A = WordsA8[1]; LoadMatrix8(); term1 = 1; char1 = 'A'; break;
                                case "A3": word3A = WordsA8[2]; LoadMatrix8(); term1 = 2; char1 = 'A'; break;
                                case "A4": word4A = WordsA8[3]; LoadMatrix8(); term1 = 3; char1 = 'A'; break;
                                case "A5": word5A = WordsA8[4]; LoadMatrix8(); term1 = 4; char1 = 'A'; break;
                                case "A6": word6A = WordsA8[5]; LoadMatrix8(); term1 = 5; char1 = 'A'; break;
                                case "A7": word7A = WordsA8[6]; LoadMatrix8(); term1 = 6; char1 = 'A'; break;
                                case "A8": word8A = WordsA8[7]; LoadMatrix8(); term1 = 7; char1 = 'A'; break;

                                case "B1": word1B = WordsB8[0]; LoadMatrix8(); term1 = 0; char1 = 'B'; break;
                                case "B2": word2B = WordsB8[1]; LoadMatrix8(); term1 = 1; char1 = 'B'; break;
                                case "B3": word3B = WordsB8[2]; LoadMatrix8(); term1 = 2; char1 = 'B'; break;
                                case "B4": word4B = WordsB8[3]; LoadMatrix8(); term1 = 3; char1 = 'B'; break;
                                case "B5": word5B = WordsB8[4]; LoadMatrix8(); term1 = 4; char1 = 'B'; break;
                                case "B6": word6B = WordsB8[5]; LoadMatrix8(); term1 = 5; char1 = 'B'; break;
                                case "B7": word7B = WordsB8[6]; LoadMatrix8(); term1 = 6; char1 = 'B'; break;
                                case "B8": word8B = WordsB8[7]; LoadMatrix8(); term1 = 7; char1 = 'B'; break;

                            
                            }
                    
                       /*     Console.WriteLine();
                            Console.WriteLine("Liczba tim: " + tim);
                            Console.WriteLine("Liczba term1: " + term1);
                            Console.WriteLine("Liczba term2: " + term2);
                            Console.WriteLine("Liczba char1: " + char1);
                          Console.WriteLine("Liczba char2: " + char2);
                        */ 
                    while (tim == 2)
                    {
                        if ((WordsA8[term1] == WordsB8[term2]) ^ (WordsA8[term2] == WordsB8[term1]))
                        {

                            Console.WriteLine("YOU GUESSED!");
                            Thread.Sleep(1000);
                            LoadMatrix8();

                            tim = tim - 2;
                            char1 = char2 = 'O';

                        }
                        else
                        {
                            switch (coordinates)
                            {
                                case "A1": word1A = "X"; break;
                                case "A2": word2A = "X"; break;
                                case "A3": word3A = "X"; break;
                                case "A4": word4A = "X"; break;
                                case "A5": word5A = "X"; break;
                                case "A6": word6A = "X"; break;
                                case "A7": word7A = "X"; break;
                                case "A8": word8A = "X"; break;

                                case "B1": word1B = "X"; break;
                                case "B2": word2B = "X"; break;
                                case "B3": word3B = "X"; break;
                                case "B4": word4B = "X"; break;
                                case "B5": word5B = "X"; break;
                                case "B6": word6B = "X"; break;
                                case "B7": word7B = "X"; break;
                                case "B8": word8B = "X"; break;

                            }
                            switch(coordinates2)
                            {
                                case "A1": word1A = "X"; break;
                                case "A2": word2A = "X"; break;
                                case "A3": word3A = "X"; break;
                                case "A4": word4A = "X"; break;
                                case "A5": word5A = "X"; break;
                                case "A6": word6A = "X"; break;
                                case "A7": word7A = "X"; break;
                                case "A8": word8A = "X"; break;

                                case "B1": word1B = "X"; break;
                                case "B2": word2B = "X"; break;
                                case "B3": word3B = "X"; break;
                                case "B4": word4B = "X"; break; 
                                case "B5": word5B = "X"; break;
                                case "B6": word6B = "X"; break;
                                case "B7": word7B = "X"; break;
                                case "B8": word8B = "X"; break;

                            }

                            Console.WriteLine("YOU LOST ONE CHANCE!");
                            chance--;
                            Thread.Sleep(2000);
                            LoadMatrix8();

                            
                         //   Console.ReadLine();
                            tim = tim - 2;
                        }

                        
                    }
                    coordinates2 = coordinates;
                    term2 = term1;
                    char2 = char1;

                    if (chance == 0)
                    {
                        Console.Clear();
                        Console.Write("YOU LOSE! \n Do you want to play again? \n Enter yes or no: ");
                    }

                
                }
           
            
            
            
            
            }









        } // main

/* 
       
*/

        public static void LoadMatrix8()
        {
            Console.Clear(); 
            Console.WriteLine("--------------------------");
            Console.WriteLine("     Level: hard");
            Console.WriteLine("     Guess chances: " + chance + " \n");
            Console.WriteLine("       1 2 3 4 5 6 7 8");
            Console.WriteLine("     A " + word1A + " " + word2A + " " + word3A + " " + word4A + " " + word5A + " " + word6A + " " + word7A + " " + word8A);
            Console.WriteLine("     B " + word1B + " " + word2B + " " + word3B + " " + word4B + " " + word5B + " " + word6B + " " + word7B + " " + word8B);
            Console.WriteLine("--------------------------");
            Console.Write("Enter coordinate: ");

            
            //   coordinates = Console.ReadLine();

        }

        public static void LoadMatrix4()
        {
            Console.Clear();
            Console.WriteLine("--------------------------");
            Console.WriteLine("     Level: easy");
            Console.WriteLine("     Guess chances: " + chance + " \n");
            Console.WriteLine("       1 2 3 4 ");
            Console.WriteLine("     A " + word1A + " " + word2A + " " + word3A + " " + word4A);
            Console.WriteLine("     B " + word1B + " " + word2B + " " + word3B + " " + word4B);
            Console.WriteLine("--------------------------");
            Console.Write("Enter coordinate: ");

        }


        static string GetWord(int wordNumber)
        {
            string Words = "Words.txt";
            string[] lines = File.ReadAllLines(Words);

            return lines[wordNumber];

        }









    } // end class Program
}