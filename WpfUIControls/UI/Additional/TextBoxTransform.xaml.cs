using System;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using WpfUIControls.API;

namespace WpfUIControls.UI.Additional
{
    /// <summary>
    /// Логика взаимодействия для TextBoxTransform.xaml
    /// </summary>
    public partial class TextBoxTransform : UserControl, IDisposable
    {
        public TextBoxTransform()
        {
            InitializeComponent();

            CoordColor = CoordColor.LightGray;
            ScrollBias = 1f;
            _useTextBoxOffset = true;
            UseValuesAboveZero = false;
        }


        #region Variables
        public string Text
        {
            get
            {
                return tbValue.Text;
            }
            set
            {
                if (IsTextAllowed(value))
                {
                    tbValue.Text = value;
                }
            }
        }
        public CoordColor CoordColor
        {
            get
            {
                Brush brush = rCoordColor.Fill;
                if (Equals(brush, CoordColors.Red))
                {
                    return CoordColor.Red;
                }
                else if (Equals(brush, CoordColors.Green))
                {
                    return CoordColor.Green;
                }
                else if (Equals(brush, CoordColors.Blue))
                {
                    return CoordColor.Blue;
                }
                else
                {
                    return CoordColor.LightGray;
                }
            }
            set
            {
                switch (value)
                {
                    case CoordColor.Red:
                        rCoordColor.Fill = CoordColors.Red;
                        break;
                    case CoordColor.Green:
                        rCoordColor.Fill = CoordColors.Green;
                        break;
                    case CoordColor.Blue:
                        rCoordColor.Fill = CoordColors.Blue;
                        break;
                    case CoordColor.LightGray:
                        rCoordColor.Fill = CoordColors.LightGray;
                        break;

                    default:
                        throw new ArgumentException();
                }
            }
        }
        public new ToolTip ToolTip
        {
            get
            {
                return (ToolTip)tbValue.ToolTip;
            }
            set
            {
                tbValue.ToolTip = value;
            }
        }
        public float ScrollBias { get; set; }
        public bool UseTextBoxOffset
        {
            get
            {
                return _useTextBoxOffset;
            }
            set
            {
                _useTextBoxOffset = value;
                if (_useTextBoxOffset)
                {
                    tbValue.Padding = new Thickness(5, 0, 0, 0);
                }
                else
                {
                    tbValue.Padding = new Thickness(0);
                }
            }
        }
        public bool UseValuesAboveZero { get; set; }
        public bool TextChangedEnabled { get; set; }
        public Action TextChanged;

        private bool _useTextBoxOffset;
        #endregion


        #region Event handlers

        #region Focus
        private void tbValue_MouseEnter(object sender, MouseEventArgs e)
        {
            rMain.Fill = Brushes.White;
        }

        private void tbValue_MouseLeave(object sender, MouseEventArgs e)
        {
            rMain.Fill = CoordColors.LightGray;
        }
        #endregion

        #region Numeric scroll
        private void tbValue_MouseWheel(object sender, MouseWheelEventArgs e)
        {
            string result = tbValue.Text;

            if (result == String.Empty)
            {
                result = "1.0";
            }

            if (e.Delta > 0)
            {
                result = (Math.Round(Convert.ToSingle(result.Replace(".", ",")) + ScrollBias, 4)).ToString().Replace(",", ".");
            }
            else if (e.Delta < 0)
            {
                result = (Math.Round(Convert.ToSingle(result.Replace(".", ",")) - ScrollBias, 4)).ToString().Replace(",", ".");

                if (UseValuesAboveZero && Convert.ToSingle(result.Replace(".", ",")) <= 0)
                {
                    return;
                }
            }

            if (!result.Contains("."))
            {
                result += ".0";
            }

            tbValue.Text = result;
            if (TextChangedEnabled)
            {
                TextChanged();
            }
        }
        #endregion

        #region Only numerics
        private void tbValue_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !IsTextAllowed(e.Text);
            if (!e.Handled && TextChangedEnabled)
            {
                if (tbValue.SelectedText == String.Empty)
                {
                    int caretIndex = tbValue.CaretIndex;
                    if (caretIndex == tbValue.Text.Length)
                    {
                        tbValue.Text += e.Text;
                        e.Handled = true;
                        tbValue.CaretIndex = ++caretIndex;
                    }
                    else if (caretIndex == 0)
                    {
                        tbValue.Text = e.Text + tbValue.Text;
                        e.Handled = true;
                    }
                    else
                    {
                        tbValue.Text.Insert(caretIndex, e.Text);
                    }
                }
                else
                {
                    tbValue.Text = e.Text;
                    e.Handled = true;
                    ++tbValue.CaretIndex;
                }

                TextChanged();
            }
        }

        private void tbValue_Pasting(object sender, DataObjectPastingEventArgs e)
        {
            if (e.DataObject.GetDataPresent(typeof(string)))
            {
                string text = (string)e.DataObject.GetData(typeof(string));
                if (!IsTextAllowed(text))
                {
                    e.CancelCommand();
                }
            }
            else
            {
                e.CancelCommand();
            }
        }

        private bool IsTextAllowed(string text)
        {
            Regex regex = new Regex("[^0-9.-]+");
            return !regex.IsMatch(text);
        }
        #endregion

        #endregion


        public void Dispose()
        {
            CoordColors.Dispose();
            Text = string.Empty;
            ToolTip = null;
            ScrollBias = 0;
        }

    }
}
