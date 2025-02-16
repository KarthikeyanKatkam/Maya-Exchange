import axios from 'axios';

const API_BASE_URL = '/api'; // Base URL for API calls

// Function to fetch DeFi data
export const fetchDeFiData = async () => {
    try {
        const response = await axios.get(`${API_BASE_URL}/defi/data`);
        return response.data;
    } catch (error: any) {
        throw new Error('Error fetching DeFi data: ' + error.message);
    }
};

// Function to initiate a DeFi transaction
export const initiateDeFiTransaction = async (transactionData: any) => {
    try {
        const response = await axios.post(`${API_BASE_URL}/defi/transaction`, transactionData);
        return response.data;
    } catch (error: any) {
        throw new Error('Error initiating DeFi transaction: ' + error.message);
    }
};

// Function to fetch KYC status for a user
export const fetchKYCStatus = async (userId: string) => {
    try {
        const response = await axios.get(`${API_BASE_URL}/kyc/status/${userId}`);
        return response.data;
    } catch (error: any) {
        throw new Error('Error fetching KYC status: ' + error.message);
    }
};

// Function to log user-accessible features related to DeFi
export const logDeFiFeatureUsage = async (featureData: any) => {
    try {
        const response = await axios.post(`${API_BASE_URL}/analytics/defi-feature-usage`, featureData);
        return response.data;
    } catch (error: any) {
        throw new Error('Error logging DeFi feature usage: ' + error.message);
    }
};
