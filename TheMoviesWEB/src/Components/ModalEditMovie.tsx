import { Fragment, useState } from "react"
import {Modal, Button, Form} from 'react-bootstrap'
import { usePutData } from "../API"

type Props = {
    show:boolean,
    handleClose:() => void,
    title:string
}

const ModalEditMovie = ({show,handleClose,title}:Props):JSX.Element => {

    const PutData = usePutData();
    const [data,setData] = useState<object>({})

    const updateData = (e:React.ChangeEvent<HTMLInputElement>) => {
        setData({
            ...data,
            title:title,
            [e.target.name]:e.target.value
        })
    }

    const handleSubmit = (e:any) => {
        e.preventDefault();
        PutData("https://localhost:7201/api/v1/movies",data)
    } 

    return(
        <Fragment>
            <Modal show={show} onHide={handleClose}>
                <Form onSubmit={handleSubmit} style={{padding: "3rem"}}>
                
            
                    <Form.Group className="mb-3">
                        <Form.Label>Title</Form.Label>
                        <Form.Control disabled value={title} required onChange={updateData} name="Title" />
                    </Form.Group>
                    <Form.Group className="mb-3" >
                        <Form.Label>Description</Form.Label>
                        <Form.Control required onChange={updateData} name="Description" as="textarea" rows={3} />
                    </Form.Group>
                    <Form.Group className="mb-3" >
                        <Form.Label>Author</Form.Label>
                        <Form.Control required onChange={updateData} name="Author" placeholder="Author name" />
                    </Form.Group>
                    <Form.Group className="mb-3">
                        <Form.Label>Release Date</Form.Label>
                        <Form.Control required onChange={updateData} name="ReleaseDate" placeholder="Release Date" />
                    </Form.Group>
                    <Form.Group className="mb-3" >
                        <Form.Label>Image Url</Form.Label>
                        <Form.Control required onChange={updateData} name="UrlImg" placeholder="Image url" />
                    </Form.Group>
                    
                    <Button type='submit'  variant="success">Update Movie</Button>
            
            
                </Form>
                <Modal.Footer>
                    <Button variant="secondary" onClick={handleClose}>
                        Close
                    </Button>
                </Modal.Footer>
            </Modal>
        </Fragment>
    )
}

export default ModalEditMovie;