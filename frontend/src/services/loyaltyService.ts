import axios from 'axios';

const API_BASE_URL = '/api'; // Base URL for API calls

// Function to fetch loyalty points for a user
export const fetchLoyaltyPoints = async (userId: string) => {
    try {
        const response = await axios.get(`${API_BASE_URL}/loyalty/points/${userId}`);
        return response.data;
    } catch (error: any) {
        throw new Error('Error fetching loyalty points: ' + error.message);
    }
};

// Function to redeem loyalty points
export const redeemLoyaltyPoints = async (userId: string, points: number) => {
    try {
        const response = await axios.post(`${API_BASE_URL}/loyalty/redeem`, { userId, points });
        return response.data;
    } catch (error: any) {
        throw new Error('Error redeeming loyalty points: ' + error.message);
    }
};

// Function to log user-accessible features related to loyalty
export const logLoyaltyFeatureUsage = async (featureData: any) => {
    try {
        const response = await axios.post(`${API_BASE_URL}/analytics/loyalty-feature-usage`, featureData);
        return response.data;
    } catch (error: any) {
        throw new Error('Error logging loyalty feature usage: ' + error.message);
    }
};
