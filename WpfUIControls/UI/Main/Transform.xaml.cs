using System;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using OpenTK;

namespace WpfUIControls.UI.Main
{
    /// <summary>
    /// Логика взаимодействия для Transform.xaml
    /// </summary>
    public partial class Transform : UserControl
    {
        public Transform()
        {
            try
            {
                InitializeComponent();
                InitializeVariables();
                InitializeEventHandlers();
            }
            catch (Exception e)
            {
                throw e.InnerException;
            }
        }


        private bool isLockedTransform;
        private Brush SelectedRow;
        private Brush UsualRow;

        public Vector3d Location
        {
            get
            {
                return new Vector3d(
                    Convert.ToDouble(Location_X.Text.Replace(".", ",")),
                    Convert.ToDouble(Location_Y.Text.Replace(".", ",")),
                    Convert.ToDouble(Location_Z.Text.Replace(".", ","))
                );
            }
            set
            {
                Location_X.Text = value.X.ToString().Replace(",", "."); ;
                Location_Y.Text = value.Y.ToString().Replace(",", "."); ;
                Location_Z.Text = value.Z.ToString().Replace(",", "."); ;
            }
        }
        public Vector3d Rotation
        {
            get
            {
                return new Vector3d(
                    Convert.ToDouble(Rotation_X.Text.Replace(".", ",")),
                    Convert.ToDouble(Rotation_Y.Text.Replace(".", ",")),
                    Convert.ToDouble(Rotation_Z.Text.Replace(".", ","))
                );
            }
            set
            {
                Rotation_X.Text = value.X.ToString().Replace(",", ".");
                Rotation_Y.Text = value.Y.ToString().Replace(",", "."); ;
                Rotation_Z.Text = value.Z.ToString().Replace(",", "."); ;
            }
        }
        public Vector3d Scale
        {
            get
            {
                return new Vector3d(
                    Convert.ToDouble(Scale_X.Text.Replace(".", ",")),
                    Convert.ToDouble(Scale_Y.Text.Replace(".", ",")),
                    Convert.ToDouble(Scale_Z.Text.Replace(".", ","))
                );
            }
            set
            {
                Scale_X.Text = value.X.ToString().Replace(",", "."); ;
                Scale_Y.Text = value.Y.ToString().Replace(",", "."); ;
                Scale_Z.Text = value.Z.ToString().Replace(",", "."); ;
            }
        }


        #region Inits
        private void InitializeVariables()
        {
            this.isLockedTransform = false;
            this.iLock.Source = (ImageSource)Resources["lock_unlocked"];
            this.UsualRow = new SolidColorBrush((Color)Resources["UI_Background_DarkGray"]);
            this.SelectedRow = new SolidColorBrush((Color)Resources["UI_Background_Selection_Gray"]);
        }

        private void InitializeEventHandlers()
        {
            this.ScrollBias.TextChanged += new Action(ScrollBias_TextChanged);
            this.MouseMove += Transform_MouseMove;
        }
        #endregion

        #region Event Handlers
        private void iLock_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (!isLockedTransform)
            {
                iLock.Source = (ImageSource)Resources["lock_locked"];
                EnableTextBoxes(false);
            }
            else
            {
                iLock.Source = (ImageSource)Resources["lock_unlocked"];
                EnableTextBoxes(true);
            }

            isLockedTransform = !isLockedTransform;
        }

        private void Transform_MouseMove(object sender, MouseEventArgs e)
        {
            double y = e.GetPosition(this).Y;

            RowColorChanger(BorderRow1, 0, 40, y);
            RowColorChanger(BorderRow2, 40, 80, y);
            RowColorChanger(BorderRow3, 80, 120, y);
            RowColorChanger(BorderRow4, 120, 160, y);
        }

        private void ScrollBias_TextChanged()
        {
            float bias = Convert.ToSingle(ScrollBias.Text.Replace(".", ","));

            Location_X.ScrollBias = bias;
            Location_Y.ScrollBias = bias;
            Location_Z.ScrollBias = bias;
            Rotation_X.ScrollBias = bias;
            Rotation_Y.ScrollBias = bias;
            Rotation_Z.ScrollBias = bias;
            Scale_X.ScrollBias = bias;
            Scale_Y.ScrollBias = bias;
            Scale_Z.ScrollBias = bias;
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

        private void EnableTextBoxes(bool value)
        {
            Location_X.IsEnabled = value;
            Location_Y.IsEnabled = value;
            Location_Z.IsEnabled = value;
            Rotation_X.IsEnabled = value;
            Rotation_Y.IsEnabled = value;
            Rotation_Z.IsEnabled = value;
            Scale_X.IsEnabled = value;
            Scale_Y.IsEnabled = value;
            Scale_Z.IsEnabled = value;
        }

    }
}
