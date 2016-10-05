using System;
using System.Collections.Generic;
using System.Linq;

namespace BFWork {
    /* By GorkyR */
    class StringGenerator {

        static string GetShiftString(int by){
            if (by == 0)
                return "";
            else if (by > 0)
                return new string('>', by);
            else
                return new string('<', -by);
        }

        static string GetIncrementString(int by){
            if (by == 0)
                return "";
            else if (by > 0)
                return new string('+', by);
            else
                return new string('-', -by);
        }

        public static string BrainFuckGenerator(string input, int threshold)
        {
            string finalCode = "++++++++++[";

            var Path = StringPathfinder.GeneratePaths(input, threshold);

            var states = new int[Path.charArrayList.Count];

            for (int i = 0; i < Path.charArrayList.Count; i++)
            {
                int c = Convert.ToInt32(Path.charArrayList[i].First()) / 10;
                finalCode += ">" + GetIncrementString(c);
                states[i] = c * 10;
            }
            finalCode += GetShiftString(-Path.charArrayList.Count) + "-]";

            int currentPointer = -1;
            for (int i = 0; i < input.Length; i++)
            {
                int nextPointer = Path.sequenceArray[i];
                int nextValue = Convert.ToInt32(input[i]);

                finalCode += GetShiftString(nextPointer - currentPointer);
                finalCode += GetIncrementString(nextValue - states[Path.sequenceArray[i]]) + ".";

                states[Path.sequenceArray[i]] = nextValue;
                currentPointer = nextPointer;
            }/**/

            return finalCode;
        }

        [STAThread]
        static void Main(String[] args)
        {
            string inputString;
            if (args.Length > 0) {
                inputString = args[0];
            }
            else{
                Console.Write("\nInput line to convert: ");
                inputString = Console.ReadLine();
            }

            int threshold = 0;
            int tmptLength = int.MaxValue;
            for (int i = 1; i <= 20; i++){
                int tmp = BrainFuckGenerator(inputString, i).Length;
                if (tmp < tmptLength){
                    tmptLength = tmp;
                    threshold = i;
                }
            }

            string outputBF = BrainFuckGenerator(inputString, threshold);
            System.Windows.Forms.Clipboard.SetText(outputBF);
            Console.WriteLine("\n{0}", outputBF);
            Console.WriteLine("\nOriginal length: {0} bytes\tOutput length: {1} bytes\t\tRatio: {2}", inputString.Length, outputBF.Length, (double) outputBF.Length / inputString.Length);
        }
    }
}