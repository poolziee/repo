package fontys.sem3.iTrips.service;

import fontys.sem3.iTrips._mapper.HotelMapper;
import fontys.sem3.iTrips._mapper.RoomMapper;
import fontys.sem3.iTrips.dto.hotel.HotelDTO;
import fontys.sem3.iTrips.dto.hotel.NewHotelDTO;
import fontys.sem3.iTrips.dto.room.RoomWithBookingsDTO;
import fontys.sem3.iTrips.dto.room.RoomWithoutRelationshipsDTO;
import fontys.sem3.iTrips.model.Hotel;
import fontys.sem3.iTrips.model.Room;
import fontys.sem3.iTrips.model.User;
import fontys.sem3.iTrips.repo.HotelRepo;
import fontys.sem3.iTrips.repo.RoomRepo;
import fontys.sem3.iTrips.serviceInterfaces.IHotelServiceBooking;
import fontys.sem3.iTrips.serviceInterfaces.IUserByIdAccessible;
import lombok.extern.slf4j.Slf4j;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import java.util.ArrayList;
import java.util.List;
import java.util.Objects;

@Service
@Slf4j
public class HotelService implements IHotelServiceBooking {

    @Autowired
    public HotelService(HotelRepo hotelRepo, RoomRepo roomRepo, RoomMapper roomMapper, HotelMapper hotelMapper, IUserByIdAccessible userService) {
        this.hotelRepo = hotelRepo;
        this.roomRepo = roomRepo;
        this.roomMapper = roomMapper;
        this.hotelMapper = hotelMapper;
        this.userService = userService;
    }

    private final HotelRepo hotelRepo;
    private final RoomRepo roomRepo;
    private final RoomMapper roomMapper;
    private final HotelMapper hotelMapper;
    private final IUserByIdAccessible userService;

    public List<Hotel> getByManagerId(Long id) {
        return hotelRepo.findAllByManager_Id(id);
    }

    public Hotel getByName(String name) {
        return hotelRepo.getByName(name);
    }

    public List<Room> getAllRooms() {
        return roomRepo.findAll();
    }

    public Hotel getById(Long id) {
        return hotelRepo.getById(id);
    }
    //  MANAGING SERVICE

    public List<HotelDTO> getHotels() {
       List<Hotel> hotels = hotelRepo.findAll();
       return hotelMapper.toHotelDTOs(hotels);
    }

    public Room getRoomById(long id){
        return roomRepo.getById(id);
    }

    public void deleteAll(){
        hotelRepo.deleteAll();
        roomRepo.deleteAll();
    }

    public List<Hotel> getAll() {
       return hotelRepo.findAll();
    }

    public HotelDTO getHotelById(long hotelId){
        return hotelMapper.toHotelDTO(hotelRepo.getById(hotelId));
    }

    public List<HotelDTO> getHotelsByManagerId(long managerId){

    User manager = userService.getUserById(managerId);
    List<HotelDTO> hotels = hotelMapper.toHotelDTOs(hotelRepo.findAllByManager_Id(managerId));
    hotels.forEach(h -> {
        int total_bookings = h.getRooms().stream().mapToInt(r -> r.getBookings().size()).sum();
        h.setTotal_bookings(total_bookings);
    });
    return hotels;

    }

    public HotelDTO saveHotel(NewHotelDTO newHotel) {
        log.info("Adding hotel: {}", newHotel);
        User manager = userService.getUserById(newHotel.getManagerId());
        Hotel hotel = hotelMapper.toHotel(newHotel);
        hotel.setManager(manager);
        return hotelMapper.toHotelDTO(hotelRepo.save(hotel));
    }

    public HotelDTO updateHotel(NewHotelDTO updated, long hotelId){
        Hotel hotel = hotelRepo.getById(hotelId);
        hotel.setDescription(updated.getDescription());
        hotel.setName(updated.getName());
        hotel.setCountry(updated.getCountry());
        hotel.setCity(updated.getCity());
        hotel.setStreet(updated.getStreet());
        hotel.setStars(updated.getStars());
        hotel.setCaption(updated.getCaption());
        return hotelMapper.toHotelDTO(hotelRepo.save(hotel));
    }
    public HotelDTO updateRoom(RoomWithoutRelationshipsDTO updated, Long roomId){
        Room room = roomRepo.getById(roomId);
        room.setType(updated.getType());
        room.setSleeps(updated.getSleeps());
        room.setPrice(updated.getPrice());
        room.setTotal(updated.getTotal());
        return hotelMapper.toHotelDTO(roomRepo.save(room).getHotel());
    }
    public HotelDTO addRoom(RoomWithoutRelationshipsDTO newRoom, long hotelId) {
        Hotel hotel = hotelRepo.getById(hotelId);
        log.info("Room: {}", newRoom);
        Room room = roomRepo.save(roomMapper.toRoom(newRoom));
      /*  log.info("Saved room to database with id: {}",room.getId());*/
        room.setHotel(hotel);
        return hotelMapper.toHotelDTO((roomRepo.save(room)).getHotel());
    }

    public List<String> getAddresses(){
        List<String> countries = new ArrayList<>();
        List<String> combined = new ArrayList<>();
        for(Hotel h : hotelRepo.findAll()){
            if(!countries.contains(h.getCountry())){
                countries.add(h.getCountry());
            }
            String comb = h.getCity() + ", " + h.getCountry();
            if(!combined.contains(comb)){
                combined.add(comb);
            }

        }
        combined.addAll(countries);
        return combined;
    }

    public List<RoomWithBookingsDTO> getRooms(){
        return roomMapper.roomWithBookingDTOs(roomRepo.findAll());
    }
}
