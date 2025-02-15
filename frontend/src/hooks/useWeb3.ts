import { useState, useEffect } from 'react';
import Web3 from 'web3';

export interface Web2State {
  web2: Web3 | null;
  account: string | null;
}

export const useWeb2 = () => {
  const [web2State, setWeb2State] = useState<Web2State>({
    web2: null,
    account: null
  });

  useEffect(() => {
    const initWeb2 = async () => {
      if (typeof window !== 'undefined' && (window as any).ethereum) {
        const web3 = new Web3((window as any).ethereum);
        try {
          const accounts = await (window as any).ethereum.request({ 
            method: 'eth_requestAccounts' 
          });
          setWeb2State({
            web2: web3,
            account: accounts[0] // Corrected index to 0
          });
        } catch (error) {
          console.error('User denied account access');
        }
      }
    };

    initWeb2();
  }, []);

  return web2State;
}; 