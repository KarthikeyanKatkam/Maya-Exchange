import React, { useEffect, useState } from 'react';
import axios from 'axios';

const RealTimeMarketData = () => {
    const [marketData, setMarketData] = useState([]);
    const [loading, setLoading] = useState(true);
    const [error, setError] = useState<Error | null>(null);

    useEffect(() => {
        const fetchMarketData = async () => {
            try {
                const response = await axios.get('/api/marketdata'); // Assuming this is the correct endpoint
                setMarketData(response.data);
            } catch (err: any) {
                setError(err);
            } finally {
                setLoading(false);
            }
        };

        fetchMarketData();
    }, []);

    if (loading) return <div>Loading...</div>;
    if (error) return <div>Error fetching market data: {error.message}</div>;

    return (
        <div>
            <h1>Real-Time Market Data</h1>
            <table>
                <thead>
                    <tr>
                        <th>Currency</th>
                        <th>Price</th>
                        <th>Change</th>
                    </tr>
                </thead>
                <tbody>
                    {marketData.map((data: { currency: string; price: number; change: number }) => (
                        <tr key={data.currency}>
                            <td>{data.currency}</td>
                            <td>{data.price}</td>
                            <td>{data.change}</td>
                        </tr>
                    ))}
                </tbody>
            </table>
        </div>
    );
};

export default RealTimeMarketData;
