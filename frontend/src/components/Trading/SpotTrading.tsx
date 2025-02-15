import React, { useEffect, useState } from 'react';
import './SpotTrading.css'; // Assuming you have a CSS file for styling

const SpotTrading: React.FC = () => {
  const [spotData, setSpotData] = useState<any[]>([]);
  const [isLoading, setIsLoading] = useState<boolean>(true);
  const [error, setError] = useState<string | null>(null);

  useEffect(() => {
    const fetchSpotData = async () => {
      setIsLoading(true);
      try {
        const response = await fetch('/api/spot'); // Example API endpoint for spot trading
        if (!response.ok) {
          throw new Error('Failed to fetch spot trading data');
        }
        const data = await response.json();
        setSpotData(data);
      } catch (err: any) {
        setError(err.message || 'An error occurred while fetching spot trading data');
      } finally {
        setIsLoading(false);
      }
    };

    fetchSpotData();
  }, []);

  return (
    <div className="spotTradingContainer">
      <h1 className="spotTradingHeader">Spot Trading</h1>
      {isLoading && <p>Loading spot trading data...</p>}
      {error && <div className="errorIndicator">{error}</div>}
      <ul>
        {spotData.map((trade) => (
          <li key={trade.id}>
            <h2>{trade.title}</h2>
            <p>{trade.description}</p>
            <p>Price: {trade.price}</p>
            <p>Volume: {trade.volume}</p>
          </li>
        ))}
      </ul>
    </div>
  );
};

export default SpotTrading;
