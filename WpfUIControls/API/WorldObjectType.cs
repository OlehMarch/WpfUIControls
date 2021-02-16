using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace WpfUIControls.API
{
    public enum WorldObjectType : int
    {
        Folder,
        Mesh,
        Sound,
        Light,
        SpotLight
    }

    public static class WorldObjectImage
    {
        public static Image GetInstance(ResourceDictionary resources, WorldObjectType type)
        {
            Image image = new Image();

            switch (type)
            {
                case WorldObjectType.Mesh:
                    image.Source = (BitmapImage)resources["mesh"];
                    break;
                case WorldObjectType.Sound:
                    image.Source = (BitmapImage)resources["sound"];
                    break;
                case WorldObjectType.Light:
                    image.Source = (BitmapImage)resources["light"];
                    break;
                case WorldObjectType.SpotLight:
                    image.Source = (BitmapImage)resources["spotlight"];
                    break;

                case WorldObjectType.Folder:
                default:
                    image.Source = (BitmapImage)resources["folder"];
                    break;
            }
            image.Width = 20;
            image.Height = 15;
            image.Stretch = System.Windows.Media.Stretch.Uniform;

            return image;
        }
    }

}
