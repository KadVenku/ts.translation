using System.ComponentModel;
using System.Runtime.CompilerServices;
using ts.translation.Annotations;

namespace ts.translation.data.holder.observables
{
    public class ObservableTranslationData : INotifyPropertyChanged
    {
        private string _key;
        private string _value;
        public string Key {
            get => _key;
            set
            {
                if (_key.Equals(value)) return;
                _key = value;
                OnPropertyChanged();
            }
        }

        public string Value
        {
            get => _value;
            set
            {
                if (_value.Equals(value)) return;
                _value = value;
                OnPropertyChanged();
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableTranslationData(string key, string value)
        {
            _key = key;
            _value = value;
        }

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
