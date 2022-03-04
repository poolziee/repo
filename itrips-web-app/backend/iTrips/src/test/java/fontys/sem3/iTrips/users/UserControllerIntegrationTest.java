package fontys.sem3.iTrips.users;

import com.fasterxml.jackson.databind.ObjectMapper;
import fontys.sem3.iTrips.dto.user.NewUserDTO;
import fontys.sem3.iTrips.dto.user.UserDTO;
import fontys.sem3.iTrips.service.UserService;
import org.junit.jupiter.api.*;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.boot.test.autoconfigure.web.servlet.AutoConfigureMockMvc;
import org.springframework.boot.test.context.SpringBootTest;
import org.springframework.http.MediaType;
import org.springframework.mock.web.MockHttpServletResponse;
import org.springframework.security.test.context.support.WithMockUser;
import org.springframework.test.context.ActiveProfiles;
import org.springframework.test.web.servlet.MockMvc;
import org.springframework.test.web.servlet.setup.MockMvcBuilders;
import org.springframework.web.context.WebApplicationContext;

import static org.springframework.security.test.web.servlet.setup.SecurityMockMvcConfigurers.springSecurity;
import static org.springframework.test.web.servlet.request.MockMvcRequestBuilders.*;
import static org.springframework.test.web.servlet.result.MockMvcResultMatchers.status;

/*
@RunWith(SpringRunner.class)
*/
@SpringBootTest(webEnvironment = SpringBootTest.WebEnvironment.RANDOM_PORT)
@AutoConfigureMockMvc
@TestMethodOrder(MethodOrderer.OrderAnnotation.class)
@ActiveProfiles("test")
public class UserControllerIntegrationTest {

    @Autowired
    private WebApplicationContext context;

    @Autowired
    private MockMvc mvc;

    @BeforeEach
    public void setup() {
        mvc = MockMvcBuilders
                .webAppContextSetup(context)
                .apply(springSecurity())
                .build();
    }

    @Autowired
    private ObjectMapper objectMapper;

    @Autowired
    private MockMvc mockMvc;

    @Autowired
    UserService userService;

    @Test
    @Order(1)
    void registrationWorksThroughAllLayers() throws Exception{
        NewUserDTO user = new NewUserDTO("Bobby","Reynolds", "bobby", "bobby1234", "bobby@mail.com", "ROLE_BOOKER");
        mvc.perform(post("/api/register")
                .contentType(MediaType.APPLICATION_JSON)
                .content(objectMapper.writeValueAsString(user)))
                .andExpect(status().is(201));
        UserDTO addedUser = userService.getUserDTO("bobby");
        Assertions.assertEquals("bobby", addedUser.getUsername());
    }

    @Test
    @Order(2)
    void registrationFailsThroughAllLayers() throws Exception{
        NewUserDTO user = new NewUserDTO("Bobby","Reynolds", "bobby", "bobby1234", "bobby@mail.com", "ROLE_BOOKER");
        mvc.perform(post("/api/register")
                .contentType(MediaType.APPLICATION_JSON)
                .content(objectMapper.writeValueAsString(user)))
                .andExpect(status().is(400));
    }

    @Test
    @Order(3)
    void gettingUsersWorksThroughAllLayers() throws Exception{
        MockHttpServletResponse response = mvc.perform(get("/api/users")).
                andExpect(status().is(200))
                .andReturn()
                .getResponse();
    }

    @Test
    @WithMockUser("spring")
    @Order(4)
    void updatePasswordWorksThroughAllLayers() throws  Exception {
        mvc.perform(put("/api/user/update-password")
                        .contentType(MediaType.APPLICATION_JSON)
                        .param("currPassword", "bobby1234")
                        .param("newPassword", "bobby123Updated")
                        .param("userId", "1")
                )
                .andExpect(status().is(200));
    }

    @Test
    @WithMockUser("spring")
    @Order(5)
    void updatePasswordFailsThroughAllLayers() throws  Exception {
        mvc.perform(put("/api/user/update-password")
                        .contentType(MediaType.APPLICATION_JSON)
                        .param("currPassword", "bob")
                        .param("newPassword", "bobby123Updated")
                        .param("userId", "1")
                )
                .andExpect(status().is(400));
    }


}
