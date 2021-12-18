using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Lemka.UIL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize("IsConnected")]
    public class ProduitsController : ControllerBase
    {
        #region Produit

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Get()
        {
            try
            {
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        public IActionResult Get(int id)
        {
            try
            {
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult Post([FromBody] string value)
        {
            try
            {
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public IActionResult Put(int id, [FromBody] string value)
        {
            try
            {
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public IActionResult Delete(int id)
        {
            try
            {
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        #endregion

        #region Images

        [HttpGet("{id}/Images")]
        [AllowAnonymous]
        public IActionResult GetImages(int id)
        {
            try
            {
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost("{id}/Images")]
        [Authorize(Roles = "Admin")]
        public IActionResult PostImage(int id, [FromBody] string value)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            try
            {
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{id}/Images/{iId}")]
        [Authorize(Roles = "Admin")]
        public IActionResult DeleteImage(int id, int iId)
        {
            try
            {
                return NoContent();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        #endregion

        #region Tags

        [HttpGet("{id}/Tags")]
        [AllowAnonymous]
        public IActionResult GetTags(int id)
        {
            try
            {
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost("{id}/Tags")]
        [Authorize(Roles = "Admin")]
        public IActionResult PostTag(int id, [FromBody] int value)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            try
            {
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{id}/Tags/{tId}")]
        [Authorize(Roles = "Admin")]
        public IActionResult DeleteTag(int id, int tId)
        {
            try
            {
                return NoContent();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        #endregion

        #region Like

        [HttpPost("{Id}/Like")]
        public IActionResult Like(int id)
        {
            try
            {
                return NoContent();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{Id}/Like")]
        public IActionResult Unlike(int id)
        {
            try
            {
                return NoContent();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        #endregion
    }
}
