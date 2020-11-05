import React, { useState, useEffect, useContext } from 'react';
import { UserContext } from "../../Providers/UserProvider";
import { Link, useHistory } from "react-router-dom"
import Card from 'react-bootstrap/Card'
import Container from 'react-bootstrap/Container'



const ProfileDetails = (props) => {
    const { getById } = useContext(UserContext);
    const history = useHistory();
    const [user, setUser] = useState({
        id: 0,
        firstName: "Trogdor",
        lastName: "Burninator",
        userName: "BurnieLanders",
        email: "GonBUrnya@hotmail.com",
        userPhone: "+15555555555"
    })

    const getUser = async (id) => {
        let result = await getById(id);
        if (!result) return;
        setUser(result)
    }

    useEffect(() => {
        const user = JSON.parse(props.match.params.id)
        getUser(user.id);
    }, [])

    return (
        <Container>
            <Card>
                <h1>test</h1>
            </Card>
        </Container>
    )
}

export default ProfileDetails