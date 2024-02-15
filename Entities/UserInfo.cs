namespace FuckUGenshin.Entities
{

    public class UserInfo
    {
        public int code { get; set; }
        public string? message { get; set; }
        public int ttl { get; set; }
        public UData? data { get; set; }
    }

    public class UData
    {
        public bool isLogin { get; set; }
        public int email_verified { get; set; }
        public string? face { get; set; }
        public int face_nft { get; set; }
        public int face_nft_type { get; set; }
        public Level_Info? level_info { get; set; }
        public int mid { get; set; }
        public int mobile_verified { get; set; }
        public float money { get; set; }
        public int moral { get; set; }
        public Official? official { get; set; }
        public Officialverify? officialVerify { get; set; }
        public Pendant? pendant { get; set; }
        public int scores { get; set; }
        public string? uname { get; set; }
        public long vipDueDate { get; set; }
        public int vipStatus { get; set; }
        public int vipType { get; set; }
        public int vip_pay_type { get; set; }
        public int vip_theme_type { get; set; }
        public Vip_Label? vip_label { get; set; }
        public int vip_avatar_subscript { get; set; }
        public string? vip_nickname_color { get; set; }
        public Vip? vip { get; set; }
        public Wallet? wallet { get; set; }
        public bool has_shop { get; set; }
        public string? shop_url { get; set; }
        public int allowance_count { get; set; }
        public int answer_status { get; set; }
        public int is_senior_member { get; set; }
        public Wbi_Img? wbi_img { get; set; }
        public bool is_jury { get; set; }
    }

    public class Level_Info
    {
        public int current_level { get; set; }
        public int current_min { get; set; }
        public int current_exp { get; set; }
        public int next_exp { get; set; }
    }

    public class Official
    {
        public int role { get; set; }
        public string? title { get; set; }
        public string? desc { get; set; }
        public int type { get; set; }
    }

    public class Officialverify
    {
        public int type { get; set; }
        public string? desc { get; set; }
    }

    public class Pendant
    {
        public int pid { get; set; }
        public string? name { get; set; }
        public string? image { get; set; }
        public int expire { get; set; }
        public string? image_enhance { get; set; }
        public string? image_enhance_frame { get; set; }
        public int n_pid { get; set; }
    }

    public class Vip_Label
    {
        public string? path { get; set; }
        public string? text { get; set; }
        public string? label_theme { get; set; }
        public string? text_color { get; set; }
        public int bg_style { get; set; }
        public string? bg_color { get; set; }
        public string? border_color { get; set; }
        public bool use_img_label { get; set; }
        public string? img_label_uri_hans { get; set; }
        public string? img_label_uri_hant { get; set; }
        public string? img_label_uri_hans_static { get; set; }
        public string? img_label_uri_hant_static { get; set; }
    }

    public class Vip
    {
        public int type { get; set; }
        public int status { get; set; }
        public long due_date { get; set; }
        public int vip_pay_type { get; set; }
        public int theme_type { get; set; }
        public Label? label { get; set; }
        public int avatar_subscript { get; set; }
        public string? nickname_color { get; set; }
        public int role { get; set; }
        public string? avatar_subscript_url { get; set; }
        public int tv_vip_status { get; set; }
        public int tv_vip_pay_type { get; set; }
        public int tv_due_date { get; set; }
        public Avatar_Icon? avatar_icon { get; set; }
    }

    public class Label
    {
        public string? path { get; set; }
        public string? text { get; set; }
        public string? label_theme { get; set; }
        public string? text_color { get; set; }
        public int bg_style { get; set; }
        public string? bg_color { get; set; }
        public string? border_color { get; set; }
        public bool use_img_label { get; set; }
        public string? img_label_uri_hans { get; set; }
        public string? img_label_uri_hant { get; set; }
        public string? img_label_uri_hans_static { get; set; }
        public string? img_label_uri_hant_static { get; set; }
    }

    public class Avatar_Icon
    {
        public int icon_type { get; set; }
        public Icon_Resource? icon_resource { get; set; }
    }

    public class Icon_Resource
    {
    }

    public class Wallet
    {
        public int mid { get; set; }
        public float bcoin_balance { get; set; }
        public int coupon_balance { get; set; }
        public int coupon_due_time { get; set; }
    }

    public class Wbi_Img
    {
        public string? img_url { get; set; }
        public string? sub_url { get; set; }
    }

}
