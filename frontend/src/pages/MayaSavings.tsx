import React, { useEffect, useState } from 'react';
import axios from 'axios';

// Define an interface for KYC data
interface KYCData {
    description: string; // Add other properties as needed
}

const MayaSavings = () => {
    const [savingsData, setSavingsData] = useState([]);
    const [kycData, setKycData] = useState<KYCData | null>(null);
    const [loading, setLoading] = useState(true);
    const [error, setError] = useState(null);

    useEffect(() => {
        const fetchSavingsData = async () => {
            try {
                const response = await axios.get('/api/savings'); // Assuming this is the endpoint for savings data
                setSavingsData(response.data);
            } catch (err: any) {
                setError(err.message);
            } finally {
                setLoading(false);
            }
        };

        const fetchKYCData = async () => {
            try {
                const response = await axios.get('/api/kyc'); // Endpoint for KYC data
                setKycData(response.data);
            } catch (err: any) {
                setError(err.message);
            }
        };

        fetchSavingsData();
        fetchKYCData();
    }, []);

    if (loading) return <div>Loading...</div>;
    if (error) return <div>Error: {error}</div>;

    return (
        <div>
            <h1>Maya Savings</h1>
            {savingsData.length > 0 ? (
                <ul>
                    {savingsData.map((savings: { id: string; name: string; amount: number }) => (
                        <li key={savings.id}>{savings.name}: {savings.amount} saved</li>
                    ))}
                </ul>
            ) : (
                <p>No savings data available.</p>
            )}
            {kycData && (
                <div>
                    <h2>KYC Information</h2>
                    <p>{kycData.description}</p>
                </div>
            )}
        </div>
    );
};

export default MayaSavings;
