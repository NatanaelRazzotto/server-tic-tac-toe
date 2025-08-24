namespace server_tic_tac_toe.Domain.UseCases
{
    public interface IUseCases<T,U>
        where T : class 
         where U : class   
    {
        Task<int?> ExecuteAsync(U dto);

    }
}