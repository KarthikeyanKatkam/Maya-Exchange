import axios from 'axios';

const API_BASE_URL = '/api'; // Base URL for API calls

// Function to fetch charity projects
export const fetchCharityProjects = async () => {
    try {
        const response = await axios.get(`${API_BASE_URL}/charity/projects`);
        return response.data;
    } catch (error: any) {
        throw new Error('Error fetching charity projects: ' + error.message);
    }
};

// Function to donate to a charity project
export const donateToCharity = async (projectId: string, userId: string, amount: number) => {
    try {
        const response = await axios.post(`${API_BASE_URL}/charity/donate`, { projectId, userId, amount });
        return response.data;
    } catch (error: any) {
        throw new Error('Error donating to charity: ' + error.message);
    }
};

// Function to log user-accessible features related to charity
export const logCharityFeatureUsage = async (featureData: any) => {
    try {
        const response = await axios.post(`${API_BASE_URL}/analytics/charity-feature-usage`, featureData);
        return response.data;
    } catch (error: any) {
        throw new Error('Error logging charity feature usage: ' + error.message);
    }
};
