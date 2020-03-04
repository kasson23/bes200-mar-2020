using LibraryApi.Models;

namespace LibraryApi.Services
{
	public interface ISendMessageToTheReservationProcessor
	{
		void SendReservationForProcessing(GetReservationItemResponse reservation);
	}
}