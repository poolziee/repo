package fontys.sem3.iTrips.users;

import fontys.sem3.iTrips._mapper.UserMapper;
import fontys.sem3.iTrips.dto.user.NewUserDTO;
import fontys.sem3.iTrips.dto.user.UserDTO;
import fontys.sem3.iTrips.exception.UnsatisfiedPasswordException;
import fontys.sem3.iTrips.exception.UserAlreadyExistsException;
import fontys.sem3.iTrips.model.Role;
import fontys.sem3.iTrips.model.User;
import fontys.sem3.iTrips.repo.RoleRepo;
import fontys.sem3.iTrips.repo.UserRepo;
import fontys.sem3.iTrips.service.UserService;
import org.junit.jupiter.api.*;
import org.junit.runner.RunWith;
import org.mockito.InjectMocks;
import org.mockito.Mock;
import org.mockito.junit.MockitoJUnitRunner;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.boot.test.context.SpringBootTest;
import org.springframework.security.core.userdetails.UsernameNotFoundException;
import org.springframework.security.crypto.password.PasswordEncoder;
import org.springframework.test.context.ActiveProfiles;
import org.springframework.transaction.annotation.Transactional;

import java.util.ArrayList;
import java.util.List;

import static org.assertj.core.api.AssertionsForClassTypes.assertThat;
import static org.junit.jupiter.api.Assertions.assertThrows;
import static org.junit.jupiter.api.Assertions.assertTrue;
import static org.mockito.ArgumentMatchers.any;
import static org.mockito.Mockito.*;

@TestMethodOrder(MethodOrderer.OrderAnnotation.class)
@SpringBootTest
@ActiveProfiles("test")
@RunWith(MockitoJUnitRunner.class)
public class UserServiceMockTest {

    @Mock
    UserRepo userRepo;
    @Mock
    UserMapper userMapper;
    @Mock
    RoleRepo roleRepo;
    @Mock
    PasswordEncoder encoder;
    @InjectMocks
    UserService userService;

    @Test
    @Order(1)
    public void addNewUser_success() {
        NewUserDTO user = new NewUserDTO("test","user", "testuser", "test12345", "test@mail.com", "ROLE_BOOKER");
        List<Role> roles = new ArrayList<>();
        roles.add(new Role(1L,"ROLE_BOOKER"));
        when(userMapper.toUser(any(NewUserDTO.class))).thenReturn(new User(null, "test","user", "testuser", "test12345", "test@mail.com",null, roles,null));
        when(userRepo.save(any(User.class))).thenReturn(new User(null, "test","user", "testuser", "test12345", "test@mail.com",null, roles,null));
        when(encoder.encode(any(CharSequence.class))).thenReturn("xsk42iyj41");
        when(roleRepo.findByName(any(String.class))).thenReturn(new Role(1L,"ROLE_USER"));
        when(userMapper.toUserDto(any(User.class))).thenReturn(new UserDTO(null, "test","user", "testuser", "test12345", roles,null));
        UserDTO created = userService.saveUser(user);
        verify(userMapper).toUser(any(NewUserDTO.class));
        verify(userRepo).save(any(User.class));
        verify(encoder).encode(any(CharSequence.class));
        verify(roleRepo, times(2)).findByName(any(String.class));
        verify(userMapper).toUserDto(any(User.class));

        assertThat(created.getUsername()).isSameAs(user.getUsername());
    }

    @Test
    @Order(2)
    void usernameAlreadyExists_exception() {
        List<Role> roles = new ArrayList<>();
        roles.add(new Role(1L,"ROLE_BOOKER"));

        User userToReturn = new User(1L, "test","user", "testuser", "test12345", "test@mail.com",null, roles,null);
        NewUserDTO user = new NewUserDTO("anothertest","user2", "testuser", "test12345", "test3@mail.com", "ROLE_BOOKER");
        when(userRepo.findByUsername(any(String.class))).thenReturn(userToReturn);
        when(userRepo.findByEmail(any(String.class))).thenReturn(userToReturn);
        UserAlreadyExistsException exception = assertThrows(UserAlreadyExistsException.class, () -> {
            userService.saveUser(user);
        });
        verify(userRepo).findByUsername(any(String.class));
        verify(userRepo).findByEmail(any(String.class));

        String expectedMessage = "Account with this username already exists";
        String actualMessage = exception.getMessage();

        assertTrue(actualMessage.contains(expectedMessage));
    }

    @Test
    @Order(3)
    void loadUserByUsername_exception() {
        when(userRepo.findByUsername("random")).thenReturn(null);
        UsernameNotFoundException exception = assertThrows(UsernameNotFoundException.class, () -> {
            userService.loadUserByUsername("random");
        });
        verify(userRepo).findByUsername("random");

        String expectedMessage = "User not found in the database";
        String actualMessage = exception.getMessage();

        assertTrue(actualMessage.contains(expectedMessage));
    }

    @Test
    @Order(4)
    @Transactional
    void updatePassword_success() {
        List<Role> roles = new ArrayList<>();
        roles.add(new Role(1L,"ROLE_BOOKER"));

        User userToReturn = new User(1L, "test","user", "testuser", "test@mail.com", "test12345",null, roles,null);
        when(userRepo.getById(1L)).thenReturn(userToReturn);
        when(encoder.matches(any(), any())).thenReturn(true);
        userService.updatePassword("test12345", "andyUpdate123", 1L);
        verify(userRepo).getById(1L);
        verify(userRepo).save(any(User.class));
    }

}
