import React, { useEffect, useState } from 'react';
import axios from 'axios';

const Home = () => {
    const [userData, setUserData] = useState<{ id: string; name: string }[] | null>(null);
    const [loading, setLoading] = useState(true);
    const [error, setError] = useState<{ message: string } | null>(null);

    useEffect(() => {
        const fetchUserData = async () => {
            try {
                const response = await axios.get('/users');
                setUserData(response.data);
            } catch (err: unknown) {
                if (axios.isAxiosError(err)) {
                    setError({ message: err.response?.data || err.message });
                } else {
                    setError({ message: 'An unexpected error occurred' });
                }
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
            <h1>User Data</h1>
            {userData && Array.isArray(userData) && (
                <ul>
                    {userData.map((user) => (
                        <li key={user.id}>{user.name}</li>
                    ))}
                </ul>
            )}
        </div>
    );
};

export default Home;
