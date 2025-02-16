import React, { useEffect, useState } from 'react';
import useWeb3 from '../../hooks/useWeb3'; // Adjust the import path as necessary
import { fetchUserKYCStatus } from '../../services/KYCService'; // Updated to match casing
import './MayaLaunchpad.css'; // Assuming you have a CSS file for styling

const MayaLaunchpad: React.FC = () => {
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
    <div className="mayaLaunchpadContainer">
      <h1 className="mayaLaunchpadHeader">Maya Launchpad</h1>
      {isLoading && <p>Loading...</p>}
      {error && <div className="errorIndicator">{error}</div>}
      {kycStatus && (
        <div>
          <h2>KYC Status: {kycStatus}</h2>
          {kycStatus === 'Completed' ? (
            <p>Welcome to the Maya Launchpad! Explore the available features.</p>
          ) : (
            <p>Please complete your KYC to access the Launchpad features.</p>
          )}
        </div>
      )}
    </div>
  );
};

export default MayaLaunchpad;
