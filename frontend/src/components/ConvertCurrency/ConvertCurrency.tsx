import React, { useState } from 'react';
import { Form, Button, Alert } from 'react-bootstrap';
import { useWeb2 as useWeb3 } from '../../hooks/useWeb3';

const ConvertCurrency: React.FC = () => {
  const [amount, setAmount] = useState<number>(0);
  const [error, setError] = useState<string>('');
  const [success, setSuccess] = useState<string>('');
  const [isLoading, setIsLoading] = useState<boolean>(false);
  const { account } = useWeb3();

  const handleConversion = async (e: React.FormEvent) => {
    e.preventDefault();
    setError('');
    setSuccess('');
    setIsLoading(true);

    try {
      if (!account) {
        throw new Error('Please connect your wallet');
      }

      if (amount <= 0) {
          if (amount <= 0) {
            setError('Amount must be greater than zero');
            setIsLoading(false);
            return;
          }
        }
        const kycService = await import('../../services/kycService');
        const isKYCCompleted = await kycService.checkKYCStatus(account);
        if (!isKYCCompleted) {
          setError('KYC verification is required to proceed with the conversion');
          setIsLoading(false);
          return;
        }

      // Process the currency conversion (this is a placeholder for actual conversion logic)
      // await currencyService.convertCurrency(account, amount);

      setSuccess('Currency converted successfully');
    } catch (err: any) {
      setError(err.message || 'Failed to convert currency');
    } finally {
      setIsLoading(false);
    }
  };

  return (
    <div className="convertCurrencyContainer">
      <h2>Convert Currency</h2>
      {error && <Alert variant="danger">{error}</Alert>}
      {success && <Alert variant="success">{success}</Alert>}

      <Form onSubmit={handleConversion}>
        <Form.Group className="form-group">
          <Form.Label>Amount</Form.Label>
          <Form.Control
            type="number"
            value={amount}
            onChange={(e) => setAmount(Number(e.target.value))}
            required
          />
        </Form.Group>
        <Button type="submit" className="btn-submit" disabled={isLoading}>
          {isLoading ? 'Converting...' : 'Convert'}
        </Button>
      </Form>
    </div>
  );
};

export default ConvertCurrency;
