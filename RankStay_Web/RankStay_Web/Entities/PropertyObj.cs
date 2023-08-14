namespace RankStay_Web.Entities
{
    public class PropertyObj
    {
        public int PropertyId { get; set; }
        public int PropertyProvinceId { get; set; }
        public string? ProvinceName { get; set; }
        public string? ProvincePhoto { get; set; }
        public string? PropertyName { get; set; }
        public string? PropertyDescription { get; set; }
        public int? PropertyUserId { get; set; }
        public double? AverageReviewStar { get; set; }
    }
}