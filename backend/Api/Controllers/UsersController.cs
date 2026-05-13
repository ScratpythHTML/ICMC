using Microsoft.AspNetCore.Mvc;
using Services.Users.Add;
using Services.Users.Delete;
using Services.Users.Get;
using Services.Users.Search;
using Services.Users.Update;

namespace Api.Controllers;

/// <summary>
/// Controller for requests relating to users.
/// </summary>
[ApiController]
[Route("users")]
public class UsersController : ControllerBase
{
  private readonly IGetUserService _getUserService;
  private readonly IDeleteUserService _deleteUserService;
  private readonly IAddUserService _addUserService;
  private readonly IUpdateUserService _updateUserService;
  private readonly ISearchUsersService _searchUsersService;

  public UsersController(
    IGetUserService getUserService,
    IDeleteUserService deleteUserService,
    IAddUserService addUserService,
    IUpdateUserService updateUserService,
    ISearchUsersService searchUsersService
  )
  {
    _getUserService = getUserService;
    _deleteUserService = deleteUserService;
    _addUserService = addUserService;
    _updateUserService = updateUserService;
    _searchUsersService = searchUsersService;
  }

  [HttpGet("{id}")]
  public async Task<IActionResult> GetUser([FromRoute] int id, CancellationToken cancellationToken)
  {
    var request = new GetUserRequest(id);
    var result = await _getUserService.Handle(request, cancellationToken).ConfigureAwait(false);

    if (result.IsSuccess)
    {
      return Ok(result.Output);
    }

    return NotFound(result.Errors);
  }

  [HttpGet]
  public async Task<IActionResult> SearchUsers([FromQuery] SearchUsersRequest request, CancellationToken cancellationToken)
  {
    var result = await _searchUsersService.Handle(request, cancellationToken).ConfigureAwait(false);
    if (result.IsSuccess)
    {
      return Ok(result.Output);
    }

    return NotFound(result.Errors);
  }

  [HttpDelete("{id}")]
  public async Task<IActionResult> DeleteUser(int id, CancellationToken cancellationToken)
  {
    var request = new DeleteUserRequest(id);
    var result = await _deleteUserService.Handle(request, cancellationToken);

    if (result.IsSuccess)
    {
      return NoContent();
    }

    return BadRequest(result.Errors);
  }

  [HttpPost]
  public async Task<IActionResult> AddUser(AddUserRequest request, CancellationToken cancellationToken)
  {
    var result = await _addUserService.Handle(request, cancellationToken);

    if (result.IsSuccess)
    {
      return Created();
    }
    return BadRequest(result.Errors);
  }


  [HttpPatch("{id}")]
  public async Task<IActionResult> UpdateUser(int id, UpdateUserRequest request, CancellationToken cancellationToken)
  {
    if (id != request.Id)
    {
      return BadRequest("Id in URL must match Id in request body");
    }

    var result = await _updateUserService.Handle(request, cancellationToken);

    if (result.IsSuccess)
    {
      return NoContent();
    }

    return BadRequest(result.Errors);
  }
}
