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

        private static int height = 10;
        private static int width = 10;

        public static Dictionary<string, List<int[]>> TriangleDict = new Dictionary<string, List<int[]>>();

        static TriangleProvider()
        {
                int[] columns = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 };

            //Create triangle grid
            foreach (Rows row in Enum.GetValues(typeof(Rows)))
            {
                int rowNumber = (int)row;
                for (int col = 0; col < columns.Length; col++)
                {
                    var key = row + (columns[col] + 1).ToString();
                    var coordinates = new List<int[]>();

                    var xCoordList = GetXCoordValues(col, rowNumber);
                    var yCoordList = GetYCoordValues(col, rowNumber);

                    // making 3 coords for each Triangle
                    for (int i = 0; i < 3; i++){
                        Coordinate coordinate = new Coordinate { X = xCoordList[i], Y = yCoordList[i] };
                        int[] coord = { coordinate.X, coordinate.Y };
                        coordinates.Add(coord);
                    }
                    TriangleDict.Add(key, coordinates);
                }
            }
        }

        public static List<int> GetXCoordValues(int col, int row)
        {
            if(col%2 == 0)
            {
                return new List<int> { col * width / 2, col * width / 2, col * width / 2 + width };
            }
            return new List<int> { (col - 1) * width / 2, (col - 1) * width / 2 + width, (col - 1) * width / 2 + width};
        }

        public static List<int> GetYCoordValues(int col, int row)
        {
            if (col % 2 == 0)
            {
                return new List<int> { row * height, row * height + height, row * height + height };
            }
            return new List<int> { row * height, row * height, row * height + height };
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
