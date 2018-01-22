using Serilog;
using TestStack.White.UIItems;
using TestStack.White.UIItems.Finders;
using UIButton = TestStack.White.UIItems.Button;

namespace CalcTests.Base
{
    public class Button : BaseElement
    {
        public Button(IUIItemContainer container, SearchCriteria criteria, string elementName) : base(elementName)
        {
            _button = container.Get<UIButton>(criteria);
        }

        public void Click()
        {
            Log.Information("Click Button '{0}'", ElementName);
            _button.Click();
        }

        private readonly UIButton _button;
    }
}