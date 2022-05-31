using DAL.Models;
using InventoryService.Entity;
using MassTransit;
using System.Threading.Tasks;
using UserService.Events;

namespace InventoryService.Consumers
{
    public class VideoDeletaionConsumers : IConsumer<VideoDeletation>
    {
        public Task Consume(ConsumeContext<VideoDeletation> context)
        {
            var message = context.Message.title;

            InventoryManagmentEntity inventoryManagmentEntity = new InventoryManagmentEntity();

            Inventory flightModel = inventoryManagmentEntity.GetFlightByID(1);
            inventoryManagmentEntity.Update(flightModel);
            return Task.CompletedTask;
        }
    }
}
