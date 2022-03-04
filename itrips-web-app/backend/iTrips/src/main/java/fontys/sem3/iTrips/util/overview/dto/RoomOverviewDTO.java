package fontys.sem3.iTrips.util.overview.dto;

import fontys.sem3.iTrips.dto.booking.BookingDTO;
import fontys.sem3.iTrips.model.Booking;
import lombok.AllArgsConstructor;
import lombok.Data;

import java.util.HashMap;
import java.util.List;

@Data
@AllArgsConstructor
public class RoomOverviewDTO {
   double weeklyRevenue;
   double monthlyRevenue;
   double totalSum;
   double[] monthlySums;
}
