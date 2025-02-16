import React, { useEffect, useState } from 'react';
import useWeb3 from '../../hooks/useWeb3';
import { fetchUserKYCStatus } from '../../services/KYCService';
import './PrivacySettings.css'; // Assuming you have a CSS file for styling

const PrivacySettings: React.FC = () => {
  const { account } = useWeb3();
  const [kycStatus, setKycStatus] = useState<string>('');
  const [error, setError] = useState<string>('');
  const [isLoading, setIsLoading] = useState<boolean>(true);
  const [privacyEnabled, setPrivacyEnabled] = useState<boolean>(false);

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

  const handlePrivacyToggle = () => {
    setPrivacyEnabled(!privacyEnabled);
  };

  return (
    <div className="privacySettingsContainer">
      <h1 className="privacySettingsHeader">Privacy Settings</h1>
      {isLoading && <p>Loading...</p>}
      {error && <div className="errorIndicator">{error}</div>}
      {kycStatus && (
        <div>
          <h2>KYC Status: {kycStatus}</h2>
          {kycStatus === 'Completed' ? (
            <div>
              <label>
                <input
                  type="checkbox"
                  checked={privacyEnabled}
                  onChange={handlePrivacyToggle}
                />
                Enable Privacy Features
              </label>
            </div>
          ) : (
            <p>Please complete your KYC to access privacy settings.</p>
          )}
        </div>
      )}
    </div>
  );
};

export default PrivacySettings;
