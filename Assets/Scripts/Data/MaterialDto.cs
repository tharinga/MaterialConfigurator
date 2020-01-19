namespace MakeAShape.Data
{
    public class MaterialDto
    {
        public string Name { get; set; }
        public string AlbedoUrl { get; set; }
        public string NormalUrl { get; set; }
        public float Specularity { get; set; }
        public float Smoothness { get; set; }
        public float TilingX { get; set; }
        public float TilingY { get; set; }
        public float BumpScale { get; set; }
        public int Type { get; set; }
    }
}