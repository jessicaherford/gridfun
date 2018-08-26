using System;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace grid_fun.Models
{
    [DataContract]
    public class Triangle
    {
        [DataMember]
        public string Id { get; set; }
        [DataMember]
        public int[] Coord1 { get; set; }
        [DataMember]
        public int[] Coord2 { get; set; }
        [DataMember]
        public int[] Coord3 { get; set; }

        public Triangle() { }


        public Triangle(string id, int[] coord1, int[] coord2, int[] coord3)
        {
            Id = id;
            Coord1 = coord1;
            Coord2 = coord2;
            Coord3 = coord3;
        }

        public string ToJsonString(){
            return JsonConvert.SerializeObject(this);
        }
    }
}
