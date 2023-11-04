using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using Kompas6API5;
using Kompas6Constants3D;
using PhotoFramePlugin.Model;

namespace PhotoFramePlugin.View
{
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

        private Dictionary<string, bool> _dictionaryErrors = new Dictionary<string, bool>()
        {
            { nameof(WidthInsideFrameTextBox), true },
            { nameof(HeightInsideFrameTextBox), true },
            { nameof(FrameWidthTextBox), true },
            { nameof(FrameHeightTextBox), true },
            { nameof(FrameThicknessTextBox), true }
        };

        private PhotoFrameParameters _parameters = new PhotoFrameParameters();

        private Parameter _widthInsideFrame = new Parameter
        {
            MaxValue = 1200,
            MinValue = 100,
            Value = 100
        };

        private Parameter _heightInsideFrame = new Parameter
        {
            MaxValue = 1200,
            MinValue = 100,
            Value = 100
        };

        private Parameter _frameWidth = new Parameter
        {
            MaxValue = 1210,
            MinValue = 110,
            Value = 110
        };

        private Parameter _frameHeight = new Parameter
        {
            MaxValue = 1210,
            MinValue = 110,
            Value = 110
        };

        private Parameter _frameThickness = new Parameter
        {
            MaxValue = 30,
            MinValue = 10,
            Value = 10
        };

        private Parameter _backWallThickness = new Parameter
        {
            MaxValue = 2,
            MinValue = 2,
            Value = 2
        };

        private KompasObject kompas;
        private ToolTip _toolTip = new ToolTip();


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
            if (kompas == null)
            {
                Type t = Type.GetTypeFromProgID("KOMPAS.Application.5");
                kompas = (KompasObject)Activator.CreateInstance(t);
            }

            if (kompas != null)
            {
                kompas.Visible = true;
                kompas.ActivateControllerAPI();
            }

            ksDocument3D iDocument3D = (ksDocument3D)kompas.Document3D();
            iDocument3D.Create(false /*видимый*/, true /*деталь*/);

            ksPart iPart = iDocument3D.GetPart((short)Part_Type.pTop_Part);
            //iDocument3D.fileName = "PhotoFrame";

            ksEntity iSketch = iPart.NewEntity((short)Obj3dType.o3d_sketch);
            ksSketchDefinition iDefinitionSketch = iSketch.GetDefinition();
            iDefinitionSketch.SetPlane(iPart.GetDefaultEntity((short)Obj3dType.o3d_planeXOY));
            iSketch.Create();

            double innerX = 300;
            double innerY = 400;

            double centreInnerX = (innerX / 2) * -1;
            double centreInnerY = (innerY / 2) * -1;
            ksRectangleParam innerFrame = (ksRectangleParam)kompas.GetParamStruct(91);
            innerFrame.x = centreInnerX;
            innerFrame.y = centreInnerY;
            innerFrame.height = 400;
            innerFrame.width = 300;
            innerFrame.style = 1;

            double otherX = 400;
            double otherY = 500;

            double centreOtherX = (otherX / 2) * -1;
            double centreOtherY = (otherY / 2) * -1;
            ksRectangleParam otherFrame = (ksRectangleParam)kompas.GetParamStruct(91);
            otherFrame.x = centreOtherX;
            otherFrame.y = centreOtherY;
            otherFrame.height = 500;
            otherFrame.width = 400;
            otherFrame.style = 1;

            ksDocument2D iDocument2D = iDefinitionSketch.BeginEdit();
            iDocument2D.ksRectangle(innerFrame, 0);
            iDocument2D.ksRectangle(otherFrame, 0);
            iDefinitionSketch.EndEdit();

