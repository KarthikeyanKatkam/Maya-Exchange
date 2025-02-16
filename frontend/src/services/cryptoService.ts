import axios from 'axios';

const API_BASE_URL = '/api'; // Base URL for API calls

// Function to fetch cryptocurrency data
export const fetchCryptoData = async () => {
    try {
        const response = await axios.get(`${API_BASE_URL}/crypto/data`);
        return response.data;
    } catch (error: any) {
        throw new Error('Error fetching cryptocurrency data: ' + error.message);
    }
};

// Function to convert cryptocurrency
export const convertCrypto = async (fromCurrency: string, toCurrency: string, amount: number) => {
    try {
        const response = await axios.post(`${API_BASE_URL}/crypto/convert`, {
            fromCurrency,
            toCurrency,
            amount
        });
        return response.data;
    } catch (error: any) {
        throw new Error('Error converting cryptocurrency: ' + error.message);
    }
};

// Function to handle KYC verification for cryptocurrency transactions
export const verifyKYCForCrypto = async (userData: any) => {
    try {
        const response = await axios.post(`${API_BASE_URL}/crypto/kyc`, userData);
        return response.data;
    } catch (error: any) {
        throw new Error('Error during KYC verification for cryptocurrency: ' + error.message);
    }
};

// Function to log user-accessible features related to cryptocurrency
export const logCryptoFeatureUsage = async (featureData: any) => {
    try {
        const response = await axios.post(`${API_BASE_URL}/analytics/crypto-feature-usage`, featureData);
        return response.data;
    } catch (error: any) {
        throw new Error('Error logging cryptocurrency feature usage: ' + error.message);
    }
};
