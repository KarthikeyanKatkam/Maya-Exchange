import axios from 'axios';
import { UserSettings } from '../types/UserSettings';

// Function to fetch user settings
export const fetchUserSettings = async (): Promise<UserSettings> => {
    try {
        const response = await axios.get('/api/users/settings');
        const data = response.data;

        // Ensure the returned data matches the UserSettings interface
        return {
            userId: data.userId,
            username: data.username,
            email: data.email,
            phoneNumber: data.phoneNumber,
            isKYCCompleted: data.isKYCCompleted,
            preferredCurrency: data.preferredCurrency,
            notificationPreferences: {
                email: data.notificationPreferences.email,
                sms: data.notificationPreferences.sms,
            },
        };
    } catch (error: any) {
        throw new Error('Error fetching user settings: ' + error.message);
    }
};

export const updateUserSettings = async (settings: any) => {
    // Your implementation to update user settings
};
