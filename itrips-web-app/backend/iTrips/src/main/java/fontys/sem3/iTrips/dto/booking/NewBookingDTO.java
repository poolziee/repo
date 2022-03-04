package fontys.sem3.iTrips.dto.booking;

import fontys.sem3.iTrips.dto.hotel.HotelWithoutRelationshipsDTO;
import fontys.sem3.iTrips.dto.room.RoomWithoutRelationshipsDTO;
import fontys.sem3.iTrips.dto.user.BookerInfoDTO;
import lombok.AllArgsConstructor;
import lombok.Data;
import lombok.NoArgsConstructor;

import java.sql.Date;

@AllArgsConstructor
@NoArgsConstructor
@Data
public class NewBookingDTO {
    private double price;
    private Long userId;
    private Long roomId;
    private String checkinString;
    private String checkoutString;
}
