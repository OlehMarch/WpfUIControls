using System.Collections.Generic;
using System.Windows.Controls;

namespace WpfUIControls.API
{
    public class EntityParamSets
    {
        public static List<UserControl> GetInstance(EntityParamSet set)
        {
            List<UserControl> controls = new List<UserControl>();

            switch (set)
            {
                case EntityParamSet.Mesh:
                    {
                        controls.Add(new UI.Main.Transform()  { Name = "transform" });
                        controls.Add(new UI.Main.Lighting()   { Name = "lighting" });
                        controls.Add(new UI.Main.Collisions() { Name = "collisions" });
                        controls.Add(new UI.Main.Materials()  { Name = "materials" });
                        break;
                    }
                case EntityParamSet.Light:
                    {
                        controls.Add(new UI.Main.Transform() { Name = "transform" });
                        break;
                    }

                case EntityParamSet.None:
                default:
                    break;
            }

            return controls;
        }
    }
}
