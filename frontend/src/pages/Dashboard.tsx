import React, { useState, useEffect } from 'react';
import { Link } from 'react-router-dom';

const Dashboard: React.FC = () => {
  const [userData, setUserData] = useState({
    name: 'John Doe',
    balance: 5000,
    portfolioValue: 12000,
    activeTrades: 2,
  });

  useEffect(() => {
    // Fetch user data from the API
    // Example: fetchUserData().then(data => setUserData(data));
  }, []);

  return (
    <div className="dashboard">
      <h2>Welcome, {userData.name}</h2>
      <div className="stats">
        <div className="stat">
          <h3>Balance</h3>
          <p>${userData.balance}</p>
        </div>
        <div className="stat">
          <h3>Portfolio Value</h3>
          <p>${userData.portfolioValue}</p>
        </div>
        <div className="stat">
          <h3>Active Trades</h3>
          <p>{userData.activeTrades}</p>
        </div>
      </div>
      <Link to="/trade">Start Trading</Link>
    </div>
  );
};

export default Dashboard;
