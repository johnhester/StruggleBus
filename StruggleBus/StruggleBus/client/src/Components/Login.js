import React, { useState, useContext } from "react";
import Form from 'react-bootstrap/Form';
import Button from 'react-bootstrap/Button'
import { useHistory, Link } from "react-router-dom";
import { UserContext } from "../providers/UserProvider";

export default function Login() {
  const history = useHistory();
  const { login } = useContext(UserContext);

  const [email, setEmail] = useState();
  const [password, setPassword] = useState();

  const loginSubmit = (e) => {
    e.preventDefault();
    login(email, password)
      .then(() => history.push("/"))
      .catch(() => alert("Invalid email or password"));
  };

  return (
    <Form onSubmit={loginSubmit}>
      <fieldset>
        <Form.Group>
          <Form.Label for="email">Email</Form.Label>
          <Input id="email" type="text" onChange={e => setEmail(e.target.value)} />
        </Form.Group>
        <Form.Group>
          <Form.Label for="password">Password</Form.Label>
          <Form.Input id="password" type="password" onChange={e => setPassword(e.target.value)} />
        </Form.Group>
        <Form.Group>
          <Button>Login</Button>
        </Form.Group>
        <em>
          Not registered? <Link to="register">Register</Link>
        </em>
      </fieldset>
    </Form>
  );
}