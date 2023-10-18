using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using Kompas6API5;
using Kompas6Constants3D;

namespace PhotoFramePlugin.View
{
    public partial class MainForm : Form
    {
        private KompasObject kompas;

        public MainForm()
        {
            InitializeComponent();
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
    }
}