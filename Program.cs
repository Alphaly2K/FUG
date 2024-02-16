using FuckUGenshin.Entities;
using Newtonsoft.Json;
using RestSharp;
using System.Net;

namespace FuckUGenshin
{
    public class FuckUGenshin
    {
        public static readonly string baseUrl = "https://api.bilibili.com/";
        public static readonly string accountInfoUrl = baseUrl + "x/web-interface/nav";
        public static readonly string favorsListUrl = baseUrl + "x/v3/fav/folder/created/list-all";
        public static readonly string favorsContentUrl = baseUrl + "x/v3/fav/resource/ids";
        public static readonly string tagUrl = baseUrl + "x/tag/archive/tags";
        public static readonly string delUrl = baseUrl + "x/v3/fav/resource/batch-del";
        public readonly List<string> targetsList;
        public readonly List<Account> accountsList;
        public static readonly string aConfigUri = "./Configs/Accounts.json";
        public static readonly string tConfigUri = "./Configs/Targets.json";
        public readonly CookieContainer cookieContainer = new();
        public readonly int uid;
        public readonly string uname;
        private int fid;
        private int aid;
        public enum GetType { Account = 0, FavorsList = 1, FavorsContent = 2, Tags = 3 };
        public readonly string[] url = { accountInfoUrl, favorsListUrl, favorsContentUrl, tagUrl };
        public RestClient Client = new();
        private static string? ReadConfigs(string uri)
        {
            if (!File.Exists(uri))
            {
                Console.WriteLine("配置文件不存在，已经创建配置文件");
                _ = File.Create(uri);
                return null;
            }
            try
            {
                string rawConfig = File.ReadAllText(uri);
                return rawConfig;
            }
            catch (Exception e)
            {
                Console.WriteLine("无法打开该配置文件，请检查文件权限：");
                Console.WriteLine(e);
            }
            return null;
        }
        public FuckUGenshin()
        {
            //多账号我看现在还是免了吧
            string? rawAccounts = ReadConfigs(aConfigUri);
            //从Tag定位，直歼原神
            string? rawTargets = ReadConfigs(tConfigUri);
            if (rawAccounts != null && rawTargets != null)
            {
                try
                {
                    List<Account> accounts = JsonConvert.DeserializeObject<List<Account>>(rawAccounts);
                    List<string> targets = JsonConvert.DeserializeObject<List<string>>(rawTargets);
                    targetsList = targets;
                    accountsList = accounts;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
            }
            Cookie cookie = new("SESSDATA", accountsList[0].sessdata);
            cookieContainer.Add(new Uri(baseUrl), cookie);
            UserInfo userInfo = Get<UserInfo>(GetType.Account);
            if (userInfo != null)
            {
                uname = userInfo.data.uname;
                uid = userInfo.data.mid;
                return;
            }
            Console.WriteLine("检查配置文件中账号设置");
            System.Environment.Exit(-1);
        }

        public T? Get<T>(GetType getType)
        {
            RestRequest request = new(url[(int)getType], Method.Get)
            {
                CookieContainer = cookieContainer
            };
            switch (getType)
            {
                case GetType.Account:
                    break;
                case GetType.FavorsList:
                    _ = request.AddParameter("up_mid", uid);
                    break;
                case GetType.FavorsContent:
                    _ = request.AddParameter("media_id", fid);
                    break;
                case GetType.Tags:
                    _ = request.AddParameter("aid", aid);
                    break;
            }
            RestResponse response = Client.Execute(request);
            if (response.IsSuccessStatusCode)
            {
                try
                {
                    T res = JsonConvert.DeserializeObject<T>(response.Content.ToString());
                    return res;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
            return default;
        }

        public bool IsGenshin(List<string> tags)
        {
            foreach (string target in targetsList)
            {
                if (tags.Exists(tag => tag == target))
                {
                    return true;
                }
            }
            return false;

        }

        public bool Del(string param)
        {
            RestRequest request = new(delUrl, Method.Post)
            {
                CookieContainer = cookieContainer
            };
            _ = request.AddParameter("resources", param);
            _ = request.AddParameter("media_id", fid);
            _ = request.AddParameter("csrf", accountsList[0].csrf);
            RestResponse response = Client.Execute(request);
            return response.IsSuccessStatusCode;
        }

        public static void Main(string[] args)
        {
            FuckUGenshin FUG = new();
            Favors? favors = FUG.Get<Favors?>(GetType.FavorsList);
            List<List> favorslist = new();
            Console.WriteLine("你好" + FUG.uname + "!" + "选择一个收藏夹吧");
            foreach (List favor in favors.data.list)
            {
                favorslist.Add(favor);
                Console.WriteLine(favor.title);
            }
            int option;
            try
            {
                option = int.Parse(Console.ReadLine());
            }
            catch (Exception e)
            {
                Console.WriteLine("让你填数字，没让你填标题[流汗]");
                Console.WriteLine(e);
                return;
            }
            Entities.List select = favorslist[option - 1];
            FUG.fid = select.id;
            FavorsAll? selectFavors = FUG.Get<FavorsAll?>(GetType.FavorsContent);
            List<int> ids = new();
            foreach (Datum video in selectFavors.data)
            {
                FUG.aid = video.id;
                Tags? tmp = FUG.Get<Tags?>(GetType.Tags);
                List<string> tags = new();
                foreach (TDatum tag in tmp.data)
                {
                    tags.Add(tag.tag_name);
                }
                if (FUG.IsGenshin(tags))
                {
                    ids.Add(video.id);
                    Console.WriteLine("正在删除" + video.bv_id + "...");
                }
            }
            string? requestParam = null;
            foreach (int id in ids)
            {
                requestParam += id.ToString() + ":2,";
            }
            if (requestParam != null)
            {
                _ = requestParam.TrimEnd(',');
                Console.WriteLine("结果" + FUG.Del(requestParam));
                return;
            }
            Console.WriteLine("恭喜你！你的收藏夹没有Genshin Impact！");
        }
    }
}