using Serilog;
using TestStack.White.UIItems;
using TestStack.White.UIItems.Finders;
using UILabel = TestStack.White.UIItems.Label;

namespace CalcTests.Base
{
    public class Label : BaseElement
    {
        public Label(IUIItemContainer container, SearchCriteria criteria, string elementName) : base(elementName)
        {
            _label = container.Get<UILabel>(criteria);
        }

        public string GetText()
        {
            Log.Information("Getting text from element '{0}': {1}", ElementName, _label.Text);
            return _label.Text;
        }

        private readonly UILabel _label;
    }
}