import React, { useEffect, useState } from 'react';
import { fetchUserKYCStatus } from '../../services/KYCService';
import './MayaSavings.css'; // Assuming you have a CSS file for styling
import useWeb3 from '../../hooks/useWeb3';

const MayaSavings: React.FC = () => {
  const { account } = useWeb3();
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
        setKycStatus(status ? 'Completed' : 'Not Completed');
      } catch (err: any) {
        setError(err.message || 'Failed to fetch KYC status');
      } finally {
        setIsLoading(false);
      }
    };

    checkKYCStatus();
  }, [account]);

  return (
    <div className="mayaSavingsContainer">
      <h1 className="mayaSavingsHeader">Maya Savings</h1>
      {isLoading && <p>Loading...</p>}
      {error && <div className="errorIndicator">{error}</div>}
      {kycStatus && (
        <div>
          <h2>KYC Status: {kycStatus}</h2>
          {kycStatus === 'Completed' ? (
            <p>Welcome to the Maya Savings! You can now access your savings features.</p>
          ) : (
            <p>Please complete your KYC to access savings features.</p>
          )}
        </div>
      )}
    </div>
  );
};

export default MayaSavings;
