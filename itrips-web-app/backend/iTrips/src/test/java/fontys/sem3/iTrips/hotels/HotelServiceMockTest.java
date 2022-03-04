package fontys.sem3.iTrips.hotels;
import fontys.sem3.iTrips._mapper.HotelMapper;
import fontys.sem3.iTrips._mapper.HotelMapperImpl;
import fontys.sem3.iTrips._mapper.RoomMapper;
import fontys.sem3.iTrips._mapper.RoomMapperImpl;
import fontys.sem3.iTrips.dto.hotel.HotelDTO;
import fontys.sem3.iTrips.dto.hotel.NewHotelDTO;
import fontys.sem3.iTrips.dto.room.RoomWithoutRelationshipsDTO;
import fontys.sem3.iTrips.model.Hotel;
import fontys.sem3.iTrips.model.Room;
import fontys.sem3.iTrips.model.User;
import fontys.sem3.iTrips.repo.HotelRepo;
import fontys.sem3.iTrips.repo.RoomRepo;
import fontys.sem3.iTrips.service.HotelService;
import fontys.sem3.iTrips.serviceInterfaces.IUserByIdAccessible;
import org.junit.Before;
import org.junit.jupiter.api.*;
import org.junit.runner.RunWith;
import org.mockito.InjectMocks;
import org.mockito.Mock;
import org.mockito.Spy;
import org.mockito.junit.MockitoJUnitRunner;
import org.springframework.boot.test.context.SpringBootTest;
import org.springframework.test.annotation.Rollback;
import org.springframework.test.context.ActiveProfiles;
import org.springframework.test.web.servlet.setup.MockMvcBuilders;

import java.util.ArrayList;
import java.util.List;

import static org.junit.jupiter.api.Assertions.assertEquals;
import static org.mockito.ArgumentMatchers.any;
import static org.mockito.Mockito.*;
import static org.springframework.security.test.web.servlet.setup.SecurityMockMvcConfigurers.springSecurity;


@TestMethodOrder(MethodOrderer.OrderAnnotation.class)
@SpringBootTest
@ActiveProfiles("test")
@RunWith(MockitoJUnitRunner.class)
public class HotelServiceMockTest {

    @Spy
    HotelMapper hotelMapper = new HotelMapperImpl();
    @Mock
    HotelRepo hotelRepo;
    @Mock
    RoomRepo roomRepo;
    @Spy
    RoomMapper roomMapper = new RoomMapperImpl();
    @Mock
    IUserByIdAccessible userService;

    @InjectMocks
    HotelService hotelService;

    @Test
    @Order(1)
    @Rollback(false)
    void addNewHotel_success(){
        User manager = new User(1L, "test","user", "testuser", "test12345", "test@mail.com",null, null,null);
        NewHotelDTO hotel = new NewHotelDTO(1, "3", "description", "Royal Spa Helmond",
                "Netherlands","Helmond", "Sint Jorislaan 12", "caption");
        Hotel savedHotel = new Hotel(1L, "Royal Spa Helmond", "description",
                "Netherlands", "Helmond", "Sint Jorislaan 12", "3", "caption", manager,null );
        when(userService.getUserById(1L)).thenReturn(manager);
        when(hotelRepo.save(any(Hotel.class))).thenReturn(savedHotel);
        hotelService.saveHotel(hotel);
        verify(userService).getUserById(1L);
        verify(hotelRepo).save(any(Hotel.class));
        List<Hotel> hotels = new ArrayList<>();
        hotels.add(savedHotel);
        when(hotelRepo.findAll()).thenReturn(hotels);
        Assertions.assertEquals(1, hotelService.getHotels().get(0).getId());
    }

    @Test
    @Order(2)
    @Rollback(false)
    void getHotelById_success(){
        Hotel hotelToReturn = new Hotel(1L, "Royal Spa Helmond", "description",
                "Netherlands", "Helmond", "Sint Jorislaan 12", "3", "caption", null,null );
        when(hotelRepo.getById(1L)).thenReturn(hotelToReturn);
        HotelDTO hotel = hotelService.getHotelById(1);
        verify(hotelRepo).getById(1L);
        verify(hotelMapper).toHotelDTO(hotelToReturn);
        assertEquals("Royal Spa Helmond", hotel.getName());
    }

