import React from 'react';
import CryptoCard from './CryptoCard';
const btcIcon = require('../assets/images/crypto-icons/btc.png');
const ethIcon = require('../assets/images/crypto-icons/eth.png');

const CryptoList: React.FC = () => {
  const cryptoData = [
    { name: 'Bitcoin', symbol: 'BTC', price: 55000, change: 2.5, icon: btcIcon },
    { name: 'Ethereum', symbol: 'ETH', price: 4000, change: -1.2, icon: ethIcon },
    // Add more cryptocurrencies as needed
  ];

  return (
    <div className="crypto-list">
      <h2>Popular Cryptocurrencies</h2>
      {cryptoData.map((crypto) => (
        <div key={crypto.symbol} className="crypto-card">
          <img src={crypto.icon} alt={crypto.name} className="crypto-icon" />
          <CryptoCard
            name={crypto.name}
            symbol={crypto.symbol}
            price={crypto.price}
            change={crypto.change}
          />
        </div>
      ))}
    </div>
  );
};

export default CryptoList;