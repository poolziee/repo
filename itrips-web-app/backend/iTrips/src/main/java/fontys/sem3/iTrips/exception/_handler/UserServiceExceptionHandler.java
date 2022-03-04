package fontys.sem3.iTrips.exception._handler;

import fontys.sem3.iTrips.exception.CustomError;
import fontys.sem3.iTrips.exception.UnsatisfiedPasswordException;
import fontys.sem3.iTrips.exception.UserAlreadyExistsException;
import fontys.sem3.iTrips.model.User;
import lombok.extern.slf4j.Slf4j;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;

import static org.springframework.http.HttpStatus.BAD_REQUEST;
import static org.springframework.http.HttpStatus.INTERNAL_SERVER_ERROR;

@RestControllerAdvice
@Slf4j
public class UserServiceExceptionHandler {

    @ResponseBody
    @ExceptionHandler({UserAlreadyExistsException.class, UnsatisfiedPasswordException.class})
    @ResponseStatus(BAD_REQUEST)
    public CustomError handle(Exception ex){return new CustomError(ex.getMessage()); }


}
