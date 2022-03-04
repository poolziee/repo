package fontys.sem3.iTrips.users;
import fontys.sem3.iTrips.dto.user.NewUserDTO;
import fontys.sem3.iTrips.dto.user.UserDTO;
import fontys.sem3.iTrips.exception.UnsatisfiedPasswordException;
import fontys.sem3.iTrips.exception.UserAlreadyExistsException;
import fontys.sem3.iTrips.model.User;
import fontys.sem3.iTrips.service.UserService;
import org.junit.jupiter.api.*;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.boot.test.context.SpringBootTest;
import org.springframework.security.core.userdetails.UsernameNotFoundException;
import org.springframework.security.crypto.password.PasswordEncoder;
import org.springframework.test.context.ActiveProfiles;
import org.springframework.transaction.annotation.Transactional;

import static org.junit.jupiter.api.Assertions.*;



@TestMethodOrder(MethodOrderer.OrderAnnotation.class)
@SpringBootTest
@ActiveProfiles("test")
public class UserServiceTest {

    @Autowired
    UserService userService;

    @Autowired
    PasswordEncoder passwordEncoder;

    @Test
    @Order(1)
    void addNewUser_success(){
    UserDTO user = userService.saveUser(new NewUserDTO("Andy","Colins", "andy", "andy1234", "andyC@mail.com", "ROLE_BOOKER"));
        Assertions.assertEquals("andy", user.getUsername());
    }

    @Test
    @Order(2)
     void usernameAlreadyExists_exception() {
        UserAlreadyExistsException exception = assertThrows(UserAlreadyExistsException.class, () -> {
            userService.saveUser(new NewUserDTO("Andrei","Richards", "andy", "andy1234", "andyR@mail.com", "ROLE_BOOKER"));
        });

        String expectedMessage = "Account with this username already exists";
        String actualMessage = exception.getMessage();

        assertTrue(actualMessage.contains(expectedMessage));
    }

    @Test
    @Order(3)
     void loadUserByUsername_exception() {
        UsernameNotFoundException exception = assertThrows(UsernameNotFoundException.class, () -> {
            userService.loadUserByUsername("random");
        });

        String expectedMessage = "User not found in the database";
        String actualMessage = exception.getMessage();

        assertTrue(actualMessage.contains(expectedMessage));
    }

}
