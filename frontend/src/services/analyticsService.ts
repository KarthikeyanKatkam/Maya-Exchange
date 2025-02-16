import axios from 'axios';

const API_BASE_URL = '/api'; // Base URL for API calls

// Function to track user interactions
export const trackUserInteraction = async (interactionData: any) => {
    try {
        const response = await axios.post(`${API_BASE_URL}/analytics/track`, interactionData);
        return response.data;
    } catch (error: any) {
        throw new Error('Error tracking user interaction: ' + error.message);
    }
};

// Function to fetch analytics data
export const fetchAnalyticsData = async () => {
    try {
        const response = await axios.get(`${API_BASE_URL}/analytics/data`);
        return response.data;
    } catch (error: any) {
        throw new Error('Error fetching analytics data: ' + error.message);
    }
};

// Function to log KYC verification events
export const logKYCEvent = async (kycData: any) => {
    try {
        const response = await axios.post(`${API_BASE_URL}/analytics/kyc`, kycData);
        return response.data;
    } catch (error: any) {
        throw new Error('Error logging KYC event: ' + error.message);
    }
};

// Function to log user-accessible feature usage
export const logFeatureUsage = async (featureData: any) => {
    try {
        const response = await axios.post(`${API_BASE_URL}/analytics/feature-usage`, featureData);
        return response.data;
    } catch (error: any) {
        throw new Error('Error logging feature usage: ' + error.message);
    }
};
