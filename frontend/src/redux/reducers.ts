// reducers.ts
import { combineReducers } from 'redux';
export const SET_USER = 'SET_USER';
export const SET_BALANCE = 'SET_BALANCE';
export const SET_CRYPTO_BALANCE = 'SET_CRYPTO_BALANCE';
export const SET_TRADE_HISTORY = 'SET_TRADE_HISTORY';

interface UserState {
  name: string;
  email: string;
  kycStatus: string;
}

interface WalletState {
  balance: number;
  cryptoBalance: number;
}

interface TradeState {
  tradeHistory: any[];
}

const initialUserState: UserState = {
  name: '',
  email: '',
  kycStatus: '',
};

const initialWalletState: WalletState = {
  balance: 0,
  cryptoBalance: 0,
};

const initialTradeState: TradeState = {
  tradeHistory: [],
};

// User Reducer
const userReducer = (state = initialUserState, action: any): UserState => {
  switch (action.type) {
    case SET_USER:
      return {
        ...state,
        ...action.payload,
      };
    default:
      return state;
  }
};

// Wallet Reducer
const walletReducer = (state = initialWalletState, action: any): WalletState => {
  switch (action.type) {
    case SET_BALANCE:
      return {
        ...state,
        balance: action.payload,
      };
    case SET_CRYPTO_BALANCE:
      return {
        ...state,
        cryptoBalance: action.payload,
      };
    default:
      return state;
  }
};

// Trade Reducer
const tradeReducer = (state = initialTradeState, action: any): TradeState => {
  switch (action.type) {
    case SET_TRADE_HISTORY:
      return {
        ...state,
        tradeHistory: action.payload,
      };
    default:
      return state;
  }
};

// Combine reducers
const rootReducer = combineReducers({
  user: userReducer,
  wallet: walletReducer,
  trade: tradeReducer,
});

export default rootReducer;
