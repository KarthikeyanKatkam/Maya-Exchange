import axios from 'axios';

const API_BASE_URL = '/api'; // Base URL for API calls

// Function to fetch transaction history for a user
export const fetchTransactionHistory = async (userId: string) => {
    try {
        const response = await axios.get(`${API_BASE_URL}/transactions/history/${userId}`);
        return response.data;
    } catch (error: any) {
        throw new Error('Error fetching transaction history: ' + error.message);
    }
};

// Function to initiate a transaction
export const initiateTransaction = async (transactionData: any) => {
    try {
        const response = await axios.post(`${API_BASE_URL}/transactions/initiate`, transactionData);
        return response.data;
    } catch (error: any) {
        throw new Error('Error initiating transaction: ' + error.message);
    }
};

// Function to fetch KYC status for a user
const fetchUserKYCStatus = async (account: string): Promise<boolean> => {
    try {
        const response = await axios.get(`${API_BASE_URL}/kyc/status/${account}`);
        return response.data.isKYCCompleted; // Assuming the API returns an object with this property
    } catch (error: any) {
        throw new Error('Error fetching KYC status: ' + error.message);
    }
};

// Function to check if a user is eligible to perform transactions based on KYC status
export const checkTransactionEligibility = async (account: string): Promise<boolean> => {
    const isKYCCompleted = await fetchUserKYCStatus(account);
    return isKYCCompleted; // User must be KYC compliant to perform transactions
};

// Function to log transaction feature usage
export const logTransactionFeatureUsage = async (featureData: any) => {
    try {
        const response = await axios.post(`${API_BASE_URL}/analytics/transaction-feature-usage`, featureData);
        return response.data;
    } catch (error: any) {
        throw new Error('Error logging transaction feature usage: ' + error.message);
    }
};
