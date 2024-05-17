using Application.Core.Domain;
using Application.Core.Service;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebApi.DTO.Request;

namespace WebApi.Controllers;

[ApiController]
[Route("api/candidate_informations")]
public class CandidateInformationController : ControllerBase
{
    private readonly ICandidateInformationService _candidateInformationService;
    private readonly IMapper _mapper;

    public CandidateInformationController(ICandidateInformationService candidateInformationService, IMapper mapper)
    {
        _candidateInformationService = candidateInformationService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        var request_time = DateTime.UtcNow;

        var response = await _candidateInformationService.GetAllAsync();

        response.RequestTime = request_time;
        response.ResponseTime = DateTime.UtcNow;

        return Ok(response);
    }

    [HttpGet]
    [Route("{id}")]
    public async Task<ActionResult> GetByDetailIdAsync(string id, string partitionKeyValue)
    {
        var request_time = DateTime.UtcNow;

        var response = await _candidateInformationService.GetByDetailIdAsync(id, partitionKeyValue);

        response.RequestTime = request_time;
        response.ResponseTime = DateTime.UtcNow;

        return Ok(response);
    }

    [HttpPost]
    public async Task<ActionResult> CreateAsync([FromBody] CandidateInformationDTO candidateInformation)
    {
        var request_time = DateTime.UtcNow;

        var response = await _candidateInformationService.CreateAsync(_mapper.Map<CandidateInformation>(candidateInformation));

        response.RequestTime = request_time;
        response.ResponseTime = DateTime.UtcNow;

        return Ok(response);
    }

    [HttpPut]
    [Route("{id}")]
    public async Task<ActionResult> UpdateAppointment([FromBody] CandidateInformationDTO candidateInformation, string id, string code)
    {
        var request_time = DateTime.UtcNow;

        var existingDetailResponse = await _candidateInformationService.GetByDetailIdAsync(id, code);

        if (existingDetailResponse.IsSuccess.Equals(false))
        {
            return Ok(existingDetailResponse);
        }

        _mapper.Map(candidateInformation, existingDetailResponse.Content);

        var response = await _candidateInformationService.UpdateAsync(existingDetailResponse.Content, id);

        response.RequestTime = request_time;
        response.ResponseTime = DateTime.UtcNow;

        return Ok(response);
    }

    [HttpDelete]
    [Route("{id}")]
    public async Task<ActionResult> UpdateAppointment(string id, string partitionKeyValue)
    {
        var request_time = DateTime.UtcNow;

        var response = await _candidateInformationService.DeleteAsync(id, partitionKeyValue);

        response.RequestTime = request_time;
        response.ResponseTime = DateTime.UtcNow;

        return Ok(response);
    }
}
