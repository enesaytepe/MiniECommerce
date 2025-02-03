using Application.Features.Product.Commands.Create;
using Application.Features.Product.Commands.Delete;
using Application.Features.Product.Commands.Update;
using Application.Features.Product.Queries.GetList;
using Application.Requests;
using Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace MiniECommerce.WebAPI.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class ProductController : BaseController
{
    /// <summary>
    /// Kategoriye bağlı veya null gönderilirse kategoriden bağımsız ürünleri getirir.
    /// </summary>
    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest, [FromQuery] int? categoryId)
    {
        GetListProductQuery getListCategoryQuery = new() { PageRequest = pageRequest, CategoryId = categoryId };
        GetListResponse<GetAllListProductItemDto> result = await Mediator.Send(getListCategoryQuery);
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateProductCommand createCategoryCommand)
    {
        CreatedProductResponse result = await Mediator.Send(createCategoryCommand);
        return Created(uri: "", result);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateProductCommand updateCategoryCommand)
    {
        UpdatedProductResponse result = await Mediator.Send(updateCategoryCommand);
        return Ok(result);
    }

    [HttpDelete]
    public async Task<IActionResult> Delete([FromBody] DeleteProductCommand deleteCategoryCommand)
    {
        DeletedProductResponse result = await Mediator.Send(deleteCategoryCommand);
        return Ok(result);
    }
}