using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using grid_fun.Providers;

namespace grid_fun.Controllers
{
    [Route("api/[controller]")]
    public class TriangleController : ControllerBase
    {
        // GET: api/triangles
        [HttpGet]
        public object Get()
        {
            return TriangleProvider.GetAllTriangles();
        }


        // Get: api/triangles/byId?=A1
        [HttpGet("byId")]
        public object Get(string id)
        {
            return TriangleProvider.GetTriangleById(id);
        }
    
        // Get: api/triangles/byCoords?coord1=0&coord2=0&coord3=0&coord4=10&coord5=0&coord6=10
        [HttpGet("byCoords")]
        public object Get([FromQuery] int coord1, int coord2, int coord3, int coord4, int coord5, int coord6)
        {
            int[] coords1 = { coord1, coord2 };
            int[] coords2 = { coord3, coord4 };
            int[] coords3 = { coord5, coord6 };

            List<int[]> coords = new List<int[]>(){ coords1, coords2, coords3 };

            return TriangleProvider.GetTriangleByCoords(coords);
        }
    }
}
