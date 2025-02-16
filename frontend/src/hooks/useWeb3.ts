import { useEffect, useState } from 'react';
import Web3 from 'web3';

const useWeb3 = () => {
    const [web3, setWeb3] = useState<Web3 | null>(null);
    const [account, setAccount] = useState<string | null>(null);
    const [networkId, setNetworkId] = useState<number | null>(null);
    const [isKYCCompleted, setIsKYCCompleted] = useState<boolean>(false);
    const [error, setError] = useState<string>('');
    const [isLoading, setIsLoading] = useState<boolean>(true);

    useEffect(() => {
        const initWeb3 = async () => {
            if (window.ethereum) {
                const web3Instance = new Web3(window.ethereum);
                setWeb3(web3Instance);

                // Request account access
                await window.ethereum.request({ method: 'eth_requestAccounts' });
                const accounts = await web3Instance.eth.getAccounts();
                setAccount(accounts[0]);

                // Get network ID
                const id = await web3Instance.eth.net.getId();
                setNetworkId(Number(id));

                // Simulate KYC status check
                const kycStatus = true; // Replace with actual KYC check
                setIsKYCCompleted(kycStatus);
            } else {
                console.error('Ethereum wallet not detected. Please install MetaMask or another wallet.');
            }
        };

        initWeb3();
    }, []);

    useEffect(() => {
        const fetchAccount = async () => {
            // Simulate fetching account and KYC status
            try {
                // Replace with actual logic to get account
                const fetchedAccount = '0x1234567890abcdef'; // Example account
                setAccount(fetchedAccount);

                // Simulate KYC status check
                const kycStatus = true; // Replace with actual KYC check
                setIsKYCCompleted(kycStatus);
            } catch (err) {
                setError('Failed to fetch account');
            } finally {
                setIsLoading(false);
            }
        };

        fetchAccount();
    }, []);

    return { web3, account, networkId, isKYCCompleted, error, isLoading };
};

export default useWeb3;
