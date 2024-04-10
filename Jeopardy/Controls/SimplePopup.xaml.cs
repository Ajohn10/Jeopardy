using CommunityToolkit.Maui.Views;
using System.ComponentModel;

namespace Jeopardy.Controls;

public partial class SimplePopup : Popup, INotifyPropertyChanged
{
    private string _message;
    /// <summary>
    /// message to use for the popup
    /// </summary>
    public string Message
    {
        get { return _message; }
        set
        {
            if (_message != value)
            {
                _message = value;
                OnPropertyChanged(nameof(Message));
            }
        }
    }

    public SimplePopup()
	{
		InitializeComponent();
		this.BindingContext = this;
	}

    public event PropertyChangedEventHandler PropertyChanged;

    protected virtual void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    /// <summary>
    /// Close button clicked
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void Button_Clicked(object sender, EventArgs e)
    {
		Close();
    }
}