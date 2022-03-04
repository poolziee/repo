package fontys.sem3.iTrips._mapper;

import fontys.sem3.iTrips.dto.room.HotelRoomDTO;
import fontys.sem3.iTrips.dto.room.RoomWithoutRelationshipsDTO;
import fontys.sem3.iTrips.dto.room.RoomWithBookingsDTO;
import fontys.sem3.iTrips.model.Room;
import org.mapstruct.Mapper;

import java.util.List;

@Mapper(componentModel = "spring", uses={BookingMapper.class,HotelMapper.class,UserMapper.class})
public interface RoomMapper {


    RoomWithoutRelationshipsDTO toBookedRoomDTO(Room room);

    RoomWithBookingsDTO toRoomWithBookingsDTO(Room room);

    Room toRoom(RoomWithoutRelationshipsDTO room);

    HotelRoomDTO toHotelRoomDTO(Room room);

    List<RoomWithBookingsDTO> roomWithBookingDTOs(List<Room> rooms);
}
