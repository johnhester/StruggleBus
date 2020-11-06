import React from 'react';
import Modal from 'react-bootstrap/Modal';
import Button from 'react-bootstrap/Button';

const DeleteProfileModal = (props) => {


    return (
        <Modal show={props.show} backdrop="static" keyboard={false} centered>
            <Modal.Header>
                <Modal.Title>Delete Profile</Modal.Title>
            </Modal.Header>
            <Modal.Body> Are you sure? This action can not be undone.</Modal.Body>
            <Modal.Footer>
                <Button onClick={props.handleDelete}>Delete</Button>
                <Button onClick={props.handleClose}>Cancel</Button>
            </Modal.Footer>
        </Modal>
    )
}

export default DeleteProfileModal;