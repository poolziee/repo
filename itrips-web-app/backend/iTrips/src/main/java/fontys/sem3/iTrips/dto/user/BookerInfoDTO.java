package fontys.sem3.iTrips.dto.user;


import lombok.AllArgsConstructor;
import lombok.Data;
import lombok.NoArgsConstructor;

@AllArgsConstructor
@NoArgsConstructor
@Data
public class BookerInfoDTO {

    private Long id;
    private String firstName;
    private String lastName;
    private String username;
    private String email;
}
