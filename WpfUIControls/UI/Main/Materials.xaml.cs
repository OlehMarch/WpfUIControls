using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using WpfUIControls.API;
using WpfUIControls.UI.Additional;

namespace WpfUIControls.UI.Main
{
    /// <summary>
    /// Логика взаимодействия для Materials.xaml
    /// </summary>
    public partial class Materials : UserControl
    {
        public Materials()
        {
            InitializeComponent();
            InitializeVariables();
        }


        public TextureItemData TextureItemData { get; private set; }
        public string PathToTextures
        {
            get
            {
                return dropDownTextureList.PathToTextures;
            }
            set
            {
                dropDownTextureList.PathToTextures = value;
            }
        }

        private bool isDropDownTextureListShown;
        private Storyboard sbDdtlShow;
        private Storyboard sbDdtlHide;
        private Brush SelectedRow;
        private Brush UsualRow;


        #region Common Functions
        private void InitializeVariables()
        {
            this.UsualRow = new SolidColorBrush((Color)Resources["UI_Background_DarkGray"]);
            this.SelectedRow = new SolidColorBrush((Color)Resources["UI_Background_Selection_Gray"]);

            dropDownTextureList.SelectedItemChanged += DropDownTextureList_SelectedItemChanged;
            dropDownTextureList.Opacity = 0;
            DropDownTextureListAnimationCreation(ref sbDdtlShow, 0, 1, 0.6);
            DropDownTextureListAnimationCreation(ref sbDdtlHide, 1, 0, 0.2);
        }

        private void DropDownTextureListAnimationCreation(ref Storyboard storyboard, double from, double to, double duration)
        {
            DoubleAnimation animation = new DoubleAnimation();
            animation.From = from;
            animation.To = to;
            animation.Duration = new Duration(TimeSpan.FromSeconds(duration));
            storyboard = new Storyboard();
            storyboard.Children.Add(animation);
            Storyboard.SetTargetName(animation, dropDownTextureList.Name);
            Storyboard.SetTargetProperty(animation, new PropertyPath(DropDownTextureList.OpacityProperty));
        }

        private void TextureSelectorIconAnimationCreation(double from, double to)
        {
            var animation = new DoubleAnimation();
            animation.From = from;
            animation.To = to;
            animation.Duration = new Duration(TimeSpan.FromSeconds(0.2));
            var rotateTransform = new RotateTransform();
            lTextureSelectorIcon.RenderTransform = rotateTransform;
            lTextureSelectorIcon.RenderTransformOrigin = new Point(0.5, 0.5);
            rotateTransform.BeginAnimation(RotateTransform.AngleProperty, animation);
        }
        #endregion

        #region Texture Selector Control Group
        private void lTextureSelection_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (isDropDownTextureListShown == false)
            {
                sbDdtlShow.Begin(this);
                lTextureSelection.Content = "Hide Texture Selector";
                TextureSelectorIconAnimationCreation(0, 180);
            }
            else
            {
                sbDdtlHide.Begin(this);
                lTextureSelection.Content = "Show Texture Selector";
                TextureSelectorIconAnimationCreation(180, 360);
            }
            isDropDownTextureListShown = !isDropDownTextureListShown;
        }

        private void lTextureSelection_MouseEnter(object sender, MouseEventArgs e)
        {
            lTextureSelection.Background = SelectedRow;
        }

        private void lTextureSelection_MouseLeave(object sender, MouseEventArgs e)
        {
            lTextureSelection.Background = UsualRow;
        }
        #endregion

        private void cbTextureType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            TextureType stub = TextureType.MT;
            var selectedIndex = cbTextureType.SelectedIndex;
            if (selectedIndex >= 0 && selectedIndex < stub.GetTypeQuantity())
            {
                dropDownTextureList.TextureType = (TextureType)selectedIndex;
                dropDownTextureList.GetTextureSet();
            }
        }

        private void DropDownTextureList_SelectedItemChanged(TextureItemData obj)
        {
            lLargeIcon.Content = obj.Icon;
            lWidthValue.Content = obj.Width + " px";
            lHeightValue.Content = obj.Height + " px";
            TextureItemData = obj;
        }

    }
}

// TODO: Make label of texture selection more attractive
// TODO: Need to add to lTextureSelectorIcon arrow icon, when click event raised - switch to another or animate