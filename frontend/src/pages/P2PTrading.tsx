import React, { useState, useEffect } from 'react';
import axios from 'axios';

const P2PTrading = () => {
    const [transactions, setTransactions] = useState([]);
    const [error, setError] = useState(null);

    useEffect(() => {
        const fetchTransactions = async () => {
            try {
                const response = await axios.get('/transactions');
                setTransactions(response.data);
            } catch (err: any) {
                setError(err.message);
            }
        };

        fetchTransactions();
    }, []);

    return (
        <div>
            <h1>P2P Trading</h1>
            {error && <p>Error: {error}</p>}
            <ul>
                {transactions.map((transaction: { id: string; type: string; amount: number; currency: string }) => (
                    <li key={transaction.id}>
                        {transaction.type}: {transaction.amount} {transaction.currency}
                    </li>
                ))}
            </ul>
        </div>
    );
};

export default P2PTrading;
