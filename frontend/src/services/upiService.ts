import axios from 'axios';

const API_BASE_URL = '/api'; // Base URL for API calls

// Function to initiate a UPI payment
export const initiateUPIPayment = async (paymentData: any) => {
    try {
        const response = await axios.post(`${API_BASE_URL}/upi/initiate`, paymentData);
        return response.data;
    } catch (error: any) {
        throw new Error('Error initiating UPI payment: ' + error.message);
    }
};

// Function to fetch UPI transaction status
export const fetchUPITransactionStatus = async (transactionId: string) => {
    try {
        const response = await axios.get(`${API_BASE_URL}/upi/status/${transactionId}`);
        return response.data;
    } catch (error: any) {
        throw new Error('Error fetching UPI transaction status: ' + error.message);
    }
};

// Function to log UPI feature usage
export const logUPIFeatureUsage = async (featureData: any) => {
    try {
        const response = await axios.post(`${API_BASE_URL}/analytics/upi-feature-usage`, featureData);
        return response.data;
    } catch (error: any) {
        throw new Error('Error logging UPI feature usage: ' + error.message);
    }
};
