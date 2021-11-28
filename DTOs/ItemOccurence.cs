namespace dope_stats.DTOs
{
    public class ItemOccurence
    {
        public Dictionary<string, int>? clothes { get; set; }
        public Dictionary<string, int>? foot { get; set; }
        public Dictionary<string, int>? hand { get; set; }
        public Dictionary<string, int>? drugs { get; set; }
        public Dictionary<string, int>? neck { get; set; }
        public Dictionary<string, int>? ring { get; set; }
        public Dictionary<string, int>? waist { get; set; }
        public Dictionary<string, int>? weapon { get; set; }
        public Dictionary<string, int>? vehicle { get; set; }
    }
}
