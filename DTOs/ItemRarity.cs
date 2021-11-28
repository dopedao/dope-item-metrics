namespace dope_stats.DTOs
{
    public class ItemRarity
    {
        public Dictionary<string, double>? clothes { get; set; }
        public Dictionary<string, double>? foot { get; set; }
        public Dictionary<string, double>? hand { get; set; }
        public Dictionary<string, double>? drugs { get; set; }
        public Dictionary<string, double>? neck { get; set; }
        public Dictionary<string, double>? ring { get; set; }
        public Dictionary<string, double>? waist { get; set; }
        public Dictionary<string, double>? weapon { get; set; }
        public Dictionary<string, double>? vehicle { get; set; }
    }
}
