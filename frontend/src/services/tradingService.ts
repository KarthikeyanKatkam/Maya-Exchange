import axios from 'axios';
import { fetchUserKYCStatus } from './settingsService'; // Import the function

const API_BASE_URL = '/api'; // Base URL for API calls

// Function to fetch trading history for a user
export const fetchTradingHistory = async (userId: string) => {
    try {
        const response = await axios.get(`${API_BASE_URL}/trading/history/${userId}`);
        return response.data;
    } catch (error: any) {
        throw new Error('Error fetching trading history: ' + error.message);
    }
};

// Function to initiate a trade
export const initiateTrade = async (tradeData: any) => {
    try {
        const response = await axios.post(`${API_BASE_URL}/trading/initiate`, tradeData);
        return response.data;
    } catch (error: any) {
        throw new Error('Error initiating trade: ' + error.message);
    }
};

// Function to check if a user is eligible to trade based on KYC status
export const checkTradingEligibility = async (account: string): Promise<boolean> => {
    const isKYCCompleted = await fetchUserKYCStatus(account);
    return isKYCCompleted; // User must be KYC compliant to initiate trades
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
