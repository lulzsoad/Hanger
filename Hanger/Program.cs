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

            
        }
        /// <summary>
        /// Returns table of words used in the game.
        /// </summary>
        /// <returns></returns>
        static string[] WordsDatabase()
        {
            string[] wordsDatabase = {"airplane", "doctor", "animal", "philosophy", "atmosphere"};
            return wordsDatabase;
        }
        /// <summary>
        /// Returns drawn hanger
        /// </summary>
        /// <returns></returns>
        static string[] Hanger()
        {
            string[] hanger = { " _______",
                                " |     |",
                                " |     O",
                                " |    /|\\",
                                " |    / \\",
                                "/|\\      "};

            return hanger;
        }
    }
}
