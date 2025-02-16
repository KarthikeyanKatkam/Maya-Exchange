import React, { useEffect, useState } from 'react';
import axios from 'axios';

interface KYCData {
    description: string;
}

const NFTMarketplace = () => {
    const [nftData, setNftData] = useState([]);
    const [userAccessibleFeatures, setUserAccessibleFeatures] = useState([]);
    const [kycData, setKycData] = useState<KYCData | null>(null);
    const [loadingNft, setLoadingNft] = useState(true);
    const [loadingFeatures, setLoadingFeatures] = useState(true);
    const [loadingKYC, setLoadingKYC] = useState(true);
    const [error, setError] = useState(null);

    useEffect(() => {
        const fetchNftData = async () => {
            try {
                const response = await axios.get('/api/nfts'); // Endpoint for NFT data
                setNftData(response.data);
            } catch (err: any) {
                setError(err.message);
            } finally {
                setLoadingNft(false);
            }
        };

        const fetchUserAccessibleFeatures = async () => {
            try {
                const response = await axios.get('/api/user-accessible-features'); // Endpoint for user-accessible features
                setUserAccessibleFeatures(response.data);
            } catch (err: any) {
                setError(err.message);
            } finally {
                setLoadingFeatures(false);
            }
        };

        const fetchKycData = async () => {
            try {
                const response = await axios.get('/api/kyc'); // Endpoint for KYC data
                setKycData(response.data);
            } catch (err: any) {
                setError(err.message);
            } finally {
                setLoadingKYC(false);
            }
        };

        fetchNftData();
        fetchUserAccessibleFeatures();
        fetchKycData();
    }, []);

    if (loadingNft || loadingFeatures || loadingKYC) return <div>Loading...</div>;
    if (error) return <div>Error: {error}</div>;

    return (
        <div>
            <h1>NFT Marketplace</h1>
            <h2>NFT Listings</h2>
            <ul>
                {nftData.map((nft: { id: string; name: string; description: string }) => (
                    <li key={nft.id}>{nft.name}: {nft.description}</li>
                ))}
            </ul>
            <h2>User-Accessible Features</h2>
            <ul>
                {userAccessibleFeatures.map((feature: { name: string }, index: number) => (
                    <li key={index}>{feature.name}</li>
                ))}
            </ul>
            {kycData && (
                <div>
                    <h2>KYC Information</h2>
                    <p>{kycData.description}</p>
                </div>
            )}
        </div>
    );
};

export default NFTMarketplace;
