import React, { useEffect, useState } from 'react';
import axios from 'axios';

interface KYCData {
    description: string;
    // Add other properties as needed
}

const MayaDEX = () => {
    const [userAccessibleFeatures, setUserAccessibleFeatures] = useState([]);
    const [kycData, setKycData] = useState<KYCData | null>(null);
    const [loadingFeatures, setLoadingFeatures] = useState(true);
    const [loadingKYC, setLoadingKYC] = useState(true);
    const [error, setError] = useState(null);

    useEffect(() => {
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

        const fetchKYCData = async () => {
            try {
                const response = await axios.get('/api/kyc'); // Endpoint for KYC data
                setKycData(response.data);
            } catch (err: any) {
                setError(err.message);
            } finally {
                setLoadingKYC(false);
            }
        };

        fetchUserAccessibleFeatures();
        fetchKYCData();
    }, []);

    if (loadingFeatures || loadingKYC) return <div>Loading...</div>;
    if (error) return <div>Error: {error}</div>;

    return (
        <div>
            <h1>Maya DEX</h1>
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

export default MayaDEX;
