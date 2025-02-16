import React, { useState } from 'react';
import axios from 'axios';

const DepositWithdraw = () => {
    const [amount, setAmount] = useState('');
    const [transactionType, setTransactionType] = useState('deposit'); // 'deposit' or 'withdraw'
    const [message, setMessage] = useState('');

    const handleAmountChange = (e: { target: { value: React.SetStateAction<string>; }; }) => {
        setAmount(e.target.value);
    };

    const handleTransactionTypeChange = (e: { target: { value: React.SetStateAction<string>; }; }) => {
        setTransactionType(e.target.value);
    };

    const handleSubmit = async (e: { preventDefault: () => void; }) => {
        e.preventDefault();
        try {
            const response = await axios.post('/transactions', {
                type: transactionType,
                amount: parseFloat(amount),
            });
            setMessage(`Transaction successful: ${response.data.message}`);
        } catch (error) {
            if (axios.isAxiosError(error) && error.response) {
                setMessage(`Transaction failed: ${error.response.data.message}`);
            } else {
                setMessage('Transaction failed: An unknown error occurred.');
            }
        }
    };

    return (
        <div>
            <h1>{transactionType.charAt(0).toUpperCase() + transactionType.slice(1)}</h1>
            <form onSubmit={handleSubmit}>
                <label>
                    Amount:
                    <input type="number" value={amount} onChange={handleAmountChange} required />
                </label>
                <label>
                    Transaction Type:
                    <select value={transactionType} onChange={handleTransactionTypeChange}>
                        <option value="deposit">Deposit</option>
                        <option value="withdraw">Withdraw</option>
                    </select>
                </label>
                <button type="submit">Submit</button>
            </form>
            {message && <p>{message}</p>}
        </div>
    );
};

export default DepositWithdraw;
