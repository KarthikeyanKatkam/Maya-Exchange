import React, { useState, useEffect } from 'react';
import { Card, Form, Button, Alert, Table } from 'react-bootstrap';
import { useWeb2 } from '../../hooks/useWeb3';
import { CopyTradingService } from '../../services/copyTrading.service';
import { formatCurrency } from '../../utils/formatters';

interface CopyTradingProps {
  tradingPair: string;
}

const CopyTrading: React.FC<CopyTradingProps> = ({ tradingPair }) => {
  const [traders, setTraders] = useState<any[]>([]);
  const [selectedTrader, setSelectedTrader] = useState<string>('');
  const [amount, setAmount] = useState<number>(0);
  const [error, setError] = useState<string>('');
  const [success, setSuccess] = useState<string>('');
  const [isLoading, setIsLoading] = useState<boolean>(false);

  const { account } = useWeb2();
  const copyTradingService = new CopyTradingService();

  useEffect(() => {
    loadTopTraders();
  }, []);

  const loadTopTraders = async () => {
    try {
      const topTraders = await copyTradingService.getTopTraders(tradingPair);
      setTraders(topTraders);
    } catch (err: any) {
      setError('Failed to load top traders');
    }
  };

  const handleCopyTrading = async (e: React.FormEvent) => {
    e.preventDefault();
    setError('');
    setSuccess('');
    setIsLoading(true);

    try {
      if (!selectedTrader || amount <= 0) {
        throw new Error('Please select a trader and enter a valid amount');
      }

      await copyTradingService.startCopyTrading(selectedTrader, amount, tradingPair);
      setSuccess('Successfully started copy trading');
      
    } catch (err: any) {
      setError(err.message || 'Failed to start copy trading');
    } finally {
      setIsLoading(false);
    }
  };

  return (
    <Card className="mb-4">
      <Card.Header>
        <h4>Copy Trading</h4>
      </Card.Header>
      <Card.Body>
        {error && <Alert variant="danger">{error}</Alert>}
        {success && <Alert variant="success">{success}</Alert>}

        <Form onSubmit={handleCopyTrading}>
          <Form.Group className="mb-3">
            <Form.Label>Select Trader</Form.Label>
            <Form.Select 
              value={selectedTrader}
              onChange={(e) => setSelectedTrader(e.target.value)}
            >
              <option value="">Choose a trader...</option>
              {traders.map((trader) => (
                <option key={trader.id} value={trader.id}>
                  {trader.name} - Success Rate: {trader.successRate}%
                </option>
              ))}
            </Form.Select>
          </Form.Group>

          <Form.Group className="mb-3">
            <Form.Label>Investment Amount</Form.Label>
            <Form.Control
              type="number"
              value={amount}
              onChange={(e) => setAmount(Number(e.target.value))}
              min="0"
              step="0.01"
            />
          </Form.Group>

          <Button 
            type="submit" 
            variant="primary"
            disabled={isLoading}
          >
            {isLoading ? 'Starting...' : 'Start Copy Trading'}
          </Button>
        </Form>

        <Table className="mt-4" striped bordered hover>
          <thead>
            <tr>
              <th>Trader</th>
              <th>Success Rate</th>
              <th>Total Profit</th>
              <th>Active Followers</th>
            </tr>
          </thead>
          <tbody>
            {traders.map((trader) => (
              <tr key={trader.id}>
                <td>{trader.name}</td>
                <td>{trader.successRate}%</td>
                <td>{formatCurrency(trader.totalProfit)}</td>
                <td>{trader.followers}</td>
              </tr>
            ))}
          </tbody>
        </Table>
      </Card.Body>
    </Card>
  );
};

export default CopyTrading;
