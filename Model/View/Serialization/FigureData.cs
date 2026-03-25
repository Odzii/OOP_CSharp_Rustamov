namespace View.Serialization
{
    public class FigureData
    {
        public string FigureKind { get; set; } = string.Empty;

        public double? Radius { get; set; }

        public double? BaseLength { get; set; }
        public double? BaseWidth { get; set; }

        public double? Length { get; set; }
        public double? Width { get; set; }

        public double? Height { get; set; }
    }
}