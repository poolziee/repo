import {atom} from "recoil";


export const chatActiveContact = atom({
    key: "chatActiveContact",
    default: {},
    persistence_UNSTABLE: {
        type: "chatActiveContact",
    },
});

export const chatMessages = atom({
    key: "chatMessages",
    default: [],
    persistence_UNSTABLE: {
        type: "chatMessages",
    },
});
