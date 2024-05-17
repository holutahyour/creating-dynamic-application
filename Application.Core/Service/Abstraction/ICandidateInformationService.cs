namespace Application.Core.Service
{
    public interface ICandidateInformationService
    {
        Task<Result<CandidateInformation>> CreateAsync(CandidateInformation candidateInformation);
        Task<Result<bool>> DeleteAsync(string id, string partitionKeyValue);
        Task<Result<IList<CandidateInformation>>> GetAllAsync();
        Task<Result<CandidateInformation>> GetByDetailIdAsync(string id, string partitionKeyValue);
        Task<Result<CandidateInformation>> UpdateAsync(CandidateInformation candidateInformation, string id);
    }
}