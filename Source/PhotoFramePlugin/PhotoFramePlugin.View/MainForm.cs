namespace PhotoFramePlugin.View
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Windows.Forms;
    using PhotoFramePlugin.Model;
    using PhotoFramePlugin.Wrapper;

    /// <summary>
    /// MainForm.
    /// </summary>
    internal partial class MainForm : Form
    {
        /// <summary>
        /// Минимальное пороговое значение.
        /// </summary>
        private const int MIN_THRESHOLD_VALUE = 10;

        /// <summary>
        /// Максимальное пороговое значение.
        /// </summary>
        private const int MAX_THRESHOLD_VALUE = 50;

        /// <summary>
        /// Цвет, если всё правильно.
        /// </summary>
        private readonly Color _correctСolor = Color.White;

        /// <summary>
        /// Цвет, если есть ошибка.
        /// </summary>
        private readonly Color _errorColor = Color.LightPink;

        /// <summary>
        /// Экземпляр класса PhotoFrameBuilder.
        /// </summary>
        private readonly PhotoFrameBuilder _builder = new PhotoFrameBuilder();

        /// <summary>
        /// Экземпляр класса PhotoFrameParameters.
        /// </summary>
        private readonly PhotoFrameParameters _parameters = new PhotoFrameParameters();

        /// <summary>
        /// Ошибки валидации.
        /// </summary>
        private readonly Dictionary<string, bool> _dictionaryErrors = new Dictionary<string, bool>()
        {
            { nameof(WidthInsideFrameTextBox), true },
            { nameof(HeightInsideFrameTextBox), true },
            { nameof(FrameWidthTextBox), true },
            { nameof(FrameHeightTextBox), true },
            { nameof(FrameThicknessTextBox), true },
            { nameof(FrameRoundingTextBox), true },
        };

        /// <summary>
        /// Ширина внутри рамки.
        /// </summary>
        private readonly Parameter _widthInsideFrame = new Parameter
        {
            MaxValue = 1200,
            MinValue = 100,
            Value = 100,
        };

        /// <summary>
        /// Высота внутри рамки.
        /// </summary>
        private readonly Parameter _heightInsideFrame = new Parameter
        {
            MaxValue = 1200,
            MinValue = 100,
            Value = 100,
        };

        /// <summary>
        /// Ширина рамки.
        /// </summary>
        private readonly Parameter _frameWidth = new Parameter
        {
            MaxValue = 1210,
            MinValue = 110,
            Value = 110,
        };

        /// <summary>
        /// Высота рамки.
        /// </summary>
        private readonly Parameter _frameHeight = new Parameter
        {
            MaxValue = 1210,
            MinValue = 110,
            Value = 110,
        };

        /// <summary>
        /// Толщина рамки.
        /// </summary>
        private readonly Parameter _frameThickness = new Parameter
        {
            MaxValue = 30,
            MinValue = 10,
            Value = 10,
        };

        /// <summary>
        /// Толщина задней стенки.
        /// </summary>
        private readonly Parameter _backWallThickness = new Parameter
        {
            MaxValue = 2,
            MinValue = 2,
            Value = 2,
        };

        /// <summary>
        /// Скругление рамки.
        /// </summary>
        private readonly Parameter _frameRounding = new Parameter
        {
            MaxValue = 8,
            MinValue = 1,
            Value = 1,
        };

        /// <summary>
        /// Подсказки для полей.
        /// </summary>
        private readonly ToolTip _toolTip = new ToolTip();

        /// <summary>
        /// Initializes a new instance of the <see cref="MainForm"/> class.
        /// </summary>
        public MainForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Проверка формы на наличие ошибок.
        /// </summary>
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

        /// <summary>
        /// Проверка зависимых параметров ширины.
        /// </summary>
        private void CheckingDependentWidthParameters()
        {
            if (!Validator.DependentParameterValidation(
                _widthInsideFrame,
                _frameWidth,
                MIN_THRESHOLD_VALUE,
                MAX_THRESHOLD_VALUE))
            {
                WidthInsideFrameTextBox.BackColor = _errorColor;
                FrameWidthTextBox.BackColor = _errorColor;
                _dictionaryErrors[nameof(WidthInsideFrameTextBox)] = false;
                _dictionaryErrors[nameof(FrameWidthTextBox)] = false;
                _toolTip.SetToolTip(
                    WidthInsideFrameTextBox,
                    "Ширина внутренней рамки не должна превышать ширину внешней рамки");
                _toolTip.SetToolTip(
                    FrameWidthTextBox,
                    "Ширина внутренней рамки не должна превышать ширину внешней рамки");
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

        /// <summary>
        /// Проверка зависимых параметров высоты.
        /// </summary>
        private void CheckingDependentHeightParameters()
        {
            if (!Validator.DependentParameterValidation(
                _heightInsideFrame,
                _frameHeight,
                MIN_THRESHOLD_VALUE,
                MAX_THRESHOLD_VALUE))
            {
                HeightInsideFrameTextBox.BackColor = _errorColor;
                FrameHeightTextBox.BackColor = _errorColor;
                _dictionaryErrors[nameof(HeightInsideFrameTextBox)] = false;
                _dictionaryErrors[nameof(FrameHeightTextBox)] = false;
                _toolTip.SetToolTip(
                    HeightInsideFrameTextBox,
                    "Высота внутренней рамки не должна превышать ширину внешней рамки");
                _toolTip.SetToolTip(
                    FrameHeightTextBox,
                    "Высота внутренней рамки не должна превышать ширину внешней рамки");
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
                { ParameterType.WidthInsideFrame, _widthInsideFrame },
                { ParameterType.HeightInsideFrame, _heightInsideFrame },
                { ParameterType.FrameWidth, _frameWidth },
                { ParameterType.FrameHeight, _frameHeight },
                { ParameterType.FrameThickness, _frameThickness },
                { ParameterType.BackWallThickness, _backWallThickness },
                { ParameterType.FrameRounding, _frameRounding }
            };

            _builder.BuildPhotoFrame(_parameters, FrameRoundingCheckBox.Checked, EllipseFrameCheckBox.Checked);
        }

        private void WidthInsideFrameTextBox_TextChanged(object sender, EventArgs e)
        {
            if (WidthInsideFrameTextBox.Text != string.Empty)
            {
                _widthInsideFrame.Value = System.Convert.ToSingle(WidthInsideFrameTextBox.Text);
                if (!Validator.ValidateParameter(_widthInsideFrame))
                {
                    WidthInsideFrameTextBox.BackColor = _errorColor;
                    _toolTip.SetToolTip(
                        WidthInsideFrameTextBox,
                        "Ширина внутри рамки должна быть в диапазоне от 100 до 1200 мм");
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
                if (!Validator.ValidateParameter(_heightInsideFrame))
                {
                    HeightInsideFrameTextBox.BackColor = _errorColor;
                    _toolTip.SetToolTip(
                        HeightInsideFrameTextBox,
                        "Высота внутри рамки должна быть в диапазоне от 100 до 1200 мм");
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
                if (!Validator.ValidateParameter(_frameWidth))
                {
                    FrameWidthTextBox.BackColor = _errorColor;
                    _toolTip.SetToolTip(
                        FrameWidthTextBox,
                        "Ширина внешней рамки должна быть в диапазоне от 110 до 1210 мм");
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
                if (!Validator.ValidateParameter(_frameHeight))
                {
                    FrameHeightTextBox.BackColor = _errorColor;
                    _toolTip.SetToolTip(
                        FrameHeightTextBox,
                        "Высота внешней рамки должна быть в диапазоне от 110 до 1210 мм");
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
                if (!Validator.ValidateParameter(_frameThickness))
                {
                    FrameThicknessTextBox.BackColor = _errorColor;
                    _toolTip.SetToolTip(
                        FrameThicknessTextBox,
                        "Толщина рамки должна быть в диапазоне от 10 до 30 мм");
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

        private void FrameRoundingTextBox_TextChanged(object sender, EventArgs e)
        {
            if (FrameRoundingTextBox.Text != string.Empty)
            {
                _frameRounding.Value = System.Convert.ToSingle(FrameRoundingTextBox.Text);
                if (!Validator.ValidateParameter(_frameRounding))
                {
                    FrameRoundingTextBox.BackColor = _errorColor;
                    _toolTip.SetToolTip(
                        FrameRoundingTextBox,
                        "Скругление рамки должна быть в диапазоне от 1 до 8 мм");
                    _dictionaryErrors[nameof(FrameRoundingTextBox)] = false;
                    CheckFormOnErrors();
                }
                else
                {
                    FrameRoundingTextBox.BackColor = _correctСolor;
                    _toolTip.SetToolTip(FrameRoundingTextBox, "");
                    _dictionaryErrors[nameof(FrameRoundingTextBox)] = true;
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
            DialogResult isFormClosing;
            isFormClosing = MessageBox.Show(
                "Вы действительно хотите выйти??",
                "Выход из программы",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            e.Cancel = !(isFormClosing == DialogResult.Yes);
        }

        private void FrameRoundingCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (FrameRoundingCheckBox.CheckState == CheckState.Checked)
            {
                FrameRoundingTextBox.Enabled = true;
                _frameRounding.Value = System.Convert.ToSingle(FrameRoundingTextBox.Text);
                if (!Validator.ValidateParameter(_frameRounding))
                {
                    FrameRoundingTextBox.BackColor = _errorColor;
                    _toolTip.SetToolTip(
                        FrameRoundingTextBox,
                        "Скругление рамки должна быть в диапазоне от 1 до 8 мм");
                    _dictionaryErrors[nameof(FrameRoundingTextBox)] = false;
                    CheckFormOnErrors();
                }
            }
            else
            {
                FrameRoundingTextBox.Enabled = false;
                _dictionaryErrors[nameof(FrameRoundingTextBox)] = true;
                CheckFormOnErrors();
            }
        }
    }
}