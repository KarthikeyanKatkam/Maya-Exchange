import React, { useEffect, useState } from 'react';
import { Alert } from 'react-bootstrap';
import { useWeb2 as useWeb3 } from '../../hooks/useWeb3';
import { fetchUserKYCStatus } from '../../services/kycService'; // Assuming this service exists

const Dashboard: React.FC = () => {
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
    <div className="dashboardContainer">
      <h1 className="dashboardHeader">User Dashboard</h1>
      {isLoading && <p>Loading...</p>}
      {error && <Alert variant="danger">{error}</Alert>}
      {kycStatus && (
        <div>
          <h2>KYC Status: {kycStatus}</h2>
          {kycStatus === 'Completed' ? (
            <p>You can access all features.</p>
          ) : (
            <p>Please complete your KYC to access all features.</p>
          )}
        </div>
      )}
    </div>
  );
};

export default Dashboard;
