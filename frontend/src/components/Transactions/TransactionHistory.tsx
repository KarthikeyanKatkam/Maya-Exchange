import React, { useEffect, useState } from 'react';
import './TransactionHistory.css'; // Assuming you have a CSS file for styling

const TransactionHistory: React.FC = () => {
  const [transactions, setTransactions] = useState<any[]>([]);
  const [isLoading, setIsLoading] = useState<boolean>(true);
  const [error, setError] = useState<string | null>(null);

  useEffect(() => {
    const fetchTransactions = async () => {
      setIsLoading(true);
      try {
        const response = await fetch('/api/transactions'); // Example API endpoint for transaction history
        if (!response.ok) {
          throw new Error('Failed to fetch transaction history');
        }
        const data = await response.json();
        setTransactions(data);
      } catch (err: any) {
        setError(err.message || 'An error occurred while fetching transaction history');
      } finally {
        setIsLoading(false);
      }
    };

    fetchTransactions();
  }, []);

  return (
    <div className="transactionHistoryContainer">
      <h1 className="transactionHistoryHeader">Transaction History</h1>
      {isLoading && <p>Loading transaction history...</p>}
      {error && <div className="errorIndicator">{error}</div>}
      <ul>
        {transactions.map((transaction) => (
          <li key={transaction.id} className="transactionItem">
            <p className="transactionDate">{transaction.date}</p>
            <p className="transactionAmount">{transaction.amount}</p>
            <p>{transaction.description}</p>
          </li>
        ))}
      </ul>
    </div>
  );
};

export default TransactionHistory;
