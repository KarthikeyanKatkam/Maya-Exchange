import React, { useEffect, useState } from 'react';
import { fetchUserKYCStatus } from '../../services/KYCService'; // Updated to match casing
import useWeb2 from '../../hooks/useWeb3';
import './MayaDEX.css';
import useWeb3 from '../../hooks/useWeb3';

const MayaDEX: React.FC = () => {
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
    <div className="mayaDEXContainer">
      <h1 className="mayaDEXHeader">Maya DEX</h1>
      {isLoading && <p>Loading...</p>}
      {error && <div className="errorIndicator">{error}</div>}
      {kycStatus && (
        <div>
          <h2>KYC Status: {kycStatus}</h2>
          {kycStatus === 'Completed' ? (
            <p>Welcome to the Maya DEX! You can now trade.</p>
          ) : (
            <p>Please complete your KYC to access trading features.</p>
          )}
        </div>
      )}
    </div>
  );
};

export default MayaDEX;
