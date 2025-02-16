import axios from 'axios';

const API_BASE_URL = 'http://localhost:5000'; // Adjust the base URL as needed

export const getUserSettings = async (userId: string) => {
    try {
        const response = await axios.get(`${API_BASE_URL}/users/${userId}/settings`);
        return response.data;
    } catch (error) {
        console.error('Error fetching user settings:', error);
        throw error;
    }
};

export const updateUserSettings = async (userId: string, settings: any) => {
    try {
        const response = await axios.put(`${API_BASE_URL}/users/${userId}/settings`, settings);
        return response.data;
    } catch (error) {
        console.error('Error updating user settings:', error);
        throw error;
    }
};

// Example function to fetch user KYC status
const fetchUserKYCStatus = async (account: string): Promise<boolean> => {
    // Logic to fetch KYC status from the database or API
    // This is just a placeholder implementation
    return true; // Assume KYC is completed for demonstration
};

export { fetchUserKYCStatus };
