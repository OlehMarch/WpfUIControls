using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using WpfUIControls.API;

namespace WpfUIControls.UI.Main
{
    /// <summary>
    /// Логика взаимодействия для EntityParamHolder.xaml
    /// </summary>
    public partial class EntityParamHolder : UserControl, IDisposable
    {
        public EntityParamHolder()
        {
            InitializeComponent();
            InitializeVariables();
        }


        public List<UserControl> Entities
        {
            get
            {
                return _entities;
            }
            set
            {
                _entities.Clear();
                _entities = value;
                UnSubscribeExpanders();
                SetUpEntities();
                AddToGrid();
            }
        }
        private List<UserControl> _entities;
        private Brush _lightBlack;
        private Brush _headerDarkGray;
        private Brush _lightGray;


        private void InitializeVariables()
        {
            _lightBlack = new SolidColorBrush((Color)Resources["UI_Background_LightBlack"]);
            _headerDarkGray = new SolidColorBrush((Color)Resources["UI_Header_DarkGray"]);
            _lightGray = new SolidColorBrush((Color)Resources["UI_Foreground_LightGray"]);
            _entities = new List<UserControl>();
            AddRow();
        }

        private void SetUpEntities()
        {
            _entities.ForEach(item =>
            {
                item.Width = double.NaN;
                item.Height = double.NaN;
                item.Margin = new Thickness(0);
            });
        }

        private void AddToGrid()
        {
            int i = 0;

            foreach (var item in _entities)
            {
                var expander = AddExpander(item.GetType().ToString(), item);
                SubscribeExpander(expander);
                Grid.SetRow(expander, i++);
                Grid.SetColumn(expander, 0);
                MainGrid.Children.Add(expander);
                expander = null;

                AddRow();
                // Uncomment next two lines if you need to resize height of items
                //AddGridSplitter(i++);
                //AddRow();
            }
        }

        private Expander AddExpander(string entityParamType, UserControl control)
        {
            return new Expander()
            {
                FontSize = 15,
                IsExpanded = true,
                Header = entityParamType.GetExpanderHeader(),
                Name = "Expander" + entityParamType.GetExpanderHeader(),
                Content = control,
                Background = _lightBlack,
                Foreground = _lightGray,
                Width = double.NaN,
                Height = double.NaN,
                Margin = new Thickness(0),
                Padding = new Thickness(5)
            };
        }

        private void AddGridSplitter(int rowIndex)
        {
            GridSplitter splitter = new GridSplitter();
            splitter.VerticalAlignment = VerticalAlignment.Stretch;
            splitter.HorizontalAlignment = HorizontalAlignment.Stretch;
            splitter.ResizeBehavior = GridResizeBehavior.PreviousAndNext;
            splitter.Height = 5;
            splitter.Margin = new Thickness(0, 0, 0, 0);
            splitter.Background = new SolidColorBrush(Colors.Transparent);

            Grid.SetRow(splitter, rowIndex);
            Grid.SetColumn(splitter, 0);
            MainGrid.Children.Add(splitter);
        }

        private void AddRow()
        {
            var rd = new RowDefinition();
            rd.Height = GridLength.Auto;
            MainGrid.RowDefinitions.Add(rd);
        }

        #region Subscription
        private void SubscribeExpander(Expander expander)
        {
            expander.MouseEnter += Expander_MouseEnter;
            expander.MouseLeave += Expander_MouseLeave;
        }

        private void UnSubscribeExpanders()
        {
            foreach (var item in MainGrid.Children)
            {
                if (item is Expander)
                {
                    (item as Expander).MouseEnter -= Expander_MouseEnter;
                    (item as Expander).MouseLeave -= Expander_MouseLeave;
                }
            }
        }

        private void Expander_MouseEnter(object sender, MouseEventArgs e)
        {
            (sender as Expander).Background = _headerDarkGray;
        }

        private void Expander_MouseLeave(object sender, MouseEventArgs e)
        {
            (sender as Expander).Background = _lightBlack;
        }

        #endregion

        public void Dispose()
        {
            _lightGray = null;
            _lightBlack = null;
            _headerDarkGray = null;
            _entities.Clear();
            _entities = null;
            UnSubscribeExpanders();
            MainGrid.Children.Clear();
        }

    }
}

// Add custom expander styles