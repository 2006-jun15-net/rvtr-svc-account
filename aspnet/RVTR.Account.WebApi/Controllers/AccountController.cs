using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RVTR.Account.DataContext.Repositories;
using RVTR.Account.ObjectModel.Models;
using System.Threading.Tasks;
using RVTR.Account.WebApi.ResponseObjects;
using System;
using Microsoft.AspNetCore.Http;

namespace RVTR.Account.WebApi.Controllers
{
  /// <summary>
  ///
  /// </summary>
  [ApiController]
  [ApiVersion("0.0")]
  [EnableCors("Public")]
  [Route("rest/account/{version:apiVersion}/[controller]")]
  public class AccountController : ControllerBase
  {
    private readonly ILogger<AccountController> _logger;
    private readonly UnitOfWork _unitOfWork;

    /// <summary>
    ///
    /// </summary>
    /// <param name="logger"></param>
    /// <param name="unitOfWork"></param>
    public AccountController(ILogger<AccountController> logger, UnitOfWork unitOfWork)
    {
      _logger = logger;
      _unitOfWork = unitOfWork;
    }

    /// <summary>
    /// Delete a user's account
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id)
    {
      try
      {
        await _unitOfWork.Account.DeleteAsync(id);
        await _unitOfWork.CommitAsync();
        return Ok();
      }
      catch
      {
        return NotFound(new ErrorObject ($"Account with ID number {id} does not exist"));
      }
    }

    /// <summary>
    /// Get all user accounts available
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Get()
    {
      if (!ModelState.IsValid)
      {
        return BadRequest(new ErrorObject("Invalid data sent"));
      }
      else
      {
        return Ok(await _unitOfWork.Account.SelectAsync());
      }
    }

    /// <summary>
    /// Get a user's account by account ID number
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Get(int id)
    {
      AccountModel accountModel;
      try
      {
        accountModel = await _unitOfWork.Account.SelectAsync(id);
      }
      catch (ArgumentException e)
      {
        return BadRequest(new ValidationError(e));

      }
      if (accountModel is AccountModel theAccount)
      {
        return Ok(theAccount);
      } 
      return NotFound(new ErrorObject ($"Account with ID number {id} does not exist"));
    }

    /// <summary>
    /// Add an account 
    /// </summary>
    /// <param name="account"></param>
    /// <returns></returns>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Post([FromBody] AccountModel account)
    {
      if(!ModelState.IsValid)
      {
        return BadRequest(new ErrorObject("Invalid account data sent"));
      }
      
      await _unitOfWork.Account.InsertAsync(account);
      await _unitOfWork.CommitAsync();

      //if(!success)
      //{
      //  return BadRequest(new ErrorObject("Failed to add an account"));
      //}
      //return Accepted(account);
      return Ok(MessageObject.Success);
      
    }

    /// <summary>
    /// Update an existing account
    /// </summary>
    /// <param name="account"></param>
    /// <returns></returns>
    [HttpPut]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Put([FromBody] AccountModel account)
    {
      if(!ModelState.IsValid)
      {
        return BadRequest(new ErrorObject("Invalid account data sent"));
      }

      _unitOfWork.Account.Update(account);
      await _unitOfWork.CommitAsync();


      //return Accepted(account);
      return Ok(MessageObject.Success);
      
    }

   
  }
}
