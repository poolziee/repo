package fontys.sem3.iTrips.util.overview.dto;

import lombok.AllArgsConstructor;
import lombok.Data;

@Data
@AllArgsConstructor
public class HotelOverviewDTO {
    double weeklyRevenue;
    double monthlyRevenue;
    double totalSum;
    double[] sums;
}