import axios from 'axios';

const API_BASE_URL = '/api'; // Base URL for API calls

// Function to fetch NFT details for a user
export const fetchNFTDetails = async (userId: string) => {
    try {
        const response = await axios.get(`${API_BASE_URL}/nft/details/${userId}`);
        return response.data;
    } catch (error: any) {
        throw new Error('Error fetching NFT details: ' + error.message);
    }
};

// Function to mint a new NFT
export const mintNFT = async (userId: string, nftData: any) => {
    try {
        const response = await axios.post(`${API_BASE_URL}/nft/mint`, { userId, nftData });
        return response.data;
    } catch (error: any) {
        throw new Error('Error minting NFT: ' + error.message);
    }
};

// Function to transfer an NFT
export const transferNFT = async (fromUserId: string, toUserId: string, nftId: string) => {
    try {
        const response = await axios.post(`${API_BASE_URL}/nft/transfer`, { fromUserId, toUserId, nftId });
        return response.data;
    } catch (error: any) {
        throw new Error('Error transferring NFT: ' + error.message);
    }
};

// Function to log NFT feature usage
export const logNFTFeatureUsage = async (featureData: any) => {
    try {
        const response = await axios.post(`${API_BASE_URL}/analytics/nft-feature-usage`, featureData);
        return response.data;
    } catch (error: any) {
        throw new Error('Error logging NFT feature usage: ' + error.message);
    }
};
