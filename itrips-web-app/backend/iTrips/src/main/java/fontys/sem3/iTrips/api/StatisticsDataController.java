package fontys.sem3.iTrips.api;

import fontys.sem3.iTrips.service.StatisticsDataService;
import fontys.sem3.iTrips.util.overview.EntitiesYearlySumsData;
import fontys.sem3.iTrips.util.overview.EntityYearlyDataSum;
import fontys.sem3.iTrips.util.overview.OverviewData;
import lombok.AllArgsConstructor;
import lombok.extern.slf4j.Slf4j;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestParam;
import org.springframework.web.bind.annotation.RestController;

@RestController
@Slf4j
@AllArgsConstructor
@RequestMapping("/api")
public class StatisticsDataController {

    private final StatisticsDataService service;

    @GetMapping("/hotel_manager/overview-statistics")
    public OverviewData getOverviewData(@RequestParam long managerId){
    return service.getOverviewData(managerId, true);
    }

    @GetMapping("/hotel_manager/analytics-statistics")
    public OverviewData getAnalysisData(@RequestParam long managerId){
        return service.getOverviewData(managerId, false);
    }

    @GetMapping("hotel_manager/analytics-statistics/hotel")
    public EntitiesYearlySumsData analysisRoomData(@RequestParam String hotelName, @RequestParam Long managerId){
        return service.getRoomsData(hotelName, managerId);
    }
}
