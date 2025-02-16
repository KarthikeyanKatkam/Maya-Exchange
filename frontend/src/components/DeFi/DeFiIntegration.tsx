import React, { useEffect, useState } from 'react';
import useWeb2 from '../../hooks/useWeb3';
import { fetchUserKYCStatus } from '../../services/KYCService';
import styles from './DeFi.module.css';

const DeFiIntegration: React.FC = () => {
  const { account } = useWeb2();
  const [kycStatus, setKycStatus] = useState<string>('');
  const [error, setError] = useState<string>('');
  const [isLoading, setIsLoading] = useState<boolean>(true);

  useEffect(() => {
    const checkKYCStatus = async () => {
      if (!account) {
        setError('Please connect your wallet to check KYC status.');
        setIsLoading(false);
        return;
      }

      try {
        const status = await fetchUserKYCStatus(account);
        setKycStatus(typeof status === 'string' ? status : '');
      } catch (err: any) {
        setError(err.message || 'Failed to fetch KYC status');
      } finally {
        setIsLoading(false);
      }
    };

    checkKYCStatus();
  }, [account]);

  return (
    <div className={styles.deFiContainer}>
      <h1 className={styles.deFiHeader}>DeFi Integration</h1>
      {isLoading && <div className={styles.loadingSpinner}></div>}
      {error && <div className={styles.errorIndicator}>{error}</div>}
      {kycStatus && (
        <div>
          <h2>KYC Status: {kycStatus}</h2>
          {kycStatus === 'Completed' ? (
            <p>You have access to all DeFi features.</p>
          ) : (
            <p>Please complete your KYC to access DeFi features.</p>
          )}
        </div>
      )}
    </div>
  );
};

export default DeFiIntegration;
