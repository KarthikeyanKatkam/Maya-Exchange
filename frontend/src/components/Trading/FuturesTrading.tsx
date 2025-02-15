import React, { useEffect, useState } from 'react';
import './FuturesTrading.css'; // Assuming you have a CSS file for styling

const FuturesTrading: React.FC = () => {
  const [tradingData, setTradingData] = useState<any[]>([]);
  const [isLoading, setIsLoading] = useState<boolean>(true);
  const [error, setError] = useState<string | null>(null);

  useEffect(() => {
    const fetchTradingData = async () => {
      setIsLoading(true);
      try {
        const response = await fetch('/api/futures'); // Example API endpoint
        if (!response.ok) {
          throw new Error('Failed to fetch trading data');
        }
        const data = await response.json();
        setTradingData(data);
      } catch (err: any) {
        setError(err.message || 'An error occurred while fetching trading data');
      } finally {
        setIsLoading(false);
      }
    };

    fetchTradingData();
  }, []);

  return (
    <div className="futuresTradingContainer">
      <h1 className="futuresTradingHeader">Futures Trading</h1>
      {isLoading && <p>Loading trading data...</p>}
      {error && <div className="errorIndicator">{error}</div>}
      <ul>
        {tradingData.map((trade) => (
          <li key={trade.id}>
            <h2>{trade.title}</h2>
            <p>{trade.description}</p>
            <p>Price: {trade.price}</p>
          </li>
        ))}
      </ul>
    </div>
  );
};

export default FuturesTrading;
