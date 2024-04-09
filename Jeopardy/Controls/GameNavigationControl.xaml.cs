namespace Jeopardy.Controls;

public partial class GameNavigationControl : ContentView
{
    public GameNavigationControl()
    {
        InitializeComponent();
    }

    private void Play_Clicked(object sender, EventArgs e)
    {
        var newGame = new GamePage();
        newGame.BindingContext = this.BindingContext;
        Navigation.PushAsync(newGame);
    }
}