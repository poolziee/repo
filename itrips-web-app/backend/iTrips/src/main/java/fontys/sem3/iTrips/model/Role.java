package fontys.sem3.iTrips.model;

import lombok.*;

import javax.persistence.*;


@Entity @Table(name="role") @Getter @Setter @AllArgsConstructor @NoArgsConstructor
public class Role {
    @Id
    @SequenceGenerator(name="role_sequence",sequenceName="role_sequence",allocationSize = 1) @GeneratedValue(strategy = GenerationType.SEQUENCE, generator = "role_sequence")
    private Long id;
    private String name;
}
