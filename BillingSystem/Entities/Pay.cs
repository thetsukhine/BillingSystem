using MessagePack.Formatters;
using System.ComponentModel.DataAnnotations;

namespace BillingSystem.Entities
{
    public class Pay
    {
       
        public int Id { get; set; }
        public string api_caller { get; set; }
        public int BillId { get; set; }
     
        public int Amount { get; set;}
        public string reference_no { get; set; }
        public int  phone_number { get; set; }

    }
}
