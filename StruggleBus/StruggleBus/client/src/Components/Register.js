import React, { useState, useContext } from "react";
import Form from 'react-bootstrap/Form';
import Button from 'react-bootstrap/Button';
import { useHistory } from "react-router-dom";
import { UserContext } from "../providers/UserProvider";

export default function Register() {
  const history = useHistory();
  const { register } = useContext(UserContext);

  const [name, setName] = useState();
  const [email, setEmail] = useState();
  const [password, setPassword] = useState();
  const [confirmPassword, setConfirmPassword] = useState();

  const registerClick = (e) => {
    e.preventDefault();
    if (password && password !== confirmPassword) {
      alert("Passwords don't match. Do better.");
    } else {
      const user = { name, email };
      register(user, password)
        .then(() => history.push("/"));
    }
  };

  return (
    <Form onSubmit={registerClick}>
      <fieldset>
        <Form.Group>
          <Form.Label htmlFor="name">Name</Form.Label>
          <Form.Input id="name" type="text" onChange={e => setName(e.target.value)} />
        </Form.Group>
        <Form.Group>
          <Form.Label for="email">Email</Form.Label>
          <Form.Input id="email" type="text" onChange={e => setEmail(e.target.value)} />
        </Form.Group>
        <Form.Group>
          <Form.Label for="password">Password</Form.Label>
          <Form.Input id="password" type="password" onChange={e => setPassword(e.target.value)} />
        </Form.Group>
        <Form.Group>
          <Form.Label for="confirmPassword">Confirm Password</Form.Label>
          <Form.Input id="confirmPassword" type="password" onChange={e => setConfirmPassword(e.target.value)} />
        </Form.Group>
        <Form.Group>
          <Button>Register</Button>
        </Form.Group>
      </fieldset>
    </Form>
  );
}