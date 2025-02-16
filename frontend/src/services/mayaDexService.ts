import axios from 'axios';

const API_BASE_URL = '/api'; // Base URL for API calls

// Function to fetch user KYC status
export const fetchUserKYCStatus = async (account: string): Promise<boolean> => {
    try {
        const response = await axios.get(`${API_BASE_URL}/kyc-status/${account}`);
        return response.data.isKYCCompleted; // Ensure this returns a boolean
    } catch (error: any) {
        throw new Error('Error fetching KYC status: ' + error.message);
    }
};

// Function to log user-accessible features related to KYC
export const logKYCFeatureUsage = async (featureData: any) => {
    try {
        const response = await axios.post(`${API_BASE_URL}/analytics/kyc-feature-usage`, featureData);
        return response.data;
    } catch (error: any) {
        throw new Error('Error logging KYC feature usage: ' + error.message);
    }
};

// Function to check if a user is eligible for a specific feature based on KYC status
export const checkFeatureEligibility = async (account: string, feature: string): Promise<boolean> => {
    const isKYCCompleted = await fetchUserKYCStatus(account);
    // Logic to determine eligibility based on KYC status and feature
    return isKYCCompleted; // Simplified for demonstration
};
