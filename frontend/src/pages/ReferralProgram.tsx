import React, { useEffect, useState } from 'react';
import axios from 'axios';

const ReferralProgram = () => {
    const [referralCode, setReferralCode] = useState('');
    const [referralLink, setReferralLink] = useState('');

    useEffect(() => {
        // Fetch the user's referral code from the API
        const fetchReferralCode = async () => {
            try {
                const response = await axios.get('/users/referral-code');
                setReferralCode(response.data.code);
                setReferralLink(`${window.location.origin}/referral/${response.data.code}`);
            } catch (error) {
                console.error('Error fetching referral code:', error);
            }
        };

        fetchReferralCode();
    }, []);

    return (
        <div className="referral-program">
            <h1>Referral Program</h1>
            <p>Your referral code: <strong>{referralCode}</strong></p>
            <p>Share this link with your friends: <a href={referralLink}>{referralLink}</a></p>
        </div>
    );
};

export default ReferralProgram;
