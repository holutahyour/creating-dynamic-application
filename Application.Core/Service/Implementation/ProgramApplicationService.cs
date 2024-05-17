using Application.Core.Domain;

namespace Application.Core.Service;

public class ProgramApplicationService : IProgramApplicationService
{
    private readonly IProgramApplicationRepository _programApplicationRepository;

    public ProgramApplicationService(IProgramApplicationRepository programApplicationRepository)
    {
        _programApplicationRepository = programApplicationRepository;
    }

    public async Task<Result<ProgramApplication>> CreateAsync(ProgramApplication programApplication)
    {
        Result<ProgramApplication> result = new(false);

        try
        {
            var response = await _programApplicationRepository.CreateAsync(programApplication, programApplication.Code);

            result.SetSuccess(response, $"program application with Id {response.id} created successfully !");
        }
        catch (Exception ex)
        {
            result.SetError(ex.Message.ToString(), "error while creating program application");
        }

        return result;
    }

    public async Task<Result<IList<ProgramApplication>>> GetAllAsync()
    {
        Result<IList<ProgramApplication>> result = new(false);

        try
        {
            var response = await _programApplicationRepository.GetAllAsync();

            result.SetSuccess(response, "retrieved successfully.");
        }
        catch (Exception ex)
        {
            result.SetError(ex.Message.ToString(), "error while retrieving program application");
        }

        return result;
    }

    public async Task<Result<ProgramApplication>> GetByDetailIdAsync(string id, string partitionKeyValue)
    {
        Result<ProgramApplication> result = new(false);

        try
        {
            var response = await _programApplicationRepository.GetDetailByIdAsync(id, partitionKeyValue);

            result.SetSuccess(response, "retrieved successfully.");
        }
        catch (Exception ex)
        {
            result.SetError(ex.Message.ToString(), "error while retrieving program application");
        }

        return result;
    }

    public async Task<Result<ProgramApplication>> UpdateAsync(ProgramApplication programApplication, string id)
    {
        Result<ProgramApplication> result = new(false);

        try
        {
            
            var response = await _programApplicationRepository.UpdateAsync(programApplication, id, programApplication.Code);

            result.SetSuccess(response, $"program application with Id {response.id} updated successfully !");
        }
        catch (Exception ex)
        {
            result.SetError(ex.Message.ToString(), "error while updating program application");
        }

        return result;
    }

    public async Task<Result<bool>> DeleteAsync(string id, string partitionKeyValue)
    {
        Result<bool> result = new(false);

        try
        {
            var response = await _programApplicationRepository.DeleteAsync(id, partitionKeyValue);

            result.SetSuccess(response, "deleted successfully.");
        }
        catch (Exception ex)
        {
            result.SetError(ex.Message.ToString(), "Error while deleting Program Application");
        }

        return result;
    }
}
