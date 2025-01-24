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
    public class PayPeriodController : ControllerBase
    {
        private ResponseDTO response;
        public PayPeriodController()
        {
            response = new ResponseDTO();
        }
        [HttpGet]
        public ResponseDTO Get()
        {
            ResponseDTO responseDTO = new ResponseDTO();
            using (var _context1 = new AndyMiscContext())
            {
                var data = _context1.AndyPayPeriodTables
                            .OrderByDescending(x => x.PayPeriodId)
                            .Take(5)
                            .Select(x => new
                            {
                                x.WeekStartDate,  // Replace with the actual property names
                                x.WeekEndDate,
                                x.PayPeriodPayDate
                            })
                        .ToList();

                // responseDTO.Result = data;
                List<PayPeriodDTO> periods = new List<PayPeriodDTO>();
                foreach (var item in data)
                {
                    //string weekStartDate = item.WeekStartDate.ToString("yyyy-MM-dd");
                    //string weekEndDate = item.WeekEndDate.ToString("yyyy-MM-dd");

                    int countOfDrivers = _context1.AndyCityDriverWorkingHoursRecords
                                          .Where(record => record.DateOfWork >= item.WeekStartDate && record.DateOfWork <= item.WeekEndDate)
                                          .Select(record => record.DriverId)
                                          .Distinct()
                                          .Count();
                    int CountOfOrders = _context1.AndyCityDriverWorkingHoursRecords
                        .Where(record => record.DateOfWork >= item.WeekStartDate && record.DateOfWork <= item.WeekEndDate).
                        Select(record => record.OrderNumber)
                       .Distinct()
                       .Count();

                    periods.Add(new PayPeriodDTO
                    {
                        PayperiodStartDate = item.WeekStartDate,
                        PayperiodEndDate = item.WeekEndDate,
                        PayDayDate = (DateOnly)item.PayPeriodPayDate,
                        CountOFDriver = countOfDrivers,
                        NoOfOrders = CountOfOrders,
                        //TotalHoursWorked = totalHoursWorked
                    });
                }
                responseDTO.Result = periods;
                return responseDTO;
                //DateOnly start = DateOnly.FromDateTime(DateTime.Today);
                //DateOnly initialStart = new DateOnly(2024, 11, 2);
                //while (start.DayOfWeek != DayOfWeek.Saturday)
                //{
                //    start = start.AddDays(-1); // Move back to the last Saturday
                //}

                //List<PayPeriodDTO> periods = new List<PayPeriodDTO>();

                //// Generate 10 weeks of pay periods
                //for (int i = 0; i < 5; i++)
                //{
                //    DateOnly periodStart = start.AddDays(-7 * i); // Start date of the pay period
                //    DateOnly periodEnd = periodStart.AddDays(7);  // End date of the pay period (next Sunday)                
                //    DateOnly PayDAY = initialStart.AddDays(14);
                //    initialStart = PayDAY;

                //    using (var _context1 = new AndyMiscContext())
                //    {
                //        //using(var _context2 = new Se())
                //        //{
                //        // here i need to get last 3 payperiod dates.. and change the logic for the pay period week start date and pay period end date week .
                //        //}
                //        // Fetch data from the database for each pay period
                //        //var Data = _context1.[Andy_PayPeriodTable]

                //        int countOfDrivers = _context1.AndyDriverWorkbookRecordV1s
                //            .Where(record => record.Dateonly >= periodStart && record.Dateonly <= periodEnd)
                //            .Select(record => record.MppId)
                //            .Distinct()
                //            .Count();  // Count of distinct drivers

                //        int noOfOrders = _context1.AndyDriverWorkbookRecordV1s
                //            .Where(record => record.Dateonly >= periodStart && record.Dateonly <= periodEnd)
                //            .Select(record => record.NoteOrdernum) // Assuming 'OrderId' represents orders
                //            .Distinct()
                //            .Count();  // Count of distinct orders

                //        //float totalHoursWorked = (float)_context1.AndyDriverWorkbookRecordV1s
                //        //    .Where(record => record.Dateonly >= periodStart && record.Dateonly <= periodEnd)
                //        //    .GroupBy(record => new { record.MppId, record.Dateonly })
                //        //    .Sum(g => g.FirstOrDefault().TotalHrsRaw);
                //        // .Sum(record => record.TotalHrsRaw);  // Sum total hours worked

                //        float totalHoursWorked = (float)_context1.AndyDriverWorkbookRecordV1s
                //              .Where(record => record.Dateonly >= periodStart && record.Dateonly <= periodEnd)
                //              .ToList() // Load data into memory
                //               .GroupBy(record => new { record.MppId, record.Dateonly })
                //              .Sum(g => g.FirstOrDefault()?.TotalHrsRaw ?? 0); // Use null-coalescing to handle null values



                //        // Add the populated data to the list of pay periods
                //        periods.Add(new PayPeriodDTO
                //        {
                //            PayperiodStartDate = periodStart,
                //            PayperiodEndDate = periodEnd,
                //            PayDayDate = PayDAY,
                //            CountOFDriver = countOfDrivers,
                //            NoOfOrders = noOfOrders,
                //            TotalHoursWorked = totalHoursWorked
                //        });
                //    }
                //}

                //var response = new ResponseDTO
                //{
                //    Result = periods
                //};

                //return response;
            }
        }
          [HttpGet]
        [Route("DataRecords")]
        public ResponseDTO GetRecords()
        {
            ResponseDTO responseDTO = new ResponseDTO();
            using (var _context1 = new AndyMiscContext())
            {
                var data =  _context1.AndyPayPeriodTables
                            .OrderByDescending(x => x.PayPeriodId)
                            .Take(5)
                            .Select(x => new
                        {
                            x.WeekStartDate,  // Replace with the actual property names
                            x.WeekEndDate,
                            x.PayPeriodPayDate
                        })
                        .ToList();

               // responseDTO.Result = data;
                List<PayPeriodDTO> periods = new List<PayPeriodDTO>();
                foreach (var item in data)
                {
                    //string weekStartDate = item.WeekStartDate.ToString("yyyy-MM-dd");
                    //string weekEndDate = item.WeekEndDate.ToString("yyyy-MM-dd");

                    int countOfDrivers = _context1.AndyCityDriverWorkingHoursRecords
                                          .Where(record => record.DateOfWork >= item.WeekStartDate && record.DateOfWork <= item.WeekEndDate)
                                          .Select(record => record.DriverId)
                                          .Distinct()
                                          .Count();
                    int CountOfOrders = _context1.AndyCityDriverWorkingHoursRecords
                        .Where(record => record.DateOfWork >= item.WeekStartDate && record.DateOfWork <= item.WeekEndDate).
                        Select(record => record.OrderNumber)
                       .Distinct()
                       .Count();

                    periods.Add(new PayPeriodDTO
                    {
                        PayperiodStartDate = item.WeekStartDate,
                        PayperiodEndDate = item.WeekEndDate,
                        PayDayDate = (DateOnly)item.PayPeriodPayDate,
                        CountOFDriver = countOfDrivers,
                        NoOfOrders = CountOfOrders,
                        //TotalHoursWorked = totalHoursWorked
                    });
                }
                responseDTO.Result = periods;

            }
            
            return responseDTO;
        }
    }
}
