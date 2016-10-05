using System;
using System.Collections.Generic;
using System.Linq;

namespace BFWork{
    /* By GorkyR */
    public struct Path
    {
        public Path(List<List<char>> a, int[] b)
        {
            this.charArrayList = a;
            this.sequenceArray = b;
        }
        public List<List<char>> charArrayList;
        public int[] sequenceArray;
    }

    public class StringPathfinder {

        public static Path GeneratePaths(string input, int threshold)
        {
            var pathList = new List<List<char>>();

            int stringLength = input.Length;
            pathList.Add(new List<char> { input[0] });

            int[] locationArray = new int[stringLength];

            for (int i = 1; i < stringLength; i++)
            {
                int currentChar = Convert.ToInt32(input[i]);
                int distance = threshold;
                int index = 0;
                bool found = false;

                for (int j = 0; j < pathList.Count; j++)
                {
                    int lastChar = Convert.ToInt32(pathList[j].Last());
                    int curDistance = Math.Abs(currentChar - lastChar);
                    if (curDistance < distance)
                    {
                        found = true;
                        distance = curDistance;
                        index = j;
                    }
                }

                if (!found)
                {
                    pathList.Add(new List<char> { input[i] });
                    locationArray[i] = pathList.Count - 1;
                }
                else
                {
                    pathList[index].Add(input[i]);
                    locationArray[i] = index;
                }
            }

            return new Path(pathList, locationArray);
        }

        static void Main(String[] args){

            Console.Write("\nInput string to generate path: ");

            string outputString = Console.ReadLine();

            int threshold = 10;

            if (args.Length > 0){
                int newthreshold;
                threshold = Int32.TryParse(args[0], out newthreshold) ? newthreshold : 10;
            }

            var Path = GeneratePaths(outputString, threshold);

            Console.WriteLine("\nGenerated paths: {0}\n", Path.charArrayList.Count);

            foreach(var path in Path.charArrayList){
                Console.Write("{0} -> \t[", (int)(Convert.ToInt32(path.First()) / 10) * 10 );
                for (int i = 0; i < path.Count-1; i++)
                    Console.Write("\"{0}\", ", path[i]);
                Console.Write("\"{0}\"]\n", path.Last());
            }
        }

    }
}