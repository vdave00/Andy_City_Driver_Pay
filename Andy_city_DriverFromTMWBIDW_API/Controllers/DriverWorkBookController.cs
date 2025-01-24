using Andy.Services.Andy_city_DriverFromTMWBIDW_API.DTO;
using Andy_city_DriverFromTMWBIDW_API.DTO;
using Andy_city_DriverFromTMWBIDW_API.Models;
using Andy_city_DriverFromTMWBIDW_API.Models.SecondDb;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Andy_city_DriverFromTMWBIDW_API.Controllers
{
  
    [Route("api/DriverWorkBook")]
    [ApiController]
    public class DriverWorkBookController : ControllerBase
    {

        private ResponseDTO response;
        public DriverWorkBookController()
        {
            response = new ResponseDTO();
        }
        [HttpGet]
        public ResponseDTO Get()
        {
            using (var _context1 = new AndyMiscContext())
            {


                using (var _context2 = new SecondDbContext())
                {

                    // Retrieve distinct MppId along with additional fields from AndyDriverWorkbookRecordV1s
                    var profileRecords = _context1.AndyDriverWorkbookRecordV1s
                                                   .Select(td => new
                                                   {
                                                       td.MppId,
                                                       td.TotalHrsRaw,
                                                       //td.NoteOrdernum
                                                   })
                                                   .Distinct()
                                                   .ToList();

                    // Retrieve all records from ManpowerProfiles
                    var allManpowerProfiles = _context2.Manpowerprofiles
                                                        .Select(tm => new
                                                        {
                                                            tm.MppId,
                                                            tm.MppType1,
                                                            tm.MppFleet,
                                                            tm.MppType3,
                                                            tm.MppType4,
                                                            tm.MppPayto,
                                                            tm.MppTeamleader,
                                                            tm.MppFirstname,
                                                            tm.MppLastname,
                                                        })
                                                        .Distinct()
                                                        .ToList();

                    // Perform an inner join using LINQ with case-insensitive comparison on MppId
                    var workbookRecords = (from tm in allManpowerProfiles
                                           join pr in profileRecords on tm.MppId.ToLower() equals pr.MppId.ToLower()
                                           select new
                                           {
                                               tm.MppId,
                                               tm.MppFirstname,
                                               tm.MppLastname,
                                               tm.MppType1,
                                               tm.MppFleet,
                                               pr.TotalHrsRaw,      // Additional fields from AndyDriverWorkbookRecordV1s
                                                                    // pr.NoteOrdernum       // Additional fields from AndyDriverWorkbookRecordV1s
                                           })
                                           .Distinct()
                                           .ToList();

                    // Combine results as needed
                    var combinedResults = workbookRecords
                                           .Select(tm => new DriverDTO
                                           {
                                               Driverid = tm.MppId,
                                               DriverFname = tm.MppFirstname,
                                               DriverLname = tm.MppLastname,
                                               DriverFleet = tm.MppFleet,
                                               Eld = tm.MppFleet,
                                               TotalHours = tm.TotalHrsRaw,    // Map additional fields to DTO
                                                                               // OrderNumber = tm.NoteOrdernum     // Map additional fields to DTO
                                           })
                                           .Distinct()
                                           .ToList();

                    // Return the results
                    response.Result = combinedResults;

                    //response.Result =combinedResults;
                }
            }
            return response;
        }


        /// <summary>
        /// /This Method for Get Accurate Total Hours..
        /// </summary>
        /// <param name="sdate"></param>
        /// <param name="edate"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("api/drivers/DriverRecords{sdate}/{edate}")]
        //[Route("api/drivers")] 
        public ResponseDTO GetDriverRecords(DateTime sdate, DateTime edate, DateTime phyPayPeriod)
        {
            var response = new ResponseDTO();

            // Convert DateTime to string in "yyyy-MM-dd" format
            //string Sdate = sdate.ToString("yyyy-MM-dd");
            //string Edate = edate.ToString("yyyy-MM-dd");
            DateOnly Sdate = DateOnly.Parse(sdate.ToString("yyyy-MM-dd"));
            DateOnly Edate = DateOnly.Parse(edate.ToString("yyyy-MM-dd"));
            DateOnly PDate = DateOnly.Parse(phyPayPeriod.ToString("yyyy-MM-dd"));

            using (var _context1 = new AndyMiscContext())
            {
                using (var _Context2 = new SecondDbContext())
                {

                    var records = _context1.AndyCityDriverWorkingHoursRecords
                               .Where(td => td.DateOfWork >= Sdate && td.DateOfWork >= Edate)
                               .GroupBy(td => td.DriverId)
                               .Select(g => new
                               {
                                   DriverID = g.Key,
                                   TotalSeconds = g.Sum(td => td.CalculateHours)
                               }).ToList().Distinct();

                    // Retrieve the related ManpowerProfiles from the second context (ManpowerProfiles)
                    var manpowerProfiles = _Context2.Manpowerprofiles
                        .Select(mp => new
                        {
                            MppId = mp.MppId,
                            Mpp_FirstName = mp.MppFirstname,
                            Mpp_LastName = mp.MppLastname,
                            Mpp_Type = mp.MppType1
                        }).ToList();

                    // Join the two lists in memory
                    var joinedRecords = from record in records
                                        join profile in manpowerProfiles
                                        on record.DriverID.ToLower() equals profile.MppId.ToLower()
                                        select new
                                        {
                                            DriverID = record.DriverID,
                                            TotalSeconds = record.TotalSeconds,
                                            Mpp_FirstName = profile.Mpp_FirstName,
                                            Mpp_LastName = profile.Mpp_LastName,
                                            Mpp_Type = profile.Mpp_Type,
                                            PayPeriod = PDate
                                        };


                    response.Result = joinedRecords;
                }
            }

            return response;
        }



        [HttpGet]
        [Route("api/drivers/{sdate}/{edate}/{phyPayPeriod}")]
        //[Route("api/drivers")] 
        public ResponseDTO Get(DateTime sdate, DateTime edate, DateTime phyPayPeriod)
        {
            DateOnly Sdate = DateOnly.FromDateTime(sdate);
            DateOnly Edate = DateOnly.FromDateTime(edate);
            DateOnly PDate = DateOnly.Parse(phyPayPeriod.ToString("yyyy-MM-dd"));
            var response = new ResponseDTO();

            using (var _context1 = new AndyMiscContext())
            {
                using (var _context2 = new SecondDbContext())
                {

                    ////Step 1: Retrieve distinct Dateonly and MppId
                    var profileRecords = _context1.AndyCityDriverWorkingHoursRecords
                        .Where(td => td.DateOfWork >= Sdate && td.DateOfWork <= Edate)
                        .GroupBy(td => new { td.DriverId, td.DateOfWork,td.Seconds }) // Group by MppId and Dateonly
                        .Select(g => new
                        {
                            MppId = g.Key.DriverId,
                            DateOnly = g.Key.DateOfWork,
                            //Seconds = g.Sum(td => td.Seconds)
                            

                            // TotalHrsRaw = g.FirstOrDefault().TotalHrsRaw // Select the first record for each date
                        })
                        .Distinct()
                        .ToList();

                    // Step 2: Retrieve unique records from ManpowerProfiles
                    var allManpowerProfiles = _context2.Manpowerprofiles
                        .Select(tm => new
                        {
                            tm.MppId,
                            tm.MppType1,
                            tm.MppFleet,
                            tm.MppFirstname,
                            tm.MppLastname,
                        })
                        .Distinct()
                        .ToList();

                    // Step 3: Join the two collections (profileRecords and allManpowerProfiles)
                    var workbookRecords = (from tm in allManpowerProfiles
                                           join pr in profileRecords on tm.MppId.ToLower() equals pr.MppId.ToLower()
                                           select new
                                           {
                                               tm.MppId,
                                               tm.MppFirstname,
                                               tm.MppLastname,
                                               tm.MppType1,
                                               tm.MppFleet,
                                               
                                               //pr.TotalHrsRaw
                                           })
                                           .ToList();

                    // Step 4: Group by MppId, and calculate the total hours and number of days worked
                    var combinedResults = workbookRecords
                        .GroupBy(x => x.MppId) // Group by MppId to calculate totals for each driver
                        .Select(g => new DriverDTO
                        {
                            Driverid = g.Key,
                            DriverFname = g.First().MppFirstname,
                            DriverLname = g.First().MppLastname,
                            DriverFleet = g.First().MppType1,
                            //   Eld = g.First().MppType2,
                            Drivertype = g.Count()
                            //InsertDate = phyPayPeriod// Number of distinct days worked
                             //TotalHours = g.Sum(x => x.) // Sum total hours worked
                        })
                        .ToList();

                    // Step 5: Set the response result
                    response.Result = combinedResults;
                }
            }
            return response;
        }


        //[HttpGet]
        //[Route("api/drivers/{id}/{sdate}/{edate}")]
        //public ResponseDTO Get(string id, DateTime sdate, DateTime edate)
        //{
        //    try
        //    {
        //        DateOnly Sdate = DateOnly.FromDateTime(sdate);
        //        DateOnly Edate = DateOnly.FromDateTime(edate);

        //        using (var _context = new AndyMiscContext())
        //        {

        //            var distinctRecords = new List<DayActivitiesDTO>();

        //            // Loop through each day in the specified date range
        //            for (var currentDate = Sdate; currentDate <= Edate; currentDate = currentDate.AddDays(1))
        //            {
        //                // Fetch records for the current date
        //                var recordsForDay = _context.AndyDriverWorkbookRecordV1s
        //                    .Where(u => u.MppId == id && u.Dateonly == currentDate)
        //                    .ToList();

        //                ordNumberDTO od = new ordNumberDTO();
        //                if (recordsForDay.Any())
        //                {
        //                    // Aggregate data for the current day
        //                    var dayRecord = new DayActivitiesDTO
        //                    {
        //                        workDay = currentDate, // Set work day

        //                        // Calculate total hours for the day (sum of unique TotalHrsRaw values)
        //                        Totalhrs = recordsForDay
        //                            .Select(x => Convert.ToInt32(x.Mysecond2) / 60.0)
        //                            .Distinct() // Keep only unique values
        //                            .Sum()
        //                            .ToString(),

        //                        // Group by order number and select necessary fields for each order
        //                        OrdNumber = recordsForDay
        //                            .GroupBy(x => x.NoteOrdernum)
        //                            .Select(orderGroup => new ordNumberDTO
        //                            {
        //                                Ordnumber = (int)orderGroup.Key, // Get the order number
        //                                TotalHoursForOrder = (orderGroup
        //                                    .GroupBy(y => new { y.Mysecond2, y.NoteMovenum, y.NoteTractor, y.NoteTrailer1, y.ActivityCodeName, y.ActivityDate }) // Group to find unique rows
        //                                    .Sum(uniqueGroup => Convert.ToSingle(uniqueGroup.Key.Mysecond2) / 3600)),
        //                                MovNumber = orderGroup.Select(x => x.NoteMovenum).Distinct().FirstOrDefault(),
        //                                TruckNumber = orderGroup.Select(x => x.NoteTractor).Distinct().FirstOrDefault(),
        //                                TrailerNumber = orderGroup.Select(x => x.NoteTrailer1).Distinct().FirstOrDefault()
        //                            })
        //                            .ToList()
        //                    };

        //                    // Add the daily record to the list
        //                    distinctRecords.Add(dayRecord);
        //                }
        //            }

        //            response.Result = distinctRecords;
        //            response.Result = (distinctRecords);
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        response.IsSuccess = false;
        //        response.Message = ex.Message;
        //    }
        //    return response;
        //}

        //apply for round 
        private double ApplyRoundingRule(double totalHours)
        {
            // Extract the fractional part (after the decimal point)
            double fractionalPart = totalHours % 1;

            // Round the fractional part according to the defined rules
            if (fractionalPart >= 0 && fractionalPart <= 0.35)
            {
                return Math.Floor(totalHours) + 0.25; // Round to the nearest 0.25
            }
            else if (fractionalPart > 0.35 && fractionalPart <= 0.65)
            {
                return Math.Floor(totalHours) + 0.50; // Round to the nearest 0.50
            }
            else if (fractionalPart > 0.65 && fractionalPart <= 0.85)
            {
                return Math.Floor(totalHours) + 0.75; // Round to the nearest 0.75
            }
            else if (fractionalPart > 0.85)
            {
                return Math.Ceiling(totalHours) + 1; // Round to the next whole hour and add 1
            }
            else
            {
                return totalHours; // No rounding if there are no fractions
            }
        }


        [HttpGet]
        [Route("Fleet")]
        public ResponseDTO GetFleet()
        {
            var response = new ResponseDTO();
            using (var _context1 = new SecondDbContext())
            {
                //var response = new ResponseDTO();

                var distinctFleets = _context1.Manpowerprofiles
            .Select(record => record.MppType1) // Select the Fleet column
            .Distinct() // Get only unique Fleet values
            .ToList();

                response.Result = distinctFleets;
                response.Message = "Distinct fleets fetched successfully";
                //  response.StatusCode = 200;

                return response;
            }

            // return response;
        }

        //New Code For Getting information from store procedure ..
        [HttpGet]
        [Route("api/drivers/DriverRecords/{id}/{sdate}/{edate}")]
        public ResponseDTO GetRecords(string id, DateTime sdate, DateTime edate)
        {
            var response = new ResponseDTO();

            try
            {
                // Convert input dates to DateOnly for easier date handling
                DateOnly Sdate = DateOnly.FromDateTime(sdate);
                DateOnly Edate = DateOnly.FromDateTime(edate);

                using (var _context = new AndyMiscContext())
                {
                    // Initialize the final result list
                    var allRecords = new List<DayActivitiesDTO>();

                    // Loop through each day in the specified date range
                    for (var currentDate = Sdate; currentDate <= Edate; currentDate = currentDate.AddDays(1))
                    {
                        // Convert the current date to string format (e.g., "2024-12-11")
                        //string _WorkDate = currentDate.ToString("yyyy-MM-dd");

                        // Fetch records for the current date
                        var workDateRecords = _context.AndyCityDriverWorkingHoursRecords
                            .Where(u => u.DriverId == id && u.DateOfWork == currentDate)
                            .ToList();

                        // If no records found, skip to the next day
                        if (!workDateRecords.Any())
                            continue;

                        // Create a DayActivitiesDTO for the current date
                        var dayActivity = new DayActivitiesDTO
                        {
                            workDay = currentDate,
                            //Totalhrs = .Sum(x => x.Seconds / 3600.0), // Total hours for the day
                            OrdNumber = workDateRecords
                                .GroupBy(x => x.OrderNumber)
                                .Select(orderGroup => new ordNumberDTO
                                {
                                    Ordnumber = Convert.ToInt32(orderGroup.Key), // Order number Math.Round(orderGroup.Sum(x => x.Seconds / 3600.0), 2)
                                    TotalHoursForOrder = (double?)Math.Round((decimal)orderGroup.Sum(x => x.Seconds / 3600.0), 2), // Total hours for the order
                                    MovNumber = orderGroup.Select(x => x.MoveNumber).FirstOrDefault(), // Movement number
                                    TruckNumber = orderGroup.Select(x => x.Tractor).FirstOrDefault(), // Truck number
                                    TrailerNumber = orderGroup.Select(x => x.Trailer).FirstOrDefault(), // Trailer number
                                    Legnumber = orderGroup.Select(x => x.LegNumber).FirstOrDefault(),
                                    TMW_OrderNumber = orderGroup.Select(X => X.OrderNumberTmw).FirstOrDefault(),
                                    PayRate = (decimal?)orderGroup.Select(x => x.PayRate).FirstOrDefault(),
                                    // Total calculated hours (optional)
                                })
                                .ToList()
                        };

                        // Add the current day's activity to the result list
                        allRecords.Add(dayActivity);
                    }

                    // Set the response with the aggregated data
                    response.Result = allRecords;
                    response.IsSuccess = true;
                    response.Message = "Records retrieved successfully.";
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions
                response.IsSuccess = false;
                response.Message = $"Error: {ex.Message}";
            }

            return response;
        }

        //End ..

        // This Procedure for Entering hours into table and also ..
        //Test 
        private double RoundToNearestQuarterHourFromDecimal(double decimalHours)
        {
            // Extract the whole number part (hours)
            int hours = (int)decimalHours;

            // Extract the fractional part and convert to minutes
            double fractionalPart = decimalHours - hours;
            int minutes = (int)(fractionalPart * 100); // Since it's not normalized to 60 minutes

            // Apply rounding rules
            if (minutes <= 5)
                minutes = 0;
            else if (minutes > 5 && minutes <= 17)        // 0 to 17 -> round to .25
                minutes = 25;
            else if (minutes <= 50)   // 28 to 50 -> round to .50
                minutes = 50;
            else if ( minutes > 60 &&minutes <= 80)   // 51 to 80 -> round to .75
                minutes = 75;
            else                      // > 80 -> add 1 hour
                return hours + 1;     // Increment the hour

            // Convert back to decimal hours with the rounded minutes
            return hours + (minutes / 100.0);
        }

        //End of test
        [HttpGet]
        [Route("api/drivers/DriverRecordsHours/{id}/{sdate}/{edate}/{phyPayPeriod}")]
        public ResponseDTO GetRecordsHours(string id, DateTime sdate, DateTime edate, DateTime phyPayPeriod)
        {
            var response = new ResponseDTO();

            try
            {
                // Convert input dates to DateOnly for easier date handling
                DateOnly Sdate = DateOnly.FromDateTime(sdate);
                DateOnly Edate = DateOnly.FromDateTime(edate);
                DateOnly PDate = DateOnly.FromDateTime(phyPayPeriod);

                using (var _context = new AndyMiscContext())
                {

                    // Initialize the final result lists
                    var allRecords = new List<DayActivitiesDTO>();
                    var weeklyRecords = new List<WeekActivitiesDTO>();

                    // Variables to track weekly and overtime data
                    double weeklyHours = 0;
                    double cumulativeHours = 0; // Tracks hours from the starting point
                    DateOnly? currentWeekStart = Sdate;

                    // Loop through each day in the specified date range
                    for (var currentDate = Sdate; currentDate <= Edate; currentDate = currentDate.AddDays(1))
                    {
                        // Fetch records for the current date
                        var workDateRecords = _context.AndyCityDriverWorkingHoursRecords
                            .Where(u => u.DriverId == id && u.DateOfWork == currentDate)
                            .ToList();


                        var Division = _context.AndyCityDriverWorkingHoursRecords
                                        .Where(u => u.DriverId == id && u.DateOfWork == currentDate)
                                        .Select(u => u.Division)
                                       .FirstOrDefault(u => u != null);


                        // If no records found, skip to the next day
                        if (!workDateRecords.Any())
                            continue;

                        // Check if the current day is a weekend
                        bool isWeekend = currentDate.DayOfWeek == DayOfWeek.Saturday || currentDate.DayOfWeek == DayOfWeek.Sunday;

                        // Group by OrderNumber and calculate total hours per order
                        var orders = new List<ordNumberDTO>();
                        foreach (var orderGroup in workDateRecords.GroupBy(x => x.OrderNumber))
                        {
                            double totalHoursForOrder = (double)Math.Round((decimal)orderGroup.Sum(x => x.Seconds / 3600.0), 2);

                            totalHoursForOrder = RoundToNearestQuarterHourFromDecimal(totalHoursForOrder);
                            // Check for overtime
                            if (cumulativeHours + totalHoursForOrder > 60)
                            {
                                // Calculate regular and overtime hours
                                double regularHours = 60 - cumulativeHours;
                                double overtimeHours = totalHoursForOrder - regularHours;

                                // Round overtime hours
                                regularHours = RoundToNearestQuarterHourFromDecimal(regularHours);
                                overtimeHours = RoundToNearestQuarterHourFromDecimal(overtimeHours);
                                using (var _context2 = new SecondDbContext())
                                {

                                    //PayRate Fetch
                                    var RegPayRate = _context2.AndyDriverPayRates
                                        .Where(p => p.DriverId == id && p.FleetCompanyId == Division)
                                        .Select(p => p.RegularRateDayShift) // Adjust the column name as per your database schema
                                        .FirstOrDefault();

                                    var WeekendPayRate = isWeekend
                                           ? _context2.AndyDriverPayRates
                                           .Where(p => p.DriverId == id && p.FleetCompanyId == Division)
                                           .Select(p => p.WeekendRate) // Adjust this to the actual column name for weekend pay
                                           .FirstOrDefault()
                                           : null;

                                    // Use Weekend Pay if available, otherwise Regular Pay
                                    var applicablePayRate = isWeekend && WeekendPayRate != null ? WeekendPayRate : RegPayRate;

                                    // new condition for not get orders without ordnumber and less than 10 minutes .. 
                                    

                                    // Add regular hours to the original order
                                    orders.Add(new ordNumberDTO
                                    {
                                        Ordnumber = Convert.ToInt32(orderGroup.Key),
                                        TotalHoursForOrder = regularHours,
                                        MovNumber = orderGroup.Select(x => x.MoveNumber).FirstOrDefault(),
                                        TruckNumber = orderGroup.Select(x => x.Tractor).FirstOrDefault(),
                                        TrailerNumber = orderGroup.Select(x => x.Trailer).FirstOrDefault(),
                                        Legnumber = orderGroup.Select(x => x.LegNumber).FirstOrDefault(),
                                        TMW_OrderNumber = orderGroup.Select(X => X.OrderNumberTmw).FirstOrDefault(),
                                        PayRate = RegPayRate, // instead of RegPay Rate .. 
                                        PayPeriod = PDate,
                                        PydAmount = (decimal?)orderGroup.Select(x => x.TotalPay).FirstOrDefault(),
                                        Notes = orderGroup.Select(x => x.Notes).FirstOrDefault(),
                                        //PaidHours= orderGroup.Select(x =>x.PaidHours).FirstOrDefault(),
                                        PaidHours = orderGroup.Select(x => x.PaidHours).FirstOrDefault(),
                                        Division=Division,

                                    });


                                    // Fetch OT PayRate for the driver
                                    var otPayRate = _context2.AndyDriverPayRates
                                        .Where(p => p.DriverId == id && p.FleetCompanyId == Division)
                                        .Select(p => p.OverTimeRateDayShift) // Adjust the column name as per your database schema
                                        .FirstOrDefault();


                                    // Create a new order for the overtime hours
                                    orders.Add(new ordNumberDTO
                                    {

                                        DriverId = id,
                                        Ordnumber = Convert.ToInt32(orderGroup.Key),
                                        TotalHoursForOrder = overtimeHours,
                                        MovNumber = orderGroup.Select(x => x.MoveNumber).FirstOrDefault(),
                                        TruckNumber = orderGroup.Select(x => x.Tractor).FirstOrDefault(),
                                        TrailerNumber = orderGroup.Select(x => x.Trailer).FirstOrDefault(),
                                        Legnumber = orderGroup.Select(x => x.LegNumber).FirstOrDefault(),
                                        TMW_OrderNumber = orderGroup.Select(X => X.OrderNumberTmw).FirstOrDefault(),
                                        PayRate = otPayRate,
                                        PayPeriod = PDate,
                                        PydAmount = (decimal?)orderGroup.Select(x => x.TotalPay).FirstOrDefault(),
                                        Notes = orderGroup.Select(x => x.Notes).FirstOrDefault(),
                                        OTNotes = "OverTimeOrder",
                                        Division = Division,

                                        //PayRate = orderGroup.Select(x => x.PayRate).FirstOrDefault()
                                    });
                                }
                                // Update cumulative hours
                                cumulativeHours = 60 + overtimeHours;
                            }
                            else
                            {
                                using (var _context2 = new SecondDbContext())
                                {
                                    var RegPayRate = _context2.AndyDriverPayRates
                                   .Where(p => p.DriverId == id && p.FleetCompanyId == Division)
                                   .Select(p => p.RegularRateDayShift) // Adjust the column name as per your database schema
                                   .FirstOrDefault();
                                    // No overtime, add the order as-is
                                    var WeekendPayRate = isWeekend
                                          ? _context2.AndyDriverPayRates
                                          .Where(p => p.DriverId == id && p.FleetCompanyId == Division)
                                          .Select(p => p.WeekendRate) // Adjust this to the actual column name for weekend pay
                                          .FirstOrDefault()
                                          : null;

                                    // Use Weekend Pay if available, otherwise Regular Pay
                                    var applicablePayRate = isWeekend && WeekendPayRate != null ? WeekendPayRate : RegPayRate;

                                    orders.Add(new ordNumberDTO
                                    {
                                        DriverId = id,
                                        Ordnumber = Convert.ToInt32(orderGroup.Key),
                                        TotalHoursForOrder = totalHoursForOrder,
                                        MovNumber = orderGroup.Select(x => x.MoveNumber).FirstOrDefault(),
                                        TruckNumber = orderGroup.Select(x => x.Tractor).FirstOrDefault(),
                                        TrailerNumber = orderGroup.Select(x => x.Trailer).FirstOrDefault(),
                                        Legnumber = orderGroup.Select(x => x.LegNumber).FirstOrDefault(),
                                        TMW_OrderNumber = orderGroup.Select(X => X.OrderNumberTmw).FirstOrDefault(),
                                        PayRate = applicablePayRate, //change the PayRate .. 
                                        PayPeriod = PDate,
                                        PydAmount = (decimal?)orderGroup.Select(x => x.TotalPay).FirstOrDefault(),
                                        PaidHours = orderGroup.Select(x => x.PaidHours).FirstOrDefault(),
                                        Division = Division,
                                    });

                                    // Update cumulative hours
                                    cumulativeHours += totalHoursForOrder;
                                }
                            }
                        }

                        // Calculate total hours for the day
                        double totalHoursForDay = orders.Sum(order => order.TotalHoursForOrder ?? 0);

                        // Create a DayActivitiesDTO for the current date
                        var dayActivity = new DayActivitiesDTO
                        {
                            workDay = currentDate,
                            Totalhrs = totalHoursForDay, // Total hours for the day
                            OrdNumber = orders
                        };

                        // Add the current day's activity to the result list
                        allRecords.Add(dayActivity);

                        // Track weekly data
                        // var startOfWeek = currentDate.AddDays(-(int)currentDate.DayOfWeek); // Start of the current week (Sunday)
                        var startOfWeek = Sdate;
                        if (currentWeekStart == null || startOfWeek != currentWeekStart)
                        {
                            // If a new week starts, finalize the previous week's record
                            if (currentWeekStart != null)
                            {
                                weeklyRecords.Add(new WeekActivitiesDTO
                                {
                                    WeekStartDate = currentWeekStart.Value,
                                    WeekEndDate = currentWeekStart.Value.AddDays(6),
                                    WeekHours = weeklyHours,
                                    DayActivities = allRecords
                                        .Where(record => record.workDay >= currentWeekStart.Value && record.workDay <= currentWeekStart.Value.AddDays(6))
                                        .ToList()
                                });
                            }

                            // Reset weekly data for the new week
                            currentWeekStart = startOfWeek;
                            weeklyHours = 0;
                        }

                        // Add daily hours to weekly hours
                        weeklyHours += totalHoursForDay;
                    }

                    // Finalize the last week's record
                    if (currentWeekStart != null)
                    {
                        weeklyRecords.Add(new WeekActivitiesDTO
                        {
                            WeekStartDate = currentWeekStart.Value,
                            WeekEndDate = currentWeekStart.Value.AddDays(6),
                            WeekHours = weeklyHours,
                            DayActivities = allRecords
                                .Where(record => record.workDay >= currentWeekStart.Value && record.workDay <= currentWeekStart.Value.AddDays(6))
                                .ToList()
                        });
                    }

                    // Set the response with the aggregated data
                    response.Result = weeklyRecords;
                    response.IsSuccess = true;
                    response.Message = "Records retrieved successfully.";
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions
                response.IsSuccess = false;
                response.Message = $"Error: {ex.Message}";
            }

            return response;
        }

        [HttpPost]
        //new code
        public async Task<ResponseDTO> AddPayDetails(PayDetailsDTO payDetails) 
        {
            ResponseDTO response = new ResponseDTO();
            if (payDetails?.PEntrylist == null || !payDetails.PEntrylist.Any())
            {
                response.IsSuccess = false;
                response.Result = "Data";
                response.Message = "Entry is null !";

                return response;
            }
            else
            {
                try
                {
                    using (var _context = new AndyMiscContext())
                    {
                        using (var _context2 = new SecondDbContext())
                        {
                            // Process the pay details
                            foreach (var entry in payDetails.PEntrylist)
                            {
                                var driverId = entry.Driverid;
                                var orderNumber = entry.Ord_Number;

                                if (driverId != null && orderNumber != null)
                                {
                                    var existingRecord = _context.AndyCityDriverWorkingHoursRecords
                                        .FirstOrDefault(r => r.DriverId == driverId && r.OrderNumber == Convert.ToString(orderNumber));
                                    var existingPay = _context2.Paydetails
                                        .FirstOrDefault(r => r.AsgnId == driverId && r.OrdHdrnumber == orderNumber);

                                    // Update existing driver working hours record if found
                                    if (existingRecord != null)
                                    {
                                        existingRecord.TotalPay = Convert.ToDouble(entry.PaydAmount);
                                        existingRecord.PayRate = Convert.ToDouble(entry.PayRate);
                                        existingRecord.CalculateHours = ((double?)entry.CalculateHours);
                                        existingRecord.PaidHours = entry.PaidHours;

                                        _context.Entry(existingRecord).State = EntityState.Modified;
                                        await _context.SaveChangesAsync();  // Save changes after modifying the existing record
                                        
                                        if (existingPay == null || entry.OTNotes== "OverTimeOrder")
                                        {
                                            int newPydNumber = GetNewPydNumber(_context2.Database.GetDbConnection());
                                            Paydetail newPayDetail = new Paydetail
                                            {
                                                PydNumber = newPydNumber,
                                                LghNumber = entry.Lgh_Number,
                                                AsgnType = "DRV",
                                                AsgnId = driverId,
                                                PydPayto = driverId,
                                                PytItemcode = "HR",
                                                PydRateunit = "HR",
                                                MovNumber = entry.Mov_number,
                                                PydDescription = "Hourly Pay-TestVersion",
                                                PydRate = (decimal?)entry.PayRate,
                                                PydPaidAmount = (decimal?)entry.PaydAmount,
                                                PydQuantity = entry.PaidHours,
                                                PydPretax = "Y",
                                                PydCurrency = "CA$",
                                                PydStatus = "PND",
                                                PyhPayperiod = entry.PayPeriod,
                                                PydWorkperiod = entry.PayPeriod,
                                                IvdPayrevenue = 0,
                                                PydRevenueratio = 0,
                                                PydLessrevenue = 0,
                                                PydPayrevenue = 0,
                                                PydTransdate = DateTime.Today,
                                                PydMinus = 1,
                                                PydSequence = 1,
                                                PydLoadstate = "NA",
                                                PydXrefnumber = 0,
                                                OrdHdrnumber = orderNumber,
                                                PytFee1 = 0,
                                                PytFee2 = 0,
                                                PydGrossamount = (decimal?)entry.PaydAmount,
                                                PydCreatedon = DateTime.Today
                                            };

                                            _context2.Paydetails.Add(newPayDetail);
                                            await _context2.SaveChangesAsync(); // Save after adding the new pay detail
                                        }
                                       

                                    }

                                    // If there's no existing pay record, create a new one
                                    
                                    //else
                                    //{
                                    //    // If an existing pay detail is found, return an error message
                                    //    response.IsSuccess = false;
                                    //    response.Result = null;
                                    //    response.Message = "Pay details already exist for this driver and order number!";
                                    //    return response;
                                    //}
                                }
                            }

                            response.IsSuccess = true;
                            response.Result = "Data saved successfully";
                            response.Message = "Pay details processed and saved.";
                        }
                    }
                }
                catch (Exception ex)
                {
                    response.IsSuccess = false;
                    response.Result = "Data";
                    response.Message = ex.Message;
                    return response;
                }
            }

            return response;
        }

        //old code
        //public async Task<ResponseDTO> AddPayDetails(PayDetailsDTO payDetails)
        //{
        //    ResponseDTO response = new ResponseDTO();
        //    if (payDetails?.PEntrylist == null || !payDetails.PEntrylist.Any())
        //    {
        //        response.IsSuccess = false;
        //        response.Result = "Data";
        //        response.Message = "Entry is null !";

        //        return response;//BadRequest("Invalid data.");
        //    }
        //    else
        //    {
        //        try
        //        {
        //            using (var _context = new AndyMiscContext())
        //            {
        //                using (var _context2 = new SecondDbContext())
        //                {
        //                    // Process the pay details
        //                    foreach (var entry in payDetails.PEntrylist)
        //                    {
        //                        var driverId = entry.Driverid; //RemoveComment
        //                        var orderNumber = entry.Ord_Number;

        //                        // Fetch the existing record
        //                        if (driverId != null && orderNumber != null)
        //                        {
        //                            var existingRecord = _context.AndyCityDriverWorkingHoursRecords
        //                                                .FirstOrDefault(r => r.DriverId == driverId && r.OrderNumber == Convert.ToString(orderNumber));
        //                            var existingPay = _context2.Paydetails.FirstOrDefault(r => r.AsgnId == driverId && r.OrdHdrnumber == orderNumber);

        //                            if (existingRecord != null)
        //                            {
        //                                // Update fields
        //                                existingRecord.TotalPay = Convert.ToDouble(entry.PaydAmount);
        //                                existingRecord.PayRate = Convert.ToDouble(entry.PayRate);
        //                                existingRecord.CalculateHours = ((double?)entry.CalculateHours);
        //                                existingRecord.PaidHours = entry.PaidHours;

        //                                _context.Entry(existingRecord).State = EntityState.Modified;
        //                                //_context.SaveChangesAsync();
        //                                int recordsSaved = _context.SaveChanges();
        //                                //var existingPay = _context2.Paydetails.FirstOrDefault(r=>r.AsgnId == driverId && r.OrdHdrnumber == orderNumber);
        //                                //if (existingPay == null)
        //                                //{


        //                                //}

        //                                //else 
        //                                //{
        //                                //    existingPay.PydDescription = "Hourly Pay-TestVersion";
        //                                //    _context2.Entry(existingPay).State = EntityState.Modified;
        //                                //    _context2.SaveChangesAsync();
        //                                //}


        //                                //existingRecord.Notes = entry;

        //                            }
        //                            if (existingPay == null)
        //                            {
        //                                int newPydNumber = 0;
        //                                newPydNumber = GetNewPydNumber(_context2.Database.GetDbConnection());
        //                                //Getting New Pyd number .
        //                                Paydetail newPayDetail = new Paydetail();

        //                                newPayDetail.PydNumber = newPydNumber;
        //                                //PyhNumber = 0,
        //                                newPayDetail.LghNumber = entry.Lgh_Number;
        //                                //AsgnNumber = 0,
        //                                newPayDetail.AsgnType = "DRV";
        //                                newPayDetail.AsgnId = driverId;
        //                                newPayDetail.PydPayto = driverId;
        //                                newPayDetail.PytItemcode = "HR";
        //                                newPayDetail.PydRateunit = "HR";
        //                                newPayDetail.MovNumber = entry.Mov_number;
        //                                newPayDetail.PydDescription = "Hourly Pay-TestVersion";
        //                                newPayDetail.PydRate = (decimal?)entry.PayRate;
        //                                newPayDetail.PydPaidAmount = (decimal?)entry.PaydAmount;
        //                                newPayDetail.PydQuantity = entry.PaidHours;
        //                                newPayDetail.PydPretax = "Y";
        //                                newPayDetail.PydCurrency = "CA$";
        //                                newPayDetail.PydStatus = "PND";
        //                                newPayDetail.PyhPayperiod = entry.PayPeriod;
        //                                newPayDetail.PydWorkperiod = entry.PayPeriod;
        //                                newPayDetail.IvdPayrevenue = 0;
        //                                newPayDetail.PydRevenueratio = 0;
        //                                newPayDetail.PydLessrevenue = 0;
        //                                newPayDetail.PydPayrevenue = 0;
        //                                newPayDetail.PydTransdate = DateTime.Today;
        //                                newPayDetail.PydMinus = 1;
        //                                newPayDetail.PydSequence = 1;
        //                                // newPayDetail.StdNumber = null;
        //                                newPayDetail.PydLoadstate = "NA";
        //                                newPayDetail.PydXrefnumber = 0;
        //                                newPayDetail.OrdHdrnumber = orderNumber;
        //                                newPayDetail.PytFee1 = 0;
        //                                newPayDetail.PytFee2 = 0;
        //                                newPayDetail.PydGrossamount = (decimal?)entry.PaydAmount;
        //                                newPayDetail.PydCreatedon = DateTime.Today;
        //                                //PydBranchOverride = null,
        //                                //PydOverlimit = null,
        //                                //PydTotaladvanced = null,


        //                                _context2.Paydetails.Add(newPayDetail);
        //                                int payDetailsSaved = await _context2.SaveChangesAsync();
        //                            }

        //                            else
        //                            {
        //                                response.IsSuccess = false;
        //                                response.Result = null;
        //                                response.Message = "Error .. !";

        //                                return response;//BadRequest("Invalid data.");
        //                            }

        //                            //int payDetailsSaved = await _context2.SaveChangesAsync();
        //                        }
        //                        else
        //                        {
        //                            continue;
        //                        }



        //                    }


        //                    response.Result = "Data";

        //                    //int payDetailsSaved = _context2.SaveChanges();


        //                    response.Message = "Here";
        //                }

        //            }

        //        }
        //        catch (Exception ex)
        //        {
        //            response.IsSuccess = false;
        //            response.Result = "Data";
        //            response.Message = ex.Message;
        //            return response;
        //        }
        //    }
        //    return response;
        //}

        private int GetNewPydNumber(DbConnection connection)
        {
            connection.Open();
            using (var command = connection.CreateCommand())
            {
                // SQL query to execute the stored procedure
                command.CommandText = @"
                           DECLARE @new_pyd_number INT;
                           EXEC @new_pyd_number = getsystemnumber @SystemKey, @OptionalParam;
                           SELECT @new_pyd_number;";
                command.CommandType = System.Data.CommandType.Text;

                // Add parameters
                var systemKeyParam = command.CreateParameter();
                systemKeyParam.ParameterName = "@SystemKey";
                systemKeyParam.Value = "PYDNUM";
                command.Parameters.Add(systemKeyParam);

                var optionalParam = command.CreateParameter();
                optionalParam.ParameterName = "@OptionalParam";
                optionalParam.Value = ""; // Replace with an appropriate value
                command.Parameters.Add(optionalParam);

                // Execute and fetch the result
                var result = command.ExecuteScalar();
                int newPydNumber = result != null ? Convert.ToInt32(result) : 0;
                return newPydNumber;
            }
        }
    }
}

