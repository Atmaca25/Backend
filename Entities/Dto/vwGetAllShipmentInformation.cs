using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Dto
{
    public class vwGetAllShipmentInformation : IDto
    {
        public int OrderId { get; set; }
        public string CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime RequiredDate { get; set; }
        public string ShipCity { get; set; }
    }
}
