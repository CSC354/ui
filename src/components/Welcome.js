import '../styles/Welcome.css'
import argument from '../imgs/argument.png'

import { Link } from 'react-router-dom';
const Welcome=()=>{

    return (
      <div className="Home">
        <div className="container ">
          <div className="row">
            <div className="text  col-lg-6 col-sm-12 col-md-12">
              <h1 className="welcome">welcome To Our Website</h1>
              <p>
                Lorem Ipsum is simply dummy text of the printing and typesetting
                industry. Lorem Ipsum has been the industry's standard dummy
                text ever since the 1500s, when an unknown printer took a galley
                of type and scrambled it to make a type specimen book. It has
              </p>
              <Link className="btn btn-primary me-2 pe-4 ps-4" to="Login">
                Login{" "}
              </Link>
              <Link className="btn btn-primary ms-2 pe-4 ps-4" to="Register">
                Register{" "}
              </Link>
            </div>
            <div className=" image col-lg-6 ">
              <img src={argument} alt="debate" />
            </div>
          </div>
        </div>
      </div>
    );
}

export default Welcome;