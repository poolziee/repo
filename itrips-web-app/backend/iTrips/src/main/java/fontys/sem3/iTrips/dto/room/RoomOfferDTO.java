package fontys.sem3.iTrips.dto.room;

import lombok.AllArgsConstructor;
import lombok.Data;
import lombok.NoArgsConstructor;

@Data
@AllArgsConstructor
public class RoomOfferDTO {
    private Long id;
    private String type;
    private int sleeps;

    private int bookings;
    private int offers_left;
    private String status;
    private double nightly_price;
    private double total_price;
    private long totalNights;
}
