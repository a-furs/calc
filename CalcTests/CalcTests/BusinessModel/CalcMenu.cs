using TestStack.White.UIItems;
using TestStack.White.UIItems.Finders;
using TestStack.White.UIItems.MenuItems;
using TestStack.White.UIItems.WindowStripControls;

namespace CalcTests.BusinessModel
{
    public class CalcMenu
    {
        public CalcMenu(IUIItemContainer mainFrame)
        {
            var menuBar = mainFrame.Get<MenuBar>(SearchCriteria.ByAutomationId("MenuBar"));
            Scientific = menuBar.MenuItem("Mode", "Scientific");
            Standard = menuBar.MenuItem("Standard");
        }

        public Menu Scientific { get; }
        public Menu Standard { get; }
    }
}