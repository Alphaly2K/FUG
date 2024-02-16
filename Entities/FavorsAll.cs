namespace FuckUGenshin.Entities
{

    public class FavorsAll
    {
        public int code { get; set; }
        public string? message { get; set; }
        public int ttl { get; set; }
        public Datum[]? data { get; set; }
    }

    public class Datum
    {
        public int id { get; set; }
        public int type { get; set; }
        public string? bv_id { get; set; }
        public string? bvid { get; set; }
    }

}
