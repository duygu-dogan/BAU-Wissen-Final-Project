import { faTrashCan } from '@fortawesome/free-solid-svg-icons'
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome'
import 'react-toastify/dist/ReactToastify.css';
import axios from 'axios';
import React from 'react';
import Cookies from 'js-cookie';

const DeleteUserModal = ({ userId, onModalClose }) => {
    const modalId = `deleteModal${userId}`;

    const accessToken = Cookies.get('RentVilla.Cookie_AT')
    axios.defaults.headers.common['Authorization'] = `Bearer ${accessToken}`;

    const handleHardDelete = (e) => {
        e.preventDefault();
        axios.delete(`http://localhost:5006/api/users/deleteUser?UserId=${userId}`)
            .then(response => {
                console.log(response);
                onModalClose("User deleted successfully.", "success");
            })
            .catch(error => {
                console.error(error);
                onModalClose("User deletion failed.", "error");
            });
    }
    const handleSoftDelete = (e) => {
        e.preventDefault();
        axios.put(`http://localhost:5006/api/users/SoftDeleteUser?UserId=${userId}`)
            .then(response => {
                console.log(response);
                onModalClose("User moved to recycle bin successfully.", "success");
            })
            .catch(error => {
                console.error(error);
                onModalClose("User movement to recycle bin failed.", "error");
            });
    }
    return (
        <div>
            <button type='button' style={{ borderRadius: "3px" }} className='btn btn-danger btn-sm' data-bs-toggle="modal" data-bs-target={`#${modalId}`}> <FontAwesomeIcon style={{ fontSize: "15px" }} icon={faTrashCan} /> </button>
            <form >
                <div class="modal fade" id={modalId} tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
                    <div class="modal-dialog">
                        <div class="modal-content">
                            <div class="modal-header">
                                <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                            </div>
                            <div class="modal-body">
                                If you want to delete this user permanently, click the delete button. If you want to move it to the recycle bin, click the recycle bin button. If you delete this user, you can't recover it.
                            </div>
                            <div class="modal-footer">
                                <button type="button" class="btn btn-secondary btn-sm" data-bs-dismiss="modal">Cancel</button>
                                <button type="button" onClick={handleHardDelete} class="btn btn-danger btn-sm" data-bs-dismiss="modal">Delete</button>
                                <button type="button" onClick={handleSoftDelete} class="btn btn-warning btn-sm" data-bs-dismiss="modal">Recycle Bin</button>
                            </div>
                        </div>
                    </div>
                </div>
            </form>
        </div>
    )
}

export default DeleteUserModal