using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuckUGenshin.Entities
{

    public class Favors
    {
        public int code { get; set; }
        public string message { get; set; }
        public int ttl { get; set; }
        public FData data { get; set; }
    }

    public class FData
    {
        public int count { get; set; }
        public List[] list { get; set; }
        public object season { get; set; }
    }

    public class List
    {
        public int id { get; set; }
        public int fid { get; set; }
        public int mid { get; set; }
        public int attr { get; set; }
        public string title { get; set; }
        public int fav_state { get; set; }
        public int media_count { get; set; }
    }
}
