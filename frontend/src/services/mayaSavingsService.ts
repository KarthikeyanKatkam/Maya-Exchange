import axios from 'axios';

const API_BASE_URL = '/api'; // Base URL for API calls

// Function to fetch savings account details for a user
export const fetchSavingsAccountDetails = async (account: string) => {
    try {
        const response = await axios.get(`${API_BASE_URL}/savings/account/${account}`);
        return response.data;
    } catch (error: any) {
        throw new Error('Error fetching savings account details: ' + error.message);
    }
};

// Function to deposit into a savings account
export const depositToSavingsAccount = async (account: string, amount: number) => {
    try {
        const response = await axios.post(`${API_BASE_URL}/savings/deposit`, { account, amount });
        return response.data;
    } catch (error: any) {
        throw new Error('Error depositing to savings account: ' + error.message);
    }
};

// Function to withdraw from a savings account
export const withdrawFromSavingsAccount = async (account: string, amount: number) => {
    try {
        const response = await axios.post(`${API_BASE_URL}/savings/withdraw`, { account, amount });
        return response.data;
    } catch (error: any) {
        throw new Error('Error withdrawing from savings account: ' + error.message);
    }
};

// Function to log savings feature usage
export const logSavingsFeatureUsage = async (featureData: any) => {
    try {
        const response = await axios.post(`${API_BASE_URL}/analytics/savings-feature-usage`, featureData);
        return response.data;
    } catch (error: any) {
        throw new Error('Error logging savings feature usage: ' + error.message);
    }
};
