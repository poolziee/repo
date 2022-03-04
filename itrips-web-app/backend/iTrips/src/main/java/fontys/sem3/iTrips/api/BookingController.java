package fontys.sem3.iTrips.api;

import fontys.sem3.iTrips.dto.booking.BookingDTO;
import fontys.sem3.iTrips.dto.booking.NewBookingDTO;
import fontys.sem3.iTrips.dto.hotel.HotelOfferDTO;
import fontys.sem3.iTrips.model.Booking;
import fontys.sem3.iTrips.service.BookingService;
import lombok.AllArgsConstructor;
import lombok.extern.slf4j.Slf4j;
import org.springframework.web.bind.annotation.*;

import java.awt.print.Book;
import java.text.ParseException;
import java.util.List;

@RestController
@Slf4j
@AllArgsConstructor
@RequestMapping("/api")
public class BookingController {

    private final BookingService bookingService;

    @GetMapping("/bookings")
    public List<BookingDTO> getBookings(){
        return bookingService.getBookingDTOs();
    }

    @GetMapping("/booking/{bookingId}")
    public BookingDTO getBooking(@PathVariable Long bookingId){
        return bookingService.getBookingDTO(bookingId);
    }

    @PostMapping("/booker/booking/save")
    public BookingDTO saveBooking(@RequestBody NewBookingDTO booking) throws ParseException {
        return bookingService.saveBooking(booking);
    }

    @GetMapping("/booker/bookings-by-user")
    public List<BookingDTO> getBookingsByUser(@RequestParam long id) {
        return bookingService.getBookingsByUser(id);
    }

    @GetMapping("/booker/get_offers")
    public List<HotelOfferDTO> getOffers(@RequestParam String location, @RequestParam String checkinString, @RequestParam String checkoutString, @RequestParam int guests) throws ParseException {
        return bookingService.getOffers(location,checkinString,checkoutString,guests);
    }


    @DeleteMapping("/booker/delete-booking")
    public boolean deleteBooking(@RequestParam Long bookingId){
         return bookingService.deleteBooking(bookingId);
    }

}
