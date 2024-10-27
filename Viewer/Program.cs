// Copyright (c) 2024 Nuno Fachada
// Distributed under the MIT License (See accompanying file LICENSE_CODE or copy
// at http://opensource.org/licenses/MIT)

using System;
using System.Collections.Generic;
using System.IO;

namespace Viewer
{
    public class Program
    {

        private static void Main(string[] args)
        {
            IDictionary<string, char> terrains = new Dictionary<string, char>()
            {
                { "desert",  '░' },
                { "plains",  '▒'},
                { "hills",   '▚'},
                { "mountain",'█'},
                { "water",   '≋'},
            };

            using StreamReader stream = File.OpenText(args[0]);
            string line;
            (int rows, int cols)? size = null;
            int read = 0;
            while ((line = stream.ReadLine()) != null)
            {
                line = line.Trim();
                if (line.Length > 0 && line[0] != '#')
                {
                    string[] strSplit = line.Split();
                    if (!size.HasValue)
                    {
                        size = (int.Parse(strSplit[0]), int.Parse(strSplit[1]));
                    }
                    else
                    {
                        Console.Write(terrains[strSplit[0]]);
                        read++;
                        if (read % size.Value.cols == 0)
                            Console.WriteLine();
                    }
                }
            }
            Console.WriteLine();
            foreach (KeyValuePair<string, char> terrain in terrains)
            {
                Console.WriteLine("{0} - {1}", terrain.Value, terrain.Key);
            }
            Console.WriteLine();

        }
    }
}
