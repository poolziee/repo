package fontys.sem3.iTrips.dto.hotel;

import fontys.sem3.iTrips.dto.room.HotelRoomDTO;
import lombok.Data;
import java.util.ArrayList;
import java.util.List;

@Data
public class HotelDTO {

    private Long id;
    private String stars;
    private String description;
    private String name;
    private String country;
    private String city;
    private String street;
    private String caption;
    private List<HotelRoomDTO> rooms = new ArrayList<>();
    private int total_bookings;
}
