using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BillingSystem.Entities;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Security.Cryptography;
using System.Text.Json.Nodes;

namespace BillingSystem.Controllers
{
    [Route("api")]
    [ApiController]
    public class PaysController : ControllerBase
    {
        private readonly UserdbContext _context;

        public PaysController(UserdbContext context)
        {
            _context = context;
        }

        //GET: api/Pays
       //[HttpGet("GetAll")]
       // public async Task<ActionResult<IEnumerable<Pay>>> GetAll()
       // {
       //     if (_context.Pay == null)
       //     {
       //         return NotFound();
       //     }
       //     return await _context.Pay.ToListAsync();
       // }

        //[HttpPost("Pay")]
        //public async Task<ActionResult<string>> Pay(Pay pay)
        //{
        //    if (_context.Pay == null)
        //    {
        //        return Problem("Entity set 'UserdbContext.Pay'  is null.");
        //    }

        //    string phoneNumber = pay.phone_number.ToString();
        //    string firstThreeNums = phoneNumber.Substring(0, 3);
        //    if (string.IsNullOrEmpty(pay.Id.ToString()) || string.IsNullOrEmpty(pay.Amount.ToString()) ||
        //      string.IsNullOrEmpty(pay.reference_no.ToString()) || string.IsNullOrEmpty(pay.phone_number.ToString()))
        //    {
        //        return BadRequest("Id, amount, reference_no and phone_number should not be empty!");
        //    }
        //    else if (firstThreeNums != "959")
        //    {
        //        return BadRequest("phone_number should be started with 959!");
        //    }
        //    else if (pay.Amount > 100000)
        //    {
        //        return BadRequest("amount is not greater than 100000!");
        //    }

        //    //var existReference_No = await _context.Pay.FindAsync(pay.reference_no);
        //    //var urlNameExists = _sb.Any(x => x.UrlName == urlName && x.Id != currentEditId);

        //    var referenceNoexists = _context.Pay.Any(x => x.reference_no == pay.reference_no);
        //    if (referenceNoexists)
        //        return BadRequest("Reference_no should be unique in system!");

        //    _context.Pay.Add(pay);
        //    await _context.SaveChangesAsync();

        //    Pay pay1 = new Pay();
        //    pay1 = await _context.Pay.FindAsync(pay.Id);

        //    return Newtonsoft.Json.JsonConvert.SerializeObject(new
        //    {
        //        status_message = "Transaction is successful! ",
        //        transaction_id = pay1.Id,
        //        amount = pay1.Amount,
        //        transaction_date = DateTime.UtcNow.ToString("yyyyMMdd"),
        //        phone_number = pay1.phone_number

        //    });
        //}

        // GET: api/Pays/5
        //[HttpGet("Transaction")]
        //public async Task<ActionResult<string>> Transaction(int id)
        //{
        //    if (_context.Pay == null)
        //    {
        //        return NotFound();
        //    }

        //    Pay pay = new Pay();
        //      pay = await _context.Pay.FindAsync(id);

        //    //if (pay == null)
        //    //{               
             
        //    //    ြူုြူreturn BadRequest("No record found");
        //    //}

        //    if (pay == null)
        //    {
        //        return BadRequest("No record found");
        //    }

        //    return Newtonsoft.Json.JsonConvert.SerializeObject(new
        //    {
        //        api_caller=  pay.api_caller ,
        //        id= pay.Id,
        //        amount= pay.Amount,
        //         reference_no=  pay.reference_no ,
        //         phone_number= pay.phone_number	
        //    });
        //}

        // POST: api/Pays
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPost]
        //public async Task<ActionResult<Pay>> PostPay(Pay pay)
        //{
        //  if (_context.Pay == null)
        //  {
        //      return Problem("Entity set 'UserdbContext.Pay'  is null.");
        //  }
        //    _context.Pay.Add(pay);
        //    await _context.SaveChangesAsync();
        //    return CreatedAtAction("GetPay", new { id = pay.Id }, pay);
        //}

        // DELETE: api/Pays/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeletePay(int id)
        //{
        //    if (_context.Pay == null)
        //    {
        //        return NotFound();
        //    }
        //    var pay = await _context.Pay.FindAsync(id);
        //    if (pay == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Pay.Remove(pay);
        //    await _context.SaveChangesAsync();

        //    return NoContent();
        //}

        private bool PayExists(int id)
        {
            return (_context.Pay?.Any(e => e.Id == id)).GetValueOrDefault();
        }

        private static bool IsValidJson(string strInput)
        {
            if (string.IsNullOrWhiteSpace(strInput)) { return false; }
            strInput = strInput.Trim();
            if ((strInput.StartsWith("{") && strInput.EndsWith("}")) || //For object
                (strInput.StartsWith("[") && strInput.EndsWith("]"))) //For array
            {
                try
                {
                    var obj = JToken.Parse(strInput);
                    return true;
                }
                catch (JsonReaderException jex)
                {
                    //Exception in parsing json
                    Console.WriteLine(jex.Message);
                    return false;
                }
                catch (Exception ex) //some other exception
                {
                    Console.WriteLine(ex.ToString());
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        // PUT: api/Pays/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutPay(int id, Pay pay)
        //{
        //    if (id != pay.Id)
        //    {
        //        return BadRequest();
        //    }
        //    _context.Entry(pay).State = EntityState.Modified;
        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!PayExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }
        //    return NoContent();
        //}

    }
}
