namespace PhotoFramePlugin.Wrapper
{
    using System;
    using System.Diagnostics;
    using System.Runtime.InteropServices;
    using Kompas6API5;
    using Kompas6Constants3D;

    /// <summary>
    /// Wrapper.
    /// </summary>
    public class Kompas3DWrapper
    {
        /// <summary>
        /// Объект компаса.
        /// </summary>
        private KompasObject KompasObject { get; set; }

        /// <summary>
        /// 3д документа.
        /// </summary>
        private ksDocument3D Document3D { get; set; }

        /// <summary>
        /// Деталь.
        /// </summary>
        private ksPart Part { get; set; }

        /// <summary>
        /// Эскиз.
        /// </summary>
        private ksEntity Sketch { get; set; }

        /// <summary>
        /// Определение эскиза.
        /// </summary>
        private ksSketchDefinition DefinitionSketch { get; set; }

        /// <summary>
        /// 2д документ.
        /// </summary>
        private ksDocument2D Document2D { get; set; }

        /// <summary>
        /// Сущность Экстра.
        /// </summary>
        private ksEntity EntityExtr { get; set; }

        /// <summary>
        /// Определение выдавливания бобышки.
        /// </summary>
        private ksBossExtrusionDefinition ExtrusionDef { get; set; }

        /// <summary>
        /// Параметры экструзии.
        /// </summary>
        private ksExtrusionParam ExtrProp { get; set; }

        /// <summary>
        /// Параметр первого прямоугольника.
        /// </summary>
        private ksRectangleParam FirstRectangleParam { get; set; }

        /// <summary>
        /// Параметр второго прямоугольника.
        /// </summary>
        private ksRectangleParam SecondRectangleParam { get; set; }

        /// <summary>
        /// Параметр третьего прямоугольника.
        /// </summary>
        private ksRectangleParam ThirdRectangleParam { get; set; }

        /// <summary>
        /// Параметр первого эллипса.
        /// </summary>
        private ksEllipseParam FirstEllipseParam { get; set; }

        /// <summary>
        /// Параметр второго эллипса.
        /// </summary>
        private ksEllipseParam SecondEllipseParam { get; set; }

        /// <summary>
        /// Параметр третьего эллипса.
        /// </summary>
        private ksEllipseParam ThirdEllipseParam { get; set; }

        /// <summary>
        /// Параметр скругления.
        /// </summary>
        private ksFilletDefinition FilletDefinition { get; set; }

        /// <summary>
        /// Открытие компаса.
        /// </summary>
        public void OpenKompas()
        {
            Process[] pname = Process.GetProcessesByName("kStudy");
            if (pname.Length != 0)
            {
                KompasObject = (KompasObject)Marshal.GetActiveObject("KOMPAS.Application.5");
                KompasObject.ActivateControllerAPI();
            }
            else
            {
                KompasObject = null;
                Type type = Type.GetTypeFromProgID("KOMPAS.Application.5");
                KompasObject = (KompasObject)Activator.CreateInstance(type);
                KompasObject.Visible = true;
                KompasObject.ActivateControllerAPI();
            }
        }

        /// <summary>
        /// Создание 3д документа.
        /// </summary>
        public void CreateDocument3D()
        {
            Document3D = (ksDocument3D)KompasObject.Document3D();
            Document3D.Create(false /*видимый*/, true /*деталь*/);
        }

        /// <summary>
        /// Создание детали.
        /// </summary>
        public void CreatePart()
        {
            Part = Document3D.GetPart((short)Part_Type.pTop_Part);
        }

        /// <summary>
        /// Определение эскиза инициализации.
        /// </summary>
        public void InitializationSketchDefinition()
        {
            Sketch = Part.NewEntity((short)Obj3dType.o3d_sketch);
            DefinitionSketch = Sketch.GetDefinition();
            DefinitionSketch.SetPlane(Part.GetDefaultEntity((short)Obj3dType.o3d_planeXOY));
            Sketch.Create();
        }

