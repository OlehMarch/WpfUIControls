using System;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using WpfUIControls.API;

namespace WpfUIControls.UI.Additional
{
    /// <summary>
    /// Логика взаимодействия для TextureItemDetailed.xaml
    /// </summary>
    public partial class TextureItemDetailed : UserControl
    {
        #region Constructors
        public TextureItemDetailed()
        {
            InitializeComponent();
            InitializeVariables();
            SubscribeToItemClickEvent();
            SubscribeToMouseHoverEvents();
        }

        public TextureItemDetailed(string fullPath, TextureType type) : this()
        {
            TextureFullPath = fullPath;
            TextureType = type;
            GetTextureName();
            GetTextureSubdirectory();
            GetImageData();
        }
        #endregion


        #region Variables
        public string TextureName
        {
            get
            {
                return textureName;
            }
            private set
            {
                textureName = value;
                lTextureName.Content = value;
                lTextureName.ToolTip += Environment.NewLine + value;
            }
        }
        public string TextureSubdirectory
        {
            get
            {
                return textureSubdirectory;
            }
            private set
            {
                textureSubdirectory = value;
                lTextureSubdirectory.Content = value;
                lTextureSubdirectory.ToolTip += Environment.NewLine + value;
            }
        }
        public TextureType TextureType
        {
            get
            {
                return textureType;
            }
            private set
            {
                textureType = value;
                lTextureType.Content = value;
                lTextureType.ToolTip += Environment.NewLine + TextureTypeSelector.GetInstance(value);
            }
        }
        public string TextureFullPath { get; private set; }
        public int TextureWidth { get; private set; }
        public int TextureHeight { get; private set; }

        public event EventHandler<bool> OnItemClick;

        private string textureName;
        private string textureSubdirectory;
        private TextureType textureType;

        private Brush SelectedRow;
        private Brush UsualRow;
        #endregion


        private void InitializeVariables()
        {
            this.UsualRow = new SolidColorBrush((Color)Resources["UI_Background_DarkGray"]);
            this.SelectedRow = new SolidColorBrush((Color)Resources["UI_Background_Selection_Gray"]);
        }

        #region Data getters
        private void GetTextureName()
        {
            TextureName = TextureFullPath.Remove(0, TextureFullPath.LastIndexOf('\\') + 1);
        }

        private void GetTextureSubdirectory()
        {
            var rootSubdir = TextureTypeSelector.GetInstance(TextureType);
            textureSubdirectory = TextureFullPath.Remove(0, TextureFullPath.IndexOf(rootSubdir));
            TextureSubdirectory = textureSubdirectory.Replace("\\" + TextureName, "");
        }

        private void GetImageData()
        {
            try
            {
                Image image = new Image();
                BitmapImage imageSource = new BitmapImage();

                imageSource.BeginInit();
                imageSource.UriSource = new Uri(TextureFullPath);
                imageSource.EndInit();

                // storing w and h of image
                TextureWidth = imageSource.PixelWidth;
                TextureHeight = imageSource.PixelHeight;

                // small icon creation
                var scaledImageSource = new TransformedBitmap(
                    imageSource, 
                    new ScaleTransform(
                        56f / imageSource.PixelWidth, 
                        56f / imageSource.PixelHeight
                    )
                );

                // attach icon to label
                image.Source = scaledImageSource;
                image.Stretch = Stretch.UniformToFill;
                lSmallIcon.Content = image;

                imageSource = null;
                scaledImageSource = null;
                image = null;
            }
            catch { }
        }
        #endregion

        #region OnClick Event Handler and Subscription
        private void SubscribeToItemClickEvent()
        {
            this.MouseLeftButtonUp += OnClick;
            rectIconBorder.MouseLeftButtonUp += OnClick;
            lSmallIcon.MouseLeftButtonUp += OnClick;
            lTextureName.MouseLeftButtonUp += OnClick;
            lTextureSubdirectory.MouseLeftButtonUp += OnClick;
            lTextureType.MouseLeftButtonUp += OnClick;
        }

        private void OnClick(object sender, MouseButtonEventArgs e)
        {
            OnItemClick(this, true);
        }
        #endregion

        #region OnMouseHover Event Handlers
        private void SubscribeToMouseHoverEvents()
        {
            MainGrid.MouseEnter += OnMouseEnter;
            MainGrid.MouseLeave += OnMouseLeave;
        }

        private void OnMouseLeave(object sender, MouseEventArgs e)
        {
            MainGrid.Background = UsualRow;
        }

        private void OnMouseEnter(object sender, MouseEventArgs e)
        {
            MainGrid.Background = SelectedRow;
        }
        #endregion

    }
}
