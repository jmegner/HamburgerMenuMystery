namespace HamburgerMenu.Views
{
    public partial class ViewB : LetterBasePage
    {
        public ViewB()
        {
            InitializeComponent();
        }

        protected override void OnNewNavStacks(string stackText)
        {
            NavStackLabel.Text = stackText;
        }

    }
}
