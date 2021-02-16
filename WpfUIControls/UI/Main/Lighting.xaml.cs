using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace WpfUIControls.UI.Main
{
    /// <summary>
    /// Логика взаимодействия для Lighting.xaml
    /// </summary>
    public partial class Lighting : UserControl
    {
        public Lighting()
        {
            InitializeComponent();
            InitializeVariables();
            InitializeEventHandlers();
        }


        private Brush SelectedRow;
        private Brush UsualRow;
        private Color SelectedCB;
        private Color UsualCB;

        public bool IsCastingShadow
        {
            get
            {
                return cbCastShadow.IsChecked.Value;
            }
            set
            {
                cbCastShadow.IsChecked = value;
            }
        }
        public double Ambient
        {
            get
            {
                return Convert.ToDouble(lAmbientValue.Content.ToString().Replace(".", ","));
            }
            set
            {
                if (value >= 0 && value <= 1.0)
                {
                    sliderAmbient.Value = value;
                    lAmbientValue.Content = value.ToString().Replace(",", ".");
                    if (lAmbientValue.Content.Equals("0") || lAmbientValue.Content.Equals("1"))
                    {
                        lAmbientValue.Content += ".0";
                    }
                }
            }
        }
        public double Diffuse
        {
            get
            {
                return Convert.ToDouble(lDiffuseValue.Content.ToString().Replace(".", ","));
            }
            set
            {
                if (value >= 0 && value <= 1.0)
                {
                    sliderDiffuse.Value = value;
                    lDiffuseValue.Content = value.ToString().Replace(",", ".");
                    if (lDiffuseValue.Content.Equals("0") || lDiffuseValue.Content.Equals("1"))
                    {
                        lDiffuseValue.Content += ".0";
                    }
                }
            }
        }
        public double Specular
        {
            get
            {
                return Convert.ToDouble(lSpecularValue.Content.ToString().Replace(".", ","));
            }
            set
            {
                if (value >= 0 && value <= 1.0)
                {
                    sliderSpecular.Value = value;
                    lSpecularValue.Content = value.ToString().Replace(",", ".");
                    if (lSpecularValue.Content.Equals("0") || lSpecularValue.Content.Equals("1"))
                    {
                        lSpecularValue.Content += ".0";
                    }
                }
            }
        }
        public double Shininess
        {
            get
            {
                return Convert.ToDouble(lReflectanceValue.Content.ToString().Replace(".", ","));
            }
            set
            {
                if (value >= 0 && value <= 100)
                {
                    sliderReflectance.Value = value;
                    lReflectanceValue.Content = value.ToString().Replace(",", ".");
                    if (!lReflectanceValue.Content.ToString().Contains("."))
                    {
                        lReflectanceValue.Content += ".0";
                    }
                }
            }
        }
        public double ShineDamper
        {
            get
            {
                return Convert.ToDouble(lShineDamperValue.Content.ToString().Replace(".", ","));
            }
            set
            {
                if (value >= 0 && value <= 200)
                {
                    sliderShineDamper.Value = value;
                    lShineDamperValue.Content = value.ToString().Replace(",", ".");
                    if (!lShineDamperValue.Content.ToString().Contains("."))
                    {
                        lShineDamperValue.Content += ".0";
                    }
                }
            }
        }


        #region Inits
        private void InitializeVariables()
        {
            IsCastingShadow = false;
            this.UsualRow = new SolidColorBrush((Color)Resources["UI_Background_DarkGray"]);
            this.SelectedRow = new SolidColorBrush((Color)Resources["UI_Background_Selection_Gray"]);
            this.UsualCB = (Color)Resources["UI_Foreground_LightGray"];
            this.SelectedCB = (Color)Resources["UI_CheckBox_Selection_Golden"];
        }
        private void InitializeEventHandlers()
        {
            this.MouseMove += Transform_MouseMove;
        }
        #endregion

        #region MouseMove Event Handler
        private void Transform_MouseMove(object sender, MouseEventArgs e)
        {
            double y = e.GetPosition(this).Y;

            RowColorChanger(BorderRow1, 0, 40, y);
            RowColorChanger(BorderRow2, 40, 80, y);
            RowColorChanger(BorderRow3, 80, 120, y);
            RowColorChanger(BorderRow4, 120, 160, y);
            RowColorChanger(BorderRow5, 160, 200, y);
            RowColorChanger(BorderRow6, 200, 240, y);
            RowColorChanger(BorderRow7, 240, 280, y);
        }
        #endregion

        #region Shadow Event Handlers
        private void cbCastShadow_MouseEnter(object sender, MouseEventArgs e)
        {
            cbCastShadowEffect.Color = SelectedCB;
        }

        private void cbCastShadow_MouseLeave(object sender, MouseEventArgs e)
        {
            cbCastShadowEffect.Color = UsualCB;
        }
        #endregion

        #region Slider Event Handlers
        private void sliderAmbient_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            double value = Math.Round(sliderAmbient.Value, 2);
            lAmbientValue.Content = value.ToString().Replace(",", ".");
            if (lAmbientValue.Content.Equals("0") || lAmbientValue.Content.Equals("1"))
            {
                lAmbientValue.Content += ".0";
            }
        }

        private void sliderDiffuse_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            double value = Math.Round(sliderDiffuse.Value, 2);
            lDiffuseValue.Content = value.ToString().Replace(",", ".");
            if (lDiffuseValue.Content.Equals("0") || lDiffuseValue.Content.Equals("1"))
            {
                lDiffuseValue.Content += ".0";
            }
        }

        private void sliderSpecular_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            double value = Math.Round(sliderSpecular.Value, 2);
            lSpecularValue.Content = value.ToString().Replace(",", ".");
            if (lSpecularValue.Content.Equals("0") || lSpecularValue.Content.Equals("1"))
            {
                lSpecularValue.Content += ".0";
            }
        }

        private void sliderReflectance_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            double value = Math.Round(sliderReflectance.Value, 1);
            lReflectanceValue.Content = value.ToString().Replace(",", ".");
            if (!lReflectanceValue.Content.ToString().Contains("."))
            {
                lReflectanceValue.Content += ".0";
            }
        }

        private void sliderShineDamper_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            double value = Math.Round(sliderShineDamper.Value, 1);
            lShineDamperValue.Content = value.ToString().Replace(",", ".");
            if (!lShineDamperValue.Content.ToString().Contains("."))
            {
                lShineDamperValue.Content += ".0";
            }
        }
        #endregion

        private void RowColorChanger(Border BorderRow, int bottomYCoord, int topYCoord, double y)
        {
            if (y > bottomYCoord && y <= topYCoord)
            {
                BorderRow.Background = SelectedRow;
            }
            else
            {
                BorderRow.Background = UsualRow;
            }
        }

    }
}
