package fontys.sem3.iTrips.api;


import fontys.sem3.iTrips.dto.hotel.HotelDTO;
import fontys.sem3.iTrips.dto.hotel.NewHotelDTO;
import fontys.sem3.iTrips.dto.room.RoomWithBookingsDTO;
import fontys.sem3.iTrips.dto.room.RoomWithoutRelationshipsDTO;
import fontys.sem3.iTrips.dto.user.NewUserDTO;
import fontys.sem3.iTrips.model.Hotel;
import fontys.sem3.iTrips.model.Role;
import fontys.sem3.iTrips.service.BookingService;
import fontys.sem3.iTrips.service.HotelService;
import fontys.sem3.iTrips.service.UserService;
import fontys.sem3.iTrips.util.overview.OverviewData;
import lombok.extern.slf4j.Slf4j;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.web.bind.annotation.*;

import java.text.ParseException;
import java.util.List;


@RestController
@RequestMapping("/api")
@Slf4j
public class HotelController {

    private final HotelService hotelService;
    private final BookingService bookingService;

    public HotelController(HotelService hotelService, BookingService bookingService){

        this.hotelService = hotelService;
        this.bookingService = bookingService;

    }

    @GetMapping("/hotel_manager/hotels")
    public List<HotelDTO> getHotels(){

        return hotelService.getHotels();
    }

    @GetMapping("/hotel_manager/hotels-by-manager")
    public List<HotelDTO> getHotelsByManagerId(@RequestParam Long managerId){
        return hotelService.getHotelsByManagerId(managerId);
    }


    @PostMapping("/hotel_manager/hotel/save")
    public HotelDTO saveHotel( @RequestBody NewHotelDTO hotel){
        return hotelService.saveHotel(hotel);
    }

    @PutMapping("/hotel_manager/hotel/update")
    public HotelDTO saveHotel( @RequestBody NewHotelDTO hotel, @RequestParam long hotelId){
        return hotelService.updateHotel(hotel, hotelId);
    }

    @PostMapping("/hotel_manager/rooms/new")
    public HotelDTO addRoom(@RequestBody RoomWithoutRelationshipsDTO room, @RequestParam Long hotelId){

        return hotelService.addRoom(room,hotelId);
    }

    @PutMapping("/hotel_manager/rooms/update")
    public HotelDTO updateRoom(@RequestBody RoomWithoutRelationshipsDTO room, @RequestParam Long roomId){

        return hotelService.updateRoom(room, roomId);
    }

    @GetMapping("/hotel_manager/rooms")
    public List<RoomWithBookingsDTO>  getRooms(){
        return hotelService.getRooms();
    }

    @GetMapping("/booker/addresses")
    public List<String> getAddresses(){ return hotelService.getAddresses();}

