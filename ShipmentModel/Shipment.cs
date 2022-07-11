using System;

namespace ShipmentModel
{
    public class Shipment
    {
        public string ShipmentId { get; set; }
        public Address Destination { get; set; }
        public Address Origin { get; set; }
        public Customer Customer { get; set; }
        public int Weight { get; set; }
        public double Price { get; set; }
        public ShipmentStatus ShipmentStatus { get; set; }
    }

}
