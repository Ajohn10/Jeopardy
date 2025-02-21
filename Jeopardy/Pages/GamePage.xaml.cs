using CommunityToolkit.Maui.Views;
using Jeopardy.Classes;
using Jeopardy.Controls;

namespace Jeopardy;

public partial class GamePage : ContentPage
{
    private Game JeopardyGame => this.BindingContext as Game;

    public GamePage()
    {
        InitializeComponent();
    }

    private void This_BindingContextChanged(object sender, EventArgs e)
    {
        try
        {
            CategoriesGrid.Clear();
            CategoriesGrid.ColumnDefinitions.Clear();
            if (BindingContext == null) return;

            for (var i = 0; i < JeopardyGame.Categories.Count; i++)
            {
                var cntrl = new CategoryControl { BindingContext = JeopardyGame.Categories[i], Margin = new Thickness(5) };
                cntrl.SetValue(Grid.ColumnProperty, i);
                var columnDefinition = new ColumnDefinition();
                columnDefinition.Width = GridLength.Star;
                CategoriesGrid.ColumnDefinitions.Add(columnDefinition);
                CategoriesGrid.Add(cntrl);
            }
        }
        catch (Exception ex)
        {
            DisplayAlert("ERROR", ex.Message, "OK");
        }
    }

    /// <summary>
    /// handle category complete
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected override void OnAppearing()
    {
        base.OnAppearing();

        if (JeopardyGame.IsComplete)
        {
            var popup = new SimplePopup();
            popup.Message = "The game has been completed!";
            popup.Closed += (s, e) => Navigation.PopAsync();
            this.ShowPopup(popup);
        }
    }
}