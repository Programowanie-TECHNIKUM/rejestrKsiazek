using System.Collections.ObjectModel;

namespace rejestrKsiazek;

public partial class MainPage : ContentPage
{
    public ObservableCollection<Book> Books { get; set; }
    int nextId = 1;

    public MainPage()
    {
        InitializeComponent();
        Books = new ObservableCollection<Book>();
        booksListViews.ItemsSource = Books;
    }

    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;

        public override string ToString()
        {
            return $"{Id}. {Title} - {Author}";
        }
    }

    private async void AddBook(object sender, EventArgs e)
    {
        string title = tytulTextBox.Text;
        string author = autorTextBox.Text;

        if (title == "" || author == "")
        {
            await DisplayAlert("Błąd", "Proszę wypełnić oba pola", "OK");
            return;
        }
        
        Book newBook = new Book { Id = nextId, Title = title, Author = author };
        Books.Add(newBook);
        nextId++;
        
        tytulTextBox.Text = string.Empty;
        autorTextBox.Text = string.Empty;
    }

    private void RemoveBook(object sender, EventArgs e)
    {
        if (sender is Button button && button.BindingContext is Book bookToRemove)
        {
            Books.Remove(bookToRemove);
        }
    }
}
