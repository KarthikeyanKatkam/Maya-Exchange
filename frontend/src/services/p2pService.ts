import axios from 'axios';
import { fetchUserKYCStatus } from './settingsService'; // Import the function

const API_BASE_URL = '/api'; // Base URL for API calls

// Function to initiate a peer-to-peer transaction
export const initiateP2PTransaction = async (senderAccount: string, receiverAccount: string, amount: number) => {
    try {
        const response = await axios.post(`${API_BASE_URL}/p2p/transaction`, { senderAccount, receiverAccount, amount });
        return response.data;
    } catch (error: any) {
        throw new Error('Error initiating P2P transaction: ' + error.message);
    }
};

// Function to fetch transaction history for a user
export const fetchTransactionHistory = async (account: string) => {
    try {
        const response = await axios.get(`${API_BASE_URL}/p2p/transactions/${account}`);
        return response.data;
    } catch (error: any) {
        throw new Error('Error fetching transaction history: ' + error.message);
    }
};

// Function to check if a user is eligible for P2P transactions based on KYC status
export const checkP2PEligibility = async (account: string): Promise<boolean> => {
    const isKYCCompleted = await fetchUserKYCStatus(account);
    return isKYCCompleted; // User must be KYC compliant to initiate P2P transactions
};
