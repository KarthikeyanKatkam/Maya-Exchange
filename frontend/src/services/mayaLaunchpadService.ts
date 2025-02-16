import axios from 'axios';
import { fetchUserKYCStatus } from './KYCService'; // Importing the function

const API_BASE_URL = '/api'; // Base URL for API calls

// Function to launch a new trading session
export const launchTradingSession = async (account: string, tradingPair: string, investment: number) => {
    try {
        const response = await axios.post(`${API_BASE_URL}/trading/launch`, { account, tradingPair, investment });
        return response.data;
    } catch (error: any) {
        throw new Error('Error launching trading session: ' + error.message);
    }
};

// Function to fetch user-accessible features based on KYC status
export const fetchUserAccessibleFeatures = async (account: string) => {
    try {
        const isKYCCompleted = await fetchUserKYCStatus(account);
        if (!isKYCCompleted) {
            throw new Error('User is not KYC compliant, access denied.');
        }
        const response = await axios.get(`${API_BASE_URL}/features/accessible/${account}`);
        return response.data;
    } catch (error: any) {
        throw new Error('Error fetching user accessible features: ' + error.message);
    }
};

// Function to log trading feature usage
export const logTradingFeatureUsage = async (featureData: any) => {
    try {
        const response = await axios.post(`${API_BASE_URL}/analytics/trading-feature-usage`, featureData);
        return response.data;
    } catch (error: any) {
        throw new Error('Error logging trading feature usage: ' + error.message);
    }
};
