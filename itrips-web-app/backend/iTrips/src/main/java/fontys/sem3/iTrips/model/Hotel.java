package fontys.sem3.iTrips.model;

import fontys.sem3.iTrips.util.overview.dto.HotelOverviewDTO;
import fontys.sem3.iTrips.util.overview.dto.RoomOverviewDTO;
import lombok.*;
import javax.persistence.*;
import java.util.*;


@AllArgsConstructor
@NoArgsConstructor
@Entity @Table(name="hotel") @Getter @Setter
public class Hotel {

    @Id @SequenceGenerator(name="hotel_sequence",sequenceName="hotel_sequence",allocationSize = 1)
    @GeneratedValue(strategy = GenerationType.SEQUENCE, generator = "hotel_sequence")
    private Long id;

    private String name;
    @Column(length=100000000)
    private String description;
    private String country;
    private String city;
    private String street;
    private String stars;
    @Column(length=1000000)
    private String caption;

    @ManyToOne
    private User manager;

    @OneToMany(mappedBy = "hotel")
    private List<Room> rooms = new ArrayList<>();

    public HotelOverviewDTO getOverviewData(boolean price){

        double weeklyRevenue = 0;
        double monthlyRevenue = 0;
        double totalSum = 0;
        double[] sums = new double[12];
        for(Room room : rooms) {
        RoomOverviewDTO overview = room.getOverviewData(price);
         weeklyRevenue += overview.getWeeklyRevenue();
         monthlyRevenue += overview.getMonthlyRevenue();
         totalSum += overview.getTotalSum();

         double[]  roomSums = overview.getMonthlySums();
            for(int i = 0; i<roomSums.length;i++){
                sums[i] +=roomSums[i];
            }

        }
        return new HotelOverviewDTO(weeklyRevenue,monthlyRevenue,totalSum,sums);
    }
/*
    public double[] getRevenuesByMonths() {
        double[] revenues = new double[12];
        for(Room room: rooms){
           double[]  roomRevenues = room.getRevenuesForMonths();
          for(int i = 0; i<roomRevenues.length;i++){
              revenues[i] +=roomRevenues[i];
          }
        }
        return revenues;
    }*/

}
