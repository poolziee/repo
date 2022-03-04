package fontys.sem3.iTrips._mapper;


import fontys.sem3.iTrips.dto.user.*;
import fontys.sem3.iTrips.model.User;
import org.mapstruct.Mapper;


import java.util.List;

@Mapper(componentModel = "spring", uses={BookingMapper.class,RoomMapper.class,HotelMapper.class})
public interface UserMapper {

    BookerDTO toBookerDTO(User booker);

    BookerInfoDTO toBookerInfoDTO(User booker);

    UserDTO toUserDto(User user);

    User toUser(UserDTO user);

    List<UserDTO> toUserDTOs(List<User> users);

    List<BookerDTO> toBookerDTOs(List<User> users);

    User toUser(NewUserDTO user);

    HotelManagerDTO toHotelManagerDTO(User user);


}
