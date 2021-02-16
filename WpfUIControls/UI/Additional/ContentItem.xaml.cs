using System;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using WpfUIControls.API;

namespace WpfUIControls.UI.Additional
{
    /// <summary>
    /// Логика взаимодействия для ContentItem.xaml
    /// </summary>
    public partial class ContentItem : UserControl
    {
        public ContentItem()
        {
            InitializeComponent();
            InitializeVariables();
        }


        #region Variables
        public event Action<string> OnContentItemClick;

        public string Text
        {
            get
            {
                return labelFileName.Text + _extension;
            }
            set
            {
                _fullPath = value;
                var name = value.Remove(0, (value.Contains('\\') ? value.LastIndexOf('\\') : value.LastIndexOf('/')) + 1);
                if (name.Contains('.'))
                    _extension = name.Remove(0, name.LastIndexOf('.'));
                labelFileName.Text = name.Replace(_extension, string.Empty);
                labelFileName.ToolTip = labelFileName.Text;
            }
        }
        public ContentItemType Type
        {
            get
            {
                return _type;
            }
            set
            {
                _type = value;
                BorderRect.Stroke = _type.GetBrush();
                labelImage.Content = _type.GetImage(Resources, _type == ContentItemType.Texture ? _fullPath : null);
            }
        }

        private Brush _selectedItem;
        private Brush _usualItem;
        private ContentItemType _type;
        private string _extension;
        private string _fullPath;
        #endregion


        private void InitializeVariables()
        {
            _usualItem = new SolidColorBrush((Color)Resources["UI_Background_Selection_Gray"]);
            _selectedItem = new SolidColorBrush((Color)Resources["UI_Foreground_LightGray"]);
        }

        #region Mouse Hover Event Handlers
        private void ContentItem_MouseEnter(object sender, MouseEventArgs e)
        {
            contentItem.BorderBrush = _selectedItem;
            if (_type == ContentItemType.Folder)
            {
                Cursor = Cursors.Hand;
            }
        }

        private void ContentItem_MouseLeave(object sender, MouseEventArgs e)
        {
            contentItem.BorderBrush = _usualItem;
            if (_type == ContentItemType.Folder)
            {
                Cursor = Cursors.Arrow;
            }
        }


        #endregion

        private void ContentItem_Click(object sender, MouseButtonEventArgs e)
        {
            if (_type == ContentItemType.Folder)
            {
                OnContentItemClick(Text);
            }
        }

    }
}
