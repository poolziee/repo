package fontys.sem3.iTrips.dto.hotel;

import lombok.AllArgsConstructor;
import lombok.Data;
import lombok.NoArgsConstructor;

@Data
@NoArgsConstructor
@AllArgsConstructor
public class NewHotelDTO {

    private long managerId;
    private String stars;
    private String description;
    private String name;
    private String country;
    private String city;
    private String street;
    private String caption;

}
