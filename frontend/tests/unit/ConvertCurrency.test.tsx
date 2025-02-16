import React from 'react';
import { render, screen } from '@testing-library/react';
import ConvertCurrency from '../../src/components/ConvertCurrency/ConvertCurrency'; // Adjust the import path as necessary

describe('ConvertCurrency Component', () => {
    test('renders ConvertCurrency component', () => {
        render(<ConvertCurrency />);
        const headingElement = screen.getByText(/convert currency/i);
        expect(headingElement).toBeInTheDocument();
    });

    test('displays currency options', () => {
        render(<ConvertCurrency />);
        const currencyOptions = screen.getAllByRole('option');
        expect(currencyOptions.length).toBeGreaterThan(0); // Ensure there are currency options
    });

    test('calls convert function on submit', () => {
        const mockConvert = jest.fn();
        render(<ConvertCurrency convert={mockConvert} />);
        
        const submitButton = screen.getByRole('button', { name: /convert/i });
        submitButton.click();
        
        expect(mockConvert).toHaveBeenCalled();
    });
});
