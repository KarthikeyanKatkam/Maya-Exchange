import React, { useEffect, useState } from 'react';
import useWeb3 from '../hooks/useWeb3';
import { fetchUserKYCStatus } from '../services/KYCService';
import styles from './DeFiIntegration.module.css';

const DeFiIntegration: React.FC = () => {
  const { account, isKYCCompleted, error, isLoading } = useWeb3();
  const [deFiFeatures, setDeFiFeatures] = useState<any[]>([]);
  const [fetchError, setFetchError] = useState<string>('');

  useEffect(() => {
    const fetchDeFiFeatures = async () => {
      if (!account) {
        setFetchError('Please connect your wallet to view DeFi features.');
        return;
      }

      try {
        const kycStatus = await fetchUserKYCStatus(account);
        if (kycStatus) {
          const response = await fetch('/api/defi/features'); // Example API call to fetch DeFi features
          if (!response.ok) {
            throw new Error('Failed to fetch DeFi features');
          }
          const features = await response.json();
          setDeFiFeatures(features);
        } else {
          setDeFiFeatures([]);
          setFetchError('KYC not completed. Please complete your KYC to access DeFi features.');
        }
      } catch (err) {
        setFetchError(err instanceof Error ? err.message : 'Error fetching DeFi features');
      }
    };

    fetchDeFiFeatures();
  }, [account]);

  return (
    <div className={styles.defiIntegrationContainer}>
      <h1>DeFi Integration</h1>
      {isLoading && <p>Loading...</p>}
      {error && <p className={styles.errorIndicator}>{error}</p>}
      {fetchError && <p className={styles.errorIndicator}>{fetchError}</p>}
      {isKYCCompleted ? (
        <ul>
          {deFiFeatures.map((feature, index) => (
            <li key={index}>{feature}</li>
          ))}
        </ul>
      ) : (
        <p>Please complete your KYC to access DeFi features.</p>
      )}
    </div>
  );
};

export default DeFiIntegration;
