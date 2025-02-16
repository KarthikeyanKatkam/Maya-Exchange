import React, { useEffect, useState } from 'react';
import useWeb3 from '../../hooks/useWeb3';
import { fetchUserKYCStatus } from '../../services/KYCService'; // Updated to match casing
import './MayaCharityFoundation.css'; // Assuming you have a CSS file for styling

const MayaCharityFoundation: React.FC = () => {
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
    <div className="mayaCharityFoundationContainer">
      <h1 className="mayaCharityFoundationHeader">Maya Charity Foundation</h1>
      {isLoading && <p>Loading...</p>}
      {error && <div className="errorIndicator">{error}</div>}
      {kycStatus && (
        <div>
          <h2>KYC Status: {kycStatus}</h2>
          {kycStatus === 'Completed' ? (
            <p>Thank you for your support! You can now access the charity features.</p>
          ) : (
            <p>Please complete your KYC to access the Charity Foundation features.</p>
          )}
        </div>
      )}
    </div>
  );
};

export default MayaCharityFoundation;
