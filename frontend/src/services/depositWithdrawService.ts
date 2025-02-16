import axios from 'axios';

const API_BASE_URL = '/api'; // Base URL for API calls

// Function to deposit funds
export const depositFunds = async (userId: string, amount: number) => {
    try {
        const response = await axios.post(`${API_BASE_URL}/transactions/deposit`, { userId, amount });
        return response.data;
    } catch (error: any) {
        throw new Error('Error depositing funds: ' + error.message);
    }
};

// Function to withdraw funds
export const withdrawFunds = async (userId: string, amount: number) => {
    try {
        const response = await axios.post(`${API_BASE_URL}/transactions/withdraw`, { userId, amount });
        return response.data;
    } catch (error: any) {
        throw new Error('Error withdrawing funds: ' + error.message);
    }
};

// Function to fetch transaction history for a user
export const fetchTransactionHistory = async (userId: string) => {
    try {
        const response = await axios.get(`${API_BASE_URL}/transactions/history/${userId}`);
        return response.data;
    } catch (error: any) {
        throw new Error('Error fetching transaction history: ' + error.message);
    }
};

// Function to log user-accessible features related to deposits and withdrawals
export const logDepositWithdrawFeatureUsage = async (featureData: any) => {
    try {
        const response = await axios.post(`${API_BASE_URL}/analytics/deposit-withdraw-feature-usage`, featureData);
        return response.data;
    } catch (error: any) {
        throw new Error('Error logging deposit/withdraw feature usage: ' + error.message);
    }
};
