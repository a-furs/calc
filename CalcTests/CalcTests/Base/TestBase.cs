using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Serilog;
using TechTalk.SpecFlow;

namespace CalcTests.Base
{
    [TestClass]
    [Binding]
    public class TestBase
    {
        [AssemblyInitialize]
        public static void SetUp(TestContext context)
        {
            _testContext = context;
            InitLogger();
            Log.Information("<===== :: Tests :: ====>");
        }

        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            InitLogger();
            Log.Information("<===== :: Tests :: ====>");
        }

        public void TestSetUp()
        {
            Log.Information("<---- Test Method ---->");
            _testStarTime = DateTime.Now;
            Log.Information("Test started at {0}", _testStarTime);
        }
        
        public void TestTearDown()
        {
            Log.Information("<---- Test Complete ---->");
            _testEndTime = DateTime.Now;
            Log.Information("Test ended at {0}", _testEndTime);
            Log.Information("Test duration: {0}", _testEndTime - _testStarTime);
        }

        public TestContext TestContext
        {
            get { return _testContext; }
            set { _testContext = value; }
        }

        private static void InitLogger()
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.LiterateConsole()
                .WriteTo.RollingFile("logs\\test-{Date}.txt")
                .CreateLogger();
        }

        private DateTime _testStarTime;
        private DateTime _testEndTime;
        private static TestContext _testContext;
    }
}