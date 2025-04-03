using System;
using System.Collections.Generic;
using System.IO;

namespace ProjGenspil
{
    public class DataHandler
    {
        public string VariantFilePath { get; set; }
        public string CopyFilePath { get; set; }

        public DataHandler(string variantFilePath, string copyFilePath)
        {
            VariantFilePath = variantFilePath;
            CopyFilePath = copyFilePath;
        }

        public void SaveVariantsToFile(List<BoardGameVariant> variants)
        {
            using (StreamWriter sw = new StreamWriter(VariantFilePath))
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

            using (StreamReader sr = new StreamReader(CopyFilePath))
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
