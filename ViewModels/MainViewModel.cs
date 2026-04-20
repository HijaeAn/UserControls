using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace UserControls.ViewModels;

public class MainViewModel : INotifyPropertyChanged
{
    private bool _isOn = true;

    public bool IsOn
    {
        get => _isOn;
        set
        {
            if (_isOn == value) return;
            _isOn = value;
            OnPropertyChanged();
        }
    }

    public ICommand ToggleCommand { get; }

    public MainViewModel()
    {
        ToggleCommand = new RelayCommand(() => IsOn = !IsOn);
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    protected void OnPropertyChanged([CallerMemberName] string? name = null)
        => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
}
