using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using ts.translation.Annotations;

namespace ts.translation.data.holder.observables
{
    public class ObservableTranslationData : INotifyPropertyChanged
    {
        private string _key;
        private string _value;
        private readonly string _initialValue;

        public string Key
        {
            get => _key;
            set
            {
                if (_key.Equals(value))
                {
                    return;
                }

                _key = value;
                OnPropertyChanged(nameof(Key));
            }
        }

        private bool _hasChanged;

        public bool HasChanged
        {
            set
            {
                _hasChanged = value;
                OnPropertyChanged(nameof(HasChanged));
            }
            get => _hasChanged;
        }

        public bool IsToDoItem => new Regex("^(TODO: )(.*)$", RegexOptions.CultureInvariant).Match(_value).Success;

        public string Value
        {
            get => _value;
            set
            {
                if (_value.Equals(value))
                {
                    return;
                }

                _value = value;
                HasChanged = !new Regex("^(" + _initialValue + ")$", RegexOptions.CultureInvariant).Match(value).Success;
                OnPropertyChanged(nameof(Value));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableTranslationData(string key, string value, bool isNewTranslation = false)
        {
            _key = key;
            _value = value;
            _initialValue = isNewTranslation ? string.Empty : value;
        }

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}