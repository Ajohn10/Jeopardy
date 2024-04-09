using CommunityToolkit.Maui.Views;

namespace Jeopardy;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();
		var gamesDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory,"Games");
		if (Directory.Exists(gamesDirectory))
		{
			var files = Directory.GetFiles(gamesDirectory).Where(u => u.EndsWith(".jeopardy"));

			foreach (var file in files) {
				var game = new Game { GameFile = new FileInfo(file) };
				var control = new Controls.GameNavigationControl();
				control.BindingContext = game;
				GameStack.Add(control);
			}
		}
	}

    private async void LoadGame_Clicked(object sender, EventArgs e)
    {
        try
        {
            var result = await FilePicker.Default.PickAsync();
            if (result != null)
            {
                if (result.FileName.EndsWith(".jeopardy", StringComparison.OrdinalIgnoreCase))
                {
                    var newGame = new GamePage();
                    newGame.BindingContext = new Game { GameFile = new FileInfo(result.FullPath) };
                    await Navigation.PushAsync(newGame);
                }
            }
        }
        catch (Exception ex)
        {
            // The user canceled or something went wrong
        }
    }

    private void Music_Loaded(object sender, EventArgs e)
    {
        (sender as MediaElement).Play();
    }
}

