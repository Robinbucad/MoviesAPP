
export type Movie = {
    id : string,
    title: string,
    description: string,
    releaseDate: string,
    urlImg : string,
    createdDate : Date,
    updateDDate : Date
    author:string
}



export type MovieCard = {
    title: string,
    description: string,
    releaseDate: string,
    urlImg : string,
    author:string
}

export type ResponseGetAllAPI = {
    errorMessage:string[],
    isSuccess: boolean,
    result:Movie[],
    statusCode: number
}

export type UseFetchState<T> = {
    state: "nothing" | "loading" | "error" | "success";
    data: ResponseGetAllAPI | T | null
    error: null | Error
}


export type CreateMovie = {
    Author:string,
    Description:string,
    ImageUrl:string,
    ReleaseDate:string,
    Title:string
}

