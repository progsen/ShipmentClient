using ShipmentModel;

namespace ShipmentDatalayer
{
    public interface IShipmentContext
    {
        ShipmentModel.Shipment CreateShipment(ShipmentModel.Shipment shipment);
        ShipmentModel.ShipmentStatus ChangeShipmentStatus(string shipmentId, ShipmentModel.ShipmentStatus status);
    }
}