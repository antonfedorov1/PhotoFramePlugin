namespace PhotoFramePlugin.Model.UnitTests
{
    using NUnit.Framework;
    using PhotoFramePlugin.Model;

    class ValidatorTests
    {
        [Test(Description = "Checking the correctness of the value")]
        public void Validate_SetCorrectValue_ReturnsTrue()
        {
            // Arrange
            var correctParameter = new Parameter { MaxValue = 1200, MinValue = 100, Value = 100 };
            var expected = true;

            // Act
            var actual = Validator.Validate(correctParameter);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test(Description = "Checking if the value is incorrect")]
        public void Validate_SetIncorrectValue_ReturnsFalse()
        {
            // Arrange
            var wrongParameter = new Parameter { MaxValue = 1200, MinValue = 100, Value = 9999 };
            var expected = false;

            // Act
            var actual = Validator.Validate(wrongParameter);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test(Description = "Checking the correctness of the value")]
        public void ValidateTwoParameter_SetCorrectValue_ReturnsTrue()
        {
            // Arrange
            var firstCorrectParameter = new Parameter { MaxValue = 1200, MinValue = 100, Value = 100 };
            var secondCorrectParameter = new Parameter { MaxValue = 1210, MinValue = 110, Value = 110 };
            var expected = true;

            // Act
            var actual = Validator.ValidateTwoParameter(firstCorrectParameter, secondCorrectParameter);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test(Description = "Checking if the value is incorrect")]
        public void ValidateTwoParameter_SetIncorrectValue_ReturnsFalse()
        {
            // Arrange
            var firstCorrectParameter = new Parameter { MaxValue = 1200, MinValue = 100, Value = 100 };
            var secondCorrectParameter = new Parameter { MaxValue = 1210, MinValue = 110, Value = 90 };
            var expected = false;

            // Act
            var actual = Validator.ValidateTwoParameter(firstCorrectParameter, secondCorrectParameter);

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}