using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;



namespace GXPEngine
{
    class ReadComboFiles
    {

        public List<string> leftArrows = new List<string>();
        public List<string> middleArrows = new List<string>();
        public List<string> rightArrows = new List<string>();
        public List<string> endCombo = new List<string>();
        public ReadComboFiles(string path)
        {

            using (var rd = new StreamReader(path))
            {
                while (!rd.EndOfStream)
                {
                    var splits = rd.ReadLine().Split(',');
                    leftArrows.Add(splits[0]);
                    middleArrows.Add(splits[1]);
                    rightArrows.Add(splits[2]);
                    endCombo.Add(splits[3]);
                }
            }
            // print column1
            /*Console.WriteLine("Column 1:");
            foreach (var element in column1)
                Console.WriteLine(element);

            // print column2
            Console.WriteLine("Column 2:");
            foreach (var element in column2)
                Console.WriteLine(element);*/
        }
    }
}
