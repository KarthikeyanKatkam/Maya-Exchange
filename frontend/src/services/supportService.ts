import axios from 'axios';

const API_BASE_URL = '/api'; // Base URL for API calls

// Function to fetch support ticket details for a user
export const fetchSupportTicketDetails = async (ticketId: string) => {
    try {
        const response = await axios.get(`${API_BASE_URL}/support/tickets/${ticketId}`);
        return response.data;
    } catch (error: any) {
        throw new Error('Error fetching support ticket details: ' + error.message);
    }
};

// Function to create a new support ticket
export const createSupportTicket = async (ticketData: any) => {
    try {
        const response = await axios.post(`${API_BASE_URL}/support/tickets`, ticketData);
        return response.data;
    } catch (error: any) {
        throw new Error('Error creating support ticket: ' + error.message);
    }
};

// Function to update an existing support ticket
export const updateSupportTicket = async (ticketId: string, updateData: any) => {
    try {
        const response = await axios.put(`${API_BASE_URL}/support/tickets/${ticketId}`, updateData);
        return response.data;
    } catch (error: any) {
        throw new Error('Error updating support ticket: ' + error.message);
    }
};

// Function to log support feature usage
export const logSupportFeatureUsage = async (featureData: any) => {
    try {
        const response = await axios.post(`${API_BASE_URL}/analytics/support-feature-usage`, featureData);
        return response.data;
    } catch (error: any) {
        throw new Error('Error logging support feature usage: ' + error.message);
    }
};
