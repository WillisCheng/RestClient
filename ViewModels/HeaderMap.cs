namespace ViewModels
{
    public class HeaderMap
    {
        public static readonly HeaderMap Default = new HeaderMap
        {
            Key = "Content-Type",
            Value = Constans.DefaultContentType
        };

        public string Key { get; set; }

        public string Value { get; set; }

        public override string ToString()
        {
            return string.Format("{0} : {1}", Key, Value);
        }
    }
}