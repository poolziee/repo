package fontys.sem3.iTrips.util.overview.dto;

import lombok.AllArgsConstructor;
import lombok.Data;

import java.util.Date;

@Data
@AllArgsConstructor
public class Revenue {
    private double revenue;
    private String from;
    private String until;
}
