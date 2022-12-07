import React, { FormEvent, useEffect, useState } from 'react';
import {Form,Button, Container} from 'react-bootstrap'
import { usePostData } from '../API';
import ModalEditMovie from './ModalEditMovie';

const CreateMovie = ():JSX.Element => {

    const PostData = usePostData();
    const [data,setData] = useState<object>({})

    const updateData = (e:React.ChangeEvent<HTMLInputElement>) => {
        setData({
            ...data,
            [e.target.name]:e.target.value
        })
    }

    const handleSubmit = (e:FormEvent) => {
        e.preventDefault();
       PostData("https://localhost:7201/api/v1/movies",data)
    } 

    return(
        <Form onSubmit={handleSubmit} style={{padding: "3rem"}}>
            
        
                <Form.Group className="mb-3">
                    <Form.Label>Title</Form.Label>
                    <Form.Control required onChange={updateData} name="Title" placeholder="Movie title" />
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
                
                <Button type='submit'  variant="success">Create Movie</Button>
           
            
      </Form>
    )
}

export default CreateMovie;