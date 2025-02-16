import axios from 'axios';

const API_BASE_URL = '/api'; // Base URL for API calls

// Function to fetch referral details for a user
export const fetchReferralDetails = async (userId: string) => {
    try {
        const response = await axios.get(`${API_BASE_URL}/referral/details/${userId}`);
        return response.data;
    } catch (error: any) {
        throw new Error('Error fetching referral details: ' + error.message);
    }
};

// Function to create a new referral
export const createReferral = async (referralData: any) => {
    try {
        const response = await axios.post(`${API_BASE_URL}/referral/create`, referralData);
        return response.data;
    } catch (error: any) {
        throw new Error('Error creating referral: ' + error.message);
    }
};

// Function to log referral feature usage
export const logReferralFeatureUsage = async (featureData: any) => {
    try {
        const response = await axios.post(`${API_BASE_URL}/analytics/referral-feature-usage`, featureData);
        return response.data;
    } catch (error: any) {
        throw new Error('Error logging referral feature usage: ' + error.message);
    }
};
