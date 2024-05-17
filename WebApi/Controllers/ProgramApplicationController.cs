using Application.Core.Domain;
using Application.Core.Service;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Cosmos.Serialization.HybridRow;
using WebApi.DTO.Request;

namespace WebApi.Controllers;

[ApiController]
[Route("api/program_applications")]
public class ProgramApplicationController : ControllerBase
{
    private readonly IProgramApplicationService _programApplicationService;
    private readonly IMapper _mapper;

    public ProgramApplicationController(IProgramApplicationService programApplicationService, IMapper mapper)
    {
        _programApplicationService = programApplicationService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        var request_time = DateTime.UtcNow;

        var response = await _programApplicationService.GetAllAsync();

        response.RequestTime = request_time;
        response.ResponseTime = DateTime.UtcNow;

        return Ok(response);
    }

    [HttpGet]
    [Route("{id}")]
    public async Task<ActionResult> GetByDetailIdAsync(string id, string partitionKeyValue)
    {
        var request_time = DateTime.UtcNow;

        var response = await _programApplicationService.GetByDetailIdAsync(id, partitionKeyValue);

        response.RequestTime = request_time;
        response.ResponseTime = DateTime.UtcNow;

        return Ok(response);
    }

    [HttpPost]
    public async Task<ActionResult> CreateAsync([FromBody] ProgramApplicationDTO programApplication)
    {
        var request_time = DateTime.UtcNow;

        var response = await _programApplicationService.CreateAsync(_mapper.Map<ProgramApplication>(programApplication));

        response.RequestTime = request_time;
        response.ResponseTime = DateTime.UtcNow;

        return Ok(response);
    }

    [HttpPut]
    [Route("{id}")]
    public async Task<ActionResult> UpdateAppointment([FromBody] ProgramApplicationDTO programApplication, string id, string code)
    {
        var request_time = DateTime.UtcNow;

        var existingDetailResponse = await _programApplicationService.GetByDetailIdAsync(id, code);

        if (existingDetailResponse.IsSuccess.Equals(false))
        {
            return Ok(existingDetailResponse);
        }

        _mapper.Map(programApplication, existingDetailResponse.Content);

        var response = await _programApplicationService.UpdateAsync(existingDetailResponse.Content, id);

        response.RequestTime = request_time;
        response.ResponseTime = DateTime.UtcNow;

        return Ok(response);
    }

    [HttpDelete]
    [Route("{id}")]
    public async Task<ActionResult> UpdateAppointment(string id, string partitionKeyValue)
    {
        var request_time = DateTime.UtcNow;

        var response = await _programApplicationService.DeleteAsync(id, partitionKeyValue);

        response.RequestTime = request_time;
        response.ResponseTime = DateTime.UtcNow;

        return Ok(response);
    }
}
