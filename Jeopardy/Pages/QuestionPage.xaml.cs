using Jeopardy.Classes;

namespace Jeopardy;

public partial class QuestionPage : ContentPage
{
    private Question Question => BindingContext as Question;

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
        Question.IsComplete = true;
        Navigation.PopAsync();
    }

    private void This_BindingContextChanged(object sender, EventArgs e)
    {
        if (this.BindingContext == null) return;

        if (string.IsNullOrEmpty(Question.Template.URL)) image.IsVisible = false;
        else image.IsVisible = true;
    }
}