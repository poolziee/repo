package fontys.sem3.iTrips.booking;

import fontys.sem3.iTrips._mapper.*;
import fontys.sem3.iTrips.dto.booking.BookingDTO;
import fontys.sem3.iTrips.dto.booking.NewBookingDTO;
import fontys.sem3.iTrips.dto.hotel.HotelWithoutRelationshipsDTO;
import fontys.sem3.iTrips.dto.room.RoomWithoutRelationshipsDTO;
import fontys.sem3.iTrips.model.Booking;
import fontys.sem3.iTrips.model.Hotel;
import fontys.sem3.iTrips.model.Room;
import fontys.sem3.iTrips.model.User;
import fontys.sem3.iTrips.repo.BookingRepo;
import fontys.sem3.iTrips.service.BookingService;
import fontys.sem3.iTrips.service.HotelService;
import fontys.sem3.iTrips.service.UserService;
import fontys.sem3.iTrips.serviceInterfaces.IHotelServiceBooking;
import fontys.sem3.iTrips.serviceInterfaces.IUserByIdAccessible;
import org.junit.jupiter.api.*;

import org.junit.runner.RunWith;
import org.mockito.InjectMocks;
import org.mockito.Mock;
import org.mockito.junit.MockitoJUnitRunner;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.boot.test.context.SpringBootTest;
import org.springframework.test.annotation.Rollback;
import org.springframework.test.context.ActiveProfiles;

import java.sql.Date;
import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.util.ArrayList;
import java.util.List;

import static org.mockito.ArgumentMatchers.any;
import static org.mockito.Mockito.*;

@TestMethodOrder(MethodOrderer.OrderAnnotation.class)
@SpringBootTest
@ActiveProfiles("test")
@RunWith(MockitoJUnitRunner.class)
public class BookingServiceMockTest {

    @Autowired
    UserService userServiceImpl;
    @Autowired
    HotelService hotelServiceImpl;

    SimpleDateFormat sdf1 = new SimpleDateFormat("MM/dd/yyyy");

    @Autowired
    BookingMapper realBookingMapper;

    @Autowired
    HotelMapper realHotelMapper;

    @Autowired
    UserMapper realUserMapper;

    @Autowired
    RoomMapper realRoomMapper;


    @Mock
     BookingMapper bookingMapper = new BookingMapperImpl();
    @Mock
    IUserByIdAccessible userService = userServiceImpl;
    @Mock
    IHotelServiceBooking hotelService = hotelServiceImpl;
    @Mock
     BookingRepo bookingRepo;

    @InjectMocks
    BookingService bookingService;

    Hotel hotel = null;
    Room room = null;
    User booker = null;
    Booking bookingEntity = null;
    NewBookingDTO newBooking = null;
    BookingDTO bookingDTO = null;
    @BeforeEach
    public void setup() throws ParseException {
         booker = new User(1L, "test","user", "testuser", "test12345", "test@mail.com",null, null,null);
        hotel = new Hotel(1L, "Royal Spa Helmond", "description",
                "Netherlands", "Helmond", "Sint Jorislaan 12", "3", "caption", null,null );

        List<Room> rooms = new ArrayList<>();
        room = new Room(1L, "King Bed", hotel, new ArrayList<>(), 3, 2, 220);
        rooms.add(room);
        hotel.setRooms(rooms);

        Date checkin =  new Date(sdf1.parse("01/01/2022").getTime());
        Date checkout = new Date(sdf1.parse("01/04/2022").getTime());
        bookingEntity = new Booking(1L,440.0,booker,room,checkin,checkout);
        newBooking = new NewBookingDTO(440.0,1L,1L,"01/01/2022","01/04/2022" );
        HotelWithoutRelationshipsDTO hotelNoR = new HotelWithoutRelationshipsDTO(1L, "Royal Spa Helmond", "description",
                "Netherlands", "Helmond", "Sint Jorislaan 12", "3", "caption");
        RoomWithoutRelationshipsDTO roomNoR = new RoomWithoutRelationshipsDTO(1L, "King Bed" , 3, 2, 220);
         bookingDTO = new BookingDTO(1L,440.0,checkin,checkout,realUserMapper.toBookerInfoDTO(booker),
                hotelNoR,roomNoR);
    }

    @Test
    @Rollback(false)
    void saveBooking_success() throws ParseException {
    when(hotelService.getRoomById(1L)).thenReturn(room);
    when(bookingRepo.save(any(Booking.class))).thenReturn(bookingEntity);
    when(userService.getUserById(1L)).thenReturn(booker);
    when(bookingMapper.toBookingDTO(any(Booking.class))).thenReturn(bookingDTO);
    BookingDTO savedBooking = bookingService.saveBooking(newBooking);
    verify(hotelService).getRoomById(1L);
    verify(bookingRepo, times(2)).save(any(Booking.class));
    verify(userService).getUserById(1L);
        Assertions.assertEquals(1L, savedBooking.getId());
    }

    @Test
    @Rollback(false)
    void deleteBooking_success() {
        when(bookingRepo.save(any(Booking.class))).thenReturn(null);
        when(bookingRepo.findById(1L)).thenReturn(java.util.Optional.ofNullable(bookingEntity));
        bookingService.deleteBooking(1L);
        verify(bookingRepo).getById(1L);
        verify(bookingRepo).delete(null);

    }

}
