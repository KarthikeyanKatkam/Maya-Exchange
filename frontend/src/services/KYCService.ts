import axios from 'axios';

const API_BASE_URL = '/api'; // Base URL for API calls

export class KYCService {
    static async checkKYCStatus(account: string): Promise<boolean> {
        // Simulate a KYC check. Replace with actual implementation.
        return new Promise((resolve) => {
            setTimeout(() => {
                resolve(true); // Assume KYC is completed for demonstration
            }, 1000);
        });
    }
}

export const fetchUserKYCStatus = async (account: string): Promise<boolean> => {
  // Your logic to fetch KYC status
  // For example, simulate an API call
  const response = await axios.get(`${API_BASE_URL}/kyc-status/${account}`);
  return response.data.isKYCCompleted; // Ensure this returns a boolean
};