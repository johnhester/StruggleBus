import React, { useContext, useState, useEffect } from 'react';
import { useHistory } from 'react-router-dom';
import Form from 'react-bootstrap/Form';
import Card from 'react-bootstrap/Card';
import Button from 'react-bootstrap/Button';
import { UserContext } from '../../Providers/UserProvider';


const EditProfile = (props) => {
    const history = useHistory();
    const { getById, editUser } = useContext(UserContext);
    const [id, setId] = useState();
    const [firebaseUserId, setFirebaseUserId] = useState();
    const [firstName, setFirstName] = useState();
    const [lastName, setLastName] = useState();
    const [userName, setUserName] = useState();
    const [email, setEmail] = useState();
    const [userPhone, setUserPhone] = useState();

    const getUser = async (id) => {
        getById(id).then(result => {
            setId(result.id)
            setFirebaseUserId(result.firebaseUserId)
            setFirstName(result.firstName)
            setLastName(result.lastName)
            setUserName(result.userName)
            setEmail(result.email)
            setUserPhone(result.userPhone)
        })
    }

    const handleEdit = (event) => {
        event.preventDefault();
        const updatedUser = {
            id,
            firebaseUserId,
            firstName,
            lastName,
            userName,
            email,
            userPhone
        }

        editUser(updatedUser).then(() => history.push("/profile"));

    }

    useEffect(() => {
        const currentUser = JSON.parse(sessionStorage.user)
        getUser(currentUser.id)
    }, [])

    return (
        <Card className="m-4">
            <Card.Header>
                Edit Profile
            </Card.Header>
            <Card.Body>
                <Form onSubmit={handleEdit}>
                    <Form.Group>
                        <Form.Label> First Name:</Form.Label>
                        <Form.Control
                            type="text"
                            onChange={(event) => setFirstName(event.target.value)}
                            defaultValue={firstName}
                            maxLength="50"
                            required></Form.Control>
                    </Form.Group>
                    <Form.Group>
                        <Form.Label> Last Name:</Form.Label>
                        <Form.Control
                            type="text"
                            onChange={(event) => setLastName(event.target.value)}
                            defaultValue={lastName}
                            maxLength="50"
                            required></Form.Control>
                    </Form.Group>
                    <Form.Group>
                        <Form.Label> Username:</Form.Label>
                        <Form.Control
                            type="text"
                            onChange={(event) => setUserName(event.target.value)}
                            defaultValue={userName}
                            maxLength="50"
                            required></Form.Control>
                    </Form.Group>

                    <Form.Group>
                        <Form.Label> Phone Number:</Form.Label>
                        <Form.Control
                            type="text"
                            onChange={(event) => setUserPhone(event.target.value)}
                            defaultValue={userPhone}
                            maxLength="15"
                            required></Form.Control>
                        <Form.Text muted>Please do not use any - or (), and include the country code</Form.Text>
                    </Form.Group>
                    <Form.Group>
                        <Button variant="primary" type="submit">Submit</Button>
                        <Button variant="danger" onClick={() => { history.push("/profile") }}>Cancel</Button>
                    </Form.Group>
                </Form>
            </Card.Body>
        </Card>
    )
}

export default EditProfile;