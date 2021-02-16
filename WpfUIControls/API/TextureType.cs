using System;
using System.Linq;

namespace WpfUIControls.API
{
    public enum TextureType
    {
        MT,
        NM,
        SM,
        GM,
        EM,
        AOM
    }

    public static class TextureTypeSelector
    {
        public static string GetInstance(TextureType type)
        {
            var rootSubdir = "";

            switch (type)
            {
                case TextureType.MT:
                    rootSubdir = "Model Texture";
                    break;
                case TextureType.NM:
                    rootSubdir = "Normal Map";
                    break;
                case TextureType.SM:
                    rootSubdir = "Specular Map";
                    break;
                case TextureType.GM:
                    rootSubdir = "Glowing Map";
                    break;
                case TextureType.EM:
                    rootSubdir = "Environment Map";
                    break;
                case TextureType.AOM:
                    rootSubdir = "Ambient Occlusion Map";
                    break;
                default:
                    break;
            }

            return rootSubdir;
        }

        public static int GetTypeQuantity(this TextureType type)
        {
            return Enum.GetValues(typeof(TextureType)).Cast<int>().Max() + 1;
        }

        public static string GetFullTextureType(this TextureType type)
        {
            return TextureTypeSelector.GetInstance(type);
        }
    }
}
