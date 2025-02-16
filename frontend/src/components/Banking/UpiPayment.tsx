import React, { useState } from 'react';
import { Card, Form, Button, Alert } from 'react-bootstrap';
import useWeb2 from '../../hooks/useWeb3'; // Fixed import statement
const UpiPayment: React.FC = () => {
  const [amount, setAmount] = useState<number>(0);
  const [error, setError] = useState<string>('');
  const [success, setSuccess] = useState<string>(''); // Added success state initialization
  const [isLoading, setIsLoading] = useState<boolean>(false); // Added loading state initialization
  const { account } = useWeb2(); // Removed duplicate declaration
  const kycService = new (require('../../services/KYCService')).default();

  const handlePayment = async (e: React.FormEvent) => {
    e.preventDefault();
    setError('');
    setSuccess('');
    setIsLoading(true);

    try {
      if (!account) {
        throw new Error('Please connect your wallet');
      }

      if (amount <= 0) {
        throw new Error('Amount must be greater than zero');
      }

      // Call KYC service to verify user before processing payment
      const isKYCCompleted = await kycService.checkKYCStatus(account);
      if (!isKYCCompleted) {
        throw new Error('KYC verification is required to proceed with the payment');
      }

      // Process the payment (this is a placeholder for actual payment logic)
      // await paymentService.processPayment(account, amount);

      setSuccess('Payment processed successfully');
    } catch (err: any) {
      setError(err.message || 'Failed to process payment');
    } finally {
      setIsLoading(false);
    }
  };

  return (
    <Card className="mb-3">
      <Card.Header>
        <h5>UPI Payment</h5>
      </Card.Header>
      <Card.Body>
        {error && <Alert variant="danger">{error}</Alert>}
        {success && <Alert variant="success">{success}</Alert>}

        <Form onSubmit={handlePayment}>
          <Form.Group className="mb-3">
            <Form.Label>Amount</Form.Label>
            <Form.Control
              type="number"
              value={amount}
              onChange={(e) => setAmount(Number(e.target.value))}
              required
            />
          </Form.Group>

          <Button type="submit" disabled={isLoading}>
            {isLoading ? 'Processing Payment...' : 'Pay via UPI'}
          </Button>
        </Form>
      </Card.Body>
    </Card>
  );
};

export default UpiPayment;
