using System.Windows.Media;

namespace WpfUIControls.API
{
    public enum WorldObjectRowHierarchyLevel : int
    {
        Root,
        Folder,
        Item
    }

    public static class WorldObjectRowHierarchyLevelExtension
    {
        public static TranslateTransform GetTransform(this WorldObjectRowHierarchyLevel level)
        {
            var offsetX = 0.0;

            switch (level)
            {
                case WorldObjectRowHierarchyLevel.Root:
                    offsetX = -20;
                    break;
                case WorldObjectRowHierarchyLevel.Folder:
                    offsetX = -10;
                    break;

                case WorldObjectRowHierarchyLevel.Item:
                default:
                    offsetX = 0;
                    break;
            }

            return new TranslateTransform(offsetX, 0);
        }

        public static System.Windows.Thickness GetPadding(this WorldObjectRowHierarchyLevel level)
        {
            System.Windows.Thickness padding;

            switch (level)
            {
                case WorldObjectRowHierarchyLevel.Root:
                    padding = new System.Windows.Thickness(30, 5, 5, 5);
                    break;
                case WorldObjectRowHierarchyLevel.Folder:
                    padding = new System.Windows.Thickness(40, 5, 5, 5);
                    break;

                case WorldObjectRowHierarchyLevel.Item:
                default:
                    padding = new System.Windows.Thickness(50, 5, 5, 5);
                    break;
            }

            return padding;
        }
    }
}
