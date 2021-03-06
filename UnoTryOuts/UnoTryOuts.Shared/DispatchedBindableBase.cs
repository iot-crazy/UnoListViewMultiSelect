using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Windows.ApplicationModel.Core;
using Windows.UI.Core;

namespace UnoTryOuts
{
    public abstract class DispatchedBindableBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected CoreDispatcher Dispatcher => CoreApplication.MainView.Dispatcher;

        protected virtual bool SetProperty<T>(ref T backingVariable, T value, [CallerMemberName] string propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(backingVariable, value)) return false;

            backingVariable = value;
            RaisePropertyChanged(propertyName);

            return true;
        }

        protected void RaisePropertyChanged([CallerMemberName] string propertyName = null)
        {
#pragma warning disable CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed
            DispatchAsync(() => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName)));
#pragma warning restore CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed
        }

        protected async Task DispatchAsync(DispatchedHandler callback)
        {
            // As WASM is currently single-threaded, and Dispatcher.HasThreadAccess always returns false for broader compatibility  reasons
            // the following code ensures the app always directly invokes the callback on WASM.
            var hasThreadAccess =
#if __WASM__
        true;
#else
        Dispatcher.HasThreadAccess;
#endif

            if (hasThreadAccess)
            {
                callback.Invoke();
            }
            else
            {
                await Dispatcher.RunAsync(CoreDispatcherPriority.Normal, callback);
            }
        }
    }
}
