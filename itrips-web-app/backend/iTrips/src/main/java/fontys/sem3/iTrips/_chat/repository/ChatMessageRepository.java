package fontys.sem3.iTrips._chat.repository;


import fontys.sem3.iTrips._chat.model.ChatMessage;
import fontys.sem3.iTrips._chat.model.MessageStatus;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Modifying;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;
import org.springframework.transaction.annotation.Transactional;

import java.util.List;

public interface ChatMessageRepository
        extends JpaRepository<ChatMessage, String> {

    long countBySenderIdAndRecipientIdAndStatus(
            String senderId, String recipientId, MessageStatus status);

    List<ChatMessage> findByChatId(String chatId);

    @Transactional
    @Modifying(clearAutomatically = true)
    @Query("update ChatMessage cm set cm.status = :status where cm.senderId = :senderId and cm.recipientId = :recipientId ")
    void updateStatus(@Param("senderId") String senderId, @Param("recipientId") String recipientId, @Param("status") MessageStatus status);

    @Query(nativeQuery = true, value = "select * from chat_message cm  where" +
            " (cm.sender_id = :senderId and cm.recipient_id = :recipientId) or " +
            "(cm.sender_id = :recipientId and cm.recipient_id = :senderId)" +
            "order by cm.id desc limit 1 ")
    ChatMessage findLastChatMessage(@Param("senderId") String senderId, @Param("recipientId") String recipientId);
}