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
        /// <param name="frameRounding">Скругление рамки.</param>
        /// <param name="ellipseFrame">Рамка в виде эллипса.</param>
        public void BuildPhotoFrame(
            PhotoFrameParameters photoFrameParameters,
            bool frameRounding,
            bool ellipseFrame)
        {
            _kompas3DWrapper.OpenKompas();
            _kompas3DWrapper.CreateDocument3D();
            _kompas3DWrapper.CreatePart();

            // Создание рамки
            _kompas3DWrapper.InitializationSketchDefinition();
            if (ellipseFrame)
            {
                _kompas3DWrapper.CreateFirstEllipseParam(
                    photoFrameParameters.Parameters[ParameterType.WidthInsideFrame].Value,
                    photoFrameParameters.Parameters[ParameterType.HeightInsideFrame].Value);
                _kompas3DWrapper.CreateSecondEllipseParam(
                    photoFrameParameters.Parameters[ParameterType.FrameWidth].Value,
                    photoFrameParameters.Parameters[ParameterType.FrameHeight].Value);
            }
            else
            {
                _kompas3DWrapper.CreateFirstRectangleParam(
                    photoFrameParameters.Parameters[ParameterType.WidthInsideFrame].Value,
                    photoFrameParameters.Parameters[ParameterType.HeightInsideFrame].Value);
                _kompas3DWrapper.CreateSecondRectangleParam(
                    photoFrameParameters.Parameters[ParameterType.FrameWidth].Value,
                    photoFrameParameters.Parameters[ParameterType.FrameHeight].Value);
            }

            _kompas3DWrapper.CreateDocument2DForTwoRectangleParam(ellipseFrame);
            _kompas3DWrapper.CreateExtrusionParam(
                photoFrameParameters.Parameters[ParameterType.FrameThickness].Value);

            // Создание бэк плейта
            _kompas3DWrapper.InitializationSketchDefinition();
            if (ellipseFrame)
            {
                _kompas3DWrapper.CreateThirdEllipseParam(
                    photoFrameParameters.Parameters[ParameterType.FrameWidth].Value,
                    photoFrameParameters.Parameters[ParameterType.FrameHeight].Value);
            }
            else
            {
                _kompas3DWrapper.CreateThirdRectangleParam(
                    photoFrameParameters.Parameters[ParameterType.WidthInsideFrame].Value,
                    photoFrameParameters.Parameters[ParameterType.HeightInsideFrame].Value);
            }

            _kompas3DWrapper.CreateDocument2DForOneRectangleParam(ellipseFrame);
            _kompas3DWrapper.CreateExtrusionParam(
                photoFrameParameters.Parameters[ParameterType.BackWallThickness].Value);
        }
    }
}
