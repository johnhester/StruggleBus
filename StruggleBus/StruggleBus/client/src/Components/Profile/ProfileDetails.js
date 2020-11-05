import React, { useState, useEffect, useContext } from 'react';
import { UserContext } from "../../Providers/UserProvider";
import { Link, useHistory } from "../react-router-dom"



const ProfileDetails = (props) => {
    const { getById } = useContext(UserContext);
    const history = useHistory();

    const getUser = async () => {

    }

    return (
        <>
        </>
    )
}

export default ProfileDetails