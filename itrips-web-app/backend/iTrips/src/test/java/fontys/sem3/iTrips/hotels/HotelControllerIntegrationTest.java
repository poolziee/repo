package fontys.sem3.iTrips.hotels;

import com.fasterxml.jackson.databind.ObjectMapper;
import fontys.sem3.iTrips.dto.hotel.HotelDTO;
import fontys.sem3.iTrips.dto.hotel.NewHotelDTO;
import fontys.sem3.iTrips.dto.room.RoomWithoutRelationshipsDTO;
import fontys.sem3.iTrips.dto.user.NewUserDTO;
import fontys.sem3.iTrips.model.Role;
import fontys.sem3.iTrips.model.Room;
import fontys.sem3.iTrips.service.HotelService;
import fontys.sem3.iTrips.service.UserService;
import org.junit.Before;
import org.junit.jupiter.api.*;
import org.junit.runner.RunWith;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.boot.test.autoconfigure.web.servlet.AutoConfigureMockMvc;
import org.springframework.boot.test.context.SpringBootTest;
import org.springframework.http.MediaType;
import org.springframework.security.test.context.support.WithMockUser;
import org.springframework.test.annotation.DirtiesContext;
import org.springframework.test.annotation.Rollback;
import org.springframework.test.context.ActiveProfiles;
import org.springframework.test.context.junit4.SpringRunner;
import org.springframework.test.web.servlet.MockMvc;
import org.springframework.test.web.servlet.setup.MockMvcBuilders;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.web.context.WebApplicationContext;

import java.util.List;

import static org.springframework.security.test.web.servlet.setup.SecurityMockMvcConfigurers.springSecurity;
import static org.springframework.test.web.servlet.request.MockMvcRequestBuilders.post;
import static org.springframework.test.web.servlet.request.MockMvcRequestBuilders.put;
import static org.springframework.test.web.servlet.result.MockMvcResultMatchers.status;

@RunWith(SpringRunner.class)
@SpringBootTest(webEnvironment = SpringBootTest.WebEnvironment.RANDOM_PORT)
@AutoConfigureMockMvc(addFilters = false)
@TestMethodOrder(MethodOrderer.OrderAnnotation.class)
@Transactional
@ActiveProfiles("test")
@DirtiesContext(classMode = DirtiesContext.ClassMode.BEFORE_CLASS)
public class HotelControllerIntegrationTest {

    @Autowired
    private WebApplicationContext context;

    @Autowired
    private MockMvc mvc;

    @Before
    public void setup() {
        mvc = MockMvcBuilders
                .webAppContextSetup(context)
                .apply(springSecurity())
                .build();
    }

    @Autowired
    private ObjectMapper objectMapper;

    @Autowired
    private HotelService hotelService;

    @Autowired
    private UserService userService;

    @Test
    @WithMockUser("spring")
    @Order(1)
    @Rollback(false)
    void addingHotelWorksThroughAllLayers() throws Exception{
        userService.saveRole(new Role(1L,"ROLE_HOTEL_MANAGER"));
        userService.saveUser(new NewUserDTO("test","user","user","user12345","x","ROLE_HOTEL_MANAGER"));
        hotelService.deleteAll();
        NewHotelDTO hotel = new NewHotelDTO(1, "3", "description", "Royal Spa Tilburg",
                "Netherlands","Tilburg", "Sint Jorislaan 12","caption");
        mvc.perform(post("/api/hotel_manager/hotel/save")
                .contentType(MediaType.APPLICATION_JSON)
                .content(objectMapper.writeValueAsString(hotel)))
                .andExpect(status().is(200));
        List<HotelDTO> hotels = hotelService.getHotels();
        boolean result = hotels.stream().anyMatch(h -> h.getName().equals("Royal Spa Tilburg"));
        Assertions.assertTrue(result);

    }

    @Test
    @WithMockUser("spring")
    @Order(2)
    @Rollback(false)
    void addingRoomWorksThroughAllLayers() throws Exception {
        RoomWithoutRelationshipsDTO room = new RoomWithoutRelationshipsDTO("Double Bed", 3, 2, 220);
        mvc.perform(post("/api/hotel_manager/rooms/new").contentType(MediaType.APPLICATION_JSON)
                .content(objectMapper.writeValueAsString(room))
                .param("hotelId", "1")).andExpect(status().is(200));
       Room addedRoom = hotelService.getRoomById(1);
        Assertions.assertEquals("Double Bed", addedRoom.getType());
    }

    @Test
    @WithMockUser("spring")
    @Order(3)
    @Rollback(false)
    void updateHotelWorksThroughAllLayers() throws Exception {
        NewHotelDTO hotel = new NewHotelDTO(0, "4", "updatedDescription", "Royal Spa Tilburg",
                "Netherlands","Helmond", "Sint Jorislaan 12","caption");
        mvc.perform(put("/api/hotel_manager/hotel/update").contentType(MediaType.APPLICATION_JSON)
                .content(objectMapper.writeValueAsString(hotel))
                .param("hotelId", "1")).andExpect(status().is(200));
        Assertions.assertEquals("updatedDescription", hotelService.getHotelById(1).getDescription());

    }

    @Test
    @WithMockUser("spring")
    @Order(4)
    @Rollback(false)
    void updateRoomWorksThroughAllLayers() throws Exception {

        RoomWithoutRelationshipsDTO room = new RoomWithoutRelationshipsDTO("Double Bed", 3, 2, 280);
        mvc.perform(put("/api/hotel_manager/rooms/update").contentType(MediaType.APPLICATION_JSON)
                .content(objectMapper.writeValueAsString(room))
                .param("roomId", "1")).andExpect(status().is(200));
        Assertions.assertEquals(280, hotelService.getRoomById(1L).getPrice());

    }

}
