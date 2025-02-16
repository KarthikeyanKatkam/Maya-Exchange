import React from 'react';
import { useEffect, useState } from 'react';
import axios from 'axios';

// Define the interface for KYC information
interface KYCInfo {
    description: string; // Add other properties as needed
}

const MayaAcademy = () => {
    const [features, setFeatures] = useState<{ name: string }[]>([]);
    const [kycInfo, setKycInfo] = useState<KYCInfo | null>(null); // Use the defined type

    useEffect(() => {
        const fetchFeatures = async () => {
            try {
                const response = await axios.get('/api/features');
                setFeatures(response.data);
            } catch (error) {
                console.error('Error fetching features:', error);
            }
        };

        const fetchKycInfo = async () => {
            try {
                const response = await axios.get('/api/kyc');
                setKycInfo(response.data); // Ensure response.data matches KYCInfo type
            } catch (error) {
                console.error('Error fetching KYC information:', error);
            }
        };

        fetchFeatures();
        fetchKycInfo();
    }, []);

    return (
        <div>
            <h1>Maya Academy</h1>
            <h2>User-Accessible Features</h2>
            <ul>
                {features.map((feature, index) => (
                    <li key={index}>{feature.name}</li>
                ))}
            </ul>
            {kycInfo && (
                <div>
                    <h2>KYC Information</h2>
                    <p>{kycInfo.description}</p> {/* This will now work correctly */}
                </div>
            )}
        </div>
    );
};

export default MayaAcademy;
