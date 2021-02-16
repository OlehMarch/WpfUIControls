using System.Collections.Generic;
using System.Windows.Controls;
using WpfUIControls.UI.Main;

namespace WpfUIControls.API
{
    public static class Extensions
    {
        public static string GetExpanderHeader(this string type)
        {
            string header = string.Empty;
            type = type.Remove(0, type.LastIndexOf(".") + 1);

            switch (type)
            {
                case "Transform":
                case "Lighting":
                case "Materials":
                    {
                        header = type;
                        break;
                    }
                case "Collisions":
                    {
                        header = "Collision";
                        break;
                    }

                default:
                    header = "Wrong control!";
                    break;
            }

            return header;
        }

        public static Transform GetParamTransform(this List<UserControl> entities)
        {
            return entities.Find(item => item is Transform) as Transform;
        }

        public static Lighting GetParamLighting(this List<UserControl> entities)
        {
            return entities.Find(item => item is Lighting) as Lighting;
        }

        public static Collisions GetParamCollisions(this List<UserControl> entities)
        {
            return entities.Find(item => item is Collisions) as Collisions;
        }

        public static Materials GetParamMaterials(this List<UserControl> entities)
        {
            return entities.Find(item => item is Materials) as Materials;
        }

    }
}
