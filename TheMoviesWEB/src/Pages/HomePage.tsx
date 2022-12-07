import { Fragment } from "react"
import Header from "../Components/Header"
import MovieList from "../Components/MovieList"

const HomePage = ():JSX.Element => {
    return(
        <Fragment>
            <Header></Header>
            <MovieList></MovieList>
        </Fragment>
    )
}

export default HomePage