package fontys.sem3.iTrips.util.overview;

import lombok.AllArgsConstructor;
import lombok.Data;

import java.util.ArrayList;
import java.util.List;

@Data
@AllArgsConstructor
public class EntitiesYearlySumsData {

    private List<String> months = new ArrayList<>();
    private List<EntityYearlyDataSum> series = new ArrayList<>();

}
