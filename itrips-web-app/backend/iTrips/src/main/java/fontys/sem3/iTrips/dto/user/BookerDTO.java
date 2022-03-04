package fontys.sem3.iTrips.dto.user;

import fontys.sem3.iTrips.dto.booking.BookingDTO;
import fontys.sem3.iTrips.dto.booking.BookingWithoutUserDTO;
import fontys.sem3.iTrips.model.Role;
import lombok.AllArgsConstructor;
import lombok.Data;
import lombok.NoArgsConstructor;

import java.util.ArrayList;
import java.util.Collection;
import java.util.List;
import java.util.Map;

@Data
public class BookerDTO {
    private Long id;
    private String firstName;
    private String lastName;
    private String username;
    private String email;
    private Collection<Role> roles = new ArrayList<>();
    private List<BookingWithoutUserDTO> bookings = new ArrayList<>();
    private Map<String, String> tokens;
}
