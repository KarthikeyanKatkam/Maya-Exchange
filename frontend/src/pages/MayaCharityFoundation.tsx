import React, { useEffect, useState } from 'react';
import axios from 'axios';

interface Charity {
    id: number; // or string, depending on your API
    name: string;
    description: string;
}

const MayaCharityFoundation = () => {
    const [charityData, setCharityData] = useState<Charity[]>([]);
    const [loading, setLoading] = useState(true);
    const [error, setError] = useState<Error | null>(null);

    useEffect(() => {
        const fetchCharityData = async () => {
            try {
                const response = await axios.get('/api/charity'); // Assuming this is the endpoint for charity data
                setCharityData(response.data);
            } catch (err: any) {
                setError(err);
            } finally {
                setLoading(false);
            }
        };

        fetchCharityData();
    }, []);

    if (loading) return <div>Loading...</div>;
    if (error) return <div>Error: {error.message}</div>;

    return (
        <div>
            <h1>Maya Charity Foundation</h1>
            {charityData.length > 0 ? (
                <ul>
                    {charityData.map((charity) => (
                        <li key={charity.id}>{charity.name}: {charity.description}</li>
                    ))}
                </ul>
            ) : (
                <p>No charity data available.</p>
            )}
        </div>
    );
};

export default MayaCharityFoundation;
