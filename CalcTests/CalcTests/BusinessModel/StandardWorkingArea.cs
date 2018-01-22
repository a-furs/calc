using TestStack.White.UIItems;
using TestStack.White.UIItems.Finders;
using Button = CalcTests.Base.Button;
using Label = CalcTests.Base.Label;

namespace CalcTests.BusinessModel
{
    public class StandardWorkingArea
    {
        public StandardWorkingArea(IUIItemContainer mainFrame)
        {
            var calcFrame = mainFrame.Get<Panel>(SearchCriteria.ByClassName("CalcFrame"));
            Button0 = new Button(calcFrame, SearchCriteria.ByAutomationId("130"), "0");
            Button1 = new Button(calcFrame, SearchCriteria.ByAutomationId("131"), "1");
            Button2 = new Button(calcFrame, SearchCriteria.ByAutomationId("132"), "2");
            Button3 = new Button(calcFrame, SearchCriteria.ByAutomationId("133"), "3");
            Button4 = new Button(calcFrame, SearchCriteria.ByAutomationId("134"), "4");
            Button5 = new Button(calcFrame, SearchCriteria.ByAutomationId("135"), "5");
            Button6 = new Button(calcFrame, SearchCriteria.ByAutomationId("136"), "6");
            Button7 = new Button(calcFrame, SearchCriteria.ByAutomationId("137"), "7");
            Button8 = new Button(calcFrame, SearchCriteria.ByAutomationId("138"), "8");
            Button9 = new Button(calcFrame, SearchCriteria.ByAutomationId("139"), "9");
            ButtonMplus = new Button(calcFrame, SearchCriteria.ByAutomationId("125"), "M+");
            ButtonMR = new Button(calcFrame, SearchCriteria.ByAutomationId("123"), "MR");
            ButtonPlus = new Button(calcFrame, SearchCriteria.ByAutomationId("93"), "+");
            ButtonEqual = new Button(calcFrame, SearchCriteria.ByAutomationId("121"), "=");

            Result = new Label(calcFrame, SearchCriteria.ByAutomationId("150"), "Result");
        }

        public Button Button0 { get; }
        public Button Button1 { get; }
        public Button Button2 { get; }
        public Button Button3 { get; }
        public Button Button4 { get; }
        public Button Button5 { get; }
        public Button Button6 { get; }
        public Button Button7 { get; }
        public Button Button8 { get; }
        public Button Button9 { get; }
        public Button ButtonMplus { get; }
        public Button ButtonMR { get; }
        public Button ButtonPlus { get; }
        public Button ButtonEqual { get; }

        public Label Result { get; }
    }
}