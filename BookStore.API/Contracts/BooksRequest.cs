namespace BookStore.API.Contracts
{
    //модель для взятия данных с фронтенда
    public record BooksRequest(
        string Title,
        string Description,
        decimal Price);
}
