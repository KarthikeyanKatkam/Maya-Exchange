import axios from 'axios';

const API_BASE_URL = '/api'; // Base URL for API calls

// Function to authenticate user
export const authenticateUser = async (credentials: { username: string; password: string }) => {
    try {
        const response = await axios.post(`${API_BASE_URL}/users/authenticate`, credentials);
        return response.data;
    } catch (error: any) {
        throw new Error('Error authenticating user: ' + error.message);
    }
};

// Function to register a new user
export const registerUser = async (userData: any) => {
    try {
        const response = await axios.post(`${API_BASE_URL}/users/register`, userData);
        return response.data;
    } catch (error: any) {
        throw new Error('Error registering user: ' + error.message);
    }
};

// Function to fetch user profile
export const fetchUserProfile = async (userId: string) => {
    try {
        const response = await axios.get(`${API_BASE_URL}/users/${userId}`);
        return response.data;
    } catch (error: any) {
        throw new Error('Error fetching user profile: ' + error.message);
    }
};

// Function to update user profile
export const updateUserProfile = async (userId: string, profileData: any) => {
    try {
        const response = await axios.put(`${API_BASE_URL}/users/${userId}`, profileData);
        return response.data;
    } catch (error: any) {
        throw new Error('Error updating user profile: ' + error.message);
    }
};

// Function to handle KYC verification
export const verifyKYC = async (kycData: any) => {
    try {
        const response = await axios.post(`${API_BASE_URL}/kyc`, kycData);
        return response.data;
    } catch (error: any) {
        throw new Error('Error during KYC verification: ' + error.message);
    }
};

// Function to log user-accessible feature usage
export const logUserFeatureUsage = async (featureData: any) => {
    try {
        const response = await axios.post(`${API_BASE_URL}/analytics/feature-usage`, featureData);
        return response.data;
    } catch (error: any) {
        throw new Error('Error logging user feature usage: ' + error.message);
    }
};
