using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace HamburgerMenu.Views
{
    public abstract class LetterBasePage : ContentPage
    {
        protected abstract void OnNewNavStacks(string stackText);

        protected override void OnAppearing()
        {
            base.OnAppearing();

            Func<IReadOnlyList<Page>, string> makeStackText
                = (IReadOnlyList<Page> pages)
                => pages.Aggregate("", (path, page) => path + "/" + page.GetType().Name);
            var stackText = makeStackText(Navigation.NavigationStack) + " ; " + makeStackText(Navigation.ModalStack);
            OnNewNavStacks(stackText);
        }
    }
}
