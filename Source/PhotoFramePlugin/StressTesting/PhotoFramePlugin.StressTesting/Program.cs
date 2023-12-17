namespace PhotoFramePlugin.StressTesting
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;
    using Microsoft.VisualBasic.Devices;
    using PhotoFramePlugin.Model;
    using PhotoFramePlugin.Wrapper;

    class Program
    {
        static void Main(string[] args)
        {
            PhotoFrameBuilder builder = new PhotoFrameBuilder();

            var stopWatch = new Stopwatch();
            stopWatch.Start();

            PhotoFrameParameters parameters = new PhotoFrameParameters();

            Parameter widthInsideFrame = new Parameter { MaxValue = 1200, MinValue = 100, Value = 100, };
            Parameter heightInsideFrame = new Parameter { MaxValue = 1200, MinValue = 100, Value = 100, };
            Parameter frameWidth = new Parameter { MaxValue = 1210, MinValue = 110, Value = 110, };
            Parameter frameHeight = new Parameter { MaxValue = 1210, MinValue = 110, Value = 110, };
            Parameter frameThickness = new Parameter { MaxValue = 30, MinValue = 10, Value = 10, };
            Parameter backWallThickness = new Parameter { MaxValue = 2, MinValue = 2, Value = 2, };
            Parameter frameRounding = new Parameter { MaxValue = 8, MinValue = 1, Value = 1, };

            parameters.Parameters = new Dictionary<ParameterType, Parameter>()
            {
                {ParameterType.WidthInsideFrame, widthInsideFrame},
                {ParameterType.HeightInsideFrame, heightInsideFrame},
                {ParameterType.FrameWidth, frameWidth},
                {ParameterType.FrameHeight, frameHeight},
                {ParameterType.FrameThickness, frameThickness},
                {ParameterType.BackWallThickness, backWallThickness},
                {ParameterType.FrameRounding, frameRounding}
            };

            var streamWriter = new StreamWriter($"log.txt", true);
            Process currentProcess = System.Diagnostics.Process.GetCurrentProcess();
            var count = 0;

            while (true)
            {
                const double gigabyteInByte = 0.000000000931322574615478515625;
                builder.BuildPhotoFrame(parameters, true, true);
                var computerInfo = new ComputerInfo();
                var usedMemory = (computerInfo.TotalPhysicalMemory
                                  - computerInfo.AvailablePhysicalMemory)
                                 * gigabyteInByte;
                streamWriter.WriteLine($"{++count}\t{stopWatch.Elapsed:hh\\:mm\\:ss}\t{usedMemory}");
                streamWriter.Flush();

            }

            stopWatch.Stop();
            streamWriter.Close();
            streamWriter.Dispose();
            Console.Write($"End {new ComputerInfo().TotalPhysicalMemory}");
        }
    }
}