    @Test
    @Order(3)
    @Rollback(false)
    void addRoom_success(){

        Hotel hotelEntity = new Hotel(1L, "Royal Spa Helmond", "description",
                "Netherlands", "Helmond", "Sint Jorislaan 12", "3", "caption", null,null );
        Room roomEntity = new Room(1L, "King Bed", hotelEntity, null, 3, 5, 220);
        RoomWithoutRelationshipsDTO newRoom = new RoomWithoutRelationshipsDTO(1L,"King Bed", 3, 5, 220);

        when(hotelRepo.getById(1L)).thenReturn(hotelEntity);
        when(roomRepo.save(any(Room.class))).thenReturn(roomEntity);
        when(roomRepo.getById(1L)).thenReturn(roomEntity);
        hotelService.addRoom(newRoom, 1L);
        verify(hotelRepo).getById(1L);
        verify(roomRepo, times(2)).save(any(Room.class));
        Assertions.assertEquals("King Bed", hotelService.getRoomById(1).getType());
    }

    @Test
    @Order(4)
    @Rollback(false)
    void updateHotel_success(){
        NewHotelDTO hotel = new NewHotelDTO(0, "4", "updatedDescription", "Royal Spa Helmond",
                "Netherlands","Helmond", "Sint Jorislaan 12", "caption");
        Hotel hotelEntity = new Hotel(1L, "Royal Spa Helmond", "description",
                "Netherlands", "Helmond", "Sint Jorislaan 12", "3", "caption", null,null );
        Hotel updatedEntity = new Hotel(1L, "Royal Spa Helmond", "updatedDescription",
                "Netherlands", "Helmond", "Sint Jorislaan 12", "3", "caption", null,null );

        when(hotelRepo.getById(1L)).thenReturn(hotelEntity);
        when(hotelRepo.save(any(Hotel.class))).thenReturn(updatedEntity);
        hotelService.updateHotel(hotel, 1L);
        verify(hotelRepo).getById(1L);
        verify(hotelRepo).save(any(Hotel.class));
        Assertions.assertEquals("updatedDescription", hotelService.getHotelById(1).getDescription());
    }

    @Test
    @Order(5)
    @Rollback(false)
    void getByManagerId_success(){
        User manager = new User(1L, "test","user", "testuser", "test12345", "test@mail.com",null, null,null);
        Hotel savedHotel = new Hotel(1L, "Royal Spa Helmond", "description",
                "Netherlands", "Helmond", "Sint Jorislaan 12", "3", "caption", manager,new ArrayList<>() );

        List<Hotel> hotelsToReturn = new ArrayList<>();
        hotelsToReturn.add(savedHotel);

        when(userService.getUserById(1L)).thenReturn(manager);
        when(hotelRepo.findAllByManager_Id(1L)).thenReturn(hotelsToReturn);
        List<HotelDTO> hotels = hotelService.getHotelsByManagerId(1L);
        verify(userService).getUserById(1L);
        verify(hotelRepo).findAllByManager_Id(1L);
        Assertions.assertEquals("Royal Spa Helmond", hotels.get(0).getName());
    }

    @Test
    @Order(6)
    @Rollback(false)
    void updateRoom_success() {
        Hotel hotelEntity = new Hotel(1L, "Royal Spa Helmond", "description",
                "Netherlands", "Helmond", "Sint Jorislaan 12", "3", "caption", null,null );
        Room roomEntity = new Room(1L, "King Bed", hotelEntity, null, 3, 5, 220);
        RoomWithoutRelationshipsDTO updatedRoom = new RoomWithoutRelationshipsDTO( "King Bed", 3, 5, 280);

    when(roomRepo.getById(1L)).thenReturn(roomEntity);
    when(roomRepo.save(any(Room.class))).thenReturn(roomEntity);
    hotelService.updateRoom(updatedRoom, 1L);
    verify(roomRepo).getById(1L);
    verify(roomRepo).save(any(Room.class));
    }

}
