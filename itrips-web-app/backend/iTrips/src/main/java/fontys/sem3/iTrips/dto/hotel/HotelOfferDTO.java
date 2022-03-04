package fontys.sem3.iTrips.dto.hotel;

import fontys.sem3.iTrips.dto.room.RoomOfferDTO;
import lombok.AllArgsConstructor;
import lombok.Data;

import java.util.ArrayList;
import java.util.List;

@Data
@AllArgsConstructor
public class HotelOfferDTO {
    private Long id;
    private String name;
    private String caption;
    private String description;
    private String stars;

    private double totalPrice;
    private double totalNights;
    private double nightlyPrice;
    private int bookings;
    private String location;
    private int guests;
    private List<RoomOfferDTO> roomOffers = new ArrayList<>();
    private String checkin;
    private String checkout;
}
