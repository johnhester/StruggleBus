import React, { useState, useContext } from "react";
import Form from 'react-bootstrap/Form';
import Button from 'react-bootstrap/Button';
import { useHistory } from "react-router-dom";
import { UserContext } from "../Providers/UserProvider";

export default function Register() {
  const history = useHistory();
  const { register } = useContext(UserContext);

  const [firstName, setFirstName] = useState();
  const [lastName, setLastName] = useState();
  const [userName, setUserName] = useState();
  const [imageUrl, setImageUrl] = useState();
  const [userPhone, setUserPhone] = useState();
  const [email, setEmail] = useState();
  const [password, setPassword] = useState();
  const [confirmPassword, setConfirmPassword] = useState();

  const registerClick = (e) => {
    e.preventDefault();
    if (password && password !== confirmPassword) {
      alert("Passwords don't match. Please try again.");
    } else {
      const user = { firstName, lastName, userName, imageUrl, userPhone, email };
      register(user, password)
        .then(() => history.push("/"))
        .catch(() => alert("Error submitting. Try again."));
    }
  };

  return (
    <Form onSubmit={registerClick}>
      <fieldset>
        <Form.Group>
          <Form.Label>First Name: </Form.Label>
          <Form.Control id="firstName" type="text" onChange={e => setFirstName(e.target.value)} required maxLength="50" />
        </Form.Group>
        <Form.Group>
          <Form.Label>Last Name: </Form.Label>
          <Form.Control id="lastName" type="text" onChange={e => setLastName(e.target.value)} required maxLength="50" />
        </Form.Group>
        <Form.Group>
          <Form.Label>User Name: </Form.Label>
          <Form.Control id="userName" type="text" onChange={e => setUserName(e.target.value)} required maxLength="50" />
        </Form.Group>
        <Form.Group>
          <Form.Label>Profile Image Url: </Form.Label>
          <Form.Control id="imageUrl" type="text" onChange={e => setImageUrl(e.target.value)} maxLength="255" />
          <Form.Text className="text-muted">Optional</Form.Text>
        </Form.Group>
        <Form.Group>
          <Form.Label>Mobile Phone Number: </Form.Label>
          <Form.Control id="phoneNumber" type="text" onChange={e => setUserPhone(e.target.value)} placeholder="+1112223333" maxLength="15" />
          <Form.Text muted>Please do not use any - or (), and include the country code</Form.Text>
        </Form.Group>
        <Form.Group>
          <Form.Label >Email</Form.Label>
          <Form.Control id="email" type="text" onChange={e => setEmail(e.target.value)} required maxLength="255" />
        </Form.Group>
        <Form.Group >
          <Form.Label htmlFor="password">Password</Form.Label>
          <Form.Control id="password" type="password" onChange={e => setPassword(e.target.value)} required />
          <Form.Text muted>Password should be at least 6 characters</Form.Text>
        </Form.Group>
        <Form.Group>
          <Form.Label >Confirm Password</Form.Label>
          <Form.Control id="confirmPassword" type="password" onChange={e => setConfirmPassword(e.target.value)} required />
        </Form.Group>
        <Form.Group>
          <Button type="submit">Register</Button>
        </Form.Group>
      </fieldset>
    </Form>
  );
}