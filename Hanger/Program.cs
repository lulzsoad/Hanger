using System;

namespace Hanger
{
    class Program
    {
        /// <summary>
        /// Source code
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            string[] words = WordsDatabase();
            string[] hanger = Hanger();

            Console.WriteLine("Welcome to HANGER! type 'START' to start a game or 'X' to exit");

            while (true)
            {
                string command = Console.ReadLine();

                if (command.ToLower() == "start")
                {
                    Console.Clear();

                    Random rand = new Random();
                    string word = words[rand.Next(0, words.Length-1)];      // draws a word from words database
                    char[] coveredWord = new char[word.Length];             // drawed word covered with '-' char.
                    int numberOfChars = word.Length;                        // Number of chars in drawed word
                    int numberOfMistakes = hanger.Length;                   // Number of maximum mistakes that player can do
                    for (int i = 0; i < word.Length; i++)                   // Coverin covered word with '-' chars
                        coveredWord[i] = '-';
                    char guess;                                             // char that player guess
                    bool bCharGuessed;
                    short mistakesDone = 0;
                    bool bGameOver = false;
                    bool bArgument = false;

                    while(true)
                    {
                        if (bArgument)
                            Argument();

                        Console.WriteLine("Guess your word!\n");
                        bCharGuessed = false;

                        for (int i = 0; i < word.Length; i++)
                            Console.Write(coveredWord[i]);

                        Console.WriteLine();
                        
                        if(mistakesDone > 0)
                        {
                            for(int i = 0; i < mistakesDone; i++)
                            {
                                Console.WriteLine(hanger[i]);
                            }
                        }

                        if(mistakesDone == numberOfMistakes)
                        {
                            Console.Clear();
                            Console.WriteLine("You lost the game!");

                            for (int i = 0; i < hanger.Length; i++)
                            {
                                Console.WriteLine(hanger[i]);
                            }

                            bGameOver = true;
                        }


                        try
                        {
                            guess = Convert.ToChar(Console.ReadLine());

                            bArgument = false;
                            bGameOver = true;

                            for (int i = 0; i < word.Length; i++)
                            {
                                if (word[i] == guess)
                                {
                                    coveredWord[i] = guess;
                                    bCharGuessed = true;
                                }
                                if (coveredWord[i] == '-')
                                    bGameOver = false;
                            }

                            if (!bCharGuessed)
                            {
                                mistakesDone++;
                            }

                        }
                        catch
                        {
                            bArgument = true;
                        }

                        if (bGameOver)
                        {
                            Console.Clear();
                            Console.WriteLine($"Word: {word}\nType 'START' to play again or 'X' to exit");
                            break;
                        }

                        Console.Clear();
                    }
                }
                else if (command.ToLower() == "x")
                {
                    
                }
                else
                {
                    Console.WriteLine("Command unknown.");
                }

            }

            /// <summary>
            /// Returns table of words used in the game.
            /// </summary>
            /// <returns></returns>
            static string[] WordsDatabase()
            {
                string[] wordsDatabase = {  "airplane", "doctor", "animal", "philosophy", "atmosphere", "chips", "station", "coronavirus",
                                            "sauce", "alphabet", "beautiful", "chess", "division", "elephant", "famous", "graphic", "hilarious",
                                            "iphone", "jellybean", "key", "leophard", "manufacture", "nationality", "operation", "predict",
                                            "reaggae", "stone", "triangle", "umbrella", "wallet", "yellow", "zombie", "fatemehgorjizadeh"};
                return wordsDatabase;
            }
            /// <summary>
            /// Returns drawn hanger
            /// </summary>
            /// <returns></returns>
            string[] Hanger()
            {
                string[] hanger = { " _______",
                                " |     |",
                                " |     O",
                                " |    /|\\",
                                " |    / \\",
                                "/|\\      "};

                return hanger;
            }
            
            static void Argument()
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("You can use characters only!");
                Console.ForegroundColor = ConsoleColor.White;
            }

        }
    }
}
