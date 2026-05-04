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
  private readonly GetUserService _getUserService;
  private readonly DeleteUserService _deleteUserService;
  private readonly AddUserService _addUserService;
  private readonly UpdateUserService _updateUserService;

  public UsersController(
    GetUserService getUserService,
    DeleteUserService deleteUserService,
    AddUserService addUserService,
    UpdateUserService updateUserService
  )
  {
    _getUserService = getUserService;
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


  [HttpPatch("{userId}")]
  public async Task<IActionResult> UpdateUser(string userId, UpdateUserRequest request, CancellationToken cancellationToken)
  {
    if (userId != request.UserId)
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
