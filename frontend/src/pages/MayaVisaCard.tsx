import React, { useState, useEffect } from 'react';
import axios from 'axios';

interface UserData {
    name: string;
    balance: number;
}

const MayaVisaCard = () => {
    const [userData, setUserData] = useState<UserData | null>(null);
    const [loading, setLoading] = useState<boolean>(true);
    const [error, setError] = useState<Error | null>(null);

    useEffect(() => {
        const fetchUserData = async () => {
            try {
                const response = await axios.get('/users'); // Fetch user data from the API
                setUserData(response.data);
            } catch (err: any) {
                setError(err);
            } finally {
                setLoading(false);
            }
        };

        fetchUserData();
    }, []);

    if (loading) return <div>Loading...</div>;
    if (error) return <div>Error: {error.message}</div>;

    return (
        <div>
            <h1>Maya Visa Card</h1>
            {userData && (
                <div>
                    <h2>Welcome, {userData.name}</h2>
                    <p>Your account balance is: {userData.balance}</p>
                </div>
            )}
        </div>
    );
};

export default MayaVisaCard;
