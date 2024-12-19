import React from 'react';

interface CryptoCardProps {
  name: string;
  symbol: string;
  price: number;
  change: number;
}

const CryptoCard: React.FC<CryptoCardProps> = ({ name, symbol, price, change }) => {
  const formattedPrice = price.toLocaleString(); // Format price with commas

  return (
    <div className="crypto-card">
      <h3>{name} ({symbol})</h3>
      <p>Price: ${formattedPrice}</p>
      <p>24h Change: {change > 0 ? `+${change}%` : `${change}%`}</p>
    </div>
  );
};

export default CryptoCard;
