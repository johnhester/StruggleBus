import React, { useState, createContext, useContext } from "react";
import "firebase/auth";
import { UserContext } from "./UserProvider";
import { useHistory } from "react-router-dom";

export const MessageContext = createContext();

export function MessageProvider(props) {
    const apiUrl = "/api/message"
    const { getToken } = useContext(UserContext);
    const [messages, setMessages] = useState([]);
    const history = useHistory();

    const getMessagesByUserId = (userId) => {
        return getToken().then((token) =>
            fetch(`${apiUrl}/${userId}`, {
                method: "GET",
                headers: {
                    Authorization: `Bearer ${token}`
                }
            }).then(res => res.json()).then(setMessages)
        )
    }

    return (
        <MessageContext.Provider value={{ messages, setMessages, getMessagesByUserId }}>
            {props.children}
        </MessageContext.Provider>
    )

}