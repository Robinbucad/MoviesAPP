import { Container, Row, Col } from "react-bootstrap";
import { useFetchData } from "../API"
import {ResponseGetAllAPI, UseFetchState} from "../TYPES";
import Movie from "./MovieCard";

const MovieList = ():JSX.Element => {

    const APIResponse:UseFetchState<ResponseGetAllAPI> = useFetchData("https://localhost:7201/api/v1/movies");
    const data = APIResponse.data?.result;
    return(
        <Container fluid >
            <Row style={{"padding":"1.2rem"}} >
                {!data ? <p>Retrieving movies</p> : data.map((mov,i) => (
                    <Col style={{"padding":"1.2rem"}} xxl={3} xl={3} md={6}key={i}>
                        <Movie title={mov.title} description={mov.description} releaseDate={mov.releaseDate} urlImg={mov.urlImg} author={mov.author} ></Movie>
                    </Col>
                ))}
            </Row>
        </Container>
    )

}

export default MovieList