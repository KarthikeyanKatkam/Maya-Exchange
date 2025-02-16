import React, { useEffect, useState } from 'react';
import axios from 'axios';

interface Faq {
    id: number; // or string, depending on your data
    question: string;
    answer: string;
}

const Support: React.FC = () => {
    const [faqData, setFaqData] = useState<Faq[]>([]);
    const [loading, setLoading] = useState<boolean>(true);
    const [error, setError] = useState<Error | null>(null); // Specify the type for error

    useEffect(() => {
        const fetchFaqData = async () => {
            try {
                const response = await axios.get('/api/support/faqs'); // Assuming this is the correct endpoint for FAQs
                setFaqData(response.data);
            } catch (err: any) {
                setError(err);
            } finally {
                setLoading(false);
            }
        };

        fetchFaqData();
    }, []);

    if (loading) return <div>Loading FAQs...</div>;
    if (error) return <div>Error fetching FAQs: {error.message}</div>;

    return (
        <div className="support">
            <h1>Support</h1>
            <h2>Frequently Asked Questions</h2>
            <ul>
                {faqData.map((faq) => (
                    <li key={faq.id}>
                        <strong>{faq.question}</strong>
                        <p>{faq.answer}</p>
                    </li>
                ))}
            </ul>
        </div>
    );
};

export default Support;
