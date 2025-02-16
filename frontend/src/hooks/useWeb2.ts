import { useState, useEffect } from 'react';

export const useWeb2 = () => {
  const [account, setAccount] = useState<string | null>(null);

  useEffect(() => {
    // Logic to fetch the account
    // setAccount(fetchedAccount);
  }, []);

  return { account };
}; 