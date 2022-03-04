package fontys.sem3.iTrips._mapper;

import fontys.sem3.iTrips.dto.booking.BookingDTO;
import fontys.sem3.iTrips.dto.booking.BookingWithoutUserDTO;
import fontys.sem3.iTrips.dto.booking.RoomBookingDTO;
import fontys.sem3.iTrips.model.Booking;
import org.mapstruct.Mapper;
import org.mapstruct.Mapping;

import java.util.List;

@Mapper(componentModel = "spring", uses={UserMapper.class,RoomMapper.class,HotelMapper.class})
public interface BookingMapper {

    @Mapping(target = "hotel", source = "room.hotel")
    BookingDTO toBookingDTO(Booking booking);

    @Mapping(target = "hotel", source = "room.hotel")
    BookingWithoutUserDTO toBookingWithoutUserDTO(Booking booking);

    RoomBookingDTO toRoomBookingDTO(Booking booking);
    List<BookingWithoutUserDTO> toBookingWithoutUserDTOs(List<Booking> bookings);
    List<BookingDTO> toBookingDTOs(List<Booking> bookings);

    @Mapping(target = "room.hotel" ,source="hotel")
    Booking toBooking(BookingDTO booking);

/*
    Booking NewBookingToBooking(NewBookingDTO bookingDTO);
*/
}
