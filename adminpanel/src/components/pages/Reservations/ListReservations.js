import React, { useEffect, useState } from 'react'
import axios from 'axios';
import ReservationTable from '../../helpers/ReservationTable';
import Cookies from 'js-cookie';

const ListReservations = () => {
    const [items, setItems] = useState([]);
    const [pagination, setPagination] = useState(
        { Page: 0, Size: 10 }
    );
    const handlePagination = (rowSize, pageSize) => {
        console.log(rowSize, pageSize)
        setPagination(
            { Page: pageSize, Size: rowSize }
        );
    }
    const accessToken = Cookies.get('RentVilla.Cookie_AT')
    axios.defaults.headers.common['Authorization'] = `Bearer ${accessToken}`;
    useEffect(() => {
        console.log(localStorage.getItem('RentVilla.Cookie_AT'))
        axios.get(`http://localhost:5006/api/reservations/getactivereservations`, { params: pagination, withCredentials: true })
            .then((res) => {
                console.log(res);
                const newItems = res.data.activeReservations.map(item => ({
                    id: item.id,
                    user: item.userName,
                    name: item.productName,
                    totalCost: item.totalCost,
                    startDate: item.startDate,
                    endDate: item.endDate,
                    isPaid: item.isPaid,
                    status: item.reservationStatus,
                }));
                setItems(newItems);
                console.log(newItems)
            })
            .catch((err) => {
                console.log(err)
            })
    }, []);

    return (
        <div className='container d-flex flex-column mt-3'>
            <div className='col-md-11 d-flex justify-content-between align-items-center'>
                <div>
                    <h3 className='container-fluid mb-2'>Active Reservations</h3>
                </div>
                <div >
                    <a style={{ borderRadius: "3px" }} href='/admin/passivereservations' className='btn btn-warning text-white btn float-end fs-6'> Passive Reservations</a>
                </div>

            </div>
            <div className='col-md-11'>
                <ReservationTable rows={items} onPagination={handlePagination} />
            </div>
        </div>
    )
}

export default ListReservations