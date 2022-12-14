import male from "../imgs/male.png";
import female from "../imgs/female.png";
import { useState } from "react";
import { Navigate } from "react-router-dom";

import "../styles/Register.css";
// import axios from "axios";
// import { Navigate } from "react-router-dom";

const Register = () => {
  const [avatar, setavatar] = useState(male);
  const [name, setname] = useState("");
  const [lastname, setlastname] = useState("");
  const [email, setemail] = useState("");
  const [password, setpassowrd] = useState("");
  const [copassword, setcopassword] = useState("");
  const [country, setcountry] = useState("");
  const [city, setcity] = useState("");
  const [redirect, setredirect] = useState(false);

  // const [redirect,setredirect] =useState(true)
  const submithandler = async (e) => {
    e.preventDefault();
    try {
      if (password!==copassword)
      {
        alert("PLease , confirm passowrd ")
        return false
      }
      
    } catch (e) {
      throw new Error(e.message);
    }
    // axios api
    // axios
    //   .post(" http://localhost:8000/comments", {
    //     name,
    //     lastname,
    //     email,
    //     password,
    //     country,
    //     city,
    //   })
    //   .then((res) => res.json());

    // fetch method
    await fetch("http://localhost:8000/comments", {
      method: "POST",
      headers: { "Content-Type": "application/json" },
      body: JSON.stringify({ name, lastname, email, password, country, city }),
    })
      .then((res) => res.json())
      .then((data) => console.log(data));
    setredirect("true");
  };
  if (redirect) {
    return <Navigate to="/login" />;
  }

  return (
    <div className="row align-items-center">
      <div className="reigister-form p-5 col-lg-6 text-start">
        <form className="row g-2" onSubmit={submithandler}>
          <label htmlFor="inputEmail4" className="form-label">
            Your Name
          </label>
          <div className="col">
            <input
              type="text"
              className="form-control"
              placeholder="First name"
              aria-label="First name"
              value={name}
              required
              onChange={(e) => setname(e.target.value)}
            />
          </div>
          <div className="col">
            <input
              type="text"
              className="form-control"
              placeholder="Last name"
              aria-label="Last name"
              value={lastname}
              onChange={(e) => setlastname(e.target.value)}
            />
          </div>

          <div className="col-md-12">
            <label htmlFor="inputEmail4" className="form-label">
              Email
            </label>
            <input
              type="email"
              className="form-control"
              id="inputEmail4"
              value={email}
              required
              onChange={(e) => setemail(e.target.value)}
            />
          </div>
          <div className="col-md-12">
            <label htmlFor="inputPassword4" className="form-label">
              Password
            </label>
            <input
              type="password"
              className="form-control"
              id="inputPassword4"
              value={password}
              required
              onChange={(e) => setpassowrd(e.target.value)}
            />
          </div>
          <div className="col-md-12">
            <label htmlFor="inputPassword4" className="form-label">
              Confirm Password
            </label>
            <input
              type="password"
              className="form-control"
              id="inputPassword4"
              onChange={(e) => setcopassword(e.target.value)}
              required
            />
          </div>

          <div className="col-md-6">
            <label htmlFor="inputCity" className="form-label">
              Country
            </label>
            <input
              type="text"
              className="form-control"
              id="inputCity"
              value={country}
              onChange={(e) => setcountry(e.target.value)}
            />
          </div>
          <div className="col-md-6">
            <label htmlFor="inputCity" className="form-label">
              City
            </label>
            <input
              type="text"
              className="form-control"
              id="inputCity"
              value={city}
              onChange={(e) => setcity(e.target.value)}
            />
          </div>

          <div className="check">
            <input
              className="form-check-input"
              type="radio"
              name="flexRadioDefault"
              id="flexRadioDefault1"
              onClick={() => {
                setavatar(male);
              }}
            />
            <label
              className="form-check-label ms-2"
              htmlFor="flexRadioDefault1"
            >
              Male
            </label>
            <input
              className="form-check-input ms-5 "
              type="radio"
              name="flexRadioDefault"
              id="flexRadioDefault1"
              onClick={() => {
                setavatar(female);
              }}
            />
            <label
              className="form-check-label ms-2"
              htmlFor="flexRadioDefault1"
            >
              Female
            </label>
          </div>
          <div className="col-12">
            <button type="submit" className="btn btn-primary">
              Sign Up
            </button>
          </div>
        </form>
      </div>
      <div className="avatar col-lg-6 ">
        <img src={avatar} alt="avatar" className="w-50" />
      </div>
    </div>
  );
};

export default Register;
