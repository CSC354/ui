import './App.css';
import {Routes,Route} from 'react-router-dom'
import NavBar from './components/NavBar';
import Welcome from "./components/Welcome";
import Login from './components/Login';
import Register from './components/Register';
import Contact from './components/Contact';
import Home from './components/Home';
function App() {
  return (
    <div className="App">
      <NavBar />
      <div className="container">
        <Routes>
          <Route index element={< Welcome />} />
          <Route path="Login" element={<Login />} />
          <Route path="Home" element={<Home />} />
          <Route path="contact" element={<Contact />} />
          <Route path="Register" element={<Register />} />
        </Routes>
      </div>
    </div>
  );
}

export default App;
