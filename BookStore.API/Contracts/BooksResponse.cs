namespace BookStore.API.Contracts
{
    public record BooksResponse( //модель для передачи данных на фронтенд
        Guid Id,
        string Title,
        string Description,
        decimal Price);
}
