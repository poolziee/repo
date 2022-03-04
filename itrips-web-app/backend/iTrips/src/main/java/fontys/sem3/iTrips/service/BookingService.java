package fontys.sem3.iTrips.service;

import fontys.sem3.iTrips._mapper.BookingMapper;
import fontys.sem3.iTrips.dto.booking.BookingDTO;
import fontys.sem3.iTrips.dto.booking.NewBookingDTO;
import fontys.sem3.iTrips.dto.hotel.HotelOfferDTO;
import fontys.sem3.iTrips.dto.room.RoomOfferDTO;
import fontys.sem3.iTrips.model.Booking;
import fontys.sem3.iTrips.model.Hotel;
import fontys.sem3.iTrips.model.Room;
import fontys.sem3.iTrips.model.User;
import fontys.sem3.iTrips.repo.BookingRepo;
import fontys.sem3.iTrips.serviceInterfaces.IHotelServiceBooking;
import fontys.sem3.iTrips.serviceInterfaces.ILatestBookingsAccessible;
import fontys.sem3.iTrips.serviceInterfaces.IUserByIdAccessible;
import lombok.extern.slf4j.Slf4j;
import org.joda.time.DateTime;
import org.joda.time.Interval;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import java.sql.Date;
import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.time.Instant;
import java.time.LocalDate;
import java.time.ZoneId;
import java.time.temporal.ChronoUnit;
import java.util.*;
import java.util.concurrent.ThreadLocalRandom;

import static java.time.temporal.TemporalAdjusters.firstDayOfMonth;
import static java.time.temporal.TemporalAdjusters.lastDayOfMonth;
import static java.util.Calendar.getInstance;

@Service
@Slf4j
public class BookingService implements ILatestBookingsAccessible {

    @Autowired
    public BookingService(BookingMapper bookingMapper, BookingRepo bookingRepo, IUserByIdAccessible userService, IHotelServiceBooking hotelService) {
        this.bookingMapper = bookingMapper;
        this.bookingRepo = bookingRepo;
        this.userService = userService;
        this.hotelService = hotelService;
        this.sdf1 = new SimpleDateFormat("MM/dd/yyyy");
    }

    private final BookingMapper bookingMapper;
    private final BookingRepo bookingRepo;
    private final IUserByIdAccessible userService;
    private final IHotelServiceBooking hotelService;
    private  final SimpleDateFormat sdf1;

    public List<BookingDTO> getLatestBookings(Long managerId) {
       return bookingMapper.toBookingDTOs(bookingRepo.getLatestBookings(managerId));
    }

    public boolean deleteBooking(Long bookingId) {
        Booking booking = bookingRepo.getById(bookingId);
        bookingRepo.delete(booking);
        return true;
    }

    public List<Long> getUserIdsByRole(String role) {
        List<Long> ids = new ArrayList<>();
        for(User user : userService.getUsers()) {
            if(user.getRoles().stream().anyMatch(r -> r.getName().equals(role))) {
                ids.add(user.getId());
            }
        }
        Collections.shuffle(ids);
        return ids;
    }



    public List<BookingDTO> getBookingsByUser(long id){
        List<Booking> bookings = bookingRepo.findAllByUserId(id);
        return bookingMapper.toBookingDTOs(bookings);
    }

