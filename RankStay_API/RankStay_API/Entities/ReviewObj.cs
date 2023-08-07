namespace RankStay_API.Entities
{
    public class ReviewObj
    {
        public int ReviewId { get; set; }
        public int ReviewPropertyId { get; set; }
        public string? PropertyName { get; set; }
        public string? ProvinceName { get; set; }
        public string? ReviewComment { get; set; }
        public double? ReviewStar { get; set; }
    }
}