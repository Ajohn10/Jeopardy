namespace Jeopardy.Controls;

public partial class GameNavigationControl : ContentView
{
	private Jeopardy.Classes.GameTemplate Game => BindingContext as Jeopardy.Classes.GameTemplate;

	public GameNavigationControl()
    {
        InitializeComponent();
    }

    private void Play_Clicked(object sender, EventArgs e)
    {
        try
        {
            if (!Game.HasReadGameFile) Game.ReadGameFile();
            var game = new Classes.Game(Game);
            var gamePage = new GamePage();
            gamePage.BindingContext = game;
            Navigation.PushAsync(gamePage);
        }
        catch (Exception ex)
        {
			// do something
		}
    }
}