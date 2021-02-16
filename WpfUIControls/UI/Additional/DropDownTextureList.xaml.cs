using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using WpfUIControls.API;

namespace WpfUIControls.UI.Additional
{
    /// <summary>
    /// Логика взаимодействия для DropDownTextureList.xaml
    /// </summary>
    public partial class DropDownTextureList : UserControl
    {
        public DropDownTextureList()
        {
            InitializeComponent();
            InitializeVariables();
        }


        public string PathToTextures { get; set; }
        public TextureType TextureType { get; set; }
        public event Action<TextureItemData> SelectedItemChanged;


        #region Common Functions
        private void InitializeVariables()
        {
            lCancelSearch.Visibility = Visibility.Collapsed;
        }

        private void OnSearchFieldClicked(Visibility visibility)
        {
            if (tbSearch.Text.Length == 0)
            {
                if (visibility == Visibility.Collapsed)
                {
                    tbSearch.Focus();
                }
                lSearch.Visibility = visibility;
            }
        }

        public void GetTextureSet()
        {
            // TODO: need to call this function when TextureType changed or when DropDownListOpened
            var texturePathSet = TextureSearch();
            AddRangeToScrollViewer(texturePathSet);
            texturePathSet = null;
        }
        #endregion

        #region Search
        private List<string> TextureSearch()
        {
            try
            {
                var searchPattern = new string[] { ".jpg", ".png", ".bmp" };
                var path = PathToTextures + "\\" + TextureTypeSelector.GetInstance(TextureType);
                return Directory.GetFiles(path, "*.*", SearchOption.AllDirectories).Where(file =>
                {
                    foreach (var item in searchPattern)
                    {
                        if (file.EndsWith(item))
                        {
                            return true;
                        }
                    }
                    return false;
                }).ToList();
            }
            catch
            {
                return null;
            }
        }

        private List<string> TextureSearchByName(string searchPattern, List<string> texturePathSet)
        {
            searchPattern = searchPattern.ToLower();
            var desiredObject = new List<string>();
            texturePathSet.ForEach(item =>
            {
                var name = item.Remove(0, item.LastIndexOf('\\') + 1).ToLower();
                if (name.Contains(searchPattern))
                {
                    desiredObject.Add(item);
                }
            });
            texturePathSet = null;
            return desiredObject;
        }

        private void ExecuteSearch()
        {
            if (PathToTextures != null && PathToTextures != String.Empty)
            {
                ShowDesiredItems(TextureSearchByName(tbSearch.Text, TextureSearch()));
            }
        }
        #endregion

        #region Show/Hide of Items of ScrollViewer
        private void ShowDesiredItems(List<string> texturePathSet)
        {
            foreach (TextureItemDetailed item in stackPanelTextureContainer.Children)
            {
                item.Visibility = Visibility.Collapsed;
                for (int i = 0; i < texturePathSet.Count; i++)
                {
                    if (item.TextureFullPath.Equals(texturePathSet[i]))
                    {
                        item.Visibility = Visibility.Visible;
                        texturePathSet.RemoveAt(i);
                        break;
                    }
                }
            }
            texturePathSet = null;
        }

        private void ShowAllItems()
        {
            foreach (TextureItemDetailed item in stackPanelTextureContainer.Children)
            {
                item.Visibility = Visibility.Visible;
            }
        }
        #endregion

        #region Adding to ScrollViewer
        private void AddRangeToScrollViewer(List<string> textureNameSet)
        {
            stackPanelTextureContainer.Children.Clear();
            if (textureNameSet != null)
            {
                textureNameSet.ForEach((item) =>
                {
                    AddToScrollViewer(CreateTextureItem(item));
                });
            }
        }

        private void AddToScrollViewer(TextureItemDetailed element)
        {
            stackPanelTextureContainer.Children.Add(element);
        }

        private TextureItemDetailed CreateTextureItem(string path)
        {
            TextureItemDetailed item = new TextureItemDetailed(path, TextureType);
            item.OnItemClick += Item_OnItemClick;
            return item;
        }
        #endregion

        #region Search Event Handlers
        private void lSearchIcon_MouseDown(object sender, MouseButtonEventArgs e)
        {
            ExecuteSearch();
        }

        private void lSearch_MouseDown(object sender, MouseButtonEventArgs e)
        {
            OnSearchFieldClicked(Visibility.Collapsed);
        }

        private void tbSearch_GotFocus(object sender, RoutedEventArgs e)
        {
            OnSearchFieldClicked(Visibility.Collapsed);
        }

        private void tbSearch_LostFocus(object sender, RoutedEventArgs e)
        {
            OnSearchFieldClicked(Visibility.Visible);
        }

        private void tbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (tbSearch.Text.Equals(String.Empty))
            {
                ShowAllItems();
                lCancelSearch.Visibility = Visibility.Collapsed;
            }
            else
            {
                lSearch.Visibility = Visibility.Collapsed;
                lCancelSearch.Visibility = Visibility.Visible;
            }
        }

        private void lCancelSearch_MouseDown(object sender, MouseButtonEventArgs e)
        {
            ShowAllItems();
            tbSearch.Text = String.Empty;
            OnSearchFieldClicked(Visibility.Visible);
            lCancelSearch.Visibility = Visibility.Collapsed;
        }
        #endregion

        private void Item_OnItemClick(object sender, bool e)
        {
            if (e == true && sender != null)
            {
                SelectedItemChanged(new TextureItemData(sender as TextureItemDetailed));
            }
        }

    }
}