        /// <summary>
        /// Создание первого параметра прямоугольника.
        /// </summary>
        /// <param name="firstParameter">Ширина.</param>
        /// <param name="secondParameter">Высота.</param>
        public void CreateFirstRectangleParam(float firstParameter, float secondParameter)
        {
            float centreInnerX = firstParameter / 2 * -1;
            float centreInnerY = secondParameter / 2 * -1;
            FirstRectangleParam = (ksRectangleParam)KompasObject.GetParamStruct(91);
            FirstRectangleParam.x = centreInnerX;
            FirstRectangleParam.y = centreInnerY;
            FirstRectangleParam.width = firstParameter;
            FirstRectangleParam.height = secondParameter;
            FirstRectangleParam.style = 1;
        }

        /// <summary>
        /// Создание второго параметра прямоугольника.
        /// </summary>
        /// <param name="firstParameter">Ширина.</param>
        /// <param name="secondParameter">Высота.</param>
        public void CreateSecondRectangleParam(float firstParameter, float secondParameter)
        {
            float centreInnerX = firstParameter / 2 * -1;
            float centreInnerY = secondParameter / 2 * -1;
            SecondRectangleParam = (ksRectangleParam)KompasObject.GetParamStruct(91);
            SecondRectangleParam.x = centreInnerX;
            SecondRectangleParam.y = centreInnerY;
            SecondRectangleParam.width = firstParameter;
            SecondRectangleParam.height = secondParameter;
            SecondRectangleParam.style = 1;
        }

        /// <summary>
        /// Создание третьего параметра прямоугольника.
        /// </summary>
        /// <param name="firstParameter">Ширина.</param>
        /// <param name="secondParameter">Высота.</param>
        public void CreateThirdRectangleParam(float firstParameter, float secondParameter)
        {
            float centreInnerX = firstParameter / 2 * -1;
            float centreInnerY = secondParameter / 2 * -1;
            ThirdRectangleParam = (ksRectangleParam)KompasObject.GetParamStruct(91);
            ThirdRectangleParam.x = centreInnerX;
            ThirdRectangleParam.y = centreInnerY;
            ThirdRectangleParam.width = firstParameter;
            ThirdRectangleParam.height = secondParameter;
            ThirdRectangleParam.style = 1;
        }

        /// <summary>
        /// Создание первого параметра эллипса.
        /// </summary>
        /// <param name="firstParameter">Ширина.</param>
        /// <param name="secondParameter">Высота.</param>
        public void CreateFirstEllipseParam(float firstParameter, float secondParameter)
        {
            FirstEllipseParam = (ksEllipseParam)KompasObject.GetParamStruct(22);
            FirstEllipseParam.A = firstParameter / 2;
            FirstEllipseParam.B = secondParameter / 2;
            FirstEllipseParam.xc = 0;
            FirstEllipseParam.yc =  0;
            FirstEllipseParam.angle = 0;
            FirstEllipseParam.style = 1;
        }

        /// <summary>
        /// Создание второго параметра эллипса.
        /// </summary>
        /// <param name="firstParameter">Ширина.</param>
        /// <param name="secondParameter">Высота.</param>
        public void CreateSecondEllipseParam(float firstParameter, float secondParameter)
        {
            SecondEllipseParam = (ksEllipseParam)KompasObject.GetParamStruct(22);
            SecondEllipseParam.A = firstParameter / 2;
            SecondEllipseParam.B = secondParameter / 2;
            SecondEllipseParam.xc = 0;
            SecondEllipseParam.yc = 0;
            SecondEllipseParam.angle = 0;
            SecondEllipseParam.style = 1;
        }

        /// <summary>
        /// Создание третьего параметра эллипса.
        /// </summary>
        /// <param name="firstParameter">Ширина.</param>
        /// <param name="secondParameter">Высота.</param>
        public void CreateThirdEllipseParam(float firstParameter, float secondParameter)
        {
            ThirdEllipseParam = (ksEllipseParam)KompasObject.GetParamStruct(22);
            ThirdEllipseParam.A = firstParameter / 2;
            ThirdEllipseParam.B = secondParameter / 2;
            ThirdEllipseParam.xc = 0;
            ThirdEllipseParam.yc = 0;
            ThirdEllipseParam.angle = 0;
            ThirdEllipseParam.style = 1;
        }

