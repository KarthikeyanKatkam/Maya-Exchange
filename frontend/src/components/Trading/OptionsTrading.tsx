import React, { useEffect, useState } from 'react';
import './OptionsTrading.css'; // Assuming you have a CSS file for styling

const OptionsTrading: React.FC = () => {
  const [optionsData, setOptionsData] = useState<any[]>([]);
  const [isLoading, setIsLoading] = useState<boolean>(true);
  const [error, setError] = useState<string | null>(null);

  useEffect(() => {
    const fetchOptionsData = async () => {
      setIsLoading(true);
      try {
        const response = await fetch('/api/options'); // Example API endpoint for options trading
        if (!response.ok) {
          throw new Error('Failed to fetch options trading data');
        }
        const data = await response.json();
        setOptionsData(data);
      } catch (err: any) {
        setError(err.message || 'An error occurred while fetching options trading data');
      } finally {
        setIsLoading(false);
      }
    };

    fetchOptionsData();
  }, []);

  return (
    <div className="optionsTradingContainer">
      <h1 className="optionsTradingHeader">Options Trading</h1>
      {isLoading && <p>Loading options trading data...</p>}
      {error && <div className="errorIndicator">{error}</div>}
      <ul>
        {optionsData.map((option) => (
          <li key={option.id}>
            <h2>{option.title}</h2>
            <p>{option.description}</p>
            <p>Strike Price: {option.strikePrice}</p>
            <p>Expiration Date: {option.expirationDate}</p>
          </li>
        ))}
      </ul>
    </div>
  );
};

export default OptionsTrading;
