import axios from "axios";
import authHeader from './auth-header';
import authService from './auth-service';

const API_URL = "http://localhost:3000/api/hotel_manager/";

const addHotel = (hotel) => {
    const manager = authService.getCurrentUser();
    hotel["managerId"] = manager.id;
    return axios.post(API_URL + "hotel/save", hotel, {
        headers: authHeader()
    })
}

const updateHotel = (hotel, hotelId) => {
    const manager = authService.getCurrentUser();
    hotel["managerId"] = manager.id;
    return axios.put(API_URL + "hotel/update", hotel, {
        params: {hotelId},
        headers: authHeader()
    })
}

const addRoom = (hotelId, room) => {
    return axios.post(API_URL + "rooms/new", room, {
        params: {hotelId},
        headers: authHeader()
    })
}

const updateRoom = (room, roomId) => {
    return axios.put(API_URL + "rooms/update", room, {
        params: {roomId},
        headers: authHeader()
    })
}

function getOverviewData() {
    const manager = authService.getCurrentUser();
    let managerId = manager.id;
    return Promise.resolve(axios.get(API_URL + "overview-statistics", {
        params: {managerId},
        headers: authHeader()
    }).then(response => {
        return Promise.resolve(response.data);
    }))
}

function getAnalyticsData() {
    const manager = authService.getCurrentUser();
    let managerId = manager.id;
    return Promise.resolve(axios.get(API_URL + "analytics-statistics", {
        params: {managerId},
        headers: authHeader()
    }).then(response => {
        return Promise.resolve(response.data);
    }))
}

function getHotelYearlyAnalyticsData(hotelName) {
    const manager = authService.getCurrentUser();
    let managerId = manager.id;
    return Promise.resolve(axios.get(API_URL + "analytics-statistics/hotel", {
        params: {hotelName: hotelName, managerId: managerId},
        headers: authHeader()
    }).then(response => {
        return Promise.resolve(response.data);
    }))
}

function getHotels() {
    const manager = authService.getCurrentUser();
    let managerId = manager.id;
    return Promise.resolve(axios.get(API_URL + "hotels-by-manager", {
        params: {managerId},
        headers: authHeader()
    }).then(response => {
        return Promise.resolve(response.data);
    }))
}

// eslint-disable-next-line import/no-anonymous-default-export
export default {
    addHotel,
    addRoom,
    getHotels,
    updateHotel,
    updateRoom,
    getOverviewData,
    getAnalyticsData,
    getHotelYearlyAnalyticsData
};
