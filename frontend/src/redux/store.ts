import { createStore, applyMiddleware, Middleware } from 'redux';
import rootReducer from './reducers';
import thunk, { ThunkMiddleware } from 'redux-thunk';

const middleware: Middleware[] = [(thunk as unknown) as ThunkMiddleware];

const store = createStore(rootReducer, applyMiddleware(...middleware));

export default store;