namespace PhotoFramePlugin.Wrapper
{
    using PhotoFramePlugin.Model;

    /// <summary>
    /// Builder.
    /// </summary>
    public class PhotoFrameBuilder
    {
        /// <summary>
        /// Экземпляр класса Kompas3DWrapper.
        /// </summary>
        private readonly Kompas3DWrapper _kompas3DWrapper = new Kompas3DWrapper();

        /// <summary>
        /// Построить фоторамку.
        /// </summary>
        /// <param name="photoFrameParameters">Параметры для построения фоторамки.</param>
        public void BuildPhotoFrame(PhotoFrameParameters photoFrameParameters)
        {
            _kompas3DWrapper.OpenKompas();
            _kompas3DWrapper.CreateDocument3D();
            _kompas3DWrapper.CreatePart();

            // Создание рамки
            _kompas3DWrapper.InitializationSketchDefinition();
            _kompas3DWrapper.CreateFirstRectangleParam(
                photoFrameParameters.Parameters[ParameterType.WidthInsideFrame].Value,
                photoFrameParameters.Parameters[ParameterType.HeightInsideFrame].Value);
            _kompas3DWrapper.CreateSecondRectangleParam(
                photoFrameParameters.Parameters[ParameterType.FrameWidth].Value,
                photoFrameParameters.Parameters[ParameterType.FrameHeight].Value);
            _kompas3DWrapper.CreateDocument2DForTwoRectangleParam();
            _kompas3DWrapper.CreateExtrusionParam
                (photoFrameParameters.Parameters[ParameterType.FrameThickness].Value);

            // Создание бэк плейта
            _kompas3DWrapper.InitializationSketchDefinition();
            _kompas3DWrapper.CreateThirdRectangleParam(
                photoFrameParameters.Parameters[ParameterType.WidthInsideFrame].Value,
                photoFrameParameters.Parameters[ParameterType.HeightInsideFrame].Value);
            _kompas3DWrapper.CreateDocument2DForOneRectangleParam();
            _kompas3DWrapper.CreateExtrusionParam(
                photoFrameParameters.Parameters[ParameterType.BackWallThickness].Value);
        }
    }
}
