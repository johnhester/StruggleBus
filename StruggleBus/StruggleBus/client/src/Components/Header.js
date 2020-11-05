import React, { useState, useContext, useEffect } from 'react';
import { UserContext } from "../Providers/UserProvider";
import { useHistory } from "react-router-dom";
import Navbar from "react-bootstrap/Navbar";
import { Nav } from 'react-bootstrap';


export default function Header() {
    const { isLoggedIn, logout } = useContext(UserContext);
    const history = useHistory();



    return (
        <Navbar bg="dark" variant="dark" sticky="top" expand="lg">
            <Navbar.Brand onClick={() => history.push("/")}>Struggle Bus</Navbar.Brand>
            {isLoggedIn ?
                <Nav className="mr-auto">
                    <Nav.Link onClick={() => history.push("/profile")}>Profile</Nav.Link>
                    <Nav.Link>Messages</Nav.Link>
                    <Nav.Link onClick={logout}>Logout</Nav.Link>
                </Nav>
                :
                <Nav>
                    <Nav.Link onClick={() => history.push("/login")}>Login</Nav.Link>
                    <Nav.Link onClick={() => history.push("/register")}>Register</Nav.Link>
                </Nav>
            }

        </Navbar>
    );
}