using Jeopardy.Classes;

namespace Jeopardy;

public partial class QuestionPage : ContentPage
{
    private JeopardyQuestion Question => BindingContext as JeopardyQuestion;

    public QuestionPage()
    {
        InitializeComponent();
    }

    /// <summary>
    /// close the question page
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void Close_Clicked(object sender, EventArgs e)
    {
        Navigation.PopAsync();
    }

    private void This_BindingContextChanged(object sender, EventArgs e)
    {
        if (this.BindingContext == null) return;

        if (string.IsNullOrEmpty(Question.URL)) image.IsVisible = false;
        else image.IsVisible = true;
    }
}