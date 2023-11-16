namespace PhotoFramePlugin.View
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Windows.Forms;
    using PhotoFramePlugin.Model;
    using PhotoFramePlugin.Wrapper;

    public partial class MainForm : Form
    {
        /// <summary>
        /// Цвет, если всё правильно.
        /// </summary>
        private readonly Color _correctСolor = Color.White;

        /// <summary>
        /// Цвет, если есть ошибка.
        /// </summary>
        private readonly Color _errorColor = Color.LightPink;

        private readonly Dictionary<string, bool> _dictionaryErrors = new Dictionary<string, bool>()
        {
            { nameof(WidthInsideFrameTextBox), true },
            { nameof(HeightInsideFrameTextBox), true },
            { nameof(FrameWidthTextBox), true },
            { nameof(FrameHeightTextBox), true },
            { nameof(FrameThicknessTextBox), true },
        };

        private readonly PhotoFrameParameters _parameters = new PhotoFrameParameters();
        private readonly PhotoFrameBuilder _builder = new PhotoFrameBuilder();

        private readonly Parameter _widthInsideFrame = new Parameter
        {
            MaxValue = 1200,
            MinValue = 100,
            Value = 100,
        };

        private readonly Parameter _heightInsideFrame = new Parameter
        {
            MaxValue = 1200,
            MinValue = 100,
            Value = 100,
        };

        private readonly Parameter _frameWidth = new Parameter
        {
            MaxValue = 1210,
            MinValue = 110,
            Value = 110,
        };

        private readonly Parameter _frameHeight = new Parameter
        {
            MaxValue = 1210,
            MinValue = 110,
            Value = 110,
        };

        private readonly Parameter _frameThickness = new Parameter
        {
            MaxValue = 30,
            MinValue = 10,
            Value = 10,
        };

        private readonly Parameter _backWallThickness = new Parameter
        {
            MaxValue = 2,
            MinValue = 2,
            Value = 2,
        };

        private readonly ToolTip _toolTip = new ToolTip();

        /// <summary>
        /// Initializes a new instance of the <see cref="MainForm"/> class.
        /// </summary>
        public MainForm()
        {
            InitializeComponent();
        }

        private void CheckFormOnErrors()
        {
            foreach (var error in _dictionaryErrors)
            {
                if (error.Value == false)
                {
                    BuildFigure.Enabled = false;
                    return;
                }
            }
            BuildFigure.Enabled = true;
        }

        private void CheckingDependentWidthParameters()
        {
            if (!Validator.ValidateTwoParameter(_widthInsideFrame, _frameWidth))
            {
                WidthInsideFrameTextBox.BackColor = _errorColor;
                FrameWidthTextBox.BackColor = _errorColor;
                _dictionaryErrors[nameof(WidthInsideFrameTextBox)] = false;
                _dictionaryErrors[nameof(FrameWidthTextBox)] = false;
                _toolTip.SetToolTip(WidthInsideFrameTextBox, "Ширина внутренней рамки не должна превышать ширину внешней рамки");
                _toolTip.SetToolTip(FrameWidthTextBox, "Ширина внутренней рамки не должна превышать ширину внешней рамки");
            }
            else
            {
                WidthInsideFrameTextBox.BackColor = _correctСolor;
                FrameWidthTextBox.BackColor = _correctСolor;
                _dictionaryErrors[nameof(WidthInsideFrameTextBox)] = true;
                _dictionaryErrors[nameof(FrameWidthTextBox)] = true;
                _toolTip.SetToolTip(WidthInsideFrameTextBox, "");
                _toolTip.SetToolTip(FrameWidthTextBox, "");
            }
        }

        private void CheckingDependentHeightParameters()
        {
            if (!Validator.ValidateTwoParameter(_heightInsideFrame, _frameHeight))
            {
                HeightInsideFrameTextBox.BackColor = _errorColor;
                FrameHeightTextBox.BackColor = _errorColor;
                _dictionaryErrors[nameof(HeightInsideFrameTextBox)] = false;
                _dictionaryErrors[nameof(FrameHeightTextBox)] = false;
                _toolTip.SetToolTip(HeightInsideFrameTextBox, "Высота внутренней рамки не должна превышать ширину внешней рамки");
                _toolTip.SetToolTip(FrameHeightTextBox, "Высота внутренней рамки не должна превышать ширину внешней рамки");
            }
            else
            {
                HeightInsideFrameTextBox.BackColor = _correctСolor;
                FrameHeightTextBox.BackColor = _correctСolor;
                _dictionaryErrors[nameof(HeightInsideFrameTextBox)] = true;
                _dictionaryErrors[nameof(FrameHeightTextBox)] = true;
                _toolTip.SetToolTip(HeightInsideFrameTextBox, "");
                _toolTip.SetToolTip(FrameHeightTextBox, "");
            }
        }

        private void BuildFigureClick(object sender, EventArgs e)
        {
            _parameters.Parameters = new Dictionary<ParameterType, Parameter>
            {
                {ParameterType.WidthInsideFrame, _widthInsideFrame},
                {ParameterType.HeightInsideFrame, _heightInsideFrame},
                {ParameterType.FrameWidth, _frameWidth},
                {ParameterType.FrameHeight, _frameHeight},
                {ParameterType.FrameThickness, _frameThickness},
                {ParameterType.BackWallThickness, _backWallThickness}
            };

            _builder.BuildPhotoFrame(_parameters);
        }

        private void WidthInsideFrameTextBox_TextChanged(object sender, EventArgs e)
        {
            if (WidthInsideFrameTextBox.Text != string.Empty)
            {
                _widthInsideFrame.Value = System.Convert.ToSingle(WidthInsideFrameTextBox.Text);
                if (!Validator.Validate(_widthInsideFrame))
                {
                    WidthInsideFrameTextBox.BackColor = _errorColor;
                    _toolTip.SetToolTip(WidthInsideFrameTextBox, "Ширина внутри рамки должна быть в диапазоне от 100 до 1200 мм");
                    _dictionaryErrors[nameof(WidthInsideFrameTextBox)] = false;
                    CheckFormOnErrors();
                }
                else
                {
                    WidthInsideFrameTextBox.BackColor = _correctСolor;
                    _toolTip.SetToolTip(WidthInsideFrameTextBox, "");
                    _dictionaryErrors[nameof(WidthInsideFrameTextBox)] = true;
                    CheckingDependentWidthParameters();
                    CheckFormOnErrors();
                }
            }
        }

        private void HeightInsideFrameTextBox_TextChanged(object sender, EventArgs e)
        {
            if (HeightInsideFrameTextBox.Text != string.Empty)
            {
                _heightInsideFrame.Value = System.Convert.ToSingle(HeightInsideFrameTextBox.Text);
                if (!Validator.Validate(_heightInsideFrame))
                {
                    HeightInsideFrameTextBox.BackColor = _errorColor;
                    _toolTip.SetToolTip(HeightInsideFrameTextBox, "Высота внутри рамки должна быть в диапазоне от 100 до 1200 мм");
                    _dictionaryErrors[nameof(HeightInsideFrameTextBox)] = false;
                    CheckFormOnErrors();
                }
                else
                {
                    HeightInsideFrameTextBox.BackColor = _correctСolor;
                    _toolTip.SetToolTip(HeightInsideFrameTextBox, "");
                    _dictionaryErrors[nameof(HeightInsideFrameTextBox)] = true;
                    CheckingDependentHeightParameters();
                    CheckFormOnErrors();
                }
            }
        }

        private void FrameWidthTextBox_TextChanged(object sender, EventArgs e)
        {
            if (FrameWidthTextBox.Text != string.Empty)
            {
                _frameWidth.Value = System.Convert.ToSingle(FrameWidthTextBox.Text);
                if (!Validator.Validate(_frameWidth))
                {
                    FrameWidthTextBox.BackColor = _errorColor;
                    _toolTip.SetToolTip(FrameWidthTextBox, "Ширина внешней рамки должна быть в диапазоне от 110 до 1210 мм");
                    _dictionaryErrors[nameof(FrameWidthTextBox)] = false;
                    CheckFormOnErrors();
                }
                else
                {
                    FrameWidthTextBox.BackColor = _correctСolor;
                    _toolTip.SetToolTip(FrameWidthTextBox, "");
                    _dictionaryErrors[nameof(FrameWidthTextBox)] = true;
                    CheckingDependentWidthParameters();
                    CheckFormOnErrors();
                }
            }
        }

        private void FrameHeightTextBox_TextChanged(object sender, EventArgs e)
        {
            if (FrameHeightTextBox.Text != string.Empty)
            {
                _frameHeight.Value = System.Convert.ToSingle(FrameHeightTextBox.Text);
                if (!Validator.Validate(_frameHeight))
                {
                    FrameHeightTextBox.BackColor = _errorColor;
                    _toolTip.SetToolTip(FrameHeightTextBox, "Высота внешней рамки должна быть в диапазоне от 110 до 1210 мм");
                    _dictionaryErrors[nameof(FrameHeightTextBox)] = false;
                    CheckFormOnErrors();
                }
                else
                {
                    FrameHeightTextBox.BackColor = _correctСolor;
                    _toolTip.SetToolTip(FrameHeightTextBox, "");
                    _dictionaryErrors[nameof(FrameHeightTextBox)] = true;
                    CheckingDependentHeightParameters();
                    CheckFormOnErrors();
                }
            }
        }

        private void FrameThicknessTextBox_TextChanged(object sender, EventArgs e)
        {
            if (FrameThicknessTextBox.Text != string.Empty)
            {
                _frameThickness.Value = System.Convert.ToSingle(FrameThicknessTextBox.Text);
                if (!Validator.Validate(_frameThickness))
                {
                    FrameThicknessTextBox.BackColor = _errorColor;
                    _toolTip.SetToolTip(FrameThicknessTextBox, "Толщина рамки должна быть в диапазоне от 10 до 30 мм");
                    _dictionaryErrors[nameof(FrameThicknessTextBox)] = false;
                    CheckFormOnErrors();
                }
                else
                {
                    FrameThicknessTextBox.BackColor = _correctСolor;
                    _toolTip.SetToolTip(FrameThicknessTextBox, "");
                    _dictionaryErrors[nameof(FrameThicknessTextBox)] = true;
                    CheckFormOnErrors();
                }
            }
        }

        private void WidthInsideFrameTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (!char.IsDigit(number) && number != 8 && number != 44)
            {
                e.Handled = true;
            }
        }

        private void HeightInsideFrameTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (!char.IsDigit(number) && number != 8 && number != 44)
            {
                e.Handled = true;
            }
        }

        private void FrameWidthTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (!char.IsDigit(number) && number != 8 && number != 44)
            {
                e.Handled = true;
            }
        }

        private void FrameHeightTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (!char.IsDigit(number) && number != 8 && number != 44)
            {
                e.Handled = true;
            }
        }

        private void FrameThicknessTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (!char.IsDigit(number) && number != 8 && number != 44)
            {
                e.Handled = true;
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            var isFormClosing = MessageBox.Show("Вы действительно хотите выйти??", "Выход из программы",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            e.Cancel = !(isFormClosing == DialogResult.Yes);
        }
    }
}