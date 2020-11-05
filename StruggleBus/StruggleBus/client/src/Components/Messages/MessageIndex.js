import React, { useState, useEffect, useContext } from 'react';
import { useHistory } from 'react-router-dom';
import { MessageContext } from "../../Providers/MessageProvider";
import Container from 'react-bootstrap/Container';
import Table from 'react-bootstrap/Table';

const MessageIndex = (props) => {

    const history = useHistory();
    const { messages, getMessagesByUserId } = useContext(MessageContext);

    const getMessages = () => {
        const currentUser = JSON.parse(sessionStorage.user);
        getMessagesByUserId(currentUser.id)
    }

    useEffect(() => {
        getMessages();
    }, [])

    return (
        <Container className="mt-5">
            <h1>User Messages</h1>
            <Table bordered striped hover>
                {messages.map(message =>
                    <tr key={message.id}>
                        <td>{message.message}</td>
                    </tr>
                )}
            </Table>
        </Container>
    )
}

export default MessageIndex;