            // ВЫДАВЛИВАНИЕ
            ksEntity entityExtr = (ksEntity)iPart.NewEntity((short)Obj3dType.o3d_bossExtrusion);
            // интерфейс свойств базовой операции выдавливания
            ksBossExtrusionDefinition extrusionDef = (ksBossExtrusionDefinition)entityExtr.GetDefinition(); // интерфейс базовой операции выдавливания
            ksExtrusionParam extrProp = (ksExtrusionParam)extrusionDef.ExtrusionParam(); // интерфейс структуры параметров выдавливания
            extrusionDef.SetSketch(iSketch); // эскиз операции выдавливания
            extrProp.direction = (short)Direction_Type.dtNormal;      // направление выдавливания (прямое)
            extrProp.typeNormal = (short)End_Type.etBlind;      // тип выдавливания (строго на глубину)
            extrProp.depthNormal = 20;         // глубина выдавливания
            entityExtr.Create();                // создадим операцию

            // задняя подложка рамки
            ksEntity entitySketch2 = iPart.NewEntity((short)Obj3dType.o3d_sketch);
            ksSketchDefinition sketchDef2 = entitySketch2.GetDefinition();
            sketchDef2.SetPlane(iPart.GetDefaultEntity((short)Obj3dType.o3d_planeXOY));  // установим плоскость
            entitySketch2.Create(); // создадим эскиз

            double innerX2 = 300;
            double innerY2 = 400;

            double centreInnerX2 = (innerX2 / 2) * -1;
            double centreInnerY2 = (innerY2 / 2) * -1;
            ksRectangleParam innerFrame2 = (ksRectangleParam)kompas.GetParamStruct(91);
            innerFrame2.x = centreInnerX;
            innerFrame2.y = centreInnerY;
            innerFrame2.height = 400;
            innerFrame2.width = 300;
            innerFrame2.style = 1;

            ksDocument2D sketchEdit2 = sketchDef2.BeginEdit();
            sketchEdit2.ksRectangle(innerFrame2, 0);
            sketchDef2.EndEdit();   // завершение редактирования эскиза

            // приклеим выдавливанием
            ksEntity entityBossExtr = (ksEntity)iPart.NewEntity((short)Obj3dType.o3d_bossExtrusion);
            ksBossExtrusionDefinition bossExtrDef = (ksBossExtrusionDefinition)entityBossExtr.GetDefinition();
            ksExtrusionParam extrProp2 = (ksExtrusionParam)bossExtrDef.ExtrusionParam(); // интерфейс структуры параметров выдавливания
            bossExtrDef.SetSketch(entitySketch2); // эскиз операции выдавливания
            extrProp2.direction = (short)Direction_Type.dtNormal;      // направление выдавливания (обратное)
            extrProp2.typeNormal = (short)End_Type.etBlind;      // тип выдавливания (строго на глубину)
            extrProp2.depthReverse = 2;         // глубина выдавливания
            entityBossExtr.Create();                // создадим операцию
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        private void WidthInsideFrameTextBox_TextChanged(object sender, EventArgs e)
        {
            if (WidthInsideFrameTextBox.Text != "")
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
            if (HeightInsideFrameTextBox.Text != "")
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
            if (FrameWidthTextBox.Text != "")
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
            if (FrameHeightTextBox.Text != "")
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
            if (FrameThicknessTextBox.Text != "")
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
            if (!Char.IsDigit(number) && number != 8 && number != 44) // цифры, клавиша BackSpace и запятая
            {
                e.Handled = true;
            }
        }

        private void HeightInsideFrameTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (!Char.IsDigit(number) && number != 8 && number != 44) // цифры, клавиша BackSpace и запятая
            {
                e.Handled = true;
            }
        }

        private void FrameWidthTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (!Char.IsDigit(number) && number != 8 && number != 44) // цифры, клавиша BackSpace и запятая
            {
                e.Handled = true;
            }
        }

        private void FrameHeightTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (!Char.IsDigit(number) && number != 8 && number != 44) // цифры, клавиша BackSpace и запятая
            {
                e.Handled = true;
            }
        }

        private void FrameThicknessTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (!Char.IsDigit(number) && number != 8 && number != 44) // цифры, клавиша BackSpace и запятая
            {
                e.Handled = true;
            }
        }
    }
}