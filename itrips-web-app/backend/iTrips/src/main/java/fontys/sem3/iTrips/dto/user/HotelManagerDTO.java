package fontys.sem3.iTrips.dto.user;

import fontys.sem3.iTrips.dto.hotel.HotelDTO;
import fontys.sem3.iTrips.model.Role;
import lombok.Data;

import java.util.List;
import java.util.Map;

@Data
public class HotelManagerDTO {
    private Long id;
    private String firstName;
    private String lastName;
    private String username;
    private String email;
    private List<Role> roles;
    private List<HotelDTO> hotels;
    private Map<String, String> tokens;

}