    public List<HotelOfferDTO> getOffers(String location, String checkinString, String checkoutString, int guests) throws ParseException {
        Date checkin =  new Date(sdf1.parse(checkinString).getTime());
        Date checkout = new Date(sdf1.parse(checkoutString).getTime());
        List<Hotel> hotels = hotelService.getAll();
        List<HotelOfferDTO> hotelOffers = new ArrayList<>();

        for(Hotel hotel : hotels) {
            boolean available = false;
            double totalPrice = 0;
            double totalNights = 0;
            double nightlyPrice = 0;
            int bookings = 0;
            String address = "";

            String comb = hotel.getCity() + ", " + hotel.getCountry();
            if(Objects.equals(hotel.getCountry(), location) || Objects.equals(comb, location)){

                List<RoomOfferDTO> roomOffers = new ArrayList<>();

                for(Room room : hotel.getRooms()) {
                    RoomOfferDTO roomOffer = getRoomOffer(checkin,checkout,room);
                    roomOffers.add(roomOffer);
                    bookings += roomOffer.getBookings();

                    if(!available && roomOffer.getOffers_left() > 0 && roomOffer.getSleeps() == guests){
                        available = true;
                        totalPrice = roomOffer.getTotal_price();
                        totalNights = roomOffer.getTotalNights();
                        nightlyPrice = roomOffer.getNightly_price();
                        address = hotel.getCountry() + ", " + hotel.getCity() + ", " + hotel.getStreet();
                    }
                } if(available){
                    HotelOfferDTO hotelOffer = new HotelOfferDTO(hotel.getId(),hotel.getName(),hotel.getCaption(),hotel.getDescription(),hotel.getStars(),
                            totalPrice,totalNights,nightlyPrice,bookings,address,guests,roomOffers,checkinString,checkoutString);
                    hotelOffers.add(hotelOffer);
                }
            }
        }
        return hotelOffers;
    }

    public RoomOfferDTO getRoomOffer(Date start, Date end, Room room) {

        DateTime checkin = new DateTime(start.getTime());
        DateTime checkout = new DateTime(end.getTime());
        Interval duration = new Interval(checkin, checkout);
     /*   long diff = end.getTime() - start.getTime();*/
        long totalNights =ChronoUnit.DAYS.between(start.toLocalDate(),end.toLocalDate());
        int space = room.getTotal();
        int count = 0;
        for(Booking booking : room.getBookings()){
            Interval booked = new Interval(new DateTime(booking.getCheckin().getTime()), new DateTime(booking.getCheckout().getTime()));

            if(duration.overlaps(booked)){
                count++;
            }
        }
        long id = room.getId();
        String type = room.getType();
        int sleeps = room.getSleeps();
        int bookings = room.getBookings().size();
        int offersLeft = space - count;
        double nightlyPrice = room.getPrice();
        double totalPrice = totalNights * nightlyPrice;
        String status = "";
        if(offersLeft <= 2){
            status = "red";
        } else if(offersLeft > 5){
            status = "green";
        } else {
            status="yellow";
        }
        return new RoomOfferDTO(id,type,sleeps,bookings,offersLeft,status,nightlyPrice,totalPrice, totalNights);
    }


    public BookingDTO saveBooking(NewBookingDTO newBooking) throws ParseException {

         Room room = hotelService.getRoomById(newBooking.getRoomId());
         Date checkin =  new Date(sdf1.parse(newBooking.getCheckinString()).getTime());
         Date checkout = new Date(sdf1.parse(newBooking.getCheckoutString()).getTime());

        if(bookingAvailable(checkin,checkout, room)){
            Booking booking = bookingRepo.save(new Booking());
            booking.setCheckin(checkin);
            booking.setCheckout(checkout);
            booking.setPrice(newBooking.getPrice());
            booking.setRoom(room);
            booking.setUser(userService.getUserById(newBooking.getUserId()));
            return bookingMapper.toBookingDTO(bookingRepo.save(booking));
        }
        return null;
    }

    public boolean bookingAvailable(Date start, Date end, Room room){
        DateTime checkin = new DateTime(start.getTime());
        DateTime checkout = new DateTime(end.getTime());
        Interval duration = new Interval(checkin, checkout);
        int space = room.getTotal();
        int count = 0;
        for(Booking booking : room.getBookings()){
            Interval booked = new Interval(new DateTime(booking.getCheckin().getTime()), new DateTime(booking.getCheckout().getTime()));

            log.info("new: " + new Date(start.getTime()) + " --- "+ new Date(end.getTime()));
            log.info("existing: " +  new Date(booking.getCheckin().getTime()) + " --- "+ new Date(booking.getCheckout().getTime()));
            if(duration.overlaps(booked)){
                count++;
                log.info("found overlapping dates number: " + count);
            } else{
                log.info("no overlap");
            }
            log.info("==================================================================================");

        }
        return count < space;
    }
    public List<BookingDTO> getBookingDTOs(){
        List<Booking> bookings = bookingRepo.findAll();
        return bookingMapper.toBookingDTOs(bookings);
    }

