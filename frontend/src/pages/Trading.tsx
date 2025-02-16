import React, { useEffect, useState } from 'react';
import axios from 'axios';

const Trading = () => {
    const [tradingData, setTradingData] = useState([]);
    const [loading, setLoading] = useState(true);
    const [error, setError] = useState<Error | null>(null);

    useEffect(() => {
        const fetchTradingData = async () => {
            try {
                const response = await axios.get('/api/tradingdata'); // Assuming this is the correct endpoint
                setTradingData(response.data);
            } catch (err: any) {
                setError(err);
            } finally {
                setLoading(false);
            }
        };

        fetchTradingData();
    }, []);

    if (loading) return <div>Loading trading data...</div>;
    if (error) return <div>Error fetching trading data: {error.message}</div>;

    return (
        <div>
            <h1>Trading Dashboard</h1>
            <table>
                <thead>
                    <tr>
                        <th>Asset</th>
                        <th>Price</th>
                        <th>Volume</th>
                        <th>Change</th>
                    </tr>
                </thead>
                <tbody>
                    {tradingData.map((data: { asset: string; price: number; volume: number; change: number }) => (
                        <tr key={data.asset}>
                            <td>{data.asset}</td>
                            <td>{data.price}</td>
                            <td>{data.volume}</td>
                            <td>{data.change}</td>
                        </tr>
                    ))}
                </tbody>
            </table>
        </div>
    );
};

export default Trading;
