package com.ivantimarket.ivanti.security;

import com.ivantimarket.ivanti.service.UserService;
import lombok.RequiredArgsConstructor;
import org.springframework.context.annotation.Bean;
import org.springframework.context.annotation.Configuration;
import org.springframework.security.authentication.AuthenticationManager;
import org.springframework.security.config.annotation.authentication.builders.AuthenticationManagerBuilder;
import org.springframework.security.config.annotation.web.builders.HttpSecurity;
import org.springframework.security.config.annotation.web.configuration.EnableWebSecurity;
import org.springframework.security.config.annotation.web.configuration.WebSecurityConfigurerAdapter;
import org.springframework.security.config.http.SessionCreationPolicy;
import org.springframework.security.core.userdetails.UserDetailsService;
import org.springframework.security.crypto.password.PasswordEncoder;
import org.springframework.security.web.authentication.AuthenticationFailureHandler;
import org.springframework.security.web.authentication.UsernamePasswordAuthenticationFilter;

import static org.springframework.http.HttpMethod.GET;
import static org.springframework.http.HttpMethod.POST;

@Configuration @EnableWebSecurity @RequiredArgsConstructor
public class SecurityConfig extends WebSecurityConfigurerAdapter {

    private final UserDetailsService userDetailsService;
    private final PasswordEncoder crypt;
    private final UserService userService;
    @Override
    protected void configure(AuthenticationManagerBuilder auth) throws Exception {
        auth.userDetailsService(userDetailsService).passwordEncoder(crypt);
    }

    @Override
    protected void configure(HttpSecurity http) throws Exception {
        CustomAuthenticationFilter customAuthenticationFilter = new CustomAuthenticationFilter(authenticationManagerBean(), authenticationFailureHandler(), userService);
        customAuthenticationFilter.setFilterProcessesUrl("/api/login");
        http.csrf().disable();
        http.cors();
        http.sessionManagement().sessionCreationPolicy(SessionCreationPolicy.STATELESS);
        //package saving-creating/deleting/updating has to be restricted later on

        http.authorizeRequests().antMatchers("/api/login/**","/api/register/**", "/api/token/refresh/**", "/api/users/**", "/api/packages/get/**", "/api/packages","/api/packages/download**","/user/login/**", "/api/packages/create",
                "/api/packages/add-new-package", "/api/packages/add-version/{packageId}", "/api/packages/uploaded/{userId}", "/api/packages/versions/{packageId}", "/api/packages/system-requirements/{packageId}",
                "/api/user/add-role", "/api/review/create", "/api/reviews/package/{packageId}", "/api/download/create",
                "/api/downloads/{userId}", "/api/packages/favouriteOfUser/{userId}", "/api/packages/downloaded/{userId}",
                "/api/reviews/packageAverageRating/{packageId}", "/api/reviews/nrReviewsWithRating/{packageId}/{rating}").permitAll();

        http.authorizeRequests().antMatchers("/api/login/**","/api/register/**", "/api/token/refresh/**", "/api/users/**", "/api/packages/get/**", "/api/packages/","/api/packages/download**","/user/login/**", "/api/packages/create",
                "/api/packages/add-new-package", "/api/packages/add-version/{packageId}", "/api/packages/uploaded/{userId}", "/api/packages/versions/{packageId}", "/api/packages/system-requirements/{packageId}", "/api/packages/update-package",
                "/api/packages/favourites/add", "/api/packages/favourites/check", "/api/packages/favourites/remove", "/api/review/create", "/api/user/changeFirstTimeVar", "/api/packages/first3packages", "/api/packages/delete/{packageId}").permitAll();

        http.authorizeRequests().antMatchers(GET, "/api/user/**").hasAnyAuthority("ROLE_USER");
        http.authorizeRequests().antMatchers(POST, "/api/user/update","/api/user/update/password").hasAnyAuthority("ROLE_CUSTOMER", "ROLE_CONTENT_CREATOR");
//        http.authorizeRequests().antMatchers(POST, "/api/packages/create", "/api/packages/add-version/**").hasAnyAuthority("ROLE_CONTENT_CREATOR");
        http.authorizeRequests().anyRequest().authenticated();
        http.addFilter(customAuthenticationFilter);
        http.addFilterBefore(new CustomAuthorizationFilter(), UsernamePasswordAuthenticationFilter.class);
        //disable security for testing
/*
        http.csrf().disable();
*/

    }

    @Bean
    public AuthenticationFailureHandler authenticationFailureHandler() {
        return new CustomAuthenticationFailureHandler();
    }

    @Bean
    @Override
    public AuthenticationManager authenticationManagerBean() throws Exception{
        return super.authenticationManagerBean();
    }

}
