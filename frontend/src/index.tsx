import React from 'react';
import { createRoot } from 'react-dom/client';
import App from './App';
import './styles/global.css'; // Assuming you have some global styles

const rootElement = document.getElementById('root');

if (rootElement) {
    const root = createRoot(rootElement);
    root.render(
        <React.StrictMode>
            <App />
        </React.StrictMode>
    );
}
