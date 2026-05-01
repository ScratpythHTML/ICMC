using Handlers.Users.Add;
using Handlers.Users.Delete;
using Handlers.Users.Get;
using Handlers.Users.Update;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

/// <summary>
/// Controller for requests relating to users.
/// </summary>
[ApiController]
[Route("users")]
public class UsersController : ControllerBase
{
  private readonly GetUserHandler _getUserHandler;
  private readonly DeleteUserHandler _deleteUserHandler;
  private readonly AddUserHandler _addUserHandler;
  private readonly UpdateUserHandler _updateUserHandler;

  public UsersController(
    GetUserHandler getUserHandler,
    DeleteUserHandler deleteUserHandler,
    AddUserHandler addUserHandler,
    UpdateUserHandler updateUserHandler
  )
  {
    _getUserHandler = getUserHandler;
    _deleteUserHandler = deleteUserHandler;
    _addUserHandler = addUserHandler;
    _updateUserHandler = updateUserHandler;
  }

  [HttpGet("{id}")]
  public async Task<IActionResult> GetUser(Guid id, CancellationToken cancellationToken)
  {
    var request = new GetUserRequest(id);
    var result = await _getUserHandler.Handle(request, cancellationToken).ConfigureAwait(false);

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
    var result = await _deleteUserHandler.Handle(request, cancellationToken);

    if (result.IsSuccess)
    {
      return NoContent();
    }

    return BadRequest(result.Errors);
  }

  [HttpPost]
  public async Task<IActionResult> AddUser(AddUserRequest request, CancellationToken cancellationToken)
  {
    var result = await _addUserHandler.Handle(request, cancellationToken);

    if (result.IsSuccess)
    {
      return Created();
    }
    return BadRequest(result.Errors);
  }


  [HttpPatch("{id}")]
  public async Task<IActionResult> UpdateUser(UpdateUserRequest request, CancellationToken cancellationToken)
  {
    var result = await _updateUserHandler.Handle(request, cancellationToken);

    if (result.IsSuccess)
    {
      return NoContent();
    }

    return BadRequest(result.Errors);
  }
}
