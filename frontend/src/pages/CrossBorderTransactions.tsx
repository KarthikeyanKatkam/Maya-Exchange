import React, { useEffect, useState } from 'react';
import useWeb3 from '../hooks/useWeb3';
import { fetchUserKYCStatus } from '../services/KYCService';
import styles from './CrossBorderTransactions.module.css';

const CrossBorderTransactions: React.FC = () => {
  const { account, isKYCCompleted, error, isLoading } = useWeb3();
  const [transactionData, setTransactionData] = useState<any[]>([]);
  const [fetchError, setFetchError] = useState<string>('');

  useEffect(() => {
    const fetchTransactions = async () => {
      if (!account) {
        setFetchError('Please connect your wallet to view transactions.');
        return;
      }

      try {
        const kycStatus = await fetchUserKYCStatus(account);
        if (kycStatus) {
          const response = await fetch('/api/transactions'); // Example API call to fetch transactions
          const data = await response.json();
          setTransactionData(data);
        } else {
          setTransactionData([]);
          setFetchError('KYC not completed. Please complete your KYC to access transaction features.');
        }
      } catch (err) {
        setFetchError(err instanceof Error ? err.message : 'Error fetching transactions');
      }
    };

    fetchTransactions();
  }, [account]);

  return (
    <div className={styles.crossBorderContainer}>
      <h1>Cross Border Transactions</h1>
      {isLoading && <p>Loading...</p>}
      {error && <p className={styles.errorIndicator}>{error}</p>}
      {fetchError && <p className={styles.errorIndicator}>{fetchError}</p>}
      {transactionData.length > 0 ? (
        <ul>
          {transactionData.map((transaction, index) => (
            <li key={index}>{transaction.description} - Amount: {transaction.amount}</li>
          ))}
        </ul>
      ) : (
        <p>No transactions available.</p>
      )}
    </div>
  );
};

export default CrossBorderTransactions;
