using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics.CodeAnalysis;


namespace Sinistrius.NumeriRomani.UnitTests;


[ExcludeFromCodeCoverage]
[TestClass]
public class RomanNumeralsFormatterTests
{

    #region Local Fields

    /// <summary>
    /// The Roman numerals formatter.
    /// </summary>
    private readonly RomanNumeralsFormatter _formatter = new();

    #endregion


    #region Tests

    /// <summary>
    /// Tests the <see cref="RomanNumeralsFormatter.Format(string?, object?, IFormatProvider?)"/> method.
    /// </summary>
    /// <param name="number">An integer that represents the number to be formatted.</param>
    /// <param name="expectedString">A string that represents the Roman numeral.</param>
    [TestMethod]
    [DataRow(1, "I")]
    [DataRow(2, "II")]
    [DataRow(4, "IV")]
    [DataRow(7, "VII")]
    [DataRow(10, "X")]
    [DataRow(14, "XIV")]
    [DataRow(49, "XLIX")]
    [DataRow(101, "CI")]
    [DataRow(1946, "MCMXLVI")]
    public void Format_Integer_ReturnsRomanNumeral(int number, string expectedString)
    {
        // Arrange

        // Act
        string actualString = String.Format(_formatter, "{0}", number);

        // Assert
        Assert.AreEqual(expectedString, actualString);
    }


    /// <summary>
    /// Tests the <see cref="RomanNumeralsFormatter.Format(string?, object?, IFormatProvider?)"/> method.
    /// </summary>
    [TestMethod]
    public void Format_Zero_ReturnsEmpty()
    {
        // Act
        string actualString = String.Format(_formatter, "{0}", 0);

        // Assert
        Assert.AreEqual(String.Empty, actualString);
    }


    /// <summary>
    /// Tests the <see cref="RomanNumeralsFormatter.Format(string?, object?, IFormatProvider?)"/> method.
    /// </summary>
    [TestMethod]
    public void Format_Empty_ReturnsEmpty()
    {
        // Act
        string actualString = String.Format(_formatter, "");

        // Assert
        Assert.AreEqual(String.Empty, actualString);
    }


    /// <summary>
    /// Tests the <see cref="RomanNumeralsFormatter.Format(string?, object?, IFormatProvider?)"/> method.
    /// </summary>
    /// <param name="value">An object that represents the value to be formatted.</param>
    [TestMethod]
    [DataRow("abc")]
    [DataRow(1.23)]
    [DataRow (-1)]
    [ExpectedException(typeof(ArgumentException))]
    public void Format_NonInteger_ThrowsArgumentException(object value)
    {
        // Act
        string actualString = String.Format(_formatter, "{0}", value);
    }

    #endregion

}