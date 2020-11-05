import React, { useState, useContext, useEffect } from 'react';
import { UserContext } from "../Providers/UserProvider";
import { useHistory } from "react-router-dom";
import Navbar from "react-bootstrap/Navbar";
import { Nav } from 'react-bootstrap';


export default function Header() {
    const { isLoggedIn, logout } = useContext(UserContext);
    const history = useHistory();
    const [userId, setUserId] = useState();
    const user = JSON.parse(sessionStorage.user);

    useEffect(() => {
        if (user != null) {
            setUserId(user.id)
        }
    }, [])

    return (
        <Header>
            <Navbar variant="dark" bg="primary" fixed="top" expand="lg">
                <Navbar.Brand>Struggle Bus</Navbar.Brand>
                {isLoggedIn ?
                    <Nav className="mr-auto">
                        <Nav.Link onClick={() => history.push(`/profile/${userId}`)}>Profile</Nav.Link>
                        <Nav.Link>Messages</Nav.Link>
                        <Nav.Link onClick={logout}>Logout</Nav.Link>
                    </Nav>
                    :
                    <Nav>
                        <Nav.Link>Login</Nav.Link>
                        <Nav.Link>Register</Nav.Link>
                    </Nav>
                }

            </Navbar>
        </Header>
    );
}