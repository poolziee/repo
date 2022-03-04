package fontys.sem3.iTrips.model;



import com.fasterxml.jackson.annotation.JsonIgnore;
import fontys.sem3.iTrips.service.DatesHelper;
import fontys.sem3.iTrips.util.overview.dto.RoomOverviewDTO;
import lombok.AllArgsConstructor;
import lombok.Getter;
import lombok.NoArgsConstructor;
import lombok.Setter;
import javax.persistence.*;
import java.time.LocalDate;
import java.time.YearMonth;
import java.util.*;

@AllArgsConstructor
@NoArgsConstructor
@Entity @Table(name ="room") @Getter @Setter
public class Room {

    @Id
    @SequenceGenerator(name="room_sequence",sequenceName="room_sequence",allocationSize = 1) @GeneratedValue(strategy = GenerationType.SEQUENCE, generator = "room_sequence")
    private Long id;
    private String type;

    @JsonIgnore
    @ManyToOne(cascade = CascadeType.ALL)
    @JoinColumn(name="hotel_id", referencedColumnName = "id")
    private Hotel hotel;

    @JsonIgnore
    @OneToMany(mappedBy = "room")
    private List<Booking> bookings = new ArrayList<>();
    private int sleeps;
    private int total;
    private double price;


  public RoomOverviewDTO getOverviewData(boolean price){

      double weeklyRevenue = 0;
      double monthlyRevenue = 0;
      double totalSum = 0;
      double[] monthlyRev = new double[12];
      int count = 0;
      for(Booking booking : bookings) {
          if(DatesHelper.dateIsAddable( new Date(booking.getCheckin().getTime()))) {
              count++;
              double sum = price ? booking.getPrice() : count;
              int bookingMonthIndex = DatesHelper.getMonthIndex(new Date(booking.getCheckin().getTime()));
              monthlyRev[bookingMonthIndex] += sum;

              //GET OTHER REVENUE
              totalSum += sum;

              if(price) {
                  YearMonth currentMonth = YearMonth.now();
                  LocalDate checkin = booking.getCheckin().toLocalDate();
                  if(currentMonth.equals(YearMonth.from(checkin))){
                      monthlyRevenue +=  sum;

                  }
                  if(DatesHelper.dateIsInSameWeek(booking.getCheckin().getTime())){
                      weeklyRevenue += sum;
                  }
              }
          }
      }
      int currentMontIndex = DatesHelper.getCurrentMontIndex();

      double[] ordered = new double[12];
      ordered[11] = monthlyRev[currentMontIndex];
      int x = 1;
      for(int i = currentMontIndex +1; i!=currentMontIndex; i = ++i%12){
          ordered[11 -x] = monthlyRev[i];
          x++;
      }
      return new RoomOverviewDTO(weeklyRevenue,monthlyRevenue,totalSum,ordered);
  }

}
