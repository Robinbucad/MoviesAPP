import { Fragment } from "react"
import CreateMovie from "../Components/CreateMovie"
import Header from "../Components/Header"

const CreateMoviePage = ():JSX.Element => {
    return(
        <Fragment>
            <Header/>
            <CreateMovie/>
        </Fragment>
    )
}

export default CreateMoviePage