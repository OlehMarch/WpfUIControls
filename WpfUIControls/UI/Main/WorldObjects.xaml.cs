using System;
using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using WpfUIControls.API;
using WpfUIControls.UI.Additional;

namespace WpfUIControls.UI.Main
{
    /// <summary>
    /// Логика взаимодействия для WorldObjects.xaml
    /// </summary>
    public partial class WorldObjects : UserControl
    {
        public WorldObjects()
        {
            InitializeComponent();
            InitializeVariables();
        }


        #region Variables
        public List<WorldObjectModel> Objects { get; private set; }

        private bool _isObjectIdShown;
        private Brush _selectedRow;
        private Brush _usualRow;

        private const ushort SCROLL_BAR_WIDTH = 10;
        private const string DETAILS_TYPE = "Type";
        private const string DETAILS_OBJECT_ID = "Object ID";
        private const string DETAILS_TYPE_HINT = "Click to change from Type to Object ID";
        private const string DETAILS_OBJECT_ID_HINT = "Click to change from Object ID to Type";
        #endregion


        #region Common Functions
        private void InitializeVariables()
        {
            _isObjectIdShown = false;

            _usualRow = new SolidColorBrush((Color)Resources["UI_Background_DarkGray"]);
            _selectedRow = new SolidColorBrush((Color)Resources["UI_Background_Selection_Gray"]);

            AddToScrollViewer(CreateRow("Landscape", "", WorldObjectType.Folder, WorldObjectRowHierarchyLevel.Root));
            AddToScrollViewer(CreateRow("Mesh",      "", WorldObjectType.Folder, WorldObjectRowHierarchyLevel.Folder));
            AddToScrollViewer(CreateRow("Light",     "", WorldObjectType.Folder, WorldObjectRowHierarchyLevel.Folder));
            AddToScrollViewer(CreateRow("Sound",     "", WorldObjectType.Folder, WorldObjectRowHierarchyLevel.Folder));
        }

        private void DetailInfoSwitched()
        {
            foreach (var item in ScrollViewerStackPanel.Children)
            {
                (item as WorldObjectRow).SwitchDetailInfo(_isObjectIdShown);
            }
        }

        private void AddObjectToSpecificFolder()
        {
            int meshPos = 2;
            int lightPos = 3;
            int soundPos = 4;
            int pos = -1;

            Objects.ForEach(item =>
            {
                switch (item.Type)
                {
                    case WorldObjectType.Mesh:
                        pos = meshPos;
                        break;
                    case WorldObjectType.Light:
                    case WorldObjectType.SpotLight:
                        pos = lightPos;
                        break;
                    case WorldObjectType.Sound:
                        pos = soundPos;
                        break;

                    default:
                        pos = ScrollViewerStackPanel.Children.Count - 1;
                        break;
                }

                meshPos++;
                lightPos++;
                soundPos++;

                ScrollViewerStackPanel.Children.Insert(pos, CreateRow(item.Label, item.ID, item.Type, item.HierarchyLevel));
            });
        }
        #endregion

        #region Scroll Viewer Event Handlers
        public void AddRangeToScrollViewer(List<WorldObjectModel> objects)
        {
            Objects = objects;
            AddObjectToSpecificFolder();
        }

        private void AddToScrollViewer(WorldObjectRow row)
        {
            ScrollViewerStackPanel.Children.Add(row);
        }

        private WorldObjectRow CreateRow(string label, string id, WorldObjectType type, WorldObjectRowHierarchyLevel hierarchyLevel)
        {
            WorldObjectRow row = new WorldObjectRow(SCROLL_BAR_WIDTH)
            {
                Label = label,
                ID = id,
                Type = type,
                HierarchyLevel = hierarchyLevel
            };
            row.EntityVisibilityChanged += WorldObjects_EntityVisibilityChanged;
            return row;
        }

        private void WorldObjects_EntityVisibilityChanged(bool isVisible, string id)
        {
            // TODO: Raise an event of Entity Visibility Changed
        }
        #endregion

        #region Label Details Action Handling
        private void labelDetails_MouseEnter(object sender, MouseEventArgs e)
        {
            labelDetails.Background = _selectedRow;
        }

        private void labelDetails_MouseLeave(object sender, MouseEventArgs e)
        {
            labelDetails.Background = _usualRow;
        }

        private void labelDetails_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (!_isObjectIdShown)
            {
                labelDetails.Content = DETAILS_OBJECT_ID;
                labelDetails.ToolTip = DETAILS_OBJECT_ID_HINT;
            }
            else
            {
                labelDetails.Content = DETAILS_TYPE;
                labelDetails.ToolTip = DETAILS_TYPE_HINT;
            }
            _isObjectIdShown = !_isObjectIdShown;
            
            DetailInfoSwitched();
        }
        #endregion

    }
}
