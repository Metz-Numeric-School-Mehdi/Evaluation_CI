using EvaluationSampleCode;

namespace EvaluationTestUnits;

[TestClass]
public sealed class TestUnits
{
    private User _adminUser;
    private User _regularUser;
    private User _creatorUser;
    
    private MathOperations _mathOperations;
    private HtmlFormatHelper _htmlFormatHelper;
    private CustomStack _stack;
    private Reservation _reservation;

    [TestInitialize]
    public void Initialize()
    {
        _mathOperations = new MathOperations();
        _htmlFormatHelper = new HtmlFormatHelper();
        _stack = new CustomStack();
        
        _adminUser = new User { IsAdmin = true };
        _regularUser = new User { IsAdmin = false };
        _creatorUser = new User { IsAdmin = false };
        _reservation = new Reservation(_creatorUser);
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

    // Tests Custom Stack

    // Pop Method
    [TestMethod]
    public void Pop_WithEmptyValue_ReturnsException()
    {
        Assert.ThrowsException<CustomStack.StackCantBeEmptyException>(() => _stack.Pop());
    }

    [TestMethod]
    public void Pop_WithListOfValue_ReturnsListOfPoppedValue()
    {
        _stack.Push(10);
        _stack.Push(11);
        _stack.Push(12);

        var result = _stack.Pop();
        Assert.AreEqual(12, result);
    }

    // Push Method
    [TestMethod]
    public void Push_WithValidValue_IncreasesCountAndAddsElementToStack()
    {
        Assert.AreEqual(0, _stack.Count());
        _stack.Push(10);

        Assert.AreEqual(1, _stack.Count());
        var poppedItem = _stack.Pop();

        Assert.AreEqual(10, poppedItem);
    }

    // Count Method
    [TestMethod]
    public void Count_WithEmptyStack_ReturnsZero()
    {
        var count = _stack.Count();
        Assert.AreEqual(0, count);
    }

    [TestMethod]
    public void Count_AfterPush_IncreasesCount()
    {
        _stack.Push(10);
        var count = _stack.Count();
        Assert.AreEqual(1, count);
    }

    [TestMethod]
    public void Count_AfterPop_DecreasesCount()
    {
        _stack.Push(10);
        _stack.Pop();

        var count = _stack.Count();

        Assert.AreEqual(0, count);
    }

    [TestMethod]
    public void Count_AfterMultiplePushes_ReturnsCorrectCount()
    {
        _stack.Push(10);
        _stack.Push(20);
        _stack.Push(30);

        var count = _stack.Count();

        Assert.AreEqual(3, count);
    }
    
    [TestMethod]
    public void Pop_OnEmptyStack_ThrowsStackCantBeEmptyException()
    {
       Assert.ThrowsException<CustomStack.StackCantBeEmptyException>(() => _stack.Pop());
    }
    
    // Tests Reservation
    [TestMethod]
    public void CanBeCancelledBy_Admin_ReturnsTrue()
    {
        var result = _reservation.CanBeCancelledBy(_adminUser);
        Assert.IsTrue(result);
    }

    [TestMethod]
    public void CanBeCancelledBy_Creator_ReturnsTrue()
    {
        var result = _reservation.CanBeCancelledBy(_creatorUser);
        Assert.IsTrue(result);
    }

    [TestMethod]
    public void CanBeCancelledBy_AnotherUser_ReturnsFalse()
    {
        var result = _reservation.CanBeCancelledBy(_regularUser);
        Assert.IsFalse(result);
    }
}