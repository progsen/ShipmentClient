using ShipmentModel;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ShipmentDatalayer
{
    public class ShipmentContext : IShipmentContext
    {
        public List<Shipment> shipments = new List<Shipment>();



        public ShipmentStatus ChangeShipmentStatus(string shipmentId, ShipmentStatus status)
        {
            Shipment shipment = shipments.First(i => i.ShipmentId == shipmentId);

            shipment.ShipmentStatus.Code = status.Code;
            shipment.ShipmentStatus.Description = status.Description;

            return shipment.ShipmentStatus;
        }

        public Shipment CreateShipment(Shipment shipment)
        {
            Shipment dbEntity = new()
            {
                Customer = shipment.Customer,
                Destination = shipment.Destination,
                Origin = shipment.Origin,
                Weight = shipment.Weight,


                ShipmentId = Guid.NewGuid().ToString(),
                Price = shipment.Weight * 1.55,
                ShipmentStatus = new ShipmentStatus()
                {
                    Code = 1,
                    Description = "Created"

                }
            };
            shipments.Add(dbEntity);

            return dbEntity;


        }
    }
}
