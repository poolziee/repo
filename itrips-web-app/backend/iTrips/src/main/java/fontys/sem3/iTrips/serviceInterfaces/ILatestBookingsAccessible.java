package fontys.sem3.iTrips.serviceInterfaces;

import fontys.sem3.iTrips.dto.booking.BookingDTO;

import java.util.List;

public interface ILatestBookingsAccessible {

     List<BookingDTO> getLatestBookings(Long managerId);
}
