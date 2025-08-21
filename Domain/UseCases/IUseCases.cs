namespace server_tic_tac_toe.Domain.UseCases
{
    public interface IUseCases<T> where T : class
    {
        Task<T?> ExecuteAsync(string id);

    }
}