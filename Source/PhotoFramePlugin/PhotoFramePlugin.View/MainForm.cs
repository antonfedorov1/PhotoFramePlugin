using System;
using Microsoft.Win32;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Drawing;
using Kompas6Constants;
using Kompas6Constants3D;
using KAPITypes;
using Kompas6API5;


namespace PhotoFramePlugin.View
{
    public partial class MainForm : Form
    {
        private KompasObject _kompas;

        public MainForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (_kompas == null)
            {
                Type t = Type.GetTypeFromProgID("KOMPAS.Application.5");
                _kompas = (KompasObject) Activator.CreateInstance(t);
            }

            if (_kompas != null)
            {
                _kompas.Visible = true;
                _kompas.ActivateControllerAPI();
            }

            if (_kompas != null)
            {
                ksDocument3D iDocument3D = (ksDocument3D) _kompas.Document3D();
                if (iDocument3D.Create(false /*видимый*/, true /*деталь*/))
                {
                    ksPart iPart = (ksPart) iDocument3D.GetPart((short) Part_Type.pNew_Part);
                }
            }
        }
    }
}
