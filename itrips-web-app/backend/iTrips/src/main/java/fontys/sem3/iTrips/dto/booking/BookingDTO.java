package fontys.sem3.iTrips.dto.booking;

import fontys.sem3.iTrips.dto.hotel.HotelWithoutRelationshipsDTO;
import fontys.sem3.iTrips.dto.room.RoomWithoutRelationshipsDTO;
import fontys.sem3.iTrips.dto.user.BookerInfoDTO;
import lombok.AllArgsConstructor;
import lombok.Data;
import lombok.NoArgsConstructor;

import java.sql.Date;
import java.util.ArrayList;
import java.util.List;

@AllArgsConstructor
@NoArgsConstructor
@Data
public class BookingDTO {

    private Long id;
    private double price;
    private Date checkin;
    private Date checkout;
    private BookerInfoDTO user;
    private HotelWithoutRelationshipsDTO hotel;
    private RoomWithoutRelationshipsDTO room;
}
