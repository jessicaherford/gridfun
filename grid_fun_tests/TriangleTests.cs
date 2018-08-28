using System;
using System.Collections.Generic;
using grid_fun.Providers;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace grid_fun_tests
{
    public class TriangleTests
    {
        [Fact]
        public void TestGetTriangleById()
        {
            var result = TriangleProvider.GetTriangleById("A1");

            Assert.Contains((string)result, "[[0,0],[0,10],[10,10]]");
        }

        [Fact]
        public void TestGetTriangleByCoords()
        {
            List<int[]> coords = new List<int[]> {};
            int[] coord1 = new int[] { 50, 50};
            coords.Add(coord1);
            int[] coord2 = new int[] { 60, 50 };
            coords.Add(coord2);
            int[] coord3 = new int[] { 60, 60 };
            coords.Add(coord3);

            var result = TriangleProvider.GetTriangleByCoords(coords);

            string keyValue = @"{""Key"":""F12"",""Value"":[[50,50],[60,50],[60,60]]}";
            Assert.Equal(result, keyValue);
        }
    }
}
