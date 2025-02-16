import React, { useEffect, useState } from 'react';
import useWeb3 from '../hooks/useWeb3';
import { fetchUserKYCStatus } from '../services/KYCService';
import styles from './AnalyticsReporting.module.css';

const AnalyticsReporting: React.FC = () => {
  const { account, isKYCCompleted, error, isLoading } = useWeb3();
  const [analyticsData, setAnalyticsData] = useState<any>(null);
  const [fetchError, setFetchError] = useState<string>('');

  useEffect(() => {
    const fetchAnalytics = async () => {
      if (!account) {
        setFetchError('Please connect your wallet to view analytics.');
        return;
      }

      if (!isKYCCompleted) {
        setFetchError('KYC verification is required to access analytics.');
        return;
      }

      try {
        // Assuming there's an API endpoint to fetch analytics data
        const response = await fetch(`/api/analytics?account=${account}`);
        if (!response.ok) {
          throw new Error('Failed to fetch analytics data');
        }
        const data = await response.json();
        setAnalyticsData(data);
      } catch (err: any) {
        setFetchError(err.message || 'An error occurred while fetching analytics data');
      }
    };

    fetchAnalytics();
  }, [account, isKYCCompleted]);

  return (
    <div className={styles.analyticsContainer}>
      <h1 className={styles.analyticsHeader}>Analytics Reporting</h1>
      {isLoading && <p>Loading...</p>}
      {fetchError && <p className={styles.error}>{fetchError}</p>}
      {analyticsData && (
        <div>
          <h2>Analytics Data</h2>
          {/* Render analytics data here */}
          <pre>{JSON.stringify(analyticsData, null, 2)}</pre>
        </div>
      )}
    </div>
  );
};

export default AnalyticsReporting;
