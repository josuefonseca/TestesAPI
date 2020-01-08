using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TestesAPI.Models;

namespace TestesAPI.Controllers
{
    [Authorize]
    public class MeninosController : ApiController    {

        [HttpGet] [Route("api/meninos")]
        public IHttpActionResult GetMeninos([FromBody] MeninosModel.Boy newBoy) {


            var lista = new MeninosModel().ListaMeninos(newBoy.CD_BOY);
            if(lista.Count > 0)
                return Ok(lista);
            else
                return NotFound();
            
        }


        [HttpPost] [Route("api/meninos")]
        public IHttpActionResult PostMenino([FromBody] MeninosModel.Boy newBoy) {
            if(newBoy is null || newBoy.AGE_BOY == 0 || string.IsNullOrEmpty(newBoy.NM_BOY))
                return BadRequest();

            if(new MeninosModel().GravaMenino(newBoy) == 1)
                return Created("api/meninos", newBoy);

            return InternalServerError();
        }


        [HttpPut] [Route("api/meninos")]
        public IHttpActionResult PutMenino([FromBody] MeninosModel.Boy newBoy) {
            if(newBoy is null || newBoy.CD_BOY == 0 || newBoy.AGE_BOY == 0 || string.IsNullOrEmpty(newBoy.NM_BOY))
                return BadRequest();

            if(new MeninosModel().GravaMenino(newBoy) == 1)
                return Ok();

            return InternalServerError();
        }

        [HttpDelete] [Route("api/meninos")]
        public IHttpActionResult DeleteMenino([FromBody] MeninosModel.Boy newBoy) {
            if(newBoy is null || newBoy.CD_BOY == 0)
                return BadRequest();

            if(new MeninosModel().ExcluiMenino(newBoy) == 1)
                return Ok();

            return InternalServerError();
        }
    }
}
