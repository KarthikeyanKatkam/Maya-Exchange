import React from 'react';
import { Link } from 'react-router-dom';
import logo from '/home/kali/Desktop/Maya-Exchange/frontend/assets/images/logo.png'; // Import logo from assets folder

const Header: React.FC = () => {
  return (
    <header>
      <div className="logo">
        <img src={logo} alt="Maya Exchange Logo" /> {/* Updated to use imported logo */}
      </div>
      <nav>
        <ul>
          <li><Link to="/">Home</Link></li>
          <li><Link to="/trade">Trade</Link></li>
          <li><Link to="/wallet">Wallet</Link></li>
          <li><Link to="/profile">Profile</Link></li>
          <li><Link to="/login">Login</Link></li>
        </ul>
      </nav>
    </header>
  );
};

export default Header;
