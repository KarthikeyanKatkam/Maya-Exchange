import React, { useEffect, useState } from 'react';
import { fetchUserKYCStatus } from '../../services/KYCService'; // Updated to match casing
import './MayaAcademy.css'; // Assuming you have a CSS file for styling
import useWeb3 from '../../hooks/useWeb3';

const MayaAcademy: React.FC = () => {
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
    <div className="mayaAcademyContainer">
      <h1 className="mayaAcademyHeader">Maya Academy</h1>
      {isLoading && <p>Loading...</p>}
      {error && <div className="errorIndicator">{error}</div>}
      {kycStatus !== undefined && (
        <div>
          <h2>KYC Status: {kycStatus ? 'Completed' : 'Not Completed'}</h2>
          {kycStatus === 'Completed' ? (
            <p>Welcome to the Maya Academy! Enjoy your learning experience.</p>
          ) : (
            <p>Please complete your KYC to access the Academy features.</p>
          )}
        </div>
      )}
    </div>
  );
};

export default MayaAcademy;
