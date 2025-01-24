using Andy_Driver_PayRate_Rule_API.DTO;
using Andy_Driver_PayRate_Rule_API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Andy_Driver_PayRate_Rule_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DriverPayRateController : ControllerBase
    {
        private readonly TmwLiveContext _context;
        private ResponseDTO response;
        public DriverPayRateController(TmwLiveContext context)
        {
            _context = context;
            response = new ResponseDTO();
        }

        private bool AndyDriverPayRateExists(int id)
        {
            return _context.AndyDriverPayRates.Any(e => e.AndyDriverPayRateId == id);
        }
      
        [HttpGet("GetPayRateRules")]
        public ResponseDTO GetPayRateRules()
        {
            using (var _context = new TmwLiveContext())
            {
                var response = new ResponseDTO();

                var ObjectList = _context.AndyDriverPayRuleOverTimes.ToList();

                response.Result = ObjectList;

                return response;

            }
        }
        [HttpPut("PayType")]
        public  IActionResult UpdatePayRate(string payType, decimal amount)
        {
            using (var _context = new TmwLiveContext())
            {
                // Find the record based on the PayType (PayRateName in your model)
                var payRateRecord = _context.AndyDriverPayRuleOverTimes
                    .FirstOrDefault(pr => pr.PayRateName == payType);

                if (payRateRecord == null)
                {
                    // Return a 404 Not Found if the record doesn't exist
                    return NotFound(new ResponseDTO
                    {
                        IsSuccess = false,
                        Message = $"PayType '{payType}' not found."
                    });
                }

                // Update the Formula field
                payRateRecord.Formula = amount;

                // Save changes to the database
                _context.Entry(payRateRecord).State = EntityState.Modified;
                _context.SaveChanges();
                // await _context.SaveChangesAsync();

                // Return a success response
                return Ok(new ResponseDTO
                {
                    IsSuccess = true,
                    Message = "Pay rate updated successfully."
                });
            }
        }


        [HttpGet]
        public ResponseDTO GetAndyDriverPayRate()
        {
            try
            {
                using (var _context = new TmwLiveContext())
                {
                    //IEnumerable<AndyDriverPayRate> objList = _context.AndyDriverPayRates.ToList();
                    //response.Result = objList;
                    var objList = (from payRate in _context.AndyDriverPayRates
                                   join driverDetail in _context.AndyDriverPayDetails
                                   on payRate.DriverId equals driverDetail.DriverId
                                   select new
                                   {
                                       payRate.AndyDriverPayRateId,
                                       payRate.DriverId,
                                       payRate.FleetCompanyId,
                                       payRate.RegularRateDayShift,
                                       payRate.RegularRateEveShift,
                                       payRate.RegularRateNightShift,
                                       payRate.RatePerMileage,
                                       payRate.OverTimeRateDayShift,
                                       payRate.OverTimeRateEveShift,
                                       payRate.EffectiveDateTo,
                                       payRate.EffectiveDateFrom,
                                       payRate.WeekendRate,
                                       payRate.IsActive,
                                       payRate.UpdateBy,
                                       payRate.OverTimeRateWeekendShift,
                                       payRate.OverTimeRateNightShift,// or whatever other columns you need from AndyDriverPayRate
                                       driverDetail.DriverFname,  // First Name from DriverPayDetail
                                       driverDetail.DriverLname   // Last Name from DriverPayDetail
                                   }).ToList();

                    // If you want the result as a list of AndyDriverPayRate objects with FName and LName added
                    var enrichedResult = objList.Select(x => new
                    {
                        x.AndyDriverPayRateId,
                        x.DriverId,
                        x.FleetCompanyId,
                        x.RegularRateDayShift,
                        x.RegularRateEveShift,
                        x.RegularRateNightShift,
                        x.RatePerMileage,
                        x.OverTimeRateDayShift,
                        x.OverTimeRateEveShift,
                        x.OverTimeRateWeekendShift,
                        x.WeekendRate,
                        x.IsActive,
                        x.EffectiveDateTo,
                        x.EffectiveDateFrom,
                        x.OverTimeRateNightShift,// or whatever other columns you need from AndyDriverPayRate
                        x.DriverFname,  // First Name from DriverPayDetail
                        x.DriverLname
                    }).ToList();

                    response.Result = enrichedResult;
                }
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }
            return response;
        }

        [HttpGet("{id}")]
        public ResponseDTO GetAndyDriverPayRate(string id)
        {

            try
            {
   
                //using (var _context = new TmwLiveContext())
                //{
                var objList = (from payRate in _context.AndyDriverPayRates
                               join driverDetail in _context.AndyDriverPayDetails
                               on payRate.DriverId equals driverDetail.DriverId
                               where payRate.DriverId == id // Filter for the specific DriverId
                               select new
                               {
                                   payRate.AndyDriverPayRateId,
                                   payRate.DriverId,
                                   payRate.FleetCompanyId,
                                   payRate.RegularRateDayShift,
                                   payRate.RegularRateEveShift,
                                   payRate.RegularRateNightShift,
                                   payRate.RatePerMileage,
                                   payRate.OverTimeRateDayShift,
                                   payRate.OverTimeRateEveShift,
                                   payRate.WeekendRate,
                                   payRate.IsActive,
                                   payRate.EffectiveDateTo,
                                   payRate.EffectiveDateFrom,
                                   payRate.OverTimeRateNightShift,
                                   driverDetail.DriverFname,
                                   driverDetail.DriverLname
                               }).ToList();

                // Enrich the result into a list of objects if needed
                var enrichedResult = objList.Select(x => new
                {
                    x.AndyDriverPayRateId,
                    x.DriverId,
                    x.FleetCompanyId,
                    x.RegularRateDayShift,
                    x.RegularRateEveShift,
                    x.RegularRateNightShift,
                    x.RatePerMileage,
                    x.OverTimeRateDayShift,
                    x.OverTimeRateEveShift,
                    x.WeekendRate,
                    x.IsActive,
                    x.EffectiveDateTo,
                    x.EffectiveDateFrom,
                    x.OverTimeRateNightShift,
                    x.DriverFname,
                    x.DriverLname
                }).ToList();

                response.Result = enrichedResult;
                // }
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }
            return response;
        }

        [HttpPost]
        public async Task<ResponseDTO> PostAndyDriverPayRate(AndyPayRateModelDTO andyDriverPay)
        {
            var response = new ResponseDTO(); // Initialize the response object
            var OverTime = 1.5;
            try
            {
                var driverId = await _context.AndyDriverPayDetails
                             .Where(d => d.DriverId == andyDriverPay.DriverName)
                             .Select(d => d.DriverId)
                             .FirstOrDefaultAsync();

                var exists = await _context.AndyDriverPayRates
                            .AnyAsync(r => r.DriverId == driverId &&
                         r.FleetCompanyId == andyDriverPay.DivisionName);
                // Add the new record to the context
                if (exists)
                {
                    response.IsSuccess = false;
                    response.Message = "Record Alredy Exist!!";
                }
                else
                {
                    List<AndyDriverPayRuleOverTime> allRecords = await _context.AndyDriverPayRuleOverTimes.ToListAsync();
                    decimal OTRate=0,EveningPay =0,NightPay=0,WeekendPay=0,WeekendOT = 0,EveningOT = 0,NightOT = 0;
                    foreach (var record  in allRecords)
                    {
                        switch (record.PayRateName)
                        {
                            case "Weekend Pay":
                                WeekendPay = (decimal)record.Formula;
                                break;

                            case "Night Pay":
                                NightPay = (decimal)record.Formula;
                                break;

                            case "Evening Pay":
                                EveningPay = (decimal)record.Formula;
                                break;

                            case "Regular Over Time":
                                OTRate = (decimal)record.Formula;
                                break;

                            case "Weekend Over Time":
                                WeekendOT = (decimal)record.Formula;
                                break;

                            case "Night Over Time":
                                NightOT = (decimal)record.Formula;
                                break;

                            case "Evening Over Time":
                                 EveningOT = (decimal)record.Formula;
                                break;


                        }


                    }
                    var RegOT = andyDriverPay.RegularPayRate * OTRate;
                    var EvePay = andyDriverPay.RegularPayRate + EveningPay;
                    var NgtPay = andyDriverPay.RegularPayRate + NightPay;
                    var WkndPay = andyDriverPay.RegularPayRate + WeekendPay;
                    var EveOT = andyDriverPay.RegularPayRate * EveningOT;
                    var NgtOT = andyDriverPay.RegularPayRate * NightOT;
                    var WkndOT = andyDriverPay.RegularPayRate * WeekendOT;

                    var andyDriverPayEntity = new AndyDriverPayRate
                    {
                        DriverId = driverId, // andyDriverPay.DriverName,
                        FleetCompanyId = andyDriverPay.DivisionName.ToString(),
                        RatePerMileage = andyDriverPay.RatePerMile,
                        RegularRateDayShift = andyDriverPay.RegularPayRate,
                        RegularRateEveShift = EvePay,//andyDriverPay.RegularPayRateEveningShift,
                        RegularRateNightShift = NgtPay,//andyDriverPay.RegularPayRateNightShift,
                        OverTimeRateDayShift =RegOT, //andyDriverPay.RegularPayRate * Convert.ToDecimal(OverTime),
                        OverTimeRateEveShift = EveOT,//andyDriverPay.RegularPayRateEveningShift * Convert.ToDecimal(OverTime),
                        OverTimeRateNightShift = NgtOT,
                        OverTimeRateWeekendShift = WkndOT,
                        //andyDriverPay.RegularPayRateNightShift * Convert.ToDecimal(OverTime),
                        WeekendRate =WkndPay, 
                       //andyDriverPay.RegularPayRate + 5,
                        UpdateBy = andyDriverPay.UpdateBy,
                        EffectiveDateFrom = andyDriverPay.EffectiveDateFrom,
                        EffectiveDateTo = andyDriverPay.EffectiveDateTo,
                        IsActive = andyDriverPay.IsActive
                    };

                    // Asynchronously save changes to the database
                    // await _context.SaveChangesAsync();

                    _context.AndyDriverPayRates.Add(andyDriverPayEntity);

                    await _context.SaveChangesAsync();
                    // Set the result and success flag in the response
                    response.IsSuccess = true;
                    response.Message = "Driver pay rate created successfully.";
                    response.Result = andyDriverPay; // You might want to return the created entity
                }
                
            }
            catch (Exception ex)
            {
                // Handle any exceptions and return error details
                response.IsSuccess = false;
                response.Message = ex.Message;
            }

            return response;
        }

        [HttpPut("{id:int}")]
        //public async Task<IActionResult> PutAndyDriverPayRate(int id, AndyDriverPayRateDTO andyDriverPay)
        public async Task<ResponseDTO> PutAndyDriverPayRate(int id, AndyDriverPayRateDTO andyDriverPay)
        {
            var response = new ResponseDTO();

            try
            {
                // Step 1: Fetch the existing pay rate entity from the database
                var existingPayRate = await _context.AndyDriverPayRates
                                        .FirstOrDefaultAsync(r => r.AndyDriverPayRateId == id);

                if (existingPayRate == null)
                {
                    response.IsSuccess = false;
                    response.Message = "Pay Rate record not found!";
                    return response;
                }

                // Step 2: Fetch formulas from AndyDriverPayRuleOverTime table
                var payRateRules = await _context.AndyDriverPayRuleOverTimes.ToListAsync();
                decimal OTRate = 0, EveningPay = 0, NightPay = 0, WeekendPay = 0;
                decimal WeekendOT = 0, EveningOT = 0, NightOT = 0;

                foreach (var rule in payRateRules)
                {
                    switch (rule.PayRateName)
                    {
                        case "Weekend Pay":
                            WeekendPay = (decimal)rule.Formula;
                            break;
                        case "Night Pay":
                            NightPay = (decimal)rule.Formula;
                            break;
                        case "Evening Pay":
                            EveningPay = (decimal)rule.Formula;
                            break;
                        case "Regular Over Time":
                            OTRate = (decimal)rule.Formula;
                            break;
                        case "Weekend Over Time":
                            WeekendOT = (decimal)rule.Formula;
                            break;
                        case "Night Over Time":
                            NightOT = (decimal)rule.Formula;
                            break;
                        case "Evening Over Time":
                            EveningOT = (decimal)rule.Formula;
                            break;
                    }
                }

                // Step 3: Update pay rates dynamically
                /*
                 * var RegOT = andyDriverPay.OverTimeRateDayShift > 0 
            ? andyDriverPay.OverTimeRateDayShift // Use directly if greater than 0
            : (andyDriverPay.RegularRateDayShift > 0 
               ? andyDriverPay.RegularRateDayShift * OTRate // Apply formula if RegularRateDayShift is available
               : existingPayRate.RegularRateDayShift * OTRate); // Fallback to existing pay rate formula

                 */
                var RegOT = andyDriverPay.OverTimeRateDayShift > 0 ? andyDriverPay.OverTimeRateDayShift : (andyDriverPay.RegularRateDayShift > 0
               ? andyDriverPay.RegularRateDayShift * OTRate // Apply formula if RegularRateDayShift is available
               : existingPayRate.RegularRateDayShift * OTRate); /*existingPayRate.RegularRateDayShift) * OTRate;*/
                var EvePay = andyDriverPay.RegularRateEveShift > 0
                    ? andyDriverPay.RegularRateEveShift
                     : andyDriverPay.RegularRateDayShift + EveningPay;

                var NgtPay = andyDriverPay.RegularRateNightShift > 0
                    ? andyDriverPay.RegularRateNightShift
                    : andyDriverPay.RegularRateDayShift + NightPay;

                var WkndPay = andyDriverPay.WeekendRate > 0
                    ? andyDriverPay.WeekendRate
                    : andyDriverPay.RegularRateDayShift + WeekendPay;

                // For Overtime Rates
                var EveOT = andyDriverPay.OverTimeRateEveShift > 0
                    ? andyDriverPay.OverTimeRateEveShift
                    : andyDriverPay.RegularRateDayShift * EveningOT;

                var NgtOT = andyDriverPay.OverTimeRateNightShift > 0
                    ? andyDriverPay.OverTimeRateNightShift
                    : andyDriverPay.RegularRateDayShift * NightOT;

                var WkndOT = andyDriverPay.OverTimeRateWeekendShift > 0
                    ? andyDriverPay.OverTimeRateWeekendShift
                    : andyDriverPay.RegularRateDayShift * WeekendOT;
                //var EvePay = andyDriverPay.RegularRateEveShift > 0 ? andyDriverPay.RegularRateDayShift + EveningPay : existingPayRate.RegularRateEveShift;
                //var NgtPay = andyDriverPay.RegularRateNightShift > 0 ? andyDriverPay.RegularRateDayShift + NightPay : existingPayRate.RegularRateNightShift;
                //var WkndPay = andyDriverPay.WeekendRate > 0 ? andyDriverPay.RegularRateDayShift + WeekendPay : existingPayRate.WeekendRate;

                //var EveOT = (andyDriverPay.OverTimeRateEveShift > 0 ? andyDriverPay.RegularRateDayShift : existingPayRate.RegularRateDayShift) * EveningOT;
                //var NgtOT = (andyDriverPay.OverTimeRateNightShift > 0 ? andyDriverPay.RegularRateDayShift : existingPayRate.RegularRateDayShift) * NightOT;
                //var WkndOT = (andyDriverPay.OverTimeRateWeekendShift > 0 ? andyDriverPay.RegularRateDayShift : existingPayRate.RegularRateDayShift) * WeekendOT;

                // Step 4: Update fields in the existing entity
                existingPayRate.RegularRateDayShift = andyDriverPay.RegularRateDayShift > 0 ? andyDriverPay.RegularRateDayShift : existingPayRate.RegularRateDayShift;
                existingPayRate.OverTimeRateDayShift = RegOT;
                existingPayRate.RegularRateEveShift = EvePay;
                existingPayRate.OverTimeRateEveShift = EveOT;
                existingPayRate.RegularRateNightShift = NgtPay;
                existingPayRate.OverTimeRateNightShift = NgtOT;
                existingPayRate.WeekendRate = WkndPay;
                existingPayRate.OverTimeRateWeekendShift = WkndOT;
                existingPayRate.RatePerMileage = andyDriverPay.RatePerMileage > 0 ? andyDriverPay.RatePerMileage : existingPayRate.RatePerMileage;
                existingPayRate.EffectiveDateFrom = andyDriverPay.EffectiveDateFrom ?? existingPayRate.EffectiveDateFrom;
                existingPayRate.EffectiveDateTo = andyDriverPay.EffectiveDateTo ?? existingPayRate.EffectiveDateTo;
                existingPayRate.IsActive = andyDriverPay.IsActive;

                // Step 5: Save changes
                await _context.SaveChangesAsync();

                response.IsSuccess = true;
                response.Message = "Pay Rate updated successfully.";
                response.Result = existingPayRate;
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }

            return response;
            //return NoContent();
        }

        //old code ..
        //public async Task<IActionResult> PutAndyDriverPayRate(int id, AndyDriverPayRateDTO andyDriverPay)
        /*
         *  {
             if (id == null)
             {
                 return BadRequest();
             }

             _context.Entry(andyDriverPay).State = EntityState.Modified;

             try
             {
                 await _context.SaveChangesAsync();
             }
             catch (DbUpdateConcurrencyException)
             {
                 if (!AndyDriverPayRateExists(id))
                 {
                     return NotFound();
                 }
                 else
                 {
                     throw;
                 }
             }

             return NoContent();
         }
         */

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteAndyDriverPayRates(int id)
        {
            var andyDriverRate = await _context.AndyDriverPayRates.FindAsync(id);
            if (andyDriverRate == null)
            {
                return NotFound();
            }

            _context.AndyDriverPayRates.Remove(andyDriverRate);
            await _context.SaveChangesAsync();

            return NoContent();
        }


    }
}
