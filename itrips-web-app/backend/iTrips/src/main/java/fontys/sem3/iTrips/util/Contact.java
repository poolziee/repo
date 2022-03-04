package fontys.sem3.iTrips.util;

import fontys.sem3.iTrips._chat.model.ChatMessage;
import lombok.AllArgsConstructor;
import lombok.Data;

@Data
@AllArgsConstructor
public class Contact {
    private long newMessages;
    private ChatMessage lastMessage;
}
