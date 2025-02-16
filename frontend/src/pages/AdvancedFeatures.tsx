import React from 'react';
import useWeb3 from '../hooks/useWeb3';
import { fetchUserKYCStatus } from '../services/KYCService';
import styles from './AdvancedFeatures.module.css';

const AdvancedFeatures: React.FC = () => {
  const { account, isKYCCompleted, error, isLoading } = useWeb3();
  const [features, setFeatures] = React.useState<string[]>([]);

  React.useEffect(() => {
    const fetchFeatures = async () => {
      if (!account) {
        return;
      }

      try {
        const kycStatus = await fetchUserKYCStatus(account);
        if (kycStatus) {
          // Fetch user-specific features based on KYC status
          const userFeatures = await fetch('/api/user/features'); // Example API call
          setFeatures(await userFeatures.json());
        } else {
          setFeatures([]);
        }
      } catch (err) {
        console.error('Error fetching features:', err);
      }
    };

    fetchFeatures();
  }, [account]);

  return (
    <div className={styles.advancedFeaturesContainer}>
      <h1>Advanced Features</h1>
      {isLoading && <p>Loading features...</p>}
      {error && <p className={styles.error}>{error}</p>}
      {isKYCCompleted ? (
        <ul>
          {features.map((feature, index) => (
            <li key={index}>{feature}</li>
          ))}
        </ul>
      ) : (
        <p>Please complete your KYC to access advanced features.</p>
      )}
    </div>
  );
};

export default AdvancedFeatures;
