import React from 'react';
import { Link } from 'react-router-dom';

const Wallet: React.FC = () => {
  return (
    <div className="wallet">
      <h2>Your Wallet</h2>
      <p>Manage your funds here.</p>
      <div className="wallet-balance">
        <h3>Fiat Balance</h3>
        <p>$5000</p>
      </div>
      <div className="wallet-balance">
        <h3>Crypto Balance</h3>
        <p>0.5 BTC</p>
      </div>
      <Link to="/deposit">Deposit Funds</Link>
      <Link to="/withdraw">Withdraw Funds</Link>
    </div>
  );
};

export default Wallet;
