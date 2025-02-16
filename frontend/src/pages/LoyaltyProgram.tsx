import React, { useEffect, useState } from 'react';
import axios from 'axios';

const LoyaltyProgram = () => {
    const [loyaltyData, setLoyaltyData] = useState<any[]>([]);
    const [loading, setLoading] = useState(true);
    const [error, setError] = useState<{ message: string } | null>(null);

    useEffect(() => {
        const fetchLoyaltyData = async () => {
            try {
                const response = await axios.get('/loyalty-program'); // Assuming this is the endpoint for loyalty data
                setLoyaltyData(response.data);
            } catch (err: any) {
                setError({ message: err.message || 'An unexpected error occurred' });
            } finally {
                setLoading(false);
            }
        };

        fetchLoyaltyData();
    }, []);

    if (loading) return <div>Loading...</div>;
    if (error) return <div>Error: {error.message}</div>;

    return (
        <div>
            <h1>Loyalty Program</h1>
            {loyaltyData.length > 0 ? (
                <ul>
                    {loyaltyData.map((item) => (
                        <li key={item.id}>{item.name}: {item.points} points</li>
                    ))}
                </ul>
            ) : (
                <div>No loyalty data available.</div>
            )}
        </div>
    );
};

export default LoyaltyProgram;
