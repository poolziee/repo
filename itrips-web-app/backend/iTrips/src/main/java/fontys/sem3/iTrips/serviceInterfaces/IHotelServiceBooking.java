package fontys.sem3.iTrips.serviceInterfaces;

import fontys.sem3.iTrips.model.Hotel;
import fontys.sem3.iTrips.model.Room;

import java.util.List;

public interface IHotelServiceBooking {
    Room getRoomById(long id);
    List<Hotel> getAll();
    List<Room> getAllRooms();
    Hotel getById(Long hotelId);
    Hotel getByName(String name);
    List<Hotel> getByManagerId(Long managerId);
}
