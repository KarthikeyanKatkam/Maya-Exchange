import React, { useState, useEffect } from 'react';
import { fetchKYCData, submitKYCData } from '../api/kycApi'; // Assuming these functions are defined in your API module

// Define the interface for KYC data
interface KYCData {
    // Define the properties of KYC data here
    // For example:
    id: string;
    name: string;
    // Add other properties as needed
}

const KYCVerification = () => {
    const [kycData, setKycData] = useState<KYCData | null>(null); // Use the defined type
    const [loading, setLoading] = useState(true);
    const [error, setError] = useState<string | null>(null); // Type error as string or null

    useEffect(() => {
        const loadKYCData = async () => {
            try {
                const data = await fetchKYCData();
                setKycData(data as KYCData); // Use type assertion to ensure data matches KYCData type
            } catch (err: any) {
                setError(err.message);
            } finally {
                setLoading(false);
            }
        };

        loadKYCData();
    }, []);

    const handleSubmit = async (event: React.FormEvent<HTMLFormElement>) => {
        event.preventDefault();
        try {
            await submitKYCData(kycData);
            alert('KYC data submitted successfully!');
        } catch (err: any) {
            setError(err.message);
        }
    };

    if (loading) return <div>Loading...</div>;
    if (error) return <div>Error: {error}</div>;

    return (
        <div>
            <h1>KYC Verification</h1>
            <form onSubmit={handleSubmit}>
                {/* Render KYC data fields here */}
                <button type="submit">Submit KYC</button>
            </form>
        </div>
    );
};

export default KYCVerification;
