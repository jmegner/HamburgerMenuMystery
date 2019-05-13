namespace HamburgerMenu.Views
{
    public partial class ViewC : LetterBasePage
    {
        public ViewC()
        {
            InitializeComponent();
        }

        protected override void OnNewNavStacks(string stackText)
        {
            NavStackLabel.Text = stackText;
        }

    }
}
