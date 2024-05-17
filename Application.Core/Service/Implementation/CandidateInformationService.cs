using Application.Core.Domain;

namespace Application.Core.Service;

public class CandidateInformationService : ICandidateInformationService
{
    private readonly ICandidateInformationRepository _candidateInformationRepository;

    public CandidateInformationService(ICandidateInformationRepository candidateInformationRepository)
    {
        _candidateInformationRepository = candidateInformationRepository;
    }

    public async Task<Result<CandidateInformation>> CreateAsync(CandidateInformation candidateInformation)
    {
        Result<CandidateInformation> result = new(false);

        try
        {
            var response = await _candidateInformationRepository.CreateAsync(candidateInformation, candidateInformation.Code);

            result.SetSuccess(response, $"candidate information with Id {response.id} created successfully !");
        }
        catch (Exception ex)
        {
            result.SetError(ex.Message.ToString(), "error while creating candidate information");
        }

        return result;
    }

    public async Task<Result<IList<CandidateInformation>>> GetAllAsync()
    {
        Result<IList<CandidateInformation>> result = new(false);

        try
        {
            var response = await _candidateInformationRepository.GetAllAsync();

            result.SetSuccess(response, "retrieved successfully.");
        }
        catch (Exception ex)
        {
            result.SetError(ex.Message.ToString(), "error while retrieving candidate information");
        }

        return result;
    }

    public async Task<Result<CandidateInformation>> GetByDetailIdAsync(string id, string partitionKeyValue)
    {
        Result<CandidateInformation> result = new(false);

        try
        {
            var response = await _candidateInformationRepository.GetDetailByIdAsync(id, partitionKeyValue);

            result.SetSuccess(response, "retrieved successfully.");
        }
        catch (Exception ex)
        {
            result.SetError(ex.Message.ToString(), "error while retrieving candidate information");
        }

        return result;
    }

    public async Task<Result<CandidateInformation>> UpdateAsync(CandidateInformation candidateInformation, string id)
    {
        Result<CandidateInformation> result = new(false);

        try
        {
            var response = await _candidateInformationRepository.UpdateAsync(candidateInformation, id, candidateInformation.Code);

            result.SetSuccess(response, $"candidate information with Id {response.id} updated successfully !");
        }
        catch (Exception ex)
        {
            result.SetError(ex.Message.ToString(), "error while updating candidate information");
        }

        return result;       
    }

    public async Task<Result<bool>> DeleteAsync(string id, string partitionKeyValue)
    {
        Result<bool> result = new(false);

        try
        {
            var response = await _candidateInformationRepository.DeleteAsync(id, partitionKeyValue);

            result.SetSuccess(response, "deleted successfully.");
        }
        catch (Exception ex)
        {
            result.SetError(ex.Message.ToString(), "Error while deleting Program Application");
        }

        return result;
    }
}
