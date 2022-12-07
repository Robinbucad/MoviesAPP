import { useEffect, useState } from "react";
import { json } from "stream/consumers";
import { CreateMovie, Movie, UseFetchState} from "./TYPES";
import Swal from 'sweetalert2'




export function useFetchData<T> (url:string) {
    const [fetchState,setFetchState] = useState<UseFetchState<T>>({
        state:"nothing",
        data: null,
        error:null
    });

    useEffect(() => {
        const FetchData = async():Promise<void> => {
            try{

                setFetchState(val => ({
                    ...val,
                    state:"loading"
                }))

                const res = await fetch(url);
                if(res.ok){
                    const dat =await res.json();
                    
                    setFetchState({
                        data:dat,
                        state:"success",
                        error:null
                    })
                }

            }catch(err){
                alert(err)
            }
        }

        FetchData()
    },[url])

    return fetchState;
}

export function usePostData(){
    const PostData = async(url:string,movie:object):Promise<void> => {
            try{
                const res = await fetch(url,{
                    method:"POST",
                    headers:{
                        "Content-type":"application/json"
                    },
                    body:JSON.stringify(movie)
                   
                })
                if(res.status === 422){
                    Swal.fire({
                        title: "<strong>Oh!</strong>,",
                        html: "<i>Movie already exists</i>",
                        icon: 'error'
                      })
                }
                if(res.status === 201){
                    Swal.fire({
                        title: "<strong>Good job!</strong>,",
                        html: "<i>Movie created succesfully</i>",
                        icon: 'success'
                      }).then(() => {
                        window.location.href = "/"
                      })
                    
                }
            }catch(err){
                alert(err)
            }
    }
    return PostData;
}

export function usePutData(){
    const PutData = async(url:string,movie:object):Promise<void> => {
            try{
                const res = await fetch(url,{
                    method:"PUT",
                    headers:{
                        "Content-type":"application/json"
                    },
                    body:JSON.stringify(movie)
                   
                })
              
                if(res.status === 200){
                    Swal.fire({
                        title: "<strong>Good job!</strong>,",
                        html: "<i>Movie updated succesfully</i>",
                        icon: 'success'
                      }).then(() => {
                        window.location.href = "/"
                      })
                    
                }
            }catch(err){
                alert(err)
            }
    }
    return PutData;
}

export function useDeleteData(){
    const DeleteData = async(url:string):Promise<void> => {
            try{
                const res = await fetch(url,{
                    method:"DELETE",
                })

                if(res.status === 200){
                    Swal.fire({
                        title: "<strong>Good job!</strong>,",
                        html: "<i>Movie deleted succesfully</i>",
                        icon: 'success'
                      }).then(() => {
                        window.location.href = "/"
                      })
                    
                }
            }catch(err){
                alert(err)
            }
    }
    return DeleteData;
}