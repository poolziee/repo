package fontys.sem3.iTrips._mapper;

import fontys.sem3.iTrips.dto.hotel.HotelWithoutRelationshipsDTO;
import fontys.sem3.iTrips.dto.hotel.HotelDTO;
import fontys.sem3.iTrips.dto.hotel.NewHotelDTO;
import fontys.sem3.iTrips.model.Hotel;
import org.mapstruct.Mapper;

import java.util.List;

@Mapper(componentModel = "spring", uses={BookingMapper.class,RoomMapper.class,UserMapper.class})
public interface HotelMapper {

    HotelWithoutRelationshipsDTO toBookedHotelDTO(Hotel hotel);
    HotelDTO toHotelDTO(Hotel hotel);
    List<HotelDTO> toHotelDTOs(List<Hotel> hotels);
    Hotel toHotel (HotelWithoutRelationshipsDTO hotel);
    Hotel toHotel(NewHotelDTO hotel);
    Hotel fakeHotelDTO(NewHotelDTO fake);
}
