namespace HamburgerMenu.Views
{
    public partial class ViewA : LetterBasePage
    {
        public ViewA()
        {
            InitializeComponent();
        }

        protected override void OnNewNavStacks(string stackText)
        {
            NavStackLabel.Text = stackText;
        }

    }
}
