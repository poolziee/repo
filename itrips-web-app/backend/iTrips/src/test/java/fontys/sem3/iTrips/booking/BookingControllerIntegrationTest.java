package fontys.sem3.iTrips.booking;

import com.fasterxml.jackson.databind.ObjectMapper;
import fontys.sem3.iTrips.dto.booking.BookingDTO;
import fontys.sem3.iTrips.dto.booking.NewBookingDTO;
import fontys.sem3.iTrips.dto.hotel.NewHotelDTO;
import fontys.sem3.iTrips.dto.room.RoomWithoutRelationshipsDTO;
import fontys.sem3.iTrips.dto.user.NewUserDTO;
import fontys.sem3.iTrips.service.BookingService;
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
import org.springframework.test.context.ActiveProfiles;
import org.springframework.test.context.junit4.SpringRunner;
import org.springframework.test.web.servlet.MockMvc;
import org.springframework.test.web.servlet.setup.MockMvcBuilders;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.web.context.WebApplicationContext;

import java.util.List;

import static org.springframework.security.test.web.servlet.setup.SecurityMockMvcConfigurers.springSecurity;
import static org.springframework.test.web.servlet.request.MockMvcRequestBuilders.*;
import static org.springframework.test.web.servlet.result.MockMvcResultMatchers.status;

@RunWith(SpringRunner.class)
@SpringBootTest(webEnvironment = SpringBootTest.WebEnvironment.RANDOM_PORT)
@AutoConfigureMockMvc(addFilters = false)
@TestMethodOrder(MethodOrderer.OrderAnnotation.class)
@Transactional
@ActiveProfiles("test")
@DirtiesContext(classMode = DirtiesContext.ClassMode.BEFORE_EACH_TEST_METHOD)
public class BookingControllerIntegrationTest {

    @Autowired
    private WebApplicationContext context;

    @Autowired
    private ObjectMapper objectMapper;

    @Autowired
    private MockMvc mockMvc;
    @Autowired
    private MockMvc mvc;

    @Autowired
    private HotelService hotelService;

    @Autowired
    private BookingService bookingService;

    @Autowired
    private UserService userService;

    @Before
    public void setup() {
        mvc = MockMvcBuilders
                .webAppContextSetup(context)
                .apply(springSecurity())
                .build();
    }

    @BeforeEach
    public void setData() {
        userService.saveUser(new NewUserDTO("Andy","Colins", "andy", "andy1234", "andyC@mail.com", "ROLE_HOTEL_MANAGER"));
        userService.saveUser(new NewUserDTO("Peter","Parker", "peter", "peter1234", "peter@mail.com", "ROLE_BOOKER"));
        NewHotelDTO hotel = new NewHotelDTO(1, "3", "description", "Royal Spa Helmond",
                "Netherlands","Helmond", "Sint Jorislaan 12", "caption");
        hotelService.saveHotel(hotel);
        RoomWithoutRelationshipsDTO room = new RoomWithoutRelationshipsDTO("King Bed Deluxe", 3,2,220);
        hotelService.addRoom(room, 1);
    }

    @Test
    @WithMockUser("spring")
    @Order(1)
    void bookingWorksThroughAllLayers() throws Exception{

        NewBookingDTO bookingToAdd = new NewBookingDTO(440.0,2L,1L,"01/01/2022", "01/04/2022");
        mvc.perform(post("/api/booker/booking/save")
                        .contentType(MediaType.APPLICATION_JSON)
                        .content(objectMapper.writeValueAsString(bookingToAdd)))
                .andExpect(status().is(200));
        List<BookingDTO> bookings = bookingService.getBookingDTOs();
        boolean result = bookings.stream().anyMatch(b -> b.getId() == 1);
        Assertions.assertTrue(result);

    }

    @Test
    @WithMockUser("spring")
    @Order(2)
    void getBookingsWorksThroughAllLayers() throws Exception {
       bookingService.saveBooking(new NewBookingDTO(440.0,2L,1L,"01/01/2022", "01/04/2022"));
        mvc.perform(get("/api/bookings"))
                .andExpect(status().is(200));
        List<BookingDTO> bookings = bookingService.getBookingDTOs();
        Assertions.assertEquals(1, bookings.size());
    }

    @Test
    @WithMockUser("spring")
    @Order(3)
    void bookingsByUserWorksThroughAllLayers() throws Exception {
        bookingService.saveBooking(new NewBookingDTO(440.0,2L,1L,"01/01/2022", "01/04/2022"));
        mvc.perform(get("/api/booker/bookings-by-user")
                        .contentType(MediaType.APPLICATION_JSON)
                .param("id", "1"))
                .andExpect(status().is(200));
        List<BookingDTO> bookings = bookingService.getBookingsByUser(2);
        Assertions.assertEquals(1, bookings.size());
    }

    @Test
    @WithMockUser("spring")
    @Order(4)
    void deleteBookingWorksThroughAllLayers() throws  Exception {
        mvc.perform(delete("/api/booker/delete-booking")
                        .contentType(MediaType.APPLICATION_JSON)
                        .param("bookingId", "1")

                )
                .andExpect(status().is(200));
        List<BookingDTO> bookings = bookingService.getBookingsByUser(2);
        Assertions.assertEquals(0, bookings.size());
    }


    @Test
    @WithMockUser("spring")
    @Order(5)
    void getOfferWorksThroughAllLayers() throws  Exception {
        mvc.perform(get("/api/booker/get_offers")
                        .contentType(MediaType.APPLICATION_JSON)
                        .param("location", "Helmond, Netherlands")
                        .param("checkinString","02/01/2022")
                        .param("checkoutString", "02/02/2022")
                        .param("guests", "3")
                )
                .andExpect(status().is(200));
    }


}
