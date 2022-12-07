import {Card, Button, Container} from 'react-bootstrap'
import {MovieCard } from '../TYPES';
import {AiFillEdit,AiFillDelete }from 'react-icons/ai'
import { useDeleteData } from '../API';
import { useState } from 'react';
import ModalEditMovie from './ModalEditMovie';
import { url } from 'inspector';



const Movie = ({title, description,releaseDate,urlImg, author}: MovieCard):JSX.Element => {

    const DeleteMovie = useDeleteData();
    const [show, setShow] = useState<boolean>(false);

    const handleClose = () => setShow(false);
    const handleShow = () => setShow(true)

    const HandleClick = (e:any) => {
        e.preventDefault();
        DeleteMovie("https://localhost:7201/api/v1/movies/name/"+ title)
    }

    const HandleEditClick = (e:any) => {
        e.preventDefault();

    }

    return (
        <Card style={{ width: '18rem', background:"#774360"}}>
            <Card.Img variant="top" src={urlImg} />
            <Card.Body>
            <Card.Title style={{ color:"white" }} >{title}</Card.Title>
            <Card.Text style={{ color:"white" }}>
               {description}
            </Card.Text>
           
            <Card.Text style={{ color:"white" }}>
               {releaseDate} by {author}
            </Card.Text>
            </Card.Body>
            <Container style={{display:'flex', flexDirection:'row-reverse', gap:'1rem', padding:'1rem'}}>
                <Button onClick={handleShow}><AiFillEdit/></Button>
                <Button onClick={HandleClick} variant='danger'><AiFillDelete/></Button>
            </Container>
            <ModalEditMovie
            show={show} 
            handleClose={handleClose}
            title={title}
            />

        </Card>
    )
}

export default Movie;