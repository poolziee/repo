package fontys.sem3.iTrips.util.overview;

import fontys.sem3.iTrips.dto.booking.BookingDTO;
import fontys.sem3.iTrips.util.overview.dto.Revenue;
import lombok.AllArgsConstructor;
import lombok.Data;

import java.util.List;

@Data
@AllArgsConstructor
public class OverviewData {
    private TotalSumData entitiesTotalSums;
    private EntitiesYearlySumsData yearlySumsData;
    private Revenue weeklyRevenue;
    private Revenue monthlyRevenue;
    private List<BookingDTO> latestBookings;
}
