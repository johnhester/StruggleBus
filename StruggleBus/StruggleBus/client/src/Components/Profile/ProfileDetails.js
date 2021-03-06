import React, { useState, useEffect, useContext } from 'react';
import { UserContext } from "../../Providers/UserProvider";
import { useHistory } from "react-router-dom"
import Card from 'react-bootstrap/Card'
import Container from 'react-bootstrap/Container'
import Button from 'react-bootstrap/Button'
import Table from 'react-bootstrap/Table'
import DeleteProfileModal from './DeleteProfileModal';


const ProfileDetails = (props) => {
    const { getById, deleteUser, logout } = useContext(UserContext);
    const history = useHistory();
    const [user, setUser] = useState({
        id: 0,
        firstName: "Trogdor",
        lastName: "Burninator",
        userName: "BurnieLanders",
        email: "GonBUrnya@hotmail.com",
        userPhone: "+15555555555"
    })

    //for delete modal
    const [show, setShow] = useState(false);
    const handleClose = () => setShow(false);
    const handleShow = () => setShow(true);

    const handleDelete = () => {
        handleClose();
        deleteUser(user.id).then(() => logout());
    }

    const getUser = async (id) => {
        let result = await getById(id);
        if (!result) return;
        setUser(result)
    }

    useEffect(() => {
        const user = JSON.parse(sessionStorage.getItem('user'))
        getUser(user.id);
    }, [])

    return (
        <Container className="mt-3">
            <Card>
                <Card.Header><h1>User Profile Details</h1></Card.Header>
                <Card.Body>
                    <Table bordered hover striped className="p-5">
                        <tbody>
                            <tr>
                                <th>First Name:</th>
                                <td>{user.firstName}</td>
                            </tr>
                            <tr>
                                <th>Last Name:</th>
                                <td>{user.lastName}</td>
                            </tr>
                            <tr>
                                <th>UserName:</th>
                                <td>{user.userName}</td>
                            </tr>
                            <tr>
                                <th>Email:</th>
                                <td>{user.email}</td>
                            </tr>
                            <tr>
                                <th>Phone Number:</th>
                                <td>{user.userPhone}</td>
                            </tr>

                        </tbody>
                    </Table>
                </Card.Body>
                <Card.Footer>
                    <Button variant="primary" className="mr-2" onClick={() => { history.push("/profile/edit") }}>Edit Profile</Button>
                    <Button variant="danger" onClick={handleShow}>Delete Profile</Button>
                </Card.Footer>
            </Card>
            <DeleteProfileModal show={show} handleClose={handleClose} handleDelete={handleDelete} />
        </Container>
    )
}

export default ProfileDetails