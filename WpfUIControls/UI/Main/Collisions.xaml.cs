using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace WpfUIControls.UI.Main
{
    /// <summary>
    /// Логика взаимодействия для Collisions.xaml
    /// </summary>
    public partial class Collisions : UserControl
    {
        public Collisions()
        {
            InitializeComponent();
            InitializeVariables();
            InitializeEventHandlers();
        }


        public bool IsCollisionEnabled
        {
            get
            {
                return cbCollisions.IsChecked.Value;
            }
            set
            {
                cbCollisions.IsChecked = value;
            }
        }
        private Brush SelectedRow;
        private Brush UsualRow;
        private Color SelectedCB;
        private Color UsualCB;
        

        #region Inits
        private void InitializeVariables()
        {
            IsCollisionEnabled = false;
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
        }
        #endregion

        #region Collision Event Handlers
        private void cbCollisions_MouseEnter(object sender, MouseEventArgs e)
        {
            cbCollisionsEffect.Color = SelectedCB;
        }

        private void cbCollisions_MouseLeave(object sender, MouseEventArgs e)
        {
            cbCollisionsEffect.Color = UsualCB;
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
