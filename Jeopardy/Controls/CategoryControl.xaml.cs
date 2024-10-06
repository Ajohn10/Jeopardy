using Jeopardy.Classes;

namespace Jeopardy.Controls;

public partial class CategoryControl : ContentView
{
    private Category Category => BindingContext as Category;

    public CategoryControl()
    {
        InitializeComponent();
    }

    private void This_BindingContextChanged(object sender, EventArgs e)
    {
        QuestionsGrid.Clear();
        QuestionsGrid.RowDefinitions.Clear();
        if (BindingContext == null) return;

        int count = 0;
        foreach (var question in Category.Questions.OrderBy(u => u.Template.Weight))
        {
            var cntrl = new QuestionControl { BindingContext = question };
            cntrl.SetValue(Grid.RowProperty, count);
            var rowDefinition = new RowDefinition();
            rowDefinition.Height = GridLength.Star;
            QuestionsGrid.RowDefinitions.Add(rowDefinition);
            QuestionsGrid.Add(cntrl);
            count++;
        }
    }
}