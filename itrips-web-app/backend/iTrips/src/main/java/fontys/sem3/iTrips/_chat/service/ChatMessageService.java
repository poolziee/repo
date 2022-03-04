package fontys.sem3.iTrips._chat.service;


import fontys.sem3.iTrips._chat.exception.ResourceNotFoundException;
import fontys.sem3.iTrips._chat.model.ChatMessage;
import fontys.sem3.iTrips._chat.model.MessageStatus;
import fontys.sem3.iTrips._chat.repository.ChatMessageRepository;
import fontys.sem3.iTrips.util.Contact;
import lombok.extern.slf4j.Slf4j;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import java.util.ArrayList;
import java.util.List;

@Service
@Slf4j
public class ChatMessageService {
    @Autowired private ChatMessageRepository repository;
    @Autowired private ChatRoomService chatRoomService;

    public ChatMessage save(ChatMessage chatMessage) {
        chatMessage.setStatus(MessageStatus.RECEIVED);
        repository.save(chatMessage);
        return chatMessage;
    }

    public Contact countNewMessages(String senderId, String recipientId) {
        long count = repository.countBySenderIdAndRecipientIdAndStatus(
                senderId, recipientId, MessageStatus.RECEIVED);
        log.info("the new messages count is: " + count);
        ChatMessage message = repository.findLastChatMessage(senderId,recipientId);
        log.info("last message:");
        log.info(String.valueOf(message));
        return new Contact(count,message);
    }

    public List<ChatMessage> findChatMessages(String senderId, String recipientId) {
        var chatId = chatRoomService.getChatId(senderId, recipientId, false);

        var messages =
                chatId.map(cId -> repository.findByChatId(cId)).orElse(new ArrayList<>());

        if(messages.size() > 0) {
            updateStatuses(senderId, recipientId, MessageStatus.DELIVERED);
        }

        return messages;
    }

    public ChatMessage findById(String id) {
        return repository
                .findById(id)
                .map(chatMessage -> {
                    chatMessage.setStatus(MessageStatus.DELIVERED);
                    return repository.save(chatMessage);
                })
                .orElseThrow(() ->
                        new ResourceNotFoundException("can't find message (" + id + ")"));
    }

    public void updateStatuses(String senderId, String recipientId, MessageStatus status) {

        repository.updateStatus(senderId,recipientId,status);
    }
}
