import "../styles/Login.css";
import { useState } from "react";
import { Navigate } from "react-router-dom";
const Login = () => {
  const [email, setemail] = useState("");
  const [password, setpassowrd] = useState("");
  const [redirect, setredirect] = useState(false);


  const submithandler = async (e) => {
    e.preventDefault();


    // fetch method
      await fetch(" http://localhost:8000/login", {
      method: "POST",
      headers: { "Content-Type": "application/json" },
      credentials: "include",
      body: JSON.stringify({
        email,
        password,
      }),
    })
    setredirect("true");
  };
  if (redirect) {
    return <Navigate to="/Home" />;
  }

  return (
    <div className="login-page">
      <div className="Login-form">
        <h1 className="header">Log In </h1>
        <form onSubmit={submithandler}>
          <div className="form-floating mb-3">
            <input
              type="email"
              className="form-control"
              id="floatingInput"
              required
              onChange={(e) => {
                setemail(e.target.value);
              }}
              placeholder="email"
            />
            <label htmlFor="floatingInput">Email address</label>
          </div>
          <div className="form-floating">
            <input
              type="password"
              className="form-control"
              id="floatingPassword"
              placeholder="Password"
              required
              onChange={(e) => {
                setpassowrd(e.target.value);
              }}
            />
            <label htmlFor="floatingPassword">Password</label>
          </div>
          <button type="submit" className="btn btn-login btn-primary ps-4 pe-4">
            Log In
          </button>
        </form>
      </div>
    </div>
  );
};

export default Login;
