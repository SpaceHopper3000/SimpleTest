using Microsoft.VisualStudio.TestTools.UnitTesting;
using SimpleTest;
using SimpleTest.Services.LoggingService;
using SimpleTest.Services.Utilities;

namespace IntegrationTest
{
    [TestClass]
    public class StringUtilityTests
    {
        private ILogger _logger;
        
        [TestInitialize]
        public void Initialize()
        {
            _logger = new ConsoleLogger();
        }

        [TestMethod]
        public void TestNullValueReturnsErrorMessage()
        {
            Assert.AreEqual("data not correct", StringUtility.RemoveAndReorder(null, _logger) );
        }
        
        [TestMethod]
        public void EmptyValueReturnsErrorMessage()
        {
            Assert.AreEqual("data not correct", StringUtility.RemoveAndReorder("", _logger) );
        }
        
        [TestMethod]
        public void WordSort()
        {
            Assert.AreEqual("Boom Zoom", StringUtility.RemoveAndReorder("Zoom Boom", _logger));
        }

        [TestMethod]
        public void CaseSort()
        {
            Assert.AreEqual("Boom boom", StringUtility.RemoveAndReorder("boom Boom", _logger));
        }

         [TestMethod]
        public void RemoveInvalidChars()
        {        
            Assert.AreEqual("b b", StringUtility.RemoveAndReorder("b, b", _logger));
        }

        [TestMethod]
        public void RemoveInvalidCharactersAndSort()
        {        
            Assert.AreEqual("baby Go go", StringUtility.RemoveAndReorder("Go baby, go", _logger));
        }

        [TestMethod]
        public void RemoveInvalidCharactersAndSortByAlphaCase()
        {
            Assert.AreEqual("ABC aBc abc CBA CBA cba", StringUtility.RemoveAndReorder("CBA, abc aBc ABC cba CBA.", _logger));
        }
    }
}