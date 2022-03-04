import axios from "axios";
import authHeader from './auth-header';
import AuthService from './auth-service';

const API_URL = "http://localhost:3000/api/booker/";

function getAddresses() {

    return Promise.resolve(axios.get(API_URL + "addresses", {
        headers: authHeader()
    }).then(response => {
        return Promise.resolve(response.data);
    }))
}

function getBookings() {

    let id = AuthService.getCurrentUser().id;
    return Promise.resolve(axios.get(API_URL + "bookings-by-user", {
        params: {id},
        headers: authHeader()
    }).then(response => {
        return Promise.resolve(response.data);
    }))
}

function getOffers(location, checkinString, checkoutString, guests) {

    return Promise.resolve(axios.get(API_URL + "get_offers", {
        params: {location, checkinString, checkoutString, guests},
        headers: authHeader()
    }).then(response => {
        return Promise.resolve(response.data);
    }))
}

function saveBooking(newBooking) {
    return axios.post(API_URL + "booking/save", newBooking, {
        headers: authHeader()
    })
}

function deleteBooking(bookingId) {
    return axios.delete(API_URL + "delete-booking", {
            params: {bookingId},
            headers: authHeader()
        }
    )
}

// eslint-disable-next-line import/no-anonymous-default-export
export default {
    getAddresses,
    getOffers,
    saveBooking,
    getBookings,
    deleteBooking
};
