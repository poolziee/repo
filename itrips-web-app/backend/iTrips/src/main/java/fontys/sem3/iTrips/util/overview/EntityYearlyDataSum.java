package fontys.sem3.iTrips.util.overview;

import lombok.AllArgsConstructor;
import lombok.Data;

import java.util.stream.DoubleStream;

@Data
@AllArgsConstructor
public class EntityYearlyDataSum implements Comparable<EntityYearlyDataSum> {
    private String name;
    double[] data;

    @Override
    public int compareTo(EntityYearlyDataSum o) {
       Double sum = DoubleStream.of(getData()).sum();
       Double oSum = DoubleStream.of(o.getData()).sum();
       return sum.compareTo(oSum);
    }
}
