using System.Diagnostics;
using System.Linq;
using CalcTests.Base;
using CalcTests.BusinessModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Serilog;
using TechTalk.SpecFlow;

namespace CalcTests.Steps
{
    [Binding]
    public class CalcSteps : TestBase
    {
        [BeforeScenario]
        public void Setup()
        {
            KillCalcProcesses();
            _calc = new Calc();
            TestSetUp();
        }

        [AfterScenario]
        public void Cleanup()
        {
            TestTearDown();
            KillCalcProcesses();
        }

        [Given(@"Calc '(.*)' Is Opened")]
        public void GivenCalcIsOpened(string calcType)
        {
            switch (calcType)
            {
                case "Scientific":
                    _calc.SwichToScientific();
                    break;
                case "Standard":
                    _calc.SwichToStandard();
                    break;
                default:
                    Assert.Fail("No such type");
                    break;
            }
        }

        [When(@"Input number '(.*)'")]
        public void WhenInputNumber(string number)
        {
            var digits = number.ToCharArray();
            foreach (var digit in digits)
            {
                switch (digit)
                {
                    case '0':
                        _calc.WorkingArea.Button0.Click();
                        break;
                    case '1':
                        _calc.WorkingArea.Button1.Click();
                        break;
                    case '2':
                        _calc.WorkingArea.Button2.Click();
                        break;
                    case '3':
                        _calc.WorkingArea.Button3.Click();
                        break;
                    case '4':
                        _calc.WorkingArea.Button4.Click();
                        break;
                    case '5':
                        _calc.WorkingArea.Button5.Click();
                        break;
                    case '6':
                        _calc.WorkingArea.Button6.Click();
                        break;
                    case '7':
                        _calc.WorkingArea.Button7.Click();
                        break;
                    case '8':
                        _calc.WorkingArea.Button8.Click();
                        break;
                    case '9':
                        _calc.WorkingArea.Button9.Click();
                        break;
                    default:
                        Assert.Fail("No such digits");
                        break;
                }
            }
        }

        [When(@"Click button '(.*)'")]
        public void WhenClickButton(string button)
        {
            switch (button)
            {
                case "+":
                    _calc.WorkingArea.ButtonPlus.Click();
                    break;
                case "=":
                    _calc.WorkingArea.ButtonEqual.Click();
                    break;
                case "M+":
                    _calc.WorkingArea.ButtonMplus.Click();
                    break;
                case "MR":
                    _calc.WorkingArea.ButtonMR.Click();
                    break;
                default:
                    Assert.Fail("No such button");
                    break;
            }
        }

        [Then(@"Result should be equal '(.*)'")]
        public void ThenResultShouldBeEqual(int expectedResult)
        {
            var result = int.Parse(_calc.WorkingArea.Result.GetText());
            Assert.AreEqual(expectedResult, result);
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
    }
}