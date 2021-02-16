using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WpfUIControls.API;

namespace WpfTest
{
    /// <summary>
    /// Логика взаимодействия для WorldObjectsWindow.xaml
    /// </summary>
    public partial class WorldObjectsWindow : Window
    {
        public WorldObjectsWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            List<WorldObjectModel> objects = new List<WorldObjectModel>();
            objects.Add(new WorldObjectModel("Mesh 1",      "1", WorldObjectType.Mesh,      WorldObjectRowHierarchyLevel.Item));
            objects.Add(new WorldObjectModel("Mesh 2",      "2", WorldObjectType.Mesh,      WorldObjectRowHierarchyLevel.Item));
            objects.Add(new WorldObjectModel("Mesh 3",      "3", WorldObjectType.Mesh,      WorldObjectRowHierarchyLevel.Item));
            objects.Add(new WorldObjectModel("Mesh 4",      "4", WorldObjectType.Mesh,      WorldObjectRowHierarchyLevel.Item));
            objects.Add(new WorldObjectModel("Light 1",     "5", WorldObjectType.Light,     WorldObjectRowHierarchyLevel.Item));
            objects.Add(new WorldObjectModel("Light 2",     "6", WorldObjectType.Light,     WorldObjectRowHierarchyLevel.Item));
            objects.Add(new WorldObjectModel("Light 3",     "7", WorldObjectType.Light,     WorldObjectRowHierarchyLevel.Item));
            objects.Add(new WorldObjectModel("Spotlight 1", "8", WorldObjectType.SpotLight, WorldObjectRowHierarchyLevel.Item));
            objects.Add(new WorldObjectModel("Spotlight 2", "9", WorldObjectType.SpotLight, WorldObjectRowHierarchyLevel.Item));
            objects.Add(new WorldObjectModel("Spotlight 3", "10", WorldObjectType.SpotLight, WorldObjectRowHierarchyLevel.Item));
            objects.Add(new WorldObjectModel("Spotlight 4", "11", WorldObjectType.SpotLight, WorldObjectRowHierarchyLevel.Item));
            objects.Add(new WorldObjectModel("Spotlight 5", "12", WorldObjectType.SpotLight, WorldObjectRowHierarchyLevel.Item));
            objects.Add(new WorldObjectModel("Sound 1",     "13", WorldObjectType.Sound,     WorldObjectRowHierarchyLevel.Item));
            objects.Add(new WorldObjectModel("Sound 2",     "14", WorldObjectType.Sound,     WorldObjectRowHierarchyLevel.Item));

            worldObjects.AddRangeToScrollViewer(objects);
        }
    }
}
