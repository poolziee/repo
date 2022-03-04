package fontys.sem3.iTrips.util.overview;

import lombok.AllArgsConstructor;
import lombok.Data;

import java.util.ArrayList;
import java.util.List;

@Data
@AllArgsConstructor
public class TotalSumData {
    private double totalSum;
    private List<EntityTotalSumData> entities = new ArrayList<>();

}
