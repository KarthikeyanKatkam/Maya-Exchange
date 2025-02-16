import React, { useState } from 'react';
import { Card, Form, Button, Alert } from 'react-bootstrap';
import useWeb3 from '../../hooks/useWeb3';
import { CurrencyConversionService } from '../../services/currencyConversion.service'; // Assuming a service for currency conversion exists

interface ConvertCurrencyProps {
  convert?: () => void;
}

const ConvertCurrency: React.FC<ConvertCurrencyProps> = ({ convert }) => {
  const [amount, setAmount] = useState<number>(0);
  const [fromCurrency, setFromCurrency] = useState<string>('USD');
  const [toCurrency, setToCurrency] = useState<string>('EUR');
  const [convertedAmount, setConvertedAmount] = useState<number | null>(null);
  const [error, setError] = useState<string>('');
  const [isLoading, setIsLoading] = useState<boolean>(false);
  const { account } = useWeb3();

  const handleConversion = async (e: React.FormEvent) => {
    e.preventDefault();
    setError('');
    setConvertedAmount(null);
    setIsLoading(true);

    try {
      if (!account) {
        throw new Error('Please connect your wallet');
      }

      if (amount <= 0) {
        throw new Error('Amount must be greater than zero');
      }

      const result = await CurrencyConversionService.convertCurrency(amount, fromCurrency, toCurrency);
      setConvertedAmount(result);
    } catch (err: any) {
      setError(err.message || 'Failed to convert currency');
    } finally {
      setIsLoading(false);
    }

    if (convert) {
      convert();
    }
  };

  return (
    <Card className="mb-3">
      <Card.Header>
        <h5>Convert Currency</h5>
      </Card.Header>
      <Card.Body>
        {error && <Alert variant="danger">{error}</Alert>}
        {convertedAmount !== null && (
          <Alert variant="success">Converted Amount: {convertedAmount.toFixed(2)} {toCurrency}</Alert>
        )}
        <Form onSubmit={handleConversion}>
          <Form.Group className="mb-3">
            <Form.Label>Amount</Form.Label>
            <Form.Control
              type="number"
              value={amount}
              onChange={(e) => setAmount(Number(e.target.value))}
              required
            />
          </Form.Group>
          <Form.Group className="mb-3">
            <Form.Label>From Currency</Form.Label>
            <Form.Control
              as="select"
              value={fromCurrency}
              onChange={(e) => setFromCurrency(e.target.value)}
            >
              <option value="USD">USD</option>
              <option value="EUR">EUR</option>
              <option value="GBP">GBP</option>
              {/* Add more currencies as needed */}
            </Form.Control>
          </Form.Group>
          <Form.Group className="mb-3">
            <Form.Label>To Currency</Form.Label>
            <Form.Control
              as="select"
              value={toCurrency}
              onChange={(e) => setToCurrency(e.target.value)}
            >
              <option value="EUR">EUR</option>
              <option value="USD">USD</option>
              <option value="GBP">GBP</option>
              {/* Add more currencies as needed */}
            </Form.Control>
          </Form.Group>
          <Button type="submit" disabled={isLoading}>
            {isLoading ? 'Converting...' : 'Convert'}
          </Button>
        </Form>
      </Card.Body>
    </Card>
  );
};

export default ConvertCurrency;
