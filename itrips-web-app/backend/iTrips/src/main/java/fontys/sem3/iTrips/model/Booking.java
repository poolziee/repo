package fontys.sem3.iTrips.model;


import com.fasterxml.jackson.annotation.JsonIgnore;
import lombok.AllArgsConstructor;
import lombok.Getter;
import lombok.NoArgsConstructor;
import lombok.Setter;

import javax.persistence.*;
import java.sql.Date;
import java.util.ArrayList;
import java.util.List;

@AllArgsConstructor
@NoArgsConstructor
@Entity @Table(name="booking") @Getter @Setter
public class Booking {

    @Id @SequenceGenerator(name="booking_sequence",sequenceName="booking_sequence",allocationSize = 1)
    @GeneratedValue(strategy = GenerationType.SEQUENCE, generator = "booking_sequence")
    private Long id;
    private double price;

    @ManyToOne
    @JoinColumn(name="user_id", referencedColumnName = "id")
    private User user;

    @ManyToOne
    @JoinColumn(name="room_id", referencedColumnName = "id")
    private Room room;

    private Date checkin;
    private Date checkout;
}
