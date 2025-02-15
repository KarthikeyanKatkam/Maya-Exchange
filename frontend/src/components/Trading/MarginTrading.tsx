import React, { useEffect, useState } from 'react';
import './MarginTrading.css'; // Assuming you have a CSS file for styling

const MarginTrading: React.FC = () => {
  const [marginData, setMarginData] = useState<any[]>([]);
  const [isLoading, setIsLoading] = useState<boolean>(true);
  const [error, setError] = useState<string | null>(null);

  useEffect(() => {
    const fetchMarginData = async () => {
      setIsLoading(true);
      try {
        const response = await fetch('/api/margin'); // Example API endpoint for margin trading
        if (!response.ok) {
          throw new Error('Failed to fetch margin trading data');
        }
        const data = await response.json();
        setMarginData(data);
      } catch (err: any) {
        setError(err.message || 'An error occurred while fetching margin trading data');
      } finally {
        setIsLoading(false);
      }
    };

    fetchMarginData();
  }, []);

  return (
    <div className="marginTradingContainer">
      <h1 className="marginTradingHeader">Margin Trading</h1>
      {isLoading && <p>Loading margin trading data...</p>}
      {error && <div className="errorIndicator">{error}</div>}
      <ul>
        {marginData.map((trade) => (
          <li key={trade.id}>
            <h2>{trade.title}</h2>
            <p>{trade.description}</p>
            <p>Leverage: {trade.leverage}</p>
            <p>Margin Required: {trade.marginRequired}</p>
          </li>
        ))}
      </ul>
    </div>
  );
};

export default MarginTrading;
