import { UserSettings, updateUserSettings } from '../types/UserSettings';
import { KYCStatus, UserAccessibleFeature } from './types';

export const checkKYCStatus = (userSettings: UserSettings): KYCStatus => {
    return {
        userId: userSettings.userId,
        isKYCCompleted: userSettings.isKYCCompleted,
        verificationDate: userSettings.isKYCCompleted ? new Date() : undefined,
        documentsSubmitted: userSettings.isKYCCompleted, // Assuming documents are submitted if KYC is completed
    };
};

export const toggleFeature = (features: UserAccessibleFeature[], featureId: string): UserAccessibleFeature[] => {
    return features.map(feature => 
        feature.featureId === featureId 
            ? { ...feature, isEnabled: !feature.isEnabled } 
            : feature
    );
};

export const updateUserKYCStatus = async (userId: string, isKYCCompleted: boolean) => {
    const userSettings: UserSettings = {
        userId,
        username: '', // Placeholder, should be fetched or passed
        email: '', // Placeholder, should be fetched or passed
        phoneNumber: undefined,
        isKYCCompleted,
        preferredCurrency: 'USD', // Placeholder, should be fetched or passed
        notificationPreferences: {
            email: true,
            sms: false,
        },
        twoFactorAuth: false,
        emailNotifications: true,
        kycStatus: isKYCCompleted ? 'Completed' : 'Pending',
    };
    return await updateUserSettings(userId, userSettings);
};
