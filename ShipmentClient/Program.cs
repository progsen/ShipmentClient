using ShipmentModel;
using ShipmentModel.Webservice;
using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;

namespace ShipmentClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            JsonSerializerOptions jsonSerializerOptions = new JsonSerializerOptions()
            {
                PropertyNameCaseInsensitive = true
            };

            using (HttpClient httpClient = new HttpClient())
            {

                Console.ReadLine();
                Shipment shipment = new Shipment()
                {

                };

                using (JsonContent jsonContent = JsonContent.Create<ShipmentModel.Shipment>(shipment))
                using (HttpResponseMessage responseMessage = httpClient.PostAsync("http://localhost:7423/CreateShipment", jsonContent).Result)
                {
                    string json = responseMessage.Content.ReadAsStringAsync().Result;
                    Console.WriteLine(json);


                    Shipment created = JsonSerializer.Deserialize<Shipment>(json, jsonSerializerOptions);

                    ChangeShipmentStatusRequest statusRequest = new ChangeShipmentStatusRequest()
                    {
                        ShipmentId = created.ShipmentId,
                        Status = new ShipmentStatus()
                        {
                            Code = 2,
                            Description = "in transit"
                        }

                    };
                    using (JsonContent jsonContent2 = JsonContent.Create(statusRequest))
                    using (HttpResponseMessage responseMessage2 = httpClient.PostAsync("http://localhost:7423/ChangeShipmentStatus", jsonContent2).Result)
                    {
                        string json2 = responseMessage2.Content.ReadAsStringAsync().Result;
                        Console.WriteLine(json2);

                    }
                }
            }
            Console.ReadLine();

        }
    }
}
