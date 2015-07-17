using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testris
{
    class Program
    {
        static void Main(string[] args)
        {

            // ********** Game Matrix and Bricks
            #region Matrix
            string M = "m ";
            string R = "r ";
            string O = "o ";
            string C = "c ";
            string B = "b ";
            string G = "g ";
            string Y = "y ";
            string dot = ". ";

            string[,] cyanI = new string[,] {{dot, dot, dot, dot},
                                            {C, C, C, C},
                                            {dot, dot, dot, dot},
                                            {dot, dot, dot, dot}};
            string[,] yellowO = new string[,] {{Y,Y},
                                            {Y,Y}};
            string[,] redZ = new string[,] {{R, R, dot},
                                            {dot, R, R},
                                            {dot, dot, dot}};
            string[,] greenS = new string[,] {{dot, G, G},
                                            {G, G, dot},
                                            {dot, dot, dot}};
            string[,] blueJ = new string[,] {{B, dot, dot},
                                            {B, B, B},
                                            {dot, dot, dot}};
            string[,] orangeL = new string[,] {{dot, dot, O},
                                                {O, O, O}};
            string[,] magentaT = new string[,] {{dot, M, dot},
                                                {M, M, M},
                                                {dot, dot, dot}};
            
            
            
            string[,] activeTetra = new string[,] {{"","","",""},
                                                   {"","","",""},
                                                   {"","","",""},
                                                   {"","","",""}};

            string[,] arr1 = new string[,]{
                                {dot, dot ,dot ,dot ,dot ,dot ,dot, dot, dot, dot},//0
                                {dot, dot ,dot ,dot ,dot ,dot ,dot, dot, dot, dot},
                                {dot, dot ,dot ,dot ,dot ,dot ,dot, dot, dot, dot},
                                {dot, dot ,dot ,dot ,dot ,dot ,dot, dot, dot, dot},//3
                                {dot, dot ,dot ,dot ,dot ,dot ,dot, dot, dot, dot},
                                {dot, dot ,dot ,dot ,dot ,dot ,dot, dot, dot, dot},
                                {dot, dot ,dot ,dot ,dot ,dot ,dot, dot, dot, dot},//6
                                {dot, dot ,dot ,dot ,dot ,dot ,dot, dot, dot, dot},
                                {dot, dot ,dot ,dot ,dot ,dot ,dot, dot, dot, dot},
                                {dot, dot ,dot ,dot ,dot ,dot ,dot, dot, dot, dot},//9
                                {dot, dot ,dot ,dot ,dot ,dot ,dot, dot, dot, dot},
                                {dot, dot ,dot ,dot ,dot ,dot ,dot, dot, dot, dot},
                                {dot, dot ,dot ,dot ,dot ,dot ,dot, dot, dot, dot},//12
                                {dot, dot ,dot ,dot ,dot ,dot ,dot, dot, dot, dot},
                                {dot, dot ,dot ,dot ,dot ,dot ,dot, dot, dot, dot},
                                {dot, dot ,dot ,dot ,dot ,dot ,dot, dot, dot, dot},//15
                                {dot, dot ,dot ,dot ,dot ,dot ,dot, dot, dot, dot},
                                {dot, dot ,dot ,dot ,dot ,dot ,dot, dot, dot, dot},
                                {dot, dot ,dot ,dot ,dot ,dot ,dot, dot, dot, dot},//18
                                {dot, dot ,dot ,dot ,dot ,dot ,dot, dot, dot, dot},
                                {dot, dot ,dot ,dot ,dot ,dot ,dot, dot, dot, dot},
                                {dot, dot ,dot ,dot ,dot ,dot ,dot, dot, dot, dot} //21
                            };

            
            int[,] grid = new int[10, 22];
            var colLength = grid.GetLength(0);
            var rowLength = grid.GetLength(1);
            #endregion

            // ************ Game Stats ***************
            int pointScored = 0;
            int clearedLines = 0;

            // ************ Logic Variables ****************
            bool outLoop = false;
            string inputCommand = "0";
            bool outputMatrix = true;
            bool onSimulation = false;

            // ************* Given Matrix Variables *************
            List<String> givenMatrix = new List<String>();

            // ************* Active Tetra ******************
            int activeRow = 0;
            int activeRowLength = 0;
            int activeCollumnLength = 0;

            

            while (true)
            {
                // ********** Input ****************
                if ((inputCommand != "q") && (inputCommand != "p") && (inputCommand != "g")
                    && (inputCommand != "c") && (inputCommand != "?n") && (inputCommand != "s")
                    && (inputCommand != "l") && (inputCommand != "t"))
                {
                    inputCommand = Console.ReadLine();
                }

                // ***************** Logic ******************
                #region p
                if (inputCommand == "p" || outLoop == true)
                {
                    int row = 0;

                    if (inputCommand == "p")
                        outLoop = true;
                    while (outLoop)
                    {
                        
                        if (row < rowLength && outLoop == true)
                        {
                            if (arr1[row, 0] != dot && arr1[row, 1] != dot 
                                && arr1[row, 2] != dot && arr1[row, 3] != dot
                                && arr1[row, 4] != dot && arr1[row, 5] != dot 
                                && arr1[row, 6] != dot && arr1[row, 7] != dot 
                                && arr1[row, 8] != dot && arr1[row, 9] != dot && onSimulation)
                            {
                                for (int count = 0; count < 10; count++ )
                                    arr1[row, count] = dot;
                                pointScored += 100;
                                clearedLines += 1;
                            }

                            row = outputCurrent(arr1, row, arr1.GetLength(1));

                            if (row >= 22)
                                outLoop = false;
                        }
                        else
                        {
                            outLoop = false;

                            // -----------------
                            inputCommand = Reset(inputCommand);
                        }
                            
                    }
                    inputCommand = "0";
                }
                #endregion

                #region q
                else if (inputCommand == "q")
                {   // **************** Quit Game ***************
                    return;
                }
                #endregion

                #region g
                else if (inputCommand == "g")
                {   // ************ Given Matrix ***************
                    int num = 0;
                    
                    // ** After g is input, fill list with the given variable and go back to start
                    while (num < 22)
                    {
                        givenMatrix.Add(Console.ReadLine());
                        num++;
                    }
                    
                    // ********** Matrix Output loop ***************
                        
                    if (givenMatrix.Count > 0 && outputMatrix == true)
                    {
                        int row = 0;
                        foreach (string s in givenMatrix)
                        {
                            //Console.Write(s);
                            string[] splitLine = new string[22];
                            int collumn = 0;
                            splitLine = s.Split(' ');
                            foreach (string sl in splitLine)
                                {
                                    switch (sl)
                                    {
                                        case ".":
                                            arr1[row, collumn] = dot;
                                            break;
                                        case "m":
                                            arr1[row, collumn] = M;
                                            break;
                                        case "r":
                                            arr1[row, collumn] = R;
                                            break;
                                        case "o":
                                            arr1[row, collumn] = O;
                                            break;
                                        case "c":
                                            arr1[row, collumn] = C;
                                            break;
                                        case "b":
                                            arr1[row, collumn] = B;
                                            break;
                                        case "g":
                                            arr1[row, collumn] = G;
                                            break;
                                        case "y":
                                            arr1[row, collumn] = Y;
                                            break;   
                                    }
                                    collumn++;
                                }
                            row++;
                        }
                        givenMatrix.RemoveRange(0,22);
                        outputMatrix = false;
                        }


                    // -----------------
                    inputCommand = Reset(inputCommand);

                }
                #endregion

                else if (inputCommand == "s")
                {
                    onSimulation = true;

                    // -----------------
                    inputCommand = Reset(inputCommand);
                }


                #region Selection
                else if (inputCommand == "I")
                {
                    activeTetra = cyanI;
                    activeRowLength = cyanI.GetLength(0);
                    activeCollumnLength = cyanI.GetLength(1);

                    // -----------------
                    inputCommand = Reset(inputCommand);
                }
                else if (inputCommand == "O")
                {
                    activeTetra = yellowO;
                    activeRowLength = yellowO.GetLength(0);
                    activeCollumnLength = yellowO.GetLength(1);

                    // -----------------
                    inputCommand = Reset(inputCommand);
                }
                else if (inputCommand == "Z")
                {
                    activeTetra = redZ;
                    activeRowLength = redZ.GetLength(0);
                    activeCollumnLength = redZ.GetLength(1);
                    // -----------------
                    inputCommand = Reset(inputCommand);
                }
                else if (inputCommand == "J")
                {
                    activeTetra = blueJ;
                    activeRowLength = blueJ.GetLength(0);
                    activeCollumnLength = blueJ.GetLength(1);

                    // -----------------
                    inputCommand = Reset(inputCommand);
                }
                else if (inputCommand == "S")
                {
                    activeTetra = greenS;
                    activeRowLength = greenS.GetLength(0);
                    activeCollumnLength = greenS.GetLength(1);

                    // -----------------
                    inputCommand = Reset(inputCommand);
                }
                else if (inputCommand == "L")
                {
                    activeTetra = orangeL;
                    activeRowLength = orangeL.GetLength(0);
                    activeCollumnLength = orangeL.GetLength(1);

                    // -----------------
                    inputCommand = Reset(inputCommand);
                }
                else if (inputCommand == "M")
                {
                    activeTetra = magentaT;
                    activeRowLength = magentaT.GetLength(0);
                    activeCollumnLength = magentaT.GetLength(1);

                    // -----------------
                    inputCommand = Reset(inputCommand);
                }
                #endregion


                else if (inputCommand == "t")
                {
                    while (activeRow < activeRowLength)
                    {
                        outputCurrent(activeTetra, activeRow, activeCollumnLength);
                        activeRow++;
                    }
                    // -----------------
                    inputCommand = Reset(inputCommand);
                }
                else if (inputCommand == "c")
                {   
                    Clear(arr1, dot, rowLength, colLength);
                    Clear(activeTetra, dot, 4, 4);

                    // -----------------
                    inputCommand = Reset(inputCommand);
                }
                else if (inputCommand == "?s")
                {   // ** Show Score **
                    Console.WriteLine(Convert.ToString(pointScored));

                    // -----------------
                    inputCommand = Reset(inputCommand);
                }
                else if (inputCommand == "?n")
                {   // ** Show lines cleared **
                    Console.WriteLine(Convert.ToString(clearedLines));

                    // -----------------
                    inputCommand = Reset(inputCommand);
                }
            }
        }
        public static string Reset(string c)
        {
            // *** Reset Input and Output loop ***
            
            c = "0";
            return c;
        }

        public static void Clear(string[,] array, string d, int row, int col)
        {
            // ********* Clear Matrix ********************

            for (int cr = 0; cr < row; cr++)
            {   // Loops through all rows
                for (int cc = 0; cc < col; cc++)
                {   // Loops through all collumns and clears them
                    array[cr, cc] = d;
                }
            }
        }

        public static int outputCurrent(string[,] array, int i, int n2)
        {
            for (int n = 0; n < n2; n++ )
            {
                Console.Write(array[i, n]);
            }
            
            /*
            Console.Write(array[i, 0]);
            Console.Write(array[i, 1]);
            Console.Write(array[i, 2]);
            Console.Write(array[i, 3]);
            Console.Write(array[i, 4]);
            Console.Write(array[i, 5]);
            Console.Write(array[i, 6]);
            Console.Write(array[i, 7]);
            Console.Write(array[i, 8]);
            Console.Write(array[i, 9]);*/
            Console.Write("\n");
            i++;
            return i;
        }
    }
}