    public BookingDTO getBookingDTO(Long bookingId){
        return bookingMapper.toBookingDTO(bookingRepo.getById(bookingId));
    }

    //AUTO GENERATE DATA
    public void generateBookings() throws ParseException {
        List<Hotel> hotels = hotelService.getAll();
        for(Hotel hotel : hotels) {
            generateYearlyBookingsForHotel(hotel);
        }
    }

    private void generateYearlyBookingsForHotel(Hotel hotel) throws ParseException {

        long janMil  =new GregorianCalendar(2021, Calendar.JANUARY, 1).getTime().getTime();
        long nextJanMil = new  GregorianCalendar(2022, Calendar.JANUARY, 31).getTime().getTime();
        LocalDate jan = Instant.ofEpochMilli(janMil).atZone(ZoneId.systemDefault()).toLocalDate();
        LocalDate nextJan = Instant.ofEpochMilli(nextJanMil).atZone(ZoneId.systemDefault()).toLocalDate();

        for(LocalDate date = jan; date.isBefore(nextJan); date = date.plusMonths(1)) {

            LocalDate first = date.with(firstDayOfMonth());
            LocalDate last =first.with(lastDayOfMonth());
            long firstMil = first.atStartOfDay(ZoneId.systemDefault()).toInstant().toEpochMilli();
            long lastMil = last.atStartOfDay(ZoneId.systemDefault()).toInstant().toEpochMilli();
            //GENERATE BOOKINGS FOR CHOSEN MONTHS
            generateMonthlyBookingsForHotel(hotel, firstMil, lastMil);
            log.info("finished month: " + date.getMonth());
        }
    }

    public void generateMonthlyBookingsForHotel(Hotel hotel, long startMil, long endMil) throws ParseException {

        List<Room> rooms = hotel.getRooms();
        for(Room room : rooms){
            Random randCount = new Random();
            int end = randCount.nextInt(5) + 1;
            int bookings = 0;
            while(bookings < end) {
                Random randUser = new Random();
                Random randRoom = new Random();
                List<Long> bookerIds = getUserIdsByRole("ROLE_BOOKER");
                Collections.shuffle(bookerIds);
                Long bookerId = bookerIds.get(randUser.nextInt(bookerIds.size()));

            /*    java.util.Date jan  =new GregorianCalendar(2022, Calendar.JANUARY, 1).getTime();
                java.util.Date dec = new GregorianCalendar(2022, Calendar.DECEMBER, 31).getTime();*/

                Date checkin = new Date(ThreadLocalRandom.current().nextLong(startMil,endMil));
                Date checkoutEnd = new Date((new DateTime(checkin)).plusDays(10).toDate().getTime());
                Date checkoutStart = new Date((new DateTime(checkin)).plusDays(1).toDate().getTime());
                Date checkout = new Date(ThreadLocalRandom.current().nextLong(checkoutStart.getTime(),checkoutEnd.getTime()));

                /*   long diff = checkout.getTime() - checkin.getTime();*/
                long totalNights = ChronoUnit.DAYS.between(checkin.toLocalDate(),checkout.toLocalDate());
                double totalPrice = totalNights * room.getPrice();
                String checkinString = sdf1.format(checkin.getTime());
                String checkoutString  = sdf1.format(checkout.getTime());

                if(bookingAvailable(checkin,checkout,room)){
                    List<Booking> temp = room.getBookings();
                    BookingDTO saved = saveBooking(new NewBookingDTO(totalPrice,bookerId,room.getId(),checkinString,checkoutString));
                    temp.add(bookingRepo.getById(saved.getId()));
                    room.setBookings(temp);
                    bookings++;
                }
            }
        }
        hotel.setRooms(rooms);
    }
}
