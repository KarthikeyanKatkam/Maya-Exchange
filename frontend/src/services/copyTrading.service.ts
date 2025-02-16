import axios from 'axios';

const API_BASE_URL = '/api'; // Base URL for API calls

// Function to copy trading settings from one user to another
export const copyTradingSettings = async (sourceUserId: string, targetUserId: string) => {
    try {
        const response = await axios.post(`${API_BASE_URL}/trading/copy`, { sourceUserId, targetUserId });
        return response.data;
    } catch (error: any) {
        throw new Error('Error copying trading settings: ' + error.message);
    }
};

// Function to fetch copy trading data for a user
export const fetchCopyTradingData = async (userId: string) => {
    try {
        const response = await axios.get(`${API_BASE_URL}/trading/copy/${userId}`);
        return response.data;
    } catch (error: any) {
        throw new Error('Error fetching copy trading data: ' + error.message);
    }
};

// Function to update copy trading preferences for a user
export const updateCopyTradingPreferences = async (userId: string, preferences: any) => {
    try {
        const response = await axios.put(`${API_BASE_URL}/trading/copy/preferences/${userId}`, preferences);
        return response.data;
    } catch (error: any) {
        throw new Error('Error updating copy trading preferences: ' + error.message);
    }
};

// Class to handle copy trading operations
export class CopyTradingService {
    // Method to initiate copy trading for a user
    public async initiateCopyTrading(sourceUserId: string, targetUserId: string) {
        return await copyTradingSettings(sourceUserId, targetUserId);
    }

    // Method to get copy trading data for a user
    public async getCopyTradingData(userId: string) {
        return await fetchCopyTradingData(userId);
    }

    // Method to set user preferences for copy trading
    public async setCopyTradingPreferences(userId: string, preferences: any) {
        return await updateCopyTradingPreferences(userId, preferences);
    }

    // Method to start copy trading for a user
    public async startCopyTrading(selectedTrader: string, amount: number, tradingPair: string) {
        try {
            const response = await axios.post(`${API_BASE_URL}/trading/copy/start`, {
                traderId: selectedTrader,
                amount,
                tradingPair,
            });
            return response.data; // Adjust based on your API response structure
        } catch (error: any) {
            throw new Error('Error starting copy trading: ' + error.message);
        }
    }

    async getTopTraders(tradingPair: string) {
        const response = await axios.get(`/api/copytrading/toptraders?pair=${tradingPair}`);
        return response.data; // Adjust based on your API response structure
    }
}

export default CopyTradingService;
