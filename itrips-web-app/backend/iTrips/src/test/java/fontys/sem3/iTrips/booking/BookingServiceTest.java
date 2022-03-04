package fontys.sem3.iTrips.booking;

import fontys.sem3.iTrips.dto.booking.BookingDTO;
import fontys.sem3.iTrips.dto.booking.NewBookingDTO;
import fontys.sem3.iTrips.dto.hotel.HotelOfferDTO;
import fontys.sem3.iTrips.dto.hotel.NewHotelDTO;
import fontys.sem3.iTrips.dto.room.RoomWithoutRelationshipsDTO;
import fontys.sem3.iTrips.dto.user.NewUserDTO;
import fontys.sem3.iTrips.model.Role;
import fontys.sem3.iTrips.service.BookingService;
import fontys.sem3.iTrips.service.HotelService;
import fontys.sem3.iTrips.service.UserService;
import org.junit.jupiter.api.*;
import org.junit.runner.RunWith;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.boot.test.context.SpringBootTest;
import org.springframework.test.annotation.DirtiesContext;
import org.springframework.test.annotation.Rollback;
import org.springframework.test.context.ActiveProfiles;
import org.springframework.test.context.junit4.SpringRunner;
import org.springframework.transaction.annotation.Transactional;

import java.sql.Date;
import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.util.List;

@RunWith(SpringRunner.class)
@TestMethodOrder(MethodOrderer.OrderAnnotation.class)
@SpringBootTest
@Transactional
@ActiveProfiles("test")
@DirtiesContext(classMode = DirtiesContext.ClassMode.BEFORE_CLASS)
public class BookingServiceTest {

    SimpleDateFormat sdf1 = new SimpleDateFormat("MM/dd/yyyy");
    @Autowired
    BookingService bookingService;

    @Autowired
     HotelService hotelService;

    @Autowired
    UserService userService;

    @Test
    @Order(1)
    @Rollback(false)
    void addBooking_success() throws ParseException {
        userService.saveRole(new Role(1L,"ROLE_HOTEL_MANAGER"));
        userService.saveUser(new NewUserDTO("test","user","user","user12345","x","ROLE_HOTEL_MANAGER"));
        NewHotelDTO hotel = new NewHotelDTO(1, "3", "description", "Royal Spa Helmond",
                "Netherlands","Helmond", "Sint Jorislaan 12", "caption");
        hotelService.saveHotel(hotel);
        RoomWithoutRelationshipsDTO room = new RoomWithoutRelationshipsDTO("King Bed Deluxe", 3,2,220);
        hotelService.addRoom(room, 1);
    BookingDTO savedBooking = bookingService.saveBooking(new NewBookingDTO(440.0,1L,1L,"01/01/2022", "01/04/2022"));
        Assertions.assertEquals("King Bed Deluxe", savedBooking.getRoom().getType());
    }

    @Test
    @Order(2)
    @Rollback(false)
  void roomBookingAvailableFor2Dates() throws ParseException {
      Date checkin =  new Date(sdf1.parse("01/02/2022").getTime());
      Date checkout = new Date(sdf1.parse("01/06/2022").getTime());
        boolean answer = bookingService.bookingAvailable(checkin,checkout, hotelService.getRoomById(1));
      Assertions.assertTrue(answer);
  }

  @Test
  @Order(3)
  void getAvailableOffers() throws ParseException {
        List<HotelOfferDTO> offers = bookingService.getOffers("Helmond, Netherlands", "01/01/2022", "01/05/2022", 3);
        Assertions.assertEquals(4, offers.get(0).getTotalNights());
  }

  @Test
    @Order(4)
    void getBookingsByUser() {
        int size = bookingService.getBookingsByUser(1L).size();
        Assertions.assertEquals(1,size);
  }

  @Test
    @Order(5)
    void deleteBooking(){
        bookingService.deleteBooking(1L);
        int bookings = bookingService.getBookingDTOs().size();
        Assertions.assertEquals(bookings, 0);
  }



}
