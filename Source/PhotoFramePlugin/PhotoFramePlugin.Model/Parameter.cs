namespace PhotoFramePlugin.Model
{
    /// <summary>
    /// Параметр фоторамки.
    /// </summary>
    public class Parameter
    {
        /// <summary>
        /// Максимальное значение.
        /// </summary>
        public float MaxValue { get; set; }

        /// <summary>
        /// Минимальное значение.
        /// </summary>
        public float MinValue { get; set; }

        /// <summary>
        /// Значение.
        /// </summary>
        public float Value { get; set; }
    }
}
