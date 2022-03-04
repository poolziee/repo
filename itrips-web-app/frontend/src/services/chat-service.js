import axios from 'axios';
import authHeader from "./auth-header";

const CHAT_SERVICE = "http://localhost:3000/api";


export function countNewMessages(senderId, recipientId) {
    if (!localStorage.getItem("user")) {
        return Promise.reject("No user in localstorage.");
    }

    return axios.get(CHAT_SERVICE + "/messages/" + senderId + "/" + recipientId + "/count", {
        headers: authHeader()
    });
}


export function findChatMessages(senderId, recipientId) {
    if (!localStorage.getItem("user")) {
        return Promise.reject("No user in localstorage.");
    }

    return axios.get(CHAT_SERVICE + "/messages/" + senderId + "/" + recipientId, {
        headers: authHeader()
    });
}

export function findChatMessage(id) {
    if (!localStorage.getItem("user")) {
        return Promise.reject("No user in localstorage.");
    }

    return axios.get(CHAT_SERVICE + "/messages/" + id, {
        headers: authHeader()
    });
}

export function getUsers() {
    if (!localStorage.getItem("user")) {
        return Promise.reject("No user in localstorage.");
    }

    return axios.get("http://localhost:3000/api/users", {
        headers: authHeader()
    });
}