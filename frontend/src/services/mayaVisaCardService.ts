import axios from 'axios';

const API_BASE_URL = '/api'; // Base URL for API calls

// Function to fetch Visa card details for a user
export const fetchVisaCardDetails = async (userId: string) => {
    try {
        const response = await axios.get(`${API_BASE_URL}/visa-card/details/${userId}`);
        return response.data;
    } catch (error: any) {
        throw new Error('Error fetching Visa card details: ' + error.message);
    }
};

// Function to add funds to a Visa card
export const addFundsToVisaCard = async (userId: string, amount: number) => {
    try {
        const response = await axios.post(`${API_BASE_URL}/visa-card/add-funds`, { userId, amount });
        return response.data;
    } catch (error: any) {
        throw new Error('Error adding funds to Visa card: ' + error.message);
    }
};

// Function to withdraw funds from a Visa card
export const withdrawFundsFromVisaCard = async (userId: string, amount: number) => {
    try {
        const response = await axios.post(`${API_BASE_URL}/visa-card/withdraw`, { userId, amount });
        return response.data;
    } catch (error: any) {
        throw new Error('Error withdrawing funds from Visa card: ' + error.message);
    }
};

// Function to log Visa card feature usage
export const logVisaCardFeatureUsage = async (featureData: any) => {
    try {
        const response = await axios.post(`${API_BASE_URL}/analytics/visa-card-feature-usage`, featureData);
        return response.data;
    } catch (error: any) {
        throw new Error('Error logging Visa card feature usage: ' + error.message);
    }
};
