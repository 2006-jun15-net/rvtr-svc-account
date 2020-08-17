using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RVTR.Account.DataContext.Repositories;
using RVTR.Account.ObjectModel.Models;

namespace RVTR.Account.WebApi.Controllers
{
    /// <summary>
    /// Represents the _Address Controller_ class
    /// </summary>
    [ApiController]
    [ApiVersion("0.0")]
    [EnableCors("Public")]
    [Route("rest/account/{version:apiVersion}/[controller]")]
    public class AddressController : ControllerBase
    {
        private readonly ILogger<AddressController> _logger;
        private readonly UnitOfWork _unitOfWork;

        /// <summary>
        /// The _Address Controller_ constructor
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="unitOfWork"></param>
        public AddressController(ILogger<AddressController> logger, UnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Deletes a user's address
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                //await _unitOfWork.Address.DeleteAsync(id);
                await _unitOfWork.CommitAsync();

                return Ok();
            }
            catch
            {
                return NotFound(id);
            }
        }

        /// <summary>
        /// Get all user addresses
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _unitOfWork.Address.SelectAsync());
        }

        /// <summary>
        /// Get a user's address by its ID number
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                return Ok(await _unitOfWork.Address.SelectAsync(id));
            }
            catch
            {
                return NotFound(id);
            }
        }

        /// <summary>
        /// Add an address to a user's account
        /// </summary>
        /// <param name="address"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Post(AddressModel address)
        {
          await _unitOfWork.Address.InsertAsync(address);
          await _unitOfWork.CommitAsync();

          return Accepted(address);
        }

    ///// <summary>
    ///// Update a user's address
    ///// </summary> 
    ///// <param name="address"></param>
    ///// <returns></returns>
    [HttpPut]
    public async Task<IActionResult> Put(AddressModel address)
    {
      _unitOfWork.Address.Update(address);
      await _unitOfWork.CommitAsync();

      return Accepted(address);
    }
  }
}
