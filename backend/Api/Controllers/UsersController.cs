using Microsoft.AspNetCore.Mvc;
using Services.Users.Add;
using Services.Users.Delete;
using Services.Users.Get;
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
  private readonly IGetUsersService _getUsersService;
  private readonly IDeleteUserService _deleteUserService;
  private readonly IAddUserService _addUserService;
  private readonly IUpdateUserService _updateUserService;

  public UsersController(
    IGetUserService getUserService,
    IGetUsersService getUsersService,
    IDeleteUserService deleteUserService,
    IAddUserService addUserService,
    IUpdateUserService updateUserService
  )
  {
    _getUserService = getUserService;
    _getUsersService = getUsersService;
    _deleteUserService = deleteUserService;
    _addUserService = addUserService;
    _updateUserService = updateUserService;
  }

  [HttpGet("{id}")]
  public async Task<IActionResult> GetUser(Guid id, CancellationToken cancellationToken)
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
  public async Task<IActionResult> GetUsers(CancellationToken cancellationToken)
  {
    var request = new GetUsersRequest();
    var result = await _getUsersService.Handle(request, cancellationToken).ConfigureAwait(false);
    if (result.IsSuccess)
    {
      return Ok(result.Output);
    }
    return BadRequest(result.Errors);
  }

  [HttpDelete("{id}")]
  public async Task<IActionResult> DeleteUser(Guid id, CancellationToken cancellationToken)
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
  public async Task<IActionResult> UpdateUser(Guid id, UpdateUserRequest request, CancellationToken cancellationToken)
  {
    if (id != request.UserId)
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
