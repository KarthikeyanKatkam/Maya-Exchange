import axios from 'axios';

const API_BASE_URL = '/api'; // Base URL for API calls

// Function to fetch user KYC status
export const fetchUserKYCStatus = async (account: string): Promise<boolean> => {
    try {
        const response = await axios.get(`${API_BASE_URL}/kyc/status/${account}`);
        return response.data.isKYCCompleted; // Assuming the API returns an object with this property
    } catch (error: any) {
        throw new Error('Error fetching KYC status: ' + error.message);
    }
};

// Function to check if a user is eligible for accessing features based on KYC status
export const checkUserFeatureEligibility = async (account: string): Promise<boolean> => {
    const isKYCCompleted = await fetchUserKYCStatus(account);
    return isKYCCompleted; // User must be KYC compliant to access certain features
};

// Function to log security feature usage
export const logSecurityFeatureUsage = async (featureData: any) => {
    try {
        const response = await axios.post(`${API_BASE_URL}/analytics/security-feature-usage`, featureData);
        return response.data;
    } catch (error: any) {
        throw new Error('Error logging security feature usage: ' + error.message);
    }
};
