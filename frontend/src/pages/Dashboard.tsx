import React, { useEffect, useState } from 'react';
import useWeb3 from '../hooks/useWeb3';
import { fetchUserKYCStatus } from '../services/KYCService';
import styles from './Dashboard.module.css';

const Dashboard: React.FC = () => {
  const { account, isKYCCompleted, error, isLoading } = useWeb3();
  const [userFeatures, setUserFeatures] = useState<string[]>([]);
  const [fetchError, setFetchError] = useState<string>('');

  useEffect(() => {
    const fetchUserFeatures = async () => {
      if (!account) {
        setFetchError('Please connect your wallet to view your dashboard features.');
        return;
      }

      try {
        const kycStatus = await fetchUserKYCStatus(account);
        if (kycStatus) {
          const response = await fetch('/api/user/features'); // Example API call to fetch user features
          if (!response.ok) {
            throw new Error('Failed to fetch user features');
          }
          const features = await response.json();
          setUserFeatures(features);
        } else {
          setUserFeatures([]);
          setFetchError('KYC not completed. Please complete your KYC to access dashboard features.');
        }
      } catch (err) {
        setFetchError(err instanceof Error ? err.message : 'Error fetching user features');
      }
    };

    fetchUserFeatures();
  }, [account]);

  return (
    <div className={styles.dashboardContainer}>
      <h1>User Dashboard</h1>
      {isLoading && <p>Loading...</p>}
      {error && <p className={styles.errorIndicator}>{error}</p>}
      {fetchError && <p className={styles.errorIndicator}>{fetchError}</p>}
      {isKYCCompleted ? (
        <ul>
          {userFeatures.map((feature, index) => (
            <li key={index}>{feature}</li>
          ))}
        </ul>
      ) : (
        <p>Please complete your KYC to access your dashboard features.</p>
      )}
    </div>
  );
};

export default Dashboard;
