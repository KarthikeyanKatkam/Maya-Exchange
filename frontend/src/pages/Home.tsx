import React from 'react';
import CryptoCard from '../components/CryptoCard';
import { Link } from 'react-router-dom';

const Home: React.FC = () => {
  // Sample data for cryptocurrencies
  const cryptos = [
    { name: 'Bitcoin', symbol: 'BTC', price: 35000, change: 2.5 },
    { name: 'Ethereum', symbol: 'ETH', price: 2000, change: -1.2 },
    { name: 'Ripple', symbol: 'XRP', price: 1.2, change: 0.8 },
  ];

  return (
    <div className="home">
      <h1>Welcome to Maya Exchange</h1>
      <p>Your gateway to seamless cryptocurrency trading and payments.</p>
      <div className="crypto-list">
        {cryptos.map((crypto, index) => (
          <CryptoCard
            key={index}
            name={crypto.name}
            symbol={crypto.symbol}
            price={crypto.price}
            change={crypto.change}
          />
        ))}
      </div>
      <Link to="/trade">Start Trading</Link>
    </div>
  );
};

export default Home;
