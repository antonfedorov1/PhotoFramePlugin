namespace PhotoFramePlugin.Model
{
    using System.Collections.Generic;

    /// <summary>
    /// Параметры фоторамки.
    /// </summary>
    public class PhotoFrameParameters
    {
        /// <summary>
        /// Параметры.
        /// </summary>
        public Dictionary<ParameterType, Parameter> Parameters { get; set; }
    }
}
