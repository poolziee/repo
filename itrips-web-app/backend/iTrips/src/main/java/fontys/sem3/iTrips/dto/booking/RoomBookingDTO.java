package fontys.sem3.iTrips.dto.booking;

import fontys.sem3.iTrips.dto.user.BookerInfoDTO;
import lombok.Data;

import java.sql.Date;


@Data
public class RoomBookingDTO {

    private Long id;
    private double price;
    private Date checkin;
    private Date checkout;
    private BookerInfoDTO user;
}
