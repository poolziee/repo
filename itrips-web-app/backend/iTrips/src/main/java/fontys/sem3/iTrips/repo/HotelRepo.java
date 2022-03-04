package fontys.sem3.iTrips.repo;

import fontys.sem3.iTrips.model.Hotel;
import fontys.sem3.iTrips.model.User;
import org.springframework.data.jpa.repository.JpaRepository;

import java.util.List;

public interface HotelRepo extends JpaRepository<Hotel,Long> {
     List<Hotel> findAllByManager_Id(long managerId);
     Hotel getByName(String name);
}
