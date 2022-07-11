using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ShipmentDatalayer;
using ShipmentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShippingService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CreateShipmentController : ControllerBase
    {

        private readonly ILogger<CreateShipmentController> logger;
        private readonly IShipmentContext shipmentContext;

        public CreateShipmentController(IShipmentContext shipmentContext, ILogger<CreateShipmentController> logger)
        {
            this.logger = logger;
            this.shipmentContext = shipmentContext;
        }

        [HttpPost]
        public Shipment CreateShipment(Shipment shipment)
        {
            Shipment shipmentResult = shipmentContext.CreateShipment(shipment);
            return shipmentResult;
        }
    }
}
