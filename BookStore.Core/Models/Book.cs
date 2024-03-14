namespace BookStore.Core.Models
{
    public class Book
    {
        public const int MAX_TITLE_LENGTH = 250;

        private Book(Guid id, string title, string description, decimal price)
        {
            Id = id;
            Title = title;
            Description = description;
            Price = price;
        }

        public Guid Id { get; }
        public string Title { get; } = string.Empty;
        public string Description { get; } = string.Empty;
        public decimal Price { get; }




        public static (Book Book, string Error) Create(Guid id, string title, string description, decimal price)
        {
            var error = string.Empty;

            //валидация для заголовка
            if (string.IsNullOrEmpty(title) || title.Length > MAX_TITLE_LENGTH)
            {
                error = "The title cannot be empty or longer 250 symbols.";
            }
            //валидация цены
            if(price < 0.0m)
            {
                error += "\nPrice cannot be lower than 0.";
            }

            var book = new Book(id, title, description, price);

            return (book, error);
        }
    }
}
