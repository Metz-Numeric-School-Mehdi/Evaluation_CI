using EvaluationSampleCode;

namespace EvaluationTestUnits;

[TestClass]
public sealed class TestUnits
{
    private MathOperations _mathOperations;
    private HtmlFormatHelper _htmlFormatHelper;

    [TestInitialize]
    public void Initialize()
    {
        _mathOperations = new MathOperations();
        _htmlFormatHelper = new HtmlFormatHelper();
    }
    
    // Tests Math Operation
    
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
    
    // Tests HTML Formater
    
    // Get Bold Format Method 
    [TestMethod]
    public void GetBoldFormat_WithHTMLContent_ReturnsBoldFormat()
    {
        var result = _htmlFormatHelper.GetBoldFormat("Content");
        Assert.AreEqual("<b>Content</b>", result);
    }
    
    // Get Italic Format Method 
    [TestMethod]
    public void GetItalicFormat_WithHTMLContent_ReturnsItalicFormat()
    {
        var result = _htmlFormatHelper.GetItalicFormat("Content");
        Assert.AreEqual("<i>Content</i>", result);
    }
    
    // Get Formatted List Elements Method 
    [TestMethod]
    public void GetFormattedListElements_WithHTMLContents_ReturnsFormattedListElements()
    {
        var contents = new List<string> { "Content", "Test" };
        var result = _htmlFormatHelper.GetFormattedListElements(contents);
        var expected = "<ul><li>Content</li><li>Test</li></ul>";
        
        Assert.AreEqual(expected, result);
    }
}