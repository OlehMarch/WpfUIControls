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
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfUIControls.API;

namespace WpfTest
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            contentItem.Text = @"D:\Projects\Programming\CSharpPrograms\D.O.E\Models\Model Texture\BrickRound0105_5_S.jpg";
            contentItem.Type = ContentItemType.Texture;
        }

        private void buttonAddToGrid_Click(object sender, RoutedEventArgs e)
        {
            entityParamHolder.Entities = EntityParamSets.GetInstance(EntityParamSet.Mesh);
            entityParamHolder.Entities.GetParamMaterials().PathToTextures = @"D:\Projects\Programming\CSharpPrograms\D.O.E\Models";
        }

        private void buttonGetTransform_Click(object sender, RoutedEventArgs e)
        {
            var transform = entityParamHolder.Entities.GetParamTransform();
            labelMeshTransform.Content = transform.Location.ToString()
                + Environment.NewLine + transform.Rotation.ToString()
                + Environment.NewLine + transform.Scale.ToString();
        }

        private void buttonSetTransform_Click(object sender, RoutedEventArgs e)
        {
            var transform = entityParamHolder.Entities.GetParamTransform();
            transform.Location = new OpenTK.Vector3d(11, 8, 7.4);
            transform.Rotation = new OpenTK.Vector3d(3.003, 43.7, 55);
            transform.Scale = new OpenTK.Vector3d(-1, 3.08, 0.9);
        }

        private void buttonGetLighting_Click(object sender, RoutedEventArgs e)
        {
            var lighting = entityParamHolder.Entities.GetParamLighting();
            labelMeshLighting.Content = lighting.IsCastingShadow.ToString()
                + Environment.NewLine + lighting.Ambient.ToString()
                + "; " + lighting.Diffuse.ToString()
                + "; " + lighting.Specular.ToString()
                + Environment.NewLine + lighting.Shininess.ToString()
                + "; " + lighting.ShineDamper.ToString();
        }

        private void buttonSetLighting_Click(object sender, RoutedEventArgs e)
        {
            var lighting = entityParamHolder.Entities.GetParamLighting();
            lighting.IsCastingShadow = true;
            lighting.Ambient = 0.48;
            lighting.Diffuse = 0.11;
            lighting.Specular = 0.89;
            lighting.Shininess = 84.2;
            lighting.ShineDamper = 196.6;
        }

        private void buttonToWorldObjWindow_Click(object sender, RoutedEventArgs e)
        {
            WorldObjectsWindow window = new WorldObjectsWindow();
            window.Show();
        }
    }
}
