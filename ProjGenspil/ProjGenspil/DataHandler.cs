using System;
using System.Collections.Generic;
using System.IO;

namespace ProjGenspil
{
    public class DataHandler
    {
        public string FilePath { get; set; }

        public DataHandler(string filePath)
        {
            FilePath = filePath;
        }

        public void SaveVariantsToFile(List<BoardGameVariant> variants)
        {
            using (StreamWriter sw = new StreamWriter(FilePath))
            {
                foreach (var variant in variants)
                {
                    foreach (var copy in variant.BoardGameCopies)
                    {
                        sw.WriteLine(copy.ToString());
                    }
                }
            }
        }

        public List<BoardGameCopy> LoadBoardGameCopyFromFile()
        {
            List<BoardGameCopy> copies = new List<BoardGameCopy>();

            using (StreamReader sr = new StreamReader(FilePath))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    if (!string.IsNullOrEmpty(line))
                    {
                        copies.Add(BoardGameCopy.FromString(line));
                    }
                }
            }
            return copies;
        }

        //public List<BoardGameVariant> LoadVariantsFromFile()
        //{
        //    List<BoardGameVariant> variants = new List<BoardGameVariant>();
        //    if (File.Exists(FilePath))
        //    {
        //        using (StreamReader sr = new StreamReader(FilePath))
        //        {
        //            string line;
        //            while ((line = sr.ReadLine()) != null)
        //            {
        //                BoardGameCopy copy = BoardGameCopy.FromString(line);
        //                BoardGameVariant variant = new BoardGameVariant
        //                {
        //                    GameName = copy.BoardGameVariant.GameName,
        //                    GameVariant = copy.BoardGameVariant.GameVariant,
        //                    BoardGameCopies = new List<BoardGameCopy> { copy }
        //                };
        //                variants.Add(variant);
        //            }
        //        }
        //    }
        //    return variants;
        //}
    }
}
