package fontys.sem3.iTrips.dto.booking;

import fontys.sem3.iTrips.dto.hotel.HotelWithoutRelationshipsDTO;
import fontys.sem3.iTrips.dto.room.RoomWithoutRelationshipsDTO;
import fontys.sem3.iTrips.dto.user.BookerInfoDTO;
import lombok.Data;

import java.sql.Date;

@Data
public class BookingWithoutUserDTO {
    private Long id;
    private double price;
    private Date checkin;
    private Date checkout;
    private HotelWithoutRelationshipsDTO hotel;
    private RoomWithoutRelationshipsDTO room;
}
