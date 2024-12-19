// action.ts
export const SET_USER = 'SET_USER';
export const SET_BALANCE = 'SET_BALANCE';
export const SET_CRYPTO_BALANCE = 'SET_CRYPTO_BALANCE';
export const SET_TRADE_HISTORY = 'SET_TRADE_HISTORY';

// User Action
export const setUser = (user: { name: string; email: string; kycStatus: string }) => ({
  type: SET_USER,
  payload: user,
});

// Wallet Action
export const setBalance = (balance: number) => ({
  type: SET_BALANCE,
  payload: balance,
});

export const setCryptoBalance = (cryptoBalance: number) => ({
  type: SET_CRYPTO_BALANCE,
  payload: cryptoBalance,
});

// Trade Action
export const setTradeHistory = (tradeHistory: any[]) => ({
  type: SET_TRADE_HISTORY,
  payload: tradeHistory,
});
