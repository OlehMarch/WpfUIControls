using System;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using WpfUIControls.API;
using WpfUIControls.UI.Main;

namespace WpfUIControls.UI.Additional
{
    /// <summary>
    /// Логика взаимодействия для WorldObjectRow.xaml
    /// </summary>
    public partial class WorldObjectRow : UserControl
    {
        public WorldObjectRow(ushort scrollBarWidth)
        {
            InitializeComponent();
            InitializeVariables(scrollBarWidth);
        }


        #region Variables
        public event Action<bool, string> EntityVisibilityChanged;

        public string Label
        {
            get
            {
                return labelObject.Content.ToString();
            }
            set
            {
                labelObject.Content = value;
            }
        }
        public string ID
        {
            get
            {
                return _id;
            }
            set
            {
                _id = value;
            }
        }
        public WorldObjectType Type
        {
            get
            {
                return _objectType;
            }
            set
            {
                _objectType = value;
                labelObjectIcon.Content = WorldObjectImage.GetInstance(Resources, _objectType);
                _type = value.ToString();
                labelObjectDetail.Content = _type;
            }
        }
        public WorldObjectRowHierarchyLevel HierarchyLevel
        {
            get
            {
                return _hierarchyLevel;
            }
            set
            {
                _hierarchyLevel = value;
                labelObjectIcon.RenderTransform = _hierarchyLevel.GetTransform();
                labelObject.Padding = _hierarchyLevel.GetPadding();
            }
        }

        private string _type;
        private string _id;
        private WorldObjectType _objectType;
        private WorldObjectRowHierarchyLevel _hierarchyLevel;
        private Brush _selectedRow;
        private Brush _usualRow;
        private bool _isVisible;
        #endregion


        public void SwitchDetailInfo(bool isObjectIdShown)
        {
            if (isObjectIdShown)
            {
                labelObjectDetail.Content = ID;
            }
            else
            {
                labelObjectDetail.Content = _type;
            }
        }

        private void InitializeVariables(ushort scrollBarWidth)
        {
            _isVisible = true;

            MainGrid.ColumnDefinitions[4].Width = 
                new System.Windows.GridLength(MainGrid.ColumnDefinitions[4].Width.Value - scrollBarWidth, System.Windows.GridUnitType.Pixel);

            _objectType = WorldObjectType.Folder;
            _hierarchyLevel = WorldObjectRowHierarchyLevel.Item;

            _usualRow = new SolidColorBrush((Color)Resources["UI_Background_DarkGray"]);
            _selectedRow = new SolidColorBrush((Color)Resources["UI_Background_Selection_Gray"]);
        }

        #region Mouse Hover Event Handlers
        private void WorldObjectRow_MouseEnter(object sender, MouseEventArgs e)
        {
            MainGrid.Background = _selectedRow;
        }

        private void WorldObjectRow_MouseLeave(object sender, MouseEventArgs e)
        {
            MainGrid.Background = _usualRow;
        }
        #endregion

        private void labelVisibilityIcon_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (_isVisible)
            {
                labelVisibilityIcon.Opacity = 0.25;
            }
            else
            {
                labelVisibilityIcon.Opacity = 1;
            }
            _isVisible = !_isVisible;

            EntityVisibilityChanged.Invoke(_isVisible, ID);
        }

    }
}
