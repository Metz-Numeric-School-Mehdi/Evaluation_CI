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
    [TestMethod]
    [DataRow(14, 22, 36)]
    [DataRow(20, 23, 43)]
    [DataRow(31, 67, 98)]
    public void Add_WithTwoNumbers_ReturnsAddition(int numberOne, int numberTwo, int expectedResult)
    {
        var result = _mathOperations.Add(numberOne, numberTwo);
        Assert.AreEqual(expectedResult, result);
    }
}