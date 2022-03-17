using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace UnoTryOuts.ViewModels
{
    public abstract class ViewModelBase : INotifyPropertyChanged
    {


        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        public void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