    @PostMapping("/data")
    public void insertData(){

        hotelService.saveHotel(new NewHotelDTO(1,"4"," <p class=\"ql-align-justify\"><strong>Lorem ipsum dolor sit amet, consectetur adipiscing elit.</strong></p><p class=\"ql-align-justify\"><em>Curabitur in felis sit amet quam</em></p><ul><li class=\"ql-align-justify\"><u> aliquam eleifend sed non ex. In et libero at arcu bibendum efficitur a sed quam. </u>Nunc rutrum eget nisi et dictum. Nunc consequat lacus nunc, ac euismod est bibendum sed. Nullam nibh risus, consequat quis posuere sit amet,<u> a</u>liquet id eros. In diam lorem, vestibulum sit amet egestas sit amet, pellentesque quis justo.</li></ul><p class=\"ql-align-justify\"><br></p><ul><li class=\"ql-align-justify\">it elementum. Sed nulla urna, aliquet at tincidunt vel, imperdiet sed dolor.</li></ul><p class=\"ql-align-justify\"><a href=\"http://localhost:3000/hotelmanager/hotels/Nulla%20libero%20lacus,%20volutpat%20eget%20tincidunt%20sed,%20efficitur%20vel%20tortor.%20Sed%20egestas%20interdum%20enim%20vel%20malesuada.%20Vestibulum%20eu%20accumsan%20orci.%20Maecenas%20mattis,%20augue%20sit%20amet%20dapibus%20malesuada,%20odio%20nisl%20egestas%20sapien,%20eget%20aliquet%20mi%20lacus%20ut%20dolor.%20Nulla%20nibh%20dolor,%20iaculis%20quis%20suscipit%20tincidunt,%20venenatis%20nec%20arcu.%20Vestibulum%20nec%20risus%20volutpat,%20eleifend%20leo%20sed,%20blandit%20lacus.%20Suspendisse%20in%20tellus%20lobortis,%20ultrices%20ante%20et,%20venenatis%20diam.%20Donec%20commodo%20nibh%20at%20est%20tempor,%20ut%20mattis%20lorem%20cursus.\" rel=\"noopener noreferrer\" target=\"_blank\">Nulla libero lacus, volutpat eget tincidunt sed, efficitur vel tortor. Sed egestas interdum enim vel m</a></p><p><br></p>",
                "Hotel Royal Spa", "Netherlands", "Eindhoven", "Marconilaan 124", "Mattis aliquam faucibus purus in massa tempor nec. Et ligula ullamcorper malesuada proin libero nunc consequat interdum varius"));
        hotelService.addRoom(new RoomWithoutRelationshipsDTO("Deluxe Double Bedroom", 2,4,65.00),1);
        hotelService.addRoom(new RoomWithoutRelationshipsDTO("Basic Double Bedroom", 2,3,45.00),1);
        hotelService.addRoom(new RoomWithoutRelationshipsDTO("Singe Bedroom", 2,3,35.00),1);
        hotelService.addRoom(new RoomWithoutRelationshipsDTO("Studio", 2,3,35.00),1);

        hotelService.saveHotel(new NewHotelDTO(1,"3","<p class=\"ql-align-justify\"><strong>Vel risus commodo viverra maecenas accumsan lacus.</strong></p><p class=\"ql-align-justify\"><em>Duis tristique sollicitudin nibh sit.</em></p><ul><li class=\"ql-align-justify\"><u> aliquam eleifend sed non ex. it amet mauris commodo quis imperdiet massa tincidunt nunc pulvinar </u>Nunc rutrum eget nisi et dictum. Nunc consequat lacus nunc, ac euismod est bibendum sed. Nullam nibh risus, consequat quis posuere sit amet,<u> a</u>liquet id eros. In diam lorem, vestibulum sit amet egestas sit amet, pellentesque quis justo.</li></ul><p class=\"ql-align-justify\"><br></p><ul><li class=\"ql-align-justify\">it elementum. Sed nulla urna, aliquet at tincidunt vel, imperdiet sed dolor.</li></ul><p class=\"ql-align-justify\"><a href=\"http://localhost:3000/hotelmanager/hotels/Nulla%20libero%20lacus,%20volutpat%20eget%20tincidunt%20sed,%20efficitur%20vel%20tortor.%20Sed%20egestas%20interdum%20enim%20vel%20malesuada.%20Vestibulum%20eu%20accumsan%20orci.%20Maecenas%20mattis,%20augue%20sit%20amet%20dapibus%20malesuada,%20odio%20nisl%20egestas%20sapien,%20eget%20aliquet%20mi%20lacus%20ut%20dolor.%20Nulla%20nibh%20dolor,%20iaculis%20quis%20suscipit%20tincidunt,%20venenatis%20nec%20arcu.%20Vestibulum%20nec%20risus%20volutpat,%20eleifend%20leo%20sed,%20blandit%20lacus.%20Suspendisse%20in%20tellus%20lobortis,%20ultrices%20ante%20et,%20venenatis%20diam.%20Donec%20commodo%20nibh%20at%20est%20tempor,%20ut%20mattis%20lorem%20cursus.\" rel=\"noopener noreferrer\" target=\"_blank\">Nulla libero lacus, volutpat eget tincidunt sed, efficitur vel tortor. Sed egestas interdum enim vel m</a></p><p><br></p>\n",
                "Little John Hostel", "Netherlands", "Helmond", "Tramstraat 120", " Nibh nisl condimentum id venenatis a condimentum vitae sapien pellentesque. Volutpat consequat mauris nunc congue nisi vitae."));
        hotelService.addRoom(new RoomWithoutRelationshipsDTO("Apartment", 2,4,55.00),2);
        hotelService.addRoom(new RoomWithoutRelationshipsDTO("Bungalow", 2,3,35.00),2);
        hotelService.addRoom(new RoomWithoutRelationshipsDTO("Couples Room", 2,2,25.00),2);
        hotelService.addRoom(new RoomWithoutRelationshipsDTO("Single Room", 1,2,25.00),2);


        hotelService.saveHotel(new NewHotelDTO(1,"5","<p class=\"ql-align-justify\"><strong>Sem et tortor consequat id porta nibh.</strong></p><p class=\"ql-align-justify\"><em>Duis tristique sollicitudin nibh sit.</em></p><ul><li class=\"ql-align-justify\"><u> aliquam eleifend sed non ex. it amet mauris commodo quis imperdiet massa tincidunt nunc pulvinar </u>Nunc rutrum eget nisi et dictum. Nunc consequat lacus nunc, ac euismod est bibendum sed. Nullam nibh risus, consequat quis posuere sit amet,<u> a</u>liquet id eros. In diam lorem, vestibulum sit amet egestas sit amet, pellentesque quis justo.</li></ul><p class=\"ql-align-justify\"><br></p><ul><li class=\"ql-align-justify\">it elementum. Sed nulla urna, aliquet at tincidunt vel, imperdiet sed dolor.</li></ul><p class=\"ql-align-justify\"><a href=\"http://localhost:3000/hotelmanager/hotels/Nulla%20libero%20lacus,%20volutpat%20eget%20tincidunt%20sed,%20efficitur%20vel%20tortor.%20Sed%20egestas%20interdum%20enim%20vel%20malesuada.%20Vestibulum%20eu%20accumsan%20orci.%20Maecenas%20mattis,%20augue%20sit%20amet%20dapibus%20malesuada,%20odio%20nisl%20egestas%20sapien,%20eget%20aliquet%20mi%20lacus%20ut%20dolor.%20Nulla%20nibh%20dolor,%20iaculis%20quis%20suscipit%20tincidunt,%20venenatis%20nec%20arcu.%20Vestibulum%20nec%20risus%20volutpat,%20eleifend%20leo%20sed,%20blandit%20lacus.%20Suspendisse%20in%20tellus%20lobortis,%20ultrices%20ante%20et,%20venenatis%20diam.%20Donec%20commodo%20nibh%20at%20est%20tempor,%20ut%20mattis%20lorem%20cursus.\" rel=\"noopener noreferrer\" target=\"_blank\">Nulla libero lacus, volutpat eget tincidunt sed, efficitur vel tortor. Sed egestas interdum enim vel m</a></p><p><br></p>\n",
                "Heaven Pearl Resort", "Netherlands", "Rotterdam", "Antwerschuz 351", "Nec sagittis aliquam malesuada bibendum arcu vitae. Consectetur adipiscing elit pellentesque habitant morbi tristique senectus et."));
        hotelService.addRoom(new RoomWithoutRelationshipsDTO("Studio", 2,4,95.00),3);
        hotelService.addRoom(new RoomWithoutRelationshipsDTO("Garden House", 2,3,65.00),3);
        hotelService.addRoom(new RoomWithoutRelationshipsDTO("Singe Bedroom", 2,3,45.00),3);


        hotelService.saveHotel(new NewHotelDTO(2,"3","<p class=\"ql-align-justify\"><strong>Vel risus commodo viverra maecenas accumsan lacus.</strong></p><p class=\"ql-align-justify\"><em>Duis tristique sollicitudin nibh sit.</em></p><ul><li class=\"ql-align-justify\"><u> aliquam eleifend sed non ex. it amet mauris commodo quis imperdiet massa tincidunt nunc pulvinar </u>Nunc rutrum eget nisi et dictum. Nunc consequat lacus nunc, ac euismod est bibendum sed. Nullam nibh risus, consequat quis posuere sit amet,<u> a</u>liquet id eros. In diam lorem, vestibulum sit amet egestas sit amet, pellentesque quis justo.</li></ul><p class=\"ql-align-justify\"><br></p><ul><li class=\"ql-align-justify\">it elementum. Sed nulla urna, aliquet at tincidunt vel, imperdiet sed dolor.</li></ul><p class=\"ql-align-justify\"><a href=\"http://localhost:3000/hotelmanager/hotels/Nulla%20libero%20lacus,%20volutpat%20eget%20tincidunt%20sed,%20efficitur%20vel%20tortor.%20Sed%20egestas%20interdum%20enim%20vel%20malesuada.%20Vestibulum%20eu%20accumsan%20orci.%20Maecenas%20mattis,%20augue%20sit%20amet%20dapibus%20malesuada,%20odio%20nisl%20egestas%20sapien,%20eget%20aliquet%20mi%20lacus%20ut%20dolor.%20Nulla%20nibh%20dolor,%20iaculis%20quis%20suscipit%20tincidunt,%20venenatis%20nec%20arcu.%20Vestibulum%20nec%20risus%20volutpat,%20eleifend%20leo%20sed,%20blandit%20lacus.%20Suspendisse%20in%20tellus%20lobortis,%20ultrices%20ante%20et,%20venenatis%20diam.%20Donec%20commodo%20nibh%20at%20est%20tempor,%20ut%20mattis%20lorem%20cursus.\" rel=\"noopener noreferrer\" target=\"_blank\">Nulla libero lacus, volutpat eget tincidunt sed, efficitur vel tortor. Sed egestas interdum enim vel m</a></p><p><br></p>\n",
                "Berlin Golf & Spa", "Germany", "Berlin", "Schneiderstreet 91", "Id volutpat lacus laoreet mut sem nulla pharetra vitae. Consectetur adipiscing elit pellentesque habitant morbi tristique senectus et."));
        hotelService.addRoom(new RoomWithoutRelationshipsDTO("King Apartment", 2,4,70.00),4);
        hotelService.addRoom(new RoomWithoutRelationshipsDTO("Double Bedroom", 2,3,60.00),4);
        hotelService.addRoom(new RoomWithoutRelationshipsDTO("Singe Bedroom", 1,3,45.00),4);

        hotelService.saveHotel(new NewHotelDTO(2,"4"," <p class=\"ql-align-justify\"><strong>Sem et tortor consequat id porta nibh.</strong></p><p class=\"ql-align-justify\"><em>Duis tristique sollicitudin nibh sit.</em></p><ul><li class=\"ql-align-justify\"><u> aliquam eleifend sed non ex. it amet mauris commodo quis imperdiet massa tincidunt nunc pulvinar </u>Nunc rutrum eget nisi et dictum. Nunc consequat lacus nunc, ac euismod est bibendum sed. Nullam nibh risus, consequat quis posuere sit amet,<u> a</u>liquet id eros. In diam lorem, vestibulum sit amet egestas sit amet, pellentesque quis justo.</li></ul><p class=\"ql-align-justify\"><br></p><ul><li class=\"ql-align-justify\">it elementum. Sed nulla urna, aliquet at tincidunt vel, imperdiet sed dolor.</li></ul><p class=\"ql-align-justify\"><a href=\"http://localhost:3000/hotelmanager/hotels/Nulla%20libero%20lacus,%20volutpat%20eget%20tincidunt%20sed,%20efficitur%20vel%20tortor.%20Sed%20egestas%20interdum%20enim%20vel%20malesuada.%20Vestibulum%20eu%20accumsan%20orci.%20Maecenas%20mattis,%20augue%20sit%20amet%20dapibus%20malesuada,%20odio%20nisl%20egestas%20sapien,%20eget%20aliquet%20mi%20lacus%20ut%20dolor.%20Nulla%20nibh%20dolor,%20iaculis%20quis%20suscipit%20tincidunt,%20venenatis%20nec%20arcu.%20Vestibulum%20nec%20risus%20volutpat,%20eleifend%20leo%20sed,%20blandit%20lacus.%20Suspendisse%20in%20tellus%20lobortis,%20ultrices%20ante%20et,%20venenatis%20diam.%20Donec%20commodo%20nibh%20at%20est%20tempor,%20ut%20mattis%20lorem%20cursus.\" rel=\"noopener noreferrer\" target=\"_blank\">Nulla libero lacus, volutpat eget tincidunt sed, efficitur vel tortor. Sed egestas interdum enim vel m</a></p><p><br></p>\n",
                "Munich Top Resort", "Germany", "Munich", "Remstraat 211", "Egestas tellus rutrum tellus pellentesque eu tincidunt tortor aliquam nulla. Adipiscing enim eu turpis egestas pretium aenean."));
        hotelService.addRoom(new RoomWithoutRelationshipsDTO("Bungalow", 2,4,65.00),5);
        hotelService.addRoom(new RoomWithoutRelationshipsDTO("Studio", 2,3,45.00),5);
        hotelService.addRoom(new RoomWithoutRelationshipsDTO("Singe Bedroom", 1,3,35.00),5);

        hotelService.saveHotel(new NewHotelDTO(2,"5"," <p class=\"ql-align-justify\"><strong>Consequat semper viverra nam libero justo laoreet sit.</strong></p><p class=\"ql-align-justify\"><em>Duis tristique sollicitudin nibh sit.</em></p><ul><li class=\"ql-align-justify\"><u> aliquam eleifend sed non ex. It aliquet nibh praesent tristique magna sit. Sit amet mattis vulputate enim </u>Nunc rutrum eget nisi et dictum. Nunc consequat lacus nunc, ac euismod est bibendum sed. Nullam nibh risus, consequat quis posuere sit amet,<u> a</u>liquet id eros. In diam lorem, vestibulum sit amet egestas sit amet, pellentesque quis justo.</li></ul><p class=\"ql-align-justify\"><br></p><ul><li class=\"ql-align-justify\">it elementum. Sed nulla urna, aliquet at tincidunt vel, imperdiet sed dolor.</li></ul><p class=\"ql-align-justify\"><a href=\"http://localhost:3000/hotelmanager/hotels/Nulla%20libero%20lacus,%20volutpat%20eget%20tincidunt%20sed,%20efficitur%20vel%20tortor.%20Sed%20egestas%20interdum%20enim%20vel%20malesuada.%20Vestibulum%20eu%20accumsan%20orci.%20Maecenas%20mattis,%20augue%20sit%20amet%20dapibus%20malesuada,%20odio%20nisl%20egestas%20sapien,%20eget%20aliquet%20mi%20lacus%20ut%20dolor.%20Nulla%20nibh%20dolor,%20iaculis%20quis%20suscipit%20tincidunt,%20venenatis%20nec%20arcu.%20Vestibulum%20nec%20risus%20volutpat,%20eleifend%20leo%20sed,%20blandit%20lacus.%20Suspendisse%20in%20tellus%20lobortis,%20ultrices%20ante%20et,%20venenatis%20diam.%20Donec%20commodo%20nibh%20at%20est%20tempor,%20ut%20mattis%20lorem%20cursus.\" rel=\"noopener noreferrer\" target=\"_blank\">Nulla libero lacus, volutpat eget tincidunt sed, efficitur vel tortor. Sed egestas interdum enim vel m</a></p><p><br></p>\n",
                "Paradise Hotel & Casino", "Germany", "Frankfurt", "Gagelstraat 21", "Cras fermentum odio eu feugiat pretium nibh ipsum consequat. Egestas dui id ornare arcu odio ut sem."));
        hotelService.addRoom(new RoomWithoutRelationshipsDTO("VIP Apartment", 2,4,330.00),6);
        hotelService.addRoom(new RoomWithoutRelationshipsDTO("Luxury Double Bedroom", 2,3,205.00),6);
        hotelService.addRoom(new RoomWithoutRelationshipsDTO("Single Bedroom", 1,3,135.00),6);

    }

    @PostMapping("/generate-bookings")
    public List<HotelDTO> data() throws ParseException {
        bookingService.generateBookings();
        return hotelService.getHotelsByManagerId(2L);
    }

}
