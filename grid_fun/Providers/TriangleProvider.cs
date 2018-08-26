using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using grid_fun.Models;

namespace grid_fun.Providers
{
    public class TriangleProvider
    {
        enum Rows
        {
            A,
            B,
            C,
            D,
            E,
            F
        }

        public static Dictionary<string, List<int[]>> TriangleDict = new Dictionary<string, List<int[]>>();

        static TriangleProvider()
        {
            if(TriangleDict.Count.Equals(0)){
                int[] columns = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
                int x = 0;
                int y = 0;
                int columnNumber = 1;

                //Create triangle grid

                foreach( Rows row in Enum.GetValues(typeof(Rows)))
                {
                    int rowNumber = (int)row;
                    foreach(int column in columns)
                    {
                        if(column == 0)
                        {
                            Triangle startingTriangle = new Triangle
                            {
                                Id = row + columnNumber.ToString(),
                                Coord1 = new int[] { x, y },
                                Coord2 = new int[] { x, y += 10 },
                                Coord3 = new int[] { x += 10, y }
                            };

                            AddTriangleToDictionary(startingTriangle);
                            columnNumber++;
                        }
                        else if (column % 2 != 0)
                        {
                            Triangle oddTriangleColumn = new Triangle
                            {
                                Id = row + columnNumber.ToString(),
                                Coord1 = new int[] { x -= 10, y -= 10 },
                                Coord2 = new int[] { x += 10, y },
                                Coord3 = new int[] { x, y += 10 }
                            };

                            AddTriangleToDictionary(oddTriangleColumn);
                            columnNumber++;
                        }
                        else if (column % 2 == 0)
                        {
                            Triangle evenTriangleColumn = new Triangle
                            {
                                Id = row + columnNumber.ToString(),
                                Coord1 = new int[] { x, y -= 10 },
                                Coord2 = new int[] { x, y += 10 },
                                Coord3 = new int[] { x += 10, y }
                            };

                            AddTriangleToDictionary(evenTriangleColumn);
                            columnNumber++;
                        }
                    }

                    x = 0;
                    y = 0 + (rowNumber += 1) * 10;
                    columnNumber = 1;
                }
            }
        }

        private static object AddTriangleToDictionary(Triangle newTriangle)
        {
            //Adding triangle items to Dictionary
            TriangleDict.Add(newTriangle.Id, new List<int[]>()
            {
                new int[] {newTriangle.Coord1[0], newTriangle.Coord1[1]},
                new int[] {newTriangle.Coord2[0], newTriangle.Coord2[1]},
                new int[] {newTriangle.Coord3[0], newTriangle.Coord3[1]}
            });

            return JsonConvert.SerializeObject(TriangleDict);
        }

        public static object GetAllTriangles()
        {
            return JsonConvert.SerializeObject(TriangleDict);
        }

        public static object GetTriangleById(string userId)
        {
            if(TriangleDict.ContainsKey(userId))
            {
                return JsonConvert.SerializeObject(TriangleDict[userId]);
            } 
            return null;
        }

        public static object GetTriangleByCoords(List<int[]> coords)
        {
            foreach (KeyValuePair<string, List<int[]>> pair in TriangleDict)
            {
                var testpair1 = pair.Value[0];
                var testcoord1 = coords[0];
                var testpair2 = pair.Value[1];
                var testcoord2 = coords[1]; 
                var testpair3 = pair.Value[2];
                var testcoord3 = coords[2]; 

                if((testpair1[0] == testcoord1[0]) && (testpair1[1] == testcoord1[1]) && (testpair2[0] == testcoord2[0]) && (testpair2[1] == testcoord2[1]) && (testpair3[0] == testcoord3[0]) && (testpair3[1] == testcoord3[1]))
                {
                    return JsonConvert.SerializeObject(pair);
                }
            }
            return null;
        }
    }
}
