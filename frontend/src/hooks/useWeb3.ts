import { useEffect, useState } from 'react';
import { checkKYCStatus } from '../../services/kycService'; // Ensure this service exists and is correctly imported

declare global {
  interface Window {
    ethereum: any; // Declare the ethereum property on the Window interface
  }
}

const useWeb3 = () => {
  const [account, setAccount] = useState<string | null>(null);
  const [provider, setProvider] = useState<any>(null);
  const [isLoading, setIsLoading] = useState<boolean>(true);
  const [error, setError] = useState<string | null>(null);
  const [isKYCCompleted, setIsKYCCompleted] = useState<boolean>(false); // State for KYC status

  useEffect(() => {
    const initWeb3 = async () => {
      setIsLoading(true);
      try {
        if (typeof window !== 'undefined' && window.ethereum) {
          const web3Provider = window.ethereum as unknown as { request: (args: { method: string }) => Promise<string[]> };
          setProvider(web3Provider);
          const accounts = await web3Provider.request({ method: 'eth_requestAccounts' });
          setAccount(accounts[0]);

          // Check KYC status after account is set
          const kycStatus = await checkKYCStatus(accounts[0]);
          setIsKYCCompleted(kycStatus); // Update KYC status
        } else {
          setError('Please install MetaMask!');
        }
      } catch (err) {
        setError(err instanceof Error ? err.message : 'An error occurred');
      } finally {
        setIsLoading(false);
      }
    };

    initWeb3().catch(err => {
      setError(err instanceof Error ? err.message : 'An error occurred');
      setIsLoading(false);
    });
  }, []);

  return { account, provider, isLoading, error, isKYCCompleted }; // Return KYC status
};

export default useWeb3;
