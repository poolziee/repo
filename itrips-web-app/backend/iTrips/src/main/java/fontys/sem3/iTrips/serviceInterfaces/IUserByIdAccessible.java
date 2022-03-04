package fontys.sem3.iTrips.serviceInterfaces;

import fontys.sem3.iTrips.model.User;

import java.util.List;

public interface IUserByIdAccessible {
    User getUserById(long id);
    List<User> getUsers();
}
