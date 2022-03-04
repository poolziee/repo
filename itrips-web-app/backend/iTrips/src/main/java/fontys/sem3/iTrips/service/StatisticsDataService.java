package fontys.sem3.iTrips.service;

import fontys.sem3.iTrips.dto.booking.BookingDTO;
import fontys.sem3.iTrips.model.Hotel;
import fontys.sem3.iTrips.model.Room;
import fontys.sem3.iTrips.serviceInterfaces.IHotelServiceBooking;
import fontys.sem3.iTrips.serviceInterfaces.ILatestBookingsAccessible;
import fontys.sem3.iTrips.util.overview.*;
import fontys.sem3.iTrips.util.overview.dto.HotelOverviewDTO;
import fontys.sem3.iTrips.util.overview.dto.Revenue;
import fontys.sem3.iTrips.util.overview.dto.RoomOverviewDTO;
import lombok.extern.slf4j.Slf4j;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import java.text.SimpleDateFormat;
import java.util.*;

@Service
@Slf4j
public class StatisticsDataService {

    private final IHotelServiceBooking service;
    private final ILatestBookingsAccessible bookingService;

    @Autowired
    public StatisticsDataService(IHotelServiceBooking service, ILatestBookingsAccessible bookingService) {
        this.service = service;
        this.bookingService = bookingService;
    }

    public EntitiesYearlySumsData getRoomsData(String hotelName, Long managerId) {
        if(!hotelName.equals(" ")){
            Hotel hotel = service.getByName(hotelName);
            List<Room> rooms = hotel.getRooms();
            List<EntityYearlyDataSum> data = new ArrayList<>();
            for(Room room : rooms){
                RoomOverviewDTO dto = room.getOverviewData(false);
                EntityYearlyDataSum yearlyDataSum = new EntityYearlyDataSum(room.getType(),dto.getMonthlySums());
                data.add(yearlyDataSum);
            }
            Collections.sort(data);
            Collections.reverse(data);
            return new EntitiesYearlySumsData(DatesHelper.getPrevious12MonthsStrings(),data);
        }
        return getOverviewData(managerId,false).getYearlySumsData();
    }

    //MAIN METHODS

    public OverviewData getOverviewData(Long managerId, boolean price) {
        List<BookingDTO> latestBookings = new ArrayList<>();
        List<Hotel> hotels = service.getByManagerId(managerId);
         double weeklyEarnings = 0;
         double monthlyEarnings = 0;
         double totalSum = 0;
         List<EntityYearlyDataSum> hotelMonthlyData = new ArrayList<>();
         List<EntityTotalSumData> entityTotalSumData = new ArrayList<>();
         for(Hotel hotel :hotels){
            HotelOverviewDTO hotelData = hotel.getOverviewData(price);
             weeklyEarnings += hotelData.getWeeklyRevenue();
             monthlyEarnings += hotelData.getMonthlyRevenue();
             totalSum += hotelData.getTotalSum();
             hotelMonthlyData.add(new EntityYearlyDataSum(hotel.getName(),  hotelData.getSums()));
             entityTotalSumData.add(new EntityTotalSumData(hotel.getName(), hotelData.getTotalSum()));
         }
         entityTotalSumData.sort(Comparator.comparingDouble(EntityTotalSumData::getSum));
         Collections.reverse(entityTotalSumData);
         Collections.sort(hotelMonthlyData);
         Collections.reverse(hotelMonthlyData);

        SimpleDateFormat sdf1 = new SimpleDateFormat("MM.dd");
        Calendar cal = Calendar.getInstance( TimeZone.getTimeZone("Europe/London"));
        cal.set(Calendar.HOUR_OF_DAY, 0); // ! clear would not reset the hour of day !
        cal.clear(Calendar.MINUTE);
        cal.clear(Calendar.SECOND);
        cal.clear(Calendar.MILLISECOND);
         String weekFrom = sdf1.format(DatesHelper.getFirstDayOfCurrentWeek());
        String weekUntil = sdf1.format(cal.getTime());
        String monthFrom = sdf1.format(DatesHelper.getFirstDayOfCurrentMonth());
        String monthUntil = sdf1.format(cal.getTime());

        EntitiesYearlySumsData yearlyData = new EntitiesYearlySumsData(DatesHelper.getPrevious12MonthsStrings(),hotelMonthlyData);
        TotalSumData hotelsTotalSumData = new TotalSumData(totalSum, entityTotalSumData);

        if(price) {
            Revenue weeklyRevenue = new Revenue(weeklyEarnings, weekFrom,weekUntil);
            Revenue monthlyRevenue = new Revenue(monthlyEarnings, monthFrom, monthUntil);
            latestBookings = bookingService.getLatestBookings(managerId);
            return new OverviewData(hotelsTotalSumData,yearlyData,weeklyRevenue,monthlyRevenue,latestBookings) ;
        }
        return new OverviewData(hotelsTotalSumData, yearlyData,null,null,null);
    }

    //HELPING METHODS

}
