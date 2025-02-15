import React, { useEffect, useState } from 'react';
import { useWeb3 } from '../../hooks/useWeb3';
import { fetchUserKYCStatus } from '../../services/kycService';
import './NotificationSettings.css'; // Assuming you have a CSS file for styling

const NotificationSettings: React.FC = () => {
  const { account } = useWeb3();
  const [kycStatus, setKycStatus] = useState<string>('');
  const [error, setError] = useState<string>('');
  const [isLoading, setIsLoading] = useState<boolean>(true);
  const [notificationsEnabled, setNotificationsEnabled] = useState<boolean>(false);

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

  const handleNotificationToggle = () => {
    setNotificationsEnabled(!notificationsEnabled);
    // Here you would typically also save the notification preference to user settings
  };

  return (
    <div className="notificationSettingsContainer">
      <h1 className="notificationSettingsHeader">Notification Settings</h1>
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
                  checked={notificationsEnabled}
                  onChange={handleNotificationToggle}
                />
                Enable Notifications
              </label>
            </div>
          ) : (
            <p>Please complete your KYC to access notification settings.</p>
          )}
        </div>
      )}
    </div>
  );
};

export default NotificationSettings;
