import { Fragment } from 'react';
import {Navbar, Container, Nav} from 'react-bootstrap'

const Header = ():JSX.Element => {
    return (
        <Navbar bg="dark" variant="dark">
            <Container>
            <Navbar.Brand href="/">TheMovies</Navbar.Brand>
            <Nav className="me-auto">
                <Nav.Link href="createMovie">Create Movie</Nav.Link>
            </Nav>
            </Container>
      </Navbar>
    )
}

export default Header;