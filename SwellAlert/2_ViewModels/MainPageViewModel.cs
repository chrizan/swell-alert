using SwellAlert.Models;
using System.ComponentModel;

namespace SwellAlert.ViewModels
{
    public class MainPageViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private IDataProvider _dataProvider;

        public MainPageViewModel(IDataProvider dataProvider)
        {
            _dataProvider = dataProvider;
        }
    }
}
