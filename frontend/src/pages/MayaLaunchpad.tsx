import React, { useEffect, useState } from 'react';
import axios from 'axios';

interface KYCData {
    description: string;
    // Add other properties as needed
}

const MayaLaunchpad = () => {
    const [userAccessibleFeatures, setUserAccessibleFeatures] = useState([]);
    const [kycData, setKycData] = useState<KYCData | null>(null);
    const [loadingFeatures, setLoadingFeatures] = useState(true);
    const [loadingKYC, setLoadingKYC] = useState(true);
    const [error, setError] = useState<Error | null>(null);

    useEffect(() => {
        const fetchUserAccessibleFeatures = async () => {
            try {
                const response = await axios.get('/api/user-accessible-features');
                setUserAccessibleFeatures(response.data);
            } catch (error: any) {
                setError(error);
            } finally {
                setLoadingFeatures(false);
            }
        };

        const fetchKycData = async () => {
            try {
                const response = await axios.get('/api/kyc');
                setKycData(response.data);
            } catch (error: any) {
                setError(error);
            } finally {
                setLoadingKYC(false);
            }
        };

        fetchUserAccessibleFeatures();
        fetchKycData();
    }, []);

    if (loadingFeatures || loadingKYC) return <div>Loading...</div>;
    if (error) return <div>Error: {error.message}</div>;
    if (!userAccessibleFeatures || !kycData) return <div>No data available</div>;

    return (
        <div>
            <h1>Maya Launchpad</h1>
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

export default MayaLaunchpad;
