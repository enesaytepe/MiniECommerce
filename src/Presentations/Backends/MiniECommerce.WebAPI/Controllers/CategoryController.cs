using Application.Features.Category.Commands.Create;
using Application.Features.Category.Commands.Delete;
using Application.Features.Category.Commands.Update;
using Application.Features.Category.Queries.GetAllList;
using Application.Features.Category.Queries.GetList;
using Application.Requests;
using Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace MiniECommerce.WebAPI.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class CategoryController : BaseController
{
    /// <summary>
    /// Ana kategoriler, 1. derece alt kategoriler ile sayfalamalı şekilde getirilir.
    /// </summary>
    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListCategoryQuery getListCategoryQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetAllListCategoryItemDto> result = await Mediator.Send(getListCategoryQuery);
        return Ok(result);
    }

    /// <summary>
    /// Tüm kategoriler, alt kategorilerin en derinine kadar getirilir.
    /// </summary>
    [HttpGet]
    public async Task<IActionResult> GetAllList()
    {
        GetAllListCategoryQuery getListCategoryQuery = new();
        List<GetAllListCategoryItemDto> result = await Mediator.Send(getListCategoryQuery);
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateCategoryCommand createCategoryCommand)
    {
        CreatedCategoryResponse result = await Mediator.Send(createCategoryCommand);
        return Created(uri: "", result);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateCategoryCommand updateCategoryCommand)
    {
        UpdatedCategoryResponse result = await Mediator.Send(updateCategoryCommand);
        return Ok(result);
    }

    [HttpDelete]
    public async Task<IActionResult> Delete([FromBody] DeleteCategoryCommand deleteCategoryCommand)
    {
        DeletedCategoryResponse result = await Mediator.Send(deleteCategoryCommand);
        return Ok(result);
    }
}