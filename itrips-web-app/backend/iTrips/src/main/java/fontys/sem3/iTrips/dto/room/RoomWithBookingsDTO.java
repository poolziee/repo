package fontys.sem3.iTrips.dto.room;


import fontys.sem3.iTrips.dto.booking.RoomBookingDTO;
import fontys.sem3.iTrips.dto.hotel.HotelDTO;
import fontys.sem3.iTrips.dto.hotel.HotelWithoutRelationshipsDTO;
import fontys.sem3.iTrips.model.Booking;
import fontys.sem3.iTrips.model.Hotel;
import lombok.Data;
import java.util.ArrayList;
import java.util.List;

@Data
public class RoomWithBookingsDTO {

    private Long id;
    private String type;
    private HotelWithoutRelationshipsDTO hotel;
    private List<RoomBookingDTO> bookings = new ArrayList<>();
    private int sleeps;
    private int total;
    private double price;
}
