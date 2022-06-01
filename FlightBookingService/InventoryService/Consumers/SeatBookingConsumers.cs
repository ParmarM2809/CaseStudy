using DAL.Models;
using InventoryService.Entity;
using MassTransit;
using System.Threading.Tasks;
using UserService.Events;

namespace InventoryService.Consumers
{
    public class SeatBookingConsumers : IConsumer<SeatBookingDeletation>
    {
        public Task Consume(ConsumeContext<SeatBookingDeletation> context)
        {
            var message = context.Message.SeatCount;

            InventoryManagmentEntity inventoryManagmentEntity = new InventoryManagmentEntity();

            Inventory flightModel = inventoryManagmentEntity.GetFlightByID(context.Message.FlightId);
            flightModel.SeatAvaibility = flightModel.SeatAvaibility - context.Message.SeatCount;
            inventoryManagmentEntity.UpdateSeatAvaiability(flightModel);
            return Task.CompletedTask;
        }
    }
}
