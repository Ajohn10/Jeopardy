namespace Jeopardy.Controls;

public partial class QuestionControl : ContentView
{
	public QuestionControl()
	{
		InitializeComponent();
	}

	/// <summary>
	/// tapped event for border surrounding the question control
	/// </summary>
	/// <param name="sender"></param>
	/// <param name="e"></param>
    private void OnBorderTapped(object sender, TappedEventArgs e)
    {
		if (!this.IsEnabled) return;
		this.IsEnabled = false;
		this.MainBorder.BackgroundColor = new Color(0x61,0x7e,0xba);
		var questionPage = new QuestionPage();
		questionPage.BindingContext = this.BindingContext;
		Navigation.PushAsync(questionPage);
    }
}