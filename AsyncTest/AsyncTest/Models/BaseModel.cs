using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Xamarin.Forms;

namespace AsyncTest.Models
{
    internal abstract class BaseModel : INotifyPropertyChanged
    {
        protected Page CurrentPage { get; private set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public void Initialize(Page page)
        {
            CurrentPage = page;

            CurrentPage.Appearing += CurrentPageOnAppearing;
            CurrentPage.Disappearing += CurrentPageOnDisappearing;
        }

        protected virtual void CurrentPageOnAppearing(object sender, EventArgs eventArgs) {}

        protected virtual void CurrentPageOnDisappearing(object sender, EventArgs eventArgs) {}

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}