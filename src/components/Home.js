import { useEffect, useState } from "react"

function Home(){
    const [name,setName]=useState('')
    useEffect(
        ()=>{
            (
                async ()=>{
                    const res = await fetch(" http://localhost:8000/user", {
                        headers: { "Content-Type": "application/json" },
                        credentials: "include",
                    });

                    const content =await res.json();

                    setName(content.name)
                }

            )()

        }
    )
    return <>
    this is main page
    <h1> Hi , {name}</h1>
     </>
}


export default Home