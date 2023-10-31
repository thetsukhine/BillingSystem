using BillingSystem.DTO;
using BillingSystem.Entities;
using Google.Protobuf.Collections;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace BillingSystem.Controllers
{
    [Route("api")]
    [ApiController]
    public class BillController : ControllerBase
    {
        private readonly UserdbContext DBContext;
        public BillController(UserdbContext _DBContext)
        {
            this.DBContext = _DBContext;
        }

        //[HttpPost("Add")]
        //public async Task<string> InsertUser(Bill bill)
        //{
        //    var entity = new Bill()
        //    {

        //        Name = bill.Name,
        //        Description = bill.Description
        //    };
        //    DBContext.Bill.Add(entity);
        //    await DBContext.SaveChangesAsync();

        //    Bill resultbill = await DBContext.Bill.Select(s => new Bill
        //    {
        //        Id = s.Id,
        //        Name = s.Name,
        //        Description = s.Description
        //    }).FirstOrDefaultAsync();

        //    string status_message = "Bill Top up is successfully saved in the system";

        //    return    Newtonsoft.Json.JsonConvert.SerializeObject(new
        //    {
        //        status_message = status_message,
        //        date_time = DateTime.UtcNow.ToString("yyyyMMdd"),
        //        bill_id = resultbill.Id,
        //        name = resultbill.Name,
        //        description = resultbill.Description
        //    });

        //}

//        [HttpGet("List")]
//        public async Task<string> Get(string? Id)
//        {
//            List<Bill> listss = new List<Bill>();
//            if (string.IsNullOrEmpty(Id))
//            {
//                listss = await DBContext.Bill.Select(
//               s => new Bill
//               {
//                   Id = s.Id,
//                   Name = s.Name,
//                   Description = s.Description
//               }
//           ).ToListAsync();
//            }
//            else
//            {
//#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
//                Bill oneRecord = await DBContext.Bill.Select(s => new Bill
//                {
//                    Id = s.Id,
//                    Name = s.Name,
//                    Description = s.Description
//                }).FirstOrDefaultAsync(s => s.Id == Convert.ToInt32(Id));
//#pragma warning restore CS8600 //Converting null literal or possible null value to non-nullable type.
//                listss.Add(oneRecord);
//            }

//            if (listss.Count < 0)
//            {
//                return string.Empty;
//            }
//            else
//            {
//                string status_message = "Transaction is successful!";
//                string date_time = DateTime.UtcNow.ToString("yyyyMMdd");


//                return Newtonsoft.Json.JsonConvert.SerializeObject(new
//                {
//                    status_message = status_message,
//                    date_time = date_time,
//                    billers = listss
//                });
//            }
//        }

       
    }
}
