using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace WpfUIControls.API
{
    public enum ContentItemType : int
    {
        Folder,
        Mesh,
        Texture,
        Sound,
        Terrain,
        Particle
    }

    public static class ContentItemExtensions
    {
        public static Brush GetBrush(this ContentItemType type)
        {
            Brush brush = null;

            switch (type)
            {
                case ContentItemType.Mesh:
                    brush = new SolidColorBrush(Color.FromArgb(255, 64, 128, 200));
                    break;
                case ContentItemType.Texture:
                    brush = new SolidColorBrush(Color.FromArgb(255, 255, 161, 49));
                    break;
                case ContentItemType.Sound:
                    brush = new SolidColorBrush(Color.FromArgb(255, 200, 30, 30));
                    break;
                case ContentItemType.Terrain:
                    brush = new SolidColorBrush(Color.FromArgb(255, 64, 200, 48));
                    break;
                case ContentItemType.Particle:
                    brush = new SolidColorBrush(Color.FromArgb(255, 150, 64, 220));
                    break;
                case ContentItemType.Folder:
                default:
                    brush = new SolidColorBrush(Color.FromArgb(255, 71, 71, 71));
                    break;
            }

            return brush;
        }

        public static Image GetImage(this ContentItemType type, ResourceDictionary resources, string texturePath)
        {
            Image image = new Image();

            switch (type)
            {
                case ContentItemType.Folder:
                    image.Source = (BitmapImage)resources["folder"];
                    break;
                case ContentItemType.Sound:
                    image.Source = (BitmapImage)resources["sound"];
                    break;
                case ContentItemType.Terrain:
                    image.Source = (BitmapImage)resources["terrain"];
                    break;
                case ContentItemType.Particle:
                    image.Source = (BitmapImage)resources["particle"];
                    break;

                case ContentItemType.Texture:
                    image.Source = new BitmapImage(new System.Uri(texturePath));
                    break;

                case ContentItemType.Mesh:
                default:
                    image.Source = (BitmapImage)resources["no_data"];
                    break;
            }

            image.MaxWidth = 200;
            image.MaxHeight = 200;
            image.Stretch = Stretch.UniformToFill;

            return image;
        }
    }
}
