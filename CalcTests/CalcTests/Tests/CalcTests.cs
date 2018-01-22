using System.Diagnostics;
using System.Linq;
using CalcTests.Base;
using CalcTests.BusinessModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Serilog;

namespace CalcTests.Tests
{
    [TestClass]
    public class CalcTests : TestBase
    {
        [TestInitialize]
        public void Setup()
        {
            KillCalcProcesses();
            _calc = new Calc();
            TestSetUp();
        }

        [TestCleanup]
        public void Cleanup()
        {
            TestTearDown();
            KillCalcProcesses();
        }

        [TestMethod]
        public void StandardCalcTest()
        {
            _calc.SwichToStandard();
            _calc.WorkingArea.Button1.Click();
            _calc.WorkingArea.Button2.Click();
            _calc.WorkingArea.ButtonPlus.Click();
            _calc.WorkingArea.Button9.Click();
            _calc.WorkingArea.Button9.Click();
            _calc.WorkingArea.Button9.Click();
            _calc.WorkingArea.ButtonMplus.Click();
            _calc.WorkingArea.Button1.Click();
            _calc.WorkingArea.Button9.Click();
            _calc.WorkingArea.ButtonPlus.Click();
            _calc.WorkingArea.ButtonMR.Click();
            _calc.WorkingArea.ButtonEqual.Click();
            var result = int.Parse(_calc.WorkingArea.Result.GetText());

            Assert.AreEqual(ExpectedResult, result);
        }

        [TestMethod]
        public void ScientificCalcTest()
        {
            _calc.SwichToScientific();
            _calc.WorkingArea.Button1.Click();
            _calc.WorkingArea.Button2.Click();
            _calc.WorkingArea.ButtonPlus.Click();
            _calc.WorkingArea.Button9.Click();
            _calc.WorkingArea.Button9.Click();
            _calc.WorkingArea.Button9.Click();
            _calc.WorkingArea.ButtonMplus.Click();
            _calc.WorkingArea.Button1.Click();
            _calc.WorkingArea.Button9.Click();
            _calc.WorkingArea.ButtonPlus.Click();
            _calc.WorkingArea.ButtonMR.Click();
            _calc.WorkingArea.ButtonEqual.Click();
            var result = int.Parse(_calc.WorkingArea.Result.GetText());

            Assert.AreEqual(ExpectedResult, result);
        }

        private static void KillCalcProcesses()
        {
            Log.Information("Searching for processes with name '{0}'", CalcProcessName);
            var calcProcesses = Process.GetProcessesByName(CalcProcessName);
            if (calcProcesses.Any())
            {
                Log.Information("Starting process 'Kill Them All'");
                foreach (var calcProcess in calcProcesses)
                {
                    Log.Information("Process with PID '{0}' was killed", calcProcess.Id);
                    calcProcess.Kill();
                }
            }
        }

        private Calc _calc;
        private const string CalcProcessName = "calc";
        private const int ExpectedResult = 1030;
    }
}
