using Serilog;
using TestStack.White;
using TestStack.White.UIItems.WindowItems;

namespace CalcTests.BusinessModel
{
    public class Calc
    {
        public Calc()
        {
            Log.Information("Starting application {0}", _calcPath);
            var calc = Application.Launch(_calcPath);
            MainWindow = calc.GetWindow("Calculator");
            WorkingArea = new StandardWorkingArea(MainWindow);
            _calcMenu = new CalcMenu(MainWindow);
        }

        public void SwichToScientific()
        {
            _calcMenu.Scientific.Click();
            WorkingArea = new ScientificWorkingArea(MainWindow);
        }

        public void SwichToStandard()
        {
            _calcMenu.Standard.Click();
            WorkingArea = new StandardWorkingArea(MainWindow);
        }

        public Window MainWindow { get; }
        public StandardWorkingArea WorkingArea { get; private set; }

        private readonly CalcMenu _calcMenu;
        private readonly string _calcPath = @"Resources\calc";
    }
}