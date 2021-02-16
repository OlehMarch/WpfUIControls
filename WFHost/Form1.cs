using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows;
using System.Windows.Forms.Integration;
using System.Windows.Media;

namespace WFHost
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            materials1.PathToTextures = @"D:\Projects\CSharpPrograms\D.O.E\Models";
        }

        private void buttonGetModelData_Click(object sender, EventArgs e)
        {
            labelModelData.Text = transform1.Location.ToString()
                + Environment.NewLine + transform1.Rotation.ToString()
                + Environment.NewLine + transform1.Scale.ToString();
        }

        private void buttonSetModelData_Click(object sender, EventArgs e)
        {
            transform1.Location = new OpenTK.Vector3d(11, 8, 7.4);
            transform1.Rotation = new OpenTK.Vector3d(3.003, 43.7, 55);
            transform1.Scale = new OpenTK.Vector3d(-1, 3.08, 0.9);
        }

        private void buttonGetLightingData_Click(object sender, EventArgs e)
        {
            labelLightingData.Text = lighting1.IsCastingShadow.ToString()
                + Environment.NewLine + lighting1.Ambient.ToString()
                + "; " + lighting1.Diffuse.ToString() 
                + "; " + lighting1.Specular.ToString()
                + Environment.NewLine + lighting1.Shininess.ToString()
                + "; " + lighting1.ShineDamper.ToString();
        }

        private void buttonSetLightingData_Click(object sender, EventArgs e)
        {
            lighting1.IsCastingShadow = true;
            lighting1.Ambient = 0.48;
            lighting1.Diffuse = 0.11;
            lighting1.Specular = 0.89;
            lighting1.Shininess = 84.2;
            lighting1.ShineDamper = 196.6;
        }

        private void buttonAddItemToGrid_Click(object sender, EventArgs e)
        {
            var transform = new WpfUIControls.UI.Main.Transform();
            var lighting = new WpfUIControls.UI.Main.Lighting();
            var collisions = new WpfUIControls.UI.Main.Collisions();
            var materials = new WpfUIControls.UI.Main.Materials();
            entityParamHolder1.Entities = new List<System.Windows.Controls.UserControl>()
            {
                transform,
                lighting,
                collisions,
                materials
            };
        }
    }
}
