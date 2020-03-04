using LibraryApi.Models;
using RabbitMqUtils;

namespace LibraryApi.Services
{
	public class RabbitMqReservationProcessor : ISendMessageToTheReservationProcessor
	{
		IRabbitManager Manager;

		public RabbitMqReservationProcessor(IRabbitManager manager)
		{
			Manager = manager;
		}

		public void SendReservationForProcessing(GetReservationItemResponse reservation)
		{
			Manager.Publish(reservation, "", "direct", "reservations");
		}
	}
}
