package fontys.sem3.iTrips.repo;


import fontys.sem3.iTrips.model.Booking;
import fontys.sem3.iTrips.model.User;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;

import java.util.List;

public interface BookingRepo extends JpaRepository<Booking,Long> {


     @Query(nativeQuery = true, value = "select * from booking" +
             "             where user_id = :userId" +
             "             order by checkin desc")
     List<Booking> findAllByUserId(@Param("userId") long userId);

     @Query(nativeQuery = true, value = "select b.* from booking b inner join " +
             "room r on b.room_id = r.id inner join hotel h on h.id = r.hotel_id " +
             "where h.manager_id = :managerId && b.checkin <= CURDATE() " +
             "order by b.checkin desc limit 5;")
     List<Booking> getLatestBookings(@Param("managerId") long managerId);
}
