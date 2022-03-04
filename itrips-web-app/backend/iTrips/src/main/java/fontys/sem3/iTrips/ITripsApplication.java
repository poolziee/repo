package fontys.sem3.iTrips;

import fontys.sem3.iTrips.dto.hotel.NewHotelDTO;
import fontys.sem3.iTrips.dto.room.RoomWithoutRelationshipsDTO;
import fontys.sem3.iTrips.dto.user.NewUserDTO;
import fontys.sem3.iTrips.model.Role;
import fontys.sem3.iTrips.model.User;
import fontys.sem3.iTrips.service.HotelService;
import fontys.sem3.iTrips.service.UserService;
import org.springframework.boot.CommandLineRunner;
import org.springframework.boot.SpringApplication;
import org.springframework.boot.autoconfigure.SpringBootApplication;
import org.springframework.context.annotation.Bean;
import org.springframework.security.crypto.bcrypt.BCryptPasswordEncoder;
import org.springframework.security.crypto.password.PasswordEncoder;
import org.springframework.web.cors.CorsConfiguration;
import org.springframework.web.cors.UrlBasedCorsConfigurationSource;
import org.springframework.web.filter.CorsFilter;

import java.util.ArrayList;
import java.util.Arrays;

@SpringBootApplication
public class ITripsApplication {

	public static void main(String[] args) {
		SpringApplication.run(ITripsApplication.class, args);
	}

	@Bean
	PasswordEncoder passwordEncoder(){
		return new BCryptPasswordEncoder();
	}

	@Bean
	CommandLineRunner run(UserService userService, HotelService hotelService) {
		return args -> {
			/*userService.saveRole(new Role(null,"ROLE_BOOKER"));
			userService.saveRole(new Role(null,"ROLE_ADMIN"));
			userService.saveRole(new Role(null,"ROLE_HOTEL_MANAGER"));
			userService.saveRole(new Role(null, "ROLE_USER"));

			userService.saveUser(new NewUserDTO("Gregor"," Collins", "gregor", "gregor1234","gregor@mail.com", "ROLE_HOTEL_MANAGER"));
			userService.saveUser(new NewUserDTO("Elon"," Musk", "elon", "elon1234","elon@mail.com", "ROLE_HOTEL_MANAGER"));
			userService.saveUser(new NewUserDTO("John"," Travolta", "john", "john1234","john@mail.com", "ROLE_BOOKER"));
			userService.saveUser(new NewUserDTO("Jimmy ","Hendrix", "jimmy", "jimmy1234","jimmy@mail.com", "ROLE_BOOKER"));
			userService.saveUser(new NewUserDTO("Peter","Parker", "peter", "peter1234","peter@mail.com", "ROLE_BOOKER"));*/
		};
	}
}
