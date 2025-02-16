import React, { useEffect, useState } from 'react';
import useWeb3 from '../../hooks/useWeb3'; // Changed useWeb2 to useWeb3 for consistency
import { fetchUserKYCStatus } from '../../services/KYCService'; // Updated to match casing
import './LoyaltyProgram.css'; // Assuming you have a CSS file for styling

const LoyaltyProgram: React.FC = () => {
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
    <div className="loyaltyProgramContainer">
      <h1 className="loyaltyProgramHeader">Loyalty Program</h1>
      {isLoading && <p>Loading...</p>}
      {error && <div className="errorIndicator">{error}</div>}
      {kycStatus && (
        <div>
          <h2>KYC Status: {kycStatus}</h2>
          {kycStatus === 'Completed' ? (
            <p>Welcome to the Loyalty Program! Enjoy your benefits.</p>
          ) : (
            <p>Please complete your KYC to access the Loyalty Program features.</p>
          )}
        </div>
      )}
    </div>
  );
};

export default LoyaltyProgram;