        /// <summary>
        /// Создать Document2D для второго параметра прямоугольника.
        /// </summary>
        /// <param name="isEllipseFrame">Это эллипсная рамка.</param>
        public void CreateDocument2DForTwoRectangleParam(bool isEllipseFrame)
        {
            Document2D = DefinitionSketch.BeginEdit();
            if (isEllipseFrame)
            {
                Document2D.ksEllipse(FirstEllipseParam);
                Document2D.ksEllipse(SecondEllipseParam);
            }
            else
            {
                Document2D.ksRectangle(FirstRectangleParam, 0);
                Document2D.ksRectangle(SecondRectangleParam, 0);
            }

            DefinitionSketch.EndEdit();
        }

        /// <summary>
        /// Создать Document2D для первого параметра прямоугольника.
        /// </summary>
        /// <param name="isEllipseFrame">Это эллипсная рамка.</param>
        public void CreateDocument2DForOneRectangleParam(bool isEllipseFrame)
        {
            Document2D = DefinitionSketch.BeginEdit();
            if (isEllipseFrame)
            {
                Document2D.ksEllipse(ThirdEllipseParam);
            }
            else
            {
                Document2D.ksRectangle(ThirdRectangleParam, 0);
            }

            DefinitionSketch.EndEdit();
        }

        /// <summary>
        /// Создать параметр выдавливания.
        /// </summary>
        /// <param name="firstParameter">Значение выдавливания.</param>
        public void CreateExtrusionParam(float firstParameter)
        {
            EntityExtr = (ksEntity)Part.NewEntity((short)Obj3dType.o3d_bossExtrusion);
            ExtrusionDef = (ksBossExtrusionDefinition)EntityExtr.GetDefinition();
            ExtrProp = (ksExtrusionParam)ExtrusionDef.ExtrusionParam();
            ExtrusionDef.SetSketch(Sketch);
            ExtrProp.direction = (short)Direction_Type.dtNormal;
            ExtrProp.typeNormal = (short)End_Type.etBlind;
            ExtrProp.depthNormal = firstParameter;
            EntityExtr.Create();
        }

        /// <summary>
        /// Скругление рамки.
        /// </summary>
        /// <param name="rounding">Угол скругления.</param>
        /// <param name="x">Позиция ребра по оси x.</param>
        /// <param name="y">Позиция ребра по оси y.</param>
        /// <param name="z">Позиция ребра по оси z.</param>
        /// <param name="isEllipse">Строится эллипс.</param>
        public void CreateRounding(float rounding, float x, float y, float z, bool isEllipse)
        {
            EntityExtr = (ksEntity)Part.NewEntity((short)Obj3dType.o3d_fillet);
            FilletDefinition = (ksFilletDefinition)EntityExtr.GetDefinition();
            FilletDefinition.radius = rounding;
            FilletDefinition.tangent = false;

            ksEntityCollection enColPart2 = Part.EntityCollection((short)Obj3dType.o3d_edge);
            ksEntityCollection enColFillet = FilletDefinition.array();
            enColFillet.Clear();

            if (isEllipse)
            {
                y /= 2;
                enColPart2.SelectByPoint(0, y, z);
                enColFillet.Add(enColPart2.GetByIndex(0));
                EntityExtr.Create();
            }
            else
            {
                x /= 2;
                y /= 2;
                enColPart2.SelectByPoint(0, y, z);
                enColFillet.Add(enColPart2.GetByIndex(0));

                enColPart2 = Part.EntityCollection((short)Obj3dType.o3d_edge);
                enColPart2.SelectByPoint(x, 0, z);
                enColFillet.Add(enColPart2.GetByIndex(0));

                enColPart2 = Part.EntityCollection((short)Obj3dType.o3d_edge);
                enColPart2.SelectByPoint(0, -y, z);
                enColFillet.Add(enColPart2.GetByIndex(0));

                enColPart2 = Part.EntityCollection((short)Obj3dType.o3d_edge);
                enColPart2.SelectByPoint(-x, 0, z);
                enColFillet.Add(enColPart2.GetByIndex(0));
            }

            EntityExtr.Create();
        }
    }
}
