namespace Application.Core.Service
{
    public interface IProgramApplicationService
    {
        Task<Result<ProgramApplication>> CreateAsync(ProgramApplication programApplication);
        Task<Result<bool>> DeleteAsync(string id, string partitionKeyValue);
        Task<Result<IList<ProgramApplication>>> GetAllAsync();
        Task<Result<ProgramApplication>> GetByDetailIdAsync(string id, string partitionKeyValue);
        Task<Result<ProgramApplication>> UpdateAsync(ProgramApplication programApplication, string id);
    }
}