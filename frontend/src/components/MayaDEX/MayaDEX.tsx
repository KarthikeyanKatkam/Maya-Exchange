import React, { useEffect, useState } from 'react';
import { fetchUserKYCStatus } from '../../services/kycService';
import { useWeb2 as useWeb3 } from '../../hooks/useWeb3'; // Adjust the path as necessary
import './MayaDEX.css'; // Assuming you have a CSS file for styling

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
        setKycStatus(status);
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
