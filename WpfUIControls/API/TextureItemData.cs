using WpfUIControls.UI.Additional;

namespace WpfUIControls.API
{
    public struct TextureItemData
    {
        public TextureItemData(TextureItemDetailed item)
        {
            Path = item.TextureFullPath;
            Name = item.TextureName;
            Subdirectory = item.TextureSubdirectory;
            Type = item.TextureType;
            Width = item.TextureWidth;
            Height = item.TextureHeight;
            Icon = new System.Windows.Controls.Image();
            Icon.Source = ((System.Windows.Controls.Image)item.lSmallIcon.Content).Source.Clone();
        }

        public string Path { get; set; }
        public string Name { get; set; }
        public string Subdirectory { get; set; }
        public TextureType Type { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public System.Windows.Controls.Image Icon { get; set; }
    }
}
