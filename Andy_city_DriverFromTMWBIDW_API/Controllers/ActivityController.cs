using Andy.Services.Andy_city_DriverFromTMWBIDW_API.DTO;
using Andy_city_DriverFromTMWBIDW_API.DTO;
using Andy_city_DriverFromTMWBIDW_API.Models;
using Andy_city_DriverFromTMWBIDW_API.Models.SecondDb;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Andy_city_DriverFromTMWBIDW_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActivityController : ControllerBase
    {
        private ResponseDTO response;
        public ActivityController()
        {
            response = new ResponseDTO();
        }
        [HttpGet]
        public ResponseDTO Get()
        {
            using (var _context1 = new AndyMiscContext())
            {

            }
            return response;
        }

        [HttpGet]
        [Route("{sdate}/{edate}")]
        public ResponseDTO Get(DateTime sdate, DateTime edate)
        {
            DateOnly startDate = DateOnly.FromDateTime(sdate);
            DateOnly endDate = DateOnly.FromDateTime(edate);
            var response = new ResponseDTO();

            using (var _context1 = new AndyMiscContext())
            {
                // Step 1: Retrieve distinct driver data for each day within the date range
                var workDayActivities = _context1.AndyDriverWorkbookRecordV1s
                    .Where(a => a.Dateonly >= startDate && a.Dateonly <= endDate)
                    .GroupBy(a => new { a.MppId, a.Dateonly }) // Group by DriverID and Date
                    .Select(g => new WorkDayActivitesDTO
                    {
                        DriverID = g.Key.MppId,
                        DriverName = "N/A",//g.FirstOrDefault()?.MppLastfirst ?? string.Empty, // Use null-coalescing to handle potential nulls
                        Fleet = "N/A",//g.FirstOrDefault()?.TrlFleet ?? string.Empty,
                        Division = "N/A",// g.FirstOrDefault()?.OrdRevtype2 ?? string.Empty,
                        ActivityDate = (DateOnly)g.Key.Dateonly,
                      //  OrderNo = g.FirstOrDefault()?.NoteOrdernum ?? string.Empty,
                        TotalHrs = g.Sum(a => a.TotalHrsRaw), // Sum the TotalHrs for the day
                        DriverPayRate ="N/A",// g.FirstOrDefault()?.DriverPayRate ?? string.Empty,

                        // Step 2: Populate ActivityLists with all activities for this driver on this date
                        ActivityLists = g.Select(a => new ActivitiesListDTO
                        {
                            TractorNo = a.NoteTractor,
                            ActivityName = a.ActivityCodeName,
                            Activity_Time = (DateTime)a.ActivityDate,
                            Activity_Minutes = (decimal)a.OrderMins,
                            Kms = (decimal)a.OdometerKm,
                            OrderNo = a.NoteOrdernum,
                            MovNumber = a.NoteMovenum,
                            Trailer = a.NoteTrailer1,
                            Fleet = a.TrlFleet,
                            Location = a.Location
                        }).ToList()
                    })
                    .ToList();

                // Step 3: Add the result to your response DTO
                response.Result = workDayActivities;
            }

            return response;
        }
        [HttpGet]
        [Route("{id}/{sdate}/{edate}")]
        public ResponseDTO GetExactHours(DateTime sdate, DateTime edate, string mpp_id)
        {
            // Convert DateTime to DateOnly for filtering
            DateOnly startDate = DateOnly.FromDateTime(sdate);
            DateOnly endDate = DateOnly.FromDateTime(edate);

            var response = new ResponseDTO();
            var resultList = new List<object>(); // Store results for each date

            using (var _context1 = new AndyMiscContext())
            {
                using (var _context2 = new SecondDbContext())
                {
                    // Step 1: Retrieve unique records for the specified mpp_id from ManpowerProfiles
                    var manpowerProfile = _context2.Manpowerprofiles
                        .Where(mp => mp.MppId == mpp_id)
                        .Select(mp => new
                        {
                            mp.MppId,
                            mp.MppType1,
                            mp.MppFleet
                        })
                        .FirstOrDefault();

                    // Step 2: Loop through each day in the range
                    for (var currentDate = startDate; currentDate <= endDate; currentDate = currentDate.AddDays(1))
                    {
                        // Fetch records for the current date
                        var dailyRecords = _context1.AndyDriverWorkbookRecordV1s
                            .Where(td => td.MppId == mpp_id && td.Dateonly == currentDate)
                            .Select(td => new
                            {
                                td.MppId,
                                td.Dateonly,
                                td.TotalHrsRaw
                            })
                            .ToList();

                        // Aggregate results for the current date
                        var dailyResult = new
                        {
                            Date = currentDate,
                            TotalHours = dailyRecords.First().TotalHrsRaw ,//(dr => dr.TotalHrsRaw),
                            Records = dailyRecords,
                            ManpowerProfile = manpowerProfile // Attach the profile for each date
                        };

                        // Add the daily result to the final list
                        resultList.Add(dailyResult);
                    }

                    // Step 3: Assign the final result to the response
                    response.Result = resultList;
                }
            }

            return response;
        }


        // this is Method for updating and hours and OverTime ..
        [HttpGet]
        [Route("ExactHours/{id}/{sdate}/{edate}")]
        public ResponseDTO Get(DateTime sdate, DateTime edate, string mpp_id)
        {
            // Convert DateTime to DateOnly for filtering
            DateOnly startDate = DateOnly.FromDateTime(sdate);
            DateOnly endDate = DateOnly.FromDateTime(edate);

            var response = new ResponseDTO();
            var resultList = new List<object>(); // Store results for each date

            using (var _context1 = new AndyMiscContext())
            {
                using (var _context2 = new SecondDbContext())
                {
                    // Step 1: Retrieve unique records for the specified mpp_id from ManpowerProfiles
                    var manpowerProfile = _context2.Manpowerprofiles
                        .Where(mp => mp.MppId == mpp_id)
                        .Select(mp => new
                        {
                            mp.MppId,
                            mp.MppType1,
                            mp.MppFleet
                        })
                        .FirstOrDefault();

                    // Step 2: Loop through each day in the range
                    for (var currentDate = startDate; currentDate <= endDate; currentDate = currentDate.AddDays(1))
                    {
                        // Fetch records for the current date
                        var dailyRecords = _context1.AndyDriverWorkbookRecordV1s
                            .Where(td => td.MppId == mpp_id && td.Dateonly == currentDate)
                            .Select(td => new
                            {
                                td.MppId,
                                td.Dateonly,
                                td.TotalHrsRaw
                            })
                            .ToList();

                        // Aggregate results for the current date
                        var dailyResult = new
                        {
                            Date = currentDate,
                            TotalHours = dailyRecords.First().TotalHrsRaw,//(dr => dr.TotalHrsRaw),
                            Records = dailyRecords,
                            ManpowerProfile = manpowerProfile // Attach the profile for each date
                        };

                        // Add the daily result to the final list
                        resultList.Add(dailyResult);
                    }

                    // Step 3: Assign the final result to the response
                    response.Result = resultList;
                }
            }

            return response;
        }
    }
}
