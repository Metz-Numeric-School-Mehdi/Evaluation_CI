using EvaluationSampleCode;

namespace EvaluationTestUnits;

[TestClass]
public sealed class TestUnits
{
    private MathOperations _mathOperations;

    [TestInitialize]
    public void Initialize()
    {
        _mathOperations = new MathOperations();
    }
    
    //Tests Math Operation
    
    // Add Method
    [TestMethod]
    [DataRow(14, 22, 36)]
    [DataRow(20, 23, 43)]
    [DataRow(31, 67, 98)]
    public void Add_WithTwoNumbers_ReturnsAddition(int numberOne, int numberTwo, int expectedResult)
    {
        var result = _mathOperations.Add(numberOne, numberTwo);
        Assert.AreEqual(expectedResult, result);
    }
    
    // Divide Method
    [TestMethod]
    [DataRow(10, 10, 1)]
    [DataRow(8, 2, 4)]
    [DataRow(30, 3, 10)]
    public void Divide_WithTwoNumbers_ReturnsDivide(int numberOne, int numberTwo, int expectedResult)
    {
        var result = _mathOperations.Divide(numberOne, numberTwo);
        Assert.AreEqual(expectedResult, result);
    }
    
    //Get Odd Number Method
    // [TestMethod]
    // [DataRow(10, 10, 1)]
    // [DataRow(8, 2, 4)]
    // [DataRow(30, 3, 10)]
    // public void GetOddNumbers_WithOddNumber_ReturnsOddNumberList(int numberOne, int numberTwo, int expectedResult)
    // {
    //     var result = _mathOperations.Divide(numberOne, numberTwo);
    //     Assert.AreEqual(expectedResult, result);
    // }
}