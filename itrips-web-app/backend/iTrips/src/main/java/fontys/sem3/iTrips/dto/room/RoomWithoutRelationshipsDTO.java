package fontys.sem3.iTrips.dto.room;

import fontys.sem3.iTrips.model.Hotel;
import lombok.AllArgsConstructor;
import lombok.Data;
import lombok.NoArgsConstructor;

@Data
@NoArgsConstructor
public class RoomWithoutRelationshipsDTO {
    public RoomWithoutRelationshipsDTO(String type, int sleeps, int total, double price) {
        this.type = type;
        this.sleeps = sleeps;
        this.total = total;
        this.price = price;
    }

    public RoomWithoutRelationshipsDTO(long id, String type, int sleeps, int total, double price) {
        this.id = id;
        this.type = type;
        this.sleeps = sleeps;
        this.total = total;
        this.price = price;
    }

    public RoomWithoutRelationshipsDTO(String type) {
        this.type = type;
    }

    public RoomWithoutRelationshipsDTO(String type, int sleeps) {
        this.type = type;
        this.sleeps = sleeps;
    }

    private long id;
    private String type;
    private int sleeps;
    private int total;
    private double price;
}
