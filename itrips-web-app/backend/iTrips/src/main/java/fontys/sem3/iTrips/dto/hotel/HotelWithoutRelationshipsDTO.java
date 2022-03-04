package fontys.sem3.iTrips.dto.hotel;

import lombok.AllArgsConstructor;
import lombok.Data;
import lombok.NoArgsConstructor;

@Data
@NoArgsConstructor
@AllArgsConstructor
public class HotelWithoutRelationshipsDTO {
    public HotelWithoutRelationshipsDTO(String name) {
        this.name = name;
    }

    private Long id;
    private String name;
    private String description;
    private String country;
    private String city;
    private String street;
    private String stars;
    private String caption;
}
