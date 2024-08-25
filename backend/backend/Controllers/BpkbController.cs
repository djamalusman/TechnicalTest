using backend.Data;
using backend.Models;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    public class BpkbController : ControllerBase
    {
        private readonly IDataAccessProvider _dataAccessProvider;

        GeneralOutputModel output = new GeneralOutputModel();
        public BpkbController(IDataAccessProvider dataAccessProvider)
        {
            _dataAccessProvider = dataAccessProvider;
        }



        [HttpGet]
        [Route("getdatabpkb")]
        public ActionResult ViewDataAttribute()
        {
            try
            {

                GeneralOutputModel retrn = _dataAccessProvider.GetdataBpkb();

                if (retrn.Status == "OK")
                {
                    return Ok(retrn);
                }
                return BadRequest(retrn);
            }
            catch (Exception ex)
            {
                output.Status = "NG";
                output.Message = ex.ToString();

                return BadRequest(output);
            }
        }


        [HttpPost]
        [Route("GetByIdbpkb")]
        public ActionResult getDataAttributebyId([FromBody] byId pr)
        {
            try
            {

                GeneralOutputModel retrn = _dataAccessProvider.GetdatabyIdBpkb(pr);

                if (retrn.Status == "OK")
                {
                    return Ok(retrn);
                }
                return BadRequest(retrn);
            }
            catch (Exception ex)
            {
                output.Status = "NG";
                output.Message = ex.ToString();

                return BadRequest(output);
            }
        }



        [HttpGet]
        [Route("getdatalocation")]
        public ActionResult ViewDatalocation()
        {
            try
            {

                GeneralOutputModel retrn = _dataAccessProvider.Getdatalocations();

                if (retrn.Status == "OK")
                {
                    return Ok(retrn);
                }
                return BadRequest(retrn);
            }
            catch (Exception ex)
            {
                output.Status = "NG";
                output.Message = ex.ToString();

                return BadRequest(output);
            }
        }


        [HttpPost]
        [Route("StoreBpkb")]
        public async Task<IActionResult> InsertData([FromBody] Bpkbstore pr)
        {
           
            try
            {

                var result = await _dataAccessProvider.InsertDataAsync(pr);

                if (result.Status == "OK")
                {
                    return Ok(result);
                }
                return BadRequest(result);
            }
            catch (Exception ex)
            {
                output.Status = "NG";
                output.Message = ex.ToString();

                return BadRequest(output);
            }


        }


        [HttpPost]
        [Route("Update")]
        public async Task<IActionResult> UpdateData([FromBody] Bpkbstore pr)
        {

            try
            {

                var result = await _dataAccessProvider.UpdateDataAsync(pr);

                if (result.Status == "OK")
                {
                    return Ok(result);
                }
                return BadRequest(result);
            }
            catch (Exception ex)
            {
                output.Status = "NG";
                output.Message = ex.ToString();

                return BadRequest(output);
            }


        }

    }
}
