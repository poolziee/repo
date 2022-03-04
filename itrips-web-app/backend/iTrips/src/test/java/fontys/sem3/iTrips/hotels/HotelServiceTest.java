package fontys.sem3.iTrips.hotels;

import fontys.sem3.iTrips.dto.hotel.HotelDTO;
import fontys.sem3.iTrips.dto.hotel.NewHotelDTO;
import fontys.sem3.iTrips.dto.room.RoomWithoutRelationshipsDTO;
import fontys.sem3.iTrips.dto.user.NewUserDTO;
import fontys.sem3.iTrips.model.Role;
import fontys.sem3.iTrips.model.Room;
import fontys.sem3.iTrips.service.HotelService;

import fontys.sem3.iTrips.service.UserService;
import org.junit.jupiter.api.*;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.boot.test.context.SpringBootTest;
import org.springframework.test.annotation.DirtiesContext;
import org.springframework.test.annotation.Rollback;
import org.springframework.test.context.ActiveProfiles;
import org.springframework.transaction.annotation.Transactional;

import java.util.List;

import static org.junit.jupiter.api.Assertions.*;

@TestMethodOrder(MethodOrderer.OrderAnnotation.class)
@SpringBootTest
@Transactional
@ActiveProfiles("test")
@DirtiesContext(classMode = DirtiesContext.ClassMode.BEFORE_CLASS)
public class HotelServiceTest {

    @Autowired
    HotelService hotelService;
    @Autowired
    UserService userService;

    @Test
    @Order(1)
    @Rollback(false)
    void addNewHotel_success(){
        userService.saveRole(new Role(1L,"ROLE_HOTEL_MANAGER"));
        userService.saveUser(new NewUserDTO("test","user","user","user12345","x","ROLE_HOTEL_MANAGER"));
        hotelService.deleteAll();
    NewHotelDTO hotel = new NewHotelDTO(1, "3", "description", "Royal Spa Helmond",
            "Netherlands","Helmond", "Sint Jorislaan 12", "caption");
    hotelService.saveHotel(hotel);
    Assertions.assertEquals(1, hotelService.getHotels().get(0).getId());
    }

    @Test
    @Order(2)
    @Rollback(false)
    void getHotelById_success(){
        HotelDTO hotel = hotelService.getHotelById(1);
        assertEquals("Royal Spa Helmond", hotel.getName());
    }

    @Test
    @Order(3)
    @Rollback(false)
    void addRoom_success(){
        RoomWithoutRelationshipsDTO room = new RoomWithoutRelationshipsDTO("King Bed", 3, 2, 220);
       hotelService.addRoom(room, 1);
        Assertions.assertEquals("King Bed", hotelService.getRoomById(1).getType());
    }

    @Test
    @Order(4)
    @Rollback(false)
    void updateHotel_success(){
       NewHotelDTO hotel = new NewHotelDTO(0, "4", "updatedDescription", "Royal Spa Helmond",
               "Netherlands","Helmond", "Sint Jorislaan 12", "caption");
       hotelService.updateHotel(hotel, 1);
       Assertions.assertEquals("updatedDescription", hotelService.getHotelById(1).getDescription());
    }

    @Test
    @Order(5)
    @Rollback(false)
    void getByManagerId_success(){
        List<HotelDTO> hotels = hotelService.getHotelsByManagerId(1);
        Assertions.assertEquals("Royal Spa Helmond", hotels.get(0).getName());
    }

    @Test
    @Order(6)
    @Rollback(false)
    void updateRoom_success() {
        RoomWithoutRelationshipsDTO room = new RoomWithoutRelationshipsDTO("King Bed", 3, 2, 280);
        hotelService.updateRoom(room, 1L);
        Assertions.assertEquals(280, hotelService.getRoomById(1).getPrice());
    }


}
