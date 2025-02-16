import axios from 'axios';

const API_BASE_URL = '/api'; // Base URL for API calls

// Function to fetch trading data
export const fetchTradingData = async () => {
    try {
        const response = await axios.get(`${API_BASE_URL}/tradingdata`);
        return response.data;
    } catch (error: any) {
        throw new Error('Error fetching trading data: ' + error.message);
    }
};

// Function to update user settings related to trading
export const updateUserTradingSettings = async (settings: any) => {
    try {
        const response = await axios.put(`${API_BASE_URL}/users/settings`, settings);
        return response.data;
    } catch (error: any) {
        throw new Error('Error updating trading settings: ' + error.message);
    }
};

// Function to handle KYC verification
export const verifyKYC = async (userData: any) => {
    try {
        const response = await axios.post(`${API_BASE_URL}/kyc`, userData);
        return response.data;
    } catch (error: any) {
        throw new Error('Error during KYC verification: ' + error.message);
    }
};

export class AlgorithmicTradingService {
    // Method to get active strategies
    public async getActiveStrategies(account: string, tradingPair: string) {
        try {
            const response = await axios.get(`${API_BASE_URL}/strategies/active`, {
                params: { account, tradingPair }
            });
            return response.data;
        } catch (error: any) {
            throw new Error('Error fetching active strategies: ' + error.message);
        }
    }

    // Method to create a trading strategy
    public async createStrategy(strategyData: {
        account: string;
        tradingPair: string;
        strategy: string;
        investment: number;
        timeframe: string;
        stopLoss: number;
        takeProfit: number;
    }) {
        try {
            const response = await axios.post(`${API_BASE_URL}/strategies/create`, strategyData);
            return response.data;
        } catch (error: any) {
            throw new Error('Error creating trading strategy: ' + error.message);
        }
    }

    // Method to stop a trading strategy
    public async stopStrategy(strategyId: string) {
        try {
            const response = await axios.post(`${API_BASE_URL}/strategies/stop`, { strategyId });
            return response.data;
        } catch (error: any) {
            throw new Error('Error stopping trading strategy: ' + error.message);
        }
    }

    // ... other existing methods
}

export default AlgorithmicTradingService;
