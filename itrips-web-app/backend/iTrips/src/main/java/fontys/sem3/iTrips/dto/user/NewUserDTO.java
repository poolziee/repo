package fontys.sem3.iTrips.dto.user;

import fontys.sem3.iTrips.model.Role;
import lombok.AllArgsConstructor;
import lombok.Data;

import java.util.List;

@Data
@AllArgsConstructor
public class NewUserDTO {

    private String firstName;
    private String lastName;
    private String username;
    private String password;
    private String email;
    private String roleName;
}
