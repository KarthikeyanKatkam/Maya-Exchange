import React from 'react';
import { Link } from 'react-router-dom';

const Dashboard: React.FunctionComponent = () => {
  return (
    <div className="dashboard">
      <h2>Welcome to Your Dashboard</h2>
      <div className="stats">
        <div className="stat">
          <h3>Current Balance</h3>
          <p>$5000</p>
        </div>
        <div className="stat">
          <h3>Portfolio Value</h3>
          <p>$12000</p>
        </div>
        <div className="stat">
          <h3>Active Trades</h3>
          <p>2</p>
        </div>
      </div>
      <Link to="/trade">Start Trading</Link>
    </div>
  );
};

export default Dashboard;
