namespace PhotoFramePlugin.Model
{
    /// <summary>
    /// Валидатор.
    /// </summary>
    public static class Validator
    {
        /// <summary>
        /// Валидация одного параметра.
        /// </summary>
        /// <param name="parameter">Параметр.</param>
        /// <returns>True - если проверка прошла, иначе - false.</returns>
        public static bool ValidateParameter(Parameter parameter)
        {
            return !(parameter.Value > parameter.MaxValue) && !(parameter.Value < parameter.MinValue);
        }

        /// <summary>
        /// Валидация двух параметров.
        /// </summary>
        /// <param name="firstParameter">Первый параметр.</param>
        /// <param name="secondParameter">Второй параметр.</param>
        /// <param name="minValue">Минимальный порог.</param>
        /// <param name="maxValue">Максимальный порог.</param>
        /// <returns>True - если проверка прошла, иначе - false.</returns>
        public static bool DependentParameterValidation(Parameter firstParameter, Parameter secondParameter, int minValue, int maxValue)
        {
            return secondParameter.Value - firstParameter.Value >= minValue && secondParameter.Value - firstParameter.Value <= maxValue;
        }
    }
}