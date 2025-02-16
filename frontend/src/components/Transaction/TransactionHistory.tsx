import React from 'react';

interface TransactionHistoryProps {
    userId: string;
}

const TransactionHistory: React.FC<TransactionHistoryProps> = ({ userId }) => {
    return (
        <div>
            <p>User ID: {userId}</p>
        </div>
    );
};

export default TransactionHistory; 