import axios from 'axios';

// src/types/UserSettings.ts
export interface UserSettings {
    userId: string;
    isKYCCompleted: boolean;
    username: string;
    email: string;
    phoneNumber?: string;
    preferredCurrency: string;
    notificationPreferences: {
      email: boolean;
      sms: boolean;
    };
    // Add other required properties as needed
    twoFactorAuth: boolean; // Add this property
    emailNotifications: boolean; // Add this property
    kycStatus: string; // Add this property
}

// Function to update user settings
export const updateUserSettings = async (userId: string, settings: UserSettings) => {
    try {
        const response = await axios.put(`/api/users/settings/${userId}`, settings);
        return response.data;
    } catch (error: any) {
        throw new Error('Error updating user settings: ' + error.message);
    }
};
