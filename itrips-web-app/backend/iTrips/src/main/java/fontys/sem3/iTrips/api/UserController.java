package fontys.sem3.iTrips.api;


import com.auth0.jwt.JWT;
import com.auth0.jwt.JWTVerifier;
import com.auth0.jwt.algorithms.Algorithm;
import com.auth0.jwt.interfaces.DecodedJWT;
import com.fasterxml.jackson.databind.ObjectMapper;
import fontys.sem3.iTrips.dto.user.BookerDTO;
import fontys.sem3.iTrips.dto.user.HotelManagerDTO;
import fontys.sem3.iTrips.dto.user.NewUserDTO;
import fontys.sem3.iTrips.dto.user.UserDTO;
import fontys.sem3.iTrips.model.User;
import fontys.sem3.iTrips.model.Role;
import fontys.sem3.iTrips.service.UserService;
import lombok.extern.slf4j.Slf4j;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;
import org.springframework.web.servlet.support.ServletUriComponentsBuilder;

import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import java.io.IOException;
import java.net.URI;
import java.util.*;
import java.util.stream.Collectors;

import static org.springframework.http.HttpHeaders.AUTHORIZATION;
import static org.springframework.http.HttpStatus.FORBIDDEN;
import static org.springframework.util.MimeTypeUtils.APPLICATION_JSON_VALUE;

@RestController
@RequestMapping("/api")
@Slf4j
public class UserController {

    @Autowired
    public UserController(UserService userService) {
        this.userService = userService;
    }
    private final UserService userService;

    @GetMapping("/users")
    public ResponseEntity<List<UserDTO>> getUsers() {
        return ResponseEntity.ok().body(userService.getUserDTOs());
    }

    @GetMapping("/bookers")
    public ResponseEntity<List<BookerDTO>> getBookers(){
        return ResponseEntity.ok().body(userService.getBookerDTOs());
    }

    @PostMapping("/register")
    public ResponseEntity<UserDTO> saveUser(@RequestBody NewUserDTO userDTO) {
        URI uri = URI.create(ServletUriComponentsBuilder.fromCurrentContextPath().path("/api/user/save").toUriString());
        return ResponseEntity.created(uri).body(userService.saveUser(userDTO));
    }

    @PutMapping("/user/update-password")
    public boolean updatePassword(@RequestParam Long userId, @RequestParam String newPassword, @RequestParam String currPassword){
        return userService.updatePassword(currPassword, newPassword, userId);
    }

    @GetMapping("/token/refresh")
    public void refreshToken(HttpServletRequest request, HttpServletResponse response) throws IOException {
        userService.refreshToken(request,response);
    }

    @PutMapping("/user/update-user")
    public boolean updateUser(@RequestParam String email, @RequestParam String firstName, @RequestParam String lastName, @RequestParam Long userId){
        return userService.updateUser(firstName,lastName,email,userId);
    }

}
