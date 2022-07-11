namespace ShipmentModel.Webservice
{
    public class ChangeShipmentStatusRequest
    {
        public string ShipmentId { get; set; }
        public ShipmentStatus Status { get; set; }
    }
}
