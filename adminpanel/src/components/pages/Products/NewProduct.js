import { CButton, CCol, CContainer, CForm, CFormInput, CFormSelect, CFormTextarea } from '@coreui/react'
import axios from 'axios';
import React, { useEffect, useState } from 'react'
import ProductAttributesModal from '../../modals/Products/ProductAttributesModal';
import { ToastContainer, toast } from 'react-toastify';
import Cookies from 'js-cookie';

const NewProduct = () => {
    const [States, setStates] = useState([]);
    const [SelectedState, setSelectedState] = useState(null);
    const [Cities, setCities] = useState([]);
    const [selectedCity, setSelectedCity] = useState(null);
    const [Districts, setDistricts] = useState([]);
    const [selectedAttributes, setSelectedAttributes] = useState([]);
    const [validated, setValidated] = useState(false);

    const accessToken = Cookies.get('RentVilla.Cookie_AT')
    axios.defaults.headers.common['Authorization'] = `Bearer ${accessToken}`;

    useEffect(() => {
        axios('http://localhost:5006/api/region/getallstates')
            .then(data => {
                setStates(data.data);
            })
            .catch((error) => {
                console.error('Error:', error);
            });
    }, []);
    const handleStateChange = (e) => {
        const stateId = e.target.value;
        setSelectedState(stateId);
        axios.get(`http://localhost:5006/api/region/getallcities?stateId=${stateId}`)
            .then((res) => {
                setCities(res.data);
            })
            .catch((err) => {
                console.log(err);
            });
    };
    const handleCityChange = (e) => {
        const cityId = e.target.value;
        setSelectedCity(cityId);
        axios.get(`http://localhost:5006/api/region/getalldistricts?cityId=${cityId}`)
            .then((res) => {
                setDistricts(res.data);
            })
            .catch((err) => {
                console.log(err);
            });
    };
    const handleDistrictChange = (e) => {
        const districtId = e.target.value;
        console.log(Districts)
    }
    const handleAttributeChange = (attributes) => {
        setSelectedAttributes(attributes);
        console.log(selectedAttributes)
    };

    const removeAttribute = (attributeToRemove) => {
        setSelectedAttributes(selectedAttributes.filter(attribute => attribute !== attributeToRemove));
    };
    const handleSubmit = (e) => {
        e.preventDefault();
        setValidated(true);
        toast.dismiss();
        const form = e.currentTarget;
        if (form.checkValidity() === false) {
            e.preventDefault();
            e.stopPropagation();
        }
        axios.post('http://localhost:5006/api/products/add', {
            name: e.target.inputName.value,
            description: e.target.inputDescription.value,
            price: e.target.inputPrice.value,
            deposit: e.target.inputDeposit.value,
            mapId: e.target.inputMapId.value,
            address: e.target.inputAddress.value,
            shortestRentPeriod: e.target.inputRentPeriod.value,
            productaddress: {
                stateId: e.target.inputRegion.value,
                cityId: e.target.inputCity.value,
                districtId: e.target.inputDistrict.value
            },
            properties: e.target.inputAdditionalInfo.value,
            attributeIDs: selectedAttributes.map(attribute => attribute.value)
        })
            .then((res) => {
                toast('Product added successfully', { type: 'success' })
                window.location.href = '/admin/products';
            })
            .catch((err) => {
                console.log(err);
                toast('An error occurred while adding product.', { type: 'error' });
            });
    }

    return (
        <CContainer className='p-5 w-75'>
            <ToastContainer />
            <CForm className="row g-3 needs-validation" noValidate validated={validated} onSubmit={handleSubmit}>
                <CCol md={3} className='position-relative'>
                    <CFormInput type="text" id="inputName" label="Name"
                        required
                    />
                </CCol>
                <CCol md={3} className='position-relative'>
                    <CFormInput type="text" id="inputPrice" label="Price"
                        required />
                </CCol>
                <CCol md={3} className='position-relative'>
                    <CFormInput type="text" id="inputDeposit" label="Deposit"
                        required
                    />
                </CCol>
                <CCol md={3} className='position-relative'>
                    <CFormInput type="text" id="inputRentPeriod" label="Shortest Rent Period"
                        required
                    />
                </CCol>
                <CCol xs={8} className='position-relative'>
                    <CFormInput id="inputAddress" label="Address" placeholder="1234 Main St"
                        required
                    />
                </CCol>
                <CCol xs={4}>
                    <CFormInput id="inputMapId" label="MapId" />
                </CCol>
                <CCol md={4}>
                    <CFormSelect id="inputRegion" label="Region" onChange={handleStateChange} required>
                        {/* <option>Choose...</option> */}
                        {States.map((item) => (
                            <option key={item.id} value={item.id}>{item.name}</option>
                        ))}
                    </CFormSelect>
                </CCol>
                <CCol md={4}>
                    <CFormSelect id="inputCity" label="City" onChange={handleCityChange} required>
                        {/* <option>Choose...</option> */}
                        {Cities.map((item) => (
                            <option key={item.id} value={item.id}>{item.name}</option>
                        ))}
                    </CFormSelect>
                </CCol>
                <CCol md={4}>
                    <CFormSelect id="inputDistrict" label="District" onChange={handleDistrictChange} required>
                        {/* <option>Choose...</option> */}
                        {Districts.map((item) => (
                            <option key={item.id} value={item.id}>{item.name}</option>
                        ))}
                    </CFormSelect>
                </CCol>
                <CCol xs={12}>
                    <CFormTextarea
                        id="inputDescription"
                        label="Description"
                        rows={3}
                        text="Must be 8-20 words long."
                    ></CFormTextarea>
                </CCol>
                <CCol xs={12}>
                    <ProductAttributesModal onAttributeChange={handleAttributeChange} />
                    <div className="selected-attributes d-flex mt-4 gap-3">
                        {selectedAttributes.map(attribute => (
                            <div key={attribute.value} style={{ backgroundColor: 'rgba(247, 245, 245, 0.99)' }} className="attribute-box btn btn-light btn-sm d-flex gap-2 align-items-center py-1 px-2">
                                <span>{attribute.label}</span>
                                <button className='p-0' style={{ border: 'none', backgroundColor: 'transparent', fontSize: '23px' }} onClick={() => removeAttribute(attribute)}>&times;</button>
                            </div>
                        ))}
                    </div>
                </CCol>
                <CCol xs={12}>
                    <CFormTextarea
                        id="inputAdditionalInfo"
                        label="Additional Properties"
                        rows={3}
                        text="Must be 8-20 words long."
                    ></CFormTextarea>
                </CCol>
                <CCol xs={12}>
                    <hr />
                </CCol>
                <CCol xs={12} className='d-flex gap-2 justify-content-end'>
                    <CButton color="secondary" type="button" href='/admin/products'>Back to Products</CButton>
                    <CButton color="success" type="submit">Add Product</CButton>
                </CCol>
            </CForm>
        </CContainer>
    )
}

export default NewProduct