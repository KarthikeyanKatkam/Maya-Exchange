import React, { useEffect, useState } from 'react';
import { fetchUserKYCStatus } from '../../services/KYCService';
import './TwoFactorAuth.css'; // Assuming you have a CSS file for styling
import useWeb3 from '../../hooks/useWeb3';

const TwoFactorAuth: React.FC = () => {
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
    <div className="twoFactorAuthContainer">
      <h1 className="twoFactorAuthHeader">Two-Factor Authentication</h1>
      {isLoading && <p>Loading...</p>}
      {error && <div className="errorIndicator">{error}</div>}
      {kycStatus && (
        <div>
          <h2>KYC Status: {kycStatus}</h2>
          {kycStatus === 'Completed' ? (
            <p>Two-Factor Authentication is enabled. Please proceed with your actions.</p>
          ) : (
            <p>Please complete your KYC to enable Two-Factor Authentication features.</p>
          )}
        </div>
      )}
    </div>
  );
};

export default TwoFactorAuth;
