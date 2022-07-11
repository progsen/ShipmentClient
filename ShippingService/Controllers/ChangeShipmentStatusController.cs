using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ShipmentDatalayer;
using ShipmentModel;
using ShipmentModel.Webservice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShippingService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ChangeShipmentStatusController : ControllerBase
    {

        private readonly ILogger<ChangeShipmentStatusController> logger;
        private readonly IShipmentContext shipmentContext;

        public ChangeShipmentStatusController(IShipmentContext shipmentContext, ILogger<ChangeShipmentStatusController> logger)
        {
            this.logger = logger;
            this.shipmentContext = shipmentContext;
        }

        [HttpPost]
        public ShipmentStatus ChangeStatus(ChangeShipmentStatusRequest request)
        {
            ShipmentStatus shipmentResult = shipmentContext.ChangeShipmentStatus(request.ShipmentId, request.Status);
            return shipmentResult;
        }
    }

}
