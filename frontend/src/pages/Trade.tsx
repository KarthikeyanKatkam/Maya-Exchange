import React, { useState } from 'react';

const Trade: React.FC = () => {
  const [selectedCrypto, setSelectedCrypto] = useState('BTC');
  const [amount, setAmount] = useState(0);

  const handleTrade = () => {
    // Add trade logic here (e.g., call API to process trade)
    console.log(`Trading ${amount} ${selectedCrypto}`);
  };

  return (
    <div className="trade">
      <h2>Trade Cryptocurrencies</h2>
      <div className="trade-form">
        <div>
          <label>Select Cryptocurrency:</label>
          <select value={selectedCrypto} onChange={(e) => setSelectedCrypto(e.target.value)}>
            <option value="BTC">Bitcoin (BTC)</option>
            <option value="ETH">Ethereum (ETH)</option>
            <option value="XRP">Ripple (XRP)</option>
          </select>
        </div>
        <div>
          <label>Amount:</label>
          <input
            type="number"
            value={amount}
            onChange={(e) => setAmount(parseFloat(e.target.value))}
            min="0"
            step="any"
          />
        </div>
        <button onClick={handleTrade}>Execute Trade</button>
      </div>
    </div>
  );
};

export default Trade;
