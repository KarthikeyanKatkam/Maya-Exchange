import React from 'react';
import KYCVerification from './pages/KYCVerification';
import { UserAccessibleFeature } from './utils/types';
import { UserSettings } from './types/UserSettings';
import { checkKYCStatus } from './utils/upiHelpers';

const App = () => {
    const features: UserAccessibleFeature[] = [
        { featureId: 'kyc', featureName: 'KYC Verification', isEnabled: true },
        { featureId: 'transactions', featureName: 'Transaction History', isEnabled: true },
        // Add more features as needed
    ];

    const userSettings: UserSettings = {
        userId: '12345',
        isKYCCompleted: false,
        username: 'exampleUser',
        email: 'user@example.com',
        preferredCurrency: 'USD',
        notificationPreferences: { email: true, sms: false },
        twoFactorAuth: false,
        emailNotifications: true,
        kycStatus: 'Pending',
        // Add other required properties as needed
    };

    const kycStatus = checkKYCStatus(userSettings);

    return (
        <div>
            <h1>Maya Exchange</h1>
            {kycStatus.isKYCCompleted ? (
                <div>
                    <h2>KYC Status: Completed</h2>
                    {/* Render other components based on user features */}
                </div>
            ) : (
                <KYCVerification />
            )}
        </div>
    );
};

export default App;